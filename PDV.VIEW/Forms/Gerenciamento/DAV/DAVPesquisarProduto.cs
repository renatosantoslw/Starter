using PDV.CONTROLER.Funcoes;
using PDV.VIEW.Forms.Gerenciamento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms.PDV.DAV
{
    public partial class DAVPesquisarProduto : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dataTable = null;
        private List<ItemProdutoSelecionado> ProdutosSelecionados { get; set; }
        public DAVPesquisarProduto()
        {
            InitializeComponent();
            dataTable = FuncoesProduto.GetProdutosDAV();
            DataColumn dataColumn = new DataColumn("QUANTIDADE", typeof(int));
            dataTable.Columns.Add(dataColumn);
            gridControl1.DataSource = dataTable;
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[8].Visible = true;
            gridView1.Columns[6].Visible = false;
            gridView1.Columns[9].Visible = false;
            //Formatação
            gridView1.Columns[1].Caption = "CÓDIGO";
            gridView1.Columns[2].Caption = "C.BARRAS";
            gridView1.Columns[3].Caption = "PRODUTO";
            gridView1.Columns[4].Caption = "MARCA";
            gridView1.Columns[5].Caption = "UN";
            gridView1.Columns[7].Caption = "PREÇO";
            gridView1.Columns[8].Caption = "ESTOQUE";
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].OptionsColumn.AllowEdit = i == gridView1.Columns.Count - 1;
            }
            //gridView1.OptionsView.ColumnAutoWidth = false;
            //gridView1.OptionsView.BestFitMaxRowCount = -1;
            gridView1.BestFitColumns();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

            ZerarFiltros();
            ProdutosSelecionados = new List<ItemProdutoSelecionado>();
            try
            {
                int quantidade = 0;
                try
                {
                    quantidade = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "QUANTIDADE"));
                }
                catch (InvalidCastException)
                {
                }
                ProdutosSelecionados.Add(new ItemProdutoSelecionado()
                {
                    IDProduto = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODIGO")),
                    Nome = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DESCRICAO").ToString(),
                    Quantidade = quantidade
                });
            }
            catch (NullReferenceException)
            {
            }
            Close();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ZerarFiltros();

            ProdutosSelecionados = new List<ItemProdutoSelecionado>();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                try
                {
                    if (Convert.ToInt32(gridView1.GetRowCellValue(i, "QUANTIDADE")) > 0)
                    {
                        int id = Convert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns[1].FieldName));
                        string nome = gridView1.GetRowCellValue(i, gridView1.Columns[3].FieldName).ToString();
                        int quantidade = Convert.ToInt32(gridView1.GetRowCellValue(i, "QUANTIDADE"));
                        ProdutosSelecionados.Add(new ItemProdutoSelecionado()
                        {
                            IDProduto = id,
                            Nome = nome,
                            Quantidade = quantidade
                        });
                    }
                }
                catch (InvalidCastException)
                {
                }

            }
            Close();
        }
        public List<ItemProdutoSelecionado> GetProdutosSelecionados()
        {
            return ProdutosSelecionados;
        }
        public void ZerarFiltros()
        {
            for (int i = 0; i < gridView1.Columns.Count; i++)
                gridView1.Columns[i].FilterInfo = DevExpress.XtraGrid.Columns.ColumnFilterInfo.Empty;
        }

        private void DAVPesquisarProduto_KeyDown(object sender, KeyEventArgs e)
        {            
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    simpleButton1.Focus();
                    simpleButton1_Click(sender, e);
                    break;
            }
        }
    }
}
