using DFe.Classes.Entidades;
using DFe.Classes.Flags;
using DFe.Utils;
using NFe.Classes;
using NFe.Classes.Informacoes;
using NFe.Classes.Informacoes.Destinatario;
using NFe.Classes.Informacoes.Detalhe;
using NFe.Classes.Informacoes.Detalhe.Tributacao;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal;
using NFe.Classes.Informacoes.Emitente;
using NFe.Classes.Informacoes.Identificacao;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using NFe.Classes.Informacoes.Observacoes;
using NFe.Classes.Informacoes.Pagamento;
using NFe.Classes.Informacoes.Transporte;
using NFe.Classes.Servicos.Autorizacao;
using NFe.Classes.Servicos.Tipos;
using NFe.Danfe.Fast.NFCe;
using NFe.Servicos;
using NFe.Servicos.Retorno;
using NFe.Utils;
using NFe.Utils.Excecoes;
using NFe.Utils.InformacoesSuplementares;
using NFe.Utils.NFe;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.FISCAL.Base.NFCe;
using PDV.CONTROLLER.FISCAL.Util;
using PDV.CONTROLLER.NFCE.Configuracao;
using PDV.CONTROLLER.NFCE.Util;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.PDV;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PDV.CONTROLLER.NFCE.Transmissao
{
    public class EventosNFCe : IConfigNFCe
    {
        public DAO.Entidades.PDV.Venda VENDA = null;
        public List<ItemVenda> ITENS_VENDA = null;
        public List<DuplicataNFCe> PAGAMENTOS = null;
        public decimal? IDMovimentoFiscal;

        public string VERSAO = string.Empty;
        public int SERIE = 1;
        public int NUMERO;

        public decimal? IDCLiente;
        public decimal? TipoCliente = null; // 0 FISICA, 1 JURIDICA
        public string CPF_CNPJ = string.Empty;
        public string NOME_CLIENTE = string.Empty;
        public string RAZAO = string.Empty;
        
        private readonly string EMAILCLIENTE = string.Empty;

        private NFe.Classes.NFe _nfe;
        private List<TributoNFCe> ListaDeTributos = new List<TributoNFCe>();
        private Emitente EMITENTE = null;

        public Action<object, EventArgs> RetornoMensagem { get; set; }

        public EventosNFCe()
        {
            EMITENTE = FuncoesEmitente.GetEmitente();
        }

        protected virtual NFe.Classes.NFe GetNf(int numero, ModeloDocumento modelo, VersaoServico versao)
        {
            return new NFe.Classes.NFe { infNFe = GetInf(numero, modelo, versao) };
        }

        protected dest GetDestinatario(VersaoServico versao, ModeloDocumento modelo)
        {
            if (!IDCLiente.HasValue)
            {
                return null;
            }

            dest dest = TipoCliente.Value == 0 ?
               new dest(versao)
               {
                   CNPJ = ControllerFiscalUtil.SomenteNumeros(CPF_CNPJ),
                   //xNome = CONFIG_NFCe.CfgServico.tpAmb == TipoAmbiente.Homologacao ? "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL" : CPF_CNPJ
                   xNome = CONFIG_NFCe.CfgServico.tpAmb == TipoAmbiente.Homologacao ? "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL" : RAZAO
                   

               } :
               new dest(versao)
               {
                   CPF = ControllerFiscalUtil.SomenteNumeros(CPF_CNPJ),
                   xNome = CONFIG_NFCe.CfgServico.tpAmb == TipoAmbiente.Homologacao ? "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL" : NOME_CLIENTE
                   


               };

            

            if (!string.IsNullOrEmpty(EMAILCLIENTE))
            {
                dest.email = EMAILCLIENTE;
            }





            if (versao == VersaoServico.Versao310)
            {
                dest.indIEDest = indIEDest.NaoContribuinte;
            }

            dest.indIEDest = indIEDest.NaoContribuinte;
            return dest;
        }

        protected det GetDetalhe(ItemVenda Item, int i, CRT crt, ModeloDocumento modelo)
        {



            Produto _Produto = FuncoesProduto.GetProduto(Item.IDProduto);
            _Produto.EAN = _Produto.EAN;

            if (_Produto.EAN == "" || String.IsNullOrEmpty(_Produto.EAN) || _Produto.EAN.Substring(0,1) == "2")
            {
                _Produto.EAN = "SEM GTIN";
            }

            if (_Produto.EAN.Length != 13)
            {
                _Produto.EAN = "SEM GTIN";
            }
            _Produto.IDNCM = _Produto.IDNCM;      

            _Produto.Descricao = CONFIG_NFCe.CfgServico.tpAmb == TipoAmbiente.Homologacao ? "NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL" : _Produto.Descricao.TrimEnd();

            Ncm NcmVigente = FuncoesNcm.GetItemTributoVigente(FuncoesNcm.GetNCM(_Produto.IDNCM).Codigo, string.IsNullOrEmpty(_Produto.EXTipi) ? null : (decimal?)Convert.ToDecimal(_Produto.EXTipi), VENDA.DataCadastro);


            if (NcmVigente == null)
            {
                throw new Exception(string.Format("O produto \"{0}\" não possui tributação vigênte. Verifique o cadastro do IBPT e tente novamente.", _Produto.Descricao));
            }

            decimal ValorTributosNacional = 0;
            decimal ValorTributosEstadual = 0;
            decimal ValorTributosMunicipal = 0;

            UnidadeMedida unidadeMedida = FuncoesUnidadeMedida.GetUnidadeMedida(_Produto.IDUnidadeDeMedida);

            if (unidadeMedida.Descricao.Contains("KG") || unidadeMedida.Descricao.Contains("kilo") || unidadeMedida.Descricao.Contains("kg"))
            {
                decimal quantidade = Item.Quantidade;
                ValorTributosNacional = (_Produto.ValorVenda * (NcmVigente.NacionalFederal / 100)) * quantidade;
                ValorTributosEstadual = (_Produto.ValorVenda * (NcmVigente.Estadual / 100)) * quantidade;
                ValorTributosMunicipal = (_Produto.ValorVenda * (NcmVigente.Municipal / 100)) * quantidade;
            }
            else
            {
                ValorTributosNacional = (_Produto.ValorVenda * (NcmVigente.NacionalFederal / 100)) * Item.Quantidade;
                ValorTributosEstadual = (_Produto.ValorVenda * (NcmVigente.Estadual / 100)) * Item.Quantidade;
                ValorTributosMunicipal = (_Produto.ValorVenda * (NcmVigente.Municipal / 100)) * Item.Quantidade;
            }

            ListaDeTributos.Add(new TributoNFCe()
            {
                IDProduto = _Produto.IDProduto,
                PercentualEstadual = ValorTributosEstadual,
                PercentualFederal = ValorTributosNacional,
                PercentualMunicipal = ValorTributosMunicipal,
                NCM = NcmVigente
            });

            if (!_Produto.IDIntegracaoFiscalNFCe.HasValue)
            {
                throw new Exception("Produto sem Integração Fiscal NFC-e configurada. Verifique e tente novamente.");
            }

            IntegracaoFiscal Integ = FuncoesIntegracaoFiscal.GetIntegracao(_Produto.IDIntegracaoFiscalNFCe.Value);
            decimal BaseCalculo = (Item.Subtotal - Item.DescontoValor);

            //string fmt = ;
           // string strNCM = NcmVigente.Codigo(fmt);// decValue.ToString(fmt);

            prod Prod = Produtos.GetProduto(_Produto.Descricao, _Produto.IDProduto, _Produto.EAN, FuncoesNcm.GetNCM(_Produto.IDNCM).Codigo.ToString("00000000.##"), Convert.ToInt32(FuncoesCFOP.GetCFOP(FuncoesIntegracaoFiscal.GetIntegracao(_Produto.IDIntegracaoFiscalNFCe.Value).IDCFOP).Codigo), FuncoesUnidadeMedida.GetUnidadeMedida(_Produto.IDUnidadeDeMedida).Sigla, Item.Quantidade, Item.ValorUnitarioItem, Item.DescontoValor, _Produto.CEST, _Produto.EXTipi);
            det Det = Detalhe.GetDetalhe(Prod, new imposto
            {
                vTotTrib = ValorTributosNacional + ValorTributosEstadual + ValorTributosMunicipal,

                //ICMSUFDest = new ICMSUFDest()
                //{
                //    pFCPUFDest = 0,
                //    pICMSInter = 0,
                //    pICMSInterPart = 0,
                //    pICMSUFDest = 0,
                //    vBCUFDest = 0,
                //    vFCPUFDest = 0,
                //    vICMSUFDest = 0,
                //    vICMSUFRemet = 0
                //},
                ICMS = new ICMS
                {
                    TipoICMS = Imposto.GetICMS(Convert.ToInt32(FuncoesCst.GetCSTIcmsPorID(Integ.IDCSTIcms).CSTCSOSN),
                            Convert.ToInt32(FuncoesOrigemProduto.GetOrigemProduto(_Produto.IDOrigemProduto).Codigo),
                            BaseCalculo,
                            Integ.ICMS == 0 ? 0 : (Integ.ICMS_CDIFERENCIADO == 1 ? FuncoesUF.GetUnidadesFederativaComAliquotasICMS(EMITENTE.IDEmitente).AliquotaIntra : Integ.ICMS_DIFERENCIADO),
                            Integ.ICMS_RED == 1 ? _Produto.Trib_RedBCICMS : 0,
                            Integ.ICMS_DIF == 1 ? _Produto.Trib_AliqICMSDif : 0)
                }
            }, ValorTributosNacional, ValorTributosEstadual, ValorTributosMunicipal, NcmVigente.Chave, i + 1);
            //    Det.imposto.ICMSUFDest.pICMSInter = 0;
            //    Det.imposto.ICMSUFDest.pICMSInterPart = 0;

            switch (crt)
            {
                case CRT.RegimeNormal:
                case CRT.SimplesNacionalExcessoSublimite:
                    Det.imposto.COFINS = new COFINS { TipoCOFINS = Imposto.GetCofins(Convert.ToInt32(FuncoesCst.GetCSTCofins(Integ.IDCSTCofins).CST), BaseCalculo, _Produto.Trib_AliqCOFINS) };
                    Det.imposto.PIS = new PIS { TipoPIS = Imposto.GetPis(Convert.ToInt32(FuncoesCst.GetCSTCofins(Integ.IDCSTPis).CST), BaseCalculo, _Produto.Trib_AliqPIS) };
                    // IPI Não Envia na NFC-e

                    break;
            }
            return Det;
        }

        public FormaPagamento retornarFormaPagamento(string Forma)
        {
            if (Forma.Contains("DINHEIRO"))
            {
                return FormaPagamento.fpDinheiro;
            }
            else if (Forma.Contains("CRÉDITO"))
            {
                return FormaPagamento.fpCartaoCredito;
            }
            else if (Forma.Contains("DÉBITO"))
            {
                return FormaPagamento.fpCartaoDebito;
            }
            else
            {
                return FormaPagamento.fpOutro;
            }
        }

        public pag _pag;
        public List<pag> ListaDePagamentos = new List<pag>();
        public List<detPag> ListaDeDetPagamentos = new List<detPag>();
        public List<card> ListaDeDetPagamentosCartao = new List<card>();

        protected List<pag> GetPagamento(List<DuplicataNFCe> DuplicatasPagamento)
        {
            _pag = new pag();
            foreach (var item in DuplicatasPagamento)
            {
                FormaDePagamento formaDePagamentoPag = FuncoesFormaDePagamento.GetFormaDePagamento(item.IDFormaDePagamento);
                
                if (formaDePagamentoPag.Transacao == 1)
                {
                    detPag _dpag = new detPag()
                    {
                        indPag = IndicadorPagamentoDetalhePagamento.ipDetPgVista,
                        tPag = FormaPagamento.fpDinheiro,
                    
                        vPag = item.Valor - item.Troco
                    };
                    ListaDeDetPagamentos.Add(_dpag);
                }
                else
                {
                   int? tppag = Convert.ToInt32(formaDePagamentoPag.Codigo);
                   /* if (formaDePagamentoPag.Identificacao.Contains("CREDITO"))
                    {
                        tppag = 3;

                    }
                    else if (formaDePagamentoPag.Identificacao.Contains("DEBITO"))
                    {
                        tppag = 4;
                    }

                    else if (formaDePagamentoPag.Descricao.Contains("LOJA"))
                    {
                        tppag = 5;
                    }

                   else if (formaDePagamentoPag.Identificacao.Contains("TRANSF"))
                    {
                        tppag = 18;
                    }

                    else if (formaDePagamentoPag.Identificacao.Contains("BOLETO"))
                    {
                        tppag = 15;
                    }
                    else if (formaDePagamentoPag.Identificacao.Contains("DEPOSI"))
                    {
                        tppag = 16;
                    }

                    else if (formaDePagamentoPag.Identificacao.Contains("PIX"))
                    {
                        tppag = 17;
                    }
                    
                    else
                    {
                        tppag = 99;
                    }

                    */

                    detPag _dpag = new detPag()
                    {
                        indPag = IndicadorPagamentoDetalhePagamento.ipDetPgPrazo,
                        tPag = (FormaPagamento)tppag,
                       // xPag = formaDePagamentoPag.Identificacao,
                        vPag = item.Valor
                       
                    };



                    if (tppag == 99)
                    {
                        _dpag.xPag = formaDePagamentoPag.Identificacao;
                    }



                    if (tppag == 4 ^ tppag == 3)
                    {

                        card _card = new card();

                        _card.tpIntegra = TipoIntegracaoPagamento.TipNaoIntegrado;
                        //  CNPJ = "",
                        _dpag.card = _card;
                    }




                    ListaDeDetPagamentos.Add(_dpag);

                }
            }
            //_pag.vPag = DUPLICATAS.Sum(x => x.Valor);
            //_pag.vTroco = 0;
            _pag.detPag = ListaDeDetPagamentos;

            List<pag> pagamentos = new List<pag>();
            pagamentos.Add(_pag);

            return pagamentos;
        }

        protected List<detPag> GetDetPagamento(List<DuplicataNFCe> Pagamentos)
        {

            List<detPag> ListaDeDetPagamentos = new List<detPag>();
            foreach (DuplicataNFCe Item in Pagamentos)
            {
                FormaDePagamento Forma = FuncoesFormaDePagamento.GetFormaDePagamento(Item.IDFormaDePagamento);

                detPag _dpag = new detPag()
                {
                    tPag = FormaPagamento.fpDinheiro,
                    vPag = Item.Valor
                };

                ListaDeDetPagamentos.Add(_dpag);
            }
            return ListaDeDetPagamentos;
        }

        protected infNFe GetInf(int numero, ModeloDocumento modelo, VersaoServico versao)
        {
            infNFe infNFe = new infNFe
            {
                versao = Conversao.VersaoServicoParaString(versao),
                ide = GetIdentificacao(numero, modelo, versao),
                emit = CONFIG_NFCe.Emitente,
                dest = GetDestinatario(versao, modelo),
                transp = new transp() { modFrete = ModalidadeFrete.mfSemFrete }
            };

            for (int i = 0; i < ITENS_VENDA.Count; i++)
            {
                infNFe.det.Add(GetDetalhe(ITENS_VENDA[i], i, infNFe.emit.CRT, modelo));
            }

            infNFe.total = Totais.GetTotalNFCe(infNFe.det);

            if (infNFe.ide.mod == ModeloDocumento.NFCe)
            {
                infNFe.pag = GetPagamento(PAGAMENTOS); //NFCe Somente
            }

            infNFe.infAdic = new infAdic
            {
                infCpl = string.Format("Trib aprox R$: {0} Federal, {1} Estadual e Municipal: {2} Fonte: IBPT {3}|LEI COMPLEMENTAR N 123/2006, NFC-e. Transmitida por RootSys Software", ListaDeTributos.Sum(o => o.PercentualFederal).ToString("n2"), ListaDeTributos.Sum(o => o.PercentualEstadual).ToString("n2"), ListaDeTributos.Sum(o => o.PercentualMunicipal).ToString("n2"), ListaDeTributos[0].NCM.Chave)
            };
            return infNFe;
        }

        protected ide GetIdentificacao(int numero, ModeloDocumento modelo, VersaoServico versao)
        {
            string NaturezaOperacao = "";
            var config1 = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_NOME_NATUREZAOPERACAO);
            if (config1 != null)
            {
                NaturezaOperacao = Encoding.UTF8.GetString(config1.Valor);
            }
            else
            {
                throw new Exception("Informar a natureza de operação padrão nas configurações de NFce.");
            }
            int cNFSistema = numero * 20 * 2;
            ide ide = new ide
            {
                cUF = CONFIG_NFCe.Emitente.enderEmit.UF,
                natOp = NaturezaOperacao,//"Venda de mercadoria adquirida ou recebida de terceiros",
                // indPag = IndicadorPagamento.ipVista,
                ProxyDhEmi = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'-05:00'"),
                mod = ModeloDocumento.NFCe,
                serie = SERIE,
                nNF = numero,
                idDest = DestinoOperacao.doInterna,
                procEmi = ProcessoEmissao.peAplicativoContribuinte,
                indFinal = ConsumidorFinal.cfConsumidorFinal,
                indPres = PresencaComprador.pcPresencial,
                tpNF = TipoNFe.tnSaida,
                cMunFG = CONFIG_NFCe.Emitente.enderEmit.cMun,
                tpEmis = CONFIG_NFCe.CfgServico.tpEmis,
                tpImp = TipoImpressao.tiNFCe,
                cNF = cNFSistema.ToString(),// numero.ToString(),
                tpAmb = CONFIG_NFCe.CfgServico.tpAmb,
                finNFe = FinalidadeNFe.fnNormal,
                verProc = VERSAO,
                indIntermed = 0
                
            };

            if (versao == VersaoServico.Versao200)
            {
                ide.dEmi = DateTime.Today;
                ide.dSaiEnt = DateTime.Today;
            }

            if (versao != VersaoServico.Versao310)
            {
                return ide;
            }

            if (versao != VersaoServico.Versao400)
            {
                return ide;
            }

            ide.idDest = DestinoOperacao.doInterna;
            ide.dhEmi = DateTime.Now;
            ide.procEmi = ProcessoEmissao.peAplicativoContribuinte;
            ide.indFinal = ConsumidorFinal.cfConsumidorFinal;
            ide.indPres = PresencaComprador.pcPresencial;

            return ide;
        }

        public RetornoTransmissaoNFCe TransmitirNFCeNormal()
        {
            try
            {
                bool ExisteNFCe = IDMovimentoFiscal.HasValue;
                if (IDMovimentoFiscal == null)
                {
                    IDMovimentoFiscal = Sequence.GetNextID("MOVIMENTOFISCAL", "IDMOVIMENTOFISCAL");
                }

                _nfe = GetNf(NUMERO, CONFIG_NFCe.CfgServico.ModeloDocumento, CONFIG_NFCe.CfgServico.VersaoNFeAutorizacao);
                _nfe = FuncoesXml.XmlStringParaClasse<NFe.Classes.NFe>(ControllerFiscalUtil.RemoverAcentos(_nfe.ObterXmlString()));

                _nfe.Assina(); //não precisa validar aqui, pois o lote será validado em ServicosNFe.NFeAutorizacao
                //A URL do QR-Code deve ser gerada em um objeto nfe já assinado, pois na URL vai o DigestValue que é gerado por ocasião da assinatura
                _nfe.infNFeSupl = new infNFeSupl() { qrCode = _nfe.infNFeSupl.ObterUrlQrCode(_nfe, VersaoQrCode.QrCodeVersao2, CONFIG_NFCe.ConfiguracaoCsc.CIdToken, CONFIG_NFCe.ConfiguracaoCsc.Csc) }; //Define a URL do QR-Code.
                _nfe.Valida();

                ServicosNFe servicoNFe = new ServicosNFe(CONFIG_NFCe.CfgServico);

                RetornoNFeAutorizacao retornoEnvio = null;
                try
                {
                    // Se chegou até aqui é por que a nota é válida.
                    retornoEnvio = servicoNFe.NFeAutorizacao(1, IndicadorSincronizacao.Sincrono, new List<NFe.Classes.NFe> { _nfe }, false /*Envia a mensagem compactada para a SEFAZ*/);
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }

                if (ExisteNFCe)
                {
                    if (!FuncoesMovimentoFiscal.AtualizarMovimentoPorID(new MovimentoFiscal()
                    {
                        IDMovimentoFiscal = IDMovimentoFiscal.Value,
                        Cancelada = 0,
                        cStat = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.cStat : retornoEnvio.Retorno.protNFe.infProt.cStat,
                        DataRecebimento = retornoEnvio.Retorno.dhRecbto,
                        //DataEmissao = _nfe.infNFe.ide.dhEmi.UtcDateTime,
                        DataEmissao = Convert.ToDateTime(_nfe.infNFe.ide.dhEmi.ParaDataHoraStringSemUtc()),
                        Emitida = 1,
                        IDVenda = VENDA.IDVenda,
                        Serie = SERIE,
                        xMotivo = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.xMotivo : retornoEnvio.Retorno.protNFe.infProt.xMotivo,
                        Chave = _nfe.infNFe.Id,
                        XMLEnvio = Encoding.Default.GetBytes(retornoEnvio.EnvioStr),
                        XMLRetorno = Encoding.Default.GetBytes(retornoEnvio.RetornoStr),
                        Protocolo = retornoEnvio.Retorno.protNFe.infProt.nProt ?? "",
                        Contingencia = 0
                    }))
                    {
                        throw new Exception("Não foi possível salvar a NFC-e.");
                    }
                }
                else
                {
                    if (!FuncoesMovimentoFiscal.Salvar(new MovimentoFiscal()
                    {
                        IDMovimentoFiscal = IDMovimentoFiscal.Value,
                        Cancelada = 0,
                        cStat = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.cStat : retornoEnvio.Retorno.protNFe.infProt.cStat,
                        DataRecebimento = retornoEnvio.Retorno.dhRecbto,
                        //DataEmissao = _nfe.infNFe.ide.dhEmi.UtcDateTime,
                        DataEmissao = Convert.ToDateTime(_nfe.infNFe.ide.dhEmi.ParaDataHoraStringSemUtc()),
                        Emitida = 1,
                        IDVenda = VENDA.IDVenda,
                        Serie = 1,
                        xMotivo = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.xMotivo : retornoEnvio.Retorno.protNFe.infProt.xMotivo,
                        Chave = _nfe.infNFe.Id,
                        XMLEnvio = Encoding.Default.GetBytes(retornoEnvio.EnvioStr),
                        XMLRetorno = Encoding.Default.GetBytes(retornoEnvio.RetornoStr),
                        Contingencia = 0,
                        Ambiente = Convert.ToDecimal(CONFIG_NFCe.CfgServico.tpAmb),
                        TipoDocumento = Convert.ToDecimal(CONFIG_NFCe.CfgServico.ModeloDocumento),
                        Protocolo = retornoEnvio.Retorno.protNFe.infProt.nProt ?? "",
                        Numero = _nfe.infNFe.ide.nNF
                    }))
                    {
                        throw new Exception("Não foi possível salvar a NFC-e.");
                    }
                }
                return new RetornoTransmissaoNFCe()
                {
                    isAutorizada = (retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.cStat : retornoEnvio.Retorno.protNFe.infProt.cStat) == 100,
                    NFe = _nfe,
                    Protocolo = retornoEnvio.Retorno.protNFe
                };
            }
            catch (Exception Ex)
            {
                return new RetornoTransmissaoNFCe() { MotivoErro = "Não foi possível transmitir a NFC-e, Motivo: " + Ex.Message };
            }
        }

     
        public string UltimaMensagem { get; set; }
        public bool NFCeIsValida { get; private set; }

        public RetornoTransmissaoNFCe TransmitirNFCeContingencia()
        {
            string SXmlAutorizado = "";

            NFe.Classes.NFe _nfeContingencia = new NFe.Classes.NFe().CarregarDeXmlString(FuncoesMovimentoFiscal.GetXMLEnvio(IDMovimentoFiscal.Value));
            int Lote = 1;

            DAO.Entidades.Configuracao config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOCONTINGENCIA_JUSTIFICATIVA);
            _nfeContingencia.infNFe.ide.xJust = config == null ? string.Empty : ControllerFiscalUtil.RemoverAcentos(Encoding.UTF8.GetString(config.Valor));

            _nfeContingencia.infNFe.versao = Conversao.VersaoServicoParaString(CONFIG_NFCe.CfgServico.VersaoNFeAutorizacao);
            //ide = GetIdentificacao(numero, modelo, versao),
            _nfeContingencia.infNFe.emit = CONFIG_NFCe.Emitente;
            _nfeContingencia.infNFe.transp = new transp() { modFrete = ModalidadeFrete.mfSemFrete };

            _nfeContingencia.Assina(); //não precisa validar aqui, pois o lote será validado em ServicosNFe.NFeAutorizacao
                                       //A URL do QR-Code deve ser gerada em um objeto nfe já assinado, pois na URL vai o DigestValue que é gerado por ocasião da assinatura
                                       // _nfeContingencia.infNFeSupl = new infNFeSupl() { qrCode = _nfeContingencia.infNFeSupl.ObterUrlQrCode(_nfeContingencia, VersaoQrCode.QrCodeVersao2, CONFIG_NFCe.ConfiguracaoCsc.CIdToken, CONFIG_NFCe.ConfiguracaoCsc.Csc) }; //Define a URL do QR-Code.

            infNFeSupl supl = new infNFeSupl
            {
                urlChave = _nfeContingencia.infNFeSupl.ObterUrlConsulta(_nfeContingencia, VersaoQrCode.QrCodeVersao2)
            };
            _nfeContingencia.infNFeSupl = supl;
            _nfeContingencia.infNFeSupl.qrCode = _nfeContingencia.infNFeSupl.ObterUrlQrCode(_nfeContingencia, VersaoQrCode.QrCodeVersao2, CONFIG_NFCe.ConfiguracaoCsc.CIdToken, CONFIG_NFCe.ConfiguracaoCsc.Csc);


            _nfeContingencia.Valida();

            ServicosNFe servicoNFe = new ServicosNFe(CONFIG_NFCe.CfgServico);

            string r_enviostr = string.Empty;
            string r_retornostr = string.Empty;

            enviNFe4 pedEnvio = new enviNFe4("DUE", Lote, IndicadorSincronizacao.Sincrono, new List<NFe.Classes.NFe> { _nfeContingencia });



            RetornoNFeAutorizacao retornoEnvio = null;
            try
            {
                // Se chegou até aqui é por que a nota é válida.
                retornoEnvio = servicoNFe.NFeAutorizacao(Lote, IndicadorSincronizacao.Sincrono, new List<NFe.Classes.NFe> { _nfeContingencia }, false /*Envia a mensagem compactada para a SEFAZ*/);

                var nfeproc = new nfeProc
                {
                    NFe = _nfe,
                    protNFe = retornoEnvio.Retorno.protNFe,
                    versao = retornoEnvio.Retorno.versao

                };

                if (nfeproc.protNFe != null)
                {
                    SXmlAutorizado = nfeproc.ObterXmlString();
                    //var novoArquivo = DiretorioNotasEnviadas + @"\" + nfeproc.protNFe.infProt.chNFe + "-procNfe.xml";
                    //FuncoesXml.ClasseParaArquivoXml(nfeproc, novoArquivo);
                    r_retornostr = nfeproc.ObterXmlString();

                    try
                    {
                        if (!Directory.Exists("c:\\XMLENVIADOAPROV\\"))
                            Directory.CreateDirectory("c:\\XMLENVIADOAPROV\\");
                        _nfe.SalvarArquivoXml(@"c:\XMLENVIADOAPROV\" + _nfe.infNFe.Id + ".xml");
                    }
                    catch (Exception)
                    {

                    }

                }
            }








            catch (Exception Ex)
            {
                throw Ex;
            }

            if (!FuncoesMovimentoFiscal.AtualizarMovimentoPorID(new MovimentoFiscal()
            {
                IDMovimentoFiscal = IDMovimentoFiscal.Value,
                Cancelada = 0,
                cStat = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.cStat : retornoEnvio.Retorno.protNFe.infProt.cStat,
                DataRecebimento = retornoEnvio.Retorno.dhRecbto,
                //DataEmissao = _nfeContingencia.infNFe.ide.dhEmi.UtcDateTime,
                DataEmissao = Convert.ToDateTime(_nfeContingencia.infNFe.ide.dhEmi.ParaDataHoraStringSemUtc()),
                Emitida = 1,
                Serie = SERIE,
                xMotivo = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.xMotivo : retornoEnvio.Retorno.protNFe.infProt.xMotivo,
                Chave = _nfeContingencia.infNFe.Id,
                XMLEnvio = Encoding.Default.GetBytes(retornoEnvio.EnvioStr),
                XMLRetorno = Encoding.Default.GetBytes(r_retornostr),
                Contingencia = 1,
                Protocolo = retornoEnvio.Retorno.protNFe.infProt.nProt ?? ""
            }))
            {
                return new RetornoTransmissaoNFCe() { MotivoErro = "Não foi possível transmitir a NFC-e." };
            }

            return new RetornoTransmissaoNFCe()
            {
                isAutorizada = (retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.cStat : retornoEnvio.Retorno.protNFe.infProt.cStat) == 100,
                MotivoErro = "NFC-e transmitida com sucesso"
            };
        }

        public RetornoTransmissaoNFCe TransmitirNFCeContingencia2()
        {
            string SXmlAutorizado = "";


            RetornoTransmissaoNFCe RetornoTransmissao = new RetornoTransmissaoNFCe();
         
            DateTime data = DateTime.Now;
            //_nfe = GetNf(NUMERO, CONFIG_NFCe.CfgServico.ModeloDocumento, CONFIG_NFCe.CfgServico.VersaoNFeAutorizacao);

            NFe.Classes.NFe _nfe = new NFe.Classes.NFe().CarregarDeXmlString(FuncoesMovimentoFiscal.GetXMLEnvio(IDMovimentoFiscal.Value));

          
            try
            {

                _nfe.Assina();

                _nfe.Valida();


                NFCeIsValida = true;
                if (_nfe.infNFe.ide.mod == ModeloDocumento.NFCe)
                {
                    infNFeSupl supl = new infNFeSupl
                    {
                        urlChave = _nfe.infNFeSupl.ObterUrlConsulta(_nfe, VersaoQrCode.QrCodeVersao2)
                    };
                    _nfe.infNFeSupl = supl;
                    _nfe.infNFeSupl.qrCode = _nfe.infNFeSupl.ObterUrlQrCode(_nfe, VersaoQrCode.QrCodeVersao2, CONFIG_NFCe.ConfiguracaoCsc.CIdToken, CONFIG_NFCe.ConfiguracaoCsc.Csc);
                }

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                throw new Exception(ex.Message);
            }

            ServicosNFe servicoNFe = new ServicosNFe(CONFIG_NFCe.CfgServico);
            //var pedEnvio = new enviNFe3(VERSAO, Convert.ToInt32(Lote), IndicadorSincronizacao.Sincrono, new List<NFe.Classes.NFe> { _nfe });
            RetornoNFeAutorizacao retornoEnvio = null;
            RetornoNFeRetAutorizacao retornoRecibo = null;

            string r_enviostr = string.Empty;
            string r_retornostr = string.Empty;


            //enviNFe4 pedEnvio = new enviNFe4("DUE", Lote, IndicadorSincronizacao.Sincrono, new List<NFe.Classes.NFe> { _nfeContingencia });
     
            try
            {
                // Se chegou até aqui é por que a nota é válida.
              
                retornoEnvio = servicoNFe.NFeAutorizacao(1, IndicadorSincronizacao.Sincrono, new List<NFe.Classes.NFe> { _nfe }, false /*Envia a mensagem compactada para a SEFAZ*/);

                var nfeproc = new nfeProc
                {
                    NFe = _nfe,
                    protNFe = retornoEnvio.Retorno.protNFe,
                    versao = retornoEnvio.Retorno.versao

                };

                if (nfeproc.protNFe != null)
                {
                    SXmlAutorizado = nfeproc.ObterXmlString();
                    //var novoArquivo = DiretorioNotasEnviadas + @"\" + nfeproc.protNFe.infProt.chNFe + "-procNfe.xml";
                    //FuncoesXml.ClasseParaArquivoXml(nfeproc, novoArquivo);
                    r_retornostr = nfeproc.ObterXmlString();

                    try
                    {
                        if (!Directory.Exists("c:\\XMLENVIADOAPROV\\"))
                            Directory.CreateDirectory("c:\\XMLENVIADOAPROV\\");
                        _nfe.SalvarArquivoXml(@"c:\XMLENVIADOAPROV\" + _nfe.infNFe.Id + ".xml");
                    }
                    catch (Exception)
                    {

                    }

                }
            }








            catch (Exception Ex)
            {
                throw Ex;
            }

            if (!FuncoesMovimentoFiscal.AtualizarMovimentoPorID(new MovimentoFiscal()
            {
                IDMovimentoFiscal = IDMovimentoFiscal.Value,
                Cancelada = 0,
                cStat = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.cStat : retornoEnvio.Retorno.protNFe.infProt.cStat,
                DataRecebimento = retornoEnvio.Retorno.dhRecbto,
                //DataEmissao = _nfeContingencia.infNFe.ide.dhEmi.UtcDateTime,
                DataEmissao = Convert.ToDateTime(_nfe.infNFe.ide.dhEmi.ParaDataHoraStringSemUtc()),
                Emitida = 1,
                Serie = SERIE,
                xMotivo = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.xMotivo : retornoEnvio.Retorno.protNFe.infProt.xMotivo,
                Chave = _nfe.infNFe.Id,
                XMLEnvio = Encoding.Default.GetBytes(retornoEnvio.EnvioStr),
                XMLRetorno = Encoding.Default.GetBytes(r_retornostr),
                Contingencia = 0,
                Protocolo = retornoEnvio.Retorno.protNFe.infProt.nProt ?? ""
            }))
            {
                return new RetornoTransmissaoNFCe() { MotivoErro = "Não foi possível transmitir a NFC-e." };
            }

            return new RetornoTransmissaoNFCe()
            {
                isAutorizada = (retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.cStat : retornoEnvio.Retorno.protNFe.infProt.cStat) == 100,
                MotivoErro = "NFC-e transmitida com sucesso"
            };
        }

        public RetornoTransmissaoNFCe TransmitirNFCe()
         {
            try
            {
                bool ExisteNFCe = IDMovimentoFiscal.HasValue;
                bool ExisteNFCeBanco = FuncoesMovimentoFiscal.GetMovimentoBool(IDMovimentoFiscal);


                string SXmlAutorizado = "";

                Cursor.Current = Cursors.WaitCursor;
                if (!IDMovimentoFiscal.HasValue)
                    IDMovimentoFiscal = Sequence.GetNextID("MOVIMENTOFISCAL", "IDMOVIMENTOFISCAL");

                RetornoTransmissaoNFCe RetornoTransmissao = new RetornoTransmissaoNFCe();
                           
                DateTime data = DateTime.Now;
                _nfe = GetNf(NUMERO, CONFIG_NFCe.CfgServico.ModeloDocumento, CONFIG_NFCe.CfgServico.VersaoNFeAutorizacao);                             
                _nfe = FuncoesXml.XmlStringParaClasse<NFe.Classes.NFe>(ControllerFiscalUtil.RemoverAcentos(_nfe.ObterXmlString()));                                            
                _nfe.infNFe.ide.ProxyDhEmi = data.ToString("yyyy-MM-ddTHH:mm:sszzz");
         
                UltimaMensagem = "Iniciado Processo.";
                RetornoMensagem?.Invoke(this, null);
               
                try
                {
                    _nfe.Assina();
                    _nfe.Valida();

                    NFCeIsValida = true;
                    if (_nfe.infNFe.ide.mod == ModeloDocumento.NFCe)
                    {
                        infNFeSupl supl = new infNFeSupl
                        {
                            urlChave = _nfe.infNFeSupl.ObterUrlConsulta(_nfe, VersaoQrCode.QrCodeVersao2)
                        };
                        _nfe.infNFeSupl = supl;
                        _nfe.infNFeSupl.qrCode = _nfe.infNFeSupl.ObterUrlQrCode(_nfe, VersaoQrCode.QrCodeVersao2, CONFIG_NFCe.ConfiguracaoCsc.CIdToken, CONFIG_NFCe.ConfiguracaoCsc.Csc);
                    }

                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    throw new Exception(ex.Message);
                }

                ServicosNFe servicoNFe = new ServicosNFe(CONFIG_NFCe.CfgServico);
                //var pedEnvio = new enviNFe3(VERSAO, Convert.ToInt32(Lote), IndicadorSincronizacao.Sincrono, new List<NFe.Classes.NFe> { _nfe });
                RetornoNFeAutorizacao retornoEnvio = null;
                RetornoNFeRetAutorizacao retornoRecibo = null;

                string r_enviostr = string.Empty;
                string r_retornostr = string.Empty;

                try
                {

                    // Se chegou até aqui é por que a nota é válida.
                    retornoEnvio = servicoNFe.NFeAutorizacao(1, IndicadorSincronizacao.Sincrono, new List<NFe.Classes.NFe> { _nfe }, false /*Envia a mensagem compactada para a SEFAZ*/);
                    
               
                    var nfeproc = new nfeProc
                    {
                        NFe = _nfe,
                        protNFe = retornoEnvio.Retorno.protNFe,
                        versao = retornoEnvio.Retorno.versao
                    };

                    if (nfeproc.protNFe != null)
                    {
                        SXmlAutorizado = nfeproc.ObterXmlString();
                        //var novoArquivo = DiretorioNotasEnviadas + @"\" + nfeproc.protNFe.infProt.chNFe + "-procNfe.xml";
                        //FuncoesXml.ClasseParaArquivoXml(nfeproc, novoArquivo);
                        r_retornostr = nfeproc.ObterXmlString();

                        try
                        {
                            if (!Directory.Exists("c:\\XMLENVIADOAPROV\\"))
                                Directory.CreateDirectory("c:\\XMLENVIADOAPROV\\");
                                _nfe.SalvarArquivoXml(@"c:\XMLENVIADOAPROV\" + _nfe.infNFe.Id + ".xml");
                        }
                        catch (Exception)
                        {

                        }
                        //imprimirdanfe(novoArquivo);
                        //                              MessageBox.Show("Nota fiscal eletrônica enviada com sucesso.", "UDISYS Sistemas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    
                    
                    }




                }



                catch (ComunicacaoException ex)
                {
                    //Faça o tratamento de contingência OffLine aqui.
                    DAO.Entidades.Configuracao config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOCONTINGENCIA_JUSTIFICATIVA);

                    RetornoTransmissao.isAutorizada = false;
                    RetornoTransmissao.isSchemaValido = true;
                    RetornoTransmissao.isContingencia = true;
                    RetornoTransmissao.MotivoContingencia = ex.Message;
                    

                    _nfe.infNFe.ide.mod = ModeloDocumento.NFCe;
                    _nfe.infNFe.ide.dhCont = DateTime.Now;
                    _nfe.infNFe.ide.xJust = config == null ? string.Empty : ControllerFiscalUtil.RemoverAcentos(Encoding.UTF8.GetString(config.Valor));
                    _nfe.infNFe.ide.tpEmis = TipoEmissao.teOffLine;
                    _nfe.infNFe.ide.finNFe = FinalidadeNFe.fnNormal;
                    _nfe.infNFe.ide.indFinal = ConsumidorFinal.cfConsumidorFinal;
                    _nfe.infNFe.ide.indPres = PresencaComprador.pcPresencial;
                }
                catch (ValidacaoSchemaException Ex)
                {
                    RetornoTransmissao.isAutorizada = false;
                    RetornoTransmissao.isContingencia = false;
                    RetornoTransmissao.isSchemaValido = false;
                    RetornoTransmissao.MotivoErro = Ex.Message;
                    return RetornoTransmissao;
                }
                catch (Exception Ex)
                {
                    RetornoTransmissao.isAutorizada = false;
                    RetornoTransmissao.isContingencia = false;
                    RetornoTransmissao.isSchemaValido = true;
                    RetornoTransmissao.MotivoErro = Ex.Message;
                    return RetornoTransmissao;
                }

                if (RetornoTransmissao.isContingencia)
                {
                    if (!FuncoesMovimentoFiscal.Salvar(new MovimentoFiscal()
                    {
                        IDMovimentoFiscal = IDMovimentoFiscal.Value,
                        Cancelada = 0,
                        cStat = null,
                        DataRecebimento = null,
                        //DataEmissao = _nfe.infNFe.ide.dhCont.UtcDateTime,.
                        DataEmissao = Convert.ToDateTime(_nfe.infNFe.ide.dhEmi.ParaDataHoraStringSemUtc()),
                        Emitida = 0,
                        IDVenda = VENDA.IDVenda,
                        Serie = SERIE,
                        xMotivo = RetornoTransmissao.MotivoContingencia,
                        Chave = _nfe.infNFe.Id,
                        XMLEnvio = Encoding.Default.GetBytes(ControllerFiscalUtil.RemoverAcentos(FuncoesXml.ClasseParaXmlString(_nfe))),
                        XMLRetorno = null,
                        Contingencia = 1,
                        Ambiente = Convert.ToDecimal(CONFIG_NFCe.CfgServico.tpAmb),
                        TipoDocumento = Convert.ToDecimal(CONFIG_NFCe.CfgServico.ModeloDocumento),
                        Numero = _nfe.infNFe.ide.nNF

                    }))
                    {
                        throw new Exception("Não foi possível salvar a NFC-e.");
                    }
                }
                else
                {


                    if (ExisteNFCeBanco)
                    {
                        if (!FuncoesMovimentoFiscal.AtualizarMovimentoPorID(new MovimentoFiscal()
                        {

                            IDMovimentoFiscal = IDMovimentoFiscal.Value,
                            Cancelada = 0,
                            cStat = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.cStat : retornoEnvio.Retorno.protNFe.infProt.cStat,
                            DataRecebimento = retornoEnvio.Retorno.dhRecbto,
                            //DataEmissao = _nfe.infNFe.ide.dhEmi.UtcDateTime,
                            DataEmissao = Convert.ToDateTime(_nfe.infNFe.ide.dhEmi.ParaDataHoraStringSemUtc()),
                            Emitida = 1,
                            IDVenda = VENDA.IDVenda,
                            Serie = SERIE,
                            xMotivo = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.xMotivo : retornoEnvio.Retorno.protNFe.infProt.xMotivo,
                            Chave = _nfe.infNFe.Id,
                            XMLEnvio = Encoding.Default.GetBytes(retornoEnvio.EnvioStr),
                            XMLRetorno = Encoding.Default.GetBytes(r_retornostr),
                            Protocolo = retornoEnvio.Retorno.protNFe.infProt.nProt ?? "",
                            Contingencia = 0

                        }))
                        {
                            throw new Exception("Não foi possível salvar a NFC-e.");
                        }
                    }
                    else
                    {
                        if (!FuncoesMovimentoFiscal.Salvar(new MovimentoFiscal()
                        {
                            IDMovimentoFiscal = IDMovimentoFiscal.Value,
                            Cancelada = 0,
                            cStat = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.cStat : retornoEnvio.Retorno.protNFe.infProt.cStat,
                            DataRecebimento = retornoEnvio.Retorno.dhRecbto,
                            //DataEmissao = _nfe.infNFe.ide.dhEmi.UtcDateTime,.
                            DataEmissao = Convert.ToDateTime(_nfe.infNFe.ide.dhEmi.ParaDataHoraStringSemUtc()),
                            Emitida = 1,
                            IDVenda = VENDA.IDVenda,
                            Serie = SERIE,
                            xMotivo = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.xMotivo : retornoEnvio.Retorno.protNFe.infProt.xMotivo,
                            Chave = _nfe.infNFe.Id,
                            XMLEnvio = Encoding.Default.GetBytes(retornoEnvio.EnvioStr),
                            XMLRetorno = Encoding.Default.GetBytes(r_retornostr),
                            Contingencia = 0,
                            Ambiente = Convert.ToDecimal(CONFIG_NFCe.CfgServico.tpAmb),
                            TipoDocumento = Convert.ToDecimal(CONFIG_NFCe.CfgServico.ModeloDocumento),
                            Protocolo = retornoEnvio.Retorno.protNFe.infProt.nProt ?? "",
                            Numero = _nfe.infNFe.ide.nNF

                        }))
                        {
                            throw new Exception("Não foi possível salvar a NFC-e.");
                        }
                    }



                }

                if (retornoEnvio != null && !RetornoTransmissao.isContingencia && (retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.cStat : retornoEnvio.Retorno.protNFe.infProt.cStat) != 100)
                {
                    RetornoTransmissao.MotivoErro = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.xMotivo : retornoEnvio.Retorno.protNFe.infProt.xMotivo;
                    RetornoTransmissao.IDVenda = VENDA.IDVenda;
                    RetornoTransmissao.isAutorizada = false;
                    RetornoTransmissao.isContingencia = false;
                    RetornoTransmissao.IDMovimentoFiscal = IDMovimentoFiscal.Value;
                    RetornoTransmissao.NFe = _nfe;
                    RetornoTransmissao.Protocolo = retornoEnvio.Retorno.protNFe;
                    return RetornoTransmissao;
                }
                else
                {
                    RetornoTransmissao.isAutorizada = true;
                    RetornoTransmissao.IDMovimentoFiscal = IDMovimentoFiscal.Value;
                    if (!RetornoTransmissao.isContingencia)
                    {
                        RetornoTransmissao.danfe = new DanfeFrNfce(new nfeProc()
                        {
                            NFe = _nfe,
                            protNFe = retornoEnvio.Retorno.protNFe,
                            versao = retornoEnvio.Retorno.versao
                        }, CONFIG_NFCe.ConfiguracaoDanfeNfce, CONFIG_NFCe.ConfiguracaoCsc.CIdToken, CONFIG_NFCe.ConfiguracaoCsc.Csc);
                    }
                    else
                    {
                        RetornoTransmissao.danfe = new DanfeFrNfce(_nfe, CONFIG_NFCe.ConfiguracaoDanfeNfce, CONFIG_NFCe.ConfiguracaoCsc.CIdToken, CONFIG_NFCe.ConfiguracaoCsc.Csc);
                    }

                    DAO.Entidades.Configuracao configExibirDialogo = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_EXIBIRCAIXADIALOGO);
                    if (configExibirDialogo != null && "1".Equals(Encoding.UTF8.GetString(configExibirDialogo.Valor)))
                    {
                        RetornoTransmissao.isVisualizar = true;
                    }
                    else
                    {
                        DAO.Entidades.Configuracao configNomeImpressora = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_NOMEIMPRESSORA);

                        RetornoTransmissao.isVisualizar = false;
                        RetornoTransmissao.NomeImpressora = configNomeImpressora != null ? Encoding.UTF8.GetString(configNomeImpressora.Valor) : string.Empty;
                        RetornoTransmissao.isCaixaDialogo = configExibirDialogo == null ? false : "1".Equals(Encoding.UTF8.GetString(configExibirDialogo.Valor));
                    }
                    Cursor.Current = Cursors.Default;
                    return RetornoTransmissao;
                }
            }
            catch (Exception Ex)
            {
                Cursor.Current = Cursors.Default;
                  throw Ex;
            }


        }


        public RetornoTransmissaoNFCe TransmitirNFCeContingenciaManual()
        {
            try
            {
                bool ExisteNFCe = IDMovimentoFiscal.HasValue;
                bool ExisteNFCeBanco = FuncoesMovimentoFiscal.GetMovimentoBool(IDMovimentoFiscal);


                Cursor.Current = Cursors.WaitCursor;
                if (!IDMovimentoFiscal.HasValue)
                    IDMovimentoFiscal = Sequence.GetNextID("MOVIMENTOFISCAL", "IDMOVIMENTOFISCAL");

                RetornoTransmissaoNFCe RetornoTransmissao = new RetornoTransmissaoNFCe();

                DateTime data = DateTime.Now;
                _nfe = GetNf(NUMERO, CONFIG_NFCe.CfgServico.ModeloDocumento, CONFIG_NFCe.CfgServico.VersaoNFeAutorizacao);
                _nfe = FuncoesXml.XmlStringParaClasse<NFe.Classes.NFe>(ControllerFiscalUtil.RemoverAcentos(_nfe.ObterXmlString()));
                _nfe.infNFe.ide.ProxyDhEmi = data.ToString("yyyy-MM-ddTHH:mm:sszzz");

                UltimaMensagem = "Iniciado Processo.";
                RetornoMensagem?.Invoke(this, null);

                try
                {
                    _nfe.Assina();
                    _nfe.Valida();

                    NFCeIsValida = true;
                    if (_nfe.infNFe.ide.mod == ModeloDocumento.NFCe)
                    {
                        infNFeSupl supl = new infNFeSupl
                        {
                            urlChave = _nfe.infNFeSupl.ObterUrlConsulta(_nfe, VersaoQrCode.QrCodeVersao2)
                        };
                        _nfe.infNFeSupl = supl;
                        _nfe.infNFeSupl.qrCode = _nfe.infNFeSupl.ObterUrlQrCode(_nfe, VersaoQrCode.QrCodeVersao2, CONFIG_NFCe.ConfiguracaoCsc.CIdToken, CONFIG_NFCe.ConfiguracaoCsc.Csc);
                    }

                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    throw new Exception(ex.Message);
                }

                ServicosNFe servicoNFe = new ServicosNFe(CONFIG_NFCe.CfgServico);
                //var pedEnvio = new enviNFe3(VERSAO, Convert.ToInt32(Lote), IndicadorSincronizacao.Sincrono, new List<NFe.Classes.NFe> { _nfe });
                RetornoNFeAutorizacao retornoEnvio = null;
                RetornoNFeRetAutorizacao retornoRecibo = null;

                string r_enviostr = string.Empty;
                string r_retornostr = string.Empty;

                try
                {

                    //Faça o tratamento de contingência OffLine aqui.
                    DAO.Entidades.Configuracao config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOCONTINGENCIA_JUSTIFICATIVA);

                    RetornoTransmissao.isAutorizada = false;
                    RetornoTransmissao.isSchemaValido = true;
                    RetornoTransmissao.isContingencia = true;
                    RetornoTransmissao.MotivoContingencia = "Manual";


                    _nfe.infNFe.ide.mod = ModeloDocumento.NFCe;
                    _nfe.infNFe.ide.dhCont = DateTime.Now;
                    _nfe.infNFe.ide.xJust = config == null ? string.Empty : ControllerFiscalUtil.RemoverAcentos(Encoding.UTF8.GetString(config.Valor));
                    _nfe.infNFe.ide.tpEmis = TipoEmissao.teOffLine;
                    _nfe.infNFe.ide.finNFe = FinalidadeNFe.fnNormal;
                    _nfe.infNFe.ide.indFinal = ConsumidorFinal.cfConsumidorFinal;
                    _nfe.infNFe.ide.indPres = PresencaComprador.pcPresencial;

                }


                catch (ValidacaoSchemaException Ex)
                {
                    RetornoTransmissao.isAutorizada = false;
                    RetornoTransmissao.isContingencia = false;
                    RetornoTransmissao.isSchemaValido = false;
                    RetornoTransmissao.MotivoErro = Ex.Message;
                    return RetornoTransmissao;
                }
                catch (Exception Ex)
                {
                    RetornoTransmissao.isAutorizada = false;
                    RetornoTransmissao.isContingencia = false;
                    RetornoTransmissao.isSchemaValido = true;
                    RetornoTransmissao.MotivoErro = Ex.Message;
                    return RetornoTransmissao;
                }

                if (RetornoTransmissao.isContingencia)
                {
                    if (!FuncoesMovimentoFiscal.Salvar(new MovimentoFiscal()
                    {
                        IDMovimentoFiscal = IDMovimentoFiscal.Value,
                        Cancelada = 0,
                        cStat = null,
                        DataRecebimento = null,
                        //DataEmissao = _nfe.infNFe.ide.dhCont.UtcDateTime,.
                        DataEmissao = Convert.ToDateTime(_nfe.infNFe.ide.dhEmi.ParaDataHoraStringSemUtc()),
                        Emitida = 0,
                        IDVenda = VENDA.IDVenda,
                        Serie = SERIE,
                        xMotivo = RetornoTransmissao.MotivoContingencia,
                        Chave = _nfe.infNFe.Id,
                        XMLEnvio = Encoding.Default.GetBytes(ControllerFiscalUtil.RemoverAcentos(FuncoesXml.ClasseParaXmlString(_nfe))),
                        XMLRetorno = null,
                        Contingencia = 1,
                        Ambiente = Convert.ToDecimal(CONFIG_NFCe.CfgServico.tpAmb),
                        TipoDocumento = Convert.ToDecimal(CONFIG_NFCe.CfgServico.ModeloDocumento),
                        Numero = _nfe.infNFe.ide.nNF

                    }))
                    {
                        throw new Exception("Não foi possível salvar a NFC-e.");
                    }
                }
                else
                {

                    if (ExisteNFCeBanco)
                    {
                        if (!FuncoesMovimentoFiscal.AtualizarMovimentoPorID(new MovimentoFiscal()
                        {

                            IDMovimentoFiscal = IDMovimentoFiscal.Value,
                            Cancelada = 0,
                            cStat = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.cStat : retornoEnvio.Retorno.protNFe.infProt.cStat,
                            DataRecebimento = retornoEnvio.Retorno.dhRecbto,
                            //DataEmissao = _nfe.infNFe.ide.dhEmi.UtcDateTime,
                            DataEmissao = Convert.ToDateTime(_nfe.infNFe.ide.dhEmi.ParaDataHoraStringSemUtc()),
                            Emitida = 1,
                            IDVenda = VENDA.IDVenda,
                            Serie = SERIE,
                            xMotivo = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.xMotivo : retornoEnvio.Retorno.protNFe.infProt.xMotivo,
                            Chave = _nfe.infNFe.Id,
                            XMLEnvio = Encoding.Default.GetBytes(retornoEnvio.EnvioStr),
                            XMLRetorno = Encoding.Default.GetBytes(r_retornostr),
                            Protocolo = retornoEnvio.Retorno.protNFe.infProt.nProt ?? "",
                            Contingencia = 0

                        }))
                        {
                            throw new Exception("Não foi possível salvar a NFC-e.");
                        }
                    }
                    else
                    {
                        if (!FuncoesMovimentoFiscal.Salvar(new MovimentoFiscal()
                        {
                            IDMovimentoFiscal = IDMovimentoFiscal.Value,
                            Cancelada = 0,
                            cStat = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.cStat : retornoEnvio.Retorno.protNFe.infProt.cStat,
                            DataRecebimento = retornoEnvio.Retorno.dhRecbto,
                            //DataEmissao = _nfe.infNFe.ide.dhEmi.UtcDateTime,.
                            DataEmissao = Convert.ToDateTime(_nfe.infNFe.ide.dhEmi.ParaDataHoraStringSemUtc()),
                            Emitida = 1,
                            IDVenda = VENDA.IDVenda,
                            Serie = SERIE,
                            xMotivo = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.xMotivo : retornoEnvio.Retorno.protNFe.infProt.xMotivo,
                            Chave = _nfe.infNFe.Id,
                            XMLEnvio = Encoding.Default.GetBytes(retornoEnvio.EnvioStr),
                            XMLRetorno = Encoding.Default.GetBytes(r_retornostr),
                            Contingencia = 0,
                            Ambiente = Convert.ToDecimal(CONFIG_NFCe.CfgServico.tpAmb),
                            TipoDocumento = Convert.ToDecimal(CONFIG_NFCe.CfgServico.ModeloDocumento),
                            Protocolo = retornoEnvio.Retorno.protNFe.infProt.nProt ?? "",
                            Numero = _nfe.infNFe.ide.nNF

                        }))
                        {
                            throw new Exception("Não foi possível salvar a NFC-e.");
                        }
                    }

                }

                if (retornoEnvio != null && !RetornoTransmissao.isContingencia && (retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.cStat : retornoEnvio.Retorno.protNFe.infProt.cStat) != 100)
                {
                    RetornoTransmissao.MotivoErro = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.xMotivo : retornoEnvio.Retorno.protNFe.infProt.xMotivo;
                    RetornoTransmissao.IDVenda = VENDA.IDVenda;
                    RetornoTransmissao.isAutorizada = false;
                    RetornoTransmissao.isContingencia = false;
                    RetornoTransmissao.IDMovimentoFiscal = IDMovimentoFiscal.Value;
                    RetornoTransmissao.NFe = _nfe;
                    RetornoTransmissao.Protocolo = retornoEnvio.Retorno.protNFe;
                    return RetornoTransmissao;
                }
                else
                {
                    RetornoTransmissao.isAutorizada = true;
                    RetornoTransmissao.IDMovimentoFiscal = IDMovimentoFiscal.Value;
                   
                    if (!RetornoTransmissao.isContingencia)
                    {
                        RetornoTransmissao.danfe = new DanfeFrNfce(new nfeProc()
                        {
                            NFe = _nfe,
                            protNFe = retornoEnvio.Retorno.protNFe,
                            versao = retornoEnvio.Retorno.versao
                        }, CONFIG_NFCe.ConfiguracaoDanfeNfce, CONFIG_NFCe.ConfiguracaoCsc.CIdToken, CONFIG_NFCe.ConfiguracaoCsc.Csc);
                    }
                    else
                    {
                        RetornoTransmissao.danfe = new DanfeFrNfce(_nfe, CONFIG_NFCe.ConfiguracaoDanfeNfce, CONFIG_NFCe.ConfiguracaoCsc.CIdToken, CONFIG_NFCe.ConfiguracaoCsc.Csc);
                    }


                    DAO.Entidades.Configuracao configExibirDialogo = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_EXIBIRCAIXADIALOGO);
                    if (configExibirDialogo != null && "1".Equals(Encoding.UTF8.GetString(configExibirDialogo.Valor)))
                    {
                        RetornoTransmissao.isVisualizar = true;
                    }
                    else
                    {
                        DAO.Entidades.Configuracao configNomeImpressora = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_NOMEIMPRESSORA);

                        RetornoTransmissao.isVisualizar = false;
                        RetornoTransmissao.NomeImpressora = configNomeImpressora != null ? Encoding.UTF8.GetString(configNomeImpressora.Valor) : string.Empty;
                        RetornoTransmissao.isCaixaDialogo = configExibirDialogo == null ? false : "1".Equals(Encoding.UTF8.GetString(configExibirDialogo.Valor));
                    }
                    Cursor.Current = Cursors.Default;
                    return RetornoTransmissao;
                }
            }
            catch (Exception Ex)
            {
                Cursor.Current = Cursors.Default;
                throw Ex;
            }


        }

    }
}