using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using MetroFramework.Forms;
using MetroFramework;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_Usuario : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE USUÁRIO";
        private Usuario User = null;
        private List<PerfilAcesso> Perfis = FuncoesPerfilAcesso.GetPerfisAcesso_CadastroUsuario();
        private List<Usuario> Usuarios = null;
        public static readonly decimal[] idsMenuItem = { 12 };

        public FCA_Usuario(Usuario _Usuario)
        {
            InitializeComponent();
            User = _Usuario;
            Usuarios = FuncoesUsuario.GetUsuarios();

            ovCMB_Perfil.DataSource = Perfis;
            ovCMB_Perfil.DisplayMember = "descricao";
            ovCMB_Perfil.ValueMember = "idperfilacesso";


            ovCMB_UsuarioSupervisor.DataSource = Usuarios;
            ovCMB_UsuarioSupervisor.DisplayMember = "nome";
            ovCMB_UsuarioSupervisor.ValueMember = "idusuario";
            PreencherTela();
        }
        public decimal GetUsuarioID()
        {
            return User.IDUsuario;
        }

        private void PreencherTela()
        {
            ovTXT_Nome.Text = User.Nome;
            ovTXT_Login.Text = User.Login;
            ovTXT_Email.Text = User.Email;
            ovTXT_Senha.Text = Criptografia.DecodificaSenha(User.Senha);
            ovTXT_ConfirmaSenha.Text = Criptografia.DecodificaSenha(User.Senha);
            ovTXT_Pin.Text = Criptografia.DecodificaSenha(User.Pin);
            ovCKB_Ativo.Checked = User.Ativo == 1;
            ovCKB_IsVendedor.Checked = User.IsVendedor == 1;
            ovCKB_IsComprador.Checked = User.IsComprador == 1;

            PerfilAcesso perfil = Perfis.Where(o => o.IDPerfilAcesso == User.IDPerfilAcesso).FirstOrDefault();
            if (perfil != null)
                if (perfil.IsAdmin == 1)
                    textEditDescontoMaximo.Visible = labelDescontoMaximo.Visible =  false;
                else
                    textEditDescontoMaximo.Value = User.DescontoMaximo;
           
            
            
               

            if (Perfis != null)
                ovCMB_Perfil.SelectedItem = Perfis.Where(o => o.IDPerfilAcesso == User.IDPerfilAcesso).FirstOrDefault();

            ovCMB_UsuarioSupervisor.SelectedItem = Usuarios.Where(o => o.IDUsuario == User.IDUsuarioSupervisor).FirstOrDefault();


            #region Tratando Tipo de Desconto
            if  (User.TipoDesconto == 3)
            {
                tipoDescontoComboBox.SelectedIndex = 2;
            }
            else if (User.TipoDesconto == 1)
            {
                tipoDescontoComboBox.SelectedIndex = 0;
            }
            else if (User.TipoDesconto == 2)
            {
                tipoDescontoComboBox.SelectedIndex = 1;
            }
            #endregion

            #region Tratando Forma de Desconto
            if (User.FormaDesconto == 1)
            {
                formaDescontoCombobox.SelectedIndex = 0;
            }
            else if (User.FormaDesconto == 2)
            {
                formaDescontoCombobox.SelectedIndex = 1;
            }
            #endregion


            AjustarDecontoMaximo();
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

                if (string.IsNullOrEmpty(ovTXT_Nome.Text.Trim()))
                    throw new Exception("Informe o Nome.");

                if (string.IsNullOrEmpty(ovTXT_Login.Text.Trim()))
                    throw new Exception("Informe o Login.");

                if (string.IsNullOrEmpty(ovTXT_Senha.Text.Trim()))
                    throw new Exception("Informe a Senha.");

                if (string.IsNullOrEmpty(ovTXT_ConfirmaSenha.Text.Trim()))
                    throw new Exception("Informe a Confirmação da Senha.");
                else
                {
                    if (!ovTXT_Senha.Text.Equals(ovTXT_ConfirmaSenha.Text))
                        throw new Exception("As Senhas não conferem.");
                }

                if (ovCMB_Perfil.SelectedItem == null)
                    throw new Exception("Selecione um Perfil.");

                if (formaDescontoCombobox.SelectedItem == null)
                    throw new Exception("Selecione uma Forma de Desconto.");

                if (formaDescontoCombobox.SelectedIndex == 1 && textEditDescontoMaximo.Value > 100)
                    throw new Exception("A porcentagem máxima de desconto não pode ultrapassar 100%");


                User.Nome = ovTXT_Nome.Text.Trim();
                User.Login = ovTXT_Login.Text.Trim();
                User.Email = ovTXT_Email.Text.Trim();
                User.Senha = Criptografia.CodificaSenha(ovTXT_Senha.Text);
                User.Ativo = ovCKB_Ativo.Checked ? 1 : 0;
                User.IDPerfilAcesso = (ovCMB_Perfil.SelectedItem as PerfilAcesso).IDPerfilAcesso;
                User.IDUsuarioSupervisor = (ovCMB_UsuarioSupervisor.SelectedItem as Usuario).IDUsuario;
                User.Pin = Criptografia.CodificaSenha(ovTXT_Pin.Text);
                User.IsVendedor = ovCKB_IsVendedor.Checked?1:0;
                User.IsComprador = ovCKB_IsComprador.Checked ? 1 : 0;
                User.DescontoMaximo = textEditDescontoMaximo.Value;

                #region Tratando Tipo de Desconto
                if (tipoDescontoComboBox.Text == "" || tipoDescontoComboBox.Text == "Não Concede Desconto")
                {
                    User.TipoDesconto = 3;
                }
                else if (tipoDescontoComboBox.Text == "Venda")
                {
                    User.TipoDesconto = 1;
                }
                else if (tipoDescontoComboBox.Text == "Produto")
                {
                    User.TipoDesconto = 2;
                }
                #endregion

                #region Tratando Forma de Desconto
                if(formaDescontoCombobox.Text == "Valor")
                {
                    User.FormaDesconto = 1;
                }
                else if(formaDescontoCombobox.Text == "Percentual")
                {
                    User.FormaDesconto = 2;
                }
                #endregion


                if (FuncoesUsuario.ExisteLogin(User.IDUsuario, User.Login))
                    throw new Exception("O Login informado já existe.");

                DAO.Enum.TipoOperacao Op = DAO.Enum.TipoOperacao.UPDATE;
                if (!FuncoesUsuario.Existe(User.IDUsuario))
                {
                    User.IDUsuario = Sequence.GetNextID("USUARIO", "IDUSUARIO");
                    Op = DAO.Enum.TipoOperacao.INSERT;
                }

                if (!FuncoesUsuario.Salvar(User, Op))
                    throw new Exception("Não foi possível salvar o Usuário.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Usuário salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ovCMB_Perfil_DropDown(object sender, EventArgs e)
        {
            if (Perfis != null)
                ovCMB_Perfil.DataSource = Perfis.Where(o => o.Ativo == 1).ToList();
        }

        private void FCA_Usuario_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void ovCMB_Perfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerfilAcesso perfil = (ovCMB_Perfil.SelectedItem as PerfilAcesso);
            if (perfil != null)
                textEditDescontoMaximo.Visible = labelDescontoMaximo.Visible = perfil.IsAdmin == 0;

        }

        private void formaDescontoCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AjustarDecontoMaximo();
        }

        private void AjustarDecontoMaximo()
        {
            if (formaDescontoCombobox.SelectedIndex == 0)
                textEditDescontoMaximo.Properties.EditMask = "c";
            else
                textEditDescontoMaximo.Properties.EditMask = "P";
        }
 
    }
}
