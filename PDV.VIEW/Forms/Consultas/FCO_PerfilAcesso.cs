using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Util;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_PerfilAcesso : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE PERFIL DE ACESSO";
        public FCO_PerfilAcesso()
        {
            InitializeComponent();
            AtualizaPerfis("");
        }

        private void AtualizaPerfis(string Descricao)
        {
            gridControl1.DataSource = FuncoesPerfilAcesso.GetPerfisAcesso(Descricao);
            FormatarGrid();
        }

        private void FormatarGrid()
        {
            Grids.FormatGrid(ref gridView1);
        }


        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {
            FCA_PerfilAcesso t = new FCA_PerfilAcesso(new PerfilAcesso());
            t.ShowDialog(this);
            AtualizaPerfis("");
            DesabilitarBotoes();
        }

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o Perfil de Acesso selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                var id = Grids.GetValorDec(gridView1, "IDPERFILACESSO");
                try
                {
                    if (!FuncoesPerfilAcesso.Remover(id))
                        throw new Exception("Não foi possível remover o Perfil de Acesso.");
                }
                catch (Exception Ex)
                {
                   MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizaPerfis("");
            }
            DesabilitarBotoes();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
            Editar();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnRemover.Enabled = true;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Editar();            
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizaPerfis("");
            DesabilitarBotoes();
        }

        private void Editar()
        {
            try
            {
                var id = Grids.GetValorDec(gridView1, "IDPERFILACESSO");
                FCA_PerfilAcesso t = new FCA_PerfilAcesso(FuncoesPerfilAcesso.GetPerfil(id));
                t.ShowDialog(this);
                AtualizaPerfis("");
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
