using DFe.Classes.Entidades;
using DFe.Classes.Flags;
using DFe.Utils;
using NFe.Classes;
using NFe.Classes.Informacoes;
using NFe.Classes.Informacoes.Cobranca;
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
using NFe.Classes.Servicos.Tipos;
using NFe.Danfe.Fast.NFe;
using NFe.Servicos;
using NFe.Servicos.Retorno;
using NFe.Utils;
using NFe.Utils.Excecoes;
using NFe.Utils.NFe;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.FISCAL.Base.NFe;
using PDV.CONTROLLER.FISCAL.Util;
using PDV.CONTROLLER.NFE.Configuracao;
using PDV.CONTROLLER.NFE.Impressao;
using PDV.CONTROLLER.NFE.Util;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.NFe;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace PDV.CONTROLLER.NFE.Transmissao
{
    public class EventosNFe : IConfigNFe
    {
        private NFe.Classes.NFe _nfe;
        private Emitente EMITENTE = null;
        private Endereco ENDERECO_EMITENTE = null;

        private Cliente CLIENTE = null;
        private Endereco ENDERECO_CLIENTE = null;

        private Transportadora TRANSPORTADORA = null;
        private Endereco ENDERECO_TRANSPORTADORA = null;

        private DAO.Entidades.NFe.NFe NFE = null;
        private VolumeNFe VOLUME = null;
        private List<ProdutoNFe> PRODUTOS_NFE = null;
        private List<DuplicataNFe> DUPLICATAS = null;
        public List<DuplicataNFe> PAGAMENTOS = null;
        public pag _pag;
        private List<DocumentoReferenciadoNFe> DOCS_REF = null;
        private decimal SERIE = 1;
        private int NUMERO;
        private decimal? IDMovimentoFiscal;

        public bool NFeIsValida { get; set; } = false;

        public EventosNFe(DAO.Entidades.NFe.NFe _NFe, decimal Serie, int NumeroNFe, decimal? IDMOVIMENTOFISCAL = null)
        {
            EMITENTE = FuncoesEmitente.GetEmitente();
            ENDERECO_EMITENTE = FuncoesEndereco.GetEndereco(EMITENTE.IDEndereco);
            NFE = _NFe;
            TRANSPORTADORA = FuncoesTransportadora.GetTransportadora(NFE.IDTransportadora ?? -1);
            if (TRANSPORTADORA != null)
                ENDERECO_TRANSPORTADORA = FuncoesEndereco.GetEndereco(TRANSPORTADORA.IDEndereco);

            PRODUTOS_NFE = new DataTableParser<ProdutoNFe>().ParseDataTable(FuncoesProdutoNFe.GetProdutos(NFE.IDNFe));
            DUPLICATAS = new DataTableParser<DuplicataNFe>().ParseDataTable(FuncoesDuplicataNFe.GetDuplicatas(NFE.IDNFe));
            
            DOCS_REF = new DataTableParser<DocumentoReferenciadoNFe>().ParseDataTable(FuncoesDocumentoReferenciadoNFe.GetDocumentosReferenciadosNFe(NFE.IDNFe));
            
            CLIENTE = FuncoesCliente.GetCliente(NFE.IDCliente);
            ENDERECO_CLIENTE = FuncoesEndereco.GetEndereco(CLIENTE.IDEndereco.Value);
            SERIE = Serie;
            NUMERO = NumeroNFe;
            VOLUME = FuncoesVolume.GetVolume(NFE.IDNFe);
            IDMovimentoFiscal = IDMOVIMENTOFISCAL;
        }

        protected virtual NFe.Classes.NFe GetNf()
        {
            return new NFe.Classes.NFe { infNFe = GetInf() };
        }

        protected dest GetDestinatario()

        {
            dest Destinatario = new dest(CONFIG_NFe.CfgServico.VersaoNFeAutorizacao);

            Municipio Municipio = FuncoesMunicipio.GetMunicipio(ENDERECO_CLIENTE.IDMunicipio.Value);
            Pais Pais = FuncoesPais.GetPais(ENDERECO_CLIENTE.IDPais.Value);
            if (CLIENTE.IDContato.HasValue)
            {
                Contato Contato = FuncoesContato.GetContato(CLIENTE.IDContato.Value);
                if (Contato != null && Contato.Email != null)
                    Destinatario.email = Contato.Email.Trim();
            }

            Destinatario.enderDest = new enderDest
            {
                CEP = ENDERECO_CLIENTE.Cep.ToString().Trim(),
                cMun = Convert.ToInt32(Municipio.CodigoIBGE),
                cPais = Convert.ToInt32(Pais.Codigo),
                nro = ENDERECO_CLIENTE.Numero.ToString().Trim(),
                UF = FuncoesUF.GetUnidadeFederativa(ENDERECO_CLIENTE.IDUnidadeFederativa.Value).Sigla,
                xBairro = cleanText(ENDERECO_CLIENTE.Bairro.Trim()),
                xCpl = cleanText(ENDERECO_CLIENTE.Complemento),
                xLgr = cleanText(ENDERECO_CLIENTE.Logradouro.Trim()),
                xMun = cleanText(Municipio.Descricao),
                xPais = Pais.Descricao,
            };

            Destinatario.indIEDest = (indIEDest)Enum.Parse(typeof(indIEDest), CLIENTE.TipoContribuinte.ToString());
            String DestinatarioNome = null;
            if (CLIENTE.TipoDocumento == 0)
            {
                Destinatario.CNPJ = ControllerFiscalUtil.SomenteNumeros(CLIENTE.CNPJ);
                if (CONFIG_NFe.CfgServico.tpAmb == TipoAmbiente.Homologacao)
                    DestinatarioNome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                else
                    DestinatarioNome = !string.IsNullOrEmpty(CLIENTE.Nome) ? CLIENTE.NomeFantasia : CLIENTE.NomeFantasia;




                if (!string.IsNullOrEmpty(CLIENTE.InscricaoEstadual))
                    Destinatario.IE = cleanText(CLIENTE.InscricaoEstadual.ToString());
            }
            else
            {
                Destinatario.CPF = ControllerFiscalUtil.SomenteNumeros(CLIENTE.CPF);
                if (CONFIG_NFe.CfgServico.tpAmb == TipoAmbiente.Homologacao)
                    DestinatarioNome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                else
                    DestinatarioNome = !string.IsNullOrEmpty(CLIENTE.RazaoSocial) ? CLIENTE.RazaoSocial : CLIENTE.Nome;
            }
            Destinatario.xNome = DestinatarioNome.Trim();

            if (CLIENTE.IDContato.HasValue)
            {
                Contato c = FuncoesContato.GetContato(CLIENTE.IDContato.Value);
                if (!string.IsNullOrEmpty(c.Telefone))
                    Destinatario.enderDest.fone = Convert.ToInt64(ControllerFiscalUtil.SomenteNumeros(c.Telefone));
            }

            return Destinatario;
        }

        public decimal TotalTributos = 0;
        protected det GetDetalhe(ProdutoNFe Item, int i, CRT Crt)
        {
            Produto _Produto = FuncoesProduto.GetProduto(Item.IDProduto);
            

            //_Produto.EAN = CONFIG_NFe.CfgServico.tpAmb == TipoAmbiente.Homologacao ? _Produto.EAN.Trim() : _Produto.EAN.Trim();
            
            
            _Produto.Descricao = CONFIG_NFe.CfgServico.tpAmb == TipoAmbiente.Homologacao ? "NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL" : _Produto.Descricao;

            Ncm NcmVigente = FuncoesNcm.GetItemTributoVigente(FuncoesNcm.GetNCM(_Produto.IDNCM).Codigo, string.IsNullOrEmpty(_Produto.EXTipi) ? null : (decimal?)Convert.ToDecimal(_Produto.EXTipi), NFE.Emissao);
            
            if (NcmVigente == null)
                throw new Exception(string.Format("O produto \"{0}\" não possui tributação vigênte. Verifique o cadastro do IBPT e tente novamente.", _Produto.Descricao));



            //decimal ValorTributosNacional = (_Produto.ValorVenda * (NcmVigente.NacionalFederal / 100)) * Item.Quantidade;
            //decimal ValorTributosEstadual = (_Produto.ValorVenda * (NcmVigente.Estadual / 100)) * Item.Quantidade;
            //decimal ValorTributosMunicipal = (_Produto.ValorVenda * (NcmVigente.Municipal / 100)) * Item.Quantidade;

            decimal totalProdutosImposto = Item.ValorTotal * ((NcmVigente.NacionalFederal + NcmVigente.Estadual + NcmVigente.Municipal) / 100);

            TotalTributos += totalProdutosImposto;

            IntegracaoFiscal Integ = FuncoesIntegracaoFiscal.GetIntegracao(Item.IDIntegracaoFiscal);
            prod Prod = Produtos.GetProduto(_Produto.Descricao,
                                            _Produto.IDProduto,
                                            _Produto.EAN,
                                            FuncoesNcm.GetNCM(_Produto.IDNCM).Codigo.ToString(),
                                            Convert.ToInt32(FuncoesCFOP.GetCFOP(Item.IDCFOP).Codigo),
                                            FuncoesUnidadeMedida.GetUnidadeMedida(Item.IDUnidadeDeMedida).Sigla,
                                            Item.Quantidade,
                                            Item.ValorUnitario,
                                            Item.Desconto,
                                            Item.Frete,
                                            Item.OutrasDespesas,
                                            Item.Seguro,
                                            _Produto.CEST == null ? null : _Produto.CEST.Trim(),
                                            _Produto.EXTipi);

            if (string.IsNullOrEmpty(Prod.cEAN))
                Prod.cEAN = "SEM GTIN";
            Prod.cEANTrib = Prod.cEAN;

            UnidadeFederativa UF = FuncoesUF.GetUnidadesFederativaComAliquotasICMS(EMITENTE.IDEmitente);
            UnidadeFederativa UFDest = FuncoesUF.GetUnidadesFederativaComAliquotasICMS_PorUF(ENDERECO_CLIENTE.IDUnidadeFederativa.Value);

            decimal vBCProd = ((Item.ValorUnitario * Item.Quantidade) + Item.OutrasDespesas + Item.Frete + Item.Seguro) - Item.Desconto;

            ProdutoNFeICMS ProdICMS = FuncoesProdutoNFeICMS.GetProdutoICMSPorProdutoNFe(Item.IDProdutoNFe);
            ProdutoNFePIS ProdPIS = FuncoesProdutoNFePIS.GetProdutoPISPorProdutoNFe(Item.IDProdutoNFe);
            ProdutoNFeCOFINS ProdCOFINS = FuncoesProdutoNFeCOFINS.GetProdutoCOFINSPorProdutoNFe(Item.IDProdutoNFe);
            ProdutoNFePartilhaICMS ProdPartilha = FuncoesProdutoNFePartilhaICMS.GetPartilhasPorProdutoNFe(Item.IDProdutoNFe);

            CSTIpi CstIPI = FuncoesCst.GetCSTIpi(Integ.IDCSTIpi);

            det Det = Detalhe.GetDetalhe(Prod, new imposto
            {
                vTotTrib = totalProdutosImposto,
                ICMS = new ICMS
                {
                    TipoICMS = Imposto.GetICMS_NFe(Convert.ToInt32(FuncoesCst.GetCSTIcmsPorID(Integ.IDCSTIcms).CSTCSOSN),
                                                   Convert.ToInt32(FuncoesOrigemProduto.GetOrigemProduto(_Produto.IDOrigemProduto).Codigo),
                                                   vBCProd,
                                                   ProdICMS.PIcmsST,
                                                   ProdICMS.PIcms,
                                                   ProdICMS.PRedBC,
                                                   ProdICMS.PRedBcST,
                                                   ProdICMS.PMVAST,
                                                   Integ.IPI == 1 && CstIPI.CST == 2 ? _Produto.Trib_AliqIPI : 0,
                                                   ProdICMS.PCredSN,
                                                   ProdICMS.PDif,
                                                   Integ.ICMS_REDST == 1,
                                                   ENDERECO_CLIENTE.IDUnidadeFederativa != ENDERECO_EMITENTE.IDUnidadeFederativa)
                },
                IPI = CstIPI.CST != 2 ? null : new IPI { cEnq = 999, TipoIPI = Imposto.GetIPI_NFe(Convert.ToInt32(CstIPI.CST), Item.ValorTotal, _Produto.Trib_AliqIPI) },
                PIS = new PIS { TipoPIS = Imposto.GetPIS_NFe(Convert.ToInt32(FuncoesCst.GetCSTPis(ProdPIS.IDCstPIS).CST), vBCProd, ProdPIS.VPis) },
                COFINS = new COFINS { TipoCOFINS = Imposto.GetCOFINS_NFe(Convert.ToInt32(FuncoesCst.GetCSTCofins(ProdCOFINS.IDCstCOFINS).CST), vBCProd, ProdCOFINS.VCOFINS) },
            }, 0, 0, 0, NcmVigente.Chave, i + 1);

            if (Crt != CRT.SimplesNacional)
                if (((UF.IDUnidadeFederativa != UFDest.IDUnidadeFederativa) && CLIENTE.ConsumidorFinal != 0 && (CLIENTE.TipoContribuinte != 1 && CLIENTE.TipoContribuinte != 2)))
                    Det.imposto.ICMSUFDest = Imposto.GetPartilha(vBCProd, ProdPartilha.PIcmsInter, ProdPartilha.PIcmsUFDest, ProdPartilha.PFcpUFDest);
            return Det;
        }


        protected List<pag> GetPagamento(List<DuplicataNFe> DuplicatasPagamento)
        {

           if (CONFIG_NFe.CfgServico.tpAmb == TipoAmbiente.Homologacao)
            {
                detPag _dpag = new detPag()
                {
                  //  indPag = IndicadorPagamentoDetalhePagamento.ipDetPgVista,
                    tPag = FormaPagamento.fpSemPagamento,
                   
                };

                ListaDeDetPagamentos.Add(_dpag);
                _pag.detPag = ListaDeDetPagamentos;

                List<pag> pagamentoss = new List<pag>();
                pagamentoss.Add(_pag);

                return pagamentoss;
            }




            foreach (var item in DuplicatasPagamento)
            {
                FormaDePagamento formaDePagamentoPag = FuncoesFormaDePagamento.GetFormaDePagamento(item.IDFormaDePagamento);
                if (formaDePagamentoPag.Transacao == 1)
                {
                    detPag _dpag = new detPag()
                    {
                        indPag = IndicadorPagamentoDetalhePagamento.ipDetPgVista,
                        tPag = FormaPagamento.fpDinheiro,
                        vPag = item.Valor
                    };
                    ListaDeDetPagamentos.Add(_dpag);
                }
                else
                {

                    detPag _dpag = new detPag()
                    {
                        indPag = IndicadorPagamentoDetalhePagamento.ipDetPgPrazo,
                        tPag = FormaPagamento.fpDuplicataMercantil,
                        vPag = item.Valor

                    };
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
        public List<dup> Duplicatas = new List<dup>();
        public List<pag> ListaDePagamentos = new List<pag>();
        public List<detPag> ListaDeDetPagamentos = new List<detPag>();
        protected infNFe GetInf()
        {
            var infNFe = new infNFe
            {
                versao = Conversao.VersaoServicoParaString(CONFIG_NFe.CfgServico.VersaoNFeAutorizacao),
                ide = GetIdentificacao(),
                emit = CONFIG_NFe.Emitente,
                dest = GetDestinatario(),
                transp = new transp { modFrete = ModalidadeFrete.mfSemFrete },



                infAdic = new infAdic { infCpl = (string.IsNullOrEmpty(cleanText("NFE.InformacoesComplementares")) ? string.Empty : cleanText(NFE.InformacoesComplementares).Replace(Environment.NewLine, string.Empty)) }

             
            };

            switch (Convert.ToInt32(NFE.FretePor))
            {
                case 0: //emitente
                case 1: //destinatario
                case 2: //terceiros
                    if (TRANSPORTADORA != null)
                    {
                        UnidadeFederativa UFTransp = ENDERECO_TRANSPORTADORA == null ? null : FuncoesUF.GetUnidadeFederativa(ENDERECO_TRANSPORTADORA.IDUnidadeFederativa.Value);
                        Municipio MunTransp = ENDERECO_TRANSPORTADORA == null ? null : FuncoesMunicipio.GetMunicipio(ENDERECO_TRANSPORTADORA.IDMunicipio.Value);

                        infNFe.transp = new transp
                        {
                            modFrete = (ModalidadeFrete)Enum.Parse(typeof(ModalidadeFrete), NFE.FretePor.ToString()),
                            transporta = new transporta
                            {
                                xEnder = ENDERECO_TRANSPORTADORA.Logradouro,
                                UF = UFTransp.Sigla,
                                xMun = MunTransp.Descricao,
                            },

                            veicTransp = !string.IsNullOrEmpty(NFE.Placa) ? new veicTransp
                            {
                                placa = NFE.Placa.Replace("-", string.Empty).ToUpper(),
                                UF = UFTransp.Sigla
                            } : null
                        };



                        if (TRANSPORTADORA.TipoDocumento == 0)
                        {
                            infNFe.transp.transporta.xNome = TRANSPORTADORA.RazaoSocial;
                            infNFe.transp.transporta.CNPJ = TRANSPORTADORA.CNPJ;
                            if (TRANSPORTADORA.InscricaoEstadual.HasValue)
                                infNFe.transp.transporta.IE = TRANSPORTADORA.InscricaoEstadual.Value.ToString();
                        }
                        else if (TRANSPORTADORA.TipoDocumento == 1)
                        {
                            infNFe.transp.transporta.xNome = TRANSPORTADORA.Nome;
                            infNFe.transp.transporta.CPF = TRANSPORTADORA.CPF;


                        }
                    }

                    List<vol> Volumes = new List<vol>();
                    if (VOLUME.PesoBruto > 0 && VOLUME.PesoLiquido > 0)
                        Volumes.Add(new vol
                        {
                            esp = VOLUME.Especie,
                            marca = VOLUME.Marca,
                            nVol = VOLUME.Numero,
                            pesoB = VOLUME.PesoBruto,
                            pesoL = VOLUME.PesoLiquido,
                            qVol = int.Parse(VOLUME.Volume.ToString())
                        });
                    infNFe.transp.vol = Volumes;
                    infNFe.transp.modFrete = (ModalidadeFrete)Enum.Parse(typeof(ModalidadeFrete), NFE.FretePor.ToString());
                    break;
            }

            for (int i = 0; i < PRODUTOS_NFE.Count; i++)
                infNFe.det.Add(GetDetalhe(PRODUTOS_NFE[i], i, infNFe.emit.CRT));

            switch (infNFe.emit.CRT)
            {
                case CRT.SimplesNacional:
                    infNFe.total = Totais.GetTotalNFe_SimplesNacional(infNFe.det);
                    break;
                case CRT.SimplesNacionalExcessoSublimite:
                case CRT.RegimeNormal:
                    infNFe.total = Totais.GetTotalNFe_RegimeNormall(infNFe.det);
                    break;
            }
            //Definir a operação da venda Se é a prazo ou a vista identificar isso no operação de venda 
            //antes formas

            //Duplicata e fatura é quando a transação é a prazo 
            //Pagamento é quando a transacao for a vista(Dinheiro, Cartão , Cheque , Boleto etc...) ou outros(Devolução, Remessa para concerto ect....)
            //Arrumar iss
            decimal valorliquidofatura = 0;
            foreach (var item in DUPLICATAS)
            {
                FormaDePagamento formaDePagamento = FuncoesFormaDePagamento.GetFormaDePagamento(item.IDFormaDePagamento);

                if (formaDePagamento.Transacao != 1)
                {
                    valorliquidofatura += item.Valor;

                    var c = new cobr
                    {
                        fat = new fat { nFat = infNFe.ide.nNF.ToString(), vOrig = valorliquidofatura, vDesc = 0, vLiq = valorliquidofatura },
                    };

                    Duplicatas.Add(new dup
                    {
                        dVenc = item.DataVencimento,
                        nDup = item.IDDuplicataNFe.ToString(),
                        vDup = item.Valor
                    });
                    c.dup = Duplicatas;
                    infNFe.cobr = c;

                

                }
            }

            if (infNFe.ide.mod == ModeloDocumento.NFe)
                _pag = new pag();

            infNFe.pag = GetPagamento(DUPLICATAS); //NFCe Somente
            

            if (infNFe.emit.enderEmit.UF == Estado.BA)
            {
                List<autXML> ListaAutXML = new List<autXML>();
                autXML autxml = new autXML();
                autxml.CNPJ = "13937073000156";
                ListaAutXML.Add(autxml);

                infNFe.autXML = ListaAutXML;
            }

           infNFe.infAdic.infCpl = $"{ infNFe.infAdic.infCpl} .Valor aproximado total de tributos federais, estaduais e municipais:{TotalTributos.ToString("n2")}  Fonte: IBPT";
           // infNFe.infAdic.infCpl = $"{ infNFe.infAdic.infCpl}";
            
          
            
            return infNFe;
        }

        protected ide GetIdentificacao()
        {
            List<NFref> DocsRef = new List<NFref>();
            foreach (DocumentoReferenciadoNFe Doc in DOCS_REF)
                DocsRef.Add(new NFref() { refNFe = Doc.Chave });

            var ide = new ide
            {
                verProc = Conversao.VersaoServicoParaString(CONFIG_NFe.CfgServico.VersaoNFeAutorizacao),
                cUF = CONFIG_NFe.Emitente.enderEmit.UF,
                //só 3.1 para baixo  indPag = (IndicadorPagamento)Enum.Parse(typeof(IndicadorPagamento), NFE.INDPagamento.ToString()),
                mod = ModeloDocumento.NFe,
                serie = Convert.ToInt32(SERIE),
                nNF = NUMERO,
                tpNF = FuncoesCFOP.GetCFOP(NFE.IDCFOP).Tipo.Equals("1") ? TipoNFe.tnEntrada : TipoNFe.tnSaida,
                cMunFG = CONFIG_NFe.Emitente.enderEmit.cMun,
                tpEmis = CONFIG_NFe.CfgServico.tpEmis,
                tpImp = TipoImpressao.tiRetrato,
                cNF = NUMERO.ToString() + 55,
                tpAmb = CONFIG_NFe.CfgServico.tpAmb,
                idDest = ENDERECO_CLIENTE.IDUnidadeFederativa != ENDERECO_EMITENTE.IDUnidadeFederativa ? DestinoOperacao.doInterestadual : DestinoOperacao.doInterna,
                dhEmi = NFE.Emissao,
                procEmi = ProcessoEmissao.peAplicativoContribuinte,
                indFinal = CLIENTE.ConsumidorFinal == 1 ? ConsumidorFinal.cfConsumidorFinal : ConsumidorFinal.cfNao,
                indPres = (PresencaComprador)Enum.Parse(typeof(PresencaComprador), FuncoesTipoAtendimento.GetTipoAtendimento(NFE.IDTipoAtendimento).Codigo),
                finNFe = (FinalidadeNFe)Enum.Parse(typeof(FinalidadeNFe), FuncoesFinalidade.GetFinalidade(NFE.IDFinalidade).Codigo),
                dhSaiEnt = NFE.Saida,
                natOp = TratarCFOPDescricao(FuncoesCFOP.GetCFOP(NFE.IDCFOP).Descricao),
                NFref = DocsRef
            };
            return ide;
        }

        private string TratarCFOPDescricao(string descricao)
        {
            if (descricao.Length > 60)
                return descricao.Substring(0, 60);
            return descricao;
        }

        public NFe.Classes.NFe PreviewXml()
        {
            _nfe = GetNf();
            _nfe = FuncoesXml.XmlStringParaClasse<NFe.Classes.NFe>(ControllerFiscalUtil.RemoverAcentos(_nfe.ObterXmlString()));
            //_nfe.Valida();
            try
            {
                return _nfe;

            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public RetornoTransmissaoNFe TransmitirNFe()
        {
            try
            {
                string SXmlAutorizado = "";
                DAO.Enum.TipoOperacao Op = DAO.Enum.TipoOperacao.UPDATE;
                if (!IDMovimentoFiscal.HasValue || IDMovimentoFiscal == 0)
                {
                    IDMovimentoFiscal = Sequence.GetNextID("MOVIMENTOFISCAL", "IDMOVIMENTOFISCAL");
                    Op = DAO.Enum.TipoOperacao.INSERT;
                }

                RetornoTransmissaoNFe RetornoTransmissao = new RetornoTransmissaoNFe();

                _nfe = GetNf();





                _nfe = FuncoesXml.XmlStringParaClasse<NFe.Classes.NFe>(ControllerFiscalUtil.RemoverAcentos(_nfe.ObterXmlString()));

                _nfe.Assina();
                try
                {
                    if (!Directory.Exists("c:\\XMLENVI\\"))
                        Directory.CreateDirectory("c:\\XMLENVI\\");
                    _nfe.SalvarArquivoXml(@"c:\XMLENVI\" + _nfe.infNFe.ide.cNF + ".xml");
                }
                catch (Exception)
                {


                }

                _nfe.Valida();
                NFeIsValida = true;

                var servicoNFe = new ServicosNFe(CONFIG_NFe.CfgServico);
                RetornoNFeAutorizacao retornoEnvio = null;
                RetornoNFeRetAutorizacao retornoRecibo = null;
                string r_enviostr = string.Empty;
                string r_retornostr = string.Empty;

                try
                {
                    // Se chegou até aqui é por que a nota é válida.
                    IndicadorSincronizacao indicadorSinc = IndicadorSincronizacao.Sincrono;
                    DAO.Entidades.Configuracao configSincrono = FuncoesConfiguracao.GetConfiguracao("METODO_SINCRONO");

                    if (configSincrono != null && "0".Equals(Encoding.UTF8.GetString(configSincrono.Valor)))
                        indicadorSinc = IndicadorSincronizacao.Assincrono;

                    retornoEnvio = servicoNFe.NFeAutorizacao(1, indicadorSinc, new List<NFe.Classes.NFe> { _nfe }, false /*Envia a mensagem compactada para a SEFAZ*/);

                    if (indicadorSinc == IndicadorSincronizacao.Assincrono)
                    {
                        Thread.Sleep(3000);
                        retornoRecibo = servicoNFe.NFeRetAutorizacao(retornoEnvio.Retorno.infRec.nRec);

                        if (retornoRecibo.Retorno.protNFe.Count > 0)
                        {
                            retornoEnvio.Retorno.cStat = retornoRecibo.Retorno.protNFe[0].infProt.cStat;
                            //retornoEnvio.Retorno.nRec = int.Parse(retornoEnvio.Retorno.infRec.nRec);
                            retornoEnvio.Retorno.xMotivo = retornoRecibo.Retorno.protNFe[0].infProt.xMotivo;
                            r_enviostr = retornoRecibo.EnvioStr;
                            r_retornostr = retornoRecibo.RetornoStr;
                            foreach (var Item in retornoRecibo.Retorno.protNFe)
                            {
                                retornoEnvio.Retorno.protNFe = Item;
                            }
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
                                    _nfe.SalvarArquivoXml(@"c:\XMLENVIADOAPROV\" + r_retornostr + ".xml");
                                }
                                catch (Exception)
                                {

                                }
                                //imprimirdanfe(novoArquivo);
                                //                              MessageBox.Show("Nota fiscal eletrônica enviada com sucesso.", "UDISYS Sistemas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        
                        else
                        {
                            r_enviostr = retornoEnvio.EnvioStr;
                            r_retornostr = retornoEnvio.RetornoStr;

                            
                        }
                    }
                 
                    r_enviostr = retornoEnvio.EnvioStr;
                    //r_retornostr = retornoEnvio.RetornoStr;
                }
                catch (ComunicacaoException ex)
                {
                    RetornoTransmissao.isAutorizada = false;
                    RetornoTransmissao.isSchemaValido = true;
                    RetornoTransmissao.MotivoErro = ex.Message;
                    return RetornoTransmissao;
                }
                catch (ValidacaoSchemaException Ex)
                {
                    RetornoTransmissao.isAutorizada = false;
                    RetornoTransmissao.isSchemaValido = false;
                    RetornoTransmissao.MotivoErro = Ex.Message;
                    return RetornoTransmissao;
                }
                catch (Exception Ex)
                {
                    RetornoTransmissao.isAutorizada = false;
                    RetornoTransmissao.isSchemaValido = true;
                    RetornoTransmissao.MotivoErro = Ex.Message;
                    return RetornoTransmissao;
                }

                switch (Op)
                {
                    case DAO.Enum.TipoOperacao.INSERT:
                        if (!FuncoesMovimentoFiscal.Salvar(new MovimentoFiscal()
                        {
                            IDMovimentoFiscal = IDMovimentoFiscal.Value,
                            Cancelada = 0,
                            cStat = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.cStat : retornoEnvio.Retorno.protNFe.infProt.cStat,
                            DataRecebimento = retornoEnvio.Retorno.dhRecbto,
                            DataEmissao = _nfe.infNFe.ide.dhEmi.UtcDateTime,
                            Emitida = 1,
                            IDNFe = NFE.IDNFe,
                            Serie = SERIE,
                            xMotivo = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.xMotivo : retornoEnvio.Retorno.protNFe.infProt.xMotivo,
                            Chave = _nfe.infNFe.Id,
                            XMLEnvio = Encoding.Default.GetBytes(r_enviostr),
                            XMLRetorno = Encoding.Default.GetBytes(r_retornostr),
                            
                            Contingencia = 0,
                            Ambiente = Convert.ToDecimal(CONFIG_NFe.CfgServico.tpAmb),
                            TipoDocumento = Convert.ToDecimal(CONFIG_NFe.CfgServico.ModeloDocumento),
                            Numero = _nfe.infNFe.ide.nNF,
                            IDVenda = null,
                            Protocolo = retornoEnvio.Retorno.protNFe.infProt.nProt,
                        }))
                            throw new Exception("Não foi possível salvar a NF-e.");
                        break;
                    case DAO.Enum.TipoOperacao.UPDATE:
                        if (!FuncoesMovimentoFiscal.AtualizarMovimentoPorID(new MovimentoFiscal()
                        {
                            IDMovimentoFiscal = IDMovimentoFiscal.Value,
                            Cancelada = 0,
                            cStat = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.cStat : retornoEnvio.Retorno.protNFe.infProt.cStat,
                            DataRecebimento = retornoEnvio.Retorno.dhRecbto,
                            DataEmissao = _nfe.infNFe.ide.dhEmi.UtcDateTime,
                            Emitida = 1,
                            IDNFe = NFE.IDNFe,
                            Serie = SERIE,
                            xMotivo = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.xMotivo : retornoEnvio.Retorno.protNFe.infProt.xMotivo,
                            Chave = _nfe.infNFe.Id,
                            XMLEnvio = Encoding.Default.GetBytes(r_enviostr),
                            XMLRetorno = Encoding.Default.GetBytes(SXmlAutorizado),//Encoding.Default.GetBytes(r_retornostr),
                            Contingencia = 0,
                            Ambiente = Convert.ToDecimal(CONFIG_NFe.CfgServico.tpAmb),
                            TipoDocumento = Convert.ToDecimal(CONFIG_NFe.CfgServico.ModeloDocumento),
                            Numero = _nfe.infNFe.ide.nNF,
                            Protocolo = retornoEnvio.Retorno.protNFe.infProt.nProt
                        }))
                            throw new Exception("Não foi possível salvar a NF-e.");
                        break;
                }

                if (retornoEnvio != null && (retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.cStat : retornoEnvio.Retorno.protNFe.infProt.cStat) != 100)
                {
                    RetornoTransmissao.MotivoErro = retornoEnvio.Retorno.xMotivo;
                    RetornoTransmissao.IDVenda = NFE.IDNFe;
                    RetornoTransmissao.isAutorizada = false;
                    RetornoTransmissao.IDMovimentoFiscal = IDMovimentoFiscal.Value;
                    RetornoTransmissao.NFe = _nfe;
                    RetornoTransmissao.Protocolo = retornoEnvio.Retorno.protNFe;
                    return RetornoTransmissao;
                }
                else
                {
                    RetornoTransmissao.IDMovimentoFiscal = IDMovimentoFiscal.Value;
                    RetornoTransmissao.isAutorizada = true;
                    RetornoTransmissao.danfe = new DanfeFrNfe(new nfeProc()
                    {
                        NFe = _nfe,
                        protNFe = retornoEnvio.Retorno.protNFe,
                        versao = retornoEnvio.Retorno.versao
                    }, CONFIG_NFe.ConfiguracaoDanfeNFe, "Sistema Comercial");

                    DAO.Entidades.Configuracao configExibirDialogo = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_EXIBIRCAIXADIALOGO_NFE);
                    if (configExibirDialogo != null && "1".Equals(Encoding.UTF8.GetString(configExibirDialogo.Valor)))
                        RetornoTransmissao.isVisualizar = true;
                    else
                    {
                        DAO.Entidades.Configuracao configNomeImpressora = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_NOMEIMPRESSORA_NFE);

                        RetornoTransmissao.isVisualizar = false;
                        RetornoTransmissao.NomeImpressora = configNomeImpressora != null ? Encoding.UTF8.GetString(configNomeImpressora.Valor) : string.Empty;
                        RetornoTransmissao.isCaixaDialogo = configExibirDialogo == null ? false : "1".Equals(Encoding.UTF8.GetString(configExibirDialogo.Valor));
                    }
                    return RetornoTransmissao;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private String cleanText(String sText)
        {
            if (string.IsNullOrEmpty(sText))
            {
                return null;
            }
            else
            {
                String[] cLetters = { "a", "e", "i", "o", "u", "c", "n", "A", "E", "I", "O", "U", "C", "N" };
                String[] regexPatterns = { "(à|á|â|ã){1}", "(è|é|ê){1}", "(ì|í|î){1}", "(ò|ó|ô|õ){1}", "(ù|ú|û){1}", "ç{1}", "ñ{1}", "(À|Á|Â|Ã){1}", "(È|É|Ê){1}", "(Ì|Í|Î){1}", "(Ò|Ó|Ô|Õ){1}", "(Ù|Ú|Û){1}", "Ç{1}", "Ñ{1}" };

                for (int index = 0; index < cLetters.Length - 1; index++)
                {
                    sText = System.Text.RegularExpressions.Regex.Replace(sText, regexPatterns[index], cLetters[index]);
                }

                return sText;
            }
        }
    }
}