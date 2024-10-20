using System;
using PDV.CONTROLER.FuncoesRelatorios;
using System.Data;

namespace PDV.REPORTS.Reports.PedidoVendaComandaTermica
{
    public partial class ReciboPedidoVendaComanda : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable dtVenda = null;
        DataTable dtItens = null;
        public ReciboPedidoVendaComanda(DataTable Venda, DataTable Itens)
        {
            InitializeComponent();
            dtVenda = Venda;
            dtItens = Itens;
            ovSR_Itens.ReportSource = new ReciboPedidoVendaComanda_Itens(Itens);
        }

        private void xrLabel14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (GetCurrentColumnValue("codigocomanda") != null && GetCurrentColumnValue("descricaocomanda") != null)
                xrLabel14.Text = string.Format("{0} - {1}", GetCurrentColumnValue("codigocomanda"), GetCurrentColumnValue("descricaocomanda"));
        }

        private void ReciboPedidoVendaComanda_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            dtVenda.TableName = "DADOS";
            ovDS_Dados.Tables.Clear();
            ovDS_Dados.Tables.Add(dtVenda);
        }

        private void xrLabel8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel8.Text = DateTime.Now.ToString();
        }
    }
}
