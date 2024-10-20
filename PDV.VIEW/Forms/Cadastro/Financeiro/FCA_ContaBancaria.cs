using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.Financeiro
{
    public partial class FCA_ContaBancaria : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE CONTA BANCÁRIA";
        public ContaBancaria Conta { get; set; }
        private List<Banco> Bancos = null;
        public static readonly decimal[] idsMenuItem = { 35 };

        public FCA_ContaBancaria(ContaBancaria conta)
        {
            InitializeComponent();
            Conta = conta;

            Bancos = FuncoesBanco.GetBancos();
            ovCMB_Banco.DataSource = Bancos;
            ovCMB_Banco.DisplayMember = "nome";
            ovCMB_Banco.ValueMember = "idbanco";
            ovCMB_Banco.SelectedItem = null;

            Carregar();
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

                if (string.IsNullOrEmpty(ovTXT_Nome.Text.Trim()))
                    throw new Exception("Informe o Nome.");

                if (!ovCKB_CaixaInterno.Checked && ovCMB_Banco.SelectedItem == null)
                    throw new Exception("Selecione o Banco.");

                Conta.Nome = ovTXT_Nome.Text;
                Conta.Agencia = ovTXT_Agencia.Text == "" ? "0" : ovTXT_Agencia.Text;
                Conta.Conta = ovTXT_Conta.Text== "" ? "0" : ovTXT_Conta.Text;
                Conta.Digito = ovTXT_Digito.Text == "" ? "0" : ovTXT_Digito.Text;
                Conta.DigitoAgencia = ovTXT_DigitoAgencia.Text == "" ? "0" : ovTXT_DigitoAgencia.Text;
                Conta.Operacao = ovTXT_Operacao.Text == "" ? "0" : ovTXT_Operacao.Text;
                Conta.IDBanco = null;

                if (ovCMB_Banco.SelectedItem != null)
                    Conta.IDBanco = (ovCMB_Banco.SelectedItem as Banco).IDBanco;

                Conta.Ativo = ovCKB_Ativo.Checked ? 1 : 0;
                Conta.Caixa = ovCKB_CaixaInterno.Checked ? 1 : 0;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesContaBancaria.Existe(Conta.IDContaBancaria))
                {
                    Conta.IDContaBancaria = Sequence.GetNextID("CONTABANCARIA", "IDCONTABANCARIA");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesContaBancaria.Salvar(Conta, Op))
                    throw new Exception("Não foi possível salvar a Conta Bancária.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Conta Bancária salva com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Carregar()
        {
            ovTXT_Nome.Text = Conta.Nome;
            ovTXT_Agencia.Text = Conta.Agencia;
            ovTXT_Conta.Text = Conta.Conta;
            ovTXT_Digito.Text = Conta.Digito;
            ovTXT_DigitoAgencia.Text = Conta.DigitoAgencia;
            ovTXT_Operacao.Text = Conta.Operacao;

            if (Conta.IDBanco.HasValue)
                ovCMB_Banco.SelectedItem = Bancos.Where(o => o.IDBanco == Conta.IDBanco).FirstOrDefault();

            ovCKB_Ativo.Checked = Conta.Ativo == 1;
            ovCKB_CaixaInterno.Checked = Conta.Caixa == 1;

            VerificaSelecaoBanco();
        }

        private void ovCKB_CaixaInterno_CheckedChanged(object sender, EventArgs e)
        {
            VerificaSelecaoBanco();
        }

        private void VerificaSelecaoBanco()
        {
            if (!ovCKB_CaixaInterno.Checked)
            {
                label1.Font = new System.Drawing.Font("Open Sans", 9.75f, System.Drawing.FontStyle.Bold);
                label1.Text = "* Banco:";
            }
            else
            {
                label1.Font = new System.Drawing.Font("Open Sans", 9.75f, System.Drawing.FontStyle.Regular);
                label1.Text = "Banco:";
            }
        }

        private void ovCKB_CaixaInterno_Click(object sender, EventArgs e)
        {
            if (ovCKB_CaixaInterno.Checked)
            {
                ovCMB_Banco.SelectedItem = null;
            }
        }

        private void FCA_ContaBancaria_KeyDown(object sender, KeyEventArgs e)
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
