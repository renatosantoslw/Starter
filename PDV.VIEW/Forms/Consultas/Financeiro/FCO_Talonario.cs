using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.Financeiro;
using PDV.UTIL;
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
    public partial class FCO_Talonario : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE TALONÁRIO";
        private DataTable TALONARIOS = null;
        public FCO_Talonario()
        {
            InitializeComponent();
            Carregar("", "");

        }
        private void FCO_Talonario_Load(object sender, EventArgs e)
        {
            Carregar("","");
        }

        private void Carregar(string Numero, string Conta)
        {
            TALONARIOS = FuncoesTalonario.GetTalonarios(Numero, Conta);
            gridControl1.DataSource = TALONARIOS;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaHeaderTextGrid();
        
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Carregar("", "");
        }

        private void AjustaHeaderTextGrid()
        {

            gridView1.Columns[0].Caption = "CONTA BANCÁRIA";
            gridView1.Columns[1].Caption = "NÚMERO";
            gridView1.Columns[2].Caption = "INÍCIO";
            gridView1.Columns[3].Caption = "FIM";
            gridView1.Columns[4].Caption = "ATIVO";
            gridView1.Columns[5].Visible = false;
            gridView1.Columns[6].Visible = false;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            new FCA_Talonario(new Talonario()).ShowDialog(this);
            Carregar("", "");
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            
            try
            {
                FCA_Talonario Form = new FCA_Talonario(FuncoesTalonario.GetTalonario(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDTALONARIO").ToString())));
                Form.ShowDialog(this);
                Carregar("", "");
            }
            catch (Exception)
            {

            }
            finally
            {
                editarTalonariometroButton.Enabled = false;
                metroButton3.Enabled = false;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o Centro de Custo selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    if (!FuncoesTalonario.Remover(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDTALONARIO").ToString())))
                        throw new Exception("Não foi possível remover o Talonário.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Carregar("", "");
                
            }
            editarTalonariometroButton.Enabled = false;
            metroButton3.Enabled = false;
        }


        private void gridControl1_Click(object sender, EventArgs e)
        {
            editarTalonariometroButton.Enabled = true;
            metroButton3.Enabled = true;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            
            try
            {
                FCA_Talonario Form = new FCA_Talonario(FuncoesTalonario.GetTalonario(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDTALONARIO").ToString())));
                Form.ShowDialog(this);
                Carregar("", "");
                editarTalonariometroButton.Enabled = false;
                metroButton3.Enabled = false;            
            }
            catch (Exception)
            {
            }
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
            editarTalonariometroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            Carregar("", "");
            editarTalonariometroButton.Enabled = false;
            metroButton3.Enabled = false;
        }
    }
    
}
