using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.Financeiro;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro.Financeiro;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas.Financeiro
{
    public partial class FCO_NaturezaFinanceira : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE NATUREZA FINANCEIRA";
        private DataTable DADOS = null;

        public FCO_NaturezaFinanceira()
        {
            InitializeComponent();
            Carregar();
        }

        private void FCO_NaturezaFinanceira_Load(object sender, System.EventArgs e)
        {
            Carregar();
        }

        private void Carregar()
        {
            DADOS = FuncoesNatureza.GetNaturezas("");
            gridControl1.DataSource = DADOS;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = "DESCRIÇÃO";
            gridView1.Columns[2].Caption = "TIPO";
            gridView1.Columns[3].Caption = "NATUREZA SUPERIOR";
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            new FCA_NaturezaFinanceira(new Natureza()).ShowDialog(this);
            Carregar();
            editarnaturezafinanceirametroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            
            try
            {
                FCA_NaturezaFinanceira Form = new FCA_NaturezaFinanceira(FuncoesNatureza.GetNatureza(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDNATUREZA").ToString())));
                Form.ShowDialog(this);
                Carregar();
                
            }
            catch (Exception)
            {

            }
            finally
            {
                editarnaturezafinanceirametroButton.Enabled = false;
                metroButton3.Enabled = false;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover a Natureza Financeira selecionada?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    if (!FuncoesNatureza.Remover(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDNATUREZA").ToString())))
                        throw new Exception("Não foi possível remover a Natureza Financeira.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Carregar();
            }
            editarnaturezafinanceirametroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            Carregar();
            editarnaturezafinanceirametroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
            editarnaturezafinanceirametroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            editarnaturezafinanceirametroButton.Enabled = true;
            metroButton3.Enabled = true;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            
            try
            {
                FCA_NaturezaFinanceira Form = new FCA_NaturezaFinanceira(FuncoesNatureza.GetNatureza(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDNATUREZA").ToString())));
                Form.ShowDialog(this);
                Carregar();
                editarnaturezafinanceirametroButton.Enabled = false;
                metroButton3.Enabled = false;
            }
            catch (Exception)
            {
            }
        }
    }
}
