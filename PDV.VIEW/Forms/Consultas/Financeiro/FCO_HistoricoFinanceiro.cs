using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.Financeiro;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro.Financeiro;
using PDV.VIEW.Forms.Util;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas.Financeiro
{
    public partial class FCO_HistoricoFinanceiro : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE HISTÓRICO FINANCEIRO";
        private DataTable DADOS = null;

        public FCO_HistoricoFinanceiro()
        {
            InitializeComponent();
            Atualizar();
        }

        private void FCO_HistoricoFinanceiro_Load(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void Atualizar()
        {
            DADOS = FuncoesHistoricoFinanceiro.GetHistoricosFinanceiros("");
            gridControl1.DataSource = DADOS;
            FormatarGrid();
        }

        private void FormatarGrid()
        {
            Grids.FormatGrid(ref gridView1);
        }


        private void metroButton2_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            new FCA_HistoricoFinanceiro(new HistoricoFinanceiro()).ShowDialog(this);
            Atualizar();

            DesabilitarBotoes();            
        }

        private void DesabilitarBotoes()
        {
            btnEditar.Enabled = false;
            btnRemover.Enabled = false;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {           
            
            Editar();

        }

        private void Editar()
        {
            try
            {
                FCA_HistoricoFinanceiro t = new FCA_HistoricoFinanceiro(Grids.GetValorDec(gridView1, "IDHISTORICOFINANCEIRO"));
                t.ShowDialog(this);
                Atualizar();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            DesabilitarBotoes();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o Histórico Financeiro selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    if (!FuncoesHistoricoFinanceiro.Remover(Grids.GetValorDec(gridView1, "IDHISTORICOFINANCEIRO")))
                        throw new Exception("Não foi possível remover o Histórico Financeiro.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Atualizar();
                DesabilitarBotoes();
            }
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
            DesabilitarBotoes();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Editar();
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            Atualizar();
            DesabilitarBotoes();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = btnRemover.Enabled = true;
        }
    }
}
