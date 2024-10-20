using System.Data;
using PDV.CONTROLER.FuncoesRelatorios;

namespace PDV.REPORTS.Reports.PedidoVendaComandaTermica
{
    public partial class ReciboPedidoVendaComanda_Itens : DevExpress.XtraReports.UI.XtraReport
    {
        private DataTable dtItens = null;

        public ReciboPedidoVendaComanda_Itens(DataTable Itens)
        {
            InitializeComponent();
            dtItens = Itens;
        }

        private void ReciboPedidoVendaTermica_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            dtItens.TableName = "DADOS";
            ovDS_Dados.Tables.Clear();
            ovDS_Dados.Tables.Add(dtItens);
        }
    }
}
