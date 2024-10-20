using MetroFramework;
using MetroFramework.Forms;
using PDV.DAO.DB.Utils;
using PDV.VIEW.App_Context;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Configuracoes
{
    public partial class FCONFIG_MDFeGeral : DevExpress.XtraEditors.XtraForm
    {
        private IniFile _IniFile = null;

        public FCONFIG_MDFeGeral()
        {
            InitializeComponent();

            ovTXT_ValorSequence.AplicaAlteracoes();
            CarregaConfiguracoes();
        }

        private void CarregaConfiguracoes()
        {
            _IniFile = new IniFile(Contexto.CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW\\App_Data\\Start.ini" : "\\App_Data\\Start.ini"));
            ovTXT_Serie.Text = _IniFile.GetValue("Configuracoes_PDV", "serie_mdfe", "1");
            ovTXT_Sequencia.Text = _IniFile.GetValue("Configuracoes_PDV", "nomesequence_mdfe", "MDFE_01");
            ovTXT_ValorSequence.Value = Convert.ToInt32(_IniFile.GetValue("Configuracoes_PDV", "valorsequence_mdfe", "1"));
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ovTXT_Serie.Text))
                    throw new Exception("Preencha a Série.");

                if (string.IsNullOrEmpty(ovTXT_Sequencia.Text))
                    throw new Exception("Preencha a Sequência.");

                _IniFile.SetValue("Configuracoes_PDV", "serie_mdfe", ovTXT_Serie.Text);
                _IniFile.SetValue("Configuracoes_PDV", "nomesequence_mdfe", ovTXT_Sequencia.Text);
                _IniFile.SetValue("Configuracoes_PDV", "valorsequence_mdfe", ovTXT_ValorSequence.Value.ToString());

                if (!Sequence.AtualizarValorSequence(ovTXT_Sequencia.Text, ovTXT_ValorSequence.Value))
                    throw new Exception("Não foi possível atualizar o valor da Sequence.");

                _IniFile.Save(Contexto.CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW\\App_Data\\Start.ini" : "\\App_Data\\Start.ini"));

                MessageBox.Show(this, "Configurações salvas com sucesso.", "GERAL");
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "GERAL");
            }
        }

    }
}
