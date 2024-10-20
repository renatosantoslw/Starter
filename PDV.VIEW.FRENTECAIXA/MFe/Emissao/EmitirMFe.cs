using ACBr.Net.Sat;
using System;
using System.Linq;
using System.Text;
using PDV.DAO.Entidades;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.PDV;
using PDV.VIEW.FRENTECAIXA.Forms;
using NFe.Classes.Informacoes.Detalhe;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using System.Windows.Forms;
using MetroFramework;
using IntegracaoMFE;
using CFeImpressao;
using System.Diagnostics;
using DFe.Classes.Flags;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.FRENTECAIXA.Tasks;
using PDV.VIEW.FRENTECAIXA.Forms.PDV;
using System.Threading;
using System.IO;
using PDV.DAO.Custom;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Globalization;

namespace PDV.VIEW.FRENTECAIXA.MFe.Emissao
{
    public class EmitirMFe 
    {
        public IntegracaoMFE.MFE mfe;
        public RetornoMFe retornoMFe;
        public RetornoPagamento retornoPagamento;
        public Emitente Emitente;
        public Caixa caixa;

        public class Log
        {
            public DateTime DataHora { get; set; }
            public string Mensagem { get; set; }
        }
        public static class WSMonitoramento
        {
            private static BindingList<Log> _Log { get; set; }
            public static BindingList<Log> Log
            {
                get
                {
                    if (_Log == null)
                    {
                        _Log = new BindingList<Log>();
                        _Log.AllowEdit = false;
                        _Log.AllowNew = true;
                        _Log.AllowRemove = true;
                    }

                    return _Log;
                }
                set
                {
                    _Log = value;
                }
            }

