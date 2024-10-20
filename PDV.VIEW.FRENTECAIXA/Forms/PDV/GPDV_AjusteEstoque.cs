using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.UTIL;
using System.Configuration;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Entidades.Estoque.Movimento;
using PDV.DAO.DB.Utils;

namespace PDV.VIEW.FRENTECAIXA.Forms.PDV
{
    public partial class tbQtde : DevExpress.XtraEditors.XtraForm
    {
        public List<ItemVenda> ITENS_VENDA = null;
        private GPDV_PainelInicial TELAPDV = null;
        public tbQtde()
        {
            InitializeComponent();
            ITENS_VENDA = new List<ItemVenda>();
        }

        public void ConsultaProduto(string descricao, GPDV_PainelInicial TelaPDV)
        {
            TELAPDV = TelaPDV;
            ovTXT_CodigoBarrasProduto.Text = descricao;
            AtualizaProdutos(descricao);
        }
        public bool contemLetras(string texto)
        {
            if (texto.Where(c => char.IsLetter(c)).Count() > 0)
                return true;
            else
                return false;
        }

        public bool contemNumeros(string texto)
        {
            if (texto.Where(c => char.IsNumber(c)).Count() > 0)
                return true;
            else
                return false;
        }

        private void AtualizaProdutos(string Descricao)
        {
            DataTable tabela = new DataTable();
            if (contemLetras(ovTXT_CodigoBarrasProduto.Text))
                tabela = FuncoesProduto.GetProdutosPorDescricao(Descricao, false, true);
            else
                tabela = FuncoesProduto.GetProdutoEAN(Descricao);
            ovGRD_Produtos.DataSource = tabela;
            AjustaHeaderTextGrid();


            if (tabela.Rows.Count >0)
            {
                DataRow dRow = tabela.Rows[0];
                ovTXT_DescricaoProduto.Text = dRow["DESCRICAO"].ToString();
                ovTXT_Marca.Text = dRow["MARCA"].ToString();
                ovTXT_UnidadeMedida.Text = dRow["UNIDADEDEMEDIDA"].ToString();
                ovTXT_CodigoBarras.Text = dRow["CODIGODEBARRAS"].ToString();
                ovTXT_ValorUnitario.Text = dRow["PRECOVENDA"].ToString();
                ovTXT_Estoque.Text = dRow["SALDOESTOQUE"].ToString();


                ovGRD_Produtos.Rows[0].Selected = true;

                ITENS_VENDA.Add(new ItemVenda()
                {
                    CodigoItem = dRow["CODIGO"].ToString(),
                    IDItemVenda = 1,
                    DescricaoItem = dRow["DESCRICAO"].ToString(),
                    IDProduto = Convert.ToDecimal(dRow["IDPRODUTO"]),
                    Quantidade = Decimal.Parse(tbQuantidade.Text)
                });

                ovGRD_Produtos.DataSource = ITENS_VENDA;
                ovTXT_CodigoBarrasProduto.Text = "";
                tbQuantidade.Text = "1";
                ovTXT_CodigoBarrasProduto.Focus();
            }

        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Produtos.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Produtos.Width;

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font("Open Sans", 9, FontStyle.Regular);
            style.Alignment = DataGridViewContentAlignment.TopLeft;
            style.WrapMode = DataGridViewTriState.True;

            foreach (DataGridViewColumn column in ovGRD_Produtos.Columns)
            {
                switch (column.Name)
                {
                    case "codigodebarras":
                        column.DisplayIndex = 6;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.25);
                        column.Width = Convert.ToInt32(WidthGrid * 0.25);
                        column.HeaderText = "CÓDIGO DE BARRAS";
                        break;
                    case "descricao":
                        column.DisplayIndex = 7;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.35);
                        column.Width = Convert.ToInt32(WidthGrid * 0.35);
                        column.HeaderText = "NOME";
                        break;
                    case "unidadedemedida":
                        column.DisplayIndex = 8;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.35);
                        column.Width = Convert.ToInt32(WidthGrid * 0.35);
                        column.HeaderText = "UNIDADE";
                        break;
                    case "marca":
                        column.DisplayIndex = 9;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.20);
                        column.Width = Convert.ToInt32(WidthGrid * 0.20);
                        column.HeaderText = "MARCA";
                        break;
                    case "precovenda":
                        column.DisplayIndex = 5;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.20);
                        column.Width = Convert.ToInt32(WidthGrid * 0.20);
                        column.HeaderText = "PREÇO";

                        break;
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }
           
        }
        private void ovTXT_CodigoBarrasProduto_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    AtualizaProdutos(ovTXT_CodigoBarrasProduto.Text);

                    //DataRow drProduto = FuncoesProduto.GetProdutoPorCodigoPDV(ovTXT_CodigoBarrasProduto.Text.Trim());
                    //if (drProduto != null)
                    //{
                    //    if (!FuncoesProduto.ExisteTributoVigenteProduto(Convert.ToDecimal(drProduto["IDPRODUTO"])))
                    //    {
                    //        ovTXT_StatusConsulta.Text = string.Format("* O produto \"{0}\" não possui tributação vigênte. Verifique o cadastro do IBPT e tente novamente.", drProduto["PRODUTO"].ToString());
                    //        return;
                    //    }

                    //    ovTXT_DescricaoProduto.Text = drProduto["PRODUTO"].ToString();
                    //    ovTXT_Marca.Text = string.IsNullOrEmpty(drProduto["MARCA"].ToString()) ? "<Não Informado>" : drProduto["MARCA"].ToString();
                    //    ovTXT_ValorUnitario.Text = Convert.ToDecimal(drProduto["PRECOVENDA"]).ToString("n2");
                    //    ovTXT_UnidadeMedida.Text = drProduto["UNIDADEDEMEDIDA"].ToString();
                    //    ovTXT_StatusConsulta.Text = string.Empty;
                    //}
                    //else
                    //{
                    //    ovTXT_DescricaoProduto.Text = string.Empty;
                    //    ovTXT_Marca.Text = string.Empty;
                    //    ovTXT_ValorUnitario.Text = string.Empty;
                    //    ovTXT_UnidadeMedida.Text = string.Empty;

                    //    ovTXT_StatusConsulta.Text = "* Produto não encontrado. Verifique e tente novamente!";
                    //}
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private void ovGRD_Produtos_CurrentCellChanged(object sender, EventArgs e)
        {
        }

        private void ovGRD_Produtos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            ovTXT_DescricaoProduto.Text = ZeusUtil.GetValueFieldDataRowView((ovGRD_Produtos.CurrentRow.DataBoundItem as System.Data.DataRowView), "DESCRICAO").ToString();
            ovTXT_Marca.Text = ZeusUtil.GetValueFieldDataRowView((ovGRD_Produtos.CurrentRow.DataBoundItem as System.Data.DataRowView), "MARCA").ToString();
            ovTXT_UnidadeMedida.Text = ZeusUtil.GetValueFieldDataRowView((ovGRD_Produtos.CurrentRow.DataBoundItem as System.Data.DataRowView), "UNIDADEDEMEDIDA").ToString();
            ovTXT_CodigoBarras.Text = ZeusUtil.GetValueFieldDataRowView((ovGRD_Produtos.CurrentRow.DataBoundItem as System.Data.DataRowView), "CODIGODEBARRAS").ToString();
            ovTXT_ValorUnitario.Text = ZeusUtil.GetValueFieldDataRowView((ovGRD_Produtos.CurrentRow.DataBoundItem as System.Data.DataRowView), "PRECOVENDA").ToString();
            //  = ovGRD_Produtos.Rows[1].Cells[3].Value.ToString();// row.Cells[1].Value;
            //ovTXT_Peso.Focus();
        }

        private void ovGRD_Produtos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (ovGRD_Produtos.Columns[e.ColumnIndex].Name)
            {
                case "ValorUnitarioItem":
                case "ValorTotalItem":
                    e.Value = Convert.ToDecimal(e.Value).ToString("n2");
                    break;
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F10:
                    metroButton1_Click(metroButton1, null);
                    break;
                case Keys.F2:
                    tbQuantidade.Focus();
                    break;
                case Keys.F3:
                    ovTXT_CodigoBarrasProduto.Focus();
                    break;

            }
            return base.ProcessDialogKey(keyData);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            foreach (ItemVenda Item in ITENS_VENDA)
            {

                // [Processar Movimento de Estoque]
                if (!FuncoesMovimentoEstoque.Salvar(new MovimentoEstoque
                {
                    IDMovimentoEstoque = Sequence.GetNextID("MOVIMENTOESTOQUE", "IDMOVIMENTOESTOQUE"),
                    DataMovimento = DateTime.Now,
                    IDAlmoxarifado = FuncoesProduto.GetProduto(Item.IDProduto).IDAlmoxarifadoSaida,
                    IDItemVenda = null,
                    IDProduto = Item.IDProduto,
                    Quantidade = Item.Quantidade,
                    Tipo = 0,
                    IDItemInventario = null,
                    IDItemNFeEntrada = null,
                    IDItemTransferenciaEstoque = null,
                    IDProdutoNFe = null
                }))
                    throw new Exception("Não foi possível salvar o Movimento de Estoque.");
            }
            ovTXT_StatusConsulta.Visible = false;
            ovTXT_StatusConsulta.Text = "";
            Close();
        }
    }
}
