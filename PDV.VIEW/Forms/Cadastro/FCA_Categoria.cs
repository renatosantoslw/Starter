using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_Categoria : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE CATEGORIAS";
        private Categoria CATEGORIA = null;
        internal static readonly decimal[] idsMenuItem = { 18 };

        public FCA_Categoria(Categoria _Categoria)
        {
            InitializeComponent();
            CATEGORIA = _Categoria;
            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Codigo.Text = string.IsNullOrEmpty(CATEGORIA.Codigo) ? ZeusUtil.GetProximoCodigo("CATEGORIA", "CODIGO").ToString() : CATEGORIA.Codigo;
            ovTXT_Descricao.Text = CATEGORIA.Descricao;
            imageCategoriaPictureBox.Image = FuncoesProduto.ConvertByteToImage(CATEGORIA.Imagem);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ovBTN_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_Codigo.Text.Trim()))
                    throw new Exception("Informe o Código.");

                if (string.IsNullOrEmpty(ovTXT_Descricao.Text.Trim()))
                    throw new Exception("Informe a Descrição.");

                CATEGORIA.Codigo = ovTXT_Codigo.Text;
                CATEGORIA.Descricao = ovTXT_Descricao.Text;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesCategoria.Existe(CATEGORIA.IDCategoria))
                {
                    CATEGORIA.IDCategoria = Sequence.GetNextID("CATEGORIA", "IDCATEGORIA");
                    Op = TipoOperacao.INSERT;
                }

                CATEGORIA.Imagem = FuncoesProduto.ConvertImageToByte(imageCategoriaPictureBox.Image);

                if (!FuncoesCategoria.Salvar(CATEGORIA, Op))
                    throw new Exception("Não foi possível salvar a Categoria.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Categoria salva com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog _with1 = openFileDialog1;

                _with1.Filter = ("Image Files |*.png; *.bmp; *.jpg;*.jpeg; *.gif;");
                _with1.FilterIndex = 4;
                //Resetar the file name
                openFileDialog1.FileName = "";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    imageCategoriaPictureBox.Image = Image.FromFile(openFileDialog1.FileName);

                }
                string anexo = Convert.ToString(openFileDialog1.FileName);
                if (anexo != string.Empty)
                {
                   // linkTextEdit.Text = FuncoesProduto.AdicionarArquivo((System.IO.FileStream)openFileDialog1.OpenFile()).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_Categoria_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void FCA_Categoria_Load(object sender, EventArgs e)
        {

        }
    }
}
