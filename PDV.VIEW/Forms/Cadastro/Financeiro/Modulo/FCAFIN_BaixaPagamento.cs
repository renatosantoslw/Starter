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
    public partial class FCAFIN_BaixaPagamento : DevExpress.XtraEditors.XtraForm
    {
        public BaixaPagamento BaixaPag = null;      
        private ContaPagar ContaPagamento = null;
        public bool Salvou = false;
        public bool botaoSalvar = false;
        private List<ContaBancaria> Contas = null;
        private List<HistoricoFinanceiro> Historicos = null;
        private List<FormaDePagamento> Formas = null;
        public DataTable Cheques = null;
        public decimal valorInicial;

        public FCAFIN_BaixaPagamento(ContaPagar _ContaPagamento, BaixaPagamento _BaixaPag)
        {
            InitializeComponent();
            ContaPagamento = _ContaPagamento;
            BaixaPag = _BaixaPag;

            Contas = FuncoesContaBancaria.GetContasBancarias();
            Historicos = FuncoesHistoricoFinanceiro.GetHistoricosFinanceiros();
            Formas = FuncoesFormaDePagamento.GetFormasPagamento();

            ovCMB_ContaBancaria.DataSource = Contas;
            ovCMB_ContaBancaria.ValueMember = "idcontabancaria";
            ovCMB_ContaBancaria.DisplayMember = "nome";
            ovCMB_ContaBancaria.SelectedItem = null;

            ovCMB_HistoricoFinanceiro.DataSource = Historicos;
            ovCMB_HistoricoFinanceiro.ValueMember = "idhistoricofinanceiro";
            ovCMB_HistoricoFinanceiro.DisplayMember = "descricao";
            ovCMB_HistoricoFinanceiro.SelectedItem = null;

            ovCMB_FormaPagamento.DataSource = Formas;
            ovCMB_FormaPagamento.ValueMember = "idformadepagamento";
            ovCMB_FormaPagamento.DisplayMember = "identificacaodescricaoformabandeira";
            ovCMB_FormaPagamento.SelectedItem = null;


            PreencherTela();

            valorInicial = BaixaPag.Valor;

            metroTabControl2.SelectedTab = metroTabPage5;

            ovTXT_Valor.AplicaAlteracoes();
            ovTXT_Multa.AplicaAlteracoes();
            ovTXT_Juros.AplicaAlteracoes();
            ovTXT_Desconto.AplicaAlteracoes();
            ovTXT_Total.AplicaAlteracoes();

            ovTXT_ValorPag.AplicaAlteracoes();
            ovTXT_MultaPag.AplicaAlteracoes();
            ovTXT_JurosPag.AplicaAlteracoes();
            ovTXT_DescontoRec.AplicaAlteracoes();
            ovTXT_TotalPag.AplicaAlteracoes();
            ovTXT_SaldoPag.AplicaAlteracoes();
        }

        private void PreencherTela()
        {
            ovTXT_ValorPag.Value = ContaPagamento.Valor;
            ovTXT_MultaPag.Value = ContaPagamento.Multa;
            ovTXT_JurosPag.Value = ContaPagamento.Juros;
            ovTXT_DescontoRec.Value = ContaPagamento.Desconto;
            ovTXT_SaldoPag.Value = ContaPagamento.Saldo;
            ovTXT_TotalPag.Value = (ContaPagamento.Valor - ContaPagamento.Desconto) + ContaPagamento.Multa + ContaPagamento.Juros;

            ovTXT_Valor.Value = BaixaPag.Valor != 0 ? BaixaPag.Valor : ContaPagamento.Saldo;;
            ovTXT_Multa.Value = BaixaPag.Multa;
            ovTXT_Juros.Value = BaixaPag.Juros;
            ovTXT_Desconto.Value = BaixaPag.Desconto;
            ovTXT_Total.Value = (BaixaPag.Valor - BaixaPag.Desconto) + BaixaPag.Juros + BaixaPag.Multa;
            ovTXT_Baixa.Value = BaixaPag.Baixa;

            ovCMB_ContaBancaria.SelectedItem = Contas.Where(o => o.IDContaBancaria == BaixaPag.IDContaBancaria).FirstOrDefault();
            ovCMB_FormaPagamento.SelectedItem = Formas.Where(o => o.IDFormaDePagamento == BaixaPag.IDFormaDePagamento).FirstOrDefault();
            ovCMB_HistoricoFinanceiro.SelectedItem = Historicos.Where(o => o.IDHistoricoFinanceiro == BaixaPag.IDHistoricoFinanceiro).FirstOrDefault();
            ovTXT_Complemento.Text = BaixaPag.ComplmHisFin;

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

                BaixaPag.Valor = ovTXT_Valor.Value;
                BaixaPag.Multa = ovTXT_Multa.Value;
                BaixaPag.Juros = ovTXT_Juros.Value;
                BaixaPag.Desconto = ovTXT_Desconto.Value;
                BaixaPag.Baixa = ovTXT_Baixa.Value;

                BaixaPag.IDContaBancaria = (ovCMB_ContaBancaria.SelectedItem as ContaBancaria).IDContaBancaria;
                BaixaPag.IDFormaDePagamento = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento;
                BaixaPag.IDHistoricoFinanceiro = (ovCMB_HistoricoFinanceiro.SelectedItem as HistoricoFinanceiro).IDHistoricoFinanceiro;
                BaixaPag.ComplmHisFin = ovTXT_Complemento.Text;
                Salvou = true;
                Close();
                botaoSalvar = true;
            }
            catch (Exception Ex)
            {
                Salvou = false;
                MessageBox.Show(this, Ex.Message, "BAIXA DE PAGAMENTO");
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
            if (ovTXT_Valor.Value > ovTXT_SaldoPag.Value + valorInicial)             
                throw new Exception("O Valor Inserido Ultrapassa o Saldo.");

            return true;
        }

        private bool ValidaFormaPagamento()
        {
            if (ovCMB_FormaPagamento.SelectedItem == null)
            {
                MessageBox.Show(this, "Selecione a Forma de Pagamento.", "BAIXA DE PAGAMENTO");
                return false;
            }

            if (((FormaPagamento)Enum.Parse(typeof(FormaPagamento), (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).Codigo.ToString())) != FormaPagamento.fpCheque)
            {
                MessageBox.Show(this, "A Forma de Pagamento não é Cheque.", "BAIXA DE PAGAMENTO");
                return false;
            }
            return true;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (!ValidaFormaPagamento())
                return;

            FCAFIN_ChequePagamento Form = new FCAFIN_ChequePagamento(new ChequeContaPagar(), ovCMB_ContaBancaria.SelectedItem == null?-1:(ovCMB_ContaBancaria.SelectedItem as ContaBancaria).IDContaBancaria);
            Form.ShowDialog(this);
            if (Form.Salvou)
            {
                DataRow dr = Cheques.NewRow();
                dr["IDCHEQUECONTAPAGAR"] = Sequence.GetNextID("CHEQUECONTAPAGAR", "IDCHEQUECONTAPAGAR");
                dr["NUMERO"] = Form.ChequePagamento.Numero;
                dr["EMISSAO"] = Form.ChequePagamento.Emissao;
                dr["VENCIMENTO"] = Form.ChequePagamento.Vencimento;
                dr["VALOR"] = Form.ChequePagamento.Valor;
                dr["CRUZADO"] = Form.ChequePagamento.Cruzado;
                dr["COMPENSADO"] = Form.ChequePagamento.Compensado;
                dr["DEVOLVIDO"] = Form.ChequePagamento.Devolvido;

                dr["DATACOMPENSACAO"] = DBNull.Value;
                if (Form.ChequePagamento.DataCompensacao.HasValue)
                    dr["DATACOMPENSACAO"] = Form.ChequePagamento.DataCompensacao;

                dr["DATADEVOLUCAO"] = DBNull.Value;
                if (Form.ChequePagamento.DataDevolucao.HasValue)
                    dr["DATADEVOLUCAO"] = Form.ChequePagamento.DataDevolucao;

                dr["IDBAIXAPAGAMENTO"] = BaixaPag.IDBaixaPagamento;

                dr["IDTALONARIO"] = DBNull.Value;
                if (Form.ChequePagamento.IDTalonario.HasValue)
                    dr["IDTALONARIO"] = Form.ChequePagamento.IDTalonario;

                Cheques.Rows.Add(dr);
            }
            CarregarCheques(false);
        }

        private void CarregarCheques(bool Banco)
        {
            if (Banco)
                Cheques = FuncoesChequesCtaPagar.GetChequeContaPagar(BaixaPag.IDBaixaPagamento);

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
            for (int i = 5; i < 12; i++)
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
                Cheques.DefaultView.RowFilter = "[IDCHEQUECONTAPAGAR] = " + decimal.Parse(gridView.GetRowCellValue(gridView.FocusedRowHandle, "idchequecontapagar").ToString());

                FCAFIN_ChequePagamento Form = new FCAFIN_ChequePagamento(EntityUtil<ChequeContaPagar>.ParseDataRow(Cheques.DefaultView[0].Row), (ovCMB_ContaBancaria.SelectedItem as ContaBancaria).IDContaBancaria);
                Form.ShowDialog(this);
                if (Form.Salvou)
                {
                    foreach (DataRowView drView in Cheques.DefaultView)
                    {
                        drView.BeginEdit();
                        drView["NUMERO"] = Form.ChequePagamento.Numero;
                        drView["EMISSAO"] = Form.ChequePagamento.Emissao;
                        drView["VENCIMENTO"] = Form.ChequePagamento.Vencimento;
                        drView["VALOR"] = Form.ChequePagamento.Valor;
                        drView["CRUZADO"] = Form.ChequePagamento.Cruzado;
                        drView["COMPENSADO"] = Form.ChequePagamento.Compensado;
                        drView["DEVOLVIDO"] = Form.ChequePagamento.Devolvido;

                        drView["DATACOMPENSACAO"] = DBNull.Value;
                        if (Form.ChequePagamento.DataCompensacao.HasValue)
                            drView["DATACOMPENSACAO"] = Form.ChequePagamento.DataCompensacao;

                        drView["DATADEVOLUCAO"] = DBNull.Value;
                        if (Form.ChequePagamento.DataDevolucao.HasValue)
                            drView["DATADEVOLUCAO"] = Form.ChequePagamento.DataDevolucao;

                        drView.EndEdit();
                        Cheques.DefaultView.RowFilter = string.Empty;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "BAIXA PAGAMENTO");
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

            if (MessageBox.Show(this, "Deseja remover o Cheque selecionado?", "BAIXA PAGAMENTO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    Cheques.DefaultView.RowFilter = "[IDCHEQUEContaPagar] = " + decimal.Parse(gridView.GetRowCellValue(gridView.FocusedRowHandle, "idchequecontapagar").ToString());
                    foreach (DataRowView drView in Cheques.DefaultView)
                        drView.Delete();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, "BAIXA PAGAMENTO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ovTXT_Total.Value = (ovTXT_Valor.Value - ovTXT_Desconto.Value) + ovTXT_Multa.Value + ovTXT_Juros.Value;
        }

        private void FCAFIN_BaixaPagamento_KeyDown(object sender, KeyEventArgs e)
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
