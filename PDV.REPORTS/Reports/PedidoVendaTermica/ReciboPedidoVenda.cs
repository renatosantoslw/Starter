using System;
using PDV.CONTROLER.FuncoesRelatorios;
using System.Data;
using PDV.DAO.Entidades.PDV;
using System.Collections.Generic;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;

namespace PDV.REPORTS.Reports.PedidoVendaTermica
{
    public partial class ReciboPedidoVenda : DevExpress.XtraReports.UI.XtraReport
    {
        private decimal IDVENDA;
        public ReciboPedidoVenda(decimal IDVenda)
        {
            InitializeComponent();
            IDVENDA = IDVenda;
            
        }

        private void ReciboPedidoVenda_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataTable dt = FuncoesPedidoVendaTermica.GetPedidosVendaTermica(IDVENDA);
            List<DuplicataNFCe> duplicataNFCe = FuncoesItemDuplicataNFCe.GetPagamentosPorVenda(IDVENDA);
            String Pagamento = "";
            foreach (var item in duplicataNFCe)
            {
                FormaDePagamento formaDePagamento = FuncoesFormaDePagamento.GetFormaDePagamento(item.IDFormaDePagamento);
                Pagamento += $@"{formaDePagamento.Descricao.PadRight(20)}  {item.Valor.ToString("c2")}
                                ";
            }
            xrLabelPagamentos.Text = Pagamento;


            ovSR_ListaItens.ReportSource = new ReciboPedidoVenda_Itens();
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
