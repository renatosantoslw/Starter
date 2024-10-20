using DFe.Classes;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_FluxoCaixa : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "EDIÇÃO DE FLUXO DE CAIXA";
        private FluxoCaixa FluxoCaixa = null;

        public FCA_FluxoCaixa(FluxoCaixa fluxoCaixa)
        {
            Inicializar(fluxoCaixa);
        }

        public FCA_FluxoCaixa(decimal idFluxoCaixa)
        {
            Inicializar(FuncoesFluxoCaixa.GetFluxoCaixa(idFluxoCaixa) ?? new FluxoCaixa());
        }

        private void Inicializar(FluxoCaixa fluxoCaixa)
        {
            InitializeComponent();
            FluxoCaixa = fluxoCaixa;
            PreencherTela();
        }

        private void PreencherTela()
        {
            valorAberturaText.Value = FluxoCaixa.ValorCaixa;
            valorFechamentoText.Value = FluxoCaixa.ValorFechamentoCaixa;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();
                Validar();
                FluxoCaixa.ValorCaixa = valorAberturaText.Value;
                FluxoCaixa.ValorFechamentoCaixa = valorFechamentoText.Value;
                if (!FuncoesFluxoCaixa.Salvar(FluxoCaixa, TipoOperacao.UPDATE))
                    throw new Exception("Não foi possível salvar o fluxo de caixa");
                Success("Fluxo de Caixa salvo com sucesso");
                PDVControlador.Commit();
                Close();
            }
            catch (Exception exception)
            {
                Alert(exception.Message);
                PDVControlador.Rollback();
            }
            
        }

        private void Success(string msg)
        {
            MessageBox.Show(msg, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Alert(string msg)
        {
            MessageBox.Show(msg, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Validar()
        {
            if (valorAberturaText.Value < 1)
                throw new Exception("O valor de abertura não pode ser menor que R$ 1,00");
            if (valorFechamentoText.Value < 1)
                throw new Exception("O valor de fechamento não pode ser menor que R$ 1,00");
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
