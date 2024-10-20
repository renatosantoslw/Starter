using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.Financeiro
{
    public partial class FCA_CentroCusto : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE CENTRO DE CUSTO";
        public static readonly decimal[] idsMenuItem = { 33 };

        public CentroCusto Tipo { get; set;}

        public FCA_CentroCusto(CentroCusto tipo, Operacao operacao = Operacao.Ambas)
        {
            InitializeComponent();
            Tipo = tipo;
            if (operacao != Operacao.Ambas)
            {
                Tipo.TipoDeMovimento = operacao == Operacao.DeEntrada ? CentroCusto.Entrada : CentroCusto.Saida;
                radioEntrada.Enabled = radioSaida.Enabled = false;
            }
            PreencherCampos();
            
        }

        public FCA_CentroCusto(decimal idTipo)
        {
            var tipo = FuncoesCentroCusto.GetCentroCusto(idTipo);
            InitializeComponent();
            Tipo = tipo;
            PreencherCampos();

        }

        private void PreencherCampos()
        {
            ovTXT_Descricao.Text = Tipo.Descricao;
            ovTXT_Sigla.Text = Tipo.Sigla;

            radioEntrada.Checked = Tipo.TipoDeMovimento == CentroCusto.Entrada;
            radioSaida.Checked = Tipo.TipoDeMovimento == CentroCusto.Saida;
        }

        private void metroButton5_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, System.EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_Descricao.Text.Trim()))
                    throw new Exception("Informe a Descrição.");

                Tipo.Sigla = ovTXT_Sigla.Text;
                Tipo.Descricao = ovTXT_Descricao.Text;
                Tipo.TipoDeMovimento = radioEntrada.Checked ? CentroCusto.Entrada : CentroCusto.Saida;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesCentroCusto.Existe(Tipo.IDCentroCusto))
                {
                    Tipo.IDCentroCusto = Sequence.GetNextID("CENTROCUSTO", "IDCENTROCUSTO");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesCentroCusto.Salvar(Tipo, Op))
                    throw new Exception("Não foi possível salvar o Centro de Custo");

                PDVControlador.Commit();
                MessageBox.Show(this, "Centro de Custo salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_CentroCusto_KeyDown(object sender, KeyEventArgs e)
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
