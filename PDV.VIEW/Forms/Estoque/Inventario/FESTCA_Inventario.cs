using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Estoque.Inventario
{
    public partial class FESTCA_Inventario : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE INVENTÁRIO";
        private DAO.Entidades.Estoque.InventarioEstoque.Inventario Invent = null;
        private DataTable ItensInvent = null;
        private Produto ProdutoSelecionado = null;
        public List<Almoxarifado> Almoxarifados = null;

        DataRow drItemEditar = null;

        public FESTCA_Inventario(DAO.Entidades.Estoque.InventarioEstoque.Inventario _Invent)
        {
            InitializeComponent();
            Invent = _Invent;

            Almoxarifados = FuncoesAlmoxarifado.GetAlmoxarifados();
            ovCMB_Almoxarifado.DataSource = Almoxarifados;
            ovCMB_Almoxarifado.DisplayMember = "descricaoapresentacao";
            ovCMB_Almoxarifado.ValueMember = "idalmoxarifado";
            ovCMB_Almoxarifado.SelectedItem = null;

            ovTXT_Quantidade.AplicaAlteracoes();
            ModoApresentacao(true);
        }

        private void ModoApresentacao(bool ModoListagem)
        {
            if (ModoListagem)
            {
                ovGB_DadosItem.Visible = false;
                ovGB_Itens.Location = new System.Drawing.Point(6, 55);
                ovGB_Itens.Size = new System.Drawing.Size(939, 512);
                ovGB_Itens.Refresh();
            }
            else
            {
                ovGB_DadosItem.Visible = true;
                ovGB_Itens.Location = new System.Drawing.Point(6, 152);
                ovGB_Itens.Size = new System.Drawing.Size(939, 415);
                ovGB_Itens.Refresh();
            }
        }

        private void PreencherTela()
        {
            ovTXT_DataInventairo.Value = Invent.DataInventario;
            CarregarItens(true);
        }

        private void CarregarItens(bool Banco)
        {
            if (Banco)
                ItensInvent = FuncoesInventario.GetItensDoInventario(Invent.IDInventario);

            gridControl1.DataSource = ItensInvent;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            //ovGRD_Itens.RowHeadersVisible = false;
            //int WidthGrid = ovGRD_Itens.Width;
            //foreach (DataGridViewColumn column in ovGRD_Itens.Columns)
            //{
            //    switch (column.Name)
            //    {
            //        case "almoxarifado":
            //            column.DisplayIndex = 0;
            //            column.FillWeight = Convert.ToInt32(WidthGrid * 0.30);
            //            column.HeaderText = "ALMOXARIFADO";
            //            break;
            //        case "produto":
            //            column.DisplayIndex = 1;
            //            column.FillWeight = Convert.ToInt32(WidthGrid * 0.40);
            //            column.HeaderText = "PRODUTO";
            //            break;
            //        case "quantidade":
            //            column.DisplayIndex = 2;
            //            column.FillWeight = Convert.ToInt32(WidthGrid * 0.30);
            //            column.HeaderText = "QUANTIDADE";
            //            break;
            //        default:
            //            column.DisplayIndex = 0;
            //            column.Visible = false;
            //            break;
            //    }
            //}
            gridView1.Columns[0].Caption = "ALMOXARIFADO";
            gridView1.Columns[1].Caption = "PRODUTO";
            gridView1.Columns[2].Caption = "QUANTIDADE";
            gridView1.Columns[3].Visible = false;
            gridView1.Columns[4].Visible = false;
            gridView1.Columns[5].Visible = false;
        }

        private void LimparItem()
        {
            ProdutoSelecionado = null;
            ovTXT_CodProduto.Text = string.Empty;
            ovTXT_Produto.Text = string.Empty;
            ovCMB_Almoxarifado.SelectedItem = null;
            ovTXT_Quantidade.Value = 1;
        }

        private void ValidaItem()
        {
            if (ovCMB_Almoxarifado.SelectedItem == null)
                throw new Exception("Selecione o Almoxarifado.");

            if (ovTXT_Quantidade.Value == 0)
                throw new Exception("A Quantidade deve ser maior que zero.");

            if (ProdutoSelecionado == null)
                throw new Exception("Selecione o Produto.");

            var lQueryProduto = ItensInvent.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted &&
                                                                      Convert.ToDecimal(o["IDPRODUTO"]) == ProdutoSelecionado.IDProduto &&
                                                                      Convert.ToDecimal(o["IDITEMINVENTARIO"]) != (drItemEditar == null ? -1 : Convert.ToDecimal(drItemEditar["IDITEMINVENTARIO"])));
            if (lQueryProduto != null && lQueryProduto.Count() > 0)
                throw new Exception("O Produto selecionado já está adicionado.");
        }

        private void metroButton5_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, System.EventArgs e)
        {
            // Salvar
            try
            {
                PDVControlador.BeginTransaction();

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (FuncoesInventario.GetInventario(Invent.IDInventario) == null)
                {
                    Invent.IDInventario = Sequence.GetNextID("INVENTARIO", "IDINVENTARIO");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesInventario.Salvar(Invent, Op))
                    throw new Exception("Não foi possível salvar o Inventário.");

                DataTable dt = ZeusUtil.GetChanges(ItensInvent, TipoOperacao.INSERT);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                    {
                        var ItemInventario = EntityUtil<DAO.Entidades.Estoque.InventarioEstoque.ItemInventario>.ParseDataRow(dr);
                        ItemInventario.IDInventario = Invent.IDInventario;

                        if (!FuncoesInventario.SalvarItemInventario(ItemInventario, TipoOperacao.INSERT))
                            throw new Exception("Não foi possível salvar os Itens do Inventário.");
                    }

                dt = ZeusUtil.GetChanges(ItensInvent, TipoOperacao.UPDATE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                    {
                        var ItemInventario = EntityUtil<DAO.Entidades.Estoque.InventarioEstoque.ItemInventario>.ParseDataRow(dr);
                        ItemInventario.IDInventario = Invent.IDInventario;

                        if (!FuncoesInventario.SalvarItemInventario(ItemInventario, TipoOperacao.UPDATE))
                            throw new Exception("Não foi possível salvar os Itens do Inventário.");
                    }

                dt = ZeusUtil.GetChanges(ItensInvent, TipoOperacao.DELETE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesInventario.RemoverItemInventario(Convert.ToDecimal(dr["IDITEMINVENTARIO"])))
                            throw new Exception("Não foi possível salvar os Itens do Inventário.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Inventário salvo com sucesso.", NOME_TELA);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

        private void FESTCA_Inventario_Load(object sender, System.EventArgs e)
        {
            ModoApresentacao(false);
            LimparItem();
            drItemEditar = null;
            PreencherTela();
        }

        private void metroButton1_Click(object sender, System.EventArgs e)
        {
            // Novo Item
            ModoApresentacao(false);
            LimparItem();
            drItemEditar = null;
        }

        private void metroButton2_Click(object sender, System.EventArgs e)
        {
            // Editar Item
            Editar();

        }

        private void metroButton3_Click(object sender, System.EventArgs e)
        {
            // Remover Item
            if (MessageBox.Show(this, "Deseja remover o Item selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                decimal IDItemInventario = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDITEMINVENTARIO").ToString());
                ItensInvent.DefaultView.RowFilter = "[IDITEMINVENTARIO] = " + IDItemInventario;
                ItensInvent.DefaultView[0].Delete();
                ItensInvent.DefaultView.RowFilter = string.Empty;
                CarregarItens(false);
            }
        }

        private void metroButton6_Click(object sender, System.EventArgs e)
        {
            // CancelarSalvar
            LimparItem();
            ModoApresentacao(true);
        }

        private void metroButton7_Click(object sender, System.EventArgs e)
        {
            // Salvar Item
            try
            {
                ValidaItem();

                if (drItemEditar == null)
                {
                    DataRow dr = ItensInvent.NewRow();
                    dr["IDITEMINVENTARIO"] = Sequence.GetNextID("ITEMINVENTARIO", "IDITEMINVENTARIO");

                    dr["IDALMOXARIFADO"] = (ovCMB_Almoxarifado.SelectedItem as Almoxarifado).IDAlmoxarifado;
                    dr["ALMOXARIFADO"] = (ovCMB_Almoxarifado.SelectedItem as Almoxarifado).Descricao;

                    dr["IDPRODUTO"] = ProdutoSelecionado.IDProduto;
                    dr["PRODUTO"] = ProdutoSelecionado.Descricao;
                    dr["QUANTIDADE"] = ovTXT_Quantidade.Value;
                    ItensInvent.Rows.Add(dr);
                }
                else
                {
                    ItensInvent.DefaultView.RowFilter = "[IDITEMINVENTARIO] = " + Convert.ToDecimal(drItemEditar["IDITEMINVENTARIO"]);

                    ItensInvent.DefaultView[0].BeginEdit();
                    ItensInvent.DefaultView[0]["IDALMOXARIFADO"] = (ovCMB_Almoxarifado.SelectedItem as Almoxarifado).IDAlmoxarifado;
                    ItensInvent.DefaultView[0]["ALMOXARIFADO"] = (ovCMB_Almoxarifado.SelectedItem as Almoxarifado).Descricao;
                    ItensInvent.DefaultView[0]["IDPRODUTO"] = ProdutoSelecionado.IDProduto;
                    ItensInvent.DefaultView[0]["PRODUTO"] = ProdutoSelecionado.Descricao;
                    ItensInvent.DefaultView[0]["QUANTIDADE"] = ovTXT_Quantidade.Value;
                    ItensInvent.DefaultView[0].EndEdit();
                    ItensInvent.DefaultView.RowFilter = string.Empty;
                }
                LimparItem();
                ModoApresentacao(true);
                CarregarItens(false);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

        private void button2_Click_1(object sender, System.EventArgs e)
        {
            // Seletor de Produto
            FEST_SeletorProduto SeletorProduto = new FEST_SeletorProduto();
            SeletorProduto.ShowDialog(this);
            if (SeletorProduto.drProduto != null)
            {
                ProdutoSelecionado = FuncoesProduto.GetProduto(Convert.ToDecimal(SeletorProduto.drProduto["IDPRODUTO"]));
                ovTXT_CodProduto.Text = ProdutoSelecionado.Codigo;
                ovTXT_Produto.Text = ProdutoSelecionado.Descricao;
            }
        }
       private void Editar()
        {
            try
            {
                decimal IDItemInventario = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDITEMINVENTARIO").ToString());
                ItensInvent.DefaultView.RowFilter = "[IDITEMINVENTARIO] = " + IDItemInventario;
                drItemEditar = ItensInvent.DefaultView[0].Row;
                ItensInvent.DefaultView.RowFilter = string.Empty;

                ovCMB_Almoxarifado.SelectedItem = Almoxarifados.Where(o => o.IDAlmoxarifado == Convert.ToDecimal(drItemEditar["IDALMOXARIFADO"])).FirstOrDefault();
                ProdutoSelecionado = FuncoesProduto.GetProduto(Convert.ToDecimal(drItemEditar["IDPRODUTO"]));
                ovTXT_CodProduto.Text = ProdutoSelecionado.Codigo;
                ovTXT_Produto.Text = ProdutoSelecionado.Descricao;
                ovTXT_Quantidade.Value = Convert.ToDecimal(drItemEditar["QUANTIDADE"]);

                ModoApresentacao(false);
            }
            catch (NullReferenceException)
            {

            }
            
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Editar();
        }
    }
}
