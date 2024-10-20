using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using System;
using System.Data;
using System.Windows.Forms;
using PDV.VIEW.Forms.Util;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_IntegracaoFiscal :  DevExpress.XtraEditors.XtraForm

    {
        private string NOME_TELA = "CONSULTA DE INTEGRAÇÃO FISCAL E OPERACIONAL";

        public FCO_IntegracaoFiscal()
        {
            InitializeComponent();
            AtualizaIntegracoes("");
        }

        private void AtualizaIntegracoes(string Descricao)
        {
            gridControl1.DataSource = FuncoesIntegracaoFiscal.GetIntegracoes(Descricao);
            FormatarGrid();
        }

        private void FormatarGrid()
        {
            Grids.FormatGrid(ref gridView1);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            FCA_IntegracaoFiscal t = new FCA_IntegracaoFiscal(new DAO.Entidades.IntegracaoFiscal());
            t.ShowDialog(this);
            AtualizaIntegracoes("");
            DesabilitarBotoes();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover a Integração Fiscal selecionada?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                var id = Grids.GetValorDec(gridView1, "IDINTEGRACAOFISCAL");
                try
                {
                    if (!FuncoesIntegracaoFiscal.Remover(id))
                        throw new Exception("Não foi possível remover a Integração Fiscal.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizaIntegracoes("");
            }

            DesabilitarBotoes();
        }


        private void gridControl1_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = btnRemover.Enabled = true;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizaIntegracoes("");
            DesabilitarBotoes();
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

        private void Editar()
        {
            try
            {
                var id = Grids.GetValorDec(gridView1, "IDINTEGRACAOFISCAL");
                FCA_IntegracaoFiscal t = new FCA_IntegracaoFiscal(FuncoesIntegracaoFiscal.GetIntegracao(id));
                t.ShowDialog(this);
                AtualizaIntegracoes("");
                
                
            }
            catch (NullReferenceException)
            {
            }
            finally
            {
                DesabilitarBotoes();
            }
        }

        private void DesabilitarBotoes()
        {
            btnEditar.Enabled = btnRemover.Enabled = false;
        }
    }
}
