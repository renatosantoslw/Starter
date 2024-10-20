using MetroFramework;
using MetroFramework.Forms;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_HistoricoClienteFornecedor : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE HISTÓRICO";
        public HistoricoClienteFornecedor Historico = null;
        public bool Salvou = false;

        public FCA_HistoricoClienteFornecedor(HistoricoClienteFornecedor _Historico)
        {
            InitializeComponent();
            Historico = _Historico;
            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Assunto.Text = Historico.Assunto;
            ovTXT_DataHora.Text = Historico.DataHistorico.ToString();
            ovTXT_Observacao.Text = Historico.Observacao;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Salvou = false;
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ovTXT_Assunto.Text))
            {
                MessageBox.Show(this, "Informe o Assunto.", NOME_TELA);
                return;
            }

            Historico.Assunto = ovTXT_Assunto.Text;
            Historico.Observacao = ovTXT_Observacao.Text;
            Salvou = true;
            Close();
        }

        private void FCA_HistoricoClienteFornecedor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
