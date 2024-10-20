using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.Estoque.Transferencia;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Estoque.Transferencia
{
    public partial class FCA_Transferencia : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "TRANSFERÊNCIA DE ESTOQUE";
        private TransferenciaEstoque Transferencia = null;
        private DataTable ITENS = null;

        public FCA_Transferencia()
        {
            InitializeComponent();
            metroTabControl2.SelectedTab = metroTabPage5;
            Transferencia = new TransferenciaEstoque();

            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Transferencia.Value = Transferencia.DataTransferencia;
            ovTXT_Observacao.Text = Transferencia.Observacao;
            ITENS = FuncoesItemTransferenciaEstoque.GetItensPorTransferencia(Transferencia.IDTransferenciaEstoque);
            gridControl1.DataSource = ITENS;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
          
            gridView1.Columns[0].Caption = "CÓDIGO DO PRODUTO";
            gridView1.Columns[1].Caption = "QUANTIDADE";
            gridView1.Columns[2].Caption = "PRODUTO";
            gridView1.Columns[3].Caption = "ALMOX. ENTRADA";
            gridView1.Columns[4].Caption = "ALMOX. SAIDA";
            gridView1.Columns[5].Visible = false;
            gridView1.Columns[6].Visible = false;
            gridView1.Columns[7].Visible = false;
            gridView1.Columns[8].Visible = false;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click_1(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (ITENS.DefaultView.Count == 0)
                    throw new Exception("Nenhum ITEM foi encontrado para transferir.");

                Transferencia.IDTransferenciaEstoque = Sequence.GetNextID("TRANSFERENCIAESTOQUE", "IDTRANSFERENCIAESTOQUE");
                Transferencia.DataTransferencia = ovTXT_Transferencia.Value;
                Transferencia.Observacao = ovTXT_Observacao.Text;

                if (!FuncoesTransferenciaEstoque.Salvar(Transferencia, DAO.Enum.TipoOperacao.INSERT))
                    throw new Exception("Não foi possível salvar a Transferência de Estoque.");

                // Itens..
                DataTable dtOp = ZeusUtil.GetChanges(ITENS, DAO.Enum.TipoOperacao.INSERT);
                if (dtOp != null)
                    foreach (DataRow dr in dtOp.Rows)
                    {
                        ItemTransferenciaEstoque Item = EntityUtil<ItemTransferenciaEstoque>.ParseDataRow(dr);
                        Item.IDTransferenciaEstoque = Transferencia.IDTransferenciaEstoque;
                        if (!FuncoesItemTransferenciaEstoque.Salvar(Item, DAO.Enum.TipoOperacao.INSERT))
                            throw new Exception("Não foi possível salvar os Itens da Transferência de Estoque.");

                        if (!FuncoesMovimentoEstoque.Salvar(new DAO.Entidades.Estoque.Movimento.MovimentoEstoque
                        {
                            IDMovimentoEstoque = Sequence.GetNextID("MOVIMENTOESTOQUE", "IDMOVIMENTOESTOQUE"),
                            DataMovimento = DateTime.Now,
                            IDAlmoxarifado = Item.IDAlmoxarifadoEntrada,
                            IDItemTransferenciaEstoque = Item.IDItemTransferenciaEstoque,
                            IDProduto = Item.IDProduto,
                            Quantidade = Item.Quantidade,
                            Tipo = 1,
                            IDProdutoNFe = null,
                            IDItemInventario = null,
                            IDItemNFeEntrada = null,
                            IDItemVenda = null
                        }))
                            throw new Exception("Não foi possível salvar o Movimento de Estoque.");

                        // Movimento Estoque
                        if (!FuncoesMovimentoEstoque.Salvar(new DAO.Entidades.Estoque.Movimento.MovimentoEstoque
                        {
                            IDMovimentoEstoque = Sequence.GetNextID("MOVIMENTOESTOQUE", "IDMOVIMENTOESTOQUE"),
                            DataMovimento = DateTime.Now,
                            IDAlmoxarifado = Item.IDAlmoxarifadoSaida,
                            IDItemTransferenciaEstoque = Item.IDItemTransferenciaEstoque,
                            IDProduto = Item.IDProduto,
                            Quantidade = Item.Quantidade,
                            Tipo = 0,
                            IDProdutoNFe = null,
                            IDItemInventario = null,
                            IDItemNFeEntrada = null,
                            IDItemVenda = null
                        }))
                            throw new Exception("Não foi possível salvar o Movimento de Estoque.");
                    }

                dtOp = ZeusUtil.GetChanges(ITENS, DAO.Enum.TipoOperacao.DELETE);
                if (dtOp != null)
                    foreach (DataRow dr in dtOp.Rows)
                        if (!FuncoesItemTransferenciaEstoque.Remover(Convert.ToDecimal(dr["IDITEMTRANSFERENCIAESTOQUE"])))
                            throw new Exception("Não foi possível salvar os Itens da Transferência de Estoque.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Transferência efetuada com sucesso.", NOME_TELA);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            FCA_ItemTransferencia Form = new FCA_ItemTransferencia(new ItemTransferenciaEstoque(), null);
            Form.ShowDialog(this);
            if (Form.Salvou)
            {
                foreach (DataRow dr in Form.ITENS.Rows)
                {
                    if (Convert.ToDecimal(dr["QUANTIDADE"]) == 0)
                        continue;

                    DataRow drItem = ITENS.NewRow();
                    drItem["CODIGOPRODUTO"] = dr["CODIGO"];
                    drItem["QUANTIDADE"] = dr["QUANTIDADE"];
                    drItem["PRODUTO"] = dr["PRODUTO"];
                    drItem["ALMOXARIFADOENTRADA"] = FuncoesAlmoxarifado.GetAlmoxarifado(Form.Item.IDAlmoxarifadoEntrada).Descricao;
                    drItem["ALMOXARIFADOSAIDA"] = FuncoesAlmoxarifado.GetAlmoxarifado(Form.Item.IDAlmoxarifadoSaida).Descricao;
                    drItem["IDALMOXARIFADOENTRADA"] = Form.Item.IDAlmoxarifadoEntrada;
                    drItem["IDALMOXARIFADOSAIDA"] = Form.Item.IDAlmoxarifadoSaida;
                    drItem["IDITEMTRANSFERENCIAESTOQUE"] = Sequence.GetNextID("ITEMTRANSFERENCIAESTOQUE", "IDITEMTRANSFERENCIAESTOQUE");
                    drItem["IDPRODUTO"] = dr["IDPRODUTO"];
                    ITENS.Rows.Add(drItem);
                }
            }
            gridControl1.DataSource = ITENS;
            AjustaHeaderTextGrid();
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            // Editar
            try
            {
                decimal IDItemTransferenciaEstoque =decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDITEMTRANFERENCIAESTOQUE").ToString());
                ITENS.DefaultView.RowFilter = "[IDITEMTRANSFERENCIAESTOQUE] = " + IDItemTransferenciaEstoque;

                DataTable dt = FuncoesItemTransferenciaEstoque.GetProdutosComSaldoEmAlmoxarifado(Convert.ToDecimal(ITENS.DefaultView[0]["IDALMOXARIFADOENTRADA"]));
                dt = dt.AsEnumerable().Where(o => Convert.ToDecimal(o["IDPRODUTO"]) == Convert.ToDecimal(ITENS.DefaultView[0]["IDPRODUTO"])).CopyToDataTable();
                dt.Rows[0]["QUANTIDADE"] = Convert.ToDecimal(ITENS.DefaultView[0]["QUANTIDADE"]);

                FCA_ItemTransferencia Form = new FCA_ItemTransferencia(EntityUtil<ItemTransferenciaEstoque>.ParseDataRow(ITENS.DefaultView[0].Row), dt);
                Form.ShowDialog(this);
                if (Form.Salvou)
                {
                    ITENS.DefaultView.BeginInit();
                    ITENS.DefaultView[0]["QUANTIDADE"] = Form.ITENS.Rows[0]["QUANTIDADE"];
                    ITENS.DefaultView.EndInit();
                }

                ITENS.DefaultView.RowFilter = string.Empty;
                gridControl1.DataSource = ITENS;
                AjustaHeaderTextGrid();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            // Remover
            if (MessageBox.Show(this, "Deseja remover o Item selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                decimal IDItemTransferenciaEstoque = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDITEMTRANFERENCIAESTOQUE").ToString());
                ITENS.DefaultView.RowFilter = "[IDITEMTRANSFERENCIAESTOQUE] = " + IDItemTransferenciaEstoque;
                ITENS.DefaultView[0].Delete();
                ITENS.DefaultView.RowFilter = string.Empty;

                gridControl1.DataSource = ITENS;
                AjustaHeaderTextGrid();
            }
        }


        private void gridControl1_Click(object sender, EventArgs e)
        {
            // Editar
            try
            {
                decimal IDItemTransferenciaEstoque = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDITEMTRANFERENCIAESTOQUE").ToString());
                ITENS.DefaultView.RowFilter = "[IDITEMTRANSFERENCIAESTOQUE] = " + IDItemTransferenciaEstoque;

                DataTable dt = FuncoesItemTransferenciaEstoque.GetProdutosComSaldoEmAlmoxarifado(Convert.ToDecimal(ITENS.DefaultView[0]["IDALMOXARIFADOENTRADA"]));
                dt = dt.AsEnumerable().Where(o => Convert.ToDecimal(o["IDPRODUTO"]) == Convert.ToDecimal(ITENS.DefaultView[0]["IDPRODUTO"])).CopyToDataTable();
                dt.Rows[0]["QUANTIDADE"] = Convert.ToDecimal(ITENS.DefaultView[0]["QUANTIDADE"]);

                FCA_ItemTransferencia Form = new FCA_ItemTransferencia(EntityUtil<ItemTransferenciaEstoque>.ParseDataRow(ITENS.DefaultView[0].Row), dt);
                Form.ShowDialog(this);
                if (Form.Salvou)
                {
                    ITENS.DefaultView.BeginInit();
                    ITENS.DefaultView[0]["QUANTIDADE"] = Form.ITENS.Rows[0]["QUANTIDADE"];
                    ITENS.DefaultView.EndInit();
                }

                ITENS.DefaultView.RowFilter = string.Empty;
                gridControl1.DataSource = ITENS;
                AjustaHeaderTextGrid();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            PreencherTela();
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {

        }

        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {

        }
    }
}
