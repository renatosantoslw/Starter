using ModelAndroidApp.ModelAndroid;
using Newtonsoft.Json;
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
    public partial class ClienteFormsAPP : DevExpress.XtraEditors.XtraForm
    {
        public ClienteFormsAPP()
        {
            InitializeComponent();
            carregarDados();
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            carregarDados();
        }

        private void carregarDados()
        {
            Cursor.Current = Cursors.WaitCursor;
            Contexto contexto = new Contexto();
            using (ModelAndroidApp.ModelAndroid.ContextAppAndroid db = new ModelAndroidApp.ModelAndroid.ContextAppAndroid())
            {
                var BaseAPP = db.BaseAPP.ToList();
                foreach (var item in BaseAPP)
                {
                    String jsonClintes = item.Clientes.ToString();

                    List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(jsonClintes);
                    gridControlNota.DataSource = clientes;
                }
                carregar();


            }
            Cursor.Current = Cursors.WaitCursor;
        }

        private void carregar()
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.ColumnAutoWidth = false;
        }
    }
}
