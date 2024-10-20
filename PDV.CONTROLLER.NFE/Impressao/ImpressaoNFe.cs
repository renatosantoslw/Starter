using DFe.Utils;
using FastReport.DevComponents.DotNetBar;
using NFe.Classes.Servicos.Recepcao;
using NFe.Danfe.Fast.NFe;
using NFe.Servicos;
using NFe.Utils.NFe;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.NFE.Configuracao;
using PDV.DAO.Custom;
using PDV.DAO.Entidades;
using System.Text;

namespace PDV.CONTROLLER.NFE.Impressao
{
    public class ImpressaoNFe : IConfigNFe
    {
        public RetornoImpressaoNFe ImprimirNFe(decimal IDMovimentoFiscal, NFe.Classes.NFe nFe = null)
        {
            if (nFe != null && IDMovimentoFiscal == 0)
            {
                var nfe = nFe;
                nfe.infNFe.Id = "NFe23200532007843000106550010000000681000000000";
                nfe.infNFe.emit.xNome = "NOTA FISCAL SEM VALOR FISCAL - DEMOSNTRATIVO";

                var nfeProc = new NFe.Classes.nfeProc()
                {
                    NFe = nfe,
                    protNFe = null,
                    versao = null
                };
                RetornoImpressaoNFe Retorno = new RetornoImpressaoNFe();

                Retorno.danfe = new DanfeFrNfe(nfeProc, CONFIG_NFe.ConfiguracaoDanfeNFe, "Sistema Comercial - Software");
                if (nfeProc != null)
                    Retorno.danfe = new DanfeFrNfe(nfeProc, CONFIG_NFe.ConfiguracaoDanfeNFe, "Sistema Comercial - Software");

                DAO.Entidades.Configuracao configExibirDialogo = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_EXIBIRCAIXADIALOGO_NFE);
                if (configExibirDialogo != null && "1".Equals(Encoding.UTF8.GetString(configExibirDialogo.Valor)))
                    Retorno.isVisualizar = true;
                else
                {
                    DAO.Entidades.Configuracao configNomeImpressora = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_NOMEIMPRESSORA_NFE);
                    Retorno.isVisualizar = false;
                    Retorno.NomeImpressora = configNomeImpressora != null ? Encoding.UTF8.GetString(configNomeImpressora.Valor) : string.Empty;
                    Retorno.isCaixaDialogo = configExibirDialogo == null ? false : "1".Equals(Encoding.UTF8.GetString(configExibirDialogo.Valor));
                }
                return Retorno;
            }
            else
            {
                var nfe = new NFe.Classes.NFe().CarregarDeXmlString(FuncoesMovimentoFiscal.GetXMLRetorno(IDMovimentoFiscal));
                //var proc = new NFe.Classes.nfeProc().CarregarDeXmlString(FuncoesMovimentoFiscal.GetXMLRetorno(IDMovimentoFiscal));
                //retEnviNFe retEnvi = null;

                var servicoNFe = new ServicosNFe(CONFIG_NFe.CfgServico);
               // var retornoConsulta = servicoNFe.NfeConsultaProtocolo(nfe.infNFe.Id.ToString().Replace("NFe", "").Trim());


                //if (!string.IsNullOrEmpty(FuncoesMovimentoFiscal.GetXMLRetorno(IDMovimentoFiscal)))
                //  retEnvi = FuncoesXml.XmlStringParaClasse<retEnviNFe>(FuncoesMovimentoFiscal.GetXMLRetorno(IDMovimentoFiscal));

                //var nfeProc = new NFe.Classes.nfeProc()
                //{
                //    NFe = nfe,
                //    protNFe = retornoConsulta.Retorno.protNFe,
                //    versao = retornoConsulta.Retorno.versao
                //};
                MovimentoFiscal movimento = FuncoesMovimentoFiscal.GetMovimento(IDMovimentoFiscal);
                //movimento.XMLEnvio = Encoding.Default.GetBytes(nfeProc.ObterXmlString());

                RetornoImpressaoNFe Retorno = new RetornoImpressaoNFe();

                Retorno.danfe = new DanfeFrNfe(nfe, CONFIG_NFe.ConfiguracaoDanfeNFe, "Sistema Comercial-  Software");
                //if (nfeProc != null)
                //    Retorno.danfe = new DanfeFrNfe(nfeProc, CONFIG_NFe.ConfiguracaoDanfeNFe, "Sistema Comercial -  Software");

                DAO.Entidades.Configuracao configExibirDialogo = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_EXIBIRCAIXADIALOGO_NFE);
                if (configExibirDialogo != null && "1".Equals(Encoding.UTF8.GetString(configExibirDialogo.Valor)))
                    Retorno.isVisualizar = true;
                else
                {
                    DAO.Entidades.Configuracao configNomeImpressora = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_NOMEIMPRESSORA_NFE);
                    Retorno.isVisualizar = false;
                    Retorno.NomeImpressora = configNomeImpressora != null ? Encoding.UTF8.GetString(configNomeImpressora.Valor) : string.Empty;
                    Retorno.isCaixaDialogo = configExibirDialogo == null ? false : "1".Equals(Encoding.UTF8.GetString(configExibirDialogo.Valor));
                }
                return Retorno;
            }
        }

        public ConfiguracaoNFe RetornaConfiguracaoNFe()
        {
            return CONFIG_NFe;
        }
    }

    public class RetornoImpressaoNFe
    {
        public DanfeFrNfe danfe { get; set; }
        public bool isVisualizar { get; set; }
        public bool isCaixaDialogo { get; set; }
        public string NomeImpressora { get; set; }
        public bool DuasLinhas { get; set; }
    }
}
