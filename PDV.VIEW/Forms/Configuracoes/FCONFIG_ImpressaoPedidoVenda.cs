using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.Entidades;
using PDV.VIEW.App_Context;
using System;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Configuracoes
{
    public partial class FCONFIG_ImpressaoPedidoVenda : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "IMPRESSÃO DO PEDIDO DE VENDA";

        public FCONFIG_ImpressaoPedidoVenda()
        {
            InitializeComponent();
            CarregarConfiguracoes();
            PopulateInstalledPrintersCombo();
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
            Configuracao config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOPEDIDOVENDA_NOMEIMPRESSORA);
            if (config != null)

               // ovTXT_NomeImpressora.Text = Encoding.UTF8.GetString(config.Valor);
            cbeImpressora.Text = Encoding.UTF8.GetString(config.Valor);

            config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOPEDIDOVENDA_EXIBIRCAIXADIALOGO);
            if (config != null)
            {
                if ("1".Equals(Encoding.UTF8.GetString(config.Valor)))
                    ovRB_ExibirCaixaDialogo.Checked = true;
                else
                    ovRB_ExibirModoExportacao.Checked = true;
            }
            else
                ovRB_ExibirModoExportacao.Checked = true;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

              //  if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGURACAOPEDIDOVENDA_NOMEIMPRESSORA, Encoding.Default.GetBytes(ovTXT_NomeImpressora.Text)))
                  //  throw new Exception("Não foi possível salvar o Nome da Impressora.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGURACAOPEDIDOVENDA_NOMEIMPRESSORA, Encoding.Default.GetBytes(cbeImpressora.Text)))
                    throw new Exception("Não foi possível salvar o Nome da Impressora.");



                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_CONFIGURACAOPEDIDOVENDA_EXIBIRCAIXADIALOGO, Encoding.Default.GetBytes(ovRB_ExibirCaixaDialogo.Checked ? "1" : "0")))
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

        private void FCONFIG_ImpressaoPedidoVenda_Load(object sender, EventArgs e)
        {

        }


        private void PopulateInstalledPrintersCombo()
        {

        
            PrinterSettings oPS = new PrinterSettings();

            if (PrinterSettings.InstalledPrinters.Count > 0)
            {
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    cbeImpressora.Properties.Items.Add(printer);
                }


            }
        }





        
    }
}
