using MetroFramework;
using MetroFramework.Forms;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_ContatoClienteFornecedor : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE CONTATO";
        public ContatoClienteFornecedor Contato = null;
        public bool Salvou = false;

        public FCA_ContatoClienteFornecedor(ContatoClienteFornecedor _Contato)
        {
            InitializeComponent();

            ovTXT_Telefone.Mask = "(##) #####-####";
            ovTXT_TelefoneAlternativo.Mask = "(##) #####-####";

            Contato = _Contato;
            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Nome.Text = Contato.Nome;
            ovTXT_Cargo.Text = Contato.Cargo;
            ovTXT_Email.Text = Contato.Email;
            ovTXT_Telefone.Text = Contato.Telefone1;
            ovTXT_TelefoneAlternativo.Text = Contato.Telefone2;
            
            if (Contato.Sexo == 0)
                ovCKB_Masculino.Checked = true;
            else
                ovCKB_Feminino.Checked = true;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Salvou = false;
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ovTXT_Nome.Text))
                    throw new Exception("Informe o Nome.");

                Contato.Nome = ovTXT_Nome.Text;
                Contato.Cargo = ovTXT_Cargo.Text;
                Contato.Email = ovTXT_Email.Text;
                Contato.Telefone1 = ovTXT_Telefone.Text;
                Contato.Telefone2 = ovTXT_TelefoneAlternativo.Text;
                Contato.Sexo = ovCKB_Masculino.Checked ? 0 : 1;
                Salvou = true;
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

        private void FCA_ContatoClienteFornecedor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
