using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms.PDV
{
    public partial class GPDV_ProgressoNFe : Form
    {
        private bool habilitadoFechar = false;
        public GPDV_ProgressoNFe()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        public void FechaForm()
        {
            Close();
        }

        public void PublicaProgresso(string progresso)
        {
            dataGridView.Rows.Add(progresso);
        }

        private void GPDV_ProgressoMFe_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
