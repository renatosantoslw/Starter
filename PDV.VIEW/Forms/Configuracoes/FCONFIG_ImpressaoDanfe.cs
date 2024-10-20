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
    public partial class FCONFIG_ImpressaoDanfe : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "IMPRESSÃO DO DANFE NFC-E";

        public FCONFIG_ImpressaoDanfe()
        {
            InitializeComponent();

            ovTXT_MargemDireita.AplicaAlteracoes();
            ovTXT_MargemEsquerda.AplicaAlteracoes();

            CarregarConfiguracoes();
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

        private void ovBTN_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CarregarConfiguracoes()
        {
            Configuracao config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_EMISSAONORMAL);
            if (config != null)
            {
                switch (Convert.ToInt32(Encoding.UTF8.GetString(config.Valor)))
                {
                    case 0:
                        ovRBEN_NaoImprimir.Checked = true;
                        break;
                    case 1:
                        ovRBEN_UmaLinha.Checked = true;
                        break;
                    case 2:
                        ovRBEN_DuasLinhas.Checked = true;
                        break;
                }
            }

            config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_IMPRESSAOCONTINGENCIA);
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

            config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_MARGEMIMPRESSAOESQUERDA);
            if (config != null)
            {
                ovTXT_MargemEsquerda.Value = Convert.ToDecimal(Encoding.UTF8.GetString(config.Valor));
            }

            config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_MARGEMIMPRESSAODIREITA);
            if (config != null)
            {
                ovTXT_MargemDireita.Value = Convert.ToDecimal(Encoding.UTF8.GetString(config.Valor));
            }

            config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_IMPRIMIRDESCONTOITEM);
            if (config != null)
            {
                ovCKB_ImprimirDescontodoItem.Checked = "1".Equals(Encoding.UTF8.GetString(config.Valor));
            }

            config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_MODODEIMPRESSAO);
            if (config != null)
            {
                if ("1".Equals(Encoding.UTF8.GetString(config.Valor)))
                    ovRB_ModoImpressaoUnicaPagina.Checked = true;
                else if ("2".Equals(Encoding.UTF8.GetString(config.Valor)))
                    ovRB_ModoImpressaoMultiplasPaginas.Checked = true;
            }

            config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_NOMEIMPRESSORA);
            if (config != null)
                ovTXT_NomeImpressora.Text = Encoding.UTF8.GetString(config.Valor);

            config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_EXIBIRCAIXADIALOGO);
            if (config != null)
                ovCKB_ExibirCaixaDialogo.Checked = "1".Equals(Encoding.UTF8.GetString(config.Valor));
        }

        private void ovBTN_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                decimal OpcaoImpressaoNormal = 0;
                if (ovRBEN_NaoImprimir.Checked)
                    OpcaoImpressaoNormal = 0;
                else if (ovRBEN_UmaLinha.Checked)
                    OpcaoImpressaoNormal = 1;
                else if (ovRBEN_DuasLinhas.Checked)
                    OpcaoImpressaoNormal = 2;

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_EMISSAONORMAL, Encoding.Default.GetBytes(OpcaoImpressaoNormal.ToString())))
                    throw new Exception("Não foi possível salvar a Emissão Normal.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_IMPRESSAOCONTINGENCIA, Encoding.Default.GetBytes(ovRBCont_UmaLinha.Checked ? "1" : "2")))
                    throw new Exception("Não foi possível salvar a Contingência.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_MARGEMIMPRESSAOESQUERDA, Encoding.Default.GetBytes(ovTXT_MargemEsquerda.Value.ToString())))
                    throw new Exception("Não foi possível salvar a Margem de Impressão Esquerda.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_MARGEMIMPRESSAODIREITA, Encoding.Default.GetBytes(ovTXT_MargemDireita.Value.ToString())))
                    throw new Exception("Não foi possível salvar a Margem de Impressão Direita.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_IMPRIMIRDESCONTOITEM, Encoding.Default.GetBytes(ovCKB_ImprimirDescontodoItem.Checked ? "1" : "0")))
                    throw new Exception("Não foi possível salvar Imprimir Desconto do Item.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_MODODEIMPRESSAO, Encoding.Default.GetBytes(ovRB_ModoImpressaoUnicaPagina.Checked ? "1" : "2")))
                    throw new Exception("Não foi possível salvar o Modo de Impressão.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_NOMEIMPRESSORA, Encoding.Default.GetBytes(ovTXT_NomeImpressora.Text)))
                    throw new Exception("Não foi possível salvar o Nome da Impressora.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_EXIBIRCAIXADIALOGO, Encoding.Default.GetBytes(ovCKB_ExibirCaixaDialogo.Checked ? "1" : "0")))
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
