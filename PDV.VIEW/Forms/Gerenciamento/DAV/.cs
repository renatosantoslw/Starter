using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Gerenciamento.DAV
{
    public partial class LoginAdminDAV : DevExpress.XtraEditors.XtraForm
    {
        public Usuario Logado = null;
        public bool isLogado { get; set; } = false;

        public LoginAdminDAV()
        {
            InitializeComponent();
        }
        private void Logar()
        {

            if (string.IsNullOrEmpty(ovTXT_Login.Text.Trim()))
            {
                ovTXT_StatusLogin.Text = "Informe o Login.";
                ovTXT_Login.Select();
                Alert("Informe o Login.");
                return;
            }

            if (string.IsNullOrEmpty(ovTXT_Senha.Text.Trim()))
            {
                ovTXT_StatusLogin.Text = "Informe a Senha.";
                ovTXT_Senha.Select();
                Alert("Informe a Senha.");
                return;
            }

            ovTXT_StatusLogin.Text = "";

            Logado = FuncoesUsuario.GetUsuarioRoot(ovTXT_Login.Text, Criptografia.CodificaSenha(ovTXT_Senha.Text));
            if (Logado != null)
            {
                if (!IsAdmin())
                {
                    ovTXT_StatusLogin.Text = "Este Usuário não é Administrador.";
                    Alert("Usuário não é Administrador.");
                }
                else
                {

                    isLogado = true;
                    Close();
                    ovTXT_Senha.Text = "";
                }

            }
            else
            {
                Logado = FuncoesUsuario.GetUsuarioPorLoginESenha(ovTXT_Login.Text, Criptografia.CodificaSenha(ovTXT_Senha.Text));
                if (Logado == null)
                {
                    ovTXT_StatusLogin.Text = "Email ou Senha Incorreto.";
                    Alert("Email ou Senha Incorreto.");
                    Logado = null;
                    return;
                }
                else
                {
                    if (!IsAdmin())
                    {
                        ovTXT_StatusLogin.Text = "Este Usuário não é Administrador.";
                        Alert("Usuário não é Administrador.");
                    }
                    else
                    {

                        isLogado = true;
                        Close();
                        ovTXT_Senha.Text = "";
                    }
                }
            }
        }
        public void Alert(string texto)
        {
            MessageBox.Show(texto, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool IsAdmin()
        {
            PerfilAcesso perfil = FuncoesPerfilAcesso.GetPerfil(Logado.IDPerfilAcesso);
            return perfil.IsAdmin == 1;
        }

        private void logarTextBox_Click(object sender, EventArgs e)
        {
            Logar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoginAdminDAV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Logar();
            if (e.KeyCode == Keys.Escape)
                Close();
            
        }

    }
}
