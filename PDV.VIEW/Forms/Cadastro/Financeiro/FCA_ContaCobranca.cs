using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.Financeiro
{
    public partial class FCA_ContaCobranca : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE CONTA COBRANÇA";
        private ContaCobranca Conta = null;
        private List<ContaBancaria> Contas = null;
        private List<FormaDePagamento> Formas = null;
        public FCA_ContaCobranca(ContaCobranca _Conta)
        {
            InitializeComponent();
            Conta = _Conta;

            Contas = FuncoesContaBancaria.GetContasBancarias();
            ovCMB_Conta.DataSource = Contas;
            ovCMB_Conta.DisplayMember = "nome";
            ovCMB_Conta.ValueMember = "idcontabancaria";

            Formas = FuncoesFormaDePagamento.GetFormasPagamento();
            ovCMB_FormaPagamento.DataSource = Formas;
            ovCMB_FormaPagamento.DisplayMember = "identificacaodescricao";
            ovCMB_FormaPagamento.ValueMember = "idformadepagamento";
            ovCMB_FormaPagamento.SelectedItem = null;

            Carregar();

            ovTXT_Taxa.AplicaAlteracoes();
            ovTXT_DiasPagto.AplicaAlteracoes();
            ovTXT_ValorMulta.AplicaAlteracoes();
            ovTXT_PercentualJuros.AplicaAlteracoes();
        }

        private void Carregar()
        {
            ovTXT_Layout.Text = Conta.Leiaute;
            ovTXT_EspecieDocumento.Text = Conta.EspecieDoc;
            ovCKB_Aceite.Checked = Conta.Aceite == 1;
            ovTXT_Carteira.Text = Conta.Carteira;
            ovTXT_Especie.Text = Conta.Especie;
            ovTXT_Registro.Checked = Conta.Registro == 1;
            ovTXT_Cedente.Text = Conta.Cedente;
            ovTXT_NossoNumero.Text = Conta.NossoNumero.ToString();
            ovTXT_Taxa.Value = Conta.Taxa ?? 0;
            ovTXT_DiasPagto.Value = Conta.DiasPagto ?? 0;
            ovCKB_Ativo.Checked = Conta.Ativo == 1;
            ovCMB_Conta.SelectedItem = Contas.Where(o => o.IDContaBancaria == Conta.IDContaBancaria).FirstOrDefault();
            ovTXT_LocalPagamento.Text = Conta.LocalPagto;
            ovTXT_Instrucoes.Text = Conta.Instrucoes;
            ovTXT_NumeroRemessa.Text = Conta.NumeroRemessa.ToString();

            ovCMB_FormaPagamento.SelectedItem = Formas.Where(o => o.IDFormaDePagamento == Conta.IDFormaDePagamento).FirstOrDefault();
            ovTXT_ValorMulta.Value = Conta.ValorMulta;
            ovTXT_PercentualJuros.Value = Conta.PercentualJuros;
            ovTXT_VariacaoCarteira.Text = Conta.VariacaoCarteira;

            if (Conta.CNAB == 0)
                ovCKB_CNAB240.Checked = true;
            else
                ovCKB_CNAB400.Checked = true;
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

                if (string.IsNullOrEmpty(ovTXT_Layout.Text.Trim()))
                    throw new Exception("Informe o Layout.");

                if (string.IsNullOrEmpty(ovTXT_Cedente.Text.Trim()))
                    throw new Exception("Informe o Cedente.");

                if (ovCMB_Conta.SelectedItem == null)
                    throw new Exception("Selecione a Conta.");

                if (string.IsNullOrEmpty(ovTXT_NumeroRemessa.Text))
                    throw new Exception("Informe o Número da Remessa.");

                if (ovCMB_FormaPagamento.SelectedItem == null)
                    throw new Exception("Selecione a Forma de Pagamento.");

                Conta.Leiaute = ovTXT_Layout.Text;
                Conta.EspecieDoc = ovTXT_EspecieDocumento.Text;
                Conta.Aceite = ovCKB_Aceite.Checked ? 1 : 0;
                Conta.Carteira = ovTXT_Carteira.Text;
                Conta.Especie = ovTXT_Especie.Text;
                Conta.Registro = ovTXT_Registro.Checked ? 1 : 0;
                Conta.Cedente = ovTXT_Cedente.Text;
                Conta.NossoNumero = string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(ovTXT_NossoNumero.Text)) ? null : (decimal?)Convert.ToDecimal(ZeusUtil.SomenteNumeros(ovTXT_NossoNumero.Text));
                Conta.Taxa = ovTXT_Taxa.Value;
                Conta.DiasPagto = ovTXT_DiasPagto.Value;
                Conta.Ativo = ovCKB_Ativo.Checked ? 1 : 0;
                Conta.IDContaBancaria = (ovCMB_Conta.SelectedItem as ContaBancaria).IDContaBancaria;
                Conta.LocalPagto = ovTXT_LocalPagamento.Text;
                Conta.Instrucoes = ovTXT_Instrucoes.Text;
                Conta.IDFormaDePagamento = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento;
                Conta.ValorMulta = ovTXT_ValorMulta.Value;
                Conta.PercentualJuros = ovTXT_PercentualJuros.Value;
                Conta.VariacaoCarteira = ovTXT_VariacaoCarteira.Text;
                Conta.CNAB = ovCKB_CNAB240.Checked ? 0 : 1;
                Conta.NumeroRemessa = Convert.ToDecimal(ovTXT_NumeroRemessa.Text);
                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesContaCobranca.Existe(Conta.IDContaCobranca))
                {
                    Conta.IDContaCobranca = Sequence.GetNextID("CONTACOBRANCA", "IDCONTACOBRANCA");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesContaCobranca.Salvar(Conta, Op))
                    throw new Exception("Não foi possível salvar a Conta Cobrança.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Conta Cobrança salva com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_ContaCobranca_KeyDown(object sender, KeyEventArgs e)
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