using DevExpress.XtraEditors;
using MetroFramework;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.PDV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Sequence = PDV.DAO.DB.Utils.Sequence;

namespace PDV.VIEW.FRENTECAIXA.Forms.PDV
{
    public partial class DAVPedido : Form
    {
        public Venda Venda = null;

        public string CodProduto { get; set; }

        public List<ItemVenda> lstItemDeVenda = null;
        public List<DuplicataNFCe> lstPagamentos = null;
        public decimal IDItemFormaPagamento { get; set; }
        public List<FormaPagamentoAux> lstformaPagamentoAux;
        private DataRow drProduto = null;

        public CONTROLER.Funcoes.FuncoesComanda Comanda = null;
        public Cliente Cliente = null;
        public bool Alteracao = false;
        public decimal IDItemVenda { get; set; }
        public DAVPedido(int IDVENDA)
        {
            InitializeComponent();

            lstformaPagamentoAux = new List<FormaPagamentoAux>();
            carregarComboboxFormaPagamento();


            if (IDVENDA == 0)
            {
                IniciarVenda();

            }
            else
            {
                Alteracao = true;
                Venda = FuncoesVenda.GetVenda(Convert.ToDecimal(IDVENDA));

                lstItemDeVenda = FuncoesItemVenda.GetItensVenda(IDVENDA);
                if (Venda.IDCliente != null)
                {
                    Cliente = FuncoesCliente.GetCliente(Convert.ToDecimal(Venda.IDCliente));
                    clientetextEdit.Text = Cliente.Nome;
                    observacaoRichTextBox.Text = Venda.Observacao;
                }
                AtualizarQuantidadeItensESubTotalVenda();
                gridLookUpEditFormaPagamento.EditValue = Venda.IDFormaPagamento;
                carregarFormaDePagamento(Venda.IDFormaPagamento);
            }
            quantidadeTextEdit.Text = "1";
        }

        private void carregarComboboxFormaPagamento()
        {
            var formaPagamento = FuncoesFormaDePagamento.GetFormasPagamento().Select(s => new { Cod = s.IDFormaDePagamento, Nome = s.Identificacao }).OrderBy(x => x.Cod).ToList();
            gridLookUpEditFormaPagamento.Properties.DataSource = formaPagamento;
        }

        private void AtualizarQuantidadeItensESubTotalVenda()
        {
            if (lstItemDeVenda.Count == 0)
            {
                quantidadeTextEdit.Text = "0";
                totalTextEdit.Text = "0,00";
            }
            else
            {
                decimal ValorTotalVenda = 0;
                decimal QuantidadeItens = 0;

                foreach (ItemVenda Item in lstItemDeVenda)
                {
                    ValorTotalVenda += Item.ValorTotalItem;
                    QuantidadeItens += Item.Quantidade;
                }
                valorTotalVendatextEdit.Text = ValorTotalVenda.ToString("n2");
                Venda.ValorTotal = ValorTotalVenda;
                Venda.QuantidadeDeItens = QuantidadeItens;
            }
            atualizarLista();
        }

