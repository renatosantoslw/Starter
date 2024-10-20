using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using PDV.DAO.Entidades.Estoque.NFeImportacao;
using PDV.DAO.Entidades;
using PDV.CONTROLER.Funcoes;
using FontAwesome.Sharp;

namespace PDV.VIEW.Forms.Estoque.ImportacaoNFeEntrada
{
    public partial class FEST_AltualizarPrecos : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "Atualizar Preços";

        public FEST_AltualizarPrecos()
        {
            InitializeComponent();

            //icones
            Bitmap bitmapSalvar = IconChar.Save.ToBitmap(Color.SteelBlue, 32);
            Bitmap bitmapCancelar = IconChar.WindowClose.ToBitmap(Color.Firebrick, 32);

            //simpleButton1.ImageOptions.Image = bitmapIncluirTodos;
            simpleButton2.ImageOptions.Image = bitmapCancelar;
            metroButton4.ImageOptions.Image = bitmapSalvar;
        }

        private void gridControl1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "CustoNovo")
            {
                ItemNFePrecos itemGrid = (ItemNFePrecos)grdAtualizarPrecos.GetRow(e.RowHandle);
                itemGrid.Markup = CalculaMarkup(itemGrid.ValorNovo, itemGrid.CustoNovo);
            }

            if (e.Column.FieldName == "Markup")
            {
                ItemNFePrecos itemGrid = (ItemNFePrecos)grdAtualizarPrecos.GetRow(e.RowHandle);
                itemGrid.ValorNovo = CalculaValorVenda(itemGrid.CustoNovo, itemGrid.Markup);
            }

            if (e.Column.FieldName == "ValorNovo")
            {
                ItemNFePrecos itemGrid = (ItemNFePrecos)grdAtualizarPrecos.GetRow(e.RowHandle);
                itemGrid.Markup = CalculaMarkup(itemGrid.ValorNovo, itemGrid.CustoNovo);
            }
        }

        public static decimal CalculaMarkup(decimal ValorVenda, decimal ValorCusto)
        {
            if (ValorVenda > 0 && ValorCusto > 0)
                return Math.Round(((ValorVenda - ValorCusto) / ValorCusto) * 100, 2);

            return 0;
        }

        public static decimal CalculaValorVenda(decimal ValorCusto, decimal Markup)
        {
            if (ValorCusto > 0 && Markup > 0)
                return Math.Round(ValorCusto + (ValorCusto * (Markup / 100)), 2);

            return 0;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try {
                if ((gridControl1.DataSource as List<ItemNFePrecos>).Exists(q => q.ValorNovo == 0))
                    throw new Exception("Existem produtos sem valor de venda informado.");

                if ((gridControl1.DataSource as List<ItemNFePrecos>).Exists(q => q.CustoNovo == 0))
                    throw new Exception("Existem produtos sem valor de custo informado.");

                Produto produto = new Produto();

                foreach (var item in gridControl1.DataSource as List<ItemNFePrecos>)
                {
                    produto = FuncoesProduto.GetProduto(item.IDProduto);

                    produto.ValorCusto = item.CustoNovo;
                    produto.ValorVenda = item.ValorNovo;

                    FuncoesProduto.SalvarProduto(produto, DAO.Enum.TipoOperacao.UPDATE);
                }

                MessageBox.Show(this, "Preços salvos com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

        private void ovTXT_Fator_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void btnAdicionarConversao_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdAtualizarPrecos.GetSelectedRows().Count() <= 0)
                    throw new Exception("Selecione pelo menos um produto para realizar a alteração.");

                foreach (var row in grdAtualizarPrecos.GetSelectedRows())
                {
                    grdAtualizarPrecos.SetRowCellValue(row, "Markup", ovTXT_Margem.Value);
                }

                grdAtualizarPrecos.ClearSelection();

                MessageBox.Show(this, "Preços atualizados com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

        public static List<ItemNFePrecos> PreencherGridPrecos(List<ItemNFeEntrada> Itens)
        {
            List<ItemNFePrecos> lista = new List<ItemNFePrecos>();
            ItemNFePrecos itemPrecos = new ItemNFePrecos();
            Produto produto = new Produto();

            foreach (ItemNFeEntrada item in Itens)
            {
                itemPrecos = new ItemNFePrecos();
                produto = FuncoesProduto.GetProduto(item.IDProduto);

                itemPrecos.IDProduto = item.IDProduto;
                itemPrecos.DescricaoProduto = produto.Descricao;
                itemPrecos.Estoque = produto.SaldoEstoque;
                itemPrecos.CustoAnterior = produto.ValorCusto;
                itemPrecos.CustoNovo = item.Valor;
                itemPrecos.ValorAnterior = produto.ValorVenda;
                itemPrecos.ValorNovo = produto.ValorVenda;
                itemPrecos.Markup = CalculaMarkup(itemPrecos.ValorAnterior, itemPrecos.CustoNovo);

                lista.Add(itemPrecos);
            }

            return lista;
        }
    }
}