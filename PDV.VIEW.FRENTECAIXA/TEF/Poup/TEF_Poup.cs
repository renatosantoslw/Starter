using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.TEF.Poup
{
    public partial class TEF_Poup : Form
    {
        public decimal Valor { get; set; }
        public string formaPagamento { get; set; }
        public TEF_Poup(string FormaPagamento)
        {
            InitializeComponent();
            this.Text = FormaPagamento;
        }

        private void TEF_Poup_Load(object sender, EventArgs e)
        {

        }

        private void btnEfetuarPagamento_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(valorPagamentoTextBox.Text))
            {
                MessageBox.Show("Informe um valor!");
            }
            else
            {
                formaPagamento = this.Text;
                Valor = decimal.Parse(valorPagamentoTextBox.Text);
                this.Close();
            }
        }
    }
}
