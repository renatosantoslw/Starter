using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Estoque.Movimento;
using PDV.DAO.Enum;
using PDV.DAO.GridViewModels;
using PDV.DAO.QueryModels;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesMovimentoEstoque
    {
        public static bool Salvar(MovimentoEstoque Movimento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"INSERT INTO MOVIMENTOESTOQUE(
                                     IDMOVIMENTOESTOQUE, IDPRODUTO, TIPO, IDITEMNFEENTRADA, IDITEMVENDA, 
                                     IDPRODUTONFE, IDITEMINVENTARIO, IDALMOXARIFADO, 
                                     IDITEMTRANSFERENCIAESTOQUE, QUANTIDADE, DATAMOVIMENTO, SALDOATUAL, IDITEMPEDIDOCOMPRA,
                                     DESCRICAO)
                             VALUES (@IDMOVIMENTOESTOQUE, @IDPRODUTO, @TIPO, @IDITEMNFEENTRADA, @IDITEMVENDA, 
                                     @IDPRODUTONFE, @IDITEMINVENTARIO, @IDALMOXARIFADO, 
                                     @IDITEMTRANSFERENCIAESTOQUE, @QUANTIDADE, @DATAMOVIMENTO, @SALDOATUAL, @IDITEMPEDIDOCOMPRA,
                                     @DESCRICAO)";
                oSQL.ParamByName["IDMOVIMENTOESTOQUE"] = Movimento.IDMovimentoEstoque;
                oSQL.ParamByName["IDPRODUTO"] = Movimento.IDProduto;
                oSQL.ParamByName["TIPO"] = Movimento.Tipo;
                oSQL.ParamByName["IDITEMNFEENTRADA"] = Movimento.IDItemNFeEntrada;
                oSQL.ParamByName["IDITEMVENDA"] = Movimento.IDItemVenda;
                oSQL.ParamByName["IDPRODUTONFE"] = Movimento.IDProdutoNFe;
                oSQL.ParamByName["IDITEMINVENTARIO"] = Movimento.IDItemInventario;
                oSQL.ParamByName["IDALMOXARIFADO"] = Movimento.IDAlmoxarifado;
                oSQL.ParamByName["IDITEMTRANSFERENCIAESTOQUE"] = Movimento.IDItemTransferenciaEstoque;
                oSQL.ParamByName["QUANTIDADE"] = Movimento.Quantidade;
                oSQL.ParamByName["DATAMOVIMENTO"] = Movimento.DataMovimento;
                oSQL.ParamByName["SALDOATUAL"] = Movimento.SaldoAtual;
                oSQL.ParamByName["IDITEMPEDIDOCOMPRA"] = Movimento.IDItemPedidoCompra;
                oSQL.ParamByName["DESCRICAO"] = Movimento.Descricao;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static List<MovimentoDeEstoquePorProdutoGridViewModel> GetMovimentoVendaPorProduto(MovimentoDeEstoquePorProdutoQueryModel pesquisa)
        {

            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @" SELECT 
 	                            IDPRODUTO,
	                            CDEBARRAS,
                                GRUPO,
	                            PRODUTO,
	                            ESTOQUE,
	                            SUM(ENTRADA) AS ENTRADA,
	                            SUM(SAIDA)  AS SAIDA,
	                            VALORCUSTO,
	                            VALORVENDA,
	                            SUM(TOTAL) AS TOTAL FROM
                                        (SELECT
	                                        P.IDPRODUTO,
	                                        P.DESCRICAO AS PRODUTO,
	                                        P.EAN AS CDEBARRAS,
	                                        P.SALDOESTOQUE AS ESTOQUE,
                                            M.DESCRICAO AS GRUPO,
	                                        0 AS ENTRADA,
	                                        SUM(IV.QUANTIDADE) AS SAIDA,
  	                                        P.VALORCUSTO AS VALORCUSTO,
  	                                        P.VALORVENDA AS VALORVENDA,
  	                                        SUM(IV.QUANTIDADE) * P.VALORVENDA AS TOTAL
	                                        FROM PRODUTO P
                                            JOIN MARCA M ON M.IDMARCA = P.IDMARCA
	                                        JOIN ITEMVENDA IV ON IV.IDPRODUTO = P.IDPRODUTO
	                                        JOIN VENDA V ON V.IDVENDA = IV.IDVENDA
	                                        WHERE (V.DATAFATURAMENTO BETWEEN @DATADE AND @DATAATE)
	                                        AND (V.STATUS = @FATURADO)
	                                        GROUP BY P.IDPRODUTO, P.DESCRICAO, M.DESCRICAO
	                                    UNION
                                        SELECT
	                                        P.IDPRODUTO,
	                                        P.DESCRICAO AS PRODUTO,
  	                                        P.EAN AS CDEBARRAS,
  	                                        P.SALDOESTOQUE AS ESTOQUE,
                                            M.DESCRICAO AS GRUPO,               
	                                        SUM(IP.QUANTIDADE) AS ENTRADA,
	                                        0 AS SAIDA,
  	                                        P.VALORCUSTO AS VALORCUSTO,
  	                                        P.VALORVENDA AS VALORVENDA,
  	                                        0 AS TOTAL
	                                        FROM PRODUTO P
                                            JOIN MARCA M ON M.IDMARCA = P.IDMARCA
	                                        JOIN ITEMPEDIDOCOMPRA IP ON IP.IDPRODUTO = P.IDPRODUTO
	                                        JOIN PEDIDOCOMPRA C ON C.IDPEDIDOCOMPRA = IP.IDPEDIDOCOMPRA
	                                        WHERE (C.DATAFATURAMENTO BETWEEN @DATADE AND @DATAATE)
	                                        AND (C.STATUS = @FATURADO)
	                                        GROUP BY P.IDPRODUTO, P.DESCRICAO, M.DESCRICAO)
                                        TU
                            WHERE TU.PRODUTO LIKE UPPER(@PESQUISA) OR TU.CDEBARRAS LIKE (@PESQUISA)
                            GROUP BY TU.IDPRODUTO,
                            TU.CDEBARRAS,
                            TU.GRUPO,
                            TU.PRODUTO,
                            TU.ESTOQUE,
                            TU.VALORCUSTO,
                            TU.VALORVENDA
                            ORDER BY TU.PRODUTO";
                oSQL.ParamByName["DATADE"] = pesquisa.DataDe.Date;
                oSQL.ParamByName["DATAATE"] = pesquisa.DataAte.Date;
                oSQL.ParamByName["PESQUISA"] = $"%{pesquisa.Pesquisa}%".ToUpper();
                oSQL.ParamByName["FATURADO"] = StatusPedido.Faturado;
                oSQL.Open();
                return new DataTableParser<MovimentoDeEstoquePorProdutoGridViewModel>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<MovimentoDeEstoquePorProdutoGridViewModel> GetMovimentoCompraPorProduto(MovimentoDeEstoquePorProdutoQueryModel pesquisa)
        {

            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT
                                PRODUTO.IDPRODUTO,
                                PRODUTO.EAN AS CDEBARRAS,
                                PRODUTO.SALDOESTOQUE AS ESTOQUE,
                                PRODUTO.DESCRICAO AS PRODUTO,
                                MARCA.DESCRICAO AS GRUPO,
                                PRODUTO.VALORCUSTO,
                                PRODUTO.VALORVENDA,
                                SUM(ITEMPEDIDOCOMPRA.QUANTIDADE) AS ENTRADA,
                                SUM(ITEMPEDIDOCOMPRA.QUANTIDADE) * PRODUTO.VALORCUSTO AS TOTAL
                                FROM PRODUTO
                                JOIN MARCA ON PRODUTO.IDMARCA = MARCA.IDMARCA
                                JOIN ITEMPEDIDOCOMPRA ON ITEMPEDIDOCOMPRA.IDPRODUTO = PRODUTO.IDPRODUTO
                                JOIN PEDIDOCOMPRA ON ITEMPEDIDOCOMPRA.IDPEDIDOCOMPRA = PEDIDOCOMPRA.IDPEDIDOCOMPRA
                            WHERE PEDIDOCOMPRA.STATUS = @FATURADO
                            AND (PEDIDOCOMPRA.DATAFATURAMENTO BETWEEN @DATADE AND @DATAATE)
                            AND (UPPER(PRODUTO.DESCRICAO) LIKE @PESQUISA OR PRODUTO.EAN LIKE @PESQUISA)
                            GROUP BY 
                                PRODUTO.IDPRODUTO,
                                PRODUTO.EAN,
                                PRODUTO.DESCRICAO,
                                PRODUTO.SALDOESTOQUE,
                                MARCA.DESCRICAO,
                                PRODUTO.VALORCUSTO,
                                PRODUTO.VALORVENDA
                            ORDER BY PRODUTO.DESCRICAO";
                oSQL.ParamByName["DATADE"] = pesquisa.DataDe;
                oSQL.ParamByName["DATAATE"] = pesquisa.DataAte;
                oSQL.ParamByName["PESQUISA"] = $"%{pesquisa.Pesquisa}%".ToUpper();
                oSQL.ParamByName["FATURADO"] = StatusPedido.Faturado;
                oSQL.Open();
                return new DataTableParser<MovimentoDeEstoquePorProdutoGridViewModel>().ParseDataTable(oSQL.dtDados);
            }
        }
        public static bool ExcluirMovimentoPorProduto(decimal idProduto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM MOVIMENTOESTOQUE WHERE IDPRODUTO = @IDPRODUTO";

                oSQL.ParamByName["IDPRODUTO"] = idProduto;


                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool ExcluirMovimentoPorItemVenda(decimal idItem)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM MOVIMENTOESTOQUE WHERE IDITEMVENDA = @IDITEMVENDA";

                oSQL.ParamByName["IDITEMVENDA"] = idItem;

                return oSQL.ExecSQL() >= 1;
            }
        }

        public static DataTable GetMovimentosEstoque()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT
                             COALESCE(ITEMVENDA.DESCRICAO,ITEMPEDIDOCOMPRA.DESCRICAO) AS PRODUTO,
                             MOVIMENTOESTOQUE.DATAMOVIMENTO, 
                             MOVIMENTOESTOQUE.IDMOVIMENTOESTOQUE,
                             MOVIMENTOESTOQUE.DESCRICAO,                             
		                     CASE 
		                     	WHEN MOVIMENTOESTOQUE.IDITEMVENDA IS NOT NULL THEN ITEMVENDA.IDVENDA
		                     	WHEN MOVIMENTOESTOQUE.IDITEMPEDIDOCOMPRA IS NOT NULL THEN ITEMPEDIDOCOMPRA.IDPEDIDOCOMPRA
		                     END AS IDPEDIDO,		                     
		                     CASE 
		                     	WHEN MOVIMENTOESTOQUE.TIPO = 0 THEN 'ENTRADA' 
		                     	WHEN MOVIMENTOESTOQUE.TIPO = 1 THEN 'SAÍDA' 
		                     END AS TIPO, 
		                     MOVIMENTOESTOQUE.QUANTIDADE,
                             ALMOXARIFADO.DESCRICAO
      	                     FROM MOVIMENTOESTOQUE
		                     LEFT OUTER JOIN ITEMVENDA ON (ITEMVENDA.IDITEMVENDA = MOVIMENTOESTOQUE.IDITEMVENDA)
		                     LEFT OUTER JOIN ITEMPEDIDOCOMPRA ON (ITEMPEDIDOCOMPRA.IDITEMPEDIDOCOMPRA = MOVIMENTOESTOQUE.IDITEMPEDIDOCOMPRA)		                     
                             LEFT OUTER JOIN ALMOXARIFADO ON(ALMOXARIFADO.IDALMOXARIFADO =  MOVIMENTOESTOQUE.IDALMOXARIFADO)
                              WHERE 
                             (MOVIMENTOESTOQUE.IDITEMVENDA IS NOT NULL OR 
		                     MOVIMENTOESTOQUE.IDITEMPEDIDOCOMPRA IS NOT NULL)
                             ORDER BY PRODUTO";

                oSQL.Open();
                if (oSQL.dtDados.Rows.Count == 0)
                {
                    return null;
                }
                return oSQL.dtDados;
            }
        }
        public static DataTable GetMovimentosEstoque(string produtoDescricaoOuEan, DateTime date1 , DateTime date2, decimal idProduto = -1)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT
                             COALESCE(ITEMVENDA.DESCRICAO,ITEMPEDIDOCOMPRA.DESCRICAO) AS PRODUTO,
                             MOVIMENTOESTOQUE.DATAMOVIMENTO, 
                             MOVIMENTOESTOQUE.IDMOVIMENTOESTOQUE,
                             MOVIMENTOESTOQUE.DESCRICAO,                             
		                     CASE 
		                     	WHEN MOVIMENTOESTOQUE.IDITEMVENDA IS NOT NULL THEN ITEMVENDA.IDVENDA
		                     	WHEN MOVIMENTOESTOQUE.IDITEMPEDIDOCOMPRA IS NOT NULL THEN ITEMPEDIDOCOMPRA.IDPEDIDOCOMPRA
		                     END AS IDPEDIDO,
                             MARCA.DESCRICAO AS GRUPO,
		                     CASE 
		                     	WHEN MOVIMENTOESTOQUE.TIPO = 0 THEN 'ENTRADA' 
		                     	WHEN MOVIMENTOESTOQUE.TIPO = 1 THEN 'SAÍDA' 
		                     END AS TIPO, 
		                     MOVIMENTOESTOQUE.QUANTIDADE
      	                     FROM MOVIMENTOESTOQUE
		                     LEFT OUTER JOIN ITEMVENDA ON (ITEMVENDA.IDITEMVENDA = MOVIMENTOESTOQUE.IDITEMVENDA)                             
		                     LEFT OUTER JOIN ITEMPEDIDOCOMPRA ON (ITEMPEDIDOCOMPRA.IDITEMPEDIDOCOMPRA = MOVIMENTOESTOQUE.IDITEMPEDIDOCOMPRA)
                             LEFT OUTER JOIN PRODUTO ON (COALESCE(ITEMVENDA.IDPRODUTO, ITEMPEDIDOCOMPRA.IDPRODUTO) = PRODUTO.IDPRODUTO)
                             LEFT JOIN MARCA ON (MARCA.IDMARCA = PRODUTO.IDMARCA)

                             WHERE 
                             (MOVIMENTOESTOQUE.IDITEMVENDA IS NOT NULL OR 
		                     MOVIMENTOESTOQUE.IDITEMPEDIDOCOMPRA IS NOT NULL) 
                            AND (PRODUTO.IDPRODUTO = {idProduto} OR 
                            
                            PRODUTO.EAN LIKE ('%{produtoDescricaoOuEan}%') OR 
                            UPPER(PRODUTO.DESCRICAO) LIKE('%{produtoDescricaoOuEan.ToUpper()}%'))
                            AND   MOVIMENTOESTOQUE.DATAMOVIMENTO BETWEEN @DATE1 AND @DATE2 
                            ORDER BY PRODUTO.DESCRICAO";
                oSQL.ParamByName["DATE1"] = date1.Date;
                oSQL.ParamByName["DATE2"] = date2.Date;
                oSQL.Open();
                if (oSQL.dtDados.Rows.Count == 0)
                {
                    return null;
                }
                return oSQL.dtDados;
            }
        }
        public static MovimentoEstoque GetMovimentoEstoque(decimal idMovimentoEstoque)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDMOVIMENTOESTOQUE,
