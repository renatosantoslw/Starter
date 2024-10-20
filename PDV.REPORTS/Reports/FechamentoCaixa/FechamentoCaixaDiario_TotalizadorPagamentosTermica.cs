using System;
using System.Data;
using PDV.CONTROLER.FuncoesRelatorios;

namespace PDV.REPORTS.Reports.FechamentoCaixaDiarioTermica
{
    public partial class FechamentoCaixaDiario_TotalizadorPagamentosTermica : DevExpress.XtraReports.UI.XtraReport
    {
        private decimal IDUSUARIO;
        private decimal IDFLUXOCAIXA;

        public FechamentoCaixaDiario_TotalizadorPagamentosTermica(decimal IDUsuario, decimal IDFluxoCaixa)
        {
            InitializeComponent();
            IDUSUARIO = IDUsuario;
            IDFLUXOCAIXA = IDFluxoCaixa;
        }

        private void FluxoCaixaDiario_TotalizadorPagamentos_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataTable dt = FuncoesFluxoCaixa.GetDados_FluxoCaixaPagamentosTotalizador(IDUSUARIO, IDFLUXOCAIXA);
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
