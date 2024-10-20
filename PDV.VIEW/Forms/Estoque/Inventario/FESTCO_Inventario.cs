using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.UTIL;
using PDV.UTIL.InventarioUtil;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Util;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Estoque.Inventario
{
    public partial class FESTCO_Inventario : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE INVENTÁRIO";
        private DataTable DADOS = null;
        public FESTCO_Inventario()
        {
            InitializeComponent();
            Limpar();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            ovTXT_EmissaoInicio.Value = DateTime.Now.Date.AddMonths(-1);
            ovTXT_EmissaoFim.Value = DateTime.Now.Date;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Carregar();
        }

        private void FESTCO_Inventario_Load(object sender, EventArgs e)
        {
            Carregar();
        }

        private void Carregar()
        {
            DADOS = FuncoesInventario.GetInventarios(ovTXT_EmissaoInicio.Value.Date, ovTXT_EmissaoFim.Value.Date);
            gridControl1.DataSource = DADOS;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            gridView1.Columns[0].Caption = "CÓDIGO";
            gridView1.Columns[1].Caption = "DATA DO INVENTÁRIO";
        }

        private void ovGRD_Inventarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (gridView1.Columns[e.ColumnIndex].Name)
            {
                case "datainventario":
                    e.Value = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
                    break;
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            new FESTCA_Inventario(new DAO.Entidades.Estoque.InventarioEstoque.Inventario()).ShowDialog();
            Carregar();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            
            try
            {
                new FESTCA_Inventario(FuncoesInventario.GetInventario(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDITEMINVENTARIO").ToString()))).ShowDialog();
                Carregar();
            }
            catch (Exception)
            {

            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o Inventário selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    if (!FuncoesInventario.RemoverInventario(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDITEMINVENTARIO").ToString())))
                        throw new Exception("Não foi possível remover o Inventário.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Carregar();
            }
        }

        private void ovBTN_Processar_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();
                if (MessageBox.Show(this, "Deseja processar o Inventário selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    var id = Grids.GetValorDec(gridView1, "IDINVENTARIO");
                    DataTable dt = FuncoesInventario.GetItensDoInventario(id);
                    InventarioUtil.Processar(dt);
                    MessageBox.Show(this, "Processamento efetuado com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PDVControlador.Commit();
                
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void gridControl1_Click(object sender, EventArgs e)
        {
            metroButton4.Enabled = true;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                new FESTCA_Inventario(FuncoesInventario.GetInventario(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDINVENTARIO").ToString()))).ShowDialog();
                Carregar();
            }
            catch (Exception)
            {

            }
            
        }
    }
}
