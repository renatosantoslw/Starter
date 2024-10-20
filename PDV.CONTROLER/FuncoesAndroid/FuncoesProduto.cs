using System.Collections.Generic;
using PDV.DAO.Entidades;
using PDV.DAO.DB.Controller;
using PDV.DAO.Custom;

namespace PDV.CONTROLER.FuncoesAndroid
{
    public class FuncoesProduto
    {
        public static List<Produto> GetProdutosPorCategoria(decimal IDCategoria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT PRODUTO.IDPRODUTO,
                                    PRODUTO.CODIGO,
                                    PRODUTO.DESCRICAO,
                                    PRODUTO.VALORVENDA,
                                    MARCA.DESCRICAO AS MARCA
                               FROM PRODUTO
                                 LEFT JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                             WHERE (PRODUTO.IDCATEGORIA = @IDCATEGORIA OR -1 = @IDCATEGORIA)
                               ORDER BY PRODUTO.DESCRICAO, PRODUTO.CODIGO";
                oSQL.ParamByName["IDCATEGORIA"] = IDCategoria;
                oSQL.Open();
                return new DataTableParser<Produto>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<Produto> GetProdutosComTributacaoVigente()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT PRODUTO.IDPRODUTO,
                                    PRODUTO.CODIGO,
                                    PRODUTO.DESCRICAO,
                                    MARCA.DESCRICAO AS MARCA,
                                    CATEGORIA.DESCRICAO AS CATEGORIA,
                                    PRODUTO.VALORVENDA
                               FROM PRODUTO
                                 INNER JOIN NCM ON (PRODUTO.IDNCM = NCM.IDNCM
                                                AND CURRENT_DATE BETWEEN NCM.VIGENCIAINICIO AND NCM.VIGENCIAFIM)
                                 INNER JOIN UNIDADEDEMEDIDA ON (PRODUTO.IDUNIDADEDEMEDIDA = UNIDADEDEMEDIDA.IDUNIDADEDEMEDIDA)
                                  LEFT JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                                  LEFT JOIN CATEGORIA ON (PRODUTO.IDCATEGORIA = CATEGORIA.IDCATEGORIA)
                             ORDER BY PRODUTO.DESCRICAO, PRODUTO.CODIGO";
                oSQL.Open();
                return new DataTableParser<Produto>().ParseDataTable(oSQL.dtDados);
            }
        }
    }
}
