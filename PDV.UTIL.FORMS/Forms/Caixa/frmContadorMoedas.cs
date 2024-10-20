using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.UTIL.FORMS.Forms.Caixa
{
    public partial class frmContadorMoedas : Form
    {
        public frmContadorMoedas()
        {
            InitializeComponent();
        }
        public string  Valornicial { get; set; }
        private void frmContadorMoedas_Load(object sender, EventArgs e)
        {
            dgDados.Rows.Add("5 centavo");
            dgDados.Rows.Add("10 centavo");
            dgDados.Rows.Add("25 centavo");
            dgDados.Rows.Add("50 centavo");
            dgDados.Rows.Add("1 (Moeda)");
            dgDados.Rows.Add("2 Reais");
            dgDados.Rows.Add("5 Reais");
            dgDados.Rows.Add("10 Reais");
            dgDados.Rows.Add("20 Reais");
            dgDados.Rows.Add("50 Reais");
            dgDados.Rows.Add("100 Reais");
        }

        private void dgDados_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    decimal cell1 = 0;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "5 centavo")
                        cell1 = 0.05M;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "10 centavo")
                        cell1 = 0.10M;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "25 centavo")
                        cell1 = 0.25M;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "50 centavo")
                        cell1 = 0.50M;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "1 (Moeda)")
                        cell1 = 1;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "2 Reais")
                        cell1 = 2;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "5 Reais")
                        cell1 = 5;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "10 Reais")
                        cell1 = 10;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "20 Reais")
                        cell1 = 20;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "50 Reais")
                        cell1 = 50;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "100 Reais")
                        cell1 = 100;
                    decimal ValorTotal = 0;
                    decimal cell2 = Convert.ToDecimal(dgDados.CurrentRow.Cells[1].Value);
                    if (cell1.ToString() != "" && cell2.ToString() != "")
                    {

                        ValorTotal = cell1 * cell2;
                        dgDados.CurrentRow.Cells[2].Value = ValorTotal.ToString("C");

                    }
                }
                decimal valorTotal = 0;
                string valor = "";

                if (dgDados.CurrentRow.Cells[2].Value != null)
                {
                    valor = dgDados.CurrentRow.Cells[2].Value.ToString();
                    if (!valor.Equals(""))
                    {

                        for (int i = 0; i <= dgDados.RowCount - 1; i++)
                        {
                            if (dgDados.Rows[i].Cells[2].Value != null)
                            {
                                string v = dgDados.Rows[i].Cells[2].Value.ToString();
                                string vr = v.ToString().Replace("R$", "");
                                if (dgDados.Rows[i].Cells[2].Value != null)
                                    valorTotal += Convert.ToDecimal(vr);
                            }
                        }
                        if (valorTotal == 0)
                        {
                            MessageBox.Show("Nenhum registro encontrado");
                        }
                        txtTotal.Text = valorTotal.ToString("C");
                        Valornicial = valorTotal.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgDados.Rows.Clear();
            dgDados.Rows.Add("5 centavo");
            dgDados.Rows.Add("10 centavo");
            dgDados.Rows.Add("25 centavo");
            dgDados.Rows.Add("50 centavo");
            dgDados.Rows.Add("1 (Moeda)");
            dgDados.Rows.Add("2 Reais");
            dgDados.Rows.Add("5 Reais");
            dgDados.Rows.Add("10 Reais");
            dgDados.Rows.Add("20 Reais");
            dgDados.Rows.Add("50 Reais");
            dgDados.Rows.Add("100 Reais");
            txtTotal.Text = "0,00";
        }

        private void dgDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
