using MetroFramework;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using PDV.DAO.Custom;
using PDV.UTIL;
using PDV.VIEW.Forms.Cadastro.Financeiro.Modulo;
using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using System.Text;
using PDV.DAO.Entidades;
using PDV.REPORTS.Reports.CarneVendaTermica;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;
using PDV.VIEW.App_Context;
using DevExpress.XtraPrinting;
using DevExpress.XtraEditors.Filtering.Templates;
using PDV.REPORTS.Recibo;
using Sequence = PDV.DAO.DB.Utils.Sequence;
using PDV.DAO.Entidades.PDV;
using PDV.VIEW.Forms.Util;
using System.Linq;
using DevExpress.Office.Drawing;
using System.Drawing;
using FastReport.Design;
using DevExpress.XtraRichEdit.Import.Rtf;
using DevExpress.DataProcessing;
using PDV.VIEW.Forms.Gerenciamento.DAV;

namespace PDV.VIEW.Forms.Consultas.Financeiro.Modulo
{
    public partial class FCOFIN_ContaReceber : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE CONTAS A RECEBER";
        private DataTable table = null;
        private List<decimal> IdsSelecionados
        {
            get
            {
                var ids = new List<decimal>();
                foreach (var linha in gridView1.GetSelectedRows())
                {
                    var id = Grids.GetValorDec(gridView1, "IDCONTARECEBER", linha);
                    ids.Add(id);
                }

                return ids;

            }
        }
        private DataTable BAIXAS = null;
        private ContaReceber Conta = null;
        public bool ExibirSoAbertas = false;
        public decimal linha = 0;
        public decimal IDFLUXOCAIXA = 0;
        public FCOFIN_ContaReceber()
        {
            InitializeComponent();
            dateEdit1.DateTime = DateTime.Today;
            dateEdit2.DateTime = dateEdit1.DateTime.AddDays(1);
            LimparTela();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            LimparTela();
        }

        private void LimparTela()
        {

        }

        private void FIN_ContaReceber_Load(object sender, EventArgs e)
        {
            if (ExibirSoAbertas)
                CarregarSoAbertas();
            else
                Atualizar();
        }

        private void Atualizar()
        {           
            table = FuncoesContaReceber.GetContas(dateEdit1.DateTime.Date, dateEdit2.DateTime.Date.AddDays(1));
            gridControl1.DataSource = table;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            FormatarGrid();
            gridView1.BestFitColumns();
        }

