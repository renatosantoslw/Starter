using PDV.VIEW.Tarefas_do_Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PDV.VIEW.Tarefas_do_Sistema.Tarefas;

namespace PDV.UTIL.FORMS.Forms
{
    public partial class TarefasForms : Form
    {
        public TarefasForms()
        {
            InitializeComponent();
            dataGridView1.DataSource = WSMonitoramento.Log;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            WSMonitoramento.Log = null;
            dataGridView1.DataSource = WSMonitoramento.Log;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = WSMonitoramento.Log;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RefreshEdit();
                dataGridView1.Refresh();
                dataGridView1.ClearSelection();//If you want

                int nRowIndex = dataGridView1.Rows.Count - 1;
                int nColumnIndex = 0;

                dataGridView1.Rows[nRowIndex].Selected = true;
                dataGridView1.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

                //In case if you want to scroll down as well.
                dataGridView1.FirstDisplayedScrollingRowIndex = nRowIndex;
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception)
            {

            }
        }

        private void Tarefas_Load(object sender, EventArgs e)
        {

            //Task.Run((Action)(Tarefas.RunMonitoramento));
        }

       
    }
}
