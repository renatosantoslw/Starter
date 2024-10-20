

using PDV.CONTROLER.FuncoesRelatorios;
using System;

namespace PDV.REPORTS.Reports.FechamentoCaixaDiarioTermica
{
    public partial class FechamentoCaixaDiario_TotaisVendasTermica : DevExpress.XtraReports.UI.XtraReport
    {
        public FechamentoCaixaDiario_TotaisVendasTermica()
        {
            InitializeComponent();
        }

        private void FechamentoCaixaDiario_PagamentosTermica_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {          
          
            var totais = FuncoesFluxoCaixa.GetTotaisVendaDiaMesAno();

            lblTotalDia.Text = FormatarTotal(totais["TOTALDIA"]);
            lblTotalDMes.Text = FormatarTotal(totais["TOTALMES"]);
            lblTotalAno.Text = FormatarTotal(totais["TOTALANO"]);
        }

        private string FormatarTotal(object total) => Convert.ToDecimal(total).ToString("c2");
    }
}