        private void CarregarSoAbertas()
        {
            table = FuncoesContaReceber.GetContasComSaldoEmAberto("", "", "");
            gridControl1.DataSource = table;
            FormatarGrid();
        }
        private void Receber()
        {
            //CONTASRECEBER = FuncoesContaReceber.GetContas(ovTXT_Cliente.Text, ovTXT_VencimentoInicio.Value, ovTXT_VencimentoFim.Value, ovTXT_EmissaoInicio.Value, ovTXT_EmissaoFim.Value, ovTXT_FormaPagamento.Text, ovTXT_Origem.Text);
            //     ovGRD_Contas.DataSource = CONTASRECEBER;
            //     AjustaHeaderTextGrid();

            //IDCONTARECEBER, 0
            //IDCLIENTE,1
            //CLIENTE,2
            //PARCELA,3
            //EMISSAO,4
            //VENCIMENTO,5
            //FORMAPAGAMENTO,6
            //ORIGEM,7
            //VALORTOTAL,8
            //SITUACAO9
            if (linha == 0)
                throw new Exception("Selecione uma conta.");

            table = FuncoesContaReceber.GetContaReceberDT(linha);

            Conta = new ContaReceber();
            DataRow row = table.Rows[0];
            string sAux = row[0].ToString();
            Conta.IDContaReceber = decimal.Parse(row[0].ToString());
            Conta.IDCliente = decimal.Parse(row[3].ToString());
            Conta.Parcela = decimal.Parse(row[8].ToString());
            Conta.Vencimento = DateTime.Parse(row[10].ToString());
            Conta.Emissao = DateTime.Parse(row[9].ToString());
            Conta.Valor = decimal.Parse(row[19].ToString());
            Conta.ValorTotal = decimal.Parse(row[19].ToString());
            Conta.IDVenda = decimal.Parse(row[24].ToString());
            Conta.IDUsuario = Contexto.USUARIOLOGADO.IDUsuario;

            FCAFIN_BaixaRecebimento Form = new FCAFIN_BaixaRecebimento(Conta, new BaixaRecebimento()
            {
                IDBaixaRecebimento = Sequence.GetNextID("BAIXARECEBIMENTO", "IDBAIXARECEBIMENTO"),
                IDContaBancaria = 1,
                IDHistoricoFinanceiro = 1,
                IDFluxoCaixa = IDFLUXOCAIXA,
                Baixa = DateTime.Now
            });
            Form.ShowDialog(this);
            BAIXAS = new DataTable();
            if (Form.Salvou)
            {
                DataRow dr = BAIXAS.NewRow();

                AtualizaSaldo(Conta.ValorTotal);

                CarregarBaixas(false);
                DataTable dt = ZeusUtil.GetChanges(BAIXAS, TipoOperacao.INSERT);
                //  dr["IDCONTARECEBER"] = Conta.IDContaReceber;
                //       BaixaRecebimento BaixaRec = EntityUtil<BaixaRecebimento>.ParseDataRow(row);
                /* Movimentação Bancária */
                Form.BaixaRec.IDContaReceber = Conta.IDContaReceber;
                Conta.Situacao = 3;
                Conta.IDContaBancaria = Form.BaixaRec.IDContaBancaria;
                Conta.IDHistoricoFinanceiro = Form.BaixaRec.IDHistoricoFinanceiro;
                Conta.ComplmHisFin = Form.BaixaRec.ComplmHisFin;
                Conta.IDFormaDePagamento = Form.BaixaRec.IDFormaDePagamento;
                Conta.IDCentroCusto = 1;
                Conta.Pagamento = DateTime.Now;
               

                //  if (Form.BaixaRec.Valor < )
                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesContaReceber.Salvar(Conta, Op))
                    throw new Exception("Não foi possível salvar o Lançamento.");

                if (!FuncoesBaixaRecebimento.Salvar(Form.BaixaRec, TipoOperacao.INSERT))
                    throw new Exception("Não foi possível salvar as Baixas");


                if (!FuncoesMovimentoBancario.Salvar(new MovimentoBancario()
                {
                    IDMovimentoBancario = Sequence.GetNextID("MOVIMENTOBANCARIO", "IDMOVIMENTOBANCARIO"),
                    IDContaBancaria = Form.BaixaRec.IDContaBancaria,
                    IDNatureza = null,
                    Historico = FuncoesHistoricoFinanceiro.GetHistoricoFinanceiro(Form.BaixaRec.IDHistoricoFinanceiro).Descricao,
                    Conciliacao = null,
                    Sequencia = Conta.Parcela,
                    DataMovimento = DateTime.Now,
                    Documento = $"{Conta.Titulo}_{Form.BaixaRec.IDBaixaRecebimento}T",
                    Tipo = 1,
                    Valor = Form.BaixaRec.Valor,
                }, TipoOperacao.INSERT))
                    throw new Exception("Não foi possível salvar o Movimento Bancário.");

                try
                {
                    //Configuracao Config_FormaPagamentoCarne = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAONFCE_PARAMETROSFINANCEIRO_FORMACARNE);
                    //if (Config_FormaPagamentoCarne == null)
                    //    return;

                    //  if (MessageBox.Show(this, "Deseja Gerar o Carnê de Duplicata Loja?", NOME_TELA, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    // {
                    Configuracao Config_NomeImpressora = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOPEDIDOVENDA_NOMEIMPRESSORA);
                    Configuracao Config_ExibirCaixaDialogo = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOPEDIDOVENDA_EXIBIRCAIXADIALOGO);
                    ContaReceber idvenda = FuncoesContaReceber.GetIDVendaContaReceber(Conta.IDContaReceber);
                    Crediario _Crediario = new Crediario(idvenda.IDVenda.Value);
                    //   DuplicataNFCe dup = FuncoesDuplicataNFe.GetDuplicata(idvenda.Vencimento, idvenda.IDVenda.Value, idvenda.Valor);
                    //    dup.DataPagamento = DateTime.Now;

