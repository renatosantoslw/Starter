using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.Financeiro;
using PDV.UTIL;
using PDV.VIEW.Forms.Cadastro.Financeiro.Modulo;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas.Financeiro.Modulo
{
    public partial class FCOFIN_MovimentacaoBancaria : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE MOVIMENTAÇÃO BANCÁRIA";
        private DataTable DADOS = null;
        public FCOFIN_MovimentacaoBancaria()
        {
            InitializeComponent();
            Carregar();
        }

        private void Carregar()
        {
            DADOS = FuncoesMovimentoBancario.GetMovimentos("");
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
            gridView1.Columns[1].Caption = "DATA MOV.";
            gridView1.Columns[2].Caption = "N. DOC.";
            gridView1.Columns[3].Caption = "SEQ.";
            gridView1.Columns[4].Caption = "CONTA";
            gridView1.Columns[5].Caption = "VALOR";
            gridView1.Columns[6].Caption = "TIPO";
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            new FCAFIN_MovimentacaoBancaria(new MovimentoBancario()).ShowDialog(this);
            Carregar();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
          
            try
            {
                new FCAFIN_MovimentacaoBancaria(FuncoesMovimentoBancario.GetMovimento(Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMOVIMENTOBANCARIO").ToString()))).ShowDialog(this);
                Carregar();
            }
            catch (NullReferenceException)
            {

            }
            finally
            {
                editarmovimentacaometroButton4.Enabled = false;

            }
        }

        private void FCOFIN_MovimentacaoBancaria_Load(object sender, EventArgs e)
        {
            Carregar();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o Movimento Bancário selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    if (!FuncoesMovimentoBancario.Remover(Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMOVIMENTOBANCARIO").ToString())))
                        throw new Exception("Não foi possível remover o Movimento Bancário.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Carregar();
            }
        }

        private void ovGRD_Movimentacao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (gridView1.Columns[e.ColumnIndex].Name)
            {
                case "valor":
                    e.Value = Convert.ToDecimal(e.Value).ToString("c2");
                    break;
            }
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            new FCAFIN_TransferenciaBancaria().ShowDialog(this);
            Carregar();
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            new FCAFIN_Credito().ShowDialog(this); 
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            new FCAFIN_Debito().ShowDialog(this);
        }

       

        private void gridControl1_Click(object sender, EventArgs e)
        {
            editarmovimentacaometroButton4.Enabled = true;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            Carregar();
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            
            try
            {
                new FCAFIN_MovimentacaoBancaria(FuncoesMovimentoBancario.GetMovimento(Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMOVIMENTOBANCARIO").ToString()))).ShowDialog(this);
                Carregar();
            }
            catch (NullReferenceException)
            {

            }
            finally
            {
                editarmovimentacaometroButton4.Enabled = false;

            }
        }
    }
}
