using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.UTIL.Components.UControl
{
    public partial class UC_ProdutoPedidoCompra : UserControl
    {
        public DataRow CurrentRow = null;
        public UC_ProdutoPedidoCompra(DataRow _CurrentRow)
        {
            InitializeComponent();
            CurrentRow = _CurrentRow;

            ovTXT_Desconto.AplicaAlteracoes();
            ovTXT_Quantidade.AplicaAlteracoes();
            ovTXT_PrecoCusto.AplicaAlteracoes();

            Preencher();
        }

        private void Preencher()
        {
            ovTXT_Produto.Text = CurrentRow["PRODUTO"].ToString();
            ovTXT_Codigo.Text = CurrentRow["CODIGO"].ToString();
            ovTXT_Ean.Text = CurrentRow["EAN"].ToString();
            ovTXT_UnidadeDeMedida.Text = CurrentRow["UNIDADEMEDIDA"].ToString();
            ovTXT_Categoria.Text = CurrentRow["CATEGORIA"].ToString();
            ovTXT_Marca.Text = CurrentRow["MARCA"].ToString();
            ovTXT_PrecoCusto.Value = Convert.ToDecimal(CurrentRow["VALORUNITARIO"]);
            ovTXT_Quantidade.Value = Convert.ToDecimal(CurrentRow["QUANTIDADE"]);
            ovTXT_Desconto.Value = Convert.ToDecimal(CurrentRow["DESCONTO"]);
            ovTXT_Total.Text = Convert.ToDecimal(CurrentRow["TOTAL"]).ToString("c2");
        }

        private void ovTXT_Quantidade_ValueChanged(object sender, EventArgs e)
        {
            AtualizaTotal();
        }

        private void ovTXT_Desconto_ValueChanged(object sender, EventArgs e)
        {
            AtualizaTotal();
        }

        private void AtualizaTotal()
        {
            decimal Total = (ovTXT_PrecoCusto.Value * ovTXT_Quantidade.Value) - ovTXT_Desconto.Value;
            CurrentRow["QUANTIDADE"] = ovTXT_Quantidade.Value;
            CurrentRow["DESCONTO"] = ovTXT_Desconto.Value;
            CurrentRow["TOTAL"] = Total;
            CurrentRow["VALORUNITARIO"] = ovTXT_PrecoCusto.Value;

            ovTXT_Total.Text = Total.ToString("c2");
        }

        private void ovTXT_PrecoCusto_ValueChanged(object sender, EventArgs e)
        {
            AtualizaTotal();
        }

    }
}
