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
    public partial class DACPesquisarFornecedores : DevExpress.XtraEditors.XtraForm
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public DACPesquisarFornecedores()
        {
            InitializeComponent();
            gridControl1.DataSource = FuncoesFornecedor.GetFornecedores("","");
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            //Formatação
            gridView1.Columns[0].Caption = "ID DO FORNECEDOR";
            gridView1.Columns[1].Caption = "CNPJ";
            gridView1.Columns[2].Caption = "RAZÃO SOCIAL";
            gridView1.BestFitColumns();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Codigo = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDFORNECEDOR").ToString());
                Nome = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "RAZAOSOCIAL").ToString());
            }
            catch (NullReferenceException)
            {
            }
            
           Close();
           
        }
    }
}
