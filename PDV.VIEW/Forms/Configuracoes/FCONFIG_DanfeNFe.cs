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
    public partial class FCONFIG_DanfeNFe : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "IMPRESSÃO DANFE NF-E";
        public FCONFIG_DanfeNFe()
        {
            InitializeComponent();
            CarregarConfiguracoes();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Close();
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

        private void CarregarConfiguracoes()
        {
            Configuracao config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_EMISSAONORMAL_NFE);
            if (config != null)
            {
                switch (Convert.ToInt32(Encoding.UTF8.GetString(config.Valor)))
                {
                    case 1:
                        ovRBCont_UmaLinha.Checked = true;
                        break;
                    case 2:
                        ovRBCont_DuasLinhas.Checked = true;
                        break;
                }
            }
            config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_NOMEIMPRESSORA_NFE);
            if (config != null)
                ovTXT_NomeImpressora.Text = Encoding.UTF8.GetString(config.Valor);

            config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_EXIBIRCAIXADIALOGO_NFE);
            if (config != null)
                ovCKB_ExibirCaixaDialogo.Checked = "1".Equals(Encoding.UTF8.GetString(config.Valor));
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_EMISSAONORMAL_NFE, Encoding.Default.GetBytes(ovRBCont_UmaLinha.Checked ? "1" : "2")))
                    throw new Exception("Não foi possível salvar a Impressão dos Protudos.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_NOMEIMPRESSORA_NFE, Encoding.Default.GetBytes(ovTXT_NomeImpressora.Text)))
                    throw new Exception("Não foi possível salvar o Nome da Impressora.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_EXIBIRCAIXADIALOGO_NFE, Encoding.Default.GetBytes(ovCKB_ExibirCaixaDialogo.Checked ? "1" : "0")))
                    throw new Exception("Não foi possível salvar a Exibição da Caixa de Dialogo.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Configurações salvas com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
