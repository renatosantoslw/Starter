using System;
using PDV.CONTROLER.FuncoesRelatorios;
using System.Data;

namespace PDV.REPORTS.Reports.CarneVendaTermica
{
    public partial class CarneVenda : DevExpress.XtraReports.UI.XtraReport
    {
        private decimal IDVENDA;
        public CarneVenda(decimal IDVenda)
        {
            InitializeComponent();
            IDVENDA = IDVenda;
            ovSR_ListaVencimentos.ReportSource = new CarneVenda_Vencimentos();
        }

        private void ReciboPedidoVenda_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataTable dt = FuncoesPedidoVendaTermica.GetPedidosVendaTermica(IDVENDA);
            dt.TableName = "DADOS";
            ovDS_Dados.Tables.Clear();
            ovDS_Dados.Tables.Add(dt);
        }

        private void xrLabel16_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel16.Text = DateTime.Now.ToString();
        }
    }
}
