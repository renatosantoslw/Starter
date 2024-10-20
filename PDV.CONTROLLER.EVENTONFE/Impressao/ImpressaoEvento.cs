using DFe.Utils;
using NFe.Classes.Servicos.Consulta;
using NFe.Danfe.Base.NFe;
using NFe.Danfe.Fast.NFe;
using NFe.Servicos;
using NFe.Utils.NFe;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.EVENTONFE.Classes;
using PDV.DAO.Custom;
using PDV.DAO.Entidades;
using System.Text;
using PDV.CONTROLLER.NFE.Configuracao;

namespace PDV.CONTROLLER.EVENTONFE.Impressao
{
    public class ImpressaoEvento
    {
        public  RetornoEventoImpressao ImprimirEvento(byte[] Logomarca, decimal IDMovimentoFiscal, decimal IDEventoNFe)
        {
            try
            {
                EventoNFe Evento = FuncoesEventoNFe.GetEventoNFe(IDEventoNFe);
                MovimentoFiscal Movimento = FuncoesMovimentoFiscal.GetMovimento(IDMovimentoFiscal);


                var nfe = new NFe.Classes.NFe().CarregarDeXmlString(FuncoesMovimentoFiscal.GetXMLRetorno(IDMovimentoFiscal));


                //if (!string.IsNullOrEmpty(FuncoesMovimentoFiscal.GetXMLRetorno(IDMovimentoFiscal)))
                //  retEnvi = FuncoesXml.XmlStringParaClasse<retEnviNFe>(FuncoesMovimentoFiscal.GetXMLRetorno(IDMovimentoFiscal));

                var nfeProc = new NFe.Classes.nfeProc()
                {
                    NFe = nfe,
                    protNFe = null,//retornoConsulta.Retorno.protNFe,
                    versao = nfe.infNFe.versao
                };

                var texto = Encoding.Default.GetString(Evento.XML);

                RetornoEventoImpressao Retorno = new RetornoEventoImpressao();
                Retorno.Danfe = new DanfeFrEvento(nfeProc, FuncoesXml.XmlStringParaClasse<procEventoNFe>(Encoding.Default.GetString(Evento.XML)), new ConfiguracaoDanfeNfe(Logomarca, true, Movimento.Cancelada == 1), "DUE ERP -  Software");


                Configuracao configExibirDialogo = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_EXIBIRCAIXADIALOGO_NFE);
                if (configExibirDialogo != null && "1".Equals(Encoding.Default.GetString(configExibirDialogo.Valor)))
                    Retorno.isVisualizar = true;
                else
                {
                    Configuracao configNomeImpressora = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_NOMEIMPRESSORA_NFE);
                    Retorno.isVisualizar = false;
                    Retorno.NomeImpressora = configNomeImpressora != null ? Encoding.UTF8.GetString(configNomeImpressora.Valor) : string.Empty;
                    Retorno.isCaixaDialogo = configExibirDialogo == null ? false : "1".Equals(Encoding.UTF8.GetString(configExibirDialogo.Valor));
                }
                return Retorno;
            }
            catch (System.Exception tf)
            {

                return null;
            }
           
        }
    }
}
