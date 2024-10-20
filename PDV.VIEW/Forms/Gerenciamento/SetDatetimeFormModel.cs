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
    public partial class SetDateTimeFormModel : DevExpress.XtraEditors.XtraForm
    {
        public DateTime DataDeVencimento { get; set; }
        public SetDateTimeFormModel(DateTime dataDeVencimento)
        {
            InitializeComponent();

            DataDeVencimento = dateTimePicker1.Value = dataDeVencimento;            

            SetDataMinima(DateTime.Now);
        }

        public void SetDataMinima(DateTime dataMinima)
        {
            dateTimePicker1.MinDate = dataMinima;
        }


        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Close()
        {
            base.Close();
        }

        private void DataValidadeDAV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            DataDeVencimento = dateTimePicker1.Value;
            Close();
        }
    }
}
