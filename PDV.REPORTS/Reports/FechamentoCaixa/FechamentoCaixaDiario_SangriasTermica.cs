using System;
using PDV.CONTROLER.FuncoesRelatorios;
using System.Data;

namespace PDV.REPORTS.Reports.FechamentoCaixaDiarioTermica
{
    public partial class FechamentoCaixaDiario_SangriasTermica : DevExpress.XtraReports.UI.XtraReport
    {
        private decimal IDUSUARIO;
        private decimal IDFLUXOCAIXA;

        public FechamentoCaixaDiario_SangriasTermica(decimal IDUsuario, decimal IDFluxoCaixa)
        {
            InitializeComponent();
            IDUSUARIO = IDUsuario;
            IDFLUXOCAIXA = IDFluxoCaixa;
        }

        private void FechamentoCaixaDiario_PagamentosTermica_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataTable dt = FuncoesFluxoCaixa.GetDados_FluxoCaixaSangrias(IDUSUARIO, IDFLUXOCAIXA);
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
