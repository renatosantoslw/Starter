using DevExpress.XtraEditors;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_Comanda : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE COMANDAS";

        public FCO_Comanda()
        {
            InitializeComponent();
            AtualizarComandas("", "");
        }

        private void AtualizarComandas(string Codigo, string Descricao)
        {
            gridControl1.DataSource = FuncoesComanda.GetComandas(Codigo, Descricao);
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = "CÓDIGO";
            gridView1.Columns[2].Caption = "DESCRIÇÃO";
        }


        private void FCO_Comanda_Load(object sender, EventArgs e)
        {
            AtualizarComandas("","");
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            AtualizarComandas("", "");
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            FCA_Comanda t = new FCA_Comanda(new DAO.Entidades.Comanda());
            t.ShowDialog(this);
            AtualizarComandas("", "");
            editarcomanadametroButton4.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            
            try
            {
                decimal IDComanda = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCOMANDA").ToString());
                FCA_Comanda t = new FCA_Comanda(FuncoesComanda.GetComanda(IDComanda));
                t.ShowDialog(this);
                AtualizarComandas("", "");
            }
            catch (Exception)
            {
            }
            finally
            {
                editarcomanadametroButton4.Enabled = false;
                metroButton3.Enabled = false;

            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover a Comanda selecionada?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                decimal IDComanda = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCOMANDA").ToString());
                try
                {
                    if (!FuncoesComanda.Remover(IDComanda))
                        throw new Exception("Não foi possível remover a Comanda.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizarComandas("", "");
            }
            editarcomanadametroButton4.Enabled = false;
            metroButton3.Enabled = false;
        }


        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            
            try
            {
                decimal IDComanda = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCOMANDA").ToString());
                FCA_Comanda t = new FCA_Comanda(FuncoesComanda.GetComanda(IDComanda));
                t.ShowDialog(this);
                AtualizarComandas("", "");
                editarcomanadametroButton4.Enabled = false;
                metroButton3.Enabled = false;
            }
            catch (Exception)
            {
            }
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizarComandas("", "");
            editarcomanadametroButton4.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            editarcomanadametroButton4.Enabled = true;
            metroButton3.Enabled = true;
        }
        private Comanda COMANDA = null;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
             string motivo = XtraInputBox.Show("Informe a quantidade de comandas", "Inserir Comanda em Lote", "");

            int quantidade = 0;

            try
            {
                quantidade = int.Parse(motivo);
                PDVControlador.BeginTransaction();
                FuncoesComanda.RemoverTudo();
            }
            catch (Exception ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this,"A quantidade tem que ser número", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(quantidade > 0)
            {
                COMANDA = new Comanda();
                for (int i = 0; i < quantidade; i++)
                {
                    int ComandaNumero = i + 1;
                  
                    COMANDA.Codigo = ComandaNumero.ToString();
                    COMANDA.Descricao = ComandaNumero.ToString();
                    COMANDA.IDComanda = ComandaNumero;
                    if (!FuncoesComanda.Salvar(COMANDA, DAO.Enum.TipoOperacao.INSERT))
                        throw new Exception("Não foi possível salvar a Comanda.");
                }
                PDVControlador.Commit();
                MessageBox.Show(this, "Lote de Comanda salva com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarComandas("", "");
                editarcomanadametroButton4.Enabled = false;
                metroButton3.Enabled = false;
            }
        }
    }
}
