using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.PDV;
using PDV.UTIL.Components;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Util;
using PDV.VIEW.Forms.Vendas.NFe;
using PDV.VIEW.FRENTECAIXA.Forms.PDV.DAV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Sequence = PDV.DAO.DB.Utils.Sequence;
using static System.Convert;

namespace PDV.VIEW.Forms.Gerenciamento.DAV
{
    public partial class PedidoVendaItem : Form
    {
        public const string nomeTela = "CADASTRO DE PEDIDO DE VENDA";

        public Venda Venda = null;

        public string CodProduto { get; set; }

        public string CodCliente { get; set; }

        public string CodVendedor { get; set; }

        public decimal IDItemFormaPagamento { get; set; }

        public decimal IDItemVenda { get; set; }

        public List<ItemVenda> LstItensDeVenda { get; set; } = null;

        public ItemVenda ItemDeVendaSelec { get; set; }

        public bool Alteracao = false;

        public List<DuplicataNFCe> lstPagamentos = null;

        public List<FormaPagamentoAux> LstFormaDePagamentoAux;

        public FuncoesComanda Comanda = null;

        public Cliente Cliente = null;

        public Usuario Vendedor = null;

        private DataRow drProduto = null;

        LoginAdminDAV loginAdminDAV = new LoginAdminDAV();


        public PedidoVendaItem(int idVenda)
        {
            InitializeComponent();
            LstFormaDePagamentoAux = new List<FormaPagamentoAux>();
            CarregarComboboxFormaPagamento();
            if (idVenda == 0)
            {
                IniciarVenda();
                dateTimePicker1.Value = DateTime.Now;
            }
            else
            {
                Alteracao = true;
                Venda = FuncoesVenda.GetVenda(ToDecimal(idVenda));
                dateTimePicker1.Value = Venda.DataCadastro;

                DefinirLabelStatus();
                CarregarItensVenda(idVenda);

                if (Venda.IDCliente != null)
                {
                    Cliente = FuncoesCliente.GetCliente(ToDecimal(Venda.IDCliente));
                    clientetextEdit.Text = Cliente.Nome != null ? Cliente.Nome : Cliente.NomeFantasia;
                    observacaoRichTextBox.Text = Venda.Observacao;
                    textObra.Text = Venda.Obra;
                    textValorAVistaProposto.EditValue = Venda.ValorAVistaProposto;
                    if (Venda.IDVendedor == null)
                    {
                        Venda.IDVendedor = Cliente.IDVendedor;
                    }
                    Vendedor = FuncoesUsuario.GetUsuario(ToDecimal(Venda.IDVendedor));
                    vendedortextEdit.Text = Vendedor.Nome;
                }

                AtualizarQuantidadeItensESubTotalVenda();
                gridLookUpEditFormaPagamento.EditValue = Venda.IDFormaPagamento;

                var duplicataNFCes = FuncoesItemDuplicataNFCe.GetPagamentosPorVenda(Venda.IDVenda);


                CarregarFormasDePagamento(duplicataNFCes);
                CalcularTroco(duplicataNFCes.Sum(x => x.Valor) - Venda.ValorTotal);

            }
            spinQuantidade.Text = "1";
            var tipoDeOperacao = FuncoesTipoDeOperacao.GetTiposDeOperacaoPorTipoDeMovimento(TipoDeOperacao.Saida)
                                                        .Select(s => new { Cod = s.IDTipoDeOperacao, Nome = s.Nome })
                                                        .OrderBy(x => x.Cod)
                                                        .ToList();


            gridLookUpEditTipoDeOperacao.Properties.DataSource = tipoDeOperacao;
            gridLookUpEditTipoDeOperacao.EditValue = Venda.IDTipoDeOperacao;
            // Permitir acesso ao cadastro de Cliente
            //buttonAdicionarCliente.Visible = FuncoesPerfilAcesso.PermitirAcesso(Contexto.USUARIOLOGADO.IDPerfilAcesso, 16);
            HabilitarTextBoxPreco();
            valorPagtoText.Text = "0,00";
            CarregarPermissoes();
        }

        private void CarregarItensVenda(int idVenda)
        {
            LstItensDeVenda = FuncoesItemVenda.GetItensVenda(idVenda);
            LstItensDeVenda.ForEach(i => i.Subtotal = ItemVendaUtil.GetTotalItem(i));
        }

        private void DefinirLabelStatus()
        {
            switch (Venda.Status)
            {
                case 0:
                    labelStatus.Text = "ABERTO";
                    salvarSimpleButton.Enabled = true;
                    break;
                case 1:
                    labelStatus.Text = "FATURADO";
                    labelStatus.ForeColor = Color.LightGreen;
                    salvarSimpleButton.Enabled =
                    incluirSimpleButton.Enabled =
                    cancelarItemSimpleButton1.Enabled =
                    salvarSimpleButton.Enabled =
                    falseSimpleButton.Enabled =
                    dateTimePicker1.Enabled = false;
                    break;
                case 2:
                    labelStatus.Text = "CANCELADO";
                    labelStatus.ForeColor = Color.OrangeRed;
                    salvarSimpleButton.Enabled =
                    incluirSimpleButton.Enabled =
                    cancelarItemSimpleButton1.Enabled =
                    cancelarItemSimpleButton1.Enabled =
                    salvarSimpleButton.Enabled =
                    falseSimpleButton.Enabled =
                    dateTimePicker1.Enabled = false;
                    break;
                case 4:
                    labelStatus.Text = "APP";
                    salvarSimpleButton.Enabled = true;
                    break;
            }
        }

