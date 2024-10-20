using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using MetroFramework;
using MetroFramework.Forms;
using Microsoft.Win32;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Estoque.PedidoDeCompra;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.UTIL.Components;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Estoque.PedidoDeCompra;
using PDV.VIEW.Forms.Util;
using PDV.VIEW.Forms.Vendas.NFe;
using PDV.VIEW.FRENTECAIXA.Forms.PDV.DAV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations.History;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;


namespace PDV.VIEW.Forms.Gerenciamento.DAC
{
    public partial class PedidoCompraItem : Form
    {
        public const string nomeTela = "CADASTRO DE PEDIDO DE COMPRA";

        private string CodFornecedor {get; set;}

        private string CodComprador { get; set; }

        public List<ItemPedidoCompra> LstItemDeCompra { get; set; } = null;

        public ItemPedidoCompra ItemDeCompraSelec { get; set; } = null;

        public string CodProduto { get; set; }

        public decimal IDItemFormaPagamento { get; set; }

        public decimal IDItemPedidoCompra { get; set; }

        private PedidoCompra Pedido = null;

        private DataTable Itens = null;

        private DataRow drProduto = null;

        public Fornecedor Fornecedor = null;

        private Usuario Comprador = null;        

        public List<FormaPagamentoAux> lstformaPagamentoAux  = new List<FormaPagamentoAux>();        

        private List<Fornecedor> Fornecedores = null;

        private List<Transportadora> Transportadoras = null;

        private List<FormaDePagamento> FormasPagamento = null;

        

        public PedidoCompraItem(PedidoCompra _Pedido)
        {
            InitializeComponent();

            Pedido = _Pedido;
            dateTimePicker1.Value = Pedido.DataEmissao;
            switch (Pedido.Status)
            {
                case 0:
                    if (Pedido.IDPedidoCompra != -1)
                    {
                        labelStatus.Text = "ABERTO";
                        salvarSimpleButton.Enabled = true;
                    }

                    break;
                case 1:
                    labelStatus.Text = "FATURADO";
                    labelStatus.ForeColor = Color.LightGreen;
                    salvarSimpleButton.Enabled =
                    incluirSimpleButton.Enabled =
                    cancelarItemSimpleButton1.Enabled =
                    salvarSimpleButton.Enabled =
                    fecharSimpleButton.Enabled =
                    dateTimePicker1.Enabled = false;
                    break;
                case 2:
                    labelStatus.Text = "CANCELADO";
                    salvarSimpleButton.Enabled =
                    incluirSimpleButton.Enabled =
                    cancelarItemSimpleButton1.Enabled =
                    cancelarItemSimpleButton1.Enabled =
                    salvarSimpleButton.Enabled =
                    fecharSimpleButton.Enabled =
                    dateTimePicker1.Enabled = false;
                    break;
            }

            PreencherFormaDePagamento();

            PreencherTipoDeOperacao();

            PreencherFornecedor();            

            Comprador = FuncoesUsuario.GetUsuario(Pedido.IDComprador);
            if (Comprador != null)
            {
                if (Comprador.IsComprador == 1)
                    compradorTextEdit.Text = Comprador != null ? Comprador.Nome : "";
                else
                    Comprador = null;
            }
            else
            {
                Comprador = FuncoesUsuario.GetUsuario(Contexto.USUARIOLOGADO.IDUsuario);
                if (Comprador != null)
                {
                    if (Comprador.IsComprador == 1)
                        compradorTextEdit.Text = Comprador != null ? Comprador.Nome : "";
                    else
                        Comprador = null;
                }
            }

            LstItemDeCompra = FuncoesItemPedidoCompra.GetItensPedidoCompra(Pedido.IDPedidoCompra);

            List<DuplicataDAC> duplicatasDAC = FuncoesDuplicataDAC.GetPagamentosPorCompra(Pedido.IDPedidoCompra);
            CarregarFormasDePagamento(duplicatasDAC);


            if (Pedido.IDPedidoCompra == -1)
                Pedido.IDPedidoCompra = Sequence.GetNextID("PEDIDOCOMPRA", "IDPEDIDOCOMPRA");

            HabilitarTextBoxPreco();
            CarregarPermissoes();
        }

