using BaseProdutos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.BaseProdutos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
             ProdutosApi();
            Cursor.Current = Cursors.Default;
            
        }
        public async void ProdutosApi()
        {
            try
            {
                pictureBox1.Visible = true;
                HttpClient client = new HttpClient();
                string url = "http://192.168.0.104:7475/api/Produto";
                var response = await client.GetStringAsync(url);
                richTextBox1.Text = response.ToString();
                pictureBox1.Visible = false;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
            }
        }

    }
}
