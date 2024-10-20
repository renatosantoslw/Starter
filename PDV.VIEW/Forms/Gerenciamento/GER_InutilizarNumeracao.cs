using DFe.Classes.Flags;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLLER.EVENTONFE.Classes;
using PDV.CONTROLLER.EVENTONFE.Eventos;
using PDV.VIEW.App_Context;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Gerenciamento
{
    public partial class GER_InutilizarNumeracao : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "INUTILIZAR NUMERAÇÃO NFC-E/NF-E";
        private decimal TIPODOCUMENTO = 0;

        public GER_InutilizarNumeracao(decimal TipoDocumento)
        {
            InitializeComponent();
            TIPODOCUMENTO = TipoDocumento;

            NOME_TELA = TipoDocumento == 55 ? "INUTILIZAR NUMERAÇÃO NF-E" : "INUTILIZAR NUMERAÇÃO NFC-E";
            Text = NOME_TELA;

            ovTXT_Serie.Value = TipoDocumento == 55 ? Contexto.CONFIGURACAO_SERIE.SerieNFe : Contexto.CONFIGURACAO_SERIE.SerieNFCe;
            ovTXT_Ano.Value = DateTime.Now.Year - 2000;

            ovTXT_Ano.AplicaAlteracoes();
            ovTXT_NumeroInicial.AplicaAlteracoes();
            ovTXT_NumeroFinal.AplicaAlteracoes();            
            ovTXT_Serie.AplicaAlteracoes();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void inutilizarNumeracao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ovTXT_Justificativa.Text))
            {
                MessageBox.Show(this, "Preencha a Justificativa.", NOME_TELA);
                return;
            }

            try
            {
                RetornoEvento Retorno = EventoInutilizarNumeracao.Enviar(TIPODOCUMENTO == 55 ? Contexto.CONFIG_NFe.CfgServico : Contexto.CONFIG_NFCe.CfgServico,
                                                                         Contexto.CONFIG_NFe.Emitente.CNPJ,
                                                                         Convert.ToInt32(ovTXT_Ano.Value),
                                                                         (ModeloDocumento)TIPODOCUMENTO,
                                                                         Convert.ToInt32(ovTXT_Serie.Value),
                                                                         Convert.ToInt32(ovTXT_NumeroInicial.Value),
                                                                         Convert.ToInt32(ovTXT_NumeroFinal.Value),
                                                                         ovTXT_Justificativa.Text);
                MessageBox.Show(this, Retorno.xMotivo, NOME_TELA);
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }
    }
}