        private void buscarProdutosimpleButton_Click(object sender, EventArgs e)
        {
            PDV.DAV.DAVPesquisarProduto frm = new PDV.DAV.DAVPesquisarProduto();
            frm.ShowDialog();
            CodProduto = !string.IsNullOrEmpty(frm.Codigo) ? frm.Codigo.ToString() : "";
            produtotextEdit.Text = !string.IsNullOrEmpty(frm.Nome) ? frm.Nome.ToString() : "";

            LocalizarPorduto();
            calcularTotal();
        }
        private void produtotextEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LocalizarPorduto();
            }
        }

        private void LocalizarPorduto()
        {
            if (produtotextEdit.Text != string.Empty)
            {
                drProduto = FuncoesProduto.GetProdutoPorCodigoPDV(CodProduto.Trim());
                if (drProduto != null)
                {
                    //Setando campos
                    quantidadeTextEdit.Focus();
                    descontoValorTextEdit.Text = "0";
                    descricaoProdutoLabelControl1.Text = drProduto["PRODUTO"].ToString().TrimEnd();
                    precoTextEdit.Text = Convert.ToDecimal(drProduto["PRECOVENDA"]).ToString("n2");
                }
                else
                {
                    XtraMessageBox.Show("Produto não foi localizado");
                }

            }
        }

        private void quantidadeTextEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (quantidadeTextEdit.Text != string.Empty)
                {
                    calcularTotal();
                    incluirSimpleButton_Click(sender, e);
                }
            }

        }

        private void calcularTotal()
        {
            try
            {
                decimal quantidade = 0;
                decimal valor = 0;
                decimal desconto = 0;
                quantidade = decimal.Parse(quantidadeTextEdit.Text);
                valor = decimal.Parse(precoTextEdit.Text);
                desconto = decimal.Parse(descontoValorTextEdit.Text);
                decimal total = quantidade * valor;
                totalTextEdit.Text = total.ToString("n2");
            }
            catch (Exception)
            {
                //throw;
            }

        }
        public void IniciarVenda()
        {
            lstItemDeVenda = new List<ItemVenda>();
            Venda = new Venda()
            {
                IDVenda = Sequence.GetNextID("VENDA", "IDVENDA"),
                IDUsuario = 1,
                DataCadastro = DateTime.Now,
                Status = 0,
                IDFluxoCaixa = 0//!string.IsNullOrEmpty(FLUXO.IDFluxoCaixa) ? FLUXO.IDFluxoCaixa : 0,
            };

        }
        private void incluirSimpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                validacao();
                decimal Quantidade = decimal.Parse(quantidadeTextEdit.Text);
                decimal desconto = 0;

                if (!string.IsNullOrEmpty(descontoValorTextEdit.Text))
                {
                    desconto = decimal.Parse(descontoValorTextEdit.Text);
                }

                decimal item = lstItemDeVenda.Count();
                ItemVenda itemVenda = new ItemVenda()
                {
                    Item = item + 1,
                    CodigoItem = drProduto[2].ToString().TrimEnd(),
                    DescricaoItem = drProduto[3].ToString().TrimEnd(),
                    ValorUnitarioItem = Convert.ToDecimal(drProduto[8]),
                    ValorTotalItem = (Convert.ToDecimal(drProduto[8]) - desconto) * Quantidade,
                    IDProduto = Convert.ToDecimal(drProduto[0]),
                    IDItemVenda = Sequence.GetNextID("ITEMVENDA", "IDITEMVENDA"),
                    IDVenda = Venda.IDVenda,
                    Quantidade = Quantidade,
                    DescontoValor = desconto,
                    IDUsuario = 2
                };
                lstItemDeVenda.Add(itemVenda);
                decimal ValorTotalVenda = 0;
                decimal ValorTotalDesconto = 0;
                foreach (ItemVenda Item in lstItemDeVenda)
                {
                    ValorTotalVenda += Item.ValorTotalItem;
                    ValorTotalDesconto += Item.DescontoValor;
                }
                valorTotalVendatextEdit.Text = ValorTotalVenda.ToString("n2");
                totalDescontoTextEdit.Text = ValorTotalDesconto.ToString("n2");
                atualizarLista();
                if (!string.IsNullOrEmpty(gridLookUpEditFormaPagamento.Text))
                {
                    carregarFormaDePagamento(int.Parse(gridLookUpEditFormaPagamento.EditValue.ToString()));
                }
                limparDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void atualizarLista()
        {
            gridControl1.DataSource = lstItemDeVenda.ToList();
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Visible = false;
            gridView1.Columns[5].Visible = false;
            gridView1.Columns[6].Visible = false;
            gridView1.Columns[11].Visible = false;
            gridView1.Columns[12].Visible = false;
            gridView1.Columns[13].Visible = false;
            //gridView1.OptionsView.ColumnAutoWidth = false;
            //gridView1.OptionsView.BestFitMaxRowCount = -1;
            gridView1.BestFitColumns();
        }

        public void validacao()
        {
            if (produtotextEdit.Text == string.Empty) { throw new Exception("Informe o produto."); }
            if (quantidadeTextEdit.Text == string.Empty) { throw new Exception("Informe a quanidade."); }
            if (precoTextEdit.Text == string.Empty) { throw new Exception("Preço não informado."); }

        }
        public void limparDados()
        {
            produtotextEdit.Text = string.Empty;
            quantidadeTextEdit.Text = "1";
            descontoValorTextEdit.Text = string.Empty;
            precoTextEdit.Text = string.Empty;
            totalTextEdit.Text = string.Empty;
            descontoPercentualTextEdit.Text = "";
            produtotextEdit.Focus();
        }
        private void quantidadeTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            calcularTotal();
        }

        private void salvarSimpleButton_Click(object sender, EventArgs e)
        {
            if (MetroMessageBox.Show(this, "Deseja Salvar a DAV?", "DAV - Documento Auxilar de Venda", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    //PDVControlador.BeginTransaction();

                    Venda.ValorTotal = decimal.Parse(valorTotalVendatextEdit.Text);
                    Venda.IDCliente = null;
                    Venda.Status = 0;
                    Venda.IDFormaPagamento = int.Parse(gridLookUpEditFormaPagamento.EditValue.ToString());
                    Venda.Observacao = observacaoRichTextBox.Text;
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
                        Venda.IDUsuario = 2;
                    }
                    if (!FuncoesVenda.SalvarVenda(Venda))
                    {
                        throw new Exception("Não foi possível salvar a Venda.");
                    }
                    if (!FuncoesItemVenda.RemoverItensDaVenda(lstItemDeVenda, Venda.IDVenda))
                    {
                        throw new Exception("Não foi possível salvar a Venda.");
                    }

                    foreach (ItemVenda Item in lstItemDeVenda)
                    {
                        if (!FuncoesItemVenda.SalvarItemVenda(Item))
                        {
                            throw new Exception("Não foi possível salvar os Itens da Venda.");
                        }
                    }

                   // PDVControlador.Commit();
                    Close();
                }
                catch (Exception Ex)
                {
                  //  PDVControlador.Rollback();
                    MetroMessageBox.Show(this, Ex.Message, "DAV - Documento Auxiliar de Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AlterarSimpleButton_Click(object sender, EventArgs e)
        {
            //GPDV_IdentificarClienteDAV Identificar = new GPDV_IdentificarClienteDAV();
            //Identificar.ShowDialog(this);
            //if (Identificar.Identificar)
            //{
            //    if (Identificar.DRCliente != null)
            //    {
            //        Cliente = FuncoesCliente.GetCliente(Convert.ToDecimal(Identificar.DRCliente["IDCLIENTE"]));
            //    }
            //    else
            //    {
            //        Cliente = new Cliente
            //        {
            //            TipoDocumento = Convert.ToDecimal(Identificar.ovTXT_TipoPessoa.Text),
            //            Nome = Identificar.ovTXT_NomeCliente.Text,
            //            CPF = Convert.ToDecimal(Identificar.ovTXT_TipoPessoa.Text) == 1 ? ZeusUtil.SomenteNumeros(Identificar.ovTXT_CPFCNPJ.Text) : null,
            //            CNPJ = Convert.ToDecimal(Identificar.ovTXT_TipoPessoa.Text) == 0 ? ZeusUtil.SomenteNumeros(Identificar.ovTXT_CPFCNPJ.Text) : null,
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
                    descontoPercentualTextEdit.Focus();
                    break;
                case Keys.F9:
                    descontoValorTextEdit.Focus();
                    break;

                case Keys.F12:
                    fecharSimpleButton_Click(sender, e);
                    break;
            }
        }

        private void fecharSimpleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelarItemSimpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MetroMessageBox.Show(this, "Deseja Cancelar o Item Selecionado?", "DAV - Documento Auxiliar de Venda", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    lstItemDeVenda = lstItemDeVenda.Where(o => o.IDItemVenda != IDItemVenda).ToList();
                    AtualizarQuantidadeItensESubTotalVenda();
                    atualizarLista();
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "DAV - Documento Auxiliar de Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                IDItemVenda = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDItemVenda").ToString()));
            }
            catch (Exception)
            {

                //  throw;
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            atualizarLista();
        }
        private void descontoValorTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal totaldescontoPercentual = Math.Round(decimal.Parse(descontoValorTextEdit.Text.Replace(",", ".")) / decimal.Parse(precoTextEdit.Text), 2);
                descontoPercentualTextEdit.Text = (totaldescontoPercentual).ToString();
                decimal subtotal = (decimal.Parse(precoTextEdit.Text) - decimal.Parse(descontoValorTextEdit.Text)) * decimal.Parse(quantidadeTextEdit.Text);
                totalTextEdit.Text = subtotal.ToString();
                if (totaldescontoPercentual > 99)
                {
                    MessageBox.Show("Desconto não pode ser maior que 100%.");
                }

            }
            catch (Exception)
            {


            }
        }

        private void descontoPercentualTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal totaldescontoValor = Math.Round(decimal.Parse(descontoPercentualTextEdit.Text.Replace(",", ".")) * decimal.Parse(precoTextEdit.Text) / 100, 2);
                descontoValorTextEdit.Text = (totaldescontoValor).ToString();
                decimal subtotal = (decimal.Parse(precoTextEdit.Text) - decimal.Parse(descontoValorTextEdit.Text)) * decimal.Parse(quantidadeTextEdit.Text);
                totalTextEdit.Text = subtotal.ToString();
                if (totaldescontoValor > 99)
                {
                    MessageBox.Show("Desconto não pode ser maior que 100%.");
                }

            }
            catch (Exception)
            {


            }
        }

        private void precoTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void descontoPercentualTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (quantidadeTextEdit.Text != string.Empty)
                {
                    calcularTotal();
                    incluirSimpleButton_Click(sender, e);
                }
            }
        }

        private void descontoValorTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (quantidadeTextEdit.Text != string.Empty)
                {
                    calcularTotal();
                    incluirSimpleButton_Click(sender, e);
                }
            }
        }
        public class FormaPagamentoAux
        {
            public string Cod { get; set; }
            public string Nome { get; set; }
            public decimal Valor { get; set; }
            public DateTime Vencimento { get; set; }
        }
        private void AtualizarGird(List<FormaPagamentoAux> lstformaPagamentoAux)
        {
            gridControl2.DataSource = lstformaPagamentoAux.ToList();
            gridView1.BestFitColumns();
        }
        private void gridLookUpEditFormaPagamento_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEditFormaPagamento.EditValue == null)
            {
                MetroMessageBox.Show(this, "Infome a forma de pagamento", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            carregarFormaDePagamento(int.Parse(gridLookUpEditFormaPagamento.EditValue.ToString()));
        }

        private void carregarFormaDePagamento(int FormaPagamento)
        {
            lstformaPagamentoAux = null;
            gridControl2.DataSource = null;


            FormaDePagamento formaDePagamento = new FormaDePagamento();
            formaDePagamento = FuncoesFormaDePagamento.GetFormaDePagamento(decimal.Parse(FormaPagamento.ToString()));

            int FatorPeriodicidade = 0;


            if (string.IsNullOrEmpty(valorTotalVendatextEdit.Text))
            {
                MetroMessageBox.Show(this, "Infome o valor recebido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
            if (FormaPagamento == 0)
            {
                MetroMessageBox.Show(this, "Infome a forma de pagamento", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                MetroMessageBox.Show(this, "Forma de pagamento não está configurada. Verifique a quantidade de parcelas.", "DAV - Documento Auxiliar de Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < formaDePagamento.Qtd_Parcelas; i++)
            {
                FormaPagamentoAux formaPagamentoAux1 = new FormaPagamentoAux()
                {
                    Cod = gridLookUpEditFormaPagamento.EditValue.ToString(),
                    Nome = gridLookUpEditFormaPagamento.Text,
                    Valor = decimal.Parse(valorTotalVendatextEdit.Text.ToString()) / formaDePagamento.Qtd_Parcelas,
                    Vencimento = ultimoVencimento.AddDays(FatorPeriodicidade)
                };
                ultimoVencimento = formaPagamentoAux1.Vencimento;
                lstformaPagamentoAux.Add(formaPagamentoAux1);
            }
            AtualizarGird(lstformaPagamentoAux);
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (MetroMessageBox.Show(this, "Deseja Cancelar o Item Selecionado?", "DAV - Documento Auxiliar de Venda", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    lstformaPagamentoAux = lstformaPagamentoAux.Where(o => o.Cod != IDItemFormaPagamento.ToString()).ToList();
                    AtualizarQuantidadeItensESubTotalVenda();
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "DAV - Documento Auxiliar de Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pesquisarClienteSimpleButton_Click(object sender, EventArgs e)
        {
            PDV.DAV.DAVPesquisarClientes dAVPesquisarClientes = new PDV.DAV.DAVPesquisarClientes();
            dAVPesquisarClientes.ShowDialog();
            clientetextEdit.Text = dAVPesquisarClientes.Nome;
            Cliente = FuncoesCliente.GetCliente(Convert.ToDecimal(dAVPesquisarClientes.Codigo));
        }
    }
}
