using MetroFramework;
using MetroFramework.Forms;
using PDV.DAO.DB.Utils;
using PDV.VIEW.FRENTECAIXA.App_Context;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms
{
    public partial class GPDV_NFCeGeral : DevExpress.XtraEditors.XtraForm
    {
        private IniFile _IniFile = null;
        public GPDV_NFCeGeral()
        {
            InitializeComponent();
            CarregaConfiguracoes();
        }

        private void CarregaConfiguracoes()
        {
            _IniFile = new IniFile(Contexto.CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW\\App_Data\\Start.ini" : "\\App_Data\\Start.ini"));
            ovTXT_Serie.Text = _IniFile.GetValue("Configuracoes_PDV", "serie_nfce", "1");
            ovTXT_Sequencia.Text = _IniFile.GetValue("Configuracoes_PDV", "nomesequence_nfce", "PDV_01");
        }

        private void metroButton5_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ovTXT_Serie.Text))
                    throw new Exception("Preencha a Série.");

                if (string.IsNullOrEmpty(ovTXT_Sequencia.Text))
                    throw new Exception("Preencha a Sequência.");

                _IniFile.SetValue("Configuracoes_PDV", "serie_nfce", ovTXT_Serie.Text);
                _IniFile.SetValue("Configuracoes_PDV", "nomesequence_nfce", ovTXT_Sequencia.Text);

                _IniFile.Save(Contexto.CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW\\App_Data\\Start.ini" : "\\App_Data\\Start.ini"));
                
                MessageBox.Show(this, "Configurações salvas com sucesso. É Necessário deslogar da aplicação para que as configurações tenham efeito.", "GERAL");
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "GERAL");
            }
        }
    }
}
