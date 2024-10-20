using System;
using PDV.CONTROLER.FuncoesRelatorios;
using System.Data;
using PDV.DAO.Entidades.PDV;
using PDV.CONTROLER.Funcoes;
using System.Collections.Generic;
using PDV.DAO.Entidades;
using System.Linq;
using DevExpress.Internal;

namespace PDV.REPORTS.Reports.FechamentoCaixaDiarioTermica
{
    public partial class FechamentoCaixaDiario_DadosDeConferenciaTermica : DevExpress.XtraReports.UI.XtraReport
    { 
        private decimal IDFLUXOCAIXA;


        public FechamentoCaixaDiario_DadosDeConferenciaTermica(decimal IDFluxoCaixa)
        {
            InitializeComponent();
            IDFLUXOCAIXA = IDFluxoCaixa;
        }

        private void FechamentoCaixaDiario_PagamentosTermica_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var dt = FuncoesConferenciaCaixaPDV.GetConferenciasPorFluxo(IDFLUXOCAIXA);

            Totais(dt);
        }

        private void Totais(DataTable dt)
        {
            decimal calculado = 0, digitado = 0, diferenca = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];
                calculado += Convert.ToDecimal(dr["valorcalculado"]);
                digitado += Convert.ToDecimal(dr["valordigitado"]);

                //diferenca += Math.Abs(Convert.ToDecimal(dr["diferenca"]));

                diferenca += Convert.ToDecimal(dr["diferenca"]);

                dr["diferenca"] = Convert.ToDecimal(dr["diferenca"]);
            }

            dt.TableName = "DADOS";

            ovDS_Dados.Tables.Clear();
            ovDS_Dados.Tables.Add(dt);

            lblTotalCalculado.Text = calculado.ToString("c2");
            lblTotalDigitado.Text = digitado.ToString("c2");
            lblTotalDiferenca.Text = diferenca.ToString("c2");
        }
    }
}
