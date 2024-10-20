using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Configuracoes
{
    public partial class GERAL : DevExpress.XtraEditors.XtraForm
    {
        private IniFile _IniFile = null;

        public GERAL()
        {
            InitializeComponent();

            ovTXT_ValorSequence.AplicaAlteracoes();
            CarregaConfiguracoes();
            CarregaPermissoes();
        }

        private void CarregaPermissoes()
        {
            ovTXT_ValorSequence.ReadOnly = Contexto.USUARIOLOGADO.IDPerfilAcesso != 1;
        }

        private void CarregaConfiguracoes()
        {
            _IniFile = new IniFile(Contexto.CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW\\App_Data\\Start.ini" : "\\App_Data\\Start.ini"));
            ovTXT_Serie.Text = _IniFile.GetValue("Configuracoes_PDV", "serie_nfe", "1");
            ovTXT_ValorSequence.Text = GetProximoNumeroNFe();

        }

        private string GetProximoNumeroNFe()
        {
            return (FuncoesEmitente.GetEmitente().ProximoNumeroNFe - 1).ToString();
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

                if (string.IsNullOrEmpty(ovTXT_ValorSequence.Text))
                    throw new Exception("Preencha o valor atual.");

                _IniFile.SetValue("Configuracoes_PDV", "serie_nfe", ovTXT_Serie.Text);
                _IniFile.SetValue("Configuracoes_PDV", "nomesequence_nfe", ovTXT_Sequencia.Text);

                SalvarProximoNumeroNFe();

                ///if (!Sequence.AtualizarValorSequence(ovTXT_Sequencia.Text, ovTXT_ValorSequence.Value))
                   // throw new Exception("Não foi possível atualizar o valor da Sequence.");

                _IniFile.Save(Contexto.CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW\\App_Data\\Start.ini" : "\\App_Data\\Start.ini"));

                MessageBox.Show(this, "Configurações salvas com sucesso.", "GERAL");
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "GERAL");
            }
        }

        private void SalvarProximoNumeroNFe()
        {
            var emitente = FuncoesEmitente.GetEmitente();
            emitente.ProximoNumeroNFe = Convert.ToDecimal(ovTXT_ValorSequence.Text) + 1;
            FuncoesEmitente.SalvarEmitente(emitente, TipoOperacao.UPDATE);
        }
    }
}
