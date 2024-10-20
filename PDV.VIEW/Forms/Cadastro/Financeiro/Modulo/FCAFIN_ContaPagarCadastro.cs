using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.Financeiro.Modulo
{
    public partial class FCAFIN_ContaPagarCadastro : DevExpress.XtraEditors.XtraForm
    {
        private List<ContaBancaria> Contas = null;
        private List<CentroCusto> CentrosCusto = null;
        private List<HistoricoFinanceiro> Historicos = null;
        private List<FormaDePagamento> FormasPagamento = null;
        private List<Fornecedor> Fornecedores = null;
        private DataTable Baixas = null;

        private Dictionary<decimal, DataTable> Cheques = null;

        private string NOME_TELA = "CADASTRO DE CONTAS A PAGAR";
        private ContaPagar Conta = null;

        public bool botaoSalvarBaixa = false;

        

        public FCAFIN_ContaPagarCadastro(ContaPagar _Conta)
        {
            Conta = _Conta;
            InitializeComponent();



            if(Conta.IDContaPagar > 0)
            {
                btn_Cancelar.Enabled = true;
                ordMaskedTextBox.Text = Conta.Ord;
            }
            

            ovTXT_Valor.AplicaAlteracoes();
            ovTXT_Multa.AplicaAlteracoes();
            ovTXT_Juros.AplicaAlteracoes();
            ovTXT_Desconto.AplicaAlteracoes();
            ovTXT_Saldo.AplicaAlteracoes();
            ovTXT_Total.AplicaAlteracoes();

            PreencherTela();
            metroTabControl2.SelectedTab = metroTabPage5;
            CarregarPermissoes();
        }

        private void CarregarPermissoes()
        {
            PermissoesUtil.VerificarPermissaoParaTela(FCA_ContaBancaria.idsMenuItem, ref buttonAdicionarContaBancaria);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_CentroCusto.idsMenuItem, ref buttonAdicionarCentroCusto);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_FormaDePagamento.idsMenuItem, ref buttonAdicionarFormaDePagamento);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_HistoricoFinanceiro.idsMenuItem, ref buttonAdicionarHistoricoFinanceiro);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_Fornecedor.idsMenuItem, ref buttonAdicionarFornecedor);
        }


        private void PreencherFornecedor()
        {
            Fornecedores = FuncoesFornecedor.GetFornecedores();
            ovCMB_Fornecedor.DataSource = Fornecedores;
            ovCMB_Fornecedor.ValueMember = "idfornecedor";
            ovCMB_Fornecedor.DisplayMember = "descricao";
            ovCMB_Fornecedor.SelectedItem = Fornecedores.Where(o => o.IDFornecedor == Conta.IDFornecedor).FirstOrDefault();
        }

        private void PreencherFormaPagamento()
        {
            FormasPagamento = FuncoesFormaDePagamento.GetFormasPagamento();
            ovCMB_FormaPagamento.DataSource = FormasPagamento;
            ovCMB_FormaPagamento.ValueMember = "idformadepagamento";
            ovCMB_FormaPagamento.DisplayMember = "identificacaodescricaoformabandeira";
            ovCMB_FormaPagamento.Enabled = Conta.IDContaPagar == -1;
            ovCMB_FormaPagamento.SelectedItem = FormasPagamento.Where(o => o.IDFormaDePagamento == Conta.IDFormaDePagamento).FirstOrDefault();
        }

        private void PreencherHistorico()
        {
            Historicos = FuncoesHistoricoFinanceiro.GetHistoricosFinanceiros();
            ovCMB_HistoricoFinanceiro.DataSource = Historicos;
            ovCMB_HistoricoFinanceiro.ValueMember = "idhistoricofinanceiro";
            ovCMB_HistoricoFinanceiro.DisplayMember = "descricao";
            ovCMB_HistoricoFinanceiro.SelectedItem = Historicos.Where(o => o.IDHistoricoFinanceiro == Conta.IDHistoricoFinanceiro).FirstOrDefault();
        }

        private void PreencherCentroCusto()
        {
            CentrosCusto = FuncoesCentroCusto.GetCentrosCusto(CentroCusto.Entrada);
            ovCMB_CentroCusto.DataSource = CentrosCusto;
            ovCMB_CentroCusto.ValueMember = "idcentrocusto";
            ovCMB_CentroCusto.DisplayMember = "descricao";
            ovCMB_CentroCusto.SelectedItem = CentrosCusto.Where(o => o.IDCentroCusto == Conta.IDCentroCusto).FirstOrDefault();
        }

        private void PreencherContaBancaria()
        {
            Contas = FuncoesContaBancaria.GetContasBancarias();
            ovCMB_ContaBancaria.DataSource = Contas;
            ovCMB_ContaBancaria.ValueMember = "idcontabancaria";
            ovCMB_ContaBancaria.DisplayMember = "nome";
            ovCMB_ContaBancaria.SelectedItem = Contas.Where(o => o.IDContaBancaria == Conta.IDContaBancaria).FirstOrDefault();
        }

        private void PreencherTela()
        {
            Cheques = new Dictionary<decimal, DataTable>();

            PreencherContaBancaria();
            PreencherCentroCusto();
            PreencherHistorico();
            PreencherFormaPagamento();
            PreencherFornecedor();


           
           
            
            
            
            ovTXT_Emissao.Value = Conta.Emissao;
            ovTXT_Vencimento.Value = Conta.Vencimento;
            ovTXT_Fluxo.Value = Conta.Fluxo;
            ovTXT_Origem.Text = Conta.Origem;
            ovTXT_Complemento.Text = Conta.ComplmHisFin;
            ovTXT_Titulo.Text = Conta.Titulo;

            /* Valores */
            ovTXT_Valor.Value = Conta.Valor;
            ovTXT_Multa.Value = Conta.Multa;
            ovTXT_Juros.Value = Conta.Juros;
            ovTXT_Desconto.Value = Conta.Desconto;
            ovTXT_Saldo.Value = Conta.Saldo;
            ovTXT_Total.Value = Conta.ValorTotal;
            CarregarBaixas(true);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            SalvarTudo();
        }
        public void SalvarTudo()
        {
            try
            {
                PDVControlador.BeginTransaction();
                if (!Validar())
                    return;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (Conta.IDContaPagar == -1)
                {

                    Op = TipoOperacao.INSERT;
                    Conta.IDContaPagar = Sequence.GetNextID("CONTAPAGAR", "IDCONTAPAGAR");
                    Conta.Situacao = 1;
                }

                Conta.IDContaBancaria = null;
                if (ovCMB_ContaBancaria.SelectedItem != null)
                    Conta.IDContaBancaria = (ovCMB_ContaBancaria.SelectedItem as ContaBancaria).IDContaBancaria;

                Conta.IDCentroCusto = (ovCMB_CentroCusto.SelectedItem as CentroCusto).IDCentroCusto;
                
                Conta.IDFormaDePagamento = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento;
                Conta.IDHistoricoFinanceiro = (ovCMB_HistoricoFinanceiro.SelectedItem as HistoricoFinanceiro).IDHistoricoFinanceiro;
                Conta.IDFornecedor = (ovCMB_Fornecedor.SelectedItem as Fornecedor).IDFornecedor;



                Conta.Parcela = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).Qtd_Parcelas;
                Conta.Emissao = ovTXT_Emissao.Value;
                Conta.Vencimento = ovTXT_Vencimento.Value;

                Conta.Fluxo = ovTXT_Fluxo.Value;
                Conta.Origem = ovTXT_Origem.Text;
                Conta.ComplmHisFin = ovTXT_Complemento.Text;
                Conta.Titulo = (string.IsNullOrEmpty(ovTXT_Titulo.Text) ? Conta.IDContaPagar.ToString() : ovTXT_Titulo.Text);

                /* Valores */
                Conta.Valor = ovTXT_Valor.Value;
                Conta.Multa = ovTXT_Multa.Value;
                Conta.Juros = ovTXT_Juros.Value;
                Conta.Desconto = ovTXT_Desconto.Value;
                Conta.Saldo = ovTXT_Saldo.Value;
                Conta.ValorTotal = ovTXT_Total.Value;
                Conta.Ord = ordMaskedTextBox.Text;


                if (Conta.Parcela > 1 && Op == TipoOperacao.INSERT)
                {
                    for (int i = 0; i < Conta.Parcela; i++)
                    {
                        Conta.IDContaPagar = Sequence.GetNextID("CONTAPAGAR", "IDCONTAPAGAR");
                        Conta.Ord = (i + 1).ToString();
                        Conta.Vencimento = Convert.ToDateTime(ovTXT_Vencimento.Text).AddMonths(i + 1);
                        Conta.ValorTotal = decimal.Parse(ovTXT_Total.Value.ToString()) / Conta.Parcela;
                        Conta.Valor = decimal.Parse(ovTXT_Valor.Value.ToString()) / Conta.Parcela;
                        Conta.Saldo = decimal.Parse(ovTXT_Saldo.Value.ToString()) / Conta.Parcela;
                        if (!FuncoesContaPagar.Salvar(Conta, Op))
                            throw new Exception("Não foi possível salvar o Lançamento.");
                    }
                }
                else
                {

                    if (Conta.Saldo < Conta.ValorTotal)
                        Conta.Situacao = 2;
                    
                    if (Conta.Saldo == 0)
                        Conta.Situacao = 3;
                    
                    if (Conta.Saldo == Conta.ValorTotal)
                        Conta.Situacao = 1;

                    if (!FuncoesContaPagar.Salvar(Conta, Op))
                        throw new Exception("Não foi possível salvar o Lançamento.");
                }


                SalvarBaixas();

                PDVControlador.Commit();
                MessageBox.Show(this, "Lançamento salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SalvarBaixas()
        {
            DataTable dt = ZeusUtil.GetChanges(Baixas, TipoOperacao.INSERT);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    dr["IDCONTAPAGAR"] = Conta.IDContaPagar;
                    BaixaPagamento BaixaPag = EntityUtil<BaixaPagamento>.ParseDataRow(dr);
                    if (!FuncoesBaixaPagamento.Salvar(BaixaPag, TipoOperacao.INSERT))
                        throw new Exception("Não foi possível salvar as Baixas.");

                    /* Movimentação Bancária */
                    if (!FuncoesMovimentoBancario.Salvar(new MovimentoBancario()
                    {
                        IDMovimentoBancario = Sequence.GetNextID("MOVIMENTOBANCARIO", "IDMOVIMENTOBANCARIO"),
                        IDContaBancaria = BaixaPag.IDContaBancaria,
                        IDNatureza = null,
                        Historico = FuncoesHistoricoFinanceiro.GetHistoricoFinanceiro(BaixaPag.IDHistoricoFinanceiro).Descricao,
                        Conciliacao = null,
                        Sequencia = Conta.Parcela,
                        DataMovimento = DateTime.Now,
                        Documento = $"{Conta.Titulo}_{BaixaPag.IDBaixaPagamento}T",
                        Tipo = 0,
                        Valor = BaixaPag.Valor,
                    }, TipoOperacao.INSERT))
                        throw new Exception("Não foi possível salvar o Movimento Bancário.");
                }

            dt = ZeusUtil.GetChanges(Baixas, TipoOperacao.UPDATE);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    dr["IDCONTAPAGAR"] = Conta.IDContaPagar;
                    if (!FuncoesBaixaPagamento.Salvar(EntityUtil<BaixaPagamento>.ParseDataRow(dr), TipoOperacao.UPDATE))
                        throw new Exception("Não foi possível salvar as Baixas.");
                }

            dt = ZeusUtil.GetChanges(Baixas, TipoOperacao.DELETE);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    if (!FuncoesBaixaPagamento.Remover(Convert.ToDecimal(dr["IDBAIXAPAGAMENTO"])))
                        throw new Exception("Não foi possível salvar as Baixas.");

                    if (!FuncoesMovimentoBancario.RemoverPorDocumento($"{Conta.Titulo}_{dr["IDBAIXAPAGAMENTO"]}T", 0))
                        throw new Exception("Não foi possível salvar o Movimento Bancário.");
                }

            /* Salvando os Cheques das Baixas */
            foreach (DataTable dtCheque in Cheques.Values)
            {
                dt = ZeusUtil.GetChanges(dtCheque, TipoOperacao.INSERT);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesChequesCtaPagar.Salvar(EntityUtil<ChequeContaPagar>.ParseDataRow(dr), TipoOperacao.INSERT))
                            throw new Exception("Não foi possível salvar os Cheques.");

                dt = ZeusUtil.GetChanges(dtCheque, TipoOperacao.UPDATE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesChequesCtaPagar.Salvar(EntityUtil<ChequeContaPagar>.ParseDataRow(dr), TipoOperacao.UPDATE))
                            throw new Exception("Não foi possível salvar os Cheques.");

                dt = ZeusUtil.GetChanges(dtCheque, TipoOperacao.DELETE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesChequesCtaPagar.Remover(Convert.ToDecimal(dr["IDCHEQUECONTAPAGAR"])))
                            throw new Exception("Não foi possível salvar os Cheques.");
            }
        }

        private bool Validar()
        {
            //if (ovCMB_Conta.SelectedItem == null)
            //    throw new Exception("Selecione a Conta Bancária.");

            if (ovCMB_CentroCusto.SelectedItem == null)
                throw new Exception("Selecione o Centro de Custo.");

            if (ovCMB_FormaPagamento.SelectedItem == null)
                throw new Exception("Selecione a Forma de Pagamento.");

            if (ovCMB_HistoricoFinanceiro.SelectedItem == null)
                throw new Exception("Selecione o Histórico Financeiro.");

            if (ovCMB_Fornecedor.SelectedItem == null)
                throw new Exception("Selecione o Fornecedor.");

            //if (ovCMB_Situacao.SelectedItem == null)
            //    throw new Exception("Selecione a Situação.");

            return true;
        }

        private void AjustaTextHeaderBaixas()
        {
            for (int i = 8; i < 14; i++)
            {
                gridViewBaixas.Columns[i].Visible = false;

            }
            gridViewBaixas.Columns[0].Visible = false;
            gridViewBaixas.Columns[1].Caption = "DATA BAIXA";
            gridViewBaixas.Columns[2].Caption = "CONTA BANCÁRIA";
            gridViewBaixas.Columns[3].Caption = "VALOR";
            gridViewBaixas.Columns[4].Caption = "MULTA";
            gridViewBaixas.Columns[5].Caption = "JUROS";
            gridViewBaixas.Columns[6].Caption = "DESCONTO";
            gridViewBaixas.Columns[7].Caption = "VALOR TOTAL";
        }

        private void CarregarBaixas(bool Banco)
        {
            if (Banco)
                Baixas = FuncoesBaixaPagamento.GetBaixas(Conta.IDContaPagar);

            gridControlBaixas.DataSource = Baixas;
            gridViewBaixas.OptionsBehavior.Editable = false;
            gridViewBaixas.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewBaixas.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridViewBaixas.BestFitColumns();
            AjustaTextHeaderBaixas();
        }

        private void VerificaCheques(decimal IDBaixa, bool Removeu, DataTable dtCheques)
        {
            if (Removeu && Cheques.ContainsKey(IDBaixa))
            {
                Cheques.Remove(IDBaixa);
                return;
            }

            Cheques[IDBaixa] = dtCheques;
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            try
            {
                NovaBaixa();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(this, "Para adicionar uma baixa preencha os campos obrigatórios da tela de IDENTIFICAÇÃO", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DesabilitarBotoes();
        }
       public void NovaBaixa()
        {
            if (Conta.Situacao != 3 && Conta.Situacao != 0)
            {
                Conta.Valor = ovTXT_Valor.Value;
                Conta.Multa = ovTXT_Multa.Value;
                Conta.Juros = ovTXT_Juros.Value;
                Conta.Desconto = ovTXT_Desconto.Value;
                Conta.Saldo = ovTXT_Saldo.Value;
                Conta.ValorTotal = ovTXT_Total.Value;

                FCAFIN_BaixaPagamento Form = new FCAFIN_BaixaPagamento(Conta, new BaixaPagamento()
                {
                    IDBaixaPagamento = Sequence.GetNextID("BAIXAPAGAMENTO", "IDBAIXAPAGAMENTO"),
                    IDContaBancaria = ovCMB_ContaBancaria.SelectedItem == null ? -1 : (ovCMB_ContaBancaria.SelectedItem as ContaBancaria).IDContaBancaria,
                    IDHistoricoFinanceiro = ovCMB_HistoricoFinanceiro.SelectedItem == null ? -1 : (ovCMB_HistoricoFinanceiro.SelectedItem as HistoricoFinanceiro).IDHistoricoFinanceiro,
                    Baixa = DateTime.Now,
                    IDFormaDePagamento = ovCMB_FormaPagamento.SelectedItem == null ? -1 : (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento
                });
                Form.ShowDialog(this);
                botaoSalvarBaixa = Form.botaoSalvar;

                if (Form.Salvou)
                {
                    DataRow dr = Baixas.NewRow();
                    dr["IDBAIXAPAGAMENTO"] = Form.BaixaPag.IDBaixaPagamento;
                    dr["BAIXA"] = Form.BaixaPag.Baixa;
                    dr["CONTABANCARIA"] = FuncoesContaBancaria.GetContaBancaria(Form.BaixaPag.IDContaBancaria).Nome;
                    dr["TOTAL"] = (Form.BaixaPag.Valor - Form.BaixaPag.Desconto) + Form.BaixaPag.Juros +
                                  Form.BaixaPag.Multa;
                    dr["VALOR"] = Form.BaixaPag.Valor;
                    dr["IDCONTAPAGAR"] = Conta.IDContaPagar;
                    dr["IDFORMADEPAGAMENTO"] = Form.BaixaPag.IDFormaDePagamento;
                    dr["IDCONTABANCARIA"] = Form.BaixaPag.IDContaBancaria;
                    dr["IDHISTORICOFINANCEIRO"] = Form.BaixaPag.IDHistoricoFinanceiro;
                    dr["COMPLMHISFIN"] = Form.BaixaPag.ComplmHisFin;
                    dr["MULTA"] = Form.BaixaPag.Multa;
                    dr["JUROS"] = Form.BaixaPag.Juros;
                    dr["DESCONTO"] = Form.BaixaPag.Desconto;
                    Baixas.Rows.Add(dr);
                    CarregarBaixas(false);
                    AtualizaSaldo();
                    VerificaCheques(Form.BaixaPag.IDBaixaPagamento, false, Form.Cheques);
                }
                

            }
            else if (Conta.Situacao == 3)
            {
                MessageBox.Show(this, "Esta conta já esta completamente baixada.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Conta.Situacao == 0)
            {
                MessageBox.Show(this, "Esta conta já esta cancelada.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            EditarBaixas();
            DesabilitarBotoes();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            DesabilitarBotoes();
            if (MessageBox.Show(this, "Deseja remover a Baixa selecionada?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {

                    decimal IDBaixa = decimal.Parse(gridViewBaixas.GetRowCellValue(gridViewBaixas.FocusedRowHandle, gridViewBaixas.Columns[0].FieldName).ToString()); 
                    Baixas.DefaultView.RowFilter = "[IDBAIXAPAGAMENTO] = " + IDBaixa;
                    foreach (DataRowView drView in Baixas.DefaultView)
                        drView.Delete();

                    VerificaCheques(IDBaixa, true, null);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    Baixas.DefaultView.RowFilter = string.Empty;
                    CarregarBaixas(false);
                    AtualizaSaldo();
                    
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
            AtualizaSaldo();
        }

        private void AtualizaSaldo()
        {
            if (Baixas == null)
                return;

            decimal ValorSaldo = ovTXT_Total.Value - Baixas.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["VALOR"]));
            ovTXT_Saldo.Value = ValorSaldo < 0 ? 0 : ValorSaldo;
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Conta.Situacao = 0;
                if (!FuncoesContaPagar.Salvar(Conta, TipoOperacao.UPDATE))
                    throw new Exception("Não foi possível salvar o Lançamento.");

                MessageBox.Show(this, "Cancelamento salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCAFIN_ContaPagar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
       
        private void EditarBaixas()
        {
            try
            {
                decimal IDBaixa = decimal.Parse(gridViewBaixas.GetRowCellValue(gridViewBaixas.FocusedRowHandle, "idbaixapagamento").ToString());
                Baixas.DefaultView.RowFilter = "[IDBAIXAPAGAMENTO] = " + IDBaixa;

                Conta.Valor = ovTXT_Valor.Value;
                Conta.Multa = ovTXT_Multa.Value;
                Conta.Juros = ovTXT_Juros.Value;
                Conta.Desconto = ovTXT_Desconto.Value;
                Conta.Saldo = ovTXT_Saldo.Value;
                Conta.ValorTotal = ovTXT_Total.Value;
                FCAFIN_BaixaPagamento Form = new FCAFIN_BaixaPagamento(Conta, EntityUtil<BaixaPagamento>.ParseDataRow(Baixas.DefaultView[0].Row));
                Form.ShowDialog(this);
                if (Form.Salvou)
                {
                    foreach (DataRowView drView in Baixas.DefaultView)
                    {
                        drView.BeginEdit();
                        drView["BAIXA"] = Form.BaixaPag.Baixa;
                        drView["CONTABANCARIA"] = FuncoesContaBancaria.GetContaBancaria(Form.BaixaPag.IDContaBancaria).Nome;
                        drView["VALOR"] = Form.BaixaPag.Valor;
                        drView["TOTAL"] = (Form.BaixaPag.Valor - Form.BaixaPag.Desconto) + Form.BaixaPag.Juros + Form.BaixaPag.Multa;
                        drView["IDCONTAPAGAR"] = Conta.IDContaPagar;
                        drView["IDFORMADEPAGAMENTO"] = Form.BaixaPag.IDFormaDePagamento;
                        drView["IDCONTABANCARIA"] = Form.BaixaPag.IDContaBancaria;
                        drView["IDHISTORICOFINANCEIRO"] = Form.BaixaPag.IDHistoricoFinanceiro;
                        drView["COMPLMHISFIN"] = Form.BaixaPag.ComplmHisFin;
                        drView["MULTA"] = Form.BaixaPag.Multa;
                        drView["JUROS"] = Form.BaixaPag.Juros;
                        drView["DESCONTO"] = Form.BaixaPag.Desconto;
                        drView.EndEdit();
                    }
                    VerificaCheques(IDBaixa, false, Form.Cheques);
                }
                Baixas.DefaultView.RowFilter = string.Empty;
                CarregarBaixas(false);
                AtualizaSaldo();
            }
            catch (NullReferenceException)
            {

            }
        }       

        private void gridControlBaixas_DoubleClick(object sender, EventArgs e)
        {
            EditarBaixas();
            DesabilitarBotoes();
        }
        private void DesabilitarBotoes()
        {
            metroButton7.Enabled = false;
            metroButton6.Enabled = false;
        }


        private void gridControlBaixas_Click(object sender, EventArgs e)
        {
            metroButton7.Enabled = true;
            metroButton6.Enabled = true;
        }

        private void buttonAdicionaPortador_Click(object sender, EventArgs e)
        {
            new FCA_ContaBancaria(new ContaBancaria()).ShowDialog();
            PreencherContaBancaria();
        }

        private void buttonAdicionaTipoTitulo_Click(object sender, EventArgs e)
        {
            new FCA_CentroCusto(new CentroCusto()).ShowDialog();
            PreencherCentroCusto();
        }

        private void buttonAdicionaFormaDePagamento_Click(object sender, EventArgs e)
        {
            new FCA_FormaDePagamento(new FormaDePagamento()).ShowDialog();
            PreencherFormaPagamento();
        }

        private void buttonHistoricoFinanceiro_Click(object sender, EventArgs e)
        {
            new FCA_HistoricoFinanceiro(new HistoricoFinanceiro()).ShowDialog();
            PreencherHistorico();
        }

        private void buttonAdicionarFornecedor_Click(object sender, EventArgs e)
        {
            new FCA_Fornecedor(new Fornecedor()).ShowDialog();
            PreencherFornecedor();
        }
    }
}
