using FontAwesome.Sharp;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_UnidadeMedida : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE UNIDADE DE MEDIDA";

        private UnidadeMedida Unidade = null;
        public static readonly decimal[] idsMenuItem = { 136 };

        public FCA_UnidadeMedida(UnidadeMedida _Unidade)
        {
            InitializeComponent();
            Unidade = _Unidade;
            PreencherTela();
            
            //icones

            Bitmap bitmapSalvar = IconChar.Save.ToBitmap(Color.SteelBlue, 32);
            Bitmap bitmapCancelar = IconChar.WindowClose.ToBitmap(Color.Firebrick, 32);

            metroButton4.ImageOptions.Image = bitmapSalvar;
            metroButton3.ImageOptions.Image = bitmapCancelar;
        }

        private void PreencherTela()
        {
            ovTXT_Sigla.Text = Unidade.Sigla;
            ovTXT_Descricao.Text = Unidade.Descricao;
        }

        private void ovBTN_Cancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void ovBTN_Salvar_Click(object sender, System.EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_Sigla.Text.Trim()))
                    throw new Exception("Informe a Sigla.");

                if (string.IsNullOrEmpty(ovTXT_Descricao.Text.Trim()))
                    throw new Exception("Informe a Descrição.");


                DAO.Enum.TipoOperacao Op = DAO.Enum.TipoOperacao.UPDATE;
                if (!FuncoesUnidadeMedida.Existe(Unidade.IDUnidadeDeMedida))
                {
                    Unidade.IDUnidadeDeMedida = Sequence.GetNextID("UNIDADEDEMEDIDA", "IDUNIDADEDEMEDIDA");
                    Op = DAO.Enum.TipoOperacao.INSERT;
                }

                Unidade.Sigla = ovTXT_Sigla.Text;
                Unidade.Descricao = ovTXT_Descricao.Text;

                if (!FuncoesUnidadeMedida.Salvar(Unidade, Op))
                    throw new Exception("Não foi possível salvar a Unidade de Medida.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Unidade de Medida salva com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_UnidadeMedida_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}
