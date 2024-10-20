using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.Financeiro;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro.Financeiro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas.Financeiro
{
    public partial class FCO_ContaCobranca : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE CONTA COBRANÇA";
        private DataTable DADOS = null;
        public FCO_ContaCobranca()
        {
            InitializeComponent();
            Carregar();
        }

        private void FCO_ContaCobranca_Load(object sender, EventArgs e)
        {
            Carregar();
        }

        private void Carregar()
        {
            DADOS = FuncoesContaCobranca.GetContasCobrancas("", "","");
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
            gridView1.Columns[1].Caption = "CEDENTE";
            gridView1.Columns[2].Caption = "NOSSO NÚMERO";
            gridView1.Columns[3].Caption = "CONTA BANCÁRIA";
            gridView1.Columns[4].Caption = "ATIVO";
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            Carregar();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            new FCA_ContaCobranca(new ContaCobranca()).ShowDialog(this);
            Carregar();
            editarContaCobrançametroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            
           
            try
            {
                FCA_ContaCobranca Form = new FCA_ContaCobranca(FuncoesContaCobranca.GetContaCobranca(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCONTABANCARIA").ToString())));
                Form.ShowDialog(this);
                Carregar();
            }
            catch (Exception)
            {

            }
            finally
            {
                editarContaCobrançametroButton.Enabled = false;
                metroButton3.Enabled = false;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover a Conta Cobrança selecionada?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    if (!FuncoesContaCobranca.Remover(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCONTABANCARIA").ToString())))
                        throw new Exception("Não foi possível remover a Conta Cobrança.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Carregar();

            }
            editarContaCobrançametroButton.Enabled = false;
            metroButton3.Enabled = false;
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
            editarContaCobrançametroButton.Enabled = true;
            metroButton3.Enabled = true;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            Carregar();
            editarContaCobrançametroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
            editarContaCobrançametroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            
            try
            {
                FCA_ContaCobranca Form = new FCA_ContaCobranca(FuncoesContaCobranca.GetContaCobranca(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCONTACOBRANCA").ToString())));
                Form.ShowDialog(this);
                Carregar();
                editarContaCobrançametroButton.Enabled = false;
                metroButton3.Enabled = false;
            }
            catch (Exception)
            {
            }
        }
    }
}
