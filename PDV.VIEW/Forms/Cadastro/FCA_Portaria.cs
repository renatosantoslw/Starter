using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_Portaria : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE PORTARIA";
        private Portaria PORTARIA = null;

        public FCA_Portaria(Portaria _Portaria)
        {
            InitializeComponent();
            PORTARIA = _Portaria;
            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Titulo.Text = PORTARIA.Titulo;
            ovTXT_Descricao.Text = PORTARIA.Descricao;
        }
        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_Titulo.Text.Trim()))
                    throw new Exception("Informe o Título.");

                PORTARIA.Titulo = ovTXT_Titulo.Text;
                PORTARIA.Descricao = ovTXT_Descricao.Text;

                DAO.Enum.TipoOperacao Op = DAO.Enum.TipoOperacao.UPDATE;

                if (!FuncoesPortaria.Existe(PORTARIA.IDPortaria))
                {
                    PORTARIA.IDPortaria = Sequence.GetNextID("PORTARIA", "IDPORTARIA");
                    Op = DAO.Enum.TipoOperacao.INSERT;
                }

                if (!FuncoesPortaria.Salvar(PORTARIA, Op))
                    throw new Exception("Não foi possível salvar a Portaria.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Portaria salva com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_Portaria_KeyDown(object sender, KeyEventArgs e)
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
