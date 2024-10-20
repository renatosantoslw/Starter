using System;
using PDV.CONTROLER.FuncoesRelatorios;
using System.Data;
using PDV.CONTROLER.Funcoes;

namespace PDV.REPORTS.Reports.FechamentoCaixaDiarioTermica
{
    public partial class FechamentoCaixaDiario_SuprimentoDeCaixaTermica : DevExpress.XtraReports.UI.XtraReport
    {
        private decimal IDFLUXOCAIXA;

        public FechamentoCaixaDiario_SuprimentoDeCaixaTermica(decimal IDFluxoCaixa)
        {
            InitializeComponent();
            IDFLUXOCAIXA = IDFluxoCaixa;
        }

        private void FechamentoCaixaDiario_PagamentosTermica_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataTable dt = FuncoesSuprimentoCaixa.GetSuprimentoPorFluxoDeCaixa(IDFLUXOCAIXA);
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
