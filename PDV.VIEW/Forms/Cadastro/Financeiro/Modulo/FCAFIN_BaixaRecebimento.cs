using MetroFramework;
using MetroFramework.Forms;
using NFe.Classes.Informacoes.Pagamento;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Financeiro;
using PDV.UTIL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.Financeiro.Modulo
{
    public partial class FCAFIN_BaixaRecebimento : DevExpress.XtraEditors.XtraForm
    {
        public BaixaRecebimento BaixaRec = null;
        private ContaReceber ContaRecebimento = null;
        public bool Salvou = false;
        public bool botaoSalvar = false;
        private List<ContaBancaria> Contas = null;
        private List<HistoricoFinanceiro> Historicos = null;
        private List<FormaDePagamento> Formas = null;
        public DataTable Cheques = null;
        public decimal valorInicial;


        public FCAFIN_BaixaRecebimento(ContaReceber _ContaRecebimento, BaixaRecebimento _BaixaRec)
        {
            InitializeComponent();
            ContaRecebimento = _ContaRecebimento;
            BaixaRec = _BaixaRec;

            Contas = FuncoesContaBancaria.GetContasBancarias();
            Historicos = FuncoesHistoricoFinanceiro.GetHistoricosFinanceiros();
            Formas = FuncoesFormaDePagamento.GetFormasPagamento();

            ovCMB_ContaBancaria.DataSource = Contas;
            ovCMB_ContaBancaria.ValueMember = "IDCONTABANCARIA";
            ovCMB_ContaBancaria.DisplayMember = "NOME";
            ovCMB_ContaBancaria.SelectedItem = null;

            ovCMB_HistoricoFinanceiro.DataSource = Historicos;
            ovCMB_HistoricoFinanceiro.ValueMember = "IDHISTORICOFINANCEIRO";
            ovCMB_HistoricoFinanceiro.DisplayMember = "DESCRICAO";
            ovCMB_HistoricoFinanceiro.SelectedItem = null;

            ovCMB_FormaPagamento.DataSource = Formas;
            ovCMB_FormaPagamento.ValueMember = "IDFORMADEPAGAMENTO";
            ovCMB_FormaPagamento.DisplayMember = "identificacaodescricaoformabandeira";
            ovCMB_FormaPagamento.SelectedItem = null;

            PreencherTela();

            valorInicial = BaixaRec.Valor;

            metroTabControl2.SelectedTab = metroTabPage5;

            ovTXT_Valor.AplicaAlteracoes();
            ovTXT_Multa.AplicaAlteracoes();
            ovTXT_Juros.AplicaAlteracoes();
            ovTXT_Desconto.AplicaAlteracoes();
            ovTXT_Total.AplicaAlteracoes();

            ovTXT_ValorRec.AplicaAlteracoes();
            ovTXT_MultaRec.AplicaAlteracoes();
            ovTXT_JurosRec.AplicaAlteracoes();
            ovTXT_DescontoRec.AplicaAlteracoes();
            ovTXT_TotalRec.AplicaAlteracoes();
            ovTXT_SaldoRec.AplicaAlteracoes();
        }

        private void PreencherTela()
        {
            ovTXT_ValorRec.Value = ContaRecebimento.Valor;
            ovTXT_MultaRec.Value = ContaRecebimento.Multa;
            ovTXT_JurosRec.Value = ContaRecebimento.Juros;
            ovTXT_DescontoRec.Value = ContaRecebimento.Desconto;
            ovTXT_SaldoRec.Value = ContaRecebimento.Saldo;
            ovTXT_TotalRec.Value = (ContaRecebimento.Valor - ContaRecebimento.Desconto) + ContaRecebimento.Multa + ContaRecebimento.Juros;

            ovTXT_Valor.Value = BaixaRec.Valor != 0 ? BaixaRec.Valor : ContaRecebimento.Saldo;
            ovTXT_Multa.Value = BaixaRec.Multa;
            ovTXT_Juros.Value = BaixaRec.Juros;
            ovTXT_Desconto.Value = BaixaRec.Desconto;
            ovTXT_Total.Value = (BaixaRec.Valor - BaixaRec.Desconto) + BaixaRec.Juros + BaixaRec.Multa;
            ovTXT_Baixa.Value = BaixaRec.Baixa;

            ovCMB_ContaBancaria.SelectedItem = Contas.Where(o => o.IDContaBancaria == BaixaRec.IDContaBancaria).FirstOrDefault();
            ovCMB_FormaPagamento.SelectedItem = Formas.Where(o => o.IDFormaDePagamento == BaixaRec.IDFormaDePagamento).FirstOrDefault();
            ovCMB_HistoricoFinanceiro.SelectedItem = Historicos.Where(o => o.IDHistoricoFinanceiro == BaixaRec.IDHistoricoFinanceiro).FirstOrDefault();
            ovTXT_Complemento.Text = BaixaRec.ComplmHisFin;

            CarregarCheques(true);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Salvou = false;
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validar())
                    return;

                BaixaRec.Valor = ovTXT_Valor.Value;
                BaixaRec.Multa = ovTXT_Multa.Value;
                BaixaRec.Juros = ovTXT_Juros.Value;
                BaixaRec.Desconto = ovTXT_Desconto.Value;
                BaixaRec.Baixa = ovTXT_Baixa.Value;

                BaixaRec.IDContaBancaria = (ovCMB_ContaBancaria.SelectedItem as ContaBancaria).IDContaBancaria;
                BaixaRec.IDFormaDePagamento = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento;
                BaixaRec.IDHistoricoFinanceiro = (ovCMB_HistoricoFinanceiro.SelectedItem as HistoricoFinanceiro).IDHistoricoFinanceiro;
                BaixaRec.ComplmHisFin = ovTXT_Complemento.Text;

                Salvou = true;
                Close();
                botaoSalvar = true;
            }
            catch (Exception Ex)
            {
                Salvou = false;
                MessageBox.Show(this, Ex.Message, "BAIXA DE RECEBIMENTO");
            }
        }

        private bool Validar()
        {
            if (ovCMB_ContaBancaria.SelectedItem == null)
                throw new Exception("Selecione o Portador.");

            if (ovCMB_FormaPagamento.SelectedItem == null)
                throw new Exception("Selecione a Forma de Pagamento.");

            if (ovCMB_HistoricoFinanceiro.SelectedItem == null)
                throw new Exception("Selecione o Histórico Financeiro.");
            if(ovTXT_Valor.Value > ovTXT_SaldoRec.Value + valorInicial)
                throw new Exception("O Valor Inserido Ultrapassa o Saldo.");

            return true;
        }

        private bool ValidaFormaPagamento()
        {
            if (ovCMB_FormaPagamento.SelectedItem == null)
            {
                MessageBox.Show(this, "Selecione a Forma de Pagamento.", "BAIXA DE RECEBIMENTO");
                return false;
            }

            if (((FormaPagamento)Enum.Parse(typeof(FormaPagamento), (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).Codigo.ToString())) != FormaPagamento.fpCheque)
            {
                MessageBox.Show(this, "A Forma de Pagamento não é Cheque.", "BAIXA DE RECEBIMENTO");
                return false;
            }
            return true;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (!ValidaFormaPagamento())
                return;

            FCAFIN_ChequeRecebimento Form = new FCAFIN_ChequeRecebimento(new ChequeContaReceber());
            Form.ShowDialog(this);
            if (Form.Salvou)
            {
                DataRow dr = Cheques.NewRow();
                dr["IDCHEQUECONTARECEBER"] = Sequence.GetNextID("CHEQUECONTARECEBER", "IDCHEQUECONTARECEBER");
                dr["NUMERO"] = Form.ChequeRecebimento.Numero;
                dr["EMISSAO"] = Form.ChequeRecebimento.Emissao;
                dr["VENCIMENTO"] = Form.ChequeRecebimento.Vencimento;
                dr["VALOR"] = Form.ChequeRecebimento.Valor;
                dr["CRUZADO"] = Form.ChequeRecebimento.Cruzado;
                dr["COMPENSADO"] = Form.ChequeRecebimento.Compensado;
                dr["REPASSE"] = Form.ChequeRecebimento.Repasse;
                dr["DEVOLVIDO"] = Form.ChequeRecebimento.Devolvido;

                dr["DATACOMPENSACAO"] = DBNull.Value;
                if (Form.ChequeRecebimento.DataCompensacao.HasValue)
                    dr["DATACOMPENSACAO"] = Form.ChequeRecebimento.DataCompensacao;

                dr["DATADEVOLUCAO"] = DBNull.Value;
                if (Form.ChequeRecebimento.DataDevolucao.HasValue)
                    dr["DATADEVOLUCAO"] = Form.ChequeRecebimento.DataDevolucao;

                dr["DATAREPASSE"] = DBNull.Value;
                if (Form.ChequeRecebimento.DataRepasse.HasValue)
                    dr["DATAREPASSE"] = Form.ChequeRecebimento.DataRepasse;

                dr["OBSREPASSE"] = Form.ChequeRecebimento.ObsRepasse;
                dr["IDBAIXARECEBIMENTO"] = BaixaRec.IDBaixaRecebimento;
                Cheques.Rows.Add(dr);
            }
            CarregarCheques(false);
        }

        private void CarregarCheques(bool Banco)
        {
            if (Banco)
                Cheques = FuncoesChequesCtaReceber.GetChequeContaReceber(BaixaRec.IDBaixaRecebimento);

            gridControl1.DataSource = Cheques;
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView.BestFitColumns();
            AjustaTextHeaderCheques();
        }

        private void AjustaTextHeaderCheques()
        {
            gridView.Columns[0].Visible = false;
            gridView.Columns[1].Caption = "NÚMERO";
            gridView.Columns[2].Caption = "EMISSÃO";
            gridView.Columns[3].Caption = "VENCIMENTO";
            gridView.Columns[4].Caption = "VALOR";
            for (int i = 5; i < 14; i++)
            {
                gridView.Columns[i].Visible = false;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (!ValidaFormaPagamento())
                return;

            try
            {
                Cheques.DefaultView.RowFilter = "[IDCHEQUECONTARECEBER] = " +  decimal.Parse(gridView.GetRowCellValue(gridView.FocusedRowHandle, "idchequecontareceber").ToString());

                FCAFIN_ChequeRecebimento Form = new FCAFIN_ChequeRecebimento(EntityUtil<ChequeContaReceber>.ParseDataRow(Cheques.DefaultView[0].Row));
                Form.ShowDialog(this);
                if (Form.Salvou)
                {
                    foreach (DataRowView drView in Cheques.DefaultView)
                    {
                        drView.BeginEdit();
                        drView["NUMERO"] = Form.ChequeRecebimento.Numero;
                        drView["EMISSAO"] = Form.ChequeRecebimento.Emissao;
                        drView["VENCIMENTO"] = Form.ChequeRecebimento.Vencimento;
                        drView["VALOR"] = Form.ChequeRecebimento.Valor;
                        drView["CRUZADO"] = Form.ChequeRecebimento.Cruzado;
                        drView["COMPENSADO"] = Form.ChequeRecebimento.Compensado;
                        drView["REPASSE"] = Form.ChequeRecebimento.Repasse;
                        drView["DEVOLVIDO"] = Form.ChequeRecebimento.Devolvido;

                        drView["DATACOMPENSACAO"] = DBNull.Value;
                        if (Form.ChequeRecebimento.DataCompensacao.HasValue)
                            drView["DATACOMPENSACAO"] = Form.ChequeRecebimento.DataCompensacao;

                        drView["DATADEVOLUCAO"] = DBNull.Value;
                        if (Form.ChequeRecebimento.DataDevolucao.HasValue)
                            drView["DATADEVOLUCAO"] = Form.ChequeRecebimento.DataDevolucao;

                        drView["DATAREPASSE"] = DBNull.Value;
                        if (Form.ChequeRecebimento.DataRepasse.HasValue)
                            drView["DATAREPASSE"] = Form.ChequeRecebimento.DataRepasse;

                        drView["OBSREPASSE"] = Form.ChequeRecebimento.ObsRepasse;
                        drView["IDBAIXARECEBIMENTO"] = BaixaRec.IDBaixaRecebimento;
                        drView.EndEdit();
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "BAIXA RECEBIMENTO");
            }
            finally
            {
                Cheques.DefaultView.RowFilter = string.Empty;
                CarregarCheques(false);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (!ValidaFormaPagamento())
                return;

            if (MessageBox.Show(this, "Deseja remover o Cheque selecionado?", "BAIXA RECEBIMENTO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    Cheques.DefaultView.RowFilter = "[IDCHEQUECONTARECEBER] = " + decimal.Parse(gridView.GetRowCellValue(gridView.FocusedRowHandle, "idchequecontareceber").ToString());
                    foreach (DataRowView drView in Cheques.DefaultView)
                        drView.Delete();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, "BAIXA RECEBIMENTO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    Cheques.DefaultView.RowFilter = string.Empty;
                    CarregarCheques(false);
                }
            }
        }

        private void ovTXT_Valor_ValueChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }
        private void CalculaTotal()
        {
            ovTXT_Total.Value = (ovTXT_Valor.Value - ovTXT_Desconto.Value) + ovTXT_Multa.Value + ovTXT_Juros.Value;
        }

        private void FCAFIN_BaixaRecebimento_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {

        }

        private void metroButton8_Click(object sender, EventArgs e)
        {

        }
    }
}
