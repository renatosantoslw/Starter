using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Util;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_Categorias : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE CATEGORIAS";

        public FCO_Categorias()
        {
            InitializeComponent();
            AtualizarCategorias("", "");
        }

        private void AtualizarCategorias(string Codigo, string Descricao)
        {
            gridControl1.DataSource = FuncoesCategoria.GetCategorias(Codigo, Descricao);
            FormatarGrid();
        }
        
        private void FormatarGrid()
        {
            Grids.FormatGrid(ref gridView1);
        }
        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {
            FCA_Categoria t = new FCA_Categoria(new Categoria());
            t.ShowDialog(this);
            AtualizarCategorias("", "");
            DesabilitarBotoes();
        }

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        {
            Editar();                       
        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover a Categoria selecionada?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                var id = Grids.GetValorDec(gridView1, "IDCATEGORIA");
                try
                {
                    if (!FuncoesCategoria.Remover(id))
                        throw new Exception("Não foi possível remover a Categoria.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizarCategorias("", "");
            }
            DesabilitarBotoes();
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

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
            DesabilitarBotoes();
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizarCategorias("", "");
        }

        private void Editar()
        {
            try
            {
                var id = Grids.GetValorDec(gridView1, "IDCATEGORIA");
                FCA_Categoria t = new FCA_Categoria(FuncoesCategoria.GetCategoria(id));
                t.ShowDialog(this);
                AtualizarCategorias("", "");
                
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
