using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Configuracoes
{
    public partial class FCONFIG_NFCeGeral : DevExpress.XtraEditors.XtraForm
    {
        private IniFile _IniFile = null;
        private List<Cfop> CFOPS = null;
        public FCONFIG_NFCeGeral()
        {
            InitializeComponent();

            ovTXT_ValorSequence.AplicaAlteracoes();
            CarregaConfiguracoes();
            CFOPS = FuncoesCFOP.GetCFOPSAtivos();
            ovCMB_NaturezaOperacao.DataSource = CFOPS;
            ovCMB_NaturezaOperacao.DisplayMember = "codigodescricao";
            ovCMB_NaturezaOperacao.ValueMember = "idcfop";
            ovCMB_NaturezaOperacao.SelectedItem = null;
        }

        private void CarregaConfiguracoes()
        {
            _IniFile = new IniFile(Contexto.CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW\\App_Data\\Start.ini" : "\\App_Data\\Start.ini"));
            ovTXT_Serie.Text = _IniFile.GetValue("Configuracoes_PDV", "serie_nfce", "1");
            ovTXT_Sequencia.Text = _IniFile.GetValue("Configuracoes_PDV", "nomesequence_nfce", "PDV_01");
            ovTXT_ValorSequence.Value = GetProximoNumeroNFC();
        }

        private decimal GetProximoNumeroNFC()
        {
            return FuncoesEmitente.GetEmitente().ProximoNumeroNFCe - 1;
        }

        private void metroButton5_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        public void SalvarNaturezaDeOperaçãoPadrao()
        {
            try
            {
                PDVControlador.BeginTransaction();
                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_NOME_NATUREZAOPERACAO, Encoding.Default.GetBytes(ovCMB_NaturezaOperacao.Text)))
                    throw new Exception("Não foi possível salvar o nome da natureza de operação.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_CFOP_NATUREZAOPERACAO, Encoding.Default.GetBytes(ovTXT_CodNatOp.Text)))
                    throw new Exception("Não foi possível salvar o cfop da natureza de operação.");

                PDVControlador.Commit();
            }
            catch (Exception ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, ex.Message, "Configurações NFCe");
            }
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

                SalvarProximoValorNFCe();

                if (!Sequence.AtualizarValorSequence(ovTXT_Sequencia.Text, ovTXT_ValorSequence.Value))
                    throw new Exception("Não foi possível atualizar o valor da Sequence.");

                _IniFile.Save(Contexto.CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW\\App_Data\\Start.ini" : "\\App_Data\\Start.ini"));

                SalvarNaturezaDeOperaçãoPadrao();
                MessageBox.Show(this, "Configurações salvas com sucesso.", "GERAL");
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "GERAL");
            }
        }

        private void SalvarProximoValorNFCe()
        {
            var emitente = FuncoesEmitente.GetEmitente();
            emitente.ProximoNumeroNFCe = ovTXT_ValorSequence.Value + 1;
            FuncoesEmitente.SalvarEmitente(emitente, TipoOperacao.UPDATE);               
        }

        private void ovTXT_CodNatOp_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    carregarNaturezaDeOperação();
                    break;
            }
        }

        private void carregarNaturezaDeOperação()
        {
            ovCMB_NaturezaOperacao.SelectedItem = CFOPS.Where(o => o.Codigo == ZeusUtil.SomenteNumeros(ovTXT_CodNatOp.Text)).FirstOrDefault();

            if (ovCMB_NaturezaOperacao.SelectedItem == null)
            {
                MessageBox.Show(this, "CFOP não encontrado.");
                ovCMB_NaturezaOperacao.Select();
                ovCMB_NaturezaOperacao.SelectAll();
            }
        }

        private void FCONFIG_NFCeGeral_Load(object sender, EventArgs e)
        {
            Configuracao config1 = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_CFOP_NATUREZAOPERACAO);
            if (config1 != null)
            {
                ovTXT_CodNatOp.Text = Encoding.UTF8.GetString(config1.Valor);
                carregarNaturezaDeOperação();
            }
        }
    }
}
