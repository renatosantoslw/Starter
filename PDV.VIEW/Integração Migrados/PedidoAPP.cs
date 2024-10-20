using ModelAndroidApp.Controler;
using ModelAndroidApp.ModelAndroid;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW.Integração_Migrados
{

    public partial class PedidoAPP : DevExpress.XtraEditors.XtraForm
    {
        public int ID { get; set; }
        public PedidoAPP()
        {
            InitializeComponent();
            carregar();
        }
        public void carregar()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var Nota = NotaControllerAPP.BuscarNotaTudo();
                gridControlNota.DataSource = Nota;
                gridControlItens.DataSource = null;
                gridcontrolParcela.DataSource = null;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                gridView1.BestFitColumns();
                gridView1.OptionsView.ShowAutoFilterRow = true;
                gridView1.OptionsView.ColumnAutoWidth = false;
                gridView1.Columns[2].Visible = false;
                gridView1.Columns[4].Visible = false;
                gridView1.Columns[6].Visible = false;
                gridView1.Columns[13].Visible = false;
                gridView1.Columns[16].Visible = false;
                gridView1.Columns[17].Visible = false;
                gridView1.Columns[19].Visible = false;
                gridView1.Columns[21].Visible = false;
                gridView1.Columns[22].Visible = false;
                gridView1.Columns[23].Visible = false;
                gridView1.Columns[24].Visible = false;
                gridView1.Columns[26].Visible = false;
                //gridView1.Columns[27].Visible = false;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error ao importar clientes clique OK para continuar. Detalhes:" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                carregardados();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                throw;
              
            }
         
        }
        public int IDNota { get; set; }
        public int IDVendedor { get; set; }
        private void carregardados()
        {
            ID = int.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString()));
            IDNota = int.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDPedido").ToString()));
            IDVendedor = int.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDVendedor").ToString()));
            gridControlItens.DataSource = NotaControllerAPP.BuscarNotaItemPorID(IDNota, IDVendedor);
            gridcontrolParcela.DataSource = NotaControllerAPP.BuscarParcelaPorID(IDNota, IDVendedor);
            metroButton3.Enabled = true;
            FomartarGridParcelasEItens();
        }

        private void FomartarGridParcelasEItens()
        {
            gridView2.Columns[6].Visible = false;
            gridView2.Columns[14].Visible = false;
            gridView2.Columns[17].Visible = false;
            gridView2.Columns[18].Visible = false;
            gridView2.Columns[20].Visible = false;
           // gridView2.Columns[21].Visible = false;
            gridView3.Columns[5].Visible = false;
            gridView3.Columns[6].Visible = false;
            gridView2.OptionsBehavior.Editable = false;
            gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView3.OptionsBehavior.Editable = false;
            gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView2.OptionsView.ShowAutoFilterRow = true;
            gridView2.OptionsView.ColumnAutoWidth = false;
            gridView3.OptionsView.ShowAutoFilterRow = true;
            gridView3.OptionsView.ColumnAutoWidth = false;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Confirma a exclusão desse pedido?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Contexto contexto = new Contexto();
                    using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
                    {
                        db.Database.ExecuteSqlCommand($"Delete From Nota Where IDPedido ={IDNota} and ID ={ID}");
                        db.Database.ExecuteSqlCommand($"Delete From NotaItem Where IDNota = {ID} and IDVendedor = {IDVendedor}" );
                        db.Database.ExecuteSqlCommand($"Delete From Parcela Where NotaiD ={IDNota} and VendedorID ={IDVendedor}");
                        carregar();
                        metroButton3.Enabled = false;
                        MessageBox.Show("Atualizado com suceso!");
                    }
                    Cursor.Current = Cursors.WaitCursor;
                }
            }
            catch (Exception ex)
            {

                Cursor.Current = Cursors.Default;
            }
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            carregar();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ClienteFormsAPP clienteFormsAPP = new ClienteFormsAPP();
            clienteFormsAPP.ShowDialog();
        }
    }
}
