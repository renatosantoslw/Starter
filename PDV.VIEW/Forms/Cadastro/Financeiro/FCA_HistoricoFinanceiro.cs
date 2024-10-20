using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.Financeiro
{
    public partial class FCA_HistoricoFinanceiro : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "Cadastro de Histórico Financeiro";
        public static readonly decimal[] idsMenuItem = { 35 };

        public HistoricoFinanceiro Historico { get; set; }

        public FCA_HistoricoFinanceiro(HistoricoFinanceiro historico, Operacao operacao = Operacao.Ambas)
        {
            InitializeComponent();
            Historico = historico;

            if (operacao != Operacao.Ambas)
            {
                Historico.TipoDeMovimento = operacao == Operacao.DeEntrada ? CentroCusto.Entrada : CentroCusto.Saida;
                radioEntrada.Enabled = radioSaida.Enabled = false;
            }

            PreencherTela();
        }

        public FCA_HistoricoFinanceiro(decimal idHistorico)
        {
            var historico = FuncoesHistoricoFinanceiro.GetHistoricoFinanceiro(idHistorico);

            InitializeComponent();
            Historico = historico;
            PreencherTela();

        }

        private void PreencherTela()
        {
            ovTXT_Descricao.Text = Historico.Descricao;

            radioEntrada.Checked = Historico.TipoDeMovimento == CentroCusto.Entrada;
            radioSaida.Checked = Historico.TipoDeMovimento == CentroCusto.Saida;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_Descricao.Text.Trim()))
                    throw new Exception("Informe a Descrição.");

                Historico.Descricao = ovTXT_Descricao.Text;

                Historico.TipoDeMovimento = radioEntrada.Checked ? CentroCusto.Entrada : CentroCusto.Saida;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesHistoricoFinanceiro.Existe(Historico.IDHistoricoFinanceiro))
                {
                    Historico.IDHistoricoFinanceiro = Sequence.GetNextID("HISTORICOFINANCEIRO", "IDHISTORICOFINANCEIRO");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesHistoricoFinanceiro.Salvar(Historico, Op))
                    throw new Exception("Não foi possível salvar o Histórico Financeiro.");

                PDVControlador.Commit();
                MessageBox.Show(this, " Histórico Financeiro salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_HistoricoFinanceiro_KeyDown(object sender, KeyEventArgs e)
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