IDPRODUTO,
TIPO,
IDITEMNFEENTRADA,
IDITEMVENDA,
IDPRODUTONFE,
IDITEMINVENTARIO,
IDALMOXARIFADO,
IDITEMTRANSFERENCIAESTOQUE,
QUANTIDADE,
DATAMOVIMENTO,
SALDOATUAL,
SALDOALMOXARIFADO,
IDITEMPEDIDOCOMPRA,
DESCRICAO FROM MOVIMENTOESTOQUE
                             WHERE IDMOVIMENTOESTOQUE = @IDMOVIMENTOESTOQUE";
                oSQL.ParamByName["IDMOVIMENTOESTOQUE"] = idMovimentoEstoque;
                oSQL.Open();
                if (oSQL.dtDados.Rows.Count == 0)
                {
                    return null;
                }
                return EntityUtil<MovimentoEstoque>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static DataTable GetMovimentoEstoquePorIdProduto(decimal idProduto)
        {

            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT
                             COALESCE(ITEMVENDA.DESCRICAO,ITEMPEDIDOCOMPRA.DESCRICAO) AS PRODUTO,
                             MOVIMENTOESTOQUE.IDMOVIMENTOESTOQUE,
                             MOVIMENTOESTOQUE.DESCRICAO,
		                     CASE 
		                     	WHEN MOVIMENTOESTOQUE.IDITEMVENDA IS NOT NULL THEN ITEMVENDA.IDVENDA
		                     	WHEN MOVIMENTOESTOQUE.IDITEMPEDIDOCOMPRA IS NOT NULL THEN ITEMPEDIDOCOMPRA.IDPEDIDOCOMPRA
		                     END AS IDPEDIDO,
		                     MOVIMENTOESTOQUE.DATAMOVIMENTO,  
		                     CASE 
		                     	WHEN MOVIMENTOESTOQUE.TIPO = 0 THEN 'ENTRADA' 
		                     	WHEN MOVIMENTOESTOQUE.TIPO = 1 THEN 'SAÍDA' 
		                     END AS TIPO, 
		                     MOVIMENTOESTOQUE.QUANTIDADE,
                             ALMOXARIFADO.DESCRICAO
      	                     FROM MOVIMENTOESTOQUE
		                     LEFT OUTER JOIN ITEMVENDA ON (ITEMVENDA.IDITEMVENDA = MOVIMENTOESTOQUE.IDITEMVENDA)
		                     LEFT OUTER JOIN ITEMPEDIDOCOMPRA ON (ITEMPEDIDOCOMPRA.IDITEMPEDIDOCOMPRA = MOVIMENTOESTOQUE.IDITEMPEDIDOCOMPRA)		                     
                             LEFT OUTER JOIN ALMOXARIFADO ON(ALMOXARIFADO.IDALMOXARIFADO =  MOVIMENTOESTOQUE.IDALMOXARIFADO)
                              WHERE 
                             --(MOVIMENTOESTOQUE.IDITEMVENDA IS NOT NULL OR 
		                     --MOVIMENTOESTOQUE.IDITEMPEDIDOCOMPRA IS NOT NULL) AND
                             MOVIMENTOESTOQUE.IDPRODUTO = @IDPRODUTO ORDER BY MOVIMENTOESTOQUE.IDMOVIMENTOESTOQUE DESC";
                             
                
                oSQL.ParamByName["IDPRODUTO"] = idProduto;

                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}
