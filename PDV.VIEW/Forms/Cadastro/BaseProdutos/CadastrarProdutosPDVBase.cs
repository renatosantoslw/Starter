using BaseProdutos;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.BaseProdutos
{
    public partial class CadastrarProdutosPDVBase : DevExpress.XtraEditors.XtraForm
    {
        public List<Produto> ListaProduto { get; set; }

        private List<OrigemProduto> Origem = FuncoesOrigemProduto.GetOrigensProduto();
        private List<UnidadeMedida> Unidades = FuncoesUnidadeMedida.GetUnidadesMedida();
        private List<Marca> Marcas = FuncoesMarca.GetMarcas();
        private List<IntegracaoFiscal> IntegNFe = FuncoesIntegracaoFiscal.GetIntegracoes();
        private List<IntegracaoFiscal> IntegNFCe = FuncoesIntegracaoFiscal.GetIntegracoes();
        private List<Almoxarifado> AlmoxEntrada = FuncoesAlmoxarifado.GetAlmoxarifados();
        private List<Almoxarifado> AlmoxSaida = FuncoesAlmoxarifado.GetAlmoxarifados();


        public void carregarCombos()
        {
            ovCMB_IntegracaoNFe.DataSource = IntegNFe;
            ovCMB_IntegracaoNFe.DisplayMember = "descricao";
            ovCMB_IntegracaoNFe.ValueMember = "idintegracaofiscal";
            ovCMB_IntegracaoNFe.SelectedItem = null;

            ovCMB_IntegracaoNFCe.DataSource = IntegNFCe;
            ovCMB_IntegracaoNFCe.DisplayMember = "descricao";
            ovCMB_IntegracaoNFCe.ValueMember = "idintegracaofiscal";
            ovCMB_IntegracaoNFCe.SelectedItem = null;

            ovCMB_AlmoxEntrada.DataSource = AlmoxEntrada;
            ovCMB_AlmoxEntrada.DisplayMember = "descricaoapresentacao";
            ovCMB_AlmoxEntrada.ValueMember = "idalmoxarifado";

            ovCMB_AlmoxSaida.DataSource = AlmoxSaida;
            ovCMB_AlmoxSaida.DisplayMember = "descricaoapresentacao";
            ovCMB_AlmoxSaida.ValueMember = "idalmoxarifado";

            metroComboBoxTipoDeProduto.SelectedIndex = -1;
        }
        public CadastrarProdutosPDVBase()
        {
            InitializeComponent();
            ListaProduto = new List<Produto>();
        }

        private void simpleButtonBaixar_Click(object sender, EventArgs e)
        {
            BuscarBaseProdutos buscarBaseProdutos = new BuscarBaseProdutos();
            buscarBaseProdutos.ShowDialog();
            var produtoSelecionado = buscarBaseProdutos.GetProdutoSelecionado();

            if (produtoSelecionado != null)
            {

                Marca marca = GetOrCreateMarca(produtoSelecionado);
                Categoria categoria = GetOrCreateCategoria(produtoSelecionado);

                Produto produto = new Produto()
                {
                    Descricao = produtoSelecionado.DescricaoUpper,
                    EAN = produtoSelecionado.Gtin,
                    IDMarca = marca != null ? marca.IDMarca : -1,
                    IDCategoria = categoria != null ? categoria.IDCategoria : -1,
                    IDNCM = produtoSelecionado.Ncm != null ? FuncoesNcm.GetNCMPorCodigo(Convert.ToDecimal(produtoSelecionado.Ncm)).IDNCM : -1,
                    CEST = produtoSelecionado.Cest,
                    ValorVenda = produtoSelecionado.PrecoMedio
                };
                textEditNomeProduto.Text = produto.Descricao;


                imageProdutoPictureBox.ImageLocation = "http://192.168.0.104:7475/Content/Imagens/" + produtoSelecionado.FotoGif;
            }
        }
        private Marca GetOrCreateMarca(ProdutoBase produtoSelecionado)
        {
            Marca marca = null;
            if (produtoSelecionado.Marca != null)
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
                            IDMarca = PDV.DAO.DB.Utils.Sequence.GetNextID("MARCA", "IDMARCA"),
                            Descricao = produtoSelecionado.Marca
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
        private Categoria GetOrCreateCategoria(ProdutoBase produtoSelecionado)
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
