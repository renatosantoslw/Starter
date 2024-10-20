using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.UTIL;
using PDV.VIEW.Forms.Cadastro.MDFe;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas.MDFe
{
    public partial class FCO_Condutor : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE CONDUTOR";
        public FCO_Condutor()
        {
            InitializeComponent();
            Carregar();
        }
        private void Carregar()
        {
            gridControl1.DataSource = FuncoesCondutor.GetCondutores("", "");
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = "CPF";
            gridView1.Columns[2].Caption = "NOME";
            gridView1.Columns[3].Caption = "UF";
            gridView1.Columns[4].Caption = "ATIVO";
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            FCA_Condutor t = new FCA_Condutor(new DAO.Entidades.MDFe.Condutor());
            t.ShowDialog(this);
            Carregar();
            condutormetroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            
            try
            {
                FCA_Condutor t = new FCA_Condutor(FuncoesCondutor.GetCondutor(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCONDUTOR").ToString())));
                t.ShowDialog(this);
                Carregar();
            }
            catch (Exception)
            {
            }
            finally
            {
                condutormetroButton.Enabled = false;
                metroButton3.Enabled = false;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o Condutor selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    if (!FuncoesCondutor.Remover(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCONDUTOR").ToString())))
                        throw new Exception("Não foi possível remover o Condutor.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Carregar();
                condutormetroButton.Enabled = false;
                metroButton3.Enabled = false;
            }
        }

        private void FCO_Condutor_Load(object sender, EventArgs e)
        {
            Carregar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            
            try
            {
                FCA_Condutor t = new FCA_Condutor(FuncoesCondutor.GetCondutor(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCONDUTOR").ToString())));
                t.ShowDialog(this);
                Carregar();
                condutormetroButton.Enabled = false;
                metroButton3.Enabled = false;
            }
            catch (Exception)
            {

            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            condutormetroButton.Enabled = true;
            metroButton3.Enabled = true;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            Carregar();
            condutormetroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
            condutormetroButton.Enabled = false;
            metroButton3.Enabled = false;
        }
    }
}
