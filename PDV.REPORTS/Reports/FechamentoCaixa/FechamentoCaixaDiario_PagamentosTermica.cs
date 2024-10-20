using System;
using PDV.CONTROLER.FuncoesRelatorios;
using System.Data;

namespace PDV.REPORTS.Reports.FechamentoCaixaDiarioTermica
{
    public partial class FechamentoCaixaDiario_PagamentosTermica : DevExpress.XtraReports.UI.XtraReport
    {
        public FechamentoCaixaDiario_PagamentosTermica()
        {
            InitializeComponent();
        }

        private void FechamentoCaixaDiario_PagamentosTermica_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
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
