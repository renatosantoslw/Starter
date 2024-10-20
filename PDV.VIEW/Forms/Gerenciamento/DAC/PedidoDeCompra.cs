using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Estoque.PedidoDeCompra;
using PDV.DAO.Entidades.Financeiro;
using PDV.REPORTS.Reports.PedidoDeCompra;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Relatorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using PDV.DAO.Entidades.Estoque.Movimento;
using PDV.DAO.Entidades.PDV;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using PDV.VIEW.Forms.Gerenciamento.DAC;
using DevExpress.XtraPrinting;
using PDV.VIEW.Forms.Estoque.ImportacaoNFeEntrada;
using System.Linq;
using PDV.VIEW.Forms.Util;
using PDV.DAO.Enum;

namespace PDV.VIEW.Forms.Estoque.PedidoDeCompra
{
    public partial class FCO_PedidoCompra : XtraForm
    {
        private string NOME_TELA = "CONSULTA DE PEDIDO DE COMPRA";
        private DataTable DADOS = null;
        public decimal PEDIDOCOMPRAID { get; set; }

        public string STATUS { get; set; }
        private int indexColunaSelecionado = -1;
        private DataTable table;
        public ContaPagar Conta;
        private object novoStripMenuItem1;

        string status;

        private List<decimal> IdsSelecionados
        {
            get
            {
                var ids = new List<decimal>();
                foreach (var linha in gridView1.GetSelectedRows())
                {
                    var id = Grids.GetValorDec(gridView1, "IDPEDIDOCOMPRA", linha);
                    ids.Add(id);
                }

                return ids;
            }
        }
        public FCO_PedidoCompra()
        {
            InitializeComponent();
            Conta = new ContaPagar();
            dateEdit1.DateTime = DateTime.Today;
            dateEdit2.DateTime = dateEdit1.DateTime.AddDays(1);
            metroTabControl1.SelectedIndex = 0;
            CarregarPermissoes();
        }

        private void CarregarPermissoes()
        {
            buttonFaturar.Enabled = Contexto.ITENSMENU.Where(i  => i.IDItemMenu == 128).Count() == 1;
            buttonCancelar.Enabled = Contexto.ITENSMENU.Where(i => i.IDItemMenu == 129).Count() == 1;
        }

        private void Carregar()
        {
            table = FuncoesPedidoCompra.GetPedidosDeCompra(dateEdit1.DateTime.Date, dateEdit2.DateTime.Date.AddDays(1));
            gridControl1.DataSource = table;
            FormatarGrid();
        }

        private void FormatarGrid()
        {
            
            Grids.FormatColumnType(ref gridView1, new List<string>()
            { 
                "TIPOFRETE",
                "IDPEDIDOCOMPRA"
            }, GridFormats.VisibleFalse);


            Grids.FormatColumnType(ref gridView1, "TOTAL", GridFormats.SumFinance);
            Grids.FormatColumnType(ref gridView1, "TOTAL", GridFormats.Finance);
            Grids.FormatGrid(ref gridView1);

        }


        private void metroButton2_Click(object sender, EventArgs e)
        {
            Carregar();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            // Novo
            new PedidoCompraItem(new PedidoCompra()).ShowDialog(this);
            Carregar();
           
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            // Editar

            try
            {
                decimal IDPedidoCompra = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDPEDIDOCOMPRA").ToString());

                new PedidoCompraItem(FuncoesPedidoCompra.GetPedidoCompra(IDPedidoCompra)).ShowDialog(this);
                Carregar();

            }
            catch (NullReferenceException)
            {
            }
        }

        private void ovGRD_Pedidos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (gridView1.Columns[e.ColumnIndex].Name)
            {
                case "DATAEMISSAO":
                case "DATAENTREGA":
                case "DATACANCELAMENTO":
                    if (e.Value != null && e.Value != DBNull.Value)
                        e.Value = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
                    break;
                case "TOTAL":
                    if (e.Value != null && e.Value != DBNull.Value)
                        e.Value = Convert.ToDecimal(e.Value).ToString("c2");
                    break;
            }
        }

        private void FCO_PedidoCompra_Load(object sender, EventArgs e)
        {
            Carregar();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            ImprimirPedidoCompra();
        }

