using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdutoLocal = PDV.DAO.Entidades.Produto;

namespace BaseProdutos
{
    public class ConversorProdutoBase
    {

        public static ProdutoLocal GerarProdutoLocal(ProdutoBase produto)
        {
            Marca marca = GetOrCreateMarca(produto);
            Categoria categoria = GetOrCreateCategoria(produto);
            decimal idNcm = 23619;
            if (produto.Ncm != null)
            {
                try
                {
                    idNcm = FuncoesNcm.GetNCMPorCodigo(Convert.ToDecimal(produto.Ncm)).IDNCM;
                }
                catch (NullReferenceException)
                {
                }
            }
            var produtoLocal = new ProdutoLocal()
            {
                Descricao = produto.DescricaoUpper,
                EAN = produto.Gtin,
                IDMarca = marca != null ? marca.IDMarca : -1,
                IDCategoria = categoria != null ? categoria.IDCategoria : -1,
                IDNCM = idNcm,
                CEST = produto.Cest,
                ValorVenda = produto.PrecoMedio
            };
            return produtoLocal;
        }

        public static ProdutoLocal GerarProdutoLocal(ProdutoBaseConsulta produto)
        {
            Marca marca = GetOrCreateMarca(produto);
            Categoria categoria = GetOrCreateCategoria(produto);
            decimal idNcm = 23619;
            if (produto.Ncm != null)
            {
                try
                {
                    idNcm = FuncoesNcm.GetNCMPorCodigo(Convert.ToDecimal(produto.Ncm)).IDNCM;
                }
                catch (NullReferenceException)
                {
                }
            }
            var produtoLocal = new ProdutoLocal()
            {
                Descricao = produto.DescricaoUpper,
                EAN = produto.Gtin,
                IDMarca = marca != null ? marca.IDMarca : -1,
                IDCategoria = categoria != null ? categoria.IDCategoria : -1,
                IDNCM = idNcm,
                CEST = produto.Cest,
                ValorVenda = produto.PrecoMedio
            };
            return produtoLocal;
        }

        public static Marca GetOrCreateMarca(ProdutoBaseConsulta produtoSelecionado)
        {
            Marca marca = null;
            if (produtoSelecionado.Marca != null)
            {
                if (FuncoesMarca.Existe(produtoSelecionado.Marca))
                {
                    marca = FuncoesMarca.GetMarca(produtoSelecionado.Marca);
                }
                else
                {
                    marca = new Marca()
                    {
                        IDMarca = PDV.DAO.DB.Utils.Sequence.GetNextID("MARCA", "IDMARCA"),
                        Codigo = ZeusUtil.GetProximoCodigo("MARCA", "CODIGO").ToString(),
                        Descricao = produtoSelecionado.Marca,
                        MarcaDeProduto = true,
                        MarcaDeVeiculo = false
                    };
                    FuncoesMarca.Salvar(marca, PDV.DAO.Enum.TipoOperacao.INSERT);
                }

            }
            return marca;
        }
        public static Categoria GetOrCreateCategoria(ProdutoBaseConsulta produtoSelecionado)
        {
            Categoria categoria = null;
            if (produtoSelecionado.Categoria != null)
            {

                if (FuncoesCategoria.Existe(produtoSelecionado.Categoria))
                {
                    categoria = FuncoesCategoria.GetCategoria(produtoSelecionado.Categoria);
                }
                else
                {
                    categoria = new Categoria()
                    {
                        IDCategoria = Sequence.GetNextID("CATEGORIA", "IDCATEGORIA"),
                        Descricao = produtoSelecionado.Categoria
                    };
                    FuncoesCategoria.Salvar(categoria, PDV.DAO.Enum.TipoOperacao.INSERT);
                }


            }
            return categoria;
        }

        public static Marca GetOrCreateMarca(ProdutoBase produtoSelecionado)
        {
            Marca marca = null;
            if (produtoSelecionado.Marca != null)
            {
                if (FuncoesMarca.Existe(produtoSelecionado.Marca))
                {
                    marca = FuncoesMarca.GetMarca(produtoSelecionado.Marca);
                }
                else
                {
                    marca = new Marca()
                    {
                        IDMarca = PDV.DAO.DB.Utils.Sequence.GetNextID("MARCA", "IDMARCA"),
                        Codigo = ZeusUtil.GetProximoCodigo("MARCA", "CODIGO").ToString(),
                        Descricao = produtoSelecionado.Marca,
                        MarcaDeProduto = true,
                        MarcaDeVeiculo = false
                    };
                    FuncoesMarca.Salvar(marca, PDV.DAO.Enum.TipoOperacao.INSERT);
                }

            }
            return marca;
        }
        public static Categoria GetOrCreateCategoria(ProdutoBase produtoSelecionado)
        {
            Categoria categoria = null;
            if (produtoSelecionado.Categoria != null)
            {

                if (FuncoesCategoria.Existe(produtoSelecionado.Categoria))
                {
                    categoria = FuncoesCategoria.GetCategoria(produtoSelecionado.Categoria);
                }
                else
                {
                    categoria = new Categoria()
                    {
                        IDCategoria = Sequence.GetNextID("CATEGORIA", "IDCATEGORIA"),
                        Descricao = produtoSelecionado.Categoria
                    };
                    FuncoesCategoria.Salvar(categoria, PDV.DAO.Enum.TipoOperacao.INSERT);
                }


            }
            return categoria;
        }
    }
}