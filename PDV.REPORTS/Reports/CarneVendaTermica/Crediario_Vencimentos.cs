using PDV.CONTROLER.Funcoes;
using System;
using System.Data;

namespace PDV.REPORTS.Reports.CarneVendaTermica
{
    public partial class Crediario_Vencimentos : DevExpress.XtraReports.UI.XtraReport
    {
        public Crediario_Vencimentos()
        {
            InitializeComponent();
        }

        private void ReciboPedidoVenda_Itens_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataTable dt = FuncoesVenda.GetVencimentosParaCrediario(Convert.ToDecimal(MasterReport.GetCurrentColumnValue("idvenda")));
            dt.TableName = "DADOS";
            ovDS_Dados.Tables.Clear();
            ovDS_Dados.Tables.Add(dt);
        }
    }
}