        private void ImprimirPedidoCompra()
        {
            if (IdsSelecionados.Count > 0)
            {
                ReportPedidoCompra Rep = new ReportPedidoCompra(Contexto.USUARIOLOGADO, IdsSelecionados.FirstOrDefault());
                Stream STRel = new MemoryStream();
                Rep.ExportToPdf(STRel);
                new FREL_Preview(STRel).ShowDialog(this);
            }


            //SaveFileDialog SaveFile = new SaveFileDialog();
            //SaveFile.Filter = "RTF|*.rtf|PDF|*.pdf|XLS|*.xls|XLSX|*.xlsx";
            //SaveFile.Title = "Salvar o Pedido de Compra";
            //SaveFile.ShowDialog(this);
            //SaveFile.ShowHelp = false;
            //if (string.IsNullOrEmpty(SaveFile.FileName))
            //    return;
            //
            //switch (SaveFile.FilterIndex)
            //{
            //    case 1:
            //        Rep.ExportToRtf(SaveFile.FileName);
            //        break;
            //    case 2:
            //        Rep.ExportToPdf(SaveFile.FileName);
            //        break;
            //    case 3:
            //        Rep.ExportToXls(SaveFile.FileName);
            //        break;
            //    case 4:
            //        Rep.ExportToXlsx(SaveFile.FileName);
            //        break;
            //}
        }


        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            // Editar

