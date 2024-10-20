using PDV.DAO.DB.Controller;
using System.Data;

namespace PDV.CONTROLER.FuncoesRelatorios
{
    public class FuncoesProdutosPorFornecedor
    {
        public static DataTable GetProdutosPorFornecedor(decimal IDFornecedor, decimal IDMarca, decimal IDCategoria, decimal IDSubcategoria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT FORNECEDOR.IDFORNECEDOR,
                                    CASE WHEN FORNECEDOR.IDFORNECEDOR IS NULL THEN '<Não Informado>' ELSE FORNECEDOR.CNPJ+' - '+FORNECEDOR.RAZAOSOCIAL END AS FORNECEDOR,
                                    PRODUTO.IDPRODUTO,
                                    PRODUTO.VALORCUSTO AS VALORUNITARIO,
                                    PRODUTO.VALORVENDA,
                                    PRODUTO.CODIGO,
                                    PRODUTO.DESCRICAO AS PRODUTO,
                                    PRODUTO.SALDOESTOQUE AS SALDOESTOQUE,
                                    MARCA.IDMARCA,
                                    MARCA.DESCRICAO AS MARCA,
                                    CATEGORIA.DESCRICAO AS CATEGORIA,
                                    SUBCATEGORIA.IDCATEGORIA AS IDSUBCATEGORIA,
                                    SUBCATEGORIA.DESCRICAO AS SUBCATEGORIA
                               FROM PRODUTO
                                LEFT JOIN PRODUTOFORNECEDOR ON (PRODUTO.IDPRODUTO = PRODUTOFORNECEDOR.IDPRODUTO
                                                             AND PRODUTOFORNECEDOR.IDFORNECEDOR = @IDFORNECEDOR)
                                 LEFT JOIN FORNECEDOR ON (PRODUTOFORNECEDOR.IDFORNECEDOR = FORNECEDOR.IDFORNECEDOR)
                                 LEFT JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                                 LEFT JOIN CATEGORIA ON (PRODUTO.IDCATEGORIA = CATEGORIA.IDCATEGORIA)
                                 LEFT JOIN CATEGORIA SUBCATEGORIA ON (PRODUTO.IDSUBCATEGORIA = SUBCATEGORIA.IDCATEGORIA)
                               WHERE (@IDMARCA = -1 OR MARCA.IDMARCA = @IDMARCA)
                                 AND (@IDCATEGORIA = -1 OR CATEGORIA.IDCATEGORIA = @IDCATEGORIA)
                                 AND (@IDSUBCATEGORIA = -1 OR SUBCATEGORIA.IDCATEGORIA = @IDSUBCATEGORIA)";
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                oSQL.ParamByName["IDMARCA"] = IDMarca;
                oSQL.ParamByName["IDCATEGORIA"] = IDCategoria;
                oSQL.ParamByName["IDSUBCATEGORIA"] = IDSubcategoria;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}
