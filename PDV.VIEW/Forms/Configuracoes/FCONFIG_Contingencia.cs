using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.Entidades;
using PDV.VIEW.App_Context;
using System;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Configuracoes
{
    public partial class FCONFIG_Contingencia : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONTINGÊNCIA";

        public FCONFIG_Contingencia()
        {
            InitializeComponent();
        }

        private void FCONFIG_Contingencia_Load(object sender, EventArgs e)
        {
            CarregarConfiguracao();
        }

        private void CarregarConfiguracao()
        {
            Configuracao config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOCONTINGENCIA_JUSTIFICATIVA);
            if (config != null)
                ovTXT_Justificativa.Text = Encoding.UTF8.GetString(config.Valor);

            config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOCONTINGENCIA_TEMPOINTERVALO_MOTOR);
            if (config != null)
                ovTXT_TempoIntervalo.Text = Encoding.UTF8.GetString(config.Valor);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_Justificativa.Text.Trim()))
                    throw new Exception("Preencha a Justificativa.");

                if (ovTXT_Justificativa.Text.Trim().Length < 15)
                    throw new Exception("A Justificativa deve ter no mínimo 15 caracteres.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGURACAOCONTINGENCIA_JUSTIFICATIVA, Encoding.Default.GetBytes(ovTXT_Justificativa.Text)))
                    throw new Exception("Não foi possível salvar a Justificativa.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGURACAOCONTINGENCIA_TEMPOINTERVALO_MOTOR, Encoding.Default.GetBytes(ovTXT_TempoIntervalo.Text)))
                    throw new Exception("Não foi possível salvar o tempo de intervalo.");


                PDVControlador.Commit();
                MessageBox.Show(this, "Configurações Salvas com Sucesso.", NOME_TELA);
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