            try
            {
                decimal IDPedidoCompra = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDPEDIDOCOMPRA").ToString());
                new PedidoCompraItem(FuncoesPedidoCompra.GetPedidoCompra(IDPedidoCompra)).ShowDialog(this);
                Carregar();

            }
            catch (NullReferenceException)
            {
            }

        }
        private void gerarFaturamentoMetroButton_Click(object sender, EventArgs e)
        {
           if(Confirm("Confirmar faturamento?") == DialogResult.Yes)
                Faturar(IdsSelecionados);
        }

        private int FatorPeriodicidade(string periodicidade)
        {
            int fator = 0;

            switch (periodicidade)
            {
                case "Diário":
                    fator = 1;
                    break;
                case "Semanal":
                    fator = 7;
                    break;
                case "Quinzenal":
                    fator = 15;
                    break;
                case "Mensal":
                    fator = 30;
                    break;
                case "Trimestral":
                    fator = 90;
                    break;
                case "Semestral":
                    fator = 180;
                    break;
                case "Anual":
                    fator = 365;
                    break;
            }
            return fator;
        }

        private void Faturar(List<decimal> ids)
        {
            try
            {
                PDVControlador.BeginTransaction();
                foreach (decimal id in ids)
                {
                    var pedidoCompra = FuncoesPedidoCompra.GetPedidoCompra(id);

                    if (pedidoCompra.Status == StatusPedido.Faturado)
                        continue;
                    
                    var tipoDeOperacao = FuncoesTipoDeOperacao.GetTipoDeOperacao(decimal.Round(pedidoCompra.IDTipoDeOperacao));
                   
                    if (tipoDeOperacao.GerarFinanceiro)
                    {
                        var duplicatasDAC = FuncoesDuplicataDAC.GetPagamentosPorCompra(pedidoCompra.IDPedidoCompra);
                        var pagamentos = new List<decimal>();
                        foreach (var duplicata in duplicatasDAC)
                        {
                            if (!pagamentos.Contains(duplicata.Pagamento))
                                pagamentos.Add(duplicata.Pagamento);
                        }

                        foreach (var pagamento in pagamentos)
                        {
                            var parcelas = duplicatasDAC.Where(o => o.Pagamento == pagamento).ToList();                            
                            var tipoOperacao = TipoOperacao.INSERT;
                            decimal numDaParcela = 1;
                            foreach (var parcela in parcelas)
                            {
                                var formaDePagamento = FuncoesFormaDePagamento.GetFormaDePagamento(parcela.IDFormaDePagamento); 

                                Conta.IDContaPagar = PDV.DAO.DB.Utils.Sequence.GetNextID("CONTAPAGAR", "IDCONTAPAGAR");
                                Conta.IDPedidoCompra = id;
                                Conta.IDContaBancaria = tipoDeOperacao.IDContaBancaria;
                                Conta.IDCentroCusto = tipoDeOperacao.IdCentroCusto;
                                Conta.IDFormaDePagamento = formaDePagamento.IDFormaDePagamento;
                                Conta.IDHistoricoFinanceiro = tipoDeOperacao.IDHistoricoFinanceiro;
                                Conta.IDFornecedor = pedidoCompra.IDFornecedor;
                                Conta.Ord = numDaParcela.ToString();
                                Conta.Parcela = parcelas.Count() ;
                                Conta.Titulo = "";
                                Conta.Emissao = DateTime.Now;
                                Conta.Vencimento = parcela.DataVencimento;
                                Conta.Situacao = formaDePagamento.Transacao == 1 ? 3 : 1;
                                Conta.Fluxo = DateTime.Now;
                                Conta.Origem = "Fatura de Compra";
                                Conta.ComplmHisFin = "Faturamento de compra de codigo :" + pedidoCompra.IDPedidoCompra + ".";
                                /* Valores */
                                Conta.Valor = parcela.Valor ;
                                Conta.Multa = 0;
                                Conta.Juros = 0;
                                Conta.Desconto = 0;
                                Conta.Saldo = formaDePagamento.Transacao == 1 ? 0 : parcela.Valor;
                                Conta.ValorTotal = parcela.Valor;

                                if (!FuncoesContaPagar.Salvar(Conta, tipoOperacao))
                                    throw new Exception($"Não foi possível salvar o Lançamento da Compra {id}.");

                                if (formaDePagamento.Transacao == 1)
                                {
                                    BaixaPagamento baixaPagamento = new BaixaPagamento()
                                    {
                                        IDContaPagar = Conta.IDContaPagar,
                                        IDBaixaPagamento = PDV.DAO.DB.Utils.Sequence.GetNextID("BAIXAPAGAMENTO", "IDBAIXAPAGAMENTO"),
                                        Valor = Conta.ValorTotal,
                                        IDFormaDePagamento = Convert.ToDecimal(Conta.IDFormaDePagamento),
                                        IDHistoricoFinanceiro = Convert.ToDecimal(Conta.IDHistoricoFinanceiro),
                                        IDContaBancaria = Convert.ToDecimal(Conta.IDContaBancaria),
                                        Baixa = DateTime.Now,

                                    };
                                    if (!FuncoesBaixaPagamento.Salvar(baixaPagamento, DAO.Enum.TipoOperacao.INSERT))
                                        throw new Exception($"Não foi possível salvar a Baixa da Compra {id}.");
                                }
                                numDaParcela++;
                            }
                        }
                    }

                    var itemPedidoCompra = FuncoesItemPedidoCompra.GetItensPedidoCompra(id);

                    foreach (ItemPedidoCompra Item in itemPedidoCompra)
                    {
                        if (!FuncoesItemPedidoCompra.SalvarItemPedidoCompra(Item))
                        {
                            throw new Exception($"Não foi possível salvar os Itens da Compra {id}.");
                        }

                        if (tipoDeOperacao.ControlarEstoque)
                        {
                            if (!FuncoesMovimentoEstoque.Salvar(new MovimentoEstoque
                            {
                                IDMovimentoEstoque = PDV.DAO.DB.Utils.Sequence.GetNextID("MOVIMENTOESTOQUE", "IDMOVIMENTOESTOQUE"),
                                DataMovimento = DateTime.Now,
                                IDAlmoxarifado = FuncoesProduto.GetProduto(Item.IDProduto).IDAlmoxarifadoEntrada,
                                IDItemPedidoCompra = Item.IDItemPedidoCompra,
                                IDProduto = Item.IDProduto,
                                Quantidade = Item.Quantidade,
                                Tipo = 0,
                                Descricao = "Faturamento de Compra",
                                IDItemInventario = null,
                                IDItemVenda = null,
                                IDItemNFeEntrada = null,
                                IDItemTransferenciaEstoque = null,
                                IDProdutoNFe = null
                            }))
                            {
                                throw new Exception($"Não foi possível salvar o Movimento de Estoque da Compra {id}.");
                            }
                        }
                    }

                    //Atualizar o Status de Pedido de Compra 
                    FuncoesPedidoCompra.AtualizarStatus(id, 1);

                    //Salvar data de faturamento
                    PedidoCompra compra = FuncoesPedidoCompra.GetPedidoCompra(id);
                    compra.DataFaturamento = DateTime.Now;
                    if (!FuncoesPedidoCompra.Salvar(compra))
                        throw new Exception($"Não foi possível salvar a data de faturamento da compra {id}");
                }
                PDVControlador.Commit();
                Carregar();

            }
            catch (Exception ex)
            {
                PDVControlador.Rollback();
                MensagemErro(ex.Message);
            }
        }
        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            Carregar();
        }

        private void metroButtonCancelar_Click(object sender, EventArgs e)
        {
            if(Confirm("Confirmar o cancelamento!") == DialogResult.Yes)
            {
                var motivo = XtraInputBox.Show("Informe o motivo do cancelamento", "Cancelar Compra", "");
                try
                {
                    PDVControlador.Commit();
                    foreach (var id in IdsSelecionados)
                    {
                        FuncoesPedidoCompra.CancelaPedidoCompra(id, motivo);

                        PedidoCompra pedidoCompra = FuncoesPedidoCompra.GetPedidoCompra(decimal.Parse(id.ToString()));
                        TipoDeOperacao tipoDeOperacao = FuncoesTipoDeOperacao.GetTipoDeOperacao(pedidoCompra.IDTipoDeOperacao);

                        if (tipoDeOperacao.GerarFinanceiro)
                        {
                            if (!FuncoesContaPagar.CancelarContaPagarDocumento(id))
                                throw new Exception($"Não foi possível cancelar as contas a pagar da compra {id}");
                        }

                        var itemPedidoCompra = FuncoesItemPedidoCompra.GetItensPedidoCompra(id);


                        foreach (ItemPedidoCompra Item in itemPedidoCompra)
                        {
                            if (!FuncoesItemPedidoCompra.SalvarItemPedidoCompra(Item))
                            {
                                throw new Exception($"Não foi possível salvar os Itens de Compra da Compra {id}.");
                            }
                            if (tipoDeOperacao.ControlarEstoque)
                            {
                                // [Processar Movimento de Estoque]
                                if (!FuncoesMovimentoEstoque.Salvar(new MovimentoEstoque
                                {
                                    IDMovimentoEstoque = PDV.DAO.DB.Utils.Sequence.GetNextID("MOVIMENTOESTOQUE", "IDMOVIMENTOESTOQUE"),
                                    DataMovimento = DateTime.Now,
                                    IDAlmoxarifado = FuncoesProduto.GetProduto(Item.IDProduto).IDAlmoxarifadoEntrada,
                                    IDItemPedidoCompra = Item.IDItemPedidoCompra,
                                    IDProduto = Item.IDProduto,
                                    Quantidade = Item.Quantidade,
                                    Tipo = 1, //0- ENTRADA 1 SAIDA
                                    Descricao = "Cancelamento de Compra",
                                    IDItemInventario = null,
                                    IDItemNFeEntrada = null,
                                    IDItemTransferenciaEstoque = null,
                                    IDProdutoNFe = null
                                }))
                                {
                                    throw new Exception($"Não foi possível salvar o Movimento de Estoque da compra {id}.");
                                }
                            }
                        }
                        var compra = FuncoesPedidoCompra.GetPedidoCompra(id);
                        compra.DataFaturamento = new DateTime(1, 1, 1);
                        if (!FuncoesPedidoCompra.Salvar(compra))
                            throw new Exception($"Não foi possível salvar a data de faturamento da compra {id}");
                    }
                    PDVControlador.Commit();
                    Carregar();
                }
                catch(Exception ex)
                {
                    PDVControlador.Rollback();
                    MensagemErro(ex.Message);
                }
            }
        }

        private void metroButtonRemover_Click(object sender, EventArgs e)
        {
            if(Confirm("Confirmar a remoção!") == DialogResult.Yes)
            {
                try
                {
                    PDVControlador.BeginTransaction();
                    foreach (var id in IdsSelecionados)
                    {
                        var compra = FuncoesPedidoCompra.GetPedidoCompra(id);
                        if (compra.Status != StatusPedido.Aberto)
                            continue;

                        FuncoesDuplicataDAC.ExcluirPorPedidoCompra(id);

                        if (!FuncoesPedidoCompra.Remover(id))
                            throw new Exception($"Não foi possível remover da Compra {id}.");
                    }
                    PDVControlador.Commit();
                    Carregar();
                }
                catch (Exception exception)
                {
                    PDVControlador.Rollback();
                    MensagemErro(exception.Message);
                }
            }
            
        }


        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView currentView = sender as GridView;
            if (e.Column.FieldName == "STATUS")
            {
                string valor;
                try
                {
                    var cellValue = gridView1.GetRowCellValue(e.RowHandle, "STATUS");
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
                    case "FATURADO":
                        e.Appearance.ForeColor = System.Drawing.Color.Green;
                        break;
                    case "CANCELADO":
                        e.Appearance.ForeColor = System.Drawing.Color.Red;
                        break;
                    case "ABERTO":
                        e.Appearance.ForeColor = System.Drawing.Color.Blue;
                        break;
                }
            }
        }

        private void simpleButtonDuplicar_Click(object sender, EventArgs e)
        {

            if(Confirm("Deseja executar ação de duplicar?") == DialogResult.Yes)
            {
                try
                {
                    PDVControlador.BeginTransaction();
                    foreach (decimal id in IdsSelecionados)
                    {
                        PedidoCompra pedido = FuncoesPedidoCompra.GetPedidoCompra(id);
                        pedido.DataEmissao = DateTime.Now;

                        var itensCompra = FuncoesItemPedidoCompra.GetItensPedidoCompra(pedido.IDPedidoCompra);

                        var duplicatasDAC = FuncoesDuplicataDAC.GetPagamentosPorCompra(pedido.IDPedidoCompra);

                        pedido.IDPedidoCompra = DAO.DB.Utils.Sequence.GetNextID("PEDIDOCOMPRA", "IDPEDIDOCOMPRA");
                        pedido.Status = 0;


                        if (!FuncoesPedidoCompra.Salvar(pedido))
                            throw new Exception($"Não foi possível duplicar a Compra {id}.");

                        foreach (ItemPedidoCompra item in itensCompra)
                        {
                            item.IDPedidoCompra = pedido.IDPedidoCompra;
                            item.IDItemPedidoCompra = DAO.DB.Utils.Sequence.GetNextID("ITEMPEDIDOCOMPRA", "IDITEMPEDIDOCOMPRA");
                            if (!FuncoesItemPedidoCompra.Salvar(item, DAO.Enum.TipoOperacao.INSERT))
                                throw new Exception($"Não foi possível duplicar os Itens de Compra da Compra {id}.");
                        }

                        foreach (var item in duplicatasDAC)
                        {
                            var duplicata = new DuplicataDAC()
                            {
                                IDDuplicataDAC = DAO.DB.Utils.Sequence.GetNextID("DUPLICATANFCE", "IDDUPLICATANFCE"),
                                IDCompra = pedido.IDPedidoCompra,
                                IDFormaDePagamento = item.IDFormaDePagamento,
                                FormaDePagamento = item.FormaDePagamento,
                                Valor = item.Valor,
                                DataVencimento = item.DataVencimento,
                                Pagamento = item.Pagamento
                            };
                            FuncoesDuplicataDAC.SalvarDuplicataDAC(duplicata);
                        }
                    }
                    PDVControlador.Commit();
                    Carregar();

                }
                catch (Exception exception)
                {
                    PDVControlador.Rollback();                    
                    MensagemErro(exception.Message);

                }
                Carregar();
            }
        }

        private void MensagemErro(string msg)
        {
            MessageBox.Show(msg, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private DialogResult Confirm(string msg)
        {
            return MessageBox.Show(msg, NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void simpleButtonViaXml_Click(object sender, EventArgs e)
        {
            new FEST_EscolhaFormatoImportacaoNFe().ShowDialog(this);
            Carregar();
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

        private void metroButtonGerarNfe_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            GridImprimir.FormatarImpressão(ref e);
        }
    }
}