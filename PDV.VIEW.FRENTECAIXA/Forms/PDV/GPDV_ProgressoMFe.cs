using PDV.VIEW.FRENTECAIXA.MFe.Emissao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PDV.VIEW.FRENTECAIXA.MFe.Emissao.EmitirMFe;

namespace PDV.VIEW.FRENTECAIXA.Forms.PDV
{
    public partial class GPDV_ProgressoMFe : Form
    {
        private bool habilitadoFechar = false;
        EmitirMFe EmitirMFe;
        public bool Sucesso { get; set; }
        public GPDV_ProgressoMFe()
        {
            InitializeComponent();
            EmitirMFe = new EmitirMFe();
            dataGridView.DataSource = WSMonitoramento.Log;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void FechaForm()
        {

            Close();
        }

        public void PublicaProgresso(string progresso)
        {
            dataGridView.Rows.Add(progresso);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GPDV_ProgressoMFe_Load(object sender, EventArgs e)
        {
            //CheckForIllegalCrossThreadCalls = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Sucesso = false;
                var ultimaMensagem = WSMonitoramento.Log.LastOrDefault();

                if (ultimaMensagem != null && ultimaMensagem.Mensagem.ToString() == "Sucesso")
                {
                    Sucesso = true;
                   
                    this.Close();
                }
                else
                {
                    dataGridView.DataSource = WSMonitoramento.Log;
                    dataGridView.RefreshEdit();
                    dataGridView.Refresh();
                    dataGridView.ClearSelection();//If you want
                    int nRowIndex = dataGridView.Rows.Count - 1;
                    int nColumnIndex = 0;
                    dataGridView.Rows[nRowIndex].Selected = true;
                    dataGridView.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                    //In case if you want to scroll down as well.
                    dataGridView.FirstDisplayedScrollingRowIndex = nRowIndex;
                    dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }


            }
            catch (Exception)
            {

            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            WSMonitoramento.Log = null;
            dataGridView.DataSource = WSMonitoramento.Log;
        }
    }
}
