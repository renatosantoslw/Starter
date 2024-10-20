using MetroFramework;
using MetroFramework.Forms;
using NFe.Classes.Informacoes.Pagamento;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_FormaDePagamento : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE FORMA DE PAGAMENTO";
        private FormaDePagamento Forma = null;
        private List<DAO.Entidades.BandeiraCartao> Bandeiras = FuncoesBandeiraCartao.GetBandeiras();
        private List<FormaDePagamento> FormasPagamentoPreCadastradas = null;
        public static readonly decimal[] idsMenuItem = { 30 };

        public FCA_FormaDePagamento(FormaDePagamento _Forma)
        {
            InitializeComponent();
            Forma = _Forma;

            FormasPagamentoPreCadastradas = new List<FormaDePagamento>();
            FormasPagamentoPreCadastradas.AddRange(new[] {
                new FormaDePagamento(1,  "DINHEIRO"),
                new FormaDePagamento(2,  "CHEQUE"),
                new FormaDePagamento(3,  "CARTÃO DE CRÉDITO"),
                new FormaDePagamento(4,  "CARTÃO DE DÉBITO"),
                new FormaDePagamento(5,  "CRÉDITO LOJA"),
                new FormaDePagamento(10, "VALE ALIMENTAÇÃO"),
                new FormaDePagamento(11, "VALE REFEIÇÃO"),
                new FormaDePagamento(12, "VALE PRESENTE"),
                new FormaDePagamento(13, "VALE COMBUSTIVEL"),
                new FormaDePagamento(15, "BOLETO BANCARIO"),
                new FormaDePagamento(16, "DEPÓSITO BANCÁRIO"),
                new FormaDePagamento(17, "PAGAMENTO INSTANTÂNEO (PIX)"),
                new FormaDePagamento(18, "TRANSFERÊNCIA BANCÁRIA"),
                new FormaDePagamento(19, "PROGRAMA DE FIDELIDADE"),
                new FormaDePagamento(99, "OUTRO"),
            });

            ovCMB_FormaPagamento.DataSource = FormasPagamentoPreCadastradas;
            ovCMB_FormaPagamento.ValueMember = "CODIGO";
            ovCMB_FormaPagamento.DisplayMember = "DESCRICAO";

            ovCMB_Bandeiras.ValueMember = "IDBANDEIRACARTAO";
            ovCMB_Bandeiras.DisplayMember = "DESCRICAO";
            ovCMB_Bandeiras.DataSource = Bandeiras;
            ovCMB_Bandeiras.SelectedItem = null;

            PreencherTela();
        }
        public decimal GetFormaDePagamentoID() {return Forma.IDFormaDePagamento; }
        private void PreencherTela()
        {
            ovCMB_FormaPagamento.SelectedItem = FormasPagamentoPreCadastradas.Where(o => o.Codigo == Forma.Codigo).FirstOrDefault();
            if (Forma.IDBandeiraCartao.HasValue)
            {
                ovCMB_Bandeiras.SelectedItem = Bandeiras.Where(o => o.IDBandeiraCartao == Forma.IDBandeiraCartao).FirstOrDefault();
            }

            ovCKB_Ativo.Checked = Forma.Ativo == 1;
            ovCKB_TEF.Checked = Forma.TEF == 1 ? true : false;
            pdvCheckBox.Checked = Forma.PDV == 1 ? true : false;
            checkBoxFiscal.Checked = Forma.FISCAL == 1 ? true : false;
            ovTXT_Identificacao.Text = Forma.Identificacao;

            if (Forma.Transacao == 1)
                radioButtonAVista.Checked = true;
            else
                radioButtonAPrazo.Checked = true;

            usaCalendarioComercialcomboBox.SelectedIndex = Forma.Usa_Calendario_Comercial == "S" ? 0 : -1;
            parcelaTextBox.Text = Forma.Qtd_Parcelas.ToString();
            fatorduplicataEntradaTextBox.Text = Forma.Fator_Dup_Com_Entrada.ToString();
            fatorDuplicataSemEntradaTextBox.Text = Forma.Fator_Dup_Sem_Entrada.ToString();
            fatorChequeComEntradaTextBox.Text = Forma.Fator_Cheq_Com_Entrada.ToString();
            fatorChequeSemEntradaTextBox.Text = Forma.Fator_Cheq_Sem_Entrada.ToString();
            diasIntervaloTextBox.Text = Forma.Dias_Intervalo.ToString();
            periodicidadeMetroComboBox.Text = Forma.Periodicidade;
        }

        private void ovBTN_Cancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void ovBTN_Salvar_Click(object sender, System.EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (ovCMB_FormaPagamento.SelectedItem == null)
                {
                    throw new Exception("Selecione a Forma de Pagamento");
                }
                if (parcelaTextBox.Value <1)
                {
                    throw new Exception("O número de parcelas não pode ser menor que 0");
                }
                if (periodicidadeMetroComboBox.SelectedIndex == -1)
                {
                    throw new Exception("Informe a periodicidade");
                }

                switch ((FormaPagamento)Enum.Parse(typeof(FormaPagamento), (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).Codigo.ToString()))
                {
                    case FormaPagamento.fpCartaoCredito:
                    case FormaPagamento.fpCartaoDebito:
                    case FormaPagamento.fpValeAlimentacao:
                    case FormaPagamento.fpValeRefeicao:
                        if (ovCMB_Bandeiras.SelectedItem == null)
                        {
                            throw new Exception("Selecione a Bandeira.");
                        }

                        break;
                }

                Forma.Codigo = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).Codigo;
                Forma.Descricao = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).Descricao;
                Forma.Ativo = ovCKB_Ativo.Checked ? 1 : 0;
                Forma.TEF = ovCKB_TEF.Checked ? 1 : 0;
                Forma.PDV = pdvCheckBox.Checked ? 1 : 0;
                Forma.FISCAL = checkBoxFiscal.Checked ? 1 : 0;
                Forma.Identificacao = ovTXT_Identificacao.Text;

                Forma.IDBandeiraCartao = null;
                if (ovCMB_Bandeiras.SelectedItem != null)
                {
                    Forma.IDBandeiraCartao = (ovCMB_Bandeiras.SelectedItem as DAO.Entidades.BandeiraCartao).IDBandeiraCartao;
                }

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesFormaDePagamento.Existe(Forma.IDFormaDePagamento))
                {
                    Forma.IDFormaDePagamento = Sequence.GetNextID("FORMADEPAGAMENTO", "IDFORMADEPAGAMENTO");
                    Op = DAO.Enum.TipoOperacao.INSERT;
                }
                Forma.Transacao = radioButtonAVista.Checked ? FormaDePagamento.AVista : FormaDePagamento.APrazo;
                Forma.Usa_Calendario_Comercial = usaCalendarioComercialcomboBox.Text;
                Forma.Qtd_Parcelas = parcelaTextBox.Text != string.Empty ? int.Parse(parcelaTextBox.Text) : 1;
                Forma.Dias_Intervalo = int.Parse(diasIntervaloTextBox.Text);
                Forma.Fator_Dup_Com_Entrada = fatorduplicataEntradaTextBox.Text != string.Empty ? decimal.Parse(fatorduplicataEntradaTextBox.Text) : 0;
                Forma.Fator_Dup_Sem_Entrada = fatorDuplicataSemEntradaTextBox.Text != string.Empty ? decimal.Parse(fatorDuplicataSemEntradaTextBox.Text) : 0;
                Forma.Fator_Cheq_Com_Entrada = fatorChequeComEntradaTextBox.Text != string.Empty ? decimal.Parse(fatorChequeComEntradaTextBox.Text) : 0;
                Forma.Fator_Cheq_Sem_Entrada = fatorChequeSemEntradaTextBox.Text != string.Empty ? decimal.Parse(fatorChequeSemEntradaTextBox.Text) : 0;
                Forma.Periodicidade = periodicidadeMetroComboBox.Text;

                if (!FuncoesFormaDePagamento.Salvar(Forma, Op))
                {
                    throw new Exception("Não foi possível salvar a Forma de Pagamento.");
                }

                PDVControlador.Commit();
                MessageBox.Show(this, "Forma de Pagamento salva com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ovCMB_FormaPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ovCMB_FormaPagamento.SelectedItem == null)
            {
                ovCMB_Bandeiras.Enabled = false;
                ovCMB_Bandeiras.SelectedItem = null;
                label1.Font = new System.Drawing.Font("Tahoma", 8);
                label1.Text = "Bandeira:";
            }
            else
            {
                switch ((FormaPagamento)Enum.Parse(typeof(FormaPagamento), (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).Codigo.ToString()))
                {
                    case FormaPagamento.fpCartaoCredito:
                    case FormaPagamento.fpCartaoDebito:
                    case FormaPagamento.fpValeAlimentacao:
                    case FormaPagamento.fpValeRefeicao:
                        ovCMB_Bandeiras.Enabled = true;
                        label1.Font = new System.Drawing.Font("Tahoma",8, System.Drawing.FontStyle.Bold);
                        label1.Text = "* Bandeira:";
                        break;
                    default:
                        ovCMB_Bandeiras.Enabled = false;
                        ovCMB_Bandeiras.SelectedItem = null;
                        label1.Font = new System.Drawing.Font("Tahoma",8);
                        label1.Text = "Bandeira:";
                        break;
                }
            }
        }

        private void FCA_FormaDePagamento_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void desabilitarNumeroDeParcelas_Tick(object sender, EventArgs e)
        {
            parcelaTextBox.Enabled = !radioButtonAVista.Checked;
            if (radioButtonAVista.Checked)
                parcelaTextBox.Value = 1;
        }

    }
}
