using System;
using System.Data;
using DevExpress.Xpo;
using IntegradorZeusPDV.App_Context;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.Estoque.InventarioEstoque;
using PDV.DAO.Entidades.Estoque.Movimento;

namespace PDV.UTIL.InventarioUtil
{

    public static class InventarioUtil
    {

        public static void Processar(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
                Processar(dt.Rows[i]);
        }

        public static void Processar(ItemInventario itemInventario)
        {

            if (!FuncoesMovimentoEstoque.Salvar(new MovimentoEstoque
            {
                Descricao = "Processamento de inventário",
                IDMovimentoEstoque = Sequence.GetNextID("MOVIMENTOESTOQUE", "IDMOVIMENTOESTOQUE"),
                IDItemInventario = itemInventario.IDItemInventario,
                IDProduto = itemInventario.IDProduto,
                DataMovimento = DateTime.Now,
                IDAlmoxarifado = itemInventario.IDAlmoxarifado,
                Quantidade = itemInventario.Quantidade,
                IDItemNFeEntrada = null,
                IDItemTransferenciaEstoque = null,
                IDItemVenda = null,
                IDProdutoNFe = null,
                Tipo = 0
            }))
                throw new Exception("Não foi possível salvar o Movimento de Estoque.");
            bool sb = FuncoesProduto.AtualizarSaldoEstoque(
                    Convert.ToDecimal(itemInventario.IDProduto),
                    Convert.ToDecimal(itemInventario.Quantidade)
                );
                
        }

        public static void Processar(DataRow dr)
        {
            
            if (!FuncoesMovimentoEstoque.Salvar(new MovimentoEstoque
            {
                Descricao = "Processamento de inventário",
                IDMovimentoEstoque = Sequence.GetNextID("MOVIMENTOESTOQUE", "IDMOVIMENTOESTOQUE"),
                IDItemInventario = Convert.ToDecimal(dr["IDITEMINVENTARIO"]),
                IDProduto = Convert.ToDecimal(dr["IDPRODUTO"]),
                DataMovimento = DateTime.Now,
                IDAlmoxarifado = Convert.ToDecimal(dr["IDALMOXARIFADO"]),
                Quantidade = Convert.ToDecimal(dr["QUANTIDADE"]),
                IDItemNFeEntrada = null,
                IDItemTransferenciaEstoque = null,
                IDItemVenda = null,
                IDProdutoNFe = null,
                Tipo = 0
            }))
                throw new Exception("Não foi possível salvar o Movimento de Estoque.");
            bool sb = FuncoesProduto.AtualizarSaldoEstoque(
                    Convert.ToDecimal(dr["IDPRODUTO"]),
                    Convert.ToDecimal(dr["QUANTIDADE"])
                );

                      
        }
    }
}