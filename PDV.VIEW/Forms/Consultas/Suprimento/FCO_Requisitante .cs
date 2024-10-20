using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.UTIL;
using PDV.VIEW.Forms.Cadastro.Suprimentos;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas.Suprimento
{
    public partial class FCO_Requisitante : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA REQUISITANTE";
        private DataTable REQUISITANTES = null;
        public FCO_Requisitante()
        {
            InitializeComponent();
        }

        private void AtualizaRequisitantes()
        {
            REQUISITANTES = FuncoesRequisitante.GetRequisitantes("");
            gridControl1.DataSource = REQUISITANTES;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {

            gridView1.Columns[0].Caption = "NOME";
            gridView1.Columns[1].Caption = "CENTRO DE CUSTO";
            gridView1.Columns[2].Visible = false;
            gridView1.Columns[3].Visible = false;
        }



        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {
            FCA_Requisitante t = new FCA_Requisitante(new Requisitante());
            t.ShowDialog(this);
            AtualizaRequisitantes();
            editarrequisitantemetroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        {
            try
            {

                FCA_Requisitante t = new FCA_Requisitante(FuncoesRequisitante.GetRequisitante(Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDREQUISITANTE").ToString())));
                t.ShowDialog(this);
                AtualizaRequisitantes();
            }
            catch (Exception)
            {

            }
            finally
            {
                editarrequisitantemetroButton.Enabled = false;
                metroButton3.Enabled = false;
            }
        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o Requisitante selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    if (!FuncoesRequisitante.Remover(Convert.ToDecimal(Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDREQUISITANTE").ToString()))))
                        throw new Exception("Não foi possível remover o Requisitante.");
                }
                catch (Exception Ex)
                {
                   MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizaRequisitantes();
            }
            editarrequisitantemetroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void FCO_Requisitante_Load(object sender, EventArgs e)
        {
            AtualizaRequisitantes();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            editarrequisitantemetroButton.Enabled = true;
            metroButton3.Enabled = true;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            

            try
            {
                FCA_Requisitante t = new FCA_Requisitante(FuncoesRequisitante.GetRequisitante(Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDREQUISITANTE").ToString())));
                t.ShowDialog(this);
                AtualizaRequisitantes();
                editarrequisitantemetroButton.Enabled = false;
                metroButton3.Enabled = false;
            }
            catch (Exception)
            {

            }
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
            editarrequisitantemetroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizaRequisitantes();
            editarrequisitantemetroButton.Enabled = false;
            metroButton3.Enabled = false;
        }
    }
}