        private void CarregarPermissoes()
        {
            PermissoesUtil.VerificarPermissaoParaTela(FCA_Cliente.idsMenuItem, ref buttonAdicionarCliente);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_Usuario.idsMenuItem, ref buttonAdicionarVendedor);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_TipoDeOperacao.idsMenuItem, ref buttonAdicionarTipoDeOperacao);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_FormaDePagamento.idsMenuItem, ref buttonAdicionarFormaDePagamento);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_Produtos.idsMenuItem, ref buttonAdicionarProduto);
        }

        public void FormatarColunas()
        {
            Grids.FormatColumnType(ref gridView1, new List<string>()
            {
                "DescontoValor",
                "Quantidade",
                "ValorUnitarioItem",
                "ValorTotalItem"

            }, GridFormats.Finance);

            Grids.FormatColumnType(ref gridView1, new List<string>()
            {
                "IDProduto",
                "Descricao",
                "DescontoPorcentagem",
                "IDUsuario",
                "Marca",
                "Item",
                "Altura",
                "Largura",
                "Area"

            }, GridFormats.VisibleFalse);


            Grids.FormatGrid(ref gridView1);
        }
        private void CarregarComboboxFormaPagamento()
        {
            var formaPagamento = FuncoesFormaDePagamento.GetFormasPagamento().Select(s => new { Cod = s.IDFormaDePagamento, Nome = s.Identificacao }).OrderBy(x => x.Cod).ToList();
            gridLookUpEditFormaPagamento.Properties.DataSource = formaPagamento;
        }

        private void AtualizarQuantidadeItensESubTotalVenda()
        {
            decimal ValorTotalVenda = 0;
            decimal QuantidadeItens = 0;
            decimal ValorTotalDesconto = 0;
            if (LstItensDeVenda.Count == 0)
            {
                spinQuantidade.Text = "0";
                txtTotal.Text = "0,00";
                totalGeralText.Text = ValorTotalVenda.ToString("n2");
                totalDescontoTextEdit.Text = "";
                Venda.ValorTotal = ValorTotalVenda;
                Venda.QuantidadeItens = QuantidadeItens;
                LimparDados();

                salvarSimpleButton.Enabled = false;
            }
            else
            {


                foreach (ItemVenda Item in LstItensDeVenda)
                {
                    ValorTotalVenda += Item.Subtotal;
                    QuantidadeItens += Item.Quantidade;
                    ValorTotalDesconto += Item.DescontoValor * Item.Quantidade;
                }
                totalGeralText.Text = ValorTotalVenda.ToString("n2");
                totalDescontoTextEdit.Text = ValorTotalDesconto.ToString("n2");

                Venda.ValorTotal = ValorTotalVenda;
                Venda.QuantidadeItens = QuantidadeItens;

                LimparDados();
            }
            gridControl2.DataSource = LstFormaDePagamentoAux;
            AtualizarLista();
            TrocoPagamento();
            FormatarGridFormaPagtos();
        }
        private void buscarProdutosimpleButton_Click(object sender, EventArgs e)
        {
            if (Cliente == null || Vendedor == null)
            {
                labelSelecioneCliente.Visible = Cliente == null;
                labelSelecioneVendedor.Visible = Vendedor == null && Cliente != null;
                return;
            }

            var form = new DAVPesquisarProduto();
            form.ShowDialog();
            var itensProduto = form.GetProdutosSelecionados();
            if (itensProduto != null)
            {
                if (itensProduto.Count == 1)
                {
                    CodProduto = itensProduto[0].IDProduto.ToString();
                    produtotextEdit.Text = !string.IsNullOrEmpty(itensProduto[0].Nome) ? itensProduto[0].Nome : "";
                    spinQuantidade.Value = itensProduto[0].Quantidade;
                }
                else if (itensProduto.Count > 1)
                {
                    var itemContagem = LstItensDeVenda.Count();

                    foreach (var item in itensProduto)
                    {
                        var produto = FuncoesProduto.GetProdutoCodigo(item.IDProduto.ToString());
                        if (produto != null)
                        {
                            var itemPedidoCompra = new ItemVenda()
                            {
                                Item = itemContagem++,
                                CodigoItem = produto.EAN,
                                DescricaoItem = item.Nome,
                                ValorUnitarioItem = produto.ValorVenda,
                                Subtotal = produto.ValorVenda * item.Quantidade,
                                IDProduto = produto.IDProduto,
                                IDItemVenda = Sequence.GetNextID("ITEMVENDA", "IDITEMVENDA"),
                                IDVenda = Venda.IDVenda,
                                Quantidade = item.Quantidade,
                                DescontoValor = 0,
                                DescontoPorcentagem = 0,
                                IDUsuario = Vendedor.IDUsuario
                            };
                            LstItensDeVenda.Add(itemPedidoCompra);
                        }
                    }


                    decimal ValorTotalPedidoCompra = 0;
                    decimal ValorTotalDesconto = 0;
                    foreach (ItemVenda Item in LstItensDeVenda)
                    {
                        ValorTotalPedidoCompra += Item.Subtotal;
                        ValorTotalDesconto += Item.DescontoValor * Item.Quantidade;
                    }
                    totalGeralText.Text = ValorTotalPedidoCompra.ToString("n2");
                    totalDescontoTextEdit.Text = ValorTotalDesconto.ToString("n2");
                    AtualizarLista();

                    salvarSimpleButton.Enabled = true;
                }


                LocalizarProduto();
                CalcularTotalItem();
                TrocoPagamento();
            }

            spinQuantidade.Text = "1";

        }

        private void HabilitarTextBoxPreco()
        {
            var idPerfil = Contexto.USUARIOLOGADO.IDPerfilAcesso;
            var perfil = FuncoesPerfilAcesso.GetPerfil(idPerfil);

            if (perfil.IsAdmin == 1)
                spinPreco.Enabled = true;


        }
        private void produtotextEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LocalizarProduto();
                CalcularTotalItem();
            }
        }

        private void LocalizarProduto()
        {
            if (produtotextEdit.Text != string.Empty)
            {

                try
                {
                    decimal codigo = ToDecimal(produtotextEdit.Text);
                    CodProduto = codigo.ToString();
                }
                catch (FormatException)
                {
                }
                catch (OverflowException)
                {
                    MessageBox.Show("O código inserido é muito longo");
                    spinPreco.Text = descricaoProdutoLabelControl1.Text = CodProduto = produtotextEdit.Text = "";
                    return;
                }
                drProduto = FuncoesProduto.GetProdutoPorCodigoPDV(CodProduto.Trim());
                if (drProduto != null)
                {
                    //Setando campos
                    spinQuantidade.Focus();
                    spinDescontoValor.Text = "0";
                    produtotextEdit.Text = descricaoProdutoLabelControl1.Text = drProduto["PRODUTO"].ToString().TrimEnd();
                    spinPreco.Text = ToDecimal(drProduto["PRECOVENDA"]).ToString("n2");
                    VerificarDimensao();

                }
                else
                {
                    MessageBox.Show("Produto não foi localizado");
                    spinPreco.Text = descricaoProdutoLabelControl1.Text = CodProduto = produtotextEdit.Text = "";
                }

            }
        }

        private void VerificarDimensao()
        {
            var unidadeDeMedidaSigla = drProduto["unidadedemedidasigla"].ToString();
            AlturaLarguraEAreaVisiveis(unidadeDeMedidaSigla == "M2");
        }

        private void AlturaLarguraEAreaVisiveis(bool isVisible)
        {
            labelAltura.Visible =
            labelLargura.Visible =
            labelArea.Visible =
            spinAltura.Visible =
            spinLargura.Visible =
            spinArea.Visible = isVisible;

            spinAltura.EditValue =
            spinLargura.EditValue =
            spinArea.EditValue = 0;
        }

        private void CalcularTotalItem()
        {
            try
            {
                if (!spinDescontoValor.Text.Contains("-"))
                {
                    decimal total;
                    total = GetTotalItem();
                    txtTotal.Text = total.ToString("n2");
                }
            }
            catch (Exception exception)
            {
                Alert(exception.Message);
            }
        }

        private decimal GetTotalItem()
        {
            var precoStr = spinPreco.Text.Replace(".", ",").Replace("R$ ", "");
            var quantidade = decimal.Parse(spinQuantidade.Text);
            var preco = decimal.Parse(precoStr);
            var desconto = decimal.Parse(spinDescontoValor.Text.Replace("R$", ""));

            if (spinArea.Visible)
            {
                var area = ToDecimal(spinArea.EditValue);

                if (area > 0)
                    return ItemVendaUtil.GetTotalItem(quantidade, preco, desconto, area);
                return ItemVendaUtil.GetTotalItem(quantidade, preco, desconto);
            }

            return ItemVendaUtil.GetTotalItem(quantidade, preco, desconto);            
        }

        public void IniciarVenda()
        {
            LstItensDeVenda = new List<ItemVenda>();
            Venda = new Venda
            {
                IDVenda = Sequence.GetNextID("VENDA", "IDVENDA"),
                IDUsuario = 1,
                DataCadastro = DateTime.Now,
                Status = 0,
                IDFluxoCaixa = 0
            };

        }
        private void incluirSimpleButton_Click(object sender, EventArgs e)
        {
            if (Venda.Status != 1 && Venda.Status != 2)
            {
                if (Cliente == null || Vendedor == null)
                {
                    labelSelecioneCliente.Visible = Cliente == null;
                    labelSelecioneVendedor.Visible = Vendedor == null && Cliente != null;
                }
                else
                {
                    try
                    {
                        IDItemVenda = 0;
                        spinQuantidade.Focus();
                        if (PermitirDesconto())
                        {
                            ValidarItem();
                            decimal descontoValor = 0, descontoPorcentagem = 0;

                            if (!string.IsNullOrEmpty(spinDescontoValor.Text))
                            {
                                descontoValor = decimal.Parse(spinDescontoValor.Text);

                            }
                            if (!string.IsNullOrEmpty(txtDescontoPorcent.Text))
                            {
                                descontoPorcentagem = decimal.Parse(txtDescontoPorcent.Text);

                            }
                            decimal valorvendaatualizado = decimal.Parse(spinPreco.Text);
                            drProduto[8] = valorvendaatualizado.ToString("n2");

                            AdicionarItemALista(descontoValor, descontoPorcentagem);
                            CalcularTotalGeral();

                            AtualizarLista();
                            LimparDados();
                            salvarSimpleButton.Enabled = true;
                        }

                        CodProduto = "";
                    }
                    catch (Exception ex)
                    {
                        Alert(ex.Message);
                    }
                    TrocoPagamento();
                }
            }

        }

        private void CalcularTotalGeral()
        {
            decimal totalGeral = 0, totalDesconto = 0;

            foreach (var item in LstItensDeVenda)
            {
                totalGeral += item.Subtotal;
                totalDesconto += item.DescontoValor * item.Quantidade;
            }

            totalGeralText.Text = totalGeral.ToString("n2");
            totalDescontoTextEdit.Text = totalDesconto.ToString("n2");
        }

        private void AdicionarItemALista(decimal descontoValor, decimal descontoPorcentagem)
        {
            decimal quantidade, item, largura, area, altura;
            quantidade = decimal.Parse(spinQuantidade.Text);
            item = LstItensDeVenda.Count();
            largura = ToDecimal(spinLargura.EditValue);
            area = ToDecimal(spinArea.EditValue);
            altura = ToDecimal(spinAltura.EditValue);
            
            var itemVenda = new ItemVenda
            {
                Item = item + 1,
                CodigoItem = drProduto[2].ToString().TrimEnd(),
                DescricaoItem = drProduto[3].ToString().TrimEnd(),
                ValorUnitarioItem = ToDecimal(spinPreco.Text),
                Subtotal = GetTotalItem(),
                IDProduto = ToDecimal(drProduto[0]),
                IDItemVenda = Sequence.GetNextID("ITEMVENDA", "IDITEMVENDA"),
                IDVenda = Venda.IDVenda,
                Quantidade = quantidade,
                DescontoValor = descontoValor >= 0 ? descontoValor : 0,
                DescontoPorcentagem = descontoPorcentagem >= 0 ? descontoPorcentagem : 0,
                IDUsuario = Vendedor.IDUsuario,
                Largura = largura,
                Area = area,
                Altura = altura
            };
            LstItensDeVenda.Add(itemVenda);
        }

        private void AtualizarLista()
        {
            gridControl1.DataSource = LstItensDeVenda.ToList();
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.BestFitColumns();
            FormatarColunas();
        }

        public void ValidarItem()
        {
            if (produtotextEdit.Text == string.Empty) { throw new Exception("Informe o produto."); }
            if (spinQuantidade.Text == string.Empty) { throw new Exception("Informe a quantidade."); }
            if (spinPreco.Text == string.Empty) { throw new Exception("Preço não informado."); }
            if (spinQuantidade.Value < 1 || ToInt32(spinQuantidade.Text) < 1) { throw new Exception("A quantidade não pode ser menor que 1"); }

            if ((decimal)txtDescontoPorcent.EditValue >= 100)
                throw new Exception("O desconto não pode maior ou igual a 100% ou maior ou igual ao preço unitário do produto");

        }
        public void LimparDados()
        {
            produtotextEdit.Text = string.Empty;
            spinQuantidade.Text = "1";
            spinDescontoValor.Text = string.Empty;
            spinPreco.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtDescontoPorcent.Text = "";
            descricaoProdutoLabelControl1.Text = "...";
            produtotextEdit.Focus();
        }
        private void quantidadeTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (spinQuantidade.Value < 1)
                spinQuantidade.Value = 1;
            CalcularTotalItem();
            AlterarItemSimpleButton.Enabled = false;
        }

        private void salvarSimpleButton_Click(object sender, EventArgs e)
        {
            if (Cliente == null || Vendedor == null || int.Parse(gridLookUpEditTipoDeOperacao.EditValue.ToString()) == 0)
            {

                labelSelecioneOperacao.Visible = int.Parse(gridLookUpEditTipoDeOperacao.EditValue.ToString()) == 0;
                labelSelecioneCliente.Visible = Cliente == null;
                labelSelecioneVendedor.Visible = Vendedor == null && Cliente != null;

            }
            else if (MessageBox.Show(this, "Deseja Salvar o Pedido?", "Pedido de Venda", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    PDVControlador.BeginTransaction();
                    ValidarPagamentos();
                    PreencherVenda();
                    if (Cliente != null)
                    {
                        Venda.IDCliente = Cliente.IDCliente;
                        if (!FuncoesCliente.SalvarAtualizarClienteNFCe(Cliente.Nome, Cliente.IDCliente, Cliente.Email, Cliente._CPF_CNPJ, Cliente.TipoDocumento))
                        {
                            throw new Exception("Não foi possível salvar o Cliente.");
                        }
                    }
                    //Objter fluxo de caixa PDV
                    decimal IDFluxo = FuncoesVenda.GetFluxoCaixa();
                    if (IDFluxo != null)
                    {
                        Venda.IDFluxoCaixa = IDFluxo;
                    }
                    if (!FuncoesVenda.SalvarVenda(Venda))
                    {
                        throw new Exception("Não foi possível salvar a Venda.");
                    }
                    if (!FuncoesItemVenda.RemoverItensDaVenda(LstItensDeVenda, Venda.IDVenda))
                    {
                        throw new Exception("Não foi possível salvar a Venda.");
                    }

                    LstItensDeVenda.ForEach(i => SalvarItemVenda(i));

                    //Duplicatas
                    FuncoesItemDuplicataNFCe.ExcluirPorVenda(Venda.IDVenda);

                    LstFormaDePagamentoAux.ForEach(f => SalvarDuplicatas(f));

                    PDVControlador.Commit();
                    Close();
                }
                catch (Exception Ex)
                {
                    PDVControlador.Rollback();
                    MessageBox.Show(this, Ex.Message, "Pedido de Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            void SalvarItemVenda(ItemVenda item)
            {
                if (!FuncoesItemVenda.SalvarItemVenda(item))
                    throw new Exception("Não foi possível salvar os Itens da Venda.");
            }
        }

        private void ValidarPagamentos()
        {
            decimal totalPagamentos = ToDecimal(totalPagtosText.EditValue), totalGeral = ToDecimal(totalGeralText.EditValue);
            var valido = LstFormaDePagamentoAux.Count() == 0 || totalPagamentos >= totalGeral;

            if (!valido)
                throw new Exception("O total pago não pode ser menor que o valor total.");
        }

        private void PreencherVenda()
        {
            Venda.ValorTotal = decimal.Parse(totalGeralText.Text);
            Venda.IDCliente = null;

           // lstPagamentos = FuncoesItemDuplicataNFCe.GetPagamentosPorVenda(Venda.IDVenda);


            foreach (var pagamento in LstFormaDePagamentoAux)
            {
                var formaDePagamento = FuncoesFormaDePagamento.GetFormaDePagamento(Convert.ToDecimal(pagamento.Cod)); ;

                if (formaDePagamento.Codigo == FormaDePagamento.CodigoDinheiro)
                    Venda.Dinheiro = pagamento.Valor;
            }

            

            Venda.Status = 0;
            Venda.Observacao = observacaoRichTextBox.Text;
            Venda.PagamentosDescricao = Pedidos.GerarPagamentosObservacao(LstFormaDePagamentoAux);
            Venda.IDTipoDeOperacao = int.Parse(gridLookUpEditTipoDeOperacao.EditValue.ToString());
            Venda.IDVendedor = Vendedor.IDUsuario;
            Venda.IDUsuario = Vendedor.IDUsuario;
            Venda.Obra = textObra.Text;
            Venda.TipoDeVenda = 2;
            Venda.ValorAVistaProposto = ToDecimal(textValorAVistaProposto.EditValue);
        }

        private void SalvarDuplicatas(FormaPagamentoAux item)
        {
            var duplicata = new DuplicataNFCe
            {
                IDDuplicataNFCe = Sequence.GetNextID("DUPLICATANFCE", "IDDUPLICATANFCE"),
                IDVenda = Venda.IDVenda,
                IDFormaDePagamento = decimal.Parse(item.Cod),
                FormaDePagamento = item.Nome,
                Valor = item.Valor,
                DataVencimento = item.Vencimento,
                Pagamento = item.Pagamento
            };

            if (!FuncoesItemDuplicataNFCe.SalvarDuplicataNFCe(duplicata))
                throw new Exception($"Não foi possível salvar a duplicata {duplicata.IDDuplicataNFCe}");
        }

        private void AlterarSimpleButton_Click(object sender, EventArgs e)
        {
            //GPDV_IdentificarClienteDAV Identificar = new GPDV_IdentificarClienteDAV();
            //Identificar.ShowDialog(this);
            //if (Identificar.Identificar)
            //{
            //    if (Identificar.DRCliente != null)
            //    {
            //        Cliente = FuncoesCliente.GetCliente(ToDecimal(Identificar.DRCliente["IDCLIENTE"]));
            //    }
            //    else
            //    {
            //        Cliente = new Cliente
            //        {
            //            TipoDocumento = ToDecimal(Identificar.ovTXT_TipoPessoa.Text),
            //            Nome = Identificar.ovTXT_NomeCliente.Text,
            //            CPF = ToDecimal(Identificar.ovTXT_TipoPessoa.Text) == 1 ? ZeusUtil.SomenteNumeros(Identificar.ovTXT_CPFCNPJ.Text) : null,
            //            CNPJ = ToDecimal(Identificar.ovTXT_TipoPessoa.Text) == 0 ? ZeusUtil.SomenteNumeros(Identificar.ovTXT_CPFCNPJ.Text) : null,
            //            Email = Identificar.ovTXT_EmailCliente.Text
            //        };
            //    }

            //    documentoLabelControl1.Text = Cliente._CPF_CNPJ;
            //    clienteLabelControl.Text = Cliente.Nome;
            //}
            //else
            //{
            //    Cliente = null;
            //    documentoLabelControl1.Text = "<CPF/CNPJ Não Informado>";
            //    clienteLabelControl.Text = "<Cliente> Não Indenificado";
            //}
        }

        private void DAVPedido_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    AlterarSimpleButton_Click(sender, e);
                    break;
                case Keys.F2:
                    pesquisarVendedorSimpleButton_Click(sender, e);
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
                    spinDescontoValor.Focus();
                    break;

                case Keys.F12:
                    fecharSimpleButton_Click(sender, e);
                    break;
            }
        }

        private void fecharSimpleButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void cancelarItemSimpleButton1_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }

        private void ExcluirItem()

        {
            if (Venda.Status != 1 && Venda.Status != 2)
            {
                if (IDItemVenda != 0)
                {
                    try
                    {

                        if (MessageBox.Show(this, "Deseja Cancelar o Ítem Selecionado?", "Pedido de Venda", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            RemoverPagto();
                            LstItensDeVenda = LstItensDeVenda.Where(o => o.IDItemVenda != IDItemVenda).ToList();
                           
                            

                            AtualizarQuantidadeItensESubTotalVenda();
                            AtualizarLista();
                            IDItemVenda = 0;

                            decimal totalRecebido = valorPagtoText.EditValue.ToString() == "" ? 0 : ToDecimal(valorPagtoText.EditValue);
                            TrocoPagamento();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Pedido de Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Nenhum ítem foi selecionado.", "Pedido de Venda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }


        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                
                IDItemVenda = Grids.GetValorDec(gridView1, "IDItemVenda");
                ItemDeVendaSelec = LstItensDeVenda.SingleOrDefault(x => x.IDItemVenda == IDItemVenda);
                AlterarItemSimpleButton.Enabled = true;
            }
            catch (Exception)
            {
                IDItemVenda = 0;
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AtualizarLista();
        }
        private void descontoPercentualTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (spinQuantidade.Text != string.Empty)
                {
                    CalcularTotalItem();
                    incluirSimpleButton_Click(sender, e);
                }
            }
        }

        private void descontoValorTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (spinQuantidade.Text != string.Empty)
                {
                    CalcularTotalItem();
                    incluirSimpleButton_Click(sender, e);
                }
            }
        }

        private void AtualizarGird(List<FormaPagamentoAux> lstformaPagamentoAux)
        {
            gridControl2.DataSource = lstformaPagamentoAux.ToList();
            gridView1.BestFitColumns();
        }
        private void CarregarFormasDePagamento(List<DuplicataNFCe> duplicatasNFCe)
        {
            int seq = 1;
            foreach (var duplicata in duplicatasNFCe)
            {

                FormaDePagamento formaDePagamento = FuncoesFormaDePagamento.GetFormaDePagamento(duplicata.IDFormaDePagamento);
                FormaPagamentoAux formaPagamentoAux1 = new FormaPagamentoAux()
                {
                    Identificador = LstFormaDePagamentoAux.Count(),
                    Sequencia = seq++,
                    Cod = formaDePagamento.IDFormaDePagamento.ToString(),
                    Nome = formaDePagamento.Identificacao,
                    Valor = duplicata.Valor,
                    Vencimento = duplicata.DataVencimento,
                    Pagamento = ToInt32(duplicata.Pagamento)
                };

                LstFormaDePagamentoAux.Add(formaPagamentoAux1);
                totalPagtosText.Text = LstFormaDePagamentoAux.Sum(x => x.Valor).ToString("n2");
            }
            FormatarGridFormaPagtos();
        }
        private void CarregarFormasDePagamento(int FormaPagamento, decimal valorRecebido)
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
                fatorPeriodicidade = FatorPeriodicidade(formaDePagamento.Periodicidade);

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

                decimal pagamento = LstFormaDePagamentoAux.Count() == 0 ? 0 : LstFormaDePagamentoAux.Max(x => x.Pagamento) + 1;
                for (int i = 0; i < formaDePagamento.Qtd_Parcelas; i++)
                {
                    FormaPagamentoAux formaPagamentoAux1 = new FormaPagamentoAux()
                    {
                        Identificador = LstFormaDePagamentoAux.Count(),
                        Sequencia = i + 1,
                        Cod = formaDePagamento.IDFormaDePagamento.ToString(),
                        Nome = $"{formaDePagamento.Identificacao} ({formaDePagamento.Descricao})",
                        Valor = valorRecebido / formaDePagamento.Qtd_Parcelas,
                        Vencimento = ultimoVencimento.AddDays(fatorPeriodicidade),
                        Pagamento = ToInt32(pagamento)
                    };

                    ultimoVencimento = formaPagamentoAux1.Vencimento;
                    LstFormaDePagamentoAux.Add(formaPagamentoAux1);
                    totalPagtosText.Text = LstFormaDePagamentoAux.Sum(x => x.Valor).ToString("n2");
                }
                AtualizarGird(LstFormaDePagamentoAux);

                
                //limpando valor recebido;
                valorPagtoText.Text = "";
                gridView2.Columns[3].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView2.Columns[3].DisplayFormat.FormatString = "n2";
            }
            FormatarGridFormaPagtos();
        }
        private void FormatarGridFormaPagtos()
        {
            var count = gridView2.Columns.Count();
            if (count > 0)
            {

                Grids.FormatColumnType(ref gridView2, new List<string>()
                {
                    "Identificador",
                    "Sequencia",
                    "Pagamento"
                }, GridFormats.VisibleFalse);

                Grids.FormatColumnType(ref gridView2, "Valor", GridFormats.Finance);
                Grids.FormatColumnType(ref gridView2, "Valor", GridFormats.SumFinance);

                Grids.FormatGrid(ref gridView2);
            }

        }
        private int FatorPeriodicidade(string periodicidade)
        {
            int fator = 0;
            if (periodicidade == "Diário")
            {
                fator = 1;
            }
            else if (periodicidade == "Semanal")
            {
                fator = 7;
            }
            else if (periodicidade == "Quinzenal")
            {
                fator = 15;
            }
            else if (periodicidade == "Mensal")
            {
                fator = 30;
            }
            else if (periodicidade == "35 Dias")
            {
                fator = 35;
            }
            else if (periodicidade == "45 Dias")
            {
                fator = 45;
            }
            else if (periodicidade == "Bienal")
            {
                fator = 60;
            }
            else if (periodicidade == "Trimestral")
            {
                fator = 90;
            }
            else if (periodicidade == "Semestral")
            {
                fator = 180;
            }
            else if (periodicidade == "Anual")
            {
                fator = 365;
            }
            return fator;
        }

        private void RemoverPagto()
        {
            try
            {




                var msg = "Deseja Cancelar a Forma de Pagamento do Item Selecionado?";
                if (Confirm(msg) == DialogResult.Yes)
                {
                    IDItemFormaPagamento = Grids.GetValorDec(gridView2, "Cod");
                    LstFormaDePagamentoAux = LstFormaDePagamentoAux.Where(o => o.Cod != IDItemFormaPagamento.ToString()).ToList();
                    AtualizarQuantidadeItensESubTotalVenda();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(this,"Nenhuma forma de pagamento foi inserida.", "Pedido de Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            decimal valorPagamento = 0;

            foreach (var item in LstFormaDePagamentoAux)
            {
                valorPagamento += item.Valor;
            }

            totalPagtosText.EditValue = Math.Round(valorPagamento, 2).ToString();

            CalcularTroco(valorPagamento);
        }

        private void pesquisarClienteSimpleButton_Click(object sender, EventArgs e)
        {
            DAVPesquisarClientes dAVPesquisarClientes = new DAVPesquisarClientes();
            dAVPesquisarClientes.ShowDialog();
            var cliente = FuncoesCliente.GetCliente(ToDecimal(dAVPesquisarClientes.Codigo));

            if (cliente != null)
            {
                Cliente = cliente;
                clientetextEdit.Text = Cliente.RazaoSocial != null ? Cliente.RazaoSocial : Cliente.Nome;
                Vendedor = FuncoesUsuario.GetUsuario(Cliente.IDVendedor);
                vendedortextEdit.Text = Vendedor != null ? Vendedor.Nome : "";
            }
            labelSelecioneCliente.Visible = false;
            pesquisarClienteSimpleButton.Focus();
        }
        private void gridLookUpEditTipoDeOperacao_Enter(object sender, EventArgs e)
        {
            labelSelecioneOperacao.Visible = false;
        }

        private void buttonAdicionarFormaPagamento_Click(object sender, EventArgs e)
        {
            FCA_FormaDePagamento fCA_FormaDePagamento = new FCA_FormaDePagamento(new FormaDePagamento());
            fCA_FormaDePagamento.ShowDialog();
            CarregarComboboxFormaPagamento();
            if (fCA_FormaDePagamento.GetFormaDePagamentoID() >= 0)
                gridLookUpEditFormaPagamento.EditValue = fCA_FormaDePagamento.GetFormaDePagamentoID();
        }

        private void buttonAdicionarCliente_Click(object sender, EventArgs e)
        {
            FCA_Cliente fCA_Cliente = new FCA_Cliente(new Cliente());
            fCA_Cliente.ShowDialog();
            Cliente = FuncoesCliente.GetCliente(fCA_Cliente.GetClienteID());
            if (Cliente != null)
            {
                clientetextEdit.Text = Cliente.RazaoSocial != null ? Cliente.RazaoSocial : Cliente.Nome;
                Vendedor = FuncoesUsuario.GetUsuario(Cliente.IDVendedor);
                vendedortextEdit.Text = Vendedor.Nome;
            }

        }

        private void buttonAdicionarProduto_Click(object sender, EventArgs e)
        {
            FCA_Produtos fCA_Produtos = new FCA_Produtos(new Produto());
            fCA_Produtos.ShowDialog();
            Produto produto = fCA_Produtos.GetProduto();
            CodProduto = produto.Codigo;
            produtotextEdit.Text = produto.Descricao;
            LocalizarProduto();

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var fCA_TipoDeOperacao = new FCA_TipoDeOperacao(new TipoDeOperacao(), DAO.Enum.Operacao.DeSaida);
            fCA_TipoDeOperacao.ShowDialog();
            var tipoDeOperacao = FuncoesTipoDeOperacao.GetTiposDeOperacaoPorTipoDeMovimento(TipoDeOperacao.Saida)
                                                       .Select(s => new { Cod = s.IDTipoDeOperacao, Nome = s.Nome })
                                                       .OrderBy(x => x.Cod).ToList();


            gridLookUpEditTipoDeOperacao.Properties.DataSource = tipoDeOperacao;
            gridLookUpEditTipoDeOperacao.EditValue = fCA_TipoDeOperacao.GetTipoDeOperacaoID();
        }

        private void pesquisarVendedorSimpleButton_Click(object sender, EventArgs e)
        {

            PerfilAcesso perfil = FuncoesPerfilAcesso.GetPerfil(Contexto.USUARIOLOGADO.IDPerfilAcesso);
            if (perfil.IsAdmin == 0)
            {
                string mensagem = "Você não tem acesso a este campo. Insira os dados de um usuário admnistrador para continuar.";
                if (MessageBox.Show(this, mensagem, "Pedido de Venda", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    loginAdminDAV.ShowDialog();
            }
            if (loginAdminDAV.isLogado || perfil.IsAdmin == 1)
            {
                DAVPesquisarVendedores dAVPesquisarVendedores = new DAVPesquisarVendedores();
                dAVPesquisarVendedores.ShowDialog();

                var vendedor = FuncoesUsuario.GetUsuario(ToDecimal(dAVPesquisarVendedores.Codigo));
                if (vendedor != null)
                {
                    Vendedor = vendedor;
                    vendedortextEdit.Text = dAVPesquisarVendedores.Nome;
                }

                loginAdminDAV.isLogado = false;
            }

            labelSelecioneCliente.Visible = false;
            labelSelecioneVendedor.Visible = false;
            pesquisarVendedorSimpleButton.Focus();
        }

        public bool PermitirDesconto()
        {
            PerfilAcesso perfil = FuncoesPerfilAcesso.GetPerfil(Vendedor.IDPerfilAcesso);
            decimal valorDoDesconto = 0;
            string valorMaximoFormatado = "";
            string mensagem = "";
            bool pedirLogin;
            bool permitirDesconto = true;

            switch (Vendedor.FormaDesconto)
            {
                case 1:
                    valorDoDesconto = spinDescontoValor.Value;
                    valorMaximoFormatado = Vendedor.DescontoMaximo.ToString("c");
                    break;
                case 2:
                    valorDoDesconto = txtDescontoPorcent.Value;
                    valorMaximoFormatado = Vendedor.DescontoMaximo + "%";
                    break;
            }

            mensagem = $"Desconto para {Vendedor.Nome} não pode ser maior do que {valorMaximoFormatado} . Insira dados de um usuário administrador para obter essa permissão.";
            pedirLogin = valorDoDesconto > Vendedor.DescontoMaximo && perfil.IsAdmin != 1;

            if (pedirLogin)
            {
                if (MessageBox.Show(this, mensagem, "Pedido de Venda", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    loginAdminDAV.ShowDialog();

                if (!loginAdminDAV.isLogado)
                {
                    txtDescontoPorcent.Text = "";
                    spinDescontoValor.Text = "";
                    txtTotal.EditValue = spinPreco.Text;
                    permitirDesconto = false;
                }
            }
            loginAdminDAV.isLogado = false;
            return permitirDesconto;
        }

        private void precoTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            ExcluirItem();
        }

        private void adicionarFormaPagamentoSimpleButton_Click(object sender, EventArgs e)
        {
            AdicionarFormapagamentoGrid();

        }

        private void AdicionarFormapagamentoGrid()
        {
            if (string.IsNullOrEmpty(valorPagtoText.Text))
            {
                MessageBox.Show(this, "Infome o valor recebido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valorPagtoText.Focus();
                return;
            }
            try
            {
                ToDecimal(valorPagtoText.EditValue);
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
            if (ToDecimal(valorPagtoText.EditValue) <= 0)
            {
                MessageBox.Show(this, "O valor recebido não pode ser menor ou igual a 0.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valorPagtoText.Focus();
                return;
            }
            if (gridLookUpEditFormaPagamento.EditValue == "...")
            {
                MessageBox.Show(this, "Informe a forma de pagamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TrocoPagamento();
            if (gridLookUpEditFormaPagamento.EditValue.ToString() != "...")
            {
                decimal totalRecebido = valorPagtoText.EditValue.ToString() == "" ? 0 : ToDecimal(valorPagtoText.EditValue);
                int formaPagamento = int.Parse(gridLookUpEditFormaPagamento.EditValue.ToString());
                CarregarFormasDePagamento(formaPagamento, totalRecebido);
            }
            gridLookUpEditFormaPagamento.EditValue = "...";
        }

        void CalcularTroco(decimal ValorRecebido)
        {
            if (ValorRecebido <= 0)
                ValorRecebido = 0;
            try
            {
                decimal valorTotalPago = ToDecimal(totalPagtosText.EditValue);
                decimal ValorTotalVenda = decimal.Parse(totalGeralText.Text);
                decimal troco = ValorRecebido + valorTotalPago - ValorTotalVenda;
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

        private void totalRecebidoTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AdicionarFormapagamentoGrid();
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

            if (gridView2.GetSelectedRows().Length < 1)
                MessageBox.Show("Escolha um pagamento para excluir", "Excluir Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (LstFormaDePagamentoAux.Count > 0)
                RemoverPagto();
            else
                MessageBox.Show("Ainda não há pagamentos inseridos", "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void AlterarItemSimpleButton_Click(object sender, EventArgs e)
        {
            EditarItemDeVendaSelecionado();
        }

        private void EditarItemDeVendaSelecionado()
        {
            try
            {
                CodProduto = ItemDeVendaSelec.CodigoItem;
                spinQuantidade.Value = ItemDeVendaSelec.Quantidade;

                if (ItemDeVendaSelec != null)
                {
                    drProduto = FuncoesProduto.GetProdutoPorCodigoPDV(CodProduto.Trim());
                    spinQuantidade.Focus();

                    var descricao = ItemDeVendaSelec.DescricaoItem != null ? ItemDeVendaSelec.DescricaoItem : ItemDeVendaSelec.Descricao;
                    produtotextEdit.Text = descricaoProdutoLabelControl1.Text = descricao;
                    PreencherCampos();
                    CalcularPorcentagemDesconto();//Calcula a porcentagem do desconto

                    LstItensDeVenda.Remove(ItemDeVendaSelec);
                }
                else
                {
                   Alert("Produto não foi localizado");
                   spinPreco.Text = descricaoProdutoLabelControl1.Text = CodProduto = produtotextEdit.Text = "";
                }
            }
            catch (Exception exception)
            {
               Alert($"Desculpe! Encontramos uma excessão: {exception.Message}");
            }

            AtualizarLista();
            AlterarItemSimpleButton.Enabled = false;

            decimal ValorTotalVenda = 0, QuantidadeItens = 0, ValorTotalDesconto = 0;
            foreach (ItemVenda Item in LstItensDeVenda)
            {
                ValorTotalVenda += Item.ValorUnitarioItem * Item.Quantidade;
                QuantidadeItens += Item.Quantidade;
                ValorTotalDesconto += Item.DescontoValor * Item.Quantidade;
            }
            totalGeralText.Text = ValorTotalVenda.ToString("n2");
            totalDescontoTextEdit.Text = ValorTotalDesconto.ToString("n2");

            Venda.ValorTotal = ValorTotalVenda;
            Venda.QuantidadeItens = QuantidadeItens;
            gridControl2.DataSource = LstFormaDePagamentoAux;

            CalcularTotalItem();
            TrocoPagamento();

            void PreencherCampos()
            {
                if (ItemDeVendaSelec.Area != 0)
                {
                    AlturaLarguraEAreaVisiveis(true);
                    spinAltura.EditValue = ItemDeVendaSelec.Altura;
                    spinLargura.EditValue = ItemDeVendaSelec.Largura;
                    spinArea.EditValue = ItemDeVendaSelec.Area;
                }
                spinQuantidade.Value = ItemDeVendaSelec.Quantidade;
                spinDescontoValor.Text = ItemDeVendaSelec.DescontoValor.ToString();//Recebe o desconto somente em valor
                spinPreco.Text = ToDecimal(ItemDeVendaSelec.ValorUnitarioItem).ToString("n2");
            }
        }

        private void TrocoPagamento()
        {
            decimal totalRecebido = valorPagtoText.EditValue.ToString() == "" ? 0 : ToDecimal(valorPagtoText.EditValue.ToString().Replace("-R$", ""));
            CalcularTroco(totalRecebido);

            AlterarItemSimpleButton.Enabled = false;
        }

        private void clientetextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LocalizarCliente();
            }
        }
        private void LocalizarCliente()
        {
            try
            {
                if (clientetextEdit.Text != string.Empty)
                {

                    try
                    {
                        CodCliente = clientetextEdit.Text.Trim();
                    }
                    catch (FormatException)
                    {

                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("O número inserido é muito longo");
                        return;
                    }
                    Cliente = FuncoesCliente.GetClienteIdCpfCnpj(CodCliente);
                    if (Cliente != null)
                    {
                        clientetextEdit.Text = Cliente._DESCRICAO;
                        Vendedor = FuncoesUsuario.GetUsuario(Cliente.IDVendedor);
                        vendedortextEdit.Text = Vendedor != null ? Vendedor.Nome : "";
                    }
                    else
                    {
                        MessageBox.Show("Cliente não foi localizado");
                        CodCliente = clientetextEdit.Text = "";
                    }

                }
            }
            catch (Exception)
            {


            }


        }
        private void clientetextEdit_Click(object sender, EventArgs e)
        {
            labelSelecioneCliente.Visible = false;
            labelSelecioneVendedor.Visible = false;
        }
        private void vendedortextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LocalizarVendedor();
            }
        }
        private void LocalizarVendedor()
        {
            try
            {
                CodVendedor = ToDecimal(vendedortextEdit.Text.Trim()).ToString();

                PerfilAcesso perfil = FuncoesPerfilAcesso.GetPerfil(Contexto.USUARIOLOGADO.IDPerfilAcesso);
                if (perfil.IsAdmin == 0)
                {
                    string mensagem = "Você não tem acesso a este campo. Insira os dados de um usuário admnistrador para continuar.";
                    if (MessageBox.Show(this, mensagem, "Pedido de Venda", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        loginAdminDAV.ShowDialog();
                }
                if (loginAdminDAV.isLogado || perfil.IsAdmin == 1)
                {
                    var vendedor = FuncoesUsuario.GetUsuario(ToDecimal(CodVendedor));
                    if (vendedor != null)
                    {
                        if (vendedor.IsVendedor == 0)
                        {
                            vendedor = null;
                        }
                    }

                    if (vendedor != null)
                    {
                        Vendedor = vendedor;
                        vendedortextEdit.Text = Vendedor.Nome;
                    }
                    else
                    {
                        MessageBox.Show("Vendedor não foi localizado");
                        CodVendedor = vendedortextEdit.Text = "";
                    }
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
            loginAdminDAV.isLogado = false;
        }

        private void FormaDePagamento_EditValueChanged(object sender, EventArgs e)
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
            Venda.DataCadastro = dateTimePicker1.Value;
        }

        private void EditarValidade()
        {
            var identSelecionado = Grids.GetValorInt(gridView2, "Identificador");
            var pagamento = LstFormaDePagamentoAux.Single(l => l.Identificador == identSelecionado);
            var dataVencimentoDav = new DataVencimentoDAV(pagamento.Vencimento);
            dataVencimentoDav.ShowDialog();

            pagamento.Vencimento = dataVencimentoDav.DataDeVencimento;

            gridControl2.DataSource = LstFormaDePagamentoAux;
            gridControl2.Focus();
        }


        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            EditarValidade();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            RemoverTodosPagtos();
        }

        private void RemoverTodosPagtos()
        {
            if (Confirm("Deseja remover todos os pagamentos inseridos?") == DialogResult.Yes)
            {
                decimal valorPagamento = 0;
                LstFormaDePagamentoAux.Clear();
                gridControl2.DataSource = LstFormaDePagamentoAux;
                AtualizarQuantidadeItensESubTotalVenda();
                totalPagtosText.EditValue = Math.Round(valorPagamento, 2).ToString();
                CalcularTroco(valorPagamento);
            }
        }

        public DialogResult Confirm(string msg)
        {
            return MessageBox.Show(msg, nomeTela, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void CalcularPorcentagemDesconto()
        {
            try
            {
                var valorDesconto = (decimal)spinDescontoValor.EditValue;
                var preco = (decimal)spinPreco.EditValue;
                var porcentagemDesconto = (valorDesconto * 100) / preco;
                txtDescontoPorcent.EditValue = porcentagemDesconto >= 0 ? Math.Round(porcentagemDesconto, 2) : 0;
            }
            catch (DivideByZeroException)
            {
                txtDescontoPorcent.EditValue = 0;
            }
        }

        private void CalcularValorDesconto()
        {
            try
            {
                var porcentagemDesconto = (decimal)txtDescontoPorcent.EditValue;
                var preco = (decimal)spinPreco.EditValue;
                var valorDesconto = (porcentagemDesconto / 100) * preco;
                spinDescontoValor.EditValue = valorDesconto >= 0 ? Math.Round(valorDesconto, 2) : 0;
            }
            catch (DivideByZeroException)
            {
                spinDescontoValor.EditValue = 0;
            }
        }

        public void Alert(string msg)
        {
            MessageBox.Show(msg, nomeTela, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void descontoPercentualTextEdit_KeyUp(object sender, KeyEventArgs e)
        {
            // Não permitir valores negativos
            if (txtDescontoPorcent.Text.Contains('-'))
                txtDescontoPorcent.Text = txtDescontoPorcent.Text.Replace("-", "");


            CalcularValorDesconto();
            CalcularTotalItem();
        }

        private void txtDescontoValor_KeyUp(object sender, KeyEventArgs e)
        {
            // Não permitir valores negativos
            if (spinDescontoValor.Text.Contains('-'))
                spinDescontoValor.Text = spinDescontoValor.Text.Replace("-", "");


            CalcularPorcentagemDesconto();
            CalcularTotalItem();
        }

        private void txtDescontoValor_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            // Não permitir valores negativo
            try
            {
                var val = ToDouble(spinDescontoValor.Text.Replace("R$", "").Replace(" ", ""));
                if (val < 0.1 && !e.IsSpinUp)
                    spinDescontoValor.Text = "0";
            }
            catch (Exception exception)
            {
                Alert(exception.Message);
            }
        }

        private void txtDescontoPorcent_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            // Não permitir valores negativos
            try
            {
                var val = ToDouble(txtDescontoPorcent.Text.Replace("%", "").Replace(" ", ""));
                if (val < 0.1 && !e.IsSpinUp)
                    txtDescontoPorcent.EditValue = 0;
            }
            catch (Exception exception)
            {
                Alert(exception.Message);
            }
        }

        private void KeyDownIncluir(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                incluirSimpleButton_Click(sender, e);
        }

        private void txtDescontoValor_EditValueChanged(object sender, EventArgs e)
        {
            CalcularPorcentagemDesconto();
            CalcularTotalItem();
        }

        private void txtDescontoPorcent_EditValueChanged(object sender, EventArgs e)
        {
            CalcularValorDesconto();
            CalcularTotalItem();
        }

        private void CalcularArea(object sender, KeyEventArgs e)
        {
            CalcularArea();
        }

        private void CalcularArea()
        {
            try
            {
                var largura = ToDecimal(spinLargura.Text.Replace("R$", "").Replace(" ", ""));
                var altura = ToDecimal(spinAltura.Text.Replace("R$", "").Replace(" ", ""));
                spinArea.EditValue = Math.Round(altura * largura, 2);
            }
            catch (FormatException exception)
            {
                Alert("Erro na conversão de valores, ao calcular a área. " + exception.Message);
            }
            
        }

        private void spinArea_EditValueChanged(object sender, EventArgs e)
        {
            CalcularTotalItem();
        }

        private void txtQntd_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularTotalItem();
        }

        private void CalcularArea(object sender, EventArgs e)
        {
            CalcularArea();
        }

        private void txtQntd_EditValueChanged(object sender, EventArgs e)
        {
            CalcularTotalItem();
        }
    }
}
