using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Util;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using PDV.UTIL.FORMS.Forms;
using System.Runtime.Remoting.Contexts;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_ProdutoPDV : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE PRODUTOS";
        public bool IsAdmin { get; set; }
        public FCO_ProdutoPDV(decimal idPerfilAcesso)
        {            
            InitializeComponent();
            AtualizaProdutos("", "");
            var perfilAcesso = FuncoesPerfilAcesso.GetPerfil(idPerfilAcesso);
            IsAdmin = perfilAcesso.IsAdmin == 1;
        }

        public new void ShowDialog()
        {
            if (!IsAdmin)
            {
                var loginAdmin = new LoginAdmin();
                loginAdmin.ShowDialog();
                if (!loginAdmin.IsLogado)
                    return;
            }
           
            
            base.ShowDialog();
        }

        private void AtualizaProdutos(string Codigo, string Descricao)
        {
            gridControl1.DataSource = FuncoesProduto.GetProdutos(Codigo, Descricao);
            FormatarGrid();
        }

        private void FormatarGrid()
        {
            Grids.FormatColumnType(ref gridView1,"codigo", GridFormats.VisibleFalse);

            Grids.FormatColumnType(ref gridView1, new List<string>() 
            { 
                "valorcusto",
                "valorvenda",
                "valorvendaprazo"
            }, GridFormats.Finance);

            Grids.FormatGrid(ref gridView1);
        }

        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {
            FCA_Produtos t = new FCA_Produtos(new DAO.Entidades.Produto(), true);
            t.ShowDialog(this);
            TopMost = true;
            AtualizaProdutos("","");
            DesabilitarBotoes();
        }

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o Produto selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                decimal IDProduto = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDPRODUTO").ToString()));
                try
                {

                    PDVControlador.BeginTransaction();

                    if (FuncoesProduto.ExisteProdutoVinculadoComVenda(IDProduto))
                        throw new Exception("Produto possui vínculo com Venda e não pode ser removido.");

                    FuncoesProdutoComposicao.RemoverPorProdutoComposto(IDProduto);

                    FuncoesProdutoComposicao.RemoverPorProduto(IDProduto);



                    if (!FuncoesProduto.Remover(IDProduto))
                        throw new Exception("Não foi possível remover o Produto.");


                    PDVControlador.Commit();
                }
                catch (Exception Ex)
                {
                    PDVControlador.Rollback();
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizaProdutos("","");
            }
            DesabilitarBotoes();
        }

       
        private void FCO_Produto_Load_1(object sender, EventArgs e)
        {
            AtualizaProdutos("","");
        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {
            buttonEditar.Enabled = true;
            metroButton3.Enabled = true;
        }

        private void gridControl1_DoubleClick_1(object sender, EventArgs e)
        {
            Editar();
        }


        private void Editar()
        {
            try
            {
                var id = Grids.GetValorDec(gridView1, "idproduto");
                FCA_Produtos t = new FCA_Produtos(FuncoesProduto.GetProduto(id), true);
                t.ShowDialog(this);
                AtualizaProdutos("", "");
                
            }
            catch (NullReferenceException e)
            {

            }
            finally
            {
                DesabilitarBotoes();
            }
        }
        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizaProdutos("","");
            buttonEditar.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void simpleButtonDuplicar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja duplicar esse produto?", "CONSULTA DE PRODUTO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                try
                {
                    PDVControlador.BeginTransaction();
                    var idProduto = Grids.GetValorDec(gridView1, "idproduto");
                    var composicoes = FuncoesProdutoComposicao.GetComposicoesPorComposto(idProduto);
                    Produto produto = FuncoesProduto.GetProduto(idProduto);
                    produto.IDProduto = DAO.DB.Utils.Sequence.GetNextID("PRODUTO", "IDPRODUTO");
                    produto.Codigo = produto.IDProduto.ToString();
                    produto.EAN = GerarCodigo(produto);

                    if (!FuncoesProduto.SalvarProduto(produto, DAO.Enum.TipoOperacao.INSERT))
                        throw new Exception("Não foi possível duplicar o produto");


                    DuplicarComposicao(composicoes, produto.IDProduto);

                    
                    AtualizaProdutos("", "");
                    PDVControlador.Commit();
                }
                catch (Exception exce)
                {
                    MessageBox.Show(exce.Message);
                    PDVControlador.Rollback();
                }
                finally
                {
                    DesabilitarBotoes();
                }
            }
        }

        private void DuplicarComposicao(List<ProdutoComposicao> composicoes, decimal idProduto)
        {
            foreach (var composicao in composicoes)
            {
                
                composicao.IdProdutoComposicao = DAO.DB.Utils.Sequence.GetNextID("PRODUTOCOMPOSICAO", "IDPRODUTOCOMPOSICAO");
                composicao.IdProdutoComposto = idProduto;
                if(!FuncoesProdutoComposicao.Salvar(composicao))
                    throw new Exception($"Não foi possível inserir um item de composição. Nome: {composicao.Descricao}");
            }
        }

       
        private void DesabilitarBotoes()
        {
            buttonEditar.Enabled = metroButton3.Enabled = false;
        }     

       private string GerarCodigo(Produto produto)
       {
            Util.FGR_GeradorCodigoProduto gerador = new Util.FGR_GeradorCodigoProduto(new FCA_Produtos(produto, true),produto.IDProduto.ToString());
            gerador.GerarCodigoDeBarras();
            return gerador.CodigoDeBarras;
       }


        private void gridView1_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            GridImprimir.FormatarImpressão(ref e);
        }
    }
}
