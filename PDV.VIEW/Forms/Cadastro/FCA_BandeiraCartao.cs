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
    public partial class FCA_BandeiraCartao : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE BANDEIRA DO CARTÃO DE CRÉDITO/DÉBITO";
        private BandeiraCartao Bandeira = null;
        public FCA_BandeiraCartao(BandeiraCartao _Bandeira)
        {
            InitializeComponent();
            Bandeira = _Bandeira;
            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Codigo.Text = Bandeira.Codigo == -1 ? string.Empty : Bandeira.Codigo.ToString();
            ovTXT_Descricao.Text = Bandeira.Descricao;
        }

        private void ovBTN_Cancelar_Click(object sender, EventArgs e)
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

                Bandeira.Codigo = Convert.ToDecimal(ovTXT_Codigo.Text);
                Bandeira.Descricao = ovTXT_Descricao.Text;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesBandeiraCartao.Existe(Bandeira.IDBandeiraCartao))
                {
                    Bandeira.IDBandeiraCartao = Sequence.GetNextID("BANDEIRACARTAO", "IDBANDEIRACARTAO");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesBandeiraCartao.Salvar(Bandeira, Op))
                    throw new Exception("Não foi possível salvar a Bandeira.");

                PDVControlador.Commit();
               MessageBox.Show(this, "Bandeira salva com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
               MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_BandeiraCartao_KeyDown(object sender, KeyEventArgs e)
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
