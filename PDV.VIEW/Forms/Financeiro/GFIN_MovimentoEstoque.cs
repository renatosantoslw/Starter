using PDV.CONTROLER.Funcoes;
using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using DevExpress.XtraPrinting;
using PDV.VIEW.Forms.Util;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class GFIN_MovimentoEstoque : DevExpress.XtraEditors.XtraForm
    {
        private DataTable DataTable { get; set; } = FuncoesMovimentoEstoque.GetMovimentosEstoque();
        private string PesquisaProduto {get;set;}
        public GFIN_MovimentoEstoque()
        {
            InitializeComponent();
            dateEdit1.DateTime = DateTime.Today;
            dateEdit2.DateTime = dateEdit1.DateTime.AddDays(1);
            //Carregar();
        }

        public void Carregar()
        {
            
            //CarregarGrafico();
            gridControl1.DataSource = DataTable;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            if (gridView1.RowCount > 0)
            {
                gridView1.Columns[0].Caption = "PRODUTO";
                gridView1.Columns[1].Caption = "DATA";
                gridView1.Columns[2].Caption = "CÓD";
                gridView1.Columns[3].Caption = "DESCRIÇÃO";
                gridView1.Columns[4].Caption = "DOC";
                gridView1.Columns[5].Caption = "GRUPO";
                gridView1.Columns[6].Caption = "TIPO";
                gridView1.Columns[7].Caption = "QUANTIDADE";
                gridView1.BestFitColumns();
            }
            Grids.FormatColumnType(ref gridView1, "produto", GridFormats.Count);
            Grids.FormatColumnType(ref gridView1, "quantidade", GridFormats.Sum);           
        }

        private void FCA_Transportadora_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

       

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView currentView = sender as GridView;
            if (e.Column.FieldName == "tipo")
            {
                string valor;
                try
                {
                    var cellValue = gridView1.GetRowCellValue(e.RowHandle, "tipo");
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
                    case "SAÍDA":
                        e.Appearance.ForeColor = System.Drawing.Color.Green;
                        break;
                    case "ENTRADA":
                        e.Appearance.ForeColor = System.Drawing.Color.Red;
                        break;
                }

            }
        }
      
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void gridView1_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.Landscape = true;
            pb.PageSettings.LeftMargin = pb.PageSettings.TopMargin = pb.PageSettings.BottomMargin = pb.PageSettings.RightMargin = 5;
        }
        private void Pesquisar()
        {
            try
            {            
                try
                {
                    DataTable = FuncoesMovimentoEstoque.GetMovimentosEstoque(PesquisaProduto, dateEdit1.DateTime, dateEdit2.DateTime, Convert.ToDecimal(PesquisaProduto));
                }
                catch (FormatException)
                {
                    DataTable = FuncoesMovimentoEstoque.GetMovimentosEstoque(PesquisaProduto, dateEdit1.DateTime, dateEdit2.DateTime);
                }            
                Carregar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Movimento Estoque", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void simpleButtonPesquisar_Click(object sender, EventArgs e)
        {
            PesquisaProduto = textBoxProduto.Text;
            Pesquisar();
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
    }
}