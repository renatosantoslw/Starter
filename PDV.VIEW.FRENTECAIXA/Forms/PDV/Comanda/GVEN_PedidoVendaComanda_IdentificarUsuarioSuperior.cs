using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.VIEW.FRENTECAIXA.App_Context;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms.PDV.Comanda
{
    public partial class GVEN_PedidoVendaComanda_IdentificarUsuarioSuperior : DevExpress.XtraEditors.XtraForm
    {
        private Usuario USUARIOSUPERVISOR = null;
        public bool Autenticou = false;

        public GVEN_PedidoVendaComanda_IdentificarUsuarioSuperior()
        {
            InitializeComponent();
            USUARIOSUPERVISOR = FuncoesUsuario.GetUsuarioSupervisor(Contexto.USUARIOLOGADO.IDUsuario);

            textBox1.Text = USUARIOSUPERVISOR.Nome;
            ovTXT_Mensagem.Text = string.Empty;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.F10:
                    AutenticarUsuario();
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void metroButton4_Click(object sender, System.EventArgs e)
        {
            AutenticarUsuario();
        }

        private void AutenticarUsuario()
        {
            if (string.IsNullOrEmpty(ovTXT_Pin.Text))
                return;

            if (!FuncoesUsuario.AutenticarUsuarioSupervisor(USUARIOSUPERVISOR.Login, Criptografia.CodificaSenha(ovTXT_Pin.Text)))
            {
                ovTXT_Mensagem.Text = "Pin não autenticado!";
                return;
            }

            Autenticou = true;
            Close();
        }
    }
}
