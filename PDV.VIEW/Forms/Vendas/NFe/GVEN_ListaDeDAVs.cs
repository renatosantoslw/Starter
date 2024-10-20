using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Entidades.Estoque.PedidoDeCompra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Vendas.NFe
{
    public partial class GVEN_ListaDeDAVs : DevExpress.XtraEditors.XtraForm
    {
        public int TOperacao;
        public Venda Venda { get; set; } = null;
        public PedidoCompra Compra { get; set; } = null;


        public GVEN_ListaDeDAVs()
        {
            InitializeComponent();
            PreencherTabela();
        }
        private void PreencherTabela()        
        {
            DataTable dataTable = FuncoesVenda.GetVendasFaturadas();  
         

            gridControl1.DataSource = dataTable;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            FormatarTabela();
          

        }
        private void FormatarTabela()
        {  //Ajustar Nome
            gridView1.Columns[0].Caption = "NÚM. DAV";
            gridView1.Columns[1].Caption = "DATA EMISSÃO";
            gridView1.Columns[2].Caption = "HORA";

            gridView1.Columns[2].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns[2].DisplayFormat.FormatString = "HH:mm";
            gridView1.Columns[3].Caption = "VENDEDOR";
            gridView1.Columns[4].Caption = "DOCUMENTO";
            gridView1.Columns[5].Caption = "CLIENTE";
            gridView1.Columns[6].Caption = "TIPO DE OPERAÇÃO";
            gridView1.Columns[7].Caption = "COMANDA";
            gridView1.Columns[8].Caption = "ITENS";
            gridView1.Columns[9].Caption = "TOTAL";
            gridView1.Columns[10].Caption = "IDCOMANDA";
            gridView1.Columns[11].Caption = "IDCLIENTE";
            gridView1.Columns[12].Caption = "IDUSUARIO";

            //Esconder Dados
            gridView1.Columns[13].Visible = false;
            gridView1.Columns[7].Visible = false;
            gridView1.Columns[8].Visible = false;
            gridView1.Columns[10].Visible = false;
            gridView1.Columns[11].Visible = false;
            gridView1.Columns[12].Visible = false;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            decimal IDVenda = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0].FieldName));
            Venda = FuncoesVenda.GetVenda(IDVenda);

        }
    }
}
