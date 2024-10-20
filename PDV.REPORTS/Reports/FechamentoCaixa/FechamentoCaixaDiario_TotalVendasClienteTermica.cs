using PDV.CONTROLER.FuncoesRelatorios;

namespace PDV.REPORTS.Reports.FechamentoCaixaDiarioTermica
{
    public partial class FechamentoCaixaDiario_TotalVendasPorClienteTermica : DevExpress.XtraReports.UI.XtraReport
    {
        private decimal IDFLUXOCAIXA;

        public FechamentoCaixaDiario_TotalVendasPorClienteTermica(decimal idFluxoCaixa)
        {
            InitializeComponent();
            IDFLUXOCAIXA = idFluxoCaixa;
        }

        private void FluxoCaixaDiario_TotalizadorPagamentos_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var dt = FuncoesFluxoCaixa.GetDados_TotalVendasPorCliente(IDFLUXOCAIXA);
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
