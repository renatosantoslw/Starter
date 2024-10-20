using BaseProdutos;
using DevExpress.XtraReports.UI;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Email_Report_Gestor;
using PDV.REPORTS.Reports.Email_Gestor;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Cadastro.BaseProdutos;
using PDV.VIEW.Forms.Estoque.PedidoDeCompra;
using PDV.VIEW.Forms.Util;
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.XtraReports.Design.Commands;
using DevExpress.XtraRichEdit.Model;
using FontAwesome.Sharp;
using System.Drawing;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_Produto : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE PRODUTOS";

        public FCO_Produto()
        {
            InitializeComponent();
            AtualizaProdutos("", "");
            metroTabControl2.SelectedTab = metroTabPage5;

            //IconesFA.Icones24 icones2 = new IconesFA.Icones24();
            //icones
            
            Bitmap bitmapNovo = IconChar.PlusSquare.ToBitmap(Color.DarkGreen, 24);
            Bitmap bitmapDuplicar = IconChar.Clone.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapEditar = IconChar.PenSquare.ToBitmap(Color.DarkOrange, 24);
            Bitmap bitmapRemover = IconChar.MinusSquare.ToBitmap(Color.Firebrick, 24);
            Bitmap bitmapAtualizar = IconChar.SyncAlt.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapMovimento = IconChar.ExchangeAlt.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapImprimir = IconChar.Print.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapBuscarProdutoNuvem = IconChar.CloudDownloadAlt.ToBitmap(Color.SteelBlue, 24);

            metroButton5.ImageOptions.Image = bitmapBuscarProdutoNuvem;
            metroButton5.ImageOptions.Image = bitmapNovo; 
            simpleButtonDuplicar.ImageOptions.Image = bitmapDuplicar;
            buttonEditar.ImageOptions.Image = bitmapEditar;
            metroButton3.ImageOptions.Image = bitmapRemover;//remover
            atualizarMetroButton.ImageOptions.Image = bitmapAtualizar;
            botaoMovimento.ImageOptions.Image = bitmapMovimento;
            imprimriMetroButton.ImageOptions.Image = bitmapImprimir;
            simpleButton1.ImageOptions.Image = bitmapBuscarProdutoNuvem;
        }

        private void AtualizaProdutos(string Codigo, string Descricao)
        {
            gridControl1.DataSource = FuncoesProduto.GetProdutos(Codigo, Descricao);
            FormatarGrid();
        }

        private void FormatarGrid()
        {
            Grids.FormatColumnType(ref gridView1,"idproduto", GridFormats.VisibleFalse);

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
            FCA_Produtos t = new FCA_Produtos(new DAO.Entidades.Produto());
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

                    FuncoesProdutoComposicao.RemoverPorProdutoItemovimentoestoque(IDProduto);

                    FuncoesProdutoComposicao.RemoverPorProdutoIteminventario(IDProduto);



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

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
            DesabilitarBotoes();
        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {
            botaoMovimento.Enabled = true;
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
                var id = Grids.GetValorDec(gridView1, "IDPRODUTO");
                FCA_Produtos t = new FCA_Produtos(FuncoesProduto.GetProduto(id));
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
                    var idProduto = Grids.GetValorDec(gridView1, "IDPRODUTO");
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal idProduto = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDPRODUTO").ToString());
                new FCO_MovimentoEstoque(idProduto).ShowDialog();
            }
            catch (NullReferenceException)
            {

            }
            finally
            {
                DesabilitarBotoes();
            }           
        }
        private void DesabilitarBotoes()
        {
            buttonEditar.Enabled = metroButton3.Enabled = botaoMovimento.Enabled = false;
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            BuscarBaseProdutos();
        }
        private void BuscarBaseProdutos()
        {
            BuscarBaseProdutos produtos = new BuscarBaseProdutos();
            produtos.ShowDialog();
            //var produtoSelecionado = produtos.GetProdutoSelecionado();
            //if (produtoSelecionado != null)
            //{
            //    Marca marca = GetOrCreateMarca(produtoSelecionado);
            //    Categoria categoria = GetOrCreateCategoria(produtoSelecionado);
            //    decimal idNcm = 23619;
            //    if (produtoSelecionado.Ncm != null)
            //    {
            //        try
            //        {
            //            idNcm = FuncoesNcm.GetNCMPorCodigo(Convert.ToDecimal(produtoSelecionado.Ncm)).IDNCM;
            //        }
            //        catch (NullReferenceException)
            //        {
            //        }
            //    }
            //    Produto Produtos = new Produto()
            //    {
            //        Descricao = produtoSelecionado.DescricaoUpper,
            //        EAN = produtoSelecionado.Gtin,
            //        IDMarca = marca != null ? marca.IDMarca : -1,
            //        IDCategoria = categoria != null ? categoria.IDCategoria : -1,
            //        IDNCM = idNcm,
            //        CEST = produtoSelecionado.Cest,
            //        ValorVenda = produtoSelecionado.PrecoMedio

            //    };
             //   FCA_Produtos FormProdutos = new FCA_Produtos(Produtos);
              //  FormProdutos.imageProdutoPictureBox.Image = produtos.pictureBox2.Image;
            //    FormProdutos.ShowDialog();
                AtualizaProdutos("", "");
                buttonEditar.Enabled = false;
                metroButton3.Enabled = false;
            //}


        }

        public Marca GetOrCreateMarca(ProdutoBase produtoSelecionado)
        {
            Marca marca = null;
            if (produtoSelecionado.Marca !=null)
            {
                try
                {
                    PDVControlador.BeginTransaction();
                    if (FuncoesMarca.Existe(produtoSelecionado.Marca))
                    {
                        marca = FuncoesMarca.GetMarca(produtoSelecionado.Marca);
                    }
                    else
                    {
                        marca = new Marca()
                        {
                            IDMarca = DAO.DB.Utils.Sequence.GetNextID("MARCA", "IDMARCA"),
                            Codigo = ZeusUtil.GetProximoCodigo("MARCA", "CODIGO").ToString(),
                            Descricao = produtoSelecionado.Marca,
                            MarcaDeProduto = true,
                            MarcaDeVeiculo  = false
                        };
                        FuncoesMarca.Salvar(marca, DAO.Enum.TipoOperacao.INSERT);
                    }
                    PDVControlador.Commit();
                }
                catch (Exception)
                {
                    PDVControlador.Rollback();
                }
               
            }
            return marca;
        }
        public Categoria GetOrCreateCategoria(ProdutoBase produtoSelecionado)
        {
            Categoria categoria = null;
            if (produtoSelecionado.Categoria != null)
            {
                try
                {
                    PDVControlador.BeginTransaction();
                    if (FuncoesCategoria.Existe(produtoSelecionado.Categoria))
                    {
                        categoria = FuncoesCategoria.GetCategoria(produtoSelecionado.Categoria);
                    }
                    else
                    {
                        categoria = new Categoria()
                        {
                            IDCategoria = PDV.DAO.DB.Utils.Sequence.GetNextID("CATEGORIA", "IDCATEGORIA"),
                            Descricao = produtoSelecionado.Categoria
                        };
                        FuncoesCategoria.Salvar(categoria, DAO.Enum.TipoOperacao.INSERT);
                    }
                    PDVControlador.Commit();
                }
                catch (Exception)
                {
                    PDVControlador.Rollback();
                }

            }
            return categoria;
        }
       private string GerarCodigo(Produto produto)
       {
            Util.FGR_GeradorCodigoProduto gerador = new Util.FGR_GeradorCodigoProduto(new FCA_Produtos(produto),produto.IDProduto.ToString());
            gerador.GerarCodigoDeBarras();
            return gerador.CodigoDeBarras;
       }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "saldoestoque")
            {
                int value = Convert.ToInt32(e.CellValue);
                if (value <= 0)
                {
                    e.Appearance.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FCO_PedidoCompra fCO_PedidoCompra = new FCO_PedidoCompra();
            fCO_PedidoCompra.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            InventarioAPP inventarioAPP = new InventarioAPP();
            inventarioAPP.ShowDialog();
            AtualizaProdutos("", "");
            buttonEditar.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            PosicaoDeEstoqueReport rel = new PosicaoDeEstoqueReport();
            using (ReportPrintTool printTool = new ReportPrintTool(rel))
            {
                printTool.ShowPreviewDialog();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            PosicaoEstoquePorGrupo rel = new PosicaoEstoquePorGrupo();
            using (ReportPrintTool printTool = new ReportPrintTool(rel))
            {
                printTool.ShowPreviewDialog();
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            PosicaoEstoquePorGrupoCusto rel = new PosicaoEstoquePorGrupoCusto();
            using (ReportPrintTool printTool = new ReportPrintTool(rel))
            {
                printTool.ShowPreviewDialog();
            }
        }

        private void gridView1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void gridView1_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            GridImprimir.FormatarImpressão(ref e);
        }

        private void gridControl1_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void metroTabPage5_Click(object sender, EventArgs e)
        {

        }
    }
}
