using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.VIEW.App_Context;
using System;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Configuracoes
{
    public partial class FCONFIG_Atualizador : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONFIGURAR SERVIDOR DE ATUALIZAÇÃO";

        public FCONFIG_Atualizador()
        {
            InitializeComponent();
            PreencherTela();
        }

        private void PreencherTela()
        {
            Configuracao config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOATUALIZADOR_ENDERECO);
            if (config != null)
                ovTXT_Endereco.Text = Encoding.UTF8.GetString(config.Valor);

            config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOATUALIZADOR_PASTA);
            if (config != null)
                ovTXT_Pasta.Text = Encoding.UTF8.GetString(config.Valor);

            config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOATUALIZADOR_USUARIO);
            if (config != null)
                ovTXT_Usuario.Text = Encoding.UTF8.GetString(config.Valor);

            config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOATUALIZADOR_SENHA);
            if (config != null)
                ovTXT_Senha.Text = Criptografia.DecodificaSenha(Encoding.UTF8.GetString(config.Valor));
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
            return base.ProcessDialogKey(keyData);
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

                if (string.IsNullOrEmpty(ovTXT_Endereco.Text))
                    throw new Exception("Preencha o Endereço.");

                if (string.IsNullOrEmpty(ovTXT_Pasta.Text))
                    throw new Exception("Preencha a Pasta");

                if (string.IsNullOrEmpty(ovTXT_Usuario.Text))
                    throw new Exception("Preencha o Usuário.");

                if (string.IsNullOrEmpty(ovTXT_Senha.Text))
                    throw new Exception("Preencha a Senha.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGURACAOATUALIZADOR_ENDERECO, Encoding.Default.GetBytes(ovTXT_Endereco.Text)))
                    throw new Exception("Não foi possível salvar o Endereço.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGURACAOATUALIZADOR_PASTA, Encoding.Default.GetBytes(ovTXT_Pasta.Text)))
                    throw new Exception("Não foi possível salvar a Pasta.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGURACAOATUALIZADOR_USUARIO, Encoding.Default.GetBytes(ovTXT_Usuario.Text)))
                    throw new Exception("Não foi possível salvar o Usuário.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGURACAOATUALIZADOR_SENHA, Encoding.Default.GetBytes(Criptografia.CodificaSenha(ovTXT_Senha.Text))))
                    throw new Exception("Não foi possível salvar a Senha.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Configurações salvas com sucesso.", NOME_TELA);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }
    }
}
