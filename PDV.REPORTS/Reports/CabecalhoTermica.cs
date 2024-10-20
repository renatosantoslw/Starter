using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using PDV.CONTROLER.FuncoesRelatorios;
using System.Data;

namespace PDV.REPORTS.Reports
{
    public partial class CabecalhoTermica : DevExpress.XtraReports.UI.XtraReport
    {
        public CabecalhoTermica()
        {
            InitializeComponent();
        }

        private void xrLabel3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (GetCurrentColumnValue("CNPJ") != null)
                xrLabel3.Text = "CNPJ: " + Convert.ToUInt64(GetCurrentColumnValue("CNPJ")).ToString(@"00\.000\.000\/0000\-00");
        }

        private void xrLabel4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel4.Text = "IE: " + GetCurrentColumnValue("INSCRICAOESTADUAL");
        }

        private void xrLabel6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string Endereco = string.Format("{0} - {1}/{2} - CEP: {3}", GetCurrentColumnValue("BAIRRO"), 
                                                                   GetCurrentColumnValue("MUNICIPIO"), 
                                                                   GetCurrentColumnValue("SIGLA"),
                                                                   GetCurrentColumnValue("CEP"));
            xrLabel6.Text = Endereco;
        }

        private void CabecalhoTermica_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataTable dt = FuncoesCabecalho.GetDadosEmitente();
            dt.TableName = "DADOS";
            ovDS_Dados.Tables.Clear();
            ovDS_Dados.Tables.Add(dt);
        }

        private void xrLabel7_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel7.Text = "" + GetCurrentColumnValue("ULTIMALINHACABECALHO");
        }

        private void xrLabel5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string Endereco = string.Format(" - Fone {0}", GetCurrentColumnValue("FONE"));
            xrLabel5.Text = xrLabel5.Text + Endereco;
        }
    }
}
