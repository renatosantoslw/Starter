using DevExpress.XtraGrid.Views.Grid;
using MetroFramework;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.Estoque.Movimento;
using PDV.DAO.Entidades.PDV;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Gerenciamento;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms.PDV.Menu
{
    public partial class GPDV_EncerramentoCaixa : Form
    {
        private DataTable table;
        public decimal IDFluxo { get; set; }
        public GPDV_EncerramentoCaixa(decimal fluxo)
        {
            InitializeComponent();
            IDFluxo = fluxo;
            carregarDAV();
        }
        private void carregarDAV()
        {
            table = FuncoesVenda.GetVendas(DateTime.Now,DateTime.Now,1, IDFluxo);
            gridControl1.DataSource = table;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            AjustarColumas();
            gridView1.BestFitColumns();
        }
        public void AjustarColumas()
        {
            //Ajustar Nome
            gridView1.Columns[0].Caption = "CUPOM";
            gridView1.Columns[1].Caption = "DATA EMISSÃO";
            gridView1.Columns[2].Caption = "HORA";
            gridView1.Columns[2].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns[2].DisplayFormat.FormatString = "HH:mm";
            gridView1.Columns[3].Caption = "OPERADOR";
            gridView1.Columns[4].Caption = "CPF / CNPJ";
            gridView1.Columns[5].Caption = "CLIENTE";
            gridView1.Columns[6].Caption = "OPERAÇÃO";
            gridView1.Columns[7].Caption = "COMANDA";
            gridView1.Columns[8].Caption = "ITENS";
            gridView1.Columns[9].Caption = "TOTAL";
            gridView1.Columns[9].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[9].DisplayFormat.FormatString = "n2";
            gridView1.Columns[10].Caption = "IDCOMANDA";
            gridView1.Columns[11].Caption = "IDCLIENTE";
            gridView1.Columns[12].Caption = "IDUSUARIO";
            gridView1.Columns[13].Caption = "STATUS";
            //Esconder Dados
            gridView1.Columns[7].Visible = false;
            gridView1.Columns[8].Visible = false;
            gridView1.Columns[10].Visible = false;
            gridView1.Columns[11].Visible = false;
            gridView1.Columns[12].Visible = false;

            //Formatando Total
            gridView1.Columns[9].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;

            gridView1.Columns[9].SummaryItem.DisplayFormat = "Total R$ : {0:n2}";
            gridView1.Columns[0].SummaryItem.DisplayFormat = "Registros : {0}";

        }
        int IDVenda = 0;
        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
             IDVenda = Convert.ToInt16(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0].FieldName));
            carregarItens(IDVenda);
            carregarPagamentos(IDVenda);
            cancelarMetroButton.Enabled = true;
        }

        private void carregarItens(int id)
        {
            var itemVenda = FuncoesItemVenda.GetItensVenda(id);
            ItensVendagridControl.DataSource = itemVenda;
            ItemVendagridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            ItemVendagridView.OptionsBehavior.Editable = false;
            ItensVendagridControl.ForceInitialize();
            ItemVendagridView.OptionsView.ColumnAutoWidth = false;
            ItemVendagridView.OptionsView.ShowAutoFilterRow = true;
            ItemVendagridView.OptionsView.ShowFooter = true;
            ItemVendagridView.BestFitColumns();
        }
        private void carregarPagamentos(int id)
        {
            var itemVenda = FuncoesItemDuplicataNFCe.GetPagamentosPorVenda(id);
            pagamentoVendaGridControl.DataSource = itemVenda;
            pagamentoVendaGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            ItemVendagridView.OptionsBehavior.Editable = false;
            pagamentoVendaGridControl.ForceInitialize();
            pagamentoVendaGridView.OptionsView.ColumnAutoWidth = false;
            pagamentoVendaGridView.OptionsView.ShowAutoFilterRow = true;
            pagamentoVendaGridView.OptionsView.ShowFooter = true;
            pagamentoVendaGridView.BestFitColumns();
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            carregarDAV();
        }

        private void cancelarMetroButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Confirma o cancelamento do Cupom", "DAV", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    PDVControlador.BeginTransaction();
                    if (!FuncoesContaReceber.CancelarContaReceberDocumento(IDVenda, Contexto.USUARIOLOGADO))
                        throw new Exception($"Não foi possível salvar as contas a receber da Venda {IDVenda}.");
                    var itemVenda = FuncoesItemVenda.GetItensVenda(IDVenda);

                    foreach (ItemVenda Item in itemVenda)
                    {
                        if (!FuncoesItemVenda.SalvarItemVenda(Item))
                        {
                            throw new Exception($"Não foi possível salvar os Itens de Venda da Venda {IDVenda}.");
                        }

                        // [Processar Movimento de Estoque]
                        if (!FuncoesMovimentoEstoque.Salvar(new MovimentoEstoque
                        {
                            IDMovimentoEstoque = DAO.DB.Utils.Sequence.GetNextID("MOVIMENTOESTOQUE", "IDMOVIMENTOESTOQUE"),
                            DataMovimento = DateTime.Now,
                            IDAlmoxarifado = FuncoesProduto.GetProduto(Item.IDProduto).IDAlmoxarifadoEntrada,
                            IDItemVenda = Item.IDItemVenda,
                            IDProduto = Item.IDProduto,
                            Quantidade = Item.Quantidade,
                            Tipo = 0,
                            Descricao = "Cancelamento de Venda",
                            IDItemInventario = null,
                            IDItemNFeEntrada = null,
                            IDItemTransferenciaEstoque = null,
                            IDProdutoNFe = null
                        }))
                        {
                            throw new Exception($"Não foi possível salvar o Movimento de Estoque da Venda {IDVenda}.");
                        }

                    }
                    //Salvar data de faturamento
                    DAO.Entidades.PDV.Venda venda = FuncoesVenda.GetVenda(IDVenda);
                    venda.DataFaturamento = new DateTime(0001, 01, 01);
                    if (!FuncoesVenda.SalvarVenda(venda))
                        throw new Exception($"Não foi possível salvar a data de faturamento da venda {IDVenda}");

                    PDVControlador.Commit();

                }
                catch (Exception ex)
                {
                    PDVControlador.Rollback();
                    MessageBox.Show(this, "Erro ao cancelar pedido : " + ex.Message, "Pedido de Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void imprimirDAVSimpleButton_Click(object sender, EventArgs e)
        {
            GER_NotasFiscaisConsumidor gER_NotasFiscaisConsumidor = new GER_NotasFiscaisConsumidor();
            gER_NotasFiscaisConsumidor.EmitirCupomGerencial(IDVenda);
            cancelarMetroButton.Enabled = false;
        }
    }
}