                    //     FuncoesDuplicataNFe.AtualizaConta(dup.IDDuplicataNFCe, DateTime.Now);


                    using (ReportPrintTool printTool = new ReportPrintTool(_Crediario))
                    {
                        if (Config_NomeImpressora != null && !string.IsNullOrEmpty(Encoding.UTF8.GetString(Config_NomeImpressora.Valor)))
                            printTool.PrinterSettings.PrinterName = Encoding.UTF8.GetString(Config_NomeImpressora.Valor);
                        printTool.PrinterSettings.Copies = 1;
                        printTool.Print();
                    }

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA);
                }

                //using (ReportPrintTool printTool = new ReportPrintTool(_CarneVenda))
                //{
                //    if (Config_NomeImpressora != null && !string.IsNullOrEmpty(Encoding.UTF8.GetString(Config_NomeImpressora.Valor)))
                //        printTool.PrinterSettings.PrinterName = Encoding.UTF8.GetString(Config_NomeImpressora.Valor);
                //    printTool.PrintDialog();
                //}
            }
            // VerificaCheques(Form.BaixaRec.IDBaixaRecebimento, false, Form.Cheques);
        }
        private void CarregarBaixas(bool Banco)
        {
            //   if (Banco)
            //       BAIXAS = FuncoesBaixaRecebimento.GetBaixas(Conta.IDContaReceber);

            //ovGRD_Baixas.DataSource = BAIXAS;
            //AjustaTextHeaderBaixas();
        }
        private void AtualizaSaldo(decimal total)
        {
            if (BAIXAS == null)
                return;

            // decimal ValorSaldo = total - BAIXAS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["TOTAL"]));
            // ovTXT_Saldo.Value = ValorSaldo < 0 ? 0 : ValorSaldo;
        }

        private void FormatarGrid()
        {
            Grids.FormatGrid(ref gridView1);
            Grids.FormatColumnType(ref gridView1, new List<string> 
            { 
               "idcliente"
            }, GridFormats.VisibleFalse);

            Grids.FormatColumnType(ref gridView1, "valortotal", GridFormats.Finance);
            Grids.FormatColumnType(ref gridView1, "valortotal", GridFormats.SumFinance);

            
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            new FCAFIN_ContaReceber(new ContaReceber()).ShowDialog(this);
            Atualizar();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                new FCAFIN_ContaReceber(FuncoesContaReceber.GetContaReceber(IdsSelecionados[0])).ShowDialog();
                Atualizar();
            }
            catch (NullReferenceException)
            {

            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (Confirm("Deseja remover?") == DialogResult.Yes)
            {
                foreach (decimal id in IdsSelecionados)
                {
                    try
                    {
                        PDVControlador.BeginTransaction();
                        var conta = FuncoesContaReceber.GetContaReceber(id);
                        if (conta.IDVenda != null || conta.Situacao != StatusConta.Aberto)
                        {
                            PDVControlador.Commit();
                            continue;
                        }
                            

                        if (!FuncoesContaReceber.Remover(id))
                            throw new Exception($"Não foi possível remover o Lançamento {id}.");
                        PDVControlador.Commit();
                    }
                    catch (Exception ex)
                    {
                        PDVControlador.Rollback();
                        Alert(ex.Message);
                    }
                }
                Atualizar();
            }
        }
        public void MudaParaReceber()
        {
            btnEditar.Visible = false;
            btnNovo.Visible = false;
            btnRemover.Visible = false;
            btnReceber.Visible = true;
            ExibirSoAbertas = true;
        }
        private void btnReceber_Click(object sender, EventArgs e)
        {
            Receber();
            CarregarSoAbertas();
        }


        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void gridControl1_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                FCAFIN_ContaReceber Form = new FCAFIN_ContaReceber(FuncoesContaReceber.GetContaReceber(Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCONTARECEBER").ToString())));
                Form.ShowDialog(this);
                if (ExibirSoAbertas)
                    CarregarSoAbertas();
                else
                    Atualizar();
            }
            catch (NullReferenceException)
            {
            }
        }


        private void baixarMetroButton_Click(object sender, EventArgs e)
        {
            if (IdsSelecionados.Count == 1)
            {
                var id = IdsSelecionados.First();
                var form = new FCAFIN_ContaReceber(FuncoesContaReceber.GetContaReceber(id));
                form.NovaBaixa();
                if (form.botaoSalvar)
                    form.SalvarTudo();
            }
            else
            {
                var msg = "Confirmar a baixa das contas selecionadas?";
                if (Confirm(msg) == DialogResult.Yes)
                    Baixar();
            }
            Atualizar();
        }

        private void Baixar()
        {
            try
            {
                PDVControlador.BeginTransaction();

                foreach (var id in IdsSelecionados)
                {
                    var conta = FuncoesContaReceber.GetContaReceber(id);

                    if (conta.Situacao == StatusConta.Baixado && conta.Situacao == StatusConta.Cancelado)
                        continue;


                    var baixa = new BaixaRecebimento()
                    {
                        IDContaReceber = conta.IDContaReceber,
                        IDBaixaRecebimento = Sequence.GetNextID("BAIXARECEBIMENTO", "IDBAIXARECEBIMENTO"),
                        IDFormaDePagamento = (decimal)conta.IDFormaDePagamento,
                        IDContaBancaria = Convert.ToDecimal(conta.IDContaBancaria),
                        IDHistoricoFinanceiro = (decimal)conta.IDHistoricoFinanceiro,
                        Valor = conta.Saldo,
                        Baixa = DateTime.Now
                    };

                    if (!FuncoesBaixaRecebimento.Salvar(baixa, TipoOperacao.INSERT))
                        throw new Exception($"Não foi possível baixar a conta na baixa {id}");

                    if (conta.IDContaBancaria == null)
                        conta.IDContaBancaria = conta.IDContaBancaria;
                    conta.Situacao = StatusConta.Baixado;
                    conta.Saldo = 0;
                    conta.IDUsuario = Contexto.USUARIOLOGADO.IDUsuario;
                    if (!FuncoesContaReceber.Salvar(conta, TipoOperacao.UPDATE))
                        throw new Exception($"Não foi possível salvar a conta {conta.IDContaReceber}");
                }
                PDVControlador.Commit();
            }
            catch (Exception ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, ex.ToString());
            }
        }

        private DialogResult Confirm(string msg)
        {
            return MessageBox.Show(msg, NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            
            if (e.Column.FieldName == "situacao")
                FormatarCoresSituacao(e);

        }

        private void FormatarCoresSituacao(RowCellStyleEventArgs e)
        {
            string valor;
            try
            {
                var cellValue = gridView1.GetRowCellValue(e.RowHandle, "situacao");
                if (cellValue != null)
                    valor = cellValue.ToString();
                else throw new Exception();
            }
            catch (Exception)
            {
                valor = "";
            }
            switch (valor)
            {
                case "BAIXADO":
                    e.Appearance.ForeColor = Color.Green;
                    break;
                case "CANCELADO":
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "ABERTO":
                    e.Appearance.ForeColor = Color.Blue;
                    break;
                case "PARCIAL":
                    e.Appearance.ForeColor = Color.Yellow;
                    e.Appearance.BackColor = e.Appearance.BackColor2 = Color.Gray;
                    break;
            }
        }

        private void simpleButtonDuplicar_Click(object sender, EventArgs e)
        {
            if (Confirm("Deseja duplicar?") == DialogResult.Yes)
                foreach (var id in IdsSelecionados)
                    DuplicarConta(id);

            Atualizar();
        }

        private void DuplicarConta(decimal id)
        {
            try
            {
                PDVControlador.BeginTransaction();

                ContaReceber conta = FuncoesContaReceber.GetContaReceber(id);
                conta.IDContaReceber = Sequence.GetNextID("CONTARECEBER", "IDCONTARECEBER");
                conta.Situacao = 1;
                conta.Emissao = conta.Vencimento = conta.Fluxo = DateTime.Now;
                conta.Parcela = 1;
                conta.Saldo = conta.ValorTotal;
                conta.IDUsuario = Contexto.USUARIOLOGADO.IDUsuario;
                conta.IDVenda = null;


                if (!FuncoesContaReceber.Salvar(conta, TipoOperacao.INSERT))
                    throw new Exception($"Não foi possível duplicar a conta {id}");

                PDVControlador.Commit();
            }
            catch (Exception ex)
            {
                PDVControlador.Rollback();
                Alert(ex.Message);
            }
        }

        private void Alert(string message)
        {
            MessageBox.Show(message, NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        }

        private void gridView1_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            GridImprimir.FormatarImpressão(ref e);
        }
        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (dateEdit1.DateTime > dateEdit2.DateTime)
                dateEdit2.DateTime = dateEdit1.DateTime.AddDays(1);
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (dateEdit1.DateTime > dateEdit2.DateTime)
            {
                dateEdit1.DateTime = dateEdit2.DateTime;
                dateEdit2.DateTime = dateEdit1.DateTime.AddDays(1);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                ContaReceber cr = FuncoesContaReceber.GetContaReceber(IdsSelecionados[0]);
                Emitente emitente = FuncoesEmitente.GetEmitente();
                Cliente cliente = FuncoesCliente.GetCliente(cr.IDCliente.Value);
                Endereco endereco = FuncoesEndereco.GetEndereco(cliente.IDEndereco.Value);
                Recibo recibo = new Recibo()
                {
                    Pessoa = cliente.NomeFantasia != null ? cliente.NomeFantasia : cliente.Nome,
                    PessoaEndereco = $"{endereco.Logradouro}, Nº {endereco.Numero}, {endereco.Bairro}, {endereco.Municipio}, {endereco.UnidadeFederativa}",
                    Referente = "COMPRA DE PRODUTO E SERVIÇOS.",
                    Valor = cr.ValorTotal,
                    Importancia = ClsExtenso.Extenso_Valor(cr.ValorTotal),
                    Emitente = emitente.RazaoSocial,
                    EmitenteDocumento = emitente.CNPJ,
                    Data = DateTime.Now.ToString("dd/MM/yyyy")
                };
                var rel = new ReciboPagamento(recibo);
                using (ReportPrintTool printTool = new ReportPrintTool(rel))
                {
                    printTool.ShowPreviewDialog();
                }

            }
            catch (Exception ex)
            {
             
            }
        }

        private void botaoPesquisarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                decimal idMovimento = 0;

                try
                {
                    idMovimento = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDVENDA"));
                }
                catch (Exception)
                {

                }
                if (idMovimento > 0)
                {
                  
                        ItemVenda itemVenda = FuncoesItemVenda.GetItemVenda(Convert.ToDecimal(idMovimento));
                        new PedidoVendaItem(Convert.ToInt16(itemVenda.IDVenda)).ShowDialog();
                    botaoPesquisarProduto.Enabled = false;

                }
            }
            catch (NullReferenceException)
            {

            }
            finally
            {
                botaoPesquisarProduto.Enabled = false;
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            botaoPesquisarProduto.Enabled = true;
        }
    }
}
