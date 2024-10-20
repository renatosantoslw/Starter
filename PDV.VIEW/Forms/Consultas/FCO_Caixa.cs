using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.Forms.Cadastro;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_Caixa : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE CAIXAS";
        private DataTable Caixas;

        public FCO_Caixa()
        {
            InitializeComponent();
            AtualizarCaixas();
        }
        
        private void FCO_Caixas_Load(object sender, EventArgs e)
        {
            AtualizarCaixas();
        }       

        private void AtualizarCaixas()
        {
            Caixas = FuncoesCaixa.GetTodosCaixas();

            gridControl1.DataSource = Caixas;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaHeaderTextGrid();

        }
        
        private void AjustaHeaderTextGrid()
        {
            try
            {
                gridView1.Columns[0].Visible = false;
                gridView1.Columns[1].Caption = "NUMERO DO CAIXA";
                gridView1.Columns[2].Caption = "SERIAL POS";
                gridView1.Columns[3].Caption = "NOME POS";
                gridView1.Columns[4].Caption = "ATIVO";
                gridView1.Columns[5].Caption = "TIPO DE VENDA";
                gridView1.Columns[6].Caption = "TIPO DE PDV";
            }
            catch (Exception)
            {

            }
          
        }


        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {
            FCA_Caixa t = new FCA_Caixa(new Caixa());
            t.ShowDialog(this);
            AtualizarCaixas();
            editarCaixaMetroButton4.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        {

            try
            {
                decimal IDCaixa = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCAIXA").ToString()));
                FCA_Caixa t = new FCA_Caixa(FuncoesCaixa.GetCaixa(IDCaixa));
                t.ShowDialog(this);
                AtualizarCaixas();
            }
            catch (Exception)
            {


            }
            finally
            {
                editarCaixaMetroButton4.Enabled = false;
                metroButton3.Enabled = false;
            }

        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o saixa selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                decimal IDCaixa = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCAIXA").ToString()));
                try
                {
                    if (!FuncoesCaixa.Remover(IDCaixa))
                        throw new Exception("Não foi possível remover a Caixa.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizarCaixas();
                editarCaixaMetroButton4.Enabled = false;
                metroButton3.Enabled = false;
            }
        }


        private void gridControl1_Click(object sender, EventArgs e)
        {
            editarCaixaMetroButton4.Enabled = true;
            metroButton3.Enabled = true;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                decimal IDCaixa = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCAIXA").ToString()));

              

                FCA_Caixa t = new FCA_Caixa(FuncoesCaixa.GetCaixa(IDCaixa));
                t.ShowDialog(this);
                AtualizarCaixas();
                editarCaixaMetroButton4.Enabled = false;
                metroButton3.Enabled = false;
            }
            catch (Exception)
            {

            }
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
            editarCaixaMetroButton4.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizarCaixas();
            editarCaixaMetroButton4.Enabled = false;
            metroButton3.Enabled = false;
        }
    }
}
