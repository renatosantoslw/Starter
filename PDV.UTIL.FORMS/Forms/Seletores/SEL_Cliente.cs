using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.UTIL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDV.UTIL.FORMS.Forms.Seletores
{
    public partial class 
        SEL_Cliente : DevExpress.XtraEditors.XtraForm
    {
        public DataRow DRCliente = null;
        private DataTable CLIENTES = null;

        public SEL_Cliente()
        {
            InitializeComponent();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GVEN_SeletorClientes_Load(object sender, EventArgs e)
        {
            AtualizaClientes("");
        }

        private void AtualizaClientes(string Nome_RazaoSocial)
        {
            CLIENTES = FuncoesCliente.GetClientesNFe(Nome_RazaoSocial);
            gridControl1.DataSource = CLIENTES;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaTextHeader();
        }

        private void AjustaTextHeader()
        {
            
            gridView1.Columns[0].Caption = "NOME/FANTASIA";
            gridView1.Columns[1].Caption = "DOCUMENTO";
            for (int i = 2; i < 7; i++)
            {
                gridView1.Columns[i].Visible = false;
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                decimal IDCliente = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCLIENTE").ToString());
                DRCliente = CLIENTES.AsEnumerable().Where(o => Convert.ToDecimal(o["IDCLIENTE"]) == IDCliente).FirstOrDefault();
                Close();
            }
            catch
            {
                MessageBox.Show(this, "Selecione um Cliente.", "PESQUISA DE CLIENTES");
            }
        }
    }
}
