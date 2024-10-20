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
    public partial class DAVPesquisarClientes : DevExpress.XtraEditors.XtraForm
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public DAVPesquisarClientes()
        {
            InitializeComponent();
            gridControl1.DataSource = FuncoesCliente.GetClientes("","","");
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            //Formatação
            gridView1.Columns[0].Caption = "IDCLIENTE";
            gridView1.Columns[1].Caption = "NOME";
            gridView1.Columns[2].Caption = "DOCUMENTO";
            gridView1.Columns[3].Caption = "IE";
            gridView1.Columns[4].Caption = "TIPO";
            gridView1.Columns[5].Caption = "ATIVO";
            gridView1.BestFitColumns();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Codigo = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "idcliente").ToString());
            Nome = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "descricao").ToString());
            this.Close();
           
        }
    }
}
