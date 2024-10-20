using System;
using System.Linq;
using System.Windows.Forms;

namespace ConrollerLicença
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (clientetextBox.Text == String.Empty)
                    throw new Exception("Informe o cliente.");
                if (documentotextBox.Text == String.Empty)
                    throw new Exception("Informe o documento.");
                int ID = int.Parse(idTextBox.Text);
                using (Contexto db = new Contexto())
                {
                    Cliente cliente = new Cliente()
                    {
                        ID = ID,
                        Nome = clientetextBox.Text,
                        Documento = documentotextBox.Text,
                        Observação = observacaotextBox.Text,
                        DataVencimento = datavencimentoDateTimePicker.Value,
                        DataAplicação = dataAplicacaoDateTimePicker.Value,
                        Chave = ChaveDeAcessotextBox.Text,
                        Ativo = ativocheckBox.Checked
                    };
                    if (cliente.ID == 0)
                    {
                        //Insere
                        db.Cliente.Add(cliente);
                        db.SaveChanges();
                       
                        Listar();
                        Limpar();
                        MessageBox.Show("Salvo com sucesso!");
                    }
                    else
                    {
                        //Atualiza
                        Cliente clienteUpdate = db.Cliente.First(x => x.ID == cliente.ID);
                        clienteUpdate.ID = ID;
                        clienteUpdate.Nome = clientetextBox.Text;
                        clienteUpdate.Documento = documentotextBox.Text;
                        clienteUpdate.Observação = observacaotextBox.Text;
                        clienteUpdate.DataVencimento = datavencimentoDateTimePicker.Value;
                        clienteUpdate.DataAplicação = dataAplicacaoDateTimePicker.Value;
                        clienteUpdate.Chave = ChaveDeAcessotextBox.Text;
                        clienteUpdate.Ativo = ativocheckBox.Checked;
                        db.SaveChanges();
                     
                        Limpar();
                        Listar();
                        MessageBox.Show("Atualizado com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Limpar()
        {
            idTextBox.Text = "0";
            clientetextBox.Text = "";
            documentotextBox.Text = "";
            observacaotextBox.Text = "";
            datavencimentoDateTimePicker.Value = DateTime.Now;
            dataAplicacaoDateTimePicker.Value = DateTime.Now;
            ChaveDeAcessotextBox.Text = "";
            ativocheckBox.Checked = false;
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            Listar();

        }

        private void Listar()
        {
            try
            {
                dgClientes.DataSource = null;
                using (Contexto db = new Contexto())
                {
                    dgClientes.DataSource = db.Cliente.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int ID = 0;
            if (dgClientes.Rows[e.RowIndex].Cells[0].Value != null)
                ID = int.Parse(dgClientes.Rows[e.RowIndex].Cells[0].Value.ToString());
            try
            {
                using (Contexto db = new Contexto())
                {
                   var listaCliente =  db.Cliente.Where(x => x.ID == ID).ToList();
                    foreach (var item in listaCliente)
                    {
                        idTextBox.Text = item.ID.ToString();
                        clientetextBox.Text = item.Nome;
                        documentotextBox.Text = item.Documento;
                        observacaotextBox.Text = item.Observação;
                        datavencimentoDateTimePicker.Value = Convert.ToDateTime(item.DataVencimento);
                        dataAplicacaoDateTimePicker.Value = Convert.ToDateTime(item.DataVencimento);
                        ChaveDeAcessotextBox.Text = item.Chave;
                        ativocheckBox.Checked = item.Ativo;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Limpar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(pesquisaqrtextBox.Text.Length > 3)
            {
                dgClientes.DataSource = null;
                using (Contexto db = new Contexto())
                {
                    var pesquisa = db.Cliente.Where(x => x.Nome.Contains(pesquisaqrtextBox.Text.Trim()) || x.Documento.Contains(documentotextBox.Text.Trim()));

                    dgClientes.DataSource = pesquisa.ToList();
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir esse cliente?", "Licença", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (idTextBox.Text != "0")
                {
                    using (Contexto db = new Contexto())
                    {
                        db.Database.ExecuteSqlCommand("Delete Cliente Where ID = " + idTextBox.Text);
                        Listar();
                        Limpar();
                        MessageBox.Show("Excluido com sucesso");
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um cliente para excluir!");
                }
            }

        }

        private void datavencimentoDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Criptografia crip = new Criptografia(CryptProvider.DES);
            crip.Key = documentotextBox.Text + "AAA";
            var datavalidade = Convert.ToString(crip.Encrypt(datavencimentoDateTimePicker.Value.Date.ToString())); ;//String de Conexão WEB
            ChaveDeAcessotextBox.Text = datavalidade.ToString();
        }

        private void dataAplicacaoDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
