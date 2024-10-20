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
    public partial class DACPesquisarCompradores : DevExpress.XtraEditors.XtraForm
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public DACPesquisarCompradores()
        {
            InitializeComponent();
            gridControl1.DataSource = FuncoesUsuario.GetUsuariosCompradores();
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            //Formatação
            gridView1.Columns[0].Caption = "ID CLIENTE";
            gridView1.Columns[1].Caption = "NOME";
            for (int i = 2; i < gridView1.Columns.Count(); i++)
            {
                gridView1.Columns[i].Visible = false;
            }
            gridView1.BestFitColumns();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Codigo = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0].FieldName).ToString());
                Nome = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1].FieldName).ToString());
            }
            catch (NullReferenceException)
            {

            }
            Close();
           
        }
    }
}
