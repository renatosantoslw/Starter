using DevExpress.Office.Drawing;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.UTIL.FORMS.Forms.Seletores;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.Financeiro.Modulo
{
    public partial class FCAFIN_ContaReceber : DevExpress.XtraEditors.XtraForm
    {
        private List<ContaBancaria> Contas = null;
        private List<CentroCusto> CentrosCustos = null;
        private List<HistoricoFinanceiro> Historicos = null;
        private List<FormaDePagamento> FormasDePagamento = null;
        private List<SituacaoConta> SITUACAOCONTA = null;
        private Cliente Cliente = null;
        private DataTable Baixas = null;


        public bool Salvou = false;
        public bool botaoSalvar = false;
        private bool ComitarTransacao = true;

        private Dictionary<decimal, DataTable> Cheques = null;
        private string NOME_TELA = "CADASTRO DE CONTAS A RECEBER";
        private ContaReceber Conta = null;

        public FCAFIN_ContaReceber(ContaReceber _Conta, bool _ComitarTransacao = true)
        {
            Conta = _Conta;
            ComitarTransacao = _ComitarTransacao;
            InitializeComponent();           

            SITUACAOCONTA = SituacaoConta.GetSituacoesConta();
            
            ovTXT_Valor.AplicaAlteracoes();
            ovTXT_Multa.AplicaAlteracoes();
            ovTXT_Juros.AplicaAlteracoes();
            ovTXT_Desconto.AplicaAlteracoes();
            ovTXT_Saldo.AplicaAlteracoes();
            ovTXT_Total.AplicaAlteracoes();

            PreencherTela();
            metroTabControl2.SelectedTab = metroTabPage5;

            PreencherLabelSituacao();
            CarregarPermissoes();
        }

        private void CarregarPermissoes()
        {
            PermissoesUtil.VerificarPermissaoParaTela(FCA_ContaBancaria.idsMenuItem, ref buttonAdicionarContaBancaria);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_CentroCusto.idsMenuItem, ref buttonAdicionarCentroCusto);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_FormaDePagamento.idsMenuItem, ref buttonAdicionarFormaDePagamento);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_HistoricoFinanceiro.idsMenuItem, ref buttonAdicionarHistoricoFinanceiro);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_Cliente.idsMenuItem, ref buttonAdicionarCliente);
        }

        private void PreencherLabelSituacao()
        {
            SituacaoContaUtil.FormatarLabelSituacao(ref lblSituacao, Conta.Situacao);            
        }

        private void PreencherFormaDePagamento()
        {
            FormasDePagamento = FuncoesFormaDePagamento.GetFormasPagamento();
            ovCMB_FormaPagamento.DataSource = FormasDePagamento;
            ovCMB_FormaPagamento.ValueMember = "idformadepagamento";
            ovCMB_FormaPagamento.DisplayMember = "identificacaodescricaoformabandeira";
            ovCMB_FormaPagamento.SelectedItem = FormasDePagamento.Where(o => o.IDFormaDePagamento == Conta.IDFormaDePagamento).FirstOrDefault();
            ovCMB_FormaPagamento.Enabled = Conta.IDContaReceber == -1;
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
            CentrosCustos = FuncoesCentroCusto.GetCentrosCusto(CentroCusto.Saida);
            ovCMB_CentroCusto.DataSource = CentrosCustos;
            ovCMB_CentroCusto.ValueMember = "idcentrocusto";
            ovCMB_CentroCusto.DisplayMember = "descricao";
            ovCMB_CentroCusto.SelectedItem = CentrosCustos.Where(o => o.IDCentroCusto == Conta.IDCentroCusto).FirstOrDefault();
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
            PreencherFormaDePagamento();


            Cliente = Conta.IDCliente.HasValue ? FuncoesCliente.GetCliente(Conta.IDCliente.Value) : null;
            if (Cliente != null)
            {
                ovTXT_CodCliente.Text = Cliente.IDCliente.ToString();
                ovTXT_Cliente.Text = Cliente.TipoDocumento == 0 ? Cliente.NomeFantasia : Cliente.Nome;
            }
            else
            {
                ovTXT_Cliente.Text = "<Cliente Não Informado>";

            }

            ovTXT_Emissao.Value = Conta.Emissao;
            ovTXT_Vencimento.Value = Conta.Vencimento;
            checkBoxCancelado.Checked = Conta.Situacao == 0;
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
            Salvou = false;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SEL_Cliente SeletorCliente = new SEL_Cliente();
            SeletorCliente.ShowDialog(this);

            if (SeletorCliente.DRCliente == null)
                return;

            DataRow DrSelecionada = SeletorCliente.DRCliente;
            Cliente = FuncoesCliente.GetCliente(Convert.ToDecimal(DrSelecionada["IDCLIENTE"]));
            ovTXT_CodCliente.Text = Cliente.IDCliente.ToString();
            ovTXT_Cliente.Text = Cliente.TipoDocumento == 0 ? Cliente.NomeFantasia : Cliente.Nome;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            SalvarTudo();
        }

        private void SalvarBaixas()
        {
            DataTable dt = ZeusUtil.GetChanges(Baixas, TipoOperacao.INSERT);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    dr["IDCONTARECEBER"] = Conta.IDContaReceber;
                    BaixaRecebimento BaixaRec = EntityUtil<BaixaRecebimento>.ParseDataRow(dr);
                    if (!FuncoesBaixaRecebimento.Salvar(BaixaRec, TipoOperacao.INSERT))
                        throw new Exception("Não foi possível salvar as Baixas");

                    /* Movimentação Bancária */
                    if (!FuncoesMovimentoBancario.Salvar(new MovimentoBancario()
                    {
                        IDMovimentoBancario = Sequence.GetNextID("MOVIMENTOBANCARIO", "IDMOVIMENTOBANCARIO"),
                        IDContaBancaria = BaixaRec.IDContaBancaria,
                        IDNatureza = null,
                        Historico = FuncoesHistoricoFinanceiro.GetHistoricoFinanceiro(BaixaRec.IDHistoricoFinanceiro).Descricao,
                        Conciliacao = null,
                        Sequencia = Conta.Parcela,
                        DataMovimento = DateTime.Now,
                        Documento = $"{Conta.Titulo}_{BaixaRec.IDBaixaRecebimento}T",
                        Tipo = 1,
                        Valor = BaixaRec.Valor,
                    }, TipoOperacao.INSERT))
                        throw new Exception("Não foi possível salvar o Movimento Bancário.");
                }

            dt = ZeusUtil.GetChanges(Baixas, TipoOperacao.UPDATE);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    dr["IDCONTARECEBER"] = Conta.IDContaReceber;
                    if (!FuncoesBaixaRecebimento.Salvar(EntityUtil<BaixaRecebimento>.ParseDataRow(dr), TipoOperacao.UPDATE))
                        throw new Exception("Não foi possível salvar as Baixas.");
                }

            dt = ZeusUtil.GetChanges(Baixas, TipoOperacao.DELETE);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    if (!FuncoesBaixaRecebimento.Remover(Convert.ToDecimal(dr["IDBAIXARECEBIMENTO"])))
                        throw new Exception("Não foi possível salvar as Baixas.");

                    if (!FuncoesMovimentoBancario.RemoverPorDocumento($"{Conta.Titulo}_{dr["IDBAIXARECEBIMENTO"]}T", 1))
                        throw new Exception("Não foi possível salvar o Movimento Bancário.");
                }

            /* Salvando os Cheques das Baixas */
            foreach (DataTable dtCheque in Cheques.Values)
            {
                dt = ZeusUtil.GetChanges(dtCheque, TipoOperacao.INSERT);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesChequesCtaReceber.Salvar(EntityUtil<ChequeContaReceber>.ParseDataRow(dr), TipoOperacao.INSERT))
                            throw new Exception("Não foi possível salvar os Cheques.");

                dt = ZeusUtil.GetChanges(dtCheque, TipoOperacao.UPDATE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesChequesCtaReceber.Salvar(EntityUtil<ChequeContaReceber>.ParseDataRow(dr), TipoOperacao.UPDATE))
                            throw new Exception("Não foi possível salvar os Cheques.");

                dt = ZeusUtil.GetChanges(dtCheque, TipoOperacao.DELETE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesChequesCtaReceber.Remover(Convert.ToDecimal(dr["IDCHEQUECONTARECEBER"])))
                            throw new Exception("Não foi possível salvar os Cheques.");
            }
        }

        private bool Validar()
        {
            if (ovCMB_CentroCusto.SelectedItem == null)
                throw new Exception("Selecione o Centro de Custo.");

            if (ovCMB_FormaPagamento.SelectedItem == null)
                throw new Exception("Selecione a Forma de Pagamento.");

            if (ovCMB_HistoricoFinanceiro.SelectedItem == null)
                throw new Exception("Selecione o Histórico Financeiro.");

            if (Cliente == null && !Conta.Origem.Equals("NFCE"))
                throw new Exception("Selecione o Cliente.");


            return true;
        }

        private void FCAFIN_ContaReceber_Load(object sender, EventArgs e)
        {

        }

        /* Baixas */
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
                Baixas = FuncoesBaixaRecebimento.GetBaixas(Conta.IDContaReceber);

            gridControlBaixas.DataSource = Baixas;
            gridViewBaixas.OptionsBehavior.Editable = false;
            gridViewBaixas.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewBaixas.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridViewBaixas.BestFitColumns();

            AjustaTextHeaderBaixas();
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
                    Baixas.DefaultView.RowFilter = "[IDBAIXARECEBIMENTO] = " + IDBaixa;
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

        private void VerificaCheques(decimal IDBaixa, bool Removeu, DataTable dtCheques)
        {
            if (Removeu && Cheques.ContainsKey(IDBaixa))
            {
                Cheques.Remove(IDBaixa);
                return;
            }

            Cheques[IDBaixa] = dtCheques;
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

        private void MetroButton9_Click(object sender, EventArgs e)
        {
            ContaCobranca cc = new ContaCobranca()
            {
                IDContaCobranca = 1,
                IDContaBancaria = 1
            };

            Conta.IDContaBancaria = 1;
            var lista = FuncoesContaReceber.GetContasReceberPorLista(Conta.IDContaReceber).ToList();
            BOLETO.Boletos.BoletoBB.GerarBoletoBB(lista, cc);

        }

        private void FCAFIN_ContaReceber_KeyDown(object sender, KeyEventArgs e)
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
                decimal IDBaixa = decimal.Parse(gridViewBaixas.GetRowCellValue(gridViewBaixas.FocusedRowHandle, "IDBAIXARECEBIMENTO").ToString());
                Baixas.DefaultView.RowFilter = "[IDBAIXARECEBIMENTO] = " + IDBaixa;

                Conta.Valor = ovTXT_Valor.Value;
                Conta.Multa = ovTXT_Multa.Value;
                Conta.Juros = ovTXT_Juros.Value;
                Conta.Desconto = ovTXT_Desconto.Value;
                Conta.Saldo = ovTXT_Saldo.Value;
                Conta.ValorTotal = ovTXT_Total.Value;
                FCAFIN_BaixaRecebimento Form = new FCAFIN_BaixaRecebimento(Conta, EntityUtil<BaixaRecebimento>.ParseDataRow(Baixas.DefaultView[0].Row));
                Form.ShowDialog(this);
                if (Form.Salvou)
                {
                    foreach (DataRowView drView in Baixas.DefaultView)
                    {
                        drView.BeginEdit();
                        drView["BAIXA"] = Form.BaixaRec.Baixa;
                        drView["CONTABANCARIA"] = FuncoesContaBancaria.GetContaBancaria(Form.BaixaRec.IDContaBancaria).Nome;
                        drView["VALOR"] = Form.BaixaRec.Valor;
                        drView["TOTAL"] = (Form.BaixaRec.Valor - Form.BaixaRec.Desconto) + Form.BaixaRec.Juros + Form.BaixaRec.Multa;
                        drView["IDCONTARECEBER"] = Conta.IDContaReceber;
                        drView["IDFORMADEPAGAMENTO"] = Form.BaixaRec.IDFormaDePagamento;
                        drView["IDCONTABANCARIA"] = Form.BaixaRec.IDContaBancaria;
                        drView["IDHISTORICOFINANCEIRO"] = Form.BaixaRec.IDHistoricoFinanceiro;
                        drView["COMPLMHISFIN"] = Form.BaixaRec.ComplmHisFin;
                        drView["MULTA"] = Form.BaixaRec.Multa;
                        drView["JUROS"] = Form.BaixaRec.Juros;
                        drView["DESCONTO"] = Form.BaixaRec.Desconto;
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
        public void NovaBaixa ()
        {

            if (Conta.Situacao != 3 && Conta.Situacao != 0)
            {
                Conta.Valor = ovTXT_Valor.Value;
                Conta.Multa = ovTXT_Multa.Value;
                Conta.Juros = ovTXT_Juros.Value;
                Conta.Desconto = ovTXT_Desconto.Value;
                Conta.Saldo = ovTXT_Saldo.Value;
                Conta.ValorTotal = ovTXT_Total.Value;


                FCAFIN_BaixaRecebimento Form = new FCAFIN_BaixaRecebimento(Conta, new BaixaRecebimento()
                {
                    IDBaixaRecebimento = Sequence.GetNextID("BAIXARECEBIMENTO", "IDBAIXARECEBIMENTO"),
                    IDContaBancaria = ovCMB_ContaBancaria.SelectedItem == null ? -1 : (ovCMB_ContaBancaria.SelectedItem as ContaBancaria).IDContaBancaria,
                    IDHistoricoFinanceiro = ovCMB_HistoricoFinanceiro.SelectedItem == null ? -1 : (ovCMB_HistoricoFinanceiro.SelectedItem as HistoricoFinanceiro).IDHistoricoFinanceiro,
                    Baixa = DateTime.Now,                        
                    IDFormaDePagamento = ovCMB_FormaPagamento.SelectedItem == null ?-1:(ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento
                });


                Form.ShowDialog(this);

                botaoSalvar = Form.botaoSalvar;

                if (Form.Salvou)
                {
                    DataRow dr = Baixas.NewRow();
                    dr["IDBAIXARECEBIMENTO"] = Form.BaixaRec.IDBaixaRecebimento;
                    dr["BAIXA"] = Form.BaixaRec.Baixa;
                    dr["CONTABANCARIA"] = FuncoesContaBancaria.GetContaBancaria(Form.BaixaRec.IDContaBancaria).Nome;
                    dr["TOTAL"] = (Form.BaixaRec.Valor - Form.BaixaRec.Desconto) + Form.BaixaRec.Juros + Form.BaixaRec.Multa;
                    dr["VALOR"] = Form.BaixaRec.Valor;
                    dr["IDCONTARECEBER"] = Conta.IDContaReceber;
                    dr["IDFORMADEPAGAMENTO"] = Form.BaixaRec.IDFormaDePagamento;
                    dr["IDCONTABANCARIA"] = Form.BaixaRec.IDContaBancaria;
                    dr["IDHISTORICOFINANCEIRO"] = Form.BaixaRec.IDHistoricoFinanceiro;
                    dr["COMPLMHISFIN"] = Form.BaixaRec.ComplmHisFin;
                    dr["MULTA"] = Form.BaixaRec.Multa;
                    dr["JUROS"] = Form.BaixaRec.Juros;
                    dr["DESCONTO"] = Form.BaixaRec.Desconto;
                   Conta.Pagamento= Form.BaixaRec.Baixa;
                    Baixas.Rows.Add(dr);

                    AtualizaSaldo();

                    CarregarBaixas(false);
                    VerificaCheques(Form.BaixaRec.IDBaixaRecebimento, false, Form.Cheques);
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
        public void SalvarTudo()
        {
            try
            {
                if (ComitarTransacao)
                    PDVControlador.BeginTransaction();

                if (!Validar())
                    return;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (Conta.IDContaReceber == -1)
                {
                    Op = TipoOperacao.INSERT;
                    Conta.IDContaReceber = Sequence.GetNextID("CONTARECEBER", "IDCONTARECEBER");
                    Conta.Situacao = 1;
                }

                Conta.IDContaBancaria = null;
                if (ovCMB_ContaBancaria.SelectedItem != null)
                    Conta.IDContaBancaria = (ovCMB_ContaBancaria.SelectedItem as ContaBancaria).IDContaBancaria;
                Conta.IDCentroCusto = (ovCMB_CentroCusto.SelectedItem as CentroCusto).IDCentroCusto;
                Conta.IDFormaDePagamento = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento;
                Conta.IDHistoricoFinanceiro = (ovCMB_HistoricoFinanceiro.SelectedItem as HistoricoFinanceiro).IDHistoricoFinanceiro;
                Conta.IDCliente = Cliente == null ? null : (decimal?)Cliente.IDCliente;
                

               // Conta.Pagamento = DateTime.Now;
            

                Conta.Titulo = (string.IsNullOrEmpty(ovTXT_Titulo.Text) ? Conta.IDContaReceber.ToString() : ovTXT_Titulo.Text);
                Conta.Parcela = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).Qtd_Parcelas;



                // Value.Date.ToString("yyyy-MM-dd 00:00:00")
                Conta.Emissao = ovTXT_Emissao.Value;
                Conta.Vencimento = ovTXT_Vencimento.Value;
                Conta.Fluxo = ovTXT_Fluxo.Value;

        
                Conta.Origem = ovTXT_Origem.Text;
                Conta.ComplmHisFin = ovTXT_Complemento.Text;

                /* Valores */
                Conta.Valor = ovTXT_Valor.Value;
                Conta.Multa = ovTXT_Multa.Value;
                Conta.Juros = ovTXT_Juros.Value;
                Conta.Desconto = ovTXT_Desconto.Value;
                Conta.Saldo = ovTXT_Saldo.Value;
                Conta.ValorTotal = ovTXT_Total.Value;
                Conta.IDUsuario = Contexto.USUARIOLOGADO.IDUsuario;

                if (Conta.Parcela > 1 && Op == TipoOperacao.INSERT)
                {
                    for (int i = 0; i < Conta.Parcela; i++)
                    {
                        Conta.IDContaReceber = Sequence.GetNextID("CONTARECEBER", "IDCONTARECEBER");
                        //Conta.Ord = (i + 1).ToString();
                        Conta.Vencimento = Convert.ToDateTime(ovTXT_Vencimento.Text).AddMonths(i + 1);
                        Conta.ValorTotal = decimal.Parse(ovTXT_Total.Value.ToString()) / Conta.Parcela;
                        Conta.Valor = decimal.Parse(ovTXT_Valor.Value.ToString()) / Conta.Parcela;
                        Conta.Saldo = decimal.Parse(ovTXT_Saldo.Value.ToString()) / Conta.Parcela;
            
                        Conta.IDUsuario = Contexto.USUARIOLOGADO.IDUsuario;
                        
                        
                        if (!FuncoesContaReceber.Salvar(Conta, Op))
                            throw new Exception("Não foi possível salvar o Lançamento.");
                    }
                }
                else
                {
                    if (Conta.Saldo < Conta.Valor)
                        Conta.Situacao = 2;
                    
                    if (Conta.Saldo == 0)
                        Conta.Situacao = 3;
                    
                    if (Conta.Saldo == Conta.Valor)
                        Conta.Situacao = 1;

                    if (checkBoxCancelado.Checked)
                        Conta.Situacao = 0;

                    if (!FuncoesContaReceber.Salvar(Conta, Op))
                        throw new Exception("Não foi possível salvar o Lançamento.");
                }

                // Salvar as Baixas
                SalvarBaixas();

                if (ComitarTransacao)
                    PDVControlador.Commit();

                MessageBox.Show(this, "Lançamento salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Salvou = true;
                Close();
            }
            catch (Exception Ex)
            {
                if (ComitarTransacao)
                    PDVControlador.Rollback();

                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Salvou = false;
            }
        }

        private void gridControlBaixas_Click(object sender, EventArgs e)
        {
            metroButton7.Enabled = true;
            metroButton6.Enabled = true;
        }
        private void DesabilitarBotoes()
        {
            metroButton7.Enabled = false;
            metroButton6.Enabled = false;
        }

        private void buttonAdicionaPortador_Click(object sender, EventArgs e)
        {
            new FCA_ContaBancaria(new ContaBancaria()).ShowDialog();
            PreencherContaBancaria();
        }

        private void buttonAdicionarTipoTitulo_Click(object sender, EventArgs e)
        {
            new FCA_CentroCusto(new CentroCusto()).ShowDialog();
            PreencherCentroCusto();
        }

        private void buttonAdicionaFormaDePagamento_Click(object sender, EventArgs e)
        {
            new FCA_FormaDePagamento(new FormaDePagamento()).ShowDialog();
            PreencherFormaDePagamento();
        }

        private void buttonAdicionarHistoricoFinanceiro_Click(object sender, EventArgs e)
        {
            new FCA_HistoricoFinanceiro(new HistoricoFinanceiro()).ShowDialog();
            PreencherHistorico();
        }

        private void buttonAdicionarCliente_Click(object sender, EventArgs e)
        {
            new FCA_Cliente(new Cliente()).ShowDialog();
        }

    }
}