            public static void AddLog(string msg)
            {
                AddLog(new Log() { DataHora = DateTime.Now, Mensagem = msg });

            }
            public static void AddLog(Log log)
            {
                try
                {
                    Log.Add(log);

                    if (Log.Count > 220)
                    {
                        Log = new BindingList<Log>(Log.ToList());
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        public RetornoMFe TransmitirMFe(GPDV_PainelInicial TelaInicial)
        {
            try
            {
                WSMonitoramento.Log = null;
                TipoDeOperacao tipoDeOperacao;
                Configuracao config3 = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.TIPO_OPERACAO_PADRAO_PDV);
                if (config3 != null)
                {
                    var idtipo = Encoding.UTF8.GetString(config3.Valor);
                    tipoDeOperacao = FuncoesTipoDeOperacao.GetTipoDeOperacao(decimal.Parse(idtipo.Replace(',', '.'), CultureInfo.InvariantCulture));
                    if (tipoDeOperacao == null)
                    {
                        throw new Exception("Tipo de operação padrão do PDV não foi definido nas configurações da venda. Defina um tipo de operação para vendas no PDV no retaguarda.");
                    }
                }
                else
                {
                    throw new Exception("Tipo de operação padrão do PDV não  foi definido nas configurações da venda. Defina um tipo de operação para vendas no PDV.");
                }


                retornoMFe = new RetornoMFe();
                retornoPagamento = new RetornoPagamento();
                mfe = new MFE();
                CFe novoCfe = new CFe();
                FluxoCaixa fluxoCaixa = FuncoesFluxoCaixa.GetFluxoCaixa(TelaInicial.VENDA.IDFluxoCaixa);
                caixa =FuncoesCaixa.GetCaixa(fluxoCaixa.CaixaID);

                #region MFeConfiguração
                WSMonitoramento.AddLog("Conectando com a SEFAZ Aguarde...");
                decimal? IDMovimentoFiscal;
               
                #region Instanciando Classes       

                //Obter Dados da Empresa
                Emitente = FuncoesEmitente.GetEmitente();
                #endregion
                mfe.CodigoAtivacao = Emitente.CodigoAtivacao; //Codigo de Ativação do Equipamento
                mfe.GravarXmlEmPasta = true; //Se Deseja gravar o XML em uma pasta
                mfe.LocalArquivoXML = Emitente.PastaXml; //Se o campo acima for true deve informar o local
                if (!Directory.Exists(mfe.LocalArquivoXML))
                {
                    //Criamos um com o nome folder
                    Directory.CreateDirectory(mfe.LocalArquivoXML);
                }

                mfe.PastaImput = Emitente.PastaInput; // Local da Pasta Input do Integrador (esta informado as configurações do  Integrador Fiscal)
                mfe.PastaOutput = Emitente.PastaOutPut; // Local da Pasta OutPut do Integrador (esta informado as configurações do  Integrador Fiscal)
                mfe.TipoEnvioDLL = true; //Se utiliza o Software da Sefaz Drive MFE de Comunicação Direta, deve informar como true
                Decimal versao = Convert.ToDecimal(Emitente.VersaoXML.Replace(".", ","));
                #endregion

                #region Ide
                WSMonitoramento.AddLog("Transmitindo Cupom...");
                novoCfe.InfCFe.VersaoDadosEnt = versao; // Ver a versão do XML do Equipamento (Atualmente pode estar com 0.07 ou 0.08)
                novoCfe.InfCFe.Ide.CNPJ = Emitente.CNPJSoftwareHouse; // CNPJ do SH
                novoCfe.InfCFe.Ide.SignAC = Emitente.SignAC; //Assinatura do AC
                novoCfe.InfCFe.Ide.NumeroCaixa = int.Parse(caixa.IDCaixa.ToString()); //Pode ser uma serie ou o numero do Caixa de cada maquina

                #endregion

                #region Emite

                novoCfe.InfCFe.Emit.CNPJ = Emitente.CNPJ; // CNPJ do Contribuinte
                novoCfe.InfCFe.Emit.IE = Emitente.InscricaoEstadual.PadLeft(12,'0'); // IE do Contribuinte
                // 064941426
                   //064941426000

                novoCfe.InfCFe.Emit.CRegTribISSQN = (RegTribIssqn)1;
                novoCfe.InfCFe.Emit.IndRatISSQN = (RatIssqn)1;
                #endregion

                #region Dest
                //Se cliente Identificado na venda informe os campos abaixo, senão não informe nenhum dos 2
                if (TelaInicial.Cliente != null)
                {
                    novoCfe.InfCFe.Dest.CPF = TelaInicial.Cliente._CPF_CNPJ;
                    //ou CNPJ: novoCfe.InfCFe.Dest.CNPJ = "08723218000186";
                    novoCfe.InfCFe.Dest.Nome = TelaInicial.Cliente.Nome == null ? "NAO Identificado" : TelaInicial.Cliente.Nome; //Se informou CPF ou CNPJ deve informar o Nome, caso não souber o nome pode informar  "Nao Identificado"
                }
                else
                {
                    novoCfe.InfCFe.Dest.Nome = "NAO Identificado";
                }
                #endregion

                #region Itens
                decimal ValorTributosNacionalTot = 0;
                decimal ValorTributosEstadualTot = 0;
                decimal ValorTributosMunicipalTot = 0;
                decimal ValorAproxImposTot = 0;
                int Item = 0;
                foreach (var item in TelaInicial.ITENS_VENDA)
                {
                    Item += 1;
                    Produto _Produto = FuncoesProduto.GetProduto(item.IDProduto);
                    IntegracaoFiscal IntegracaoFiscal = FuncoesIntegracaoFiscal.GetIntegracao(_Produto.IDIntegracaoFiscalNFCe.Value);

                    Ncm NcmVigente = FuncoesNcm.GetItemTributoVigente(FuncoesNcm.GetNCM(_Produto.IDNCM).Codigo, string.IsNullOrEmpty(_Produto.EXTipi) ? null : (decimal?)Convert.ToDecimal(_Produto.EXTipi), TelaInicial.VENDA.DataCadastro);
                    if (NcmVigente == null)
                    {
                        throw new Exception(string.Format("O produto \"{0}\" não possui tributação vigênte. Verifique o cadastro do IBPT e tente novamente.", _Produto.Descricao));
                    }
                    decimal ValorTributosNacional = (_Produto.ValorVenda * (NcmVigente.NacionalFederal / 100)) * item.Quantidade;
                    decimal ValorTributosEstadual = (_Produto.ValorVenda * (NcmVigente.Estadual / 100)) * item.Quantidade;
                    decimal ValorTributosMunicipal = (_Produto.ValorVenda * (NcmVigente.Municipal / 100)) * item.Quantidade;
                    decimal ValorAproxImpos = ValorTributosNacional + ValorTributosEstadual + ValorTributosMunicipal;

                    ValorTributosNacionalTot += ValorTributosNacional;
                    ValorTributosEstadualTot += ValorTributosEstadual;
                    ValorTributosMunicipalTot += ValorTributosMunicipalTot;
                    ValorAproxImposTot += ValorTributosNacional + ValorTributosEstadual + ValorTributosMunicipalTot;

                    //Fazer um Loop para cada item
                    CFeDet detCfe = novoCfe.InfCFe.Det.AddNew();
                    detCfe.NItem = Item;
                    detCfe.Prod.CProd = _Produto.Codigo;
                    detCfe.Prod.XProd = _Produto.Descricao;
                    detCfe.Prod.NCM = NcmVigente.Codigo.ToString();
                    string cest = _Produto.CEST == null ? _Produto.CEST : null;
                    if (novoCfe.InfCFe.VersaoDadosEnt.Equals(0.08M) && string.IsNullOrEmpty(cest)) // Se a versão for 0.08 e tiver CEST deve informar o campo abaixo
                        detCfe.Prod.CEST = cest;
                    detCfe.Prod.CFOP = FuncoesCFOP.GetCFOP(tipoDeOperacao.IDOperacaoFiscal).Codigo;
                    detCfe.Prod.UCom = FuncoesUnidadeMedida.GetUnidadeMedida(_Produto.IDUnidadeDeMedida).Sigla;
                    detCfe.Prod.QCom = item.Quantidade;
                    detCfe.Prod.VUnCom = item.Subtotal; // Valor Unitario
                    detCfe.Prod.IndRegra = IndRegra.Arredondamento;
                    decimal desconto = item.DescontoValor;
                    if (desconto > 0) //Se tiver desconto no item informar
                        detCfe.Prod.VDesc = desconto;
                    detCfe.Imposto.VItem12741 = ValorAproxImpos; // Valor Aproximado dos tributos

                    //Impostos do Produto
                    det impostos = ImpostoProdutoMFe.GetDetalhe(TelaInicial.VENDA, item, 1, NFe.Classes.Informacoes.Emitente.CRT.SimplesNacional, ModeloDocumento.NFCe, Emitente);

                    if (impostos.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS00))
                    {
                        var teste = (impostos.imposto.ICMS.TipoICMS as ICMS00).pICMS.ToString();

                        detCfe.Imposto.Imposto = new ImpostoIcms
                        {
                            Icms = new ImpostoIcms00
                            {
                                Orig = OrigemMercadoria.Nacional,
                                Cst = "00",
                                PIcms = (impostos.imposto.ICMS.TipoICMS as ICMS00).pICMS,
                                VIcms = 0,
                            }
                        };
                    }
                    else if (impostos.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS40))
                    {
                        detCfe.Imposto.Imposto = new ImpostoIcms
                        {
                            Icms = new ImpostoIcms40
                            {
                                Orig = OrigemMercadoria.Nacional,
                                Cst = "40",
                            }
                        };
                    }

                    else if (impostos.imposto.ICMS.TipoICMS.GetType() == typeof(ICMSSN102))
                    {
                        detCfe.Imposto.Imposto = new ImpostoIcms
                        {
                            Icms = new ImpostoIcmsSn102
                            {
                                Orig = OrigemMercadoria.Nacional,
                                Csosn = "102",
                            }
                        };
                    }
                    else if (impostos.imposto.ICMS.TipoICMS.GetType() == typeof(ICMSSN102))
                    {
                        detCfe.Imposto.Imposto = new ImpostoIcms
                        {
                            Icms = new ImpostoIcmsSn102
                            {
                                Orig = OrigemMercadoria.Nacional,
                                Csosn = "102",
                            }
                        };
                    }

                    else if (impostos.imposto.ICMS.TipoICMS.GetType() == typeof(ICMSSN500))
                    {
                        detCfe.Imposto.Imposto = new ImpostoIcms
                        {
                            Icms = new ImpostoIcmsSn900
                            {
                                Orig = OrigemMercadoria.Nacional,
                                Csosn = "500",
                            }
                        };
                    }
                    //PIS
                    detCfe.Imposto.Pis.Pis = new ImpostoPisAliq
                    {
                        Cst = "01",
                    };
                    //COFINS
                    detCfe.Imposto.Cofins.Cofins = new ImpostoCofinsAliq
                    {
                        Cst = "01",
                    };

                    detCfe.InfAdProd = "";
                }

                #endregion

                #region Pagamentos
                WSMonitoramento.AddLog("Processando pagamentos...");
                //Fazer um Loop para cada Pagamento

                foreach (var item in TelaInicial.PAGAMENTOS)
                {
                    CFePgtoMp pag = novoCfe.InfCFe.Pagto.Pagamentos.AddNew();
                    if (item.FormaDePagamento.Contains("CARTÃO DE CRÉDITO"))
                    {
                        WSMonitoramento.AddLog($"Enviando pagamento (CREDITO)...");
                        pag.CMp = CodigoMP.CartaodeCredito;
                        if (novoCfe.InfCFe.VersaoDadosEnt.Equals(0.08M) && (pag.CMp == CodigoMP.CartaodeCredito || pag.CMp == CodigoMP.CartaodeDebito)) // Se versão = 0.08 e for Cartão deve informar o Código da Administadora de cartao
                            pag.CAdmC = 999;
                        pag.VMp = Convert.ToDecimal(item.Valor);
                        retornoPagamento = EnviarPagamento(novoCfe, false, pag.VMp, TelaInicial);
                        WSMonitoramento.AddLog($"Pagamento Enviado com Sucesso (CREDITO)...");

                        if (retornoPagamento.EnviouPagamento == false)
                        {
                            retornoMFe.Enviado = false;
                            retornoMFe.CFe = null;
                            retornoMFe.Resposta = "Operação Cancelada problemas ao processar pagamentos";
                        }
                    }
                    else if (item.FormaDePagamento.Contains("CARTÃO DE DÉBITO"))
                    {
                        WSMonitoramento.AddLog("Enviando pagamento (DEBITO)...");
                        pag.CMp = CodigoMP.CartaodeDebito;
                        if (novoCfe.InfCFe.VersaoDadosEnt.Equals(0.08M) && (pag.CMp == CodigoMP.CartaodeCredito || pag.CMp == CodigoMP.CartaodeDebito)) // Se versão = 0.08 e for Cartão deve informar o Código da Administadora de cartao
                            pag.CAdmC = 999;
                        pag.VMp = Convert.ToDecimal(item.Valor);

                        retornoPagamento = EnviarPagamento(novoCfe, false, pag.VMp, TelaInicial);

                        WSMonitoramento.AddLog("Enviando pagamento (DEBITO)...");

                        if (retornoPagamento.EnviouPagamento == false)
                        {
                            retornoMFe.Enviado = false;
                            retornoMFe.CFe = null;
                            retornoMFe.Resposta = "Operação Cancelada problemas ao processar pagamentos";
                        }
                    }
                    else if (item.FormaDePagamento.Contains("DINHEIRO"))
                    {
                        WSMonitoramento.AddLog("Enviando pagamento (DINHEIRO)...");
                        pag.CMp = CodigoMP.Dinheiro;
                        pag.VMp = Convert.ToDecimal(item.Valor);
                        WSMonitoramento.AddLog($"Pagamento Enviado com sucesso (DINHEIRO)...");
                    }
                }

                #endregion

                #region Informações Adicinais
                //novoCfe.InfCFe.Pagto.VTroco = TelaInicial.VENDA.Troco;
                //novoCfe.InfCFe.InfAdic.InfCpl = "Trib. aprox.R$: " + ValorAproxImposTot + "Sendo,Federal e " + ValorTributosNacionalTot + " Estadual." + ValorTributosEstadualTot + ".Lei fed 12741/2012"; //Informações Complementares
                novoCfe.InfCFe.InfAdic.InfCpl = ValorAproxImposTot.ToString("n2");
                #endregion

                #region Autorização
                WSMonitoramento.AddLog("Autorizando cupom...");

                var xml = novoCfe.GetXml();

                RetornosMFE retornoMFE = mfe.AutorizacaoMFE(novoCfe.GetXml());
                var Texto = "Codigo: " + retornoMFE.CodigoRetorno + Environment.NewLine +
                                                  "Descrição: " + retornoMFE.DescricaoRetorno + Environment.NewLine +
                                                  "Chave de Acesso do XML da Venda: " + (mfe.XmlRetornoAutorizacaoMFE != null ? mfe.XmlRetornoAutorizacaoMFE.InfCFe.Id : "");
                string xmlCFe = "";


                WSMonitoramento.AddLog($"{Texto.ToString()}");

                //string xmlnaoautorizado = novoCfe.GetXml();
                //string caminhologo = @"c:\logMFe\"+ "xml" + DateTime.Now.ToString("yyyyMMddHHmmss");
                //if (!Directory.Exists(caminhologo))
                //{
                //    Directory.CreateDirectory(caminhologo);
                //}
                //using (StreamWriter sw = File.CreateText(caminhologo))
                //{
                //    sw.WriteLine(xmlnaoautorizado);
                //}

                if (retornoMFE.Autorizada())
                {
                    WSMonitoramento.AddLog("O cupom foi autorizado!");
                    //Gravar no BD o XML da Venda ou os dados da Nota
                    xmlCFe = mfe.XmlRetornoAutorizacaoMFE.GetXml();
                    //Inserir Informações Documento Fiscal
                    IDMovimentoFiscal = PDV.DAO.DB.Utils.Sequence.GetNextID("MOVIMENTOFISCAL", "IDMOVIMENTOFISCAL");

                    WSMonitoramento.AddLog("Salvando o cupom...");
                    if (!FuncoesMovimentoFiscal.Salvar(new MovimentoFiscal()
                    {
                        IDMovimentoFiscal = IDMovimentoFiscal.Value,
                        Cancelada = 0,
                        cStat = Convert.ToDecimal(retornoMFE.CodigoRetorno),
                        DataRecebimento = DateTime.Now,
                        DataEmissao = DateTime.Now,
                        Emitida = 1,
                        IDVenda = TelaInicial.VENDA.IDVenda,
                        Serie = 99,
                        xMotivo = retornoMFE.DescricaoRetorno,
                        Chave = mfe.XmlRetornoAutorizacaoMFE.InfCFe.Id,
                        XMLEnvio = Encoding.Default.GetBytes(mfe.XmlRetornoAutorizacaoMFE.GetXml()),
                        XMLRetorno = Encoding.Default.GetBytes(retornoMFE.DescricaoRetorno),
                        Numero = mfe.XmlRetornoAutorizacaoMFE.InfCFe.Ide.CNf,
                        Contingencia = 0,
                        TipoDocumento = mfe.XmlRetornoAutorizacaoMFE.InfCFe.Ide.Modelo,
                        Ambiente = (decimal)mfe.XmlRetornoAutorizacaoMFE.InfCFe.Ide.TpAmb

                    }))
                    {
                        throw new Exception("Não foi possível salvar a CF-e.");
                    }
                    CFe cFe = new CFe();
                    cFe = CFe.Load(xmlCFe);
                    //Resposta Fiscal

                    WSMonitoramento.AddLog("Enviando resposta fiscal...");
                    EnviarRespostaFiscal(cFe, TelaInicial);
                    retornoMFe.Enviado = true;
                    retornoMFe.CFe = cFe;
                    retornoMFe.Resposta = Texto;

                    DAO.Entidades.Configuracao configNomeImpressora = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_NOMEIMPRESSORA);
                    var impressora = configNomeImpressora != null ? Encoding.UTF8.GetString(configNomeImpressora.Valor) : string.Empty;
                    if (impressora == null)
                    {
                        WSMonitoramento.AddLog("Sucesso");
                        WSMonitoramento.AddLog("Impressora não configurada...");

                    }
                    else
                    {
                        WSMonitoramento.AddLog("Imprimindo o cupom...");
                        ImpressaoCFe impressaoCFe = new ImpressaoCFe(cFe);
                        impressaoCFe.ImprimirCFe(impressora.ToString());
                        WSMonitoramento.AddLog("Sucesso");
                    }
                }
                else
                {
                    retornoMFe.Enviado = false;
                    retornoMFe.CFe = null;
                    retornoMFe.Resposta = Texto;
                    throw new Exception(Texto);

                }
                #endregion

               return retornoMFe;
            }
            catch (Exception ex)
            {
                WSMonitoramento.AddLog($"Ocorreu um problema ao processar o MFe: {ex.Message}");
                retornoMFe.Enviado = false;
                retornoMFe.CFe = null;
                retornoMFe.Resposta = "Erro ao Processar MFe. Detalhe :" + ex.Message;
               return retornoMFe;
            }
        }
        public void EnviarRespostaFiscal(CFe cFe, GPDV_PainelInicial TelaInicial)
        {
            if (mfe.RetornoVFPE == null || mfe.RetornoVFPE.MfeEnviadoDadosCartao == false || mfe.XmlRetornoAutorizacaoMFE == null)
            {

                //MessageBox.Show("Deve enviar o Comando EnviarPagamento e VerificarStatusValidador(ou Digitar os Dados do Cartão) primeiro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ImpressaoCFe impressaoCFe = new ImpressaoCFe(cFe);
            string txtImpressao = impressaoCFe.ObterTexto();

            string chaveAcessoValidador = "25CFE38D-3B92-46C0-91CA-CFF751A82D3D"; // Essa chave no momento está sendo utilizada tanto para Homologação como Produção para todo mundo
            string chaveAcesso = mfe.XmlRetornoAutorizacaoMFE.InfCFe.Id; //Quando for modelo 59 (MFE) deve informar o CFe na frente da Chave de Acesso
            string NSU = PagamentoProcessado.NSU;//mfe.RetornoVFPE.NSU;
            string autorizacao = PagamentoProcessado.Autorizacao;//mfe.RetornoVFPE.Autorizacao;
            string nomeBandeira = PagamentoProcessado.Bandeira;//mfe.RetornoVFPE.Bandeira;
            string nomeAdquirente = PagamentoProcessado.Adquirente;//mfe.RetornoVFPE.Adquirente;
            string cnpjLoja = "";
            cnpjLoja =Emitente.CNPJ; //CNPJ do comercio
            string numeroNotaFiscal = mfe.XmlRetornoAutorizacaoMFE.InfCFe.Ide.NCFe.ToString();
            string impressaoFiscal = txtImpressao;
            RetornosMFE retornoMFE = mfe.RespostaFiscal(chaveAcessoValidador, chaveAcesso, NSU, autorizacao, nomeBandeira, nomeAdquirente, cnpjLoja, numeroNotaFiscal, impressaoFiscal);
            var Texto = "Codigo: " + retornoMFE.CodigoRetorno + Environment.NewLine +
                                               "Descrição: " + retornoMFE.DescricaoRetorno + Environment.NewLine +
                                               "Retorno VFP-E: idRespostaFiscal = " + mfe.RetornoVFPE == null ? "" : mfe.RetornoVFPE.IdRespostaFiscal.ToString();


            if (retornoMFE.VFeRealizada())
            {
                if (mfe.RetornoVFPE.MfeEnviadoDadosCartao)
                {
                    //Gravar no BD o IDRespostaFiscal
                    Texto = "Granvando Resposta Fiscal no Banco de dados";
                    long idRespostaFiscal = mfe.RetornoVFPE.IdRespostaFiscal;
                    FuncoesVenda.AtualizarRespostaFiscal(TelaInicial.VENDA.IDVenda, idRespostaFiscal.ToString());

                }
                else
                {
                    throw new Exception("Não foi possivel enviar dados do cartão");
                }
            }
            else
            {
                throw new Exception("VPE não realizada");
            }
        }

        public PagamentoMFe PagamentoProcessado;

        public RetornoPagamento EnviarPagamento(CFe cFe, bool Multiforma, decimal Valor, GPDV_PainelInicial TelaInicial)
        {
            try
            {

                PagamentoProcessado = new PagamentoMFe();
                string chaveAcessoValidador = "25CFE38D-3B92-46C0-91CA-CFF751A82D3D"; // Essa chave no momento está sendo utilizada tanto para Homologação como Produção para todo mundo
                string cnpjLoja = Emitente.CNPJ; //CNPJ do comercio
                string cnpjAdquirente = ""; //CNPJ do Adquirente, senão souber ainda qual o Adquirente não informe
                string estabelecimento = ""; //MarchandID do Estabelecimento, senão souber ainda qual não informe
                decimal baseICMS = TelaInicial.VENDA.ValorTotal; //Base de ICMS do Total da Venda
                decimal valorTotalVenda = Valor; //Valor do Total da Venda
                string origemPagamento = "POS" + caixa.SerialPOS; // Campo para informar alguma informação para busca posterior na Sefaz
                string serialPos = caixa.SerialPOS; // Número do Serial POS
                bool habilitarMultiplosPagamentos = Multiforma; //Se tem varios cartões de pagamento informar true
                RetornosMFE retornoMFE = mfe.EnviarPagamento(chaveAcessoValidador, cnpjLoja, cnpjAdquirente, estabelecimento, baseICMS, valorTotalVenda, origemPagamento, serialPos, habilitarMultiplosPagamentos);
                String Texto = "Codigo: " + retornoMFE.CodigoRetorno + Environment.NewLine +
                                                   "Descrição: " + retornoMFE.DescricaoRetorno + Environment.NewLine +
                                                   "Retorno VFP-E: IdPagamento " + (mfe.RetornoVFPE == null ? "" : mfe.RetornoVFPE.IdPagamento + " - idLocal: " + mfe.RetornoVFPE.IdLocal.ToString());

                if (retornoMFE.VFeRealizada())
                {
                    PagamentoMFe pagamentoMFe = new PagamentoMFe();
                    pagamentoMFe.IDVenda = TelaInicial.VENDA.IDVenda;
                    pagamentoMFe.DataPagamento = DateTime.Now;
                    pagamentoMFe.IDPagamento = mfe.RetornoVFPE.IdPagamento;
                    pagamentoMFe.IDLocal = mfe.RetornoVFPE.IdLocal == true ? 1 : 0;
                    pagamentoMFe.ValorCartao = Valor.ToString("n2");

                    if (mfe.RetornoVFPE.IdLocal)
                    {
                        FCA_PagamentoMFe fCA_PagamentoMFe = new FCA_PagamentoMFe(pagamentoMFe);
                        fCA_PagamentoMFe.TopMost = true;
                        fCA_PagamentoMFe.ShowDialog();
                       
                        if (fCA_PagamentoMFe.Cancelado == true)
                        {
                            retornoPagamento.EnviouPagamento = false;
                            PagamentoProcessado = fCA_PagamentoMFe.Pagamento;
                            return retornoPagamento;
                        }
                        else
                        {
                            retornoPagamento.EnviouPagamento = true;
                            return retornoPagamento;
                        }
                    }
                    else
                    {
                        //Gravar no BD o IDPagamento e idLocal
                        int idPagamento = mfe.RetornoVFPE.IdPagamento;
                        bool idLocal = mfe.RetornoVFPE.IdLocal;
                        mfe.RetornoVFPE.MfeEnviadoDadosCartao = true;
                        FCA_PagamentoMFe fCA_PagamentoMFe = new FCA_PagamentoMFe(pagamentoMFe);
                        fCA_PagamentoMFe.ShowDialog();
                        PagamentoProcessado = fCA_PagamentoMFe.Pagamento;
                        if (fCA_PagamentoMFe.Cancelado == true)
                        {
                            retornoPagamento.EnviouPagamento = false;
                            return retornoPagamento;
                        }
                        else
                        {
                            retornoPagamento.EnviouPagamento = true;
                            return retornoPagamento;
                        }
                    }
                }
                else
                {
                    retornoPagamento.EnviouPagamento = false;
                    return retornoPagamento;
                }
            }
            catch (Exception ex)
            {
                retornoPagamento.EnviouPagamento = false;
                return retornoPagamento;
                throw;
            }

        }
        public bool VerificarIntegrador()
        {
            var processoAPI = Process.GetProcessesByName("Integrador");
            if (processoAPI.Length == 0)
            {
                MessageBox.Show("Abra o integrador", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

      

        GPDV_ProgressoMFe formProgresso = null;

      
    }
}