        private void CarregarPermissoes()
        {
            PermissoesUtil.VerificarPermissaoParaTela(FCA_Fornecedor.idsMenuItem, ref buttonAdicionarFornecedor);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_Usuario.idsMenuItem, ref buttonAdicionarComprador);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_TipoDeOperacao.idsMenuItem, ref buttonAdicionarTipoDeOperacao);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_Produtos.idsMenuItem, ref buttonAdicionarProduto);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_FormaDePagamento.idsMenuItem, ref buttonAdicionarFormaDePagamento);
        }        

        private void PreencherFornecedor()
        {
            try
            {
                Fornecedor = FuncoesFornecedor.GetFornecedor(Convert.ToDecimal(Pedido.IDFornecedor));
                fornecedortextEdit.Text = Fornecedor != null ? Fornecedor.RazaoSocial : "";
            }
            catch (Exception exception)
            {
                var msg = "Desculpe! " + exception.Message;
                MessageBox.Show(msg, "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    

        private void PreencherTipoDeOperacao()
        {
            try
            {
                var tipoDeOperacao = FuncoesTipoDeOperacao.GetTiposDeOperacaoPorTipoDeMovimento(TipoDeOperacao.Entrada)
                                                        .Select(s => new { Cod = s.IDTipoDeOperacao, Nome = s.Nome })
                                                        .OrderBy(x => x.Cod).ToList();

                gridLookUpEditTipoDeOperacao.Properties.DataSource = tipoDeOperacao;
                gridLookUpEditTipoDeOperacao.EditValue = Pedido.IDTipoDeOperacao;
            }
            catch (Exception exception)
            {
                var msg = "Desculpe! " + exception.Message;
                MessageBox.Show(msg, "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void PreencherFormaDePagamento()
        {
            try
            {
                var formaPagamento = FuncoesFormaDePagamento.GetFormasPagamento()
                                                            .Select(s => new { Cod = s.IDFormaDePagamento, Nome = s.Identificacao })
                                                            .OrderBy(x => x.Cod).ToList();

                gridLookUpEditFormaPagamento.Properties.DataSource = formaPagamento;
            }
            catch (Exception exception)
            {
                var msg = "Desculpe! " + exception.Message;
                MessageBox.Show(msg, "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void HabilitarTextBoxPreco()
        {
            var idPerfil = Contexto.USUARIOLOGADO.IDPerfilAcesso;
            var perfil = FuncoesPerfilAcesso.GetPerfil(idPerfil);

            if (perfil.IsAdmin == 1)
                txtPreco.Enabled = true;


        }

        private void CarregarFormasDePagamento(List<DuplicataDAC> duplicatasDAC)
        {
            foreach (var duplicata in duplicatasDAC)
            {
                FormaDePagamento formaDePagamento = FuncoesFormaDePagamento.GetFormaDePagamento(duplicata.IDFormaDePagamento);

                FormaPagamentoAux formaPagamentoAux1 = new FormaPagamentoAux()
                {
                    Identificador = lstformaPagamentoAux.Count(),
                    Cod = formaDePagamento.IDFormaDePagamento.ToString(),
                    Nome = formaDePagamento.Descricao,
                    Valor = duplicata.Valor,
                    Vencimento = duplicata.DataVencimento,
                    Pagamento = Convert.ToInt32(duplicata.Pagamento)

                };

                lstformaPagamentoAux.Add(formaPagamentoAux1);
                totalPagtoText.Text = lstformaPagamentoAux.Sum(x => x.Valor).ToString("n2");
            }
            FormatarColunasGridPagtos();
        }
        private void FormatarColunasGridPagtos()
        {

            var count = gridView2.Columns.Count();
            if (count > 0)
            {
                Grids.FormatColumnType(ref gridView2, new List<string>()
                {
                    "valor"
                }, GridFormats.Finance);

                Grids.FormatColumnType(ref gridView2, new List<string>() 
                { 
                    "identificador",
                    "sequencia",
                    "pagamento"
                }, GridFormats.VisibleFalse);

                Grids.FormatGrid(ref gridView2);
            }
              //gridView2.Columns[0].Visible = gridView2.Columns[1].Visible = gridView2.Columns[count -1].Visible = false;

        }
        private void PreencherTela()
        {


            if (Pedido.IDFormaDePagamento.HasValue)
                gridLookUpEditFormaPagamento.EditValue = Pedido.IDFormaDePagamento;



            observacaoText.Text = Pedido.Observacao;
            CarregarItens(true);
            AtualizarQuantidadeItensESubTotalVenda();
            FormatarColunasGridPagtos();
        }

        private void CarregarItens(bool Banco)
        {
            if (Banco)
                Itens = FuncoesItemPedidoCompra.GetItensPorPedido(Pedido.IDPedidoCompra);

            gridControl1.DataSource = LstItemDeCompra;
            AjustaHeaderTextGrid();
        }
        private void AjustaHeaderTextGrid()
        {

            Grids.FormatColumnType(ref gridView1, new List<string>() 
            {
                "ValorUnitario",
                "DescontoValor",
                "Total"
            }, GridFormats.Finance);

            Grids.FormatColumnType(ref gridView1, new List<string>()
            {
                "IdItemPedidoCompra",
                "IDUsuario",
                "IDProduto",
                "DescontoPorcentagem",
                "Descricao",
                "Item"

            }, GridFormats.VisibleFalse);

            Grids.FormatGrid(ref gridView1);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void FCA_PedidoCompra_Load(object sender, EventArgs e)
        {
            PreencherTela();
        }

        private void Validar()
        {
            var totalGeral = Convert.ToDecimal(tbxTotalGeral.Text);
            var totalPagamentos = Convert.ToDecimal(lstformaPagamentoAux.Sum(p => p.Valor));

            if (totalPagamentos < totalGeral)
                throw new Exception("A soma dos pagamentos não pode ser menor do que o total geral.");

        }

        private void AtualizarQuantidadeItensESubTotalVenda()
        {
            decimal ValorTotalVenda = 0;
            decimal QuantidadeItens = 0;
            decimal ValorTotalDesconto = 0;
            if (LstItemDeCompra.Count == 0)
            {
                txtQntd.Text = "0";
                totalTextEdit.Text = "0,00";
                tbxTotalGeral.Text = ValorTotalVenda.ToString("n2");
                txtDescontoGeral.Text = "";
                Pedido.Total = ValorTotalVenda;
                Pedido.QuantidadeItens = QuantidadeItens;
                LimparDados();

                salvarSimpleButton.Enabled = false;
            }
            else
            {
                foreach (ItemPedidoCompra Item in LstItemDeCompra)
                {
                    ValorTotalVenda += Item.ValorUnitario * Item.Quantidade;
                    QuantidadeItens += Item.Quantidade;
                    ValorTotalDesconto += Item.DescontoValor * Item.Quantidade;
                }
                tbxTotalGeral.Text = ValorTotalVenda.ToString("n2");
                txtDescontoGeral.Text = ValorTotalDesconto.ToString("n2");

                Pedido.Total = ValorTotalVenda;
                Pedido.QuantidadeItens = QuantidadeItens;
                gridControl2.DataSource = lstformaPagamentoAux;
                LimparDados();
            }
            AtualizarLista();
            TrocoPagamento();
        }

        private void ovGRD_Itens_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Editar Item
            Itens.DefaultView.RowFilter = "[IDITEMPEDIDOCOMPRA] = " + decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDITEMPEDIDOCOMPRA").ToString()));
            FCA_ItemPedidoCompra Form = new FCA_ItemPedidoCompra(Itens.DefaultView.ToTable());
            Form.ShowDialog(this);
            if (Form.Salvou)
            {
                DataTable dt = Form.DADOS;
                foreach (DataRow dr in dt.Rows)
                {
                    Itens.DefaultView.RowFilter = "[IDPRODUTO] = " + Convert.ToDecimal(dr["IDPRODUTO"]);
                    if (Itens.DefaultView.Count > 0)
                    {
                        Itens.DefaultView[0].BeginEdit();
                        Itens.DefaultView[0]["QUANTIDADE"] = Convert.ToDecimal(dr["QUANTIDADE"]);
                        Itens.DefaultView[0]["DESCONTO"] = Convert.ToDecimal(dr["DESCONTO"]);
                        Itens.DefaultView[0]["TOTAL"] = (Convert.ToDecimal(Itens.DefaultView[0]["VALORUNITARIO"]) * Convert.ToDecimal(Itens.DefaultView[0]["QUANTIDADE"])) - Convert.ToDecimal(Itens.DefaultView[0]["DESCONTO"]);
                        Itens.DefaultView[0].EndEdit();
                        Itens.DefaultView.RowFilter = string.Empty;
                    }
                }
            }
            Itens.DefaultView.RowFilter = string.Empty;
            CarregarItens(false);
            AtualizarQuantidadeItensESubTotalVenda();        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Editar();
        }

        private void Editar()
        {
            try
            {
                Itens.DefaultView.RowFilter = "[IDITEMPEDIDOCOMPRA] = " + decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDITEMPEDIDOCOMPRA").ToString()));
                FCA_ItemPedidoCompra Form = new FCA_ItemPedidoCompra(Itens.DefaultView.ToTable());
                Form.ShowDialog(this);
                if (Form.Salvou)
                {
                    DataTable dt = Form.DADOS;
                    foreach (DataRow dr in dt.Rows)
                    {
                        Itens.DefaultView.RowFilter = "[IDPRODUTO] = " + Convert.ToDecimal(dr["IDPRODUTO"]);
                        if (Itens.DefaultView.Count > 0)
                        {
                            Itens.DefaultView[0].BeginEdit();
                            Itens.DefaultView[0]["QUANTIDADE"] = Convert.ToDecimal(dr["QUANTIDADE"]);
                            Itens.DefaultView[0]["DESCONTO"] = Convert.ToDecimal(dr["DESCONTO"]);
                            Itens.DefaultView[0]["TOTAL"] = (Convert.ToDecimal(Itens.DefaultView[0]["VALORUNITARIO"]) * Convert.ToDecimal(Itens.DefaultView[0]["QUANTIDADE"])) - Convert.ToDecimal(Itens.DefaultView[0]["DESCONTO"]);
                            Itens.DefaultView[0].EndEdit();
                            Itens.DefaultView.RowFilter = string.Empty;
                        }
                    }
                }
                Itens.DefaultView.RowFilter = string.Empty;
                CarregarItens(false);
                AtualizarQuantidadeItensESubTotalVenda();
            }
            catch (NullReferenceException)
            {

            }
        }

        private void fecharSimpleButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void salvarSimpleButton_Click(object sender, EventArgs e)
        {
           
            if (Fornecedor == null || Comprador == null || int.Parse(gridLookUpEditTipoDeOperacao.EditValue.ToString()) == -1)
            {
               labelSelecioneTipoOperacao.Visible = int.Parse(gridLookUpEditTipoDeOperacao.EditValue.ToString()) == -1;
               labelSelecioneFornecedor.Visible = Fornecedor == null;
               labelSelecioneComprador.Visible = Comprador == null;
               return;
            }
            var msg = "Deseja Salvar o Pedido de Compra?";
            if (MensagemSimNao(msg) == DialogResult.Yes)
            {
                try
                {
                    PDVControlador.BeginTransaction();
                    Validar();
                    Pedido.Total = decimal.Parse(tbxTotalGeral.Text);
                    Pedido.IDFornecedor = null;
                    Pedido.Status = 0;
                    Pedido.Observacao = observacaoText.Text;
                    Pedido.IDTipoDeOperacao = int.Parse(gridLookUpEditTipoDeOperacao.EditValue.ToString());
                    Pedido.IDComprador = Comprador.IDUsuario;
                    Pedido.IDUsuarioCadastro = Comprador.IDUsuario;
                    Pedido.PagamentosDescricao = Pedidos.GerarPagamentosObservacao(lstformaPagamentoAux);
                    if (Fornecedor != null)
                    {
                        Pedido.IDFornecedor = Fornecedor.IDFornecedor;
                        if (!FuncoesFornecedor.Salvar(Fornecedor, FuncoesFornecedor.ExisteFornecedor(Fornecedor.IDFornecedor) ? TipoOperacao.UPDATE : TipoOperacao.INSERT))
                        {
                            throw new Exception("Não foi possível salvar o Cliente.");
                        }
                    }
                    //Objter fluxo de caixa PDV
                    decimal IDFluxo = FuncoesPedidoCompra.GetFluxoCaixa();
                    if (IDFluxo != null)
                    {
                        Pedido.IDFluxoCaixa = IDFluxo;
                        //Pedido.IDUsuario = 2;
                    }
                    if (!FuncoesPedidoCompra.Salvar(Pedido))
                    {
                        throw new Exception("Não foi possível salvar a Compra.");
                    }
                    if (!FuncoesItemPedidoCompra.RemoverItensPedidoCompra(LstItemDeCompra, Pedido.IDPedidoCompra))
                    {
                        throw new Exception("Não foi possível remover os itens da Compra.");
                    }

                    foreach (ItemPedidoCompra Item in LstItemDeCompra)
                    {
                        if (!FuncoesItemPedidoCompra.SalvarItemPedidoCompra(Item))
                        {
                            throw new Exception("Não foi possível salvar os Itens da Compra.");
                        }
                    }

                    //Duplicatas
                    FuncoesDuplicataDAC.ExcluirPorPedidoCompra(Pedido.IDPedidoCompra);

                    foreach (var item in lstformaPagamentoAux)
                    {
                        var duplicata = new DuplicataDAC()
                        {
                            IDDuplicataDAC = Sequence.GetNextID("DUPLICATADAC", "IDDUPLICATADAC"),
                            IDCompra = Pedido.IDPedidoCompra,
                            IDFormaDePagamento = decimal.Parse(item.Cod),
                            FormaDePagamento = item.Nome,
                            Valor = item.Valor,
                            DataVencimento = item.Vencimento,
                            Pagamento = item.Pagamento
                        };
                        if (!FuncoesDuplicataDAC.SalvarDuplicataDAC(duplicata))
                            throw new Exception($"Não foi possível salvar a duplicata {duplicata.IDDuplicataDAC}");
                    }
                    PDVControlador.Commit();
                    Close();
                }
                catch (Exception Ex)
                {
                    PDVControlador.Rollback();
                    MessageBox.Show(this, Ex.Message, "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void FormatarColunas()
        {
            gridView1.Columns[7].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[7].DisplayFormat.FormatString = "n2";

            gridView1.Columns[9].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[9].DisplayFormat.FormatString = "n2";

            gridView1.Columns[10].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[10].DisplayFormat.FormatString = "n2";           
        }

        private void incluirSimpleButton_Click(object sender, EventArgs e)
        {
            if (Pedido.Status != 1 && Pedido.Status != 2)
            {
                try
                {
                    IDItemPedidoCompra = 0;
                    txtQntd.Focus();

                    ValidarItem();
                    decimal quantidade = decimal.Parse(txtQntd.Text);
                    decimal descontoValor = 0;
                    decimal descontoPorcentagem = 0;
                    if (!string.IsNullOrEmpty(txtDescontoValor.Text))
                    {
                        descontoValor = decimal.Parse(txtDescontoValor.Text);

                    }
                    if (!string.IsNullOrEmpty(txtDescontoPorcent.Text))
                    {
                        descontoPorcentagem = decimal.Parse(txtDescontoPorcent.Text);

                    }
                    decimal valorcompraatualizado = decimal.Parse(txtPreco.Text);
                    drProduto[9] = valorcompraatualizado.ToString("n2");
                    decimal item = LstItemDeCompra.Count();

                    ItemPedidoCompra itemPedidoCompra = new ItemPedidoCompra()
                    {
                        Item = item + 1,
                        CodigoItem = drProduto[2].ToString().TrimEnd(),
                        DescricaoItem = drProduto[3].ToString().TrimEnd(),
                        ValorUnitario = valorcompraatualizado,
                        Total = (valorcompraatualizado - descontoValor) * quantidade,
                        IDProduto = Convert.ToDecimal(drProduto[0]),
                        IDItemPedidoCompra = Sequence.GetNextID("ITEMCOMPRA", "IDITEMCOMPRA"),
                        IDPedidoCompra = Pedido.IDPedidoCompra,
                        Quantidade = quantidade,
                        DescontoValor = descontoValor >= 0 ? descontoValor : 0,
                        DescontoPorcentagem = descontoPorcentagem >= 0 ? descontoPorcentagem : 0,
                        IDUsuario = Comprador.IDUsuario
                    };
                    FormatarColunas();
                    LstItemDeCompra.Add(itemPedidoCompra);
                    CalcularTotalGeral();
                    
                    AtualizarLista();
                    LimparDados();

                    salvarSimpleButton.Enabled = true;
                    TrocoPagamento();                    
                }
                catch (Exception ex)
                {
                    MensagemErro(ex.Message);
                }
            }
        }

        private void CalcularTotalGeral()
        {
            decimal total = 0, desconto = 0;
            foreach (var item in LstItemDeCompra)
            {
                total += item.Total;
                desconto += item.DescontoValor * item.Quantidade;
            }
            tbxTotalGeral.Text = total.ToString("n2");
            txtDescontoGeral.Text = desconto.ToString("n2");
        }

        public void LimparDados()
        {
            produtotextEdit.Text = string.Empty;
            txtQntd.Text = "1";
            txtDescontoValor.Text = string.Empty;
            txtPreco.Text = string.Empty;
            totalTextEdit.Text = string.Empty;
            txtDescontoPorcent.Text = "";
            descricaoProdutoLabelControl1.Text = "...";
            produtotextEdit.Focus();
        }
        private void AtualizarLista()
        {
            gridControl1.DataSource = LstItemDeCompra.ToList();
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.BestFitColumns();
                        
        }
        public void ValidarItem()
        {
            if (produtotextEdit.Text == string.Empty) { throw new Exception("Informe o produto."); }
            if (txtQntd.Text == string.Empty) { throw new Exception("Informe a quanidade."); }
            if (txtPreco.Text == string.Empty) { throw new Exception("Preço não informado."); }
            if (txtQntd.Value < 1 || Convert.ToInt32(txtQntd.Text) < 1) { throw new Exception("A quantidade não pode ser menor que 1"); }

            if ((decimal)txtDescontoPorcent.EditValue >= 100)
                throw new Exception("O desconto não pode maior ou igual a 100% ou maior ou igual ao preço unitário do produto");
        }

        private void cancelarItemSimpleButton1_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }

        private void ExcluirItem()
        {
            if (Pedido.Status !=1 && Pedido.Status!=2)
            {
                // Remover Item
                if (IDItemPedidoCompra != 0)
                {
                    try
                    {
                        if (MessageBox.Show(this, "Deseja Cancelar o Ítem Selecionado?", "Pedido de Compra", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            RemoverTodosPagtos();
                            LstItemDeCompra = LstItemDeCompra.Where(o => o.IDItemPedidoCompra != IDItemPedidoCompra).ToList();
                           
                            AtualizarQuantidadeItensESubTotalVenda();
                            AtualizarLista();
                            IDItemPedidoCompra = 0;
                        }
                        TrocoPagamento();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Nenhum ítem foi selecionado.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void buscarProdutosimpleButton_Click(object sender, EventArgs e)
        {
            if (Fornecedor == null || Comprador == null)
            {
                labelSelecioneFornecedor.Visible = Fornecedor == null;
                labelSelecioneComprador.Visible = Comprador == null;
            }
            var form = new DACPesquisarProduto();
            form.ShowDialog();
            var itensProduto = form.GetProdutosSelecionados();
            if (itensProduto != null)
            {
                if (itensProduto.Count == 1)
                {
                    CodProduto = itensProduto[0].IDProduto.ToString();
                    produtotextEdit.Text = !string.IsNullOrEmpty(itensProduto[0].Nome) ? itensProduto[0].Nome : "";
                    txtQntd.Value = itensProduto[0].Quantidade;
                }
                else if(itensProduto.Count > 1)
                {
                    decimal itemContagem = LstItemDeCompra.Count();

                    foreach (var item in itensProduto)
                    {
                        Produto produto = FuncoesProduto.GetProdutoCodigo(item.IDProduto.ToString());
                        if (produto != null)
                        {
                            ItemPedidoCompra itemPedidoCompra = new ItemPedidoCompra()
                            {
                                Item = itemContagem++,
                                CodigoItem = produto.Codigo.ToString(),
                                DescricaoItem = item.Nome,
                                ValorUnitario = produto.ValorCusto,
                                Total = produto.ValorVenda * item.Quantidade,
                                IDProduto = produto.IDProduto,
                                IDItemPedidoCompra = Sequence.GetNextID("ITEMCOMPRA", "IDITEMCOMPRA"),
                                IDPedidoCompra = Pedido.IDPedidoCompra,
                                Quantidade = item.Quantidade,
                                DescontoValor = 0,
                                DescontoPorcentagem = 0,
                                IDUsuario = Comprador.IDUsuario
                            };
                            LstItemDeCompra.Add(itemPedidoCompra);
                        }
                    }
                    FormatarColunas();
                    CalcularTotalGeral();
                    CalcularTroco(lstformaPagamentoAux.Sum(p => p.Valor));
                    AtualizarLista();
                    int formaDePagamento = -1;
                    try
                    {
                        formaDePagamento = int.Parse(gridLookUpEditFormaPagamento.EditValue.ToString());
                        
                    }
                    catch (FormatException)
                    {
                        formaDePagamento = -1;
                    }
                    if (formaDePagamento != -1)
                    {
                        carregarFormaDePagamento(formaDePagamento);
                    }
                    
                    salvarSimpleButton.Enabled = true;
                }
                LocalizarPorduto();
                
                CalcularValorDesconto();
                CalcularTotalProduto();
            }
            
        }
        private void quantidadeTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (txtQntd.Value < 1)
                txtQntd.Value = 1;
            CalcularTotalProduto();
            AlterarItemSimpleButton.Enabled = false;
        }
        private void CalcularTotalProduto()
        {
            try
            {
                if (!txtDescontoValor.Text.Contains("-"))
                {
                    var precoStr = txtPreco.Text.Replace(".", ",").Replace("R$ ", "");
                    var quantidade = decimal.Parse(txtQntd.Text);
                    var preco = decimal.Parse(precoStr);
                    var desconto = decimal.Parse(txtDescontoValor.Text.Replace("R$", ""));
                    var total = quantidade * (preco - desconto);
                    totalTextEdit.Text = total.ToString("n2");
                }
            }
            catch (Exception exception)
            {
                MensagemErro(exception.Message);
            }
            
        }
        private void LocalizarPorduto()
        {
            if (produtotextEdit.Text != string.Empty)
            {
                try
                {
                    decimal codigo = Convert.ToDecimal(produtotextEdit.Text);
                    CodProduto = codigo.ToString();
                }
                catch (FormatException)
                {

                }
                catch (OverflowException)
                {
                    MessageBox.Show("O Código inserido é muito longo");
                    txtPreco.Text = produtotextEdit.Text = descricaoProdutoLabelControl1.Text = "";

                    return;
                }
               
                if (CodProduto!=null)
                {
                    drProduto = FuncoesProduto.GetProdutoPorCodigoPDV(CodProduto.Trim());

                    if (drProduto != null)
                    {
                        //Setando campos
                        txtQntd.Focus();
                        txtDescontoValor.Text = "0";
                        produtotextEdit.Text = descricaoProdutoLabelControl1.Text = drProduto["PRODUTO"].ToString().TrimEnd();
                        txtPreco.Text = Convert.ToDecimal(drProduto["VALORCUSTO"]).ToString("n2");
                    }
                    else
                    {
                        MessageBox.Show("Produto não foi localizado");
                        txtPreco.Text = produtotextEdit.Text = descricaoProdutoLabelControl1.Text = "";
                    }
                }
            
            }
        }
        
        private void descontoPercentualTextEdit_Leave(object sender, EventArgs e)
        {
            CalcularValorDesconto();
        }
        private void CalcularValorDesconto()
        {
            try
            {
                var porcentagemDesconto = (decimal)txtDescontoPorcent.EditValue;
                var preco = (decimal)txtPreco.EditValue;
                var valorDesconto = (porcentagemDesconto / 100) * preco;
                txtDescontoValor.EditValue = valorDesconto >= 0 ? Math.Round(valorDesconto, 2) : 0;
            }
            catch (DivideByZeroException)
            {
                txtDescontoValor.EditValue = 0;
            }
            
        }

        private void descontoValorTextEdit_Leave(object sender, EventArgs e)
        {
            CalcularPorcentagemDesconto();
        }

        private void CalcularPorcentagemDesconto()
        {
            try
            {
                var valorDesconto = (decimal)txtDescontoValor.EditValue;
                var preco = (decimal)txtPreco.EditValue;
                var porcentagemDesconto = (valorDesconto * 100) / preco;
                txtDescontoPorcent.EditValue = porcentagemDesconto >=0 ? Math.Round(porcentagemDesconto, 2) : 0;
            }
            catch (DivideByZeroException)
            {
                txtDescontoPorcent.EditValue = 0;
            }
                       

        }
        private void quantidadeTextEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtQntd.Value < 1)
                txtQntd.Value = 1;
            CalcularTotalProduto();
            if (e.KeyCode == Keys.Enter)
                if (txtQntd.Text != string.Empty && (decimal)txtQntd.EditValue > 0)                    
                    incluirSimpleButton_Click(sender, e);

        }
        private void descontoPercentualTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                if (txtQntd.Text != string.Empty)
                {
                    CalcularTotalProduto();
                    incluirSimpleButton_Click(sender, e);
                }
            }
        }
        private void descontoValorTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtQntd.Text != string.Empty)
                {
                    CalcularTotalProduto();
                    incluirSimpleButton_Click(sender, e);
                }
            }
        }

        private void pesquisarFornecedorSmpleButton_Click(object sender, EventArgs e)
        {
            DACPesquisarFornecedores dACPesquisarFornecedor = new DACPesquisarFornecedores();
            dACPesquisarFornecedor.ShowDialog();            
            var fornecedor = FuncoesFornecedor.GetFornecedor(Convert.ToDecimal(dACPesquisarFornecedor.Codigo));
            if (fornecedor !=null)
            {
                Fornecedor = fornecedor;
                fornecedortextEdit.Text = dACPesquisarFornecedor.Nome;
            }
            pesquisarFornecedorSmpleButton.Focus();

            labelSelecioneFornecedor.Visible = Fornecedor == null;
        }
        private void carregarFormaDePagamento(int FormaPagamento)
        {
            lstformaPagamentoAux = null;
            gridControl2.DataSource = null;


            FormaDePagamento formaDePagamento = new FormaDePagamento();
            formaDePagamento = FuncoesFormaDePagamento.GetFormaDePagamento(decimal.Parse(FormaPagamento.ToString()));

            int FatorPeriodicidade = 0;


            if (string.IsNullOrEmpty(tbxTotalGeral.Text))
            {
                MessageBox.Show(this, "Infome o valor recebido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (FormaPagamento == 0)
            {
                //MessageBox.Show(this, "Infome a forma de pagamento", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (formaDePagamento.Periodicidade == "Diário")
            {
                FatorPeriodicidade = 1;
            }
            else if (formaDePagamento.Periodicidade == "Semanal")
            {
                FatorPeriodicidade = 7;
            }
            else if (formaDePagamento.Periodicidade == "Quinzenal")
            {
                FatorPeriodicidade = 15;
            }
            else if (formaDePagamento.Periodicidade == "Mensal")
            {
                FatorPeriodicidade = 30;
            }
            else if (formaDePagamento.Periodicidade == "Trimestral")
            {
                FatorPeriodicidade = 90;
            }
            else if (formaDePagamento.Periodicidade == "Semestral")
            {
                FatorPeriodicidade = 180;
            }
            else if (formaDePagamento.Periodicidade == "Anual")
            {
                FatorPeriodicidade = 365;
            }
            lstformaPagamentoAux = new List<FormaPagamentoAux>();

            DateTime ultimoVencimento = DateTime.Now;
            if (formaDePagamento.Qtd_Parcelas == 0 || formaDePagamento.Qtd_Parcelas == null)
            {

                MessageBox.Show(this, "Forma de pagamento não está configurada. Verifique a quantidade de parcelas.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < formaDePagamento.Qtd_Parcelas; i++)
            {
                FormaPagamentoAux formaPagamentoAux1 = new FormaPagamentoAux()
                {
                    Identificador = lstformaPagamentoAux.Count(),
                    Cod = gridLookUpEditFormaPagamento.EditValue.ToString(),
                    Nome = gridLookUpEditFormaPagamento.Text,
                    Valor = decimal.Parse(tbxTotalGeral.Text.ToString()) / formaDePagamento.Qtd_Parcelas,
                    Vencimento = ultimoVencimento.AddDays(FatorPeriodicidade)
                };
               
                ultimoVencimento = formaPagamentoAux1.Vencimento;
                lstformaPagamentoAux.Add(formaPagamentoAux1);
                
            }
            AtualizarGrid(lstformaPagamentoAux);
            

            FormatarColunasGridPagtos();
        }
        private void AtualizarGrid(List<FormaPagamentoAux> lstformaPagamentoAux)
        {
            gridControl2.DataSource = lstformaPagamentoAux.ToList();
            gridView1.BestFitColumns();
        }
        private void buttonAdicionarFornecedor_Click(object sender, EventArgs e)
        {
            FCA_Fornecedor fCA_Fornecedor = new FCA_Fornecedor(new Fornecedor());
            fCA_Fornecedor.ShowDialog();
            Fornecedor = FuncoesFornecedor.GetFornecedor(fCA_Fornecedor.GetFornecedorID());            
            if (Fornecedor != null) 
                fornecedortextEdit.Text = Fornecedor.RazaoSocial;

        }

        private void buttonAdicionarProduto_Click(object sender, EventArgs e)
        {
            FCA_Produtos fCA_Produtos = new FCA_Produtos(new Produto());
            fCA_Produtos.ShowDialog();
            Produto produto = fCA_Produtos.GetProduto();
            CodProduto = produto.Codigo;
            produtotextEdit.Text = produto.Descricao;
            LocalizarPorduto();
        }

        private void buttonFormaDePagamento_Click(object sender, EventArgs e)
        {
            FCA_FormaDePagamento fCA_FormaDePagamento = new FCA_FormaDePagamento(new FormaDePagamento());
            fCA_FormaDePagamento.ShowDialog();
            var formaPagamento = FuncoesFormaDePagamento.GetFormasPagamento().Select(s => new { Cod = s.IDFormaDePagamento, Nome = s.Identificacao }).OrderBy(x => x.Cod).ToList();
            gridLookUpEditFormaPagamento.Properties.DataSource = formaPagamento;
            if (fCA_FormaDePagamento.GetFormaDePagamentoID() >= 0)
                gridLookUpEditFormaPagamento.EditValue = fCA_FormaDePagamento.GetFormaDePagamentoID();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Vendas.NFe.FCA_TipoDeOperacao fCA_TipoDeOperacao = new Vendas.NFe.FCA_TipoDeOperacao(new TipoDeOperacao(), DAO.Enum.Operacao.DeEntrada);
            fCA_TipoDeOperacao.ShowDialog();

            var tipoDeOperacao = FuncoesTipoDeOperacao.GetTiposDeOperacaoPorTipoDeMovimento(TipoDeOperacao.Entrada)
                                                        .Select(s => new { Cod = s.IDTipoDeOperacao, Nome = s.Nome })
                                                        .OrderBy(x => x.Cod).ToList();


    

            gridLookUpEditTipoDeOperacao.Properties.DataSource = tipoDeOperacao;
            gridLookUpEditTipoDeOperacao.EditValue = fCA_TipoDeOperacao.GetTipoDeOperacaoID();
        }

        

        private void FCA_PedidoCompra_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    pesquisarFornecedorSmpleButton_Click(sender, e);
                    break;
                case Keys.F2:
                    pesquisarCompradorSimpleButton_Click(sender, e);
                    break;
                case Keys.Insert:
                    incluirSimpleButton_Click(sender, e);
                    break;
                case Keys.F6:
                    buscarProdutosimpleButton_Click(sender, e);
                    break;
                case Keys.F7:
                    salvarSimpleButton_Click(sender, e);
                    break;

                case Keys.F8:
                    txtDescontoPorcent.Focus();
                    break;
                case Keys.F9:
                    txtDescontoValor.Focus();
                    break;

                case Keys.F12:
                    fecharSimpleButton_Click(sender, e);
                    break;
            }
        }

        private void buttonAdicionarVendedor_Click(object sender, EventArgs e)
        {
            FCA_Usuario fCA_Usuario = new FCA_Usuario(new Usuario());
            fCA_Usuario.ShowDialog();
            Fornecedor = FuncoesFornecedor.GetFornecedor(fCA_Usuario.GetUsuarioID());
            if(Fornecedor != null)
                fornecedortextEdit.Text = Fornecedor.RazaoSocial;
        }

        private void pesquisarCompradorSimpleButton_Click(object sender, EventArgs e)
        {
            DACPesquisarCompradores dACPesquisarComprador = new DACPesquisarCompradores();
            dACPesquisarComprador.ShowDialog();
            var comprador = FuncoesUsuario.GetUsuario(Convert.ToDecimal(dACPesquisarComprador.Codigo));
            if (comprador != null)
            {
                Comprador = comprador;
                compradorTextEdit.Text = dACPesquisarComprador.Nome;
            }
            pesquisarCompradorSimpleButton.Focus();


            labelSelecioneComprador.Visible = Comprador == null;
        }


        private void fornecedortextEdit_Enter(object sender, EventArgs e)
        {
            labelSelecioneFornecedor.Visible = false;
        }

        private void compradorTextEdit_Enter(object sender, EventArgs e)
        {
            labelSelecioneComprador.Visible = false;
        }


        private void gridView1_Click(object sender, EventArgs e)        
        {
            try
            {
                IDItemPedidoCompra = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["IDITEMPEDIDOCOMPRA"].FieldName).ToString()));
            }
            catch (Exception)
            {
                IDItemPedidoCompra = 0;
            }

        }

        private void produtotextEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                LocalizarPorduto();
                CalcularValorDesconto();
                CalcularTotalProduto();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            ExcluirItem();
        }

        private void gridLookUpEditTipoDeOperacao_MouseEnter(object sender, EventArgs e)
        {
            labelSelecioneTipoOperacao.Visible = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            RemoverTodosPagtos();
        }

        private void RemoverTodosPagtos()
        {
            if (MensagemSimNao("Deseja remover todas as formas de pagamento?") == DialogResult.Yes)
            {
                lstformaPagamentoAux.Clear();
                gridControl2.DataSource = null;
                totalPagtoText.Text = "0,00";
                TrocoPagamento();
            }
            
        }

        private void adicionarFormaPagamentoSimpleButton_Click(object sender, EventArgs e)
        {
            AdicionarFormaPagamentoGrid();
        }
        public void AdicionarFormaPagamentoGrid()
        {
            if (string.IsNullOrEmpty(valorPagtoText.Text))
            {
                MessageBox.Show(this, "Infome o valor recebido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valorPagtoText.Focus();
                return;
            }
            try
            {
                Convert.ToDecimal(valorPagtoText.EditValue);
            }
            catch (FormatException)
            {
                valorPagtoText.EditValue = "0,00";
                MessageBox.Show(this, "O valor recebido continha caracteres estranhos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valorPagtoText.Focus();
                return;
            }
            if (valorPagtoText.Text.Contains('.'))
            {
                MessageBox.Show(this, "Não insira pontos no valor recebido, somente vírgula.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valorPagtoText.Focus();
                return;
            }
            if (Convert.ToDecimal(valorPagtoText.EditValue) <= 0)
            {
                MessageBox.Show(this, "O valor recebido não pode ser menor ou igual a 0.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valorPagtoText.Focus();
                return;
            }
            try
            {
                if (Convert.ToInt16(gridLookUpEditFormaPagamento.EditValue) == 0 || gridLookUpEditFormaPagamento.EditValue.ToString() == "...")
                {
                    MessageBox.Show(this, "Informe a forma de pagamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(this, "Informe a forma de pagamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            
            TrocoPagamento();
            if (gridLookUpEditFormaPagamento.EditValue.ToString() != "...")
            {
                decimal totalRecebido = valorPagtoText.EditValue.ToString() == "" ? 0 : Convert.ToDecimal(valorPagtoText.EditValue);
                int formaPagamento = int.Parse(gridLookUpEditFormaPagamento.EditValue.ToString());
                CarregarFormaDePagamento(formaPagamento, totalRecebido);
            }
            gridLookUpEditFormaPagamento.EditValue = "...";
        }
        private void TrocoPagamento()
        {
            decimal totalRecebido = valorPagtoText.EditValue.ToString() == "" ? 0 : Convert.ToDecimal(valorPagtoText.EditValue);
            CalcularTroco(totalRecebido);
            AlterarItemSimpleButton.Enabled = false;
        }        
        private void CalcularTroco(decimal valorRecebido)
        {
            if (valorRecebido <= 0)
                valorRecebido = 0;
            try
            {
                decimal valorTotalPago = Convert.ToDecimal(totalPagtoText.EditValue);
                decimal ValorTotalVenda = decimal.Parse(tbxTotalGeral.Text);
                decimal troco = valorRecebido + valorTotalPago - ValorTotalVenda;
                trocoTextEdit.Text = troco.ToString("C");
                if (troco > 0)
                {
                    labelControl11.Text = "TROCO R$";
                    trocoTextEdit.BackColor = Color.Green;
                    trocoTextEdit.ForeColor = Color.White;
                }
                else if (troco == 0)
                {
                    labelControl11.Text = "TROCO R$";
                    trocoTextEdit.BackColor = Color.White;
                    trocoTextEdit.ForeColor = Color.Black;
                }
                else
                {
                    labelControl11.Text = "FALTA R$";
                    trocoTextEdit.BackColor = Color.Red;
                    trocoTextEdit.ForeColor = Color.White;
                }
            }
            catch (Exception)
            {

            }
        }
        

        private void totalRecebidoTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    AdicionarFormaPagamentoGrid();
                    break;
            }
        }

        private void totalRecebidoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                
                CalcularTroco(decimal.Parse(valorPagtoText.Text));
            }
            catch (Exception)
            {

            }

        }

        private void AlterarItemSimpleButton_Click(object sender, EventArgs e)
        {            
            EditarItemDeCompraSelecionado();            
        }

        private void EditarItemDeCompraSelecionado()
        {
            CodProduto = ItemDeCompraSelec.CodigoItem;
            txtQntd.Value = ItemDeCompraSelec.Quantidade;

            if (ItemDeCompraSelec != null)
            {

                drProduto = FuncoesProduto.GetProdutoPorCodigoPDV(CodProduto.Trim());
                txtQntd.Focus();

                var descricao = ItemDeCompraSelec.DescricaoItem != null ? ItemDeCompraSelec.DescricaoItem : ItemDeCompraSelec.Descricao;
                produtotextEdit.Text = descricaoProdutoLabelControl1.Text = descricao;


                txtQntd.Value = ItemDeCompraSelec.Quantidade;
                txtDescontoValor.Text = ItemDeCompraSelec.DescontoValor.ToString();//Recebe o desconto somente em valor
                txtPreco.Text = Convert.ToDecimal(ItemDeCompraSelec.ValorUnitario).ToString("n2");
                CalcularPorcentagemDesconto();//Calcula a porcentagem do desconto

                LstItemDeCompra.Remove(ItemDeCompraSelec);
            }
            else
            {
                MessageBox.Show("Produto não foi localizado");
                txtPreco.Text = descricaoProdutoLabelControl1.Text = CodProduto = produtotextEdit.Text = "";
            }

            AtualizarLista();
            AlterarItemSimpleButton.Enabled = false;

            decimal ValorTotalVenda = 0;
            decimal QuantidadeItens = 0;
            decimal ValorTotalDesconto = 0;
            foreach (ItemPedidoCompra Item in LstItemDeCompra)
            {
                ValorTotalVenda += Item.ValorUnitario * Item.Quantidade;
                QuantidadeItens += Item.Quantidade;
                ValorTotalDesconto += Item.DescontoValor * Item.Quantidade;
            }
            tbxTotalGeral.Text = ValorTotalVenda.ToString("n2");
            txtDescontoGeral.Text = ValorTotalDesconto.ToString("n2");

            Pedido.Total = ValorTotalVenda;
            Pedido.QuantidadeItens = QuantidadeItens;
            gridControl2.DataSource = lstformaPagamentoAux;

            CalcularTotalProduto();
            TrocoPagamento();
        }

        private void gridView1_Click_1(object sender, EventArgs e)
        {
            try
            {
                IDItemPedidoCompra = Grids.GetValorDec(gridView1, "IDItemPedidoCompra");
                ItemDeCompraSelec = LstItemDeCompra.SingleOrDefault(x => x.IDItemPedidoCompra == IDItemPedidoCompra);
                AlterarItemSimpleButton.Enabled = true;
            }
            catch (Exception)
            {
                IDItemPedidoCompra = 0;
            }
        }

        private void CarregarFormaDePagamento(int FormaPagamento, decimal valorRecebido)
        {
            FormaDePagamento formaDePagamento = FuncoesFormaDePagamento.GetFormaDePagamento(decimal.Parse(FormaPagamento.ToString()));
            int fatorPeriodicidade = 0;

            if (FormaPagamento == 0)
            {
                MessageBox.Show(this, "Infome a forma de pagamento", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                fatorPeriodicidade = Periodicidade.Fator(formaDePagamento.Periodicidade);

                DateTime ultimoVencimento = DateTime.Now;
                if (formaDePagamento.Qtd_Parcelas == 0 || formaDePagamento.Qtd_Parcelas == null)
                {
                    MessageBox.Show(this, "Forma de pagamento não está configurada. Verifique a quantidade de parcelas.", "Pedido de Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (fatorPeriodicidade == 1)
                {
                    ultimoVencimento = ultimoVencimento.AddDays(formaDePagamento.Qtd_Parcelas - fatorPeriodicidade);
                    formaDePagamento.Qtd_Parcelas = 1;
                }
                    


                int pagamento = lstformaPagamentoAux.Count() == 0 ? 0: lstformaPagamentoAux.Max(x => x.Pagamento) + 1;

                for (int i = 0; i < formaDePagamento.Qtd_Parcelas; i++)
                {
                    FormaPagamentoAux formaPagamentoAux1 = new FormaPagamentoAux()
                    {
                        Identificador = lstformaPagamentoAux.Count(),
                        Sequencia = i + 1,
                        Cod = formaDePagamento.IDFormaDePagamento.ToString(),
                        Nome = formaDePagamento.Descricao,
                        Valor = valorRecebido / formaDePagamento.Qtd_Parcelas,
                        Vencimento = ultimoVencimento.AddDays(fatorPeriodicidade),
                        Pagamento = pagamento
                    };

                    ultimoVencimento = formaPagamentoAux1.Vencimento;
                    lstformaPagamentoAux.Add(formaPagamentoAux1);
                    totalPagtoText.Text = lstformaPagamentoAux.Sum(x => x.Valor).ToString("n2");
                }
                AtualizarGrid(lstformaPagamentoAux);
                //limpando valor recebido;
                valorPagtoText.Text = "";
                gridView2.Columns[3].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView2.Columns[3].DisplayFormat.FormatString = "n2";
            }
            FormatarColunasGridPagtos();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {

            CancelarFormaDePagamento();
            
        }

        private void CancelarFormaDePagamento()
        {
            try
            {
                if (MessageBox.Show(this, "Deseja Cancelar a Forma de Pagamento do Item Selecionado?", "Pedido de Venda", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    IDItemFormaPagamento = Grids.GetValorDec(gridView2, "Cod");
                    lstformaPagamentoAux = lstformaPagamentoAux.Where(o => o.Cod != IDItemFormaPagamento.ToString()).ToList();
                    AtualizarQuantidadeItensESubTotalVenda();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Pedido de Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            decimal totalRecebido = 0;

            foreach (var item in lstformaPagamentoAux)
            {
                totalRecebido += item.Valor;
            }

            totalPagtoText.EditValue = Math.Round(totalRecebido, 2).ToString();

            CalcularTroco(totalRecebido);
        }

        private void LocalizarFornecedor()
        {
            try
            {
                if (fornecedortextEdit.Text != string.Empty)
                {

                    try
                    {
                        CodFornecedor = fornecedortextEdit.Text.Trim();


                        Fornecedor = FuncoesFornecedor.GetFornecedor(Convert.ToDecimal(CodFornecedor));
                        if (Fornecedor == null)
                            Fornecedor = FuncoesFornecedor.GetFornecedorPorCNPJ(CodFornecedor);

                        if (Fornecedor != null)
                        {
                            fornecedortextEdit.Text = Fornecedor.Descricao == null ? Fornecedor.RazaoSocial : Fornecedor.Descricao;
                        }
                        else
                        {
                            MessageBox.Show("Fornecedor não foi localizado");
                            CodFornecedor = fornecedortextEdit.Text = "";
                        }
                    }
                    catch (FormatException)
                    {

                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("O número inserido é muito longo");
                        return;
                    }
                }
            }
            catch (Exception)
            {

              
            }
           
        }
        private void LocalizarComprador()
        {
            if (compradorTextEdit.Text != string.Empty)
            {

                try
                {
                    CodComprador = Convert.ToDecimal(compradorTextEdit.Text.Trim()).ToString();


                    Comprador = FuncoesUsuario.GetUsuario(Convert.ToDecimal(CodComprador));
                    if (Comprador !=null)
                    {
                        if (Comprador.IsComprador == 0)
                        {
                            Comprador = null;
                            MessageBox.Show("Comprador não foi localizado");
                        }
                    }
                    if (Comprador != null)
                    {
                        compradorTextEdit.Text = Comprador.Nome;
                    }
                    else
                    {
                        MessageBox.Show("Comprador não foi localizado");
                        CodComprador = compradorTextEdit.Text = "";
                    }
                }
                catch (FormatException)
                {

                }
                catch (OverflowException)
                {
                    MessageBox.Show("O número inserido é muito longo");
                    return;
                }
            }
        }

        private void fornecedortextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LocalizarFornecedor();
            }
        }

        private void compradorTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LocalizarComprador();
            }
        }

        private void FormaDePagamentoEditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (trocoTextEdit.Text.Contains("-R$"))
                {
                    valorPagtoText.Text = valorPagtoText.Text.ToString().Replace("-R$", "");
                    decimal totalrestante = decimal.Parse(trocoTextEdit.Text.Replace("-R$", ""));
                    valorPagtoText.Text = totalrestante.ToString();
                    valorPagtoText.Focus();
                    valorPagtoText.SelectAll();
                }
            }
            catch (Exception ex)
            {


            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Pedido.DataEmissao = dateTimePicker1.Value;
        }

        private void precoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (txtQntd.Value < 1)
                txtQntd.Value = 1;
            CalcularTotalProduto();
            AlterarItemSimpleButton.Enabled = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {



            
            if (gridView2.GetSelectedRows().Length < 1)
                MessageBox.Show("Escolha um pagamento para excluir", "Excluir Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (lstformaPagamentoAux.Count > 0)
                RemoverPagto();
            else
                MessageBox.Show("Ainda não há pagamentos inseridos", "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


        }

        private void MudarValidade()
        {

            try
            {
                var identSelecionado = Grids.GetValorInt(gridView2, "Identificador");

                var pagamento = lstformaPagamentoAux.Single(l => l.Identificador == identSelecionado);
                var dataVencimentoDav = new DataVencimentoDAC(pagamento.Vencimento);
                dataVencimentoDav.ShowDialog();

                pagamento.Vencimento = dataVencimentoDav.DataDeVencimento;

                gridControl2.DataSource = lstformaPagamentoAux;
                gridControl2.Focus();
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Ops!", MessageBoxButtons.OK);
            }
        }

        private void RemoverPagto()
        {
            try
            {
                var msg = "Deseja Cancelar a Forma de Pagamento do Item Selecionado?";
                if (MensagemSimNao(msg) == DialogResult.Yes)
                {
                    IDItemFormaPagamento = Grids.GetValorDec(gridView2, "Cod");
                    lstformaPagamentoAux = lstformaPagamentoAux.Where(o => o.Cod != IDItemFormaPagamento.ToString()).ToList();
                    AtualizarQuantidadeItensESubTotalVenda();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            decimal valorPagamento = 0;

            foreach (var item in lstformaPagamentoAux)
            {
                valorPagamento += item.Valor;
            }

            totalPagtoText.EditValue = Math.Round(valorPagamento, 2).ToString();

            CalcularTroco(valorPagamento);
        }
        public DialogResult MensagemSimNao(string msg)
        {
            return MessageBox.Show(msg, "Pedido de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void descontoPercentualTextEdit_KeyUp(object sender, KeyEventArgs e)
        {
            // Não permitir valores negativos
            if (txtDescontoPorcent.Text.Contains('-'))
                txtDescontoPorcent.Text = txtDescontoPorcent.Text.Replace("-", "");
            
            
            CalcularValorDesconto();
            CalcularTotalProduto();
        }

        private void txtDescontoValor_KeyUp(object sender, KeyEventArgs e)
        {
            // Não permitir valores negativos
            if (txtDescontoValor.Text.Contains('-'))
                txtDescontoValor.Text = txtDescontoValor.Text.Replace("-", "");


            CalcularPorcentagemDesconto();
            CalcularTotalProduto();
        }

        private void txtDescontoValor_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            // Não permitir valores negativo
            try
            {
                var val = Convert.ToDouble(txtDescontoValor.Text.Replace("R$", "").Replace(" ", ""));
                if (val < 0.1 && !e.IsSpinUp)
                    txtDescontoValor.Text = "0";
            }
            catch (Exception exception)
            {

                MensagemErro(exception.Message);
            }
        }

        private void txtDescontoPorcent_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            // Não permitir valores negativos
            try
            {
                var val = Convert.ToDouble(txtDescontoPorcent.Text.Replace("%", ""));
                if (val < 0.1 && !e.IsSpinUp)
                    txtDescontoPorcent.EditValue = 0;
            }
            catch (Exception exception)
            {
                MensagemErro(exception.Message);
            }
            
        }

        public void MensagemErro(string msg)
        {
            MessageBox.Show(msg, nomeTela, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void KeyDownIncluir(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                incluirSimpleButton_Click(sender, e);
        }

        private void txtDescontoValor_EditValueChanged(object sender, EventArgs e)
        {
            CalcularPorcentagemDesconto();
            CalcularTotalProduto();
        }

        private void txtDescontoPorcent_EditValueChanged(object sender, EventArgs e)
        {
            CalcularValorDesconto();
            CalcularTotalProduto();
        }
    }

}
