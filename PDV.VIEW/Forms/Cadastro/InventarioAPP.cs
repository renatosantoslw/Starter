using ModelAndroidApp.ModelAndroid;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.Estoque.Movimento;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class InventarioAPP : DevExpress.XtraEditors.XtraForm
    {
        private IniFile iniFile = null;
        public InventarioAPP()
        {
            InitializeComponent();
            carregar();
            iniFile = new IniFile(Contexto.CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW\\App_Data\\Start.ini" : "\\App_Data\\Start.ini")); ;
        }
        public class InventarioItem
        {
            public int ID { get; set; }
            public DateTime Data { get; set; }
            public int ProdutoID { get; set; }
            public string ProdutoNome { get; set; }

            public string Codigo { get; set; }

            public decimal Quantidade { get; set; }
            public int UsuarioID { get; set; }
            public string UsuarioNome { get; set; }
            public int EmpresaID { get; set; }
            public string EmpresaNome { get; set; }
            public bool Status { get; set; }
        }

        public async Task<List<InventarioItem>> ProdutosApi()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = iniFile.GetValue("Conexao_PDV", "apiforcadevendas") + "api/InventarioItems/";
                var response = await client.GetStringAsync(url);
                List<InventarioItem> InventarioItem = Newtonsoft.Json.JsonConvert.DeserializeObject<List<InventarioItem>>(response);
                gridControl1.DataSource = InventarioItem.ToList();
                gridView1.OptionsView.ColumnAutoWidth = false;
                gridView1.OptionsView.ShowAutoFilterRow = true;
                gridView1.OptionsView.ShowFooter = true;
                gridView1.BestFitColumns();
                return InventarioItem;

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                return null;

            }
        }

        private async void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            carregar();
        }

        private void carregar()
        {
            pictureBox1.Visible = true;

            Cursor.Current = Cursors.WaitCursor;


            using (ContextAppAndroid model = new ContextAppAndroid())
            {
                gridControl1.DataSource = model.InventarioItem.ToList();
                gridView1.OptionsView.ColumnAutoWidth = false;
                gridView1.OptionsView.ShowAutoFilterRow = true;
                gridView1.OptionsView.ShowFooter = true;
                gridView1.BestFitColumns();
            }

            Cursor.Current = Cursors.Default;

            pictureBox1.Visible = false;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            simpleButtonSelecionar.Enabled = true;
        }

        private void simpleButtonSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                using (ContextAppAndroid db = new ContextAppAndroid())
                {

                    PDV.DAO.Entidades.Emitente emitente = FuncoesEmitente.GetEmitente();

                    var Empresa = db.Empresa.Where(x => x.CNPJ == emitente.CNPJ).ToList();
                    if (Empresa.Count > 0)
                    {
                        if (Empresa[0].CNPJ != null)
                        {
                            int idempresa = Empresa[0].ID;
                            var produtos = db.InventarioItem.Where(x=>x.EmpresaID == idempresa).ToList();
                            foreach (var item in produtos)
                            {
                                PDV.DAO.Entidades.Produto produto = FuncoesProduto.GetProduto(decimal.Parse(item.ProdutoID.ToString()));
                                //Limpar Movimento de Estoque 

                                if (produto != null)
                                {
                                    FuncoesProduto.AtualizarSaldoEstoque(decimal.Parse(item.ProdutoID.ToString()), 0);
                                    FuncoesMovimentoEstoque.ExcluirMovimentoPorProduto(produto.IDProduto);

                                    if (!FuncoesMovimentoEstoque.Salvar(new MovimentoEstoque
                                    {
                                        IDMovimentoEstoque = Sequence.GetNextID("MOVIMENTOESTOQUE", "IDMOVIMENTOESTOQUE"),
                                        DataMovimento = DateTime.Now,
                                        IDAlmoxarifado = produto.IDAlmoxarifadoEntrada,
                                        //IDItemPedidoCompra = ,
                                        IDProduto = produto.IDProduto,
                                        Quantidade = item.Quantidade,
                                        Tipo = 0,
                                        Descricao = "Inventário Pelo Aplicativo",
                                        IDItemInventario = null,
                                        IDItemVenda = null,
                                        IDItemNFeEntrada = null,
                                        IDItemTransferenciaEstoque = null,
                                        IDProdutoNFe = null
                                    }))
                                    {

                                        throw new Exception($"Não foi possível salvar o Movimento de Estoque no produto de inventário de codigo {item.ProdutoID}.");
                                    }
                                  
                                }

                            }
                           
                            MessageBox.Show("Inventario Atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            db.Database.ExecuteSqlCommand($"delete InventarioItem ");

                        }
                        else
                        {
                            MessageBox.Show("Não existe um CNPJ cadastrado na base de dados do app estoque", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não existe uma empresa cadastrada na base de dados do app estoque", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
