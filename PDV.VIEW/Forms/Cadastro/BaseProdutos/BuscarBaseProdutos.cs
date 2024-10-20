
using BaseProdutos;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Consultas;
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
    public partial class BuscarBaseProdutos : Form
    {
        private IniFile iniFile = null;
        public FCO_Produto cadprodutos  { get; set; }
        private List<ProdutoBase> Produtos { get; set; } = null;
        private ProdutoBase ProdutoSelecionado { get; set; } = null;
        public BuscarBaseProdutos()
        {
            InitializeComponent();
            iniFile = new IniFile(Contexto.CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW\\App_Data\\Start.ini" : "\\App_Data\\Start.ini")); ;
            cadprodutos = new FCO_Produto();
            gridView1.GroupPanelText = "Arraste para agrupar";
            pesquisarProdutoAPIText.Select();
        }
        public async Task<List<ProdutoBase>> ProdutosApi()
        {
            try
            {
                //HttpClient client = new HttpClient();
                //string url = iniFile.GetValue("Conexao_PDV", "apibaseproduto") + pesquisarProdutoAPIText.Text;
                //var response = await client.GetStringAsync(url);
                ////var produtos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Produtos>>("["+response+"]");
                //Produtos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Produtos>>(response);
                Produtos = BaseProdutosController.GetProdutos(pesquisarProdutoAPIText.Text);
                if (Produtos.Count == 0)
                    Alert("Desculpe, a busca não achou nenhum produto na base de dados.");
                else if (Produtos.Count == 1)
                {
                    ProdutoSelecionado = Produtos.FirstOrDefault();
                    GerarTelaCadastro();
                    pesquisarProdutoAPIText.Text = "";

                    pesquisarProdutoAPIText.Select();
                }
                else
                {
                    gridControl1.DataSource = Produtos;
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.OptionsView.ShowAutoFilterRow = true;
                    gridView1.OptionsView.ShowFooter = true;
                    gridView1.BestFitColumns();
                }                
                
                return Produtos;

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                Alert(ex.Message);
                return null;
               
            }
        }

        private void Alert(string message)
        {
            MessageBox.Show(message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuscarBaseProdutos_Load(object sender, EventArgs e)
        {
           
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            simpleButtonSelecionar.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            await ProdutosApi();
            Cursor.Current = Cursors.Default;
            ProdutoSelecionado = null;
            pictureBox1.Visible = false;
        }

        

        private void simpleButtonSelecionar_Click(object sender, EventArgs e)
        {
            //Close();
            GerarTelaCadastro();
        }

        private void GerarTelaCadastro()
        {
            if (ProdutoSelecionado != null)
            {
                Produto Produtos = ConversorProdutoBase.GerarProdutoLocal(ProdutoSelecionado);
                FCA_Produtos FormProdutos = new FCA_Produtos(Produtos);
                FormProdutos.imageProdutoPictureBox.Image = pictureBox2.Image;
                FormProdutos.ShowDialog();
            }
        }

        

        public ProdutoBase GetProdutoSelecionado()
        {
            return ProdutoSelecionado;
        }

        private void gridView1_Click(object sender, EventArgs e)
        {

            try
            {
                string gtin = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1].ToString()).ToString();
                ProdutoSelecionado = Produtos.Where(p => p.Gtin == gtin).FirstOrDefault();
                pictureBox2.ImageLocation = iniFile.GetValue("Conexao_PDV", "apibaseproduto").Replace("/api/Produto/BuscarProdutosON", "")  + "/Content/Imagens/" + ProdutoSelecionado.FotoGif;
                simpleButtonSelecionar.Enabled = true;
            }
            catch (NullReferenceException)
            {
            }
            catch(ArgumentOutOfRangeException)
            {

            }
            catch(Exception exception)
            {
                Alert(exception.Message);
            }
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (GetProdutoSelecionado() != null)
            {
                Close();
            }
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void pesquisarProdutoAPIText_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void pesquisarProdutoAPIText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1_Click(sender, e);
            }
        }
    }
}
