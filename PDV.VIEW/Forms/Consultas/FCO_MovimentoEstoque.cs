using DevExpress.XtraGrid.Views.Grid;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Estoque.Movimento;
using PDV.DAO.Entidades.Estoque.PedidoDeCompra;
using PDV.DAO.Entidades.PDV;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Gerenciamento.DAC;
using PDV.VIEW.Forms.Gerenciamento.DAV;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_MovimentoEstoque : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE MOVIMENTO ESTOQUE";
        private decimal idProduto = -1;
        private Produto produto;
        public FCO_MovimentoEstoque(decimal _idProduto)
        {
            InitializeComponent();
            idProduto = _idProduto;
            produto = FuncoesProduto.GetProduto(idProduto);
            CarregarMovimentos();
        }

        private void CarregarMovimentos()
        {
            gridControl1.DataSource = FuncoesMovimentoEstoque.GetMovimentoEstoquePorIdProduto(idProduto);
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            AjustaHeaderTextGrid();
            gridView1.BestFitColumns();
            
        }

        private void AjustaHeaderTextGrid()
        {
            gridView1.Columns[0].Caption = "PRODUTO";
            gridView1.Columns[1].Caption = "CÓD";
            gridView1.Columns[2].Caption = "DESCRIÇÃO";
            gridView1.Columns[3].Caption = "DOC";
            gridView1.Columns[4].Caption = "DATA";
            gridView1.Columns[5].Caption = "TIPO";
            gridView1.Columns[6].Caption = "QUANTIDADE";
            gridView1.Columns[7].Caption = "ALMOXARIFADO";
            gridView1.Columns[6].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            gridView1.Columns[6].SummaryItem.DisplayFormat = "Saldo Atual: "  + produto.SaldoEstoque ;

        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {
            botaoPesquisarProduto.Enabled = true;
        }

        private void gridControl1_DoubleClick_1(object sender, EventArgs e)
        {
            AbrirPedido();
        }

        private void botaoPesquisarProduto_Click(object sender, EventArgs e)
        {
            AbrirPedido();
        }
        private void AbrirPedido()
        {
            try
            {
                decimal idMovimento = 0;

                try
                {
                    idMovimento = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMOVIMENTOESTOQUE"));
                }
                catch (Exception)
                {

                }
                if (idMovimento > 0)
                {
                    MovimentoEstoque movimentoEstoque = FuncoesMovimentoEstoque.GetMovimentoEstoque(idMovimento);

                    if (movimentoEstoque.IDItemPedidoCompra != null)
                    {
                        decimal idItemPedidoCompra = Convert.ToDecimal(movimentoEstoque.IDItemPedidoCompra);
                        ItemPedidoCompra itemPedidoCompra = FuncoesItemPedidoCompra.GetItemPedidoCompra(idItemPedidoCompra);
                        PedidoCompra pedido = FuncoesPedidoCompra.GetPedidoCompra(itemPedidoCompra.IDPedidoCompra);
                        new PedidoCompraItem(pedido).ShowDialog();

                    }
                    else
                    {
                        ItemVenda itemVenda = FuncoesItemVenda.GetItemVenda(Convert.ToDecimal(movimentoEstoque.IDItemVenda));
                        new PedidoVendaItem(Convert.ToInt16(itemVenda.IDVenda)).ShowDialog();
                    }
                }
            }
            catch (NullReferenceException)
            {

            }
            finally
            {
                botaoPesquisarProduto.Enabled = false;
            }
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView currentView = sender as GridView;
            if (e.Column.FieldName == "tipo")
            {
                string valor;
                try
                {
                    var cellValue = gridView1.GetRowCellValue(e.RowHandle, "tipo");
                    if (cellValue != null)
                        valor = cellValue.ToString();
                    else throw new Exception();
                }
                catch (Exception)
                {
                    valor = "";
                }
                switch (valor)
                {
                    case "SAÍDA":
                        e.Appearance.ForeColor = System.Drawing.Color.Green;
                        break;
                    case "ENTRADA":
                        e.Appearance.ForeColor = System.Drawing.Color.Red;
                        break;
                }

            }
        }
    }
}
