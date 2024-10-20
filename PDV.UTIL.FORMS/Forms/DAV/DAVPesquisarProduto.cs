using PDV.CONTROLER.Funcoes;
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
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public DAVPesquisarProduto()
        {
            InitializeComponent();
            gridControl1.DataSource = FuncoesProduto.GetProdutosDAV();
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[8].Visible = false;
            gridView1.Columns[6].Visible = false;
            gridView1.Columns[9].Visible = false;
            //Formatação
            gridView1.Columns[1].Caption = "CÓDIGO";
            gridView1.Columns[2].Caption = "C.BARRAS";
            gridView1.Columns[3].Caption = "PRODUTO";
            gridView1.Columns[4].Caption = "MARCA";
            gridView1.Columns[5].Caption = "UN";
            gridView1.Columns[7].Caption = "PREÇO";
            //gridView1.OptionsView.ColumnAutoWidth = false;
            //gridView1.OptionsView.BestFitMaxRowCount = -1;
            gridView1.BestFitColumns();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Codigo = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "codigo").ToString());
            Nome = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "descricao").ToString());
            this.Close();
           
        }
    }
}
