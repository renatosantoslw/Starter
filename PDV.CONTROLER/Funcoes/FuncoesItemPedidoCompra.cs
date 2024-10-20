using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Estoque.PedidoDeCompra;
using PDV.DAO.Enum;
using PDV.DAO.GridViewModels;
using PDV.DAO.QueryModels;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesItemPedidoCompra
    {
        public static bool RemoverItensPedidoCompra(List<ItemPedidoCompra> ItensPedidoCompra, decimal IDPedidoCompra)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                //List<ItemPedidoCompra> ItensExistentePedidoCompra = GetItensPedidoCompra(IDPedidoCompra);
                //foreach (ItemPedidoCompra Item in ItensPedidoCompra)
                //{
                //    if (ItensExistentePedidoCompra.Where(o => o.IDItemPedidoCompra == Item.IDItemPedidoCompra).FirstOrDefault() == null)
                //    {
                //        if (!Remover(Item.IDItemPedidoCompra))
                //            //throw new Exception("Não é possível remover os Itens da Compra.");
                //            ;
                //    }
                //}


                oSQL.SQL = "DELETE FROM ITEMPEDIDOCOMPRA WHERE IDPEDIDOCOMPRA = @IDITEMPEDIDOCOMPRA";
                oSQL.ParamByName["IDITEMPEDIDOCOMPRA"] = IDPedidoCompra;
                return oSQL.ExecSQL() >= 0;
            }
        }
        public static bool Salvar(ItemPedidoCompra ItemPedidoCompra, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch(Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO ITEMPEDIDOCOMPRA 
                                        (IDITEMPEDIDOCOMPRA, IDPEDIDOCOMPRA, IDPRODUTO, IDUSUARIO, QUANTIDADE, VALORUNITARIO, DESCONTOPORCENTAGEM, DESCONTO, TOTAL, DESCRICAO) 
                                      VALUES 
                                        (@IDITEMPEDIDOCOMPRA, @IDPEDIDOCOMPRA, @IDPRODUTO, @IDUSUARIO, @QUANTIDADE, @VALORUNITARIO, @DESCONTO, @DESCONTOPORCENTAGEM, @TOTAL, @DESCRICAO)";
                        oSQL.ParamByName["IDPEDIDOCOMPRA"] = ItemPedidoCompra.IDPedidoCompra;
                        oSQL.ParamByName["IDPRODUTO"] = ItemPedidoCompra.IDProduto;
                        oSQL.ParamByName["IDUSUARIO"] = ItemPedidoCompra.IDUsuario;
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE ITEMPEDIDOCOMPRA 
                                       SET QUANTIDADE = @QUANTIDADE,
                                           VALORUNITARIO = @VALORUNITARIO,
                                           DESCONTO = @DESCONTO,
                                           DESCONTOPORCENTAGEM = @DESCONTOPORCENTAGEM,
                                           TOTAL = @TOTAL,
                                           DESCRICAO = @DESCRICAO
                                     WHERE IDITEMPEDIDOCOMPRA = @IDITEMPEDIDOCOMPRA";
                        break;
                }
                oSQL.ParamByName["IDITEMPEDIDOCOMPRA"] = ItemPedidoCompra.IDItemPedidoCompra;
                oSQL.ParamByName["QUANTIDADE"] = ItemPedidoCompra.Quantidade;
                oSQL.ParamByName["VALORUNITARIO"] = ItemPedidoCompra.ValorUnitario;
                oSQL.ParamByName["DESCONTO"] = ItemPedidoCompra.DescontoValor;
                oSQL.ParamByName["DESCONTOPORCENTAGEM"] = ItemPedidoCompra.DescontoPorcentagem;
                oSQL.ParamByName["TOTAL"] = ItemPedidoCompra.Total;
                oSQL.ParamByName["DESCRICAO"] = ItemPedidoCompra.Descricao;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static List<MovimentoDeEstoquePorCompraGridViewModel> GetMovimentoPorCompra(MovimentoDeEstoquePorCompraQueryModel pesquisa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 
	                            PEDIDOCOMPRA.IDPEDIDOCOMPRA AS IDPEDIDOCOMPRA,
                                PRODUTO.EAN,
	                            UPPER(PRODUTO.DESCRICAO) AS PRODUTO,	
	                            PEDIDOCOMPRA.DATAFATURAMENTO AS DATAFATURAMENTO,
	                            UPPER(TIPODEOPERACAO.NOME) AS OPERACAO,
	                            UPPER(MARCA.DESCRICAO) AS GRUPO,
	                            ITEMPEDIDOCOMPRA.QUANTIDADE AS QUANTIDADE	
                            FROM ITEMPEDIDOCOMPRA
                            JOIN PEDIDOCOMPRA ON  (ITEMPEDIDOCOMPRA.IDPEDIDOCOMPRA = PEDIDOCOMPRA.IDPEDIDOCOMPRA)
                            JOIN PRODUTO ON (ITEMPEDIDOCOMPRA.IDPRODUTO = PRODUTO.IDPRODUTO)
                            JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                            JOIN TIPODEOPERACAO ON (PEDIDOCOMPRA.IDTIPODEOPERACAO = TIPODEOPERACAO.IDTIPODEOPERACAO)
                            WHERE TIPODEOPERACAO.TIPODEMOVIMENTO = @TIPODEMOVIMENTO
                            AND PEDIDOCOMPRA.STATUS = @FATURADO
                            AND (PEDIDOCOMPRA.DATAFATURAMENTO BETWEEN @DATADE AND @DATAATE)
                            AND (UPPER(PRODUTO.DESCRICAO) LIKE @PESQUISA OR PRODUTO.EAN LIKE @PESQUISA)
                            ORDER BY DATAFATURAMENTO DESC";
                oSQL.ParamByName["DATADE"] = pesquisa.DataDe;
                oSQL.ParamByName["DATAATE"] = pesquisa.DataAte;
                oSQL.ParamByName["PESQUISA"] = $"%{pesquisa.Pesquisa}%".ToUpper();
                oSQL.ParamByName["TIPODEMOVIMENTO"] = TipoDeOperacao.Entrada;
                oSQL.ParamByName["FATURADO"] = StatusPedido.Faturado;
                oSQL.Open();
                return new DataTableParser<MovimentoDeEstoquePorCompraGridViewModel>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool SalvarItemPedidoCompra(ItemPedidoCompra Item)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                if (ExisteItem(Item.IDItemPedidoCompra))
                    return true;

                oSQL.SQL = @"INSERT INTO ITEMPEDIDOCOMPRA(
                                         IDITEMPEDIDOCOMPRA, IDPRODUTO, IDPEDIDOCOMPRA, QUANTIDADE, DESCONTOPORCENTAGEM, DESCONTO, VALORUNITARIO, IDUSUARIO, DESCRICAO, TOTAL)
                                 VALUES (@IDITEMPEDIDOCOMPRA, @IDPRODUTO, @IDPEDIDOCOMPRA, @QUANTIDADE, @DESCONTOPORCENTAGEM, @DESCONTO, @VALORUNITARIO, @IDUSUARIO, @DESCRICAO, @TOTAL)";
                oSQL.ParamByName["IDITEMPEDIDOCOMPRA"] = Item.IDItemPedidoCompra;
                oSQL.ParamByName["IDPRODUTO"] = Item.IDProduto;
                oSQL.ParamByName["IDPEDIDOCOMPRA"] = Item.IDPedidoCompra;
                oSQL.ParamByName["QUANTIDADE"] = Item.Quantidade;
                oSQL.ParamByName["DESCONTOPORCENTAGEM"] = Item.DescontoPorcentagem;
                oSQL.ParamByName["DESCONTO"] = Item.DescontoValor;
                oSQL.ParamByName["VALORUNITARIO"] = Item.ValorUnitario;
                oSQL.ParamByName["IDUSUARIO"] = Item.IDUsuario;
                oSQL.ParamByName["DESCRICAO"] = Item.DescricaoItem;
                oSQL.ParamByName["TOTAL"] = Item.Total;
                return oSQL.ExecSQL() == 1;
            }
        }

        private static bool ExisteItem(object IDItemPedidoCompra)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM ITEMPEDIDOCOMPRA WHERE IDITEMPEDIDOCOMPRA = @IDITEMPEDIDOCOMPRA";
                oSQL.ParamByName["IDITEMPEDIDOCOMPRA"] = IDItemPedidoCompra;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool Remover(decimal IDItemPedidoCompra)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM ITEMPEDIDOCOMPRA WHERE IDITEMPEDIDOCOMPRA = @IDITEMPEDIDOCOMPRA";
                oSQL.ParamByName["IDITEMPEDIDOCOMPRA"] = IDItemPedidoCompra;
                return oSQL.ExecSQL() == 1;
            }
        }
        public static DataTable GetTop10Compras(DateTime dataDe, DateTime dataAte, decimal idOperacao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT  TOP 10 UPPER(FRN.RAZAOSOCIAL) AS DESCRICAO, SUM(PC.TOTAL) AS VALOR
                            FROM FORNECEDOR FRN 
                            JOIN PEDIDOCOMPRA PC ON PC.IDFORNECEDOR = FRN.IDFORNECEDOR
                            WHERE PC.STATUS = 1 
                            AND (PC.DATAEMISSAO BETWEEN @DATADE AND @DATAATE)
                            AND PC.IDTIPODEOPERACAO = @IDOPERACAO
                            GROUP BY FRN.RAZAOSOCIAL
                            ORDER BY SUM(PC.TOTAL) DESC
                            /*LIMIT 10*/
                            ";

                oSQL.ParamByName["DATADE"] = dataDe;
                oSQL.ParamByName["DATAATE"] = dataAte;
                oSQL.ParamByName["IDOPERACAO"] = idOperacao;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static ItemPedidoCompra GetItemPedidoCompra(decimal IDItemPedidoCompra)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDITEMPEDIDOCOMPRA,
IDPEDIDOCOMPRA,
IDPRODUTO,
QUANTIDADE,
VALORUNITARIO,
DESCONTO,
TOTAL,
DESCONTOPORCENTAGEM,
IDUSUARIO,
DESCRICAO FROM ITEMPEDIDOCOMPRA WHERE IDITEMPEDIDOCOMPRA = @IDITEMPEDIDOCOMPRA";
                oSQL.ParamByName["IDITEMPEDIDOCOMPRA"] = IDItemPedidoCompra;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<ItemPedidoCompra>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static List<ItemPedidoCompra> GetItensPedidoCompra(decimal IDPedidoCompra)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDPEDIDOCOMPRA, 
                                    IDITEMPEDIDOCOMPRA,
                                    PRODUTO.DESCRICAO AS DESCRICAOITEM,
                                    DESCONTO,
                                    VALORUNITARIO,
                                    (VALORUNITARIO - DESCONTO)* QUANTIDADE AS VALORTOTALITEM,
                                    PRODUTO.IDPRODUTO, 
                                    PRODUTO.CODIGO AS CODIGOITEM,
                                    ITEMPEDIDOCOMPRA.QUANTIDADE AS QUANTIDADE, 
                                    DESCONTOPORCENTAGEM,                          

                                    
                                    ITEMPEDIDOCOMPRA.IDUSUARIO
                               FROM ITEMPEDIDOCOMPRA
                                INNER JOIN PRODUTO ON ITEMPEDIDOCOMPRA.IDPRODUTO = PRODUTO.IDPRODUTO
                              WHERE IDPEDIDOCOMPRA = @IDPEDIDOCOMPRA";
                oSQL.ParamByName["IDPEDIDOCOMPRA"] = IDPedidoCompra;
                oSQL.Open();
                return new DataTableParser<ItemPedidoCompra>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static DataTable GetItensPorPedido(decimal IDPedidoCompra)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT PRODUTO.DESCRICAO AS PRODUTO,
                                    ITEMPEDIDOCOMPRA.QUANTIDADE,
                                    ITEMPEDIDOCOMPRA.VALORUNITARIO,
                                    ITEMPEDIDOCOMPRA.DESCONTO,
                                    ITEMPEDIDOCOMPRA.TOTAL,
                                    PRODUTO.CODIGO,
                                    PRODUTO.EAN,
                                    UNIDADEDEMEDIDA.DESCRICAO+' ('+UNIDADEDEMEDIDA.SIGLA+')' AS UNIDADEMEDIDA,
                                    COALESCE(MARCA.DESCRICAO, '<Não Informado>') AS MARCA,
                                    COALESCE(CATEGORIA.DESCRICAO, '<Não Informado>') AS CATEGORIA,
                                    ITEMPEDIDOCOMPRA.IDITEMPEDIDOCOMPRA,
                                    ITEMPEDIDOCOMPRA.IDPEDIDOCOMPRA,
                                    ITEMPEDIDOCOMPRA.IDPRODUTO
                               FROM ITEMPEDIDOCOMPRA
                                 INNER JOIN PRODUTO ON (ITEMPEDIDOCOMPRA.IDPRODUTO = PRODUTO.IDPRODUTO)
                                 LEFT JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                                  LEFT JOIN CATEGORIA ON (PRODUTO.IDCATEGORIA = CATEGORIA.IDCATEGORIA)
                                  LEFT JOIN UNIDADEDEMEDIDA ON (PRODUTO.IDUNIDADEDEMEDIDA = UNIDADEDEMEDIDA.IDUNIDADEDEMEDIDA)
                             WHERE ITEMPEDIDOCOMPRA.IDPEDIDOCOMPRA = @IDPEDIDOCOMPRA";
                oSQL.ParamByName["IDPEDIDOCOMPRA"] = IDPedidoCompra;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetProdutosParaPedidoDeCompra()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT PRODUTO.IDPRODUTO,
                                    PRODUTO.CODIGO,
                                    PRODUTO.EAN,
                                    PRODUTO.DESCRICAO AS PRODUTO,       
                                    UNIDADEDEMEDIDA.DESCRICAO+' ('+UNIDADEDEMEDIDA.SIGLA+')' AS UNIDADEMEDIDA,
                                    COALESCE(MARCA.DESCRICAO, '<Não Informado>') AS MARCA,
                                    COALESCE(CATEGORIA.DESCRICAO, '<Não Informado>') AS CATEGORIA,
                             
                                    PRODUTO.VALORCUSTO AS VALORUNITARIO,
                                    CAST(0 AS NUMERIC(15,4)) AS QUANTIDADE,
                                    CAST(0 AS NUMERIC(15,2)) AS DESCONTO,
                                    CAST(0 AS NUMERIC(15,2)) AS TOTAL
                               FROM PRODUTO
                                  LEFT JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                                  LEFT JOIN CATEGORIA ON (PRODUTO.IDCATEGORIA = CATEGORIA.IDCATEGORIA)
                                  LEFT JOIN UNIDADEDEMEDIDA ON (PRODUTO.IDUNIDADEDEMEDIDA = UNIDADEDEMEDIDA.IDUNIDADEDEMEDIDA)
                               AND PRODUTO.ATIVO = 1
                             ORDER BY PRODUTO.DESCRICAO";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}
