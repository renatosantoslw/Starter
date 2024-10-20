using System;
using PDV.CONTROLER.FuncoesRelatorios;
using System.Data;

namespace PDV.REPORTS.Reports
{
    public partial class Cabecalho : DevExpress.XtraReports.UI.XtraReport
    {
        public Cabecalho(string UsuarioEmissao)
        {
            InitializeComponent();

            ovTXT_UsuarioEmissao.Text = UsuarioEmissao;

            DataTable dt = FuncoesCabecalho.GetDadosEmitente();
            dt.TableName = "DADOS";
            ovDS_Dados.Tables.Clear();
            ovDS_Dados.Tables.Add(dt);
        }

        private void xrLabel3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (GetCurrentColumnValue("cnpj") != null)
                if (!string.IsNullOrEmpty(GetCurrentColumnValue("cnpj").ToString()))
                    xrLabel3.Text = Convert.ToUInt64(GetCurrentColumnValue("cnpj")).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}
