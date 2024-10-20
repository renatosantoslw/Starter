using PDV.CONTROLER.FuncoesRelatorios;
using System;
using System.Data;

namespace PDV.REPORTS.Reports.PedidoVendaTermica
{
    public partial class ReciboPedidoVenda_Itens : DevExpress.XtraReports.UI.XtraReport
    {
        public ReciboPedidoVenda_Itens()
        {
            InitializeComponent();
        }

        private void ReciboPedidoVenda_Itens_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataTable dt = FuncoesPedidoVendaTermica.GetItensPedidoVendaTermica(Convert.ToDecimal(MasterReport.GetCurrentColumnValue("IDVENDA")));
            dt.TableName = "DADOS";
            ovDS_Dados.Tables.Clear();
            ovDS_Dados.Tables.Add(dt);
        }
    }
}
