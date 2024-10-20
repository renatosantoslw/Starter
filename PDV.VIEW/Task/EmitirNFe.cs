using NFe.Utils.NFe;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.NFE.Impressao;
using PDV.CONTROLLER.NFE.Transmissao;
using PDV.CONTROLLER.NFE.Util;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Vendas.NFe;
using PDV.VIEW.FRENTECAIXA.Forms.PDV;
using PDV.VIEW.FRENTECAIXA.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDV.DAO.DB.Utils;
using PDV.DAO.Enum;

namespace PDV.VIEW.Task
{
    public class EmitirNFe 
    {
        public int NumeroNFe { get; set; }
        public EmitirNFe(decimal idnfe, decimal idMovimentoFiscal, bool preview)
        {
            try
            {
                if (preview)
                {
                    DAO.Entidades.NFe.NFe Nf = FuncoesNFe.GetNFe(idnfe);
                    NumeroNFe = 1002;
                    EventosNFe Ev = new EventosNFe(Nf, Nf.Serie, NumeroNFe, idMovimentoFiscal);
                    Ev.CaminhoSolution = Contexto.CaminhoSolution;
                    NFe.Classes.NFe nfe = Ev.PreviewXml();
                    viewXMLcs viewXMLcs = new viewXMLcs(nfe);
                    viewXMLcs.ShowDialog();

                }
                else
                {

                    DAO.Entidades.NFe.NFe Nf = FuncoesNFe.GetNFe(idnfe);
                    var numerosd = Contexto.CONFIGURACAO_SERIE.NomeSequenceNFe;
                    var emitente = FuncoesEmitente.GetEmitente();
                    if (idMovimentoFiscal > 0)
                    {
                        var movimentoFiscal = FuncoesMovimentoFiscal.GetMovimento(idMovimentoFiscal);
                        NumeroNFe = Convert.ToInt32(movimentoFiscal.Numero);
                    }
                    else
                    {
                        NumeroNFe = Convert.ToInt32(emitente.ProximoNumeroNFe);
                        emitente.ProximoNumeroNFe++;
                    }

                    EventosNFe Ev = new EventosNFe(Nf, Nf.Serie, NumeroNFe, idMovimentoFiscal);
                    Ev.CaminhoSolution = Contexto.CaminhoSolution;
                    RetornoTransmissaoNFe Retorno = Ev.TransmitirNFe();

                    if (Ev.NFeIsValida)
                        FuncoesEmitente.SalvarEmitente(emitente, TipoOperacao.UPDATE);

                    if (Retorno.isAutorizada)
                    {
                        RetornoImpressaoNFe impressao = new ImpressaoNFe()
                        { CaminhoSolution = Contexto.CaminhoSolution }.ImprimirNFe(Retorno.IDMovimentoFiscal);
                        if (impressao.isVisualizar)
                            impressao.danfe.Visualizar();
                        else
                            impressao.danfe.Imprimir(impressao.isCaixaDialogo, impressao.NomeImpressora);

                    }
                    else
                    {
                        MessageBox.Show(Retorno.MotivoErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception Ex)
            {
                var msg = Ex.Message;
                if (Ex.InnerException != null)
                    msg += " " + Ex.InnerException.Message;
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
