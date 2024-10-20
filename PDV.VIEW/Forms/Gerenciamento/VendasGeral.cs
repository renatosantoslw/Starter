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

namespace PDV.VIEW.Forms.Gerenciamento
{
    public partial class VendasGeral : Form
    {
        public VendasGeral()
        {
            InitializeComponent();
            carregarDAV();
        }

        public void AjustarColumas()
        {
            //Ajustar Nome
            gridView1.Columns[0].Caption = "ID";
            gridView1.Columns[1].Caption = "DATA";
            gridView1.Columns[2].Caption = "HORA";

            gridView1.Columns[2].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns[2].DisplayFormat.FormatString = "HH:mm";
            gridView1.Columns[3].Caption = "VENDEDOR";
            gridView1.Columns[4].Caption = "DOCUMENTO";
            gridView1.Columns[5].Caption = "CLIENTE";
            gridView1.Columns[6].Caption = "COMANDA";
            gridView1.Columns[7].Caption = "ITENS";
            gridView1.Columns[8].Caption = "TOTAL";
            gridView1.Columns[9].Caption = "IDCOMANDA";
            gridView1.Columns[10].Caption = "IDCLIENTE";
            gridView1.Columns[11].Caption = "IDUSUARIO";
            //Esconder Dados
            //gridView1.Columns[6].Visible = false;
            //gridView1.Columns[7].Visible = false;
            //gridView1.Columns[9].Visible = false;
            //gridView1.Columns[10].Visible = false;
            //gridView1.Columns[11].Visible = false;

        }
        private void carregarDAV()
        {
            DataTable table = FuncoesVenda.GetVendaGeral();
            gridControl1.DataSource = table;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            AjustarColumas();
            gridView1.BestFitColumns();
        }
        public int VENDAID { get; set; }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                GER_NotasFiscaisConsumidor dados = new GER_NotasFiscaisConsumidor();
                if (VENDAID != null)
                    dados.EmitirCupomGerencial(VENDAID);
            }
            catch (Exception)
            {
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            carregarDAV();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                VENDAID = int.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDVENDA").ToString()));
            }
            catch (Exception ex)
            {

               
            }
           
        }

        private void VendasGeral_Load(object sender, EventArgs e)
        {

        }
    }
}
