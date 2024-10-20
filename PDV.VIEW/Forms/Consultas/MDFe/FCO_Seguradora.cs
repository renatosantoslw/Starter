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
    public partial class FCO_Seguradora : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE SEGURADORA";
        public FCO_Seguradora()
        {
            InitializeComponent();
            Carregar();
        }

        private void FCO_Seguradora_Load(object sender, EventArgs e)
        {
            Carregar();
        }

        private void Carregar()
        {
            gridControl1.DataSource = FuncoesSeguradora.GetSeguradoras("", "");
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = "CNPJ";
            gridView1.Columns[2].Caption = "DESCRIÇÃO";
            gridView1.Columns[3].Caption = "ATIVO";
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            FCA_Seguradora t = new FCA_Seguradora(new DAO.Entidades.MDFe.Seguradora());
            t.ShowDialog(this);
            Carregar();
            editarseguradorametroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            
            try
            {
                FCA_Seguradora t = new FCA_Seguradora(FuncoesSeguradora.GetSeguradora(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDSEGURADORA").ToString())));
                t.ShowDialog(this);
                Carregar();
            }
            catch (Exception)
            {

            }
            finally
            {
                editarseguradorametroButton.Enabled = false;
                metroButton3.Enabled = false;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover a Seguradora selecionada?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    if (!FuncoesSeguradora.Remover(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDSEGURADORA").ToString())))
                        throw new Exception("Não foi possível remover a Seguradora.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Carregar();
                editarseguradorametroButton.Enabled = false;
                metroButton3.Enabled = false;
            }
        }


        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
            editarseguradorametroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            Carregar();
            editarseguradorametroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            editarseguradorametroButton.Enabled = true;
            metroButton3.Enabled = true;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            
            try
            {
                FCA_Seguradora t = new FCA_Seguradora(FuncoesSeguradora.GetSeguradora(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDSEGURADORA").ToString())));
                t.ShowDialog(this);
                Carregar();
                editarseguradorametroButton.Enabled = false;
                metroButton3.Enabled = false;
            }
            catch (Exception)
            {

            }
        }
    }
}
