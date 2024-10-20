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

namespace PDV.UTIL.FORMS.Forms
{
    public partial class AlterarSenha : DevExpress.XtraEditors.XtraForm
    {
        public AlterarSenha(String Usuario)
        {
            InitializeComponent();
            ovTXT_Login.Text = Usuario;
        }


        private void btnLogar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ovTXT_Login.Text))
                {
                    throw new Exception("Informe a senha atual");
                }

                if (string.IsNullOrEmpty(senhaAtualTextBox.Text))
                {
                    throw new Exception("Informe a senha atual");
                }
                if (string.IsNullOrEmpty(novasenha01.Text))
                {
                    throw new Exception("Informe a nova senha ");
                }
                if (string.IsNullOrEmpty(novasenha02.Text))
                {
                    throw new Exception("Confirme a nova senha ");
                }
                if(novasenha01.Text != novasenha02.Text)
                {
                    throw new Exception("A senha informada está diferente a da senha de confirmação");
                }
                Usuario usuario = FuncoesUsuario.GetUsuarioPorLoginESenha(ovTXT_Login.Text, Criptografia.CodificaSenha(senhaAtualTextBox.Text));
                if(usuario == null)
                {
                    throw new Exception("Usuário não localizado!");
                }
                FuncoesUsuario.AlterarSenha(usuario.Nome, Criptografia.CodificaSenha(novasenha01.Text), usuario.IDUsuario);
                MessageBox.Show("Usuário alterado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AlterarSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogar_Click(sender, e);
            }

        }
    }
}
