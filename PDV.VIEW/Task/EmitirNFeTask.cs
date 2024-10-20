using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.NFE.Impressao;
using PDV.CONTROLLER.NFE.Transmissao;
using PDV.CONTROLLER.NFE.Util;
using PDV.VIEW.App_Context;
using PDV.VIEW.FRENTECAIXA.Forms.PDV;
using PDV.VIEW.FRENTECAIXA.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.VIEW.Task
{
    public class EmitirNFeTask : AsyncTask<TaskParams, string, TaskResult>
    {
        public override TaskResult DoInBackGround(TaskParams param)
        {
            try
            {
                decimal idnfe = param.GetDecimal("idnfe");
                decimal idmovimentofiscal = param.GetDecimal("idmovimentofiscal");
                /* Caso Tenha a Série e Númeração, Usar a Existente, caso não existe, gerar uma nova numeração e usar a série configurada. */
                DAO.Entidades.NFe.NFe Nf = FuncoesNFe.GetNFe(idnfe);
                int NumeroNFe = idmovimentofiscal > 0 ? Convert.ToInt32(FuncoesMovimentoFiscal.GetMovimento(idmovimentofiscal).Numero) : PDV.DAO.DB.Utils.Sequence.GetNextID(Contexto.CONFIGURACAO_SERIE.NomeSequenceNFe);
                EventosNFe Ev = new EventosNFe(Nf, Nf.Serie, NumeroNFe, idmovimentofiscal);
                Ev.CaminhoSolution = Contexto.CaminhoSolution;
                UpdateProgress("Emitindo NFe");
                RetornoTransmissaoNFe Retorno = Ev.TransmitirNFe();
                if(Retorno.isAutorizada)
                {
                    UpdateProgress("NFe AUtorizada com sucesso!");

                    

                }
                else
                {
                    UpdateProgress(""+ Retorno.MotivoErro);
                }




                return new TaskResult()
                    .SetValue("Result", Retorno.isAutorizada)
                    .SetValue("Msg", Retorno.MotivoErro)
                .SetValue("idmovimentofiscal",Retorno.IDMovimentoFiscal);

            }
            catch (Exception Ex)
            {
                UpdateProgress($"Erro: \n {Ex.Message}");
                return new TaskResult()
                     .SetValue("Result", false)
                     .SetValue("Msg", Ex.Message);
            }
        }

        public override void OnPostExecute(TaskResult result)
        {
            gPDV_ProgressoNFe.Close();
        }

        GPDV_ProgressoNFe gPDV_ProgressoNFe;

        public override void OnPreExecute()
        {
            gPDV_ProgressoNFe = new GPDV_ProgressoNFe();
            gPDV_ProgressoNFe.TopMost = false;
            gPDV_ProgressoNFe.Show();
        }

        public override void OnProgressUpdate(string progress)
        {
            gPDV_ProgressoNFe.PublicaProgresso(progress);
        }
    }
}
