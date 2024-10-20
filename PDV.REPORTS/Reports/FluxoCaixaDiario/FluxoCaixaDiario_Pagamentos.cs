using System;
using PDV.CONTROLER.FuncoesRelatorios;
using System.Data;

namespace PDV.REPORTS.Reports.FluxoCaixaDiario
{
    public partial class FluxoCaixaDiario_Pagamentos : DevExpress.XtraReports.UI.XtraReport
    {
        public FluxoCaixaDiario_Pagamentos()
        {
            InitializeComponent();
        }

        private void FluxoCaixaDiario_Pagamentos_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataTable dt = FuncoesFluxoCaixa.GetDados_FluxoCaixaPagamentos(Convert.ToDecimal(MasterReport.GetCurrentColumnValue("idvenda")));
            if (dt.Rows.Count == 0)
            {
                e.Cancel = true;
                return;
            }

            dt.TableName = "DADOS";
            ovDS_Dados.Tables.Clear();
            ovDS_Dados.Tables.Add(dt);
        }
    }
}
