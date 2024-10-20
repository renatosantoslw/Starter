using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace PDV.CONTROLER.Funcoes
{
    public static class FuncoesProdutoComposicao
    {
        public static List<ProdutoComposicao> GetComposicoesPorComposto(decimal idProdutoComposto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT PC.IDPRODUTOCOMPOSICAO, PC.IDPRODUTO, P.DESCRICAO, PC.IDPRODUTOCOMPOSTO, 
                            PC.QUANTIDADE 
                            FROM PRODUTOCOMPOSICAO AS PC 
                            JOIN PRODUTO AS P ON (P.IDPRODUTO = PC.IDPRODUTO) 
                            WHERE IDPRODUTOCOMPOSTO = @IDPRODUTOCOMPOSTO";
                oSQL.ParamByName["IDPRODUTOCOMPOSTO"] = idProdutoComposto;

                oSQL.Open();

                return new DataTableParser<ProdutoComposicao>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<ProdutoComposicao> GetComposicoesPorProduto(decimal idProduto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT PC.IDPRODUTOCOMPOSICAO, PC.IDPRODUTO, P.DESCRICAO, PC.IDPRODUTOCOMPOSTO, 
                            PC.QUANTIDADE 
                            FROM PRODUTOCOMPOSICAO AS PC 
                            JOIN PRODUTO AS P ON (P.IDPRODUTO = PC.IDPRODUTO) 
                            WHERE PC.IDPRODUTO = @IDPRODUTO";
                oSQL.ParamByName["IDPRODUTO"] = idProduto;

                oSQL.Open();

                return new DataTableParser<ProdutoComposicao>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static ProdutoComposicao GetComposicao(decimal idProdutoComposicao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDPRODUTOCOMPOSICAO,
IDPRODUTO,
IDPRODUTOCOMPOSTO,
QUANTIDADE FROM PRODUTOCOMPOSICAO WHERE IDPRODUTOCOMPOSICAO = @IDPRODUTOCOMPOSICAO";
                oSQL.ParamByName["IDPRODUTOCOMPOSICAO"] = idProdutoComposicao;

                oSQL.Open();

                return new DataTableParser<ProdutoComposicao>().ParseDataTable(oSQL.dtDados).FirstOrDefault();
            }

        }

        public static bool Salvar(ProdutoComposicao produtoComposicao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"INSERT INTO PRODUTOCOMPOSICAO (IDPRODUTOCOMPOSICAO, IDPRODUTO, IDPRODUTOCOMPOSTO, QUANTIDADE) 
                                VALUES
                                (@IDPRODUTOCOMPOSICAO, @IDPRODUTO, @IDPRODUTOCOMPOSTO, @QUANTIDADE)";

                oSQL.ParamByName["IDPRODUTOCOMPOSICAO"] = produtoComposicao.IdProdutoComposicao;
                oSQL.ParamByName["IDPRODUTO"] = produtoComposicao.IdProduto;
                oSQL.ParamByName["IDPRODUTOCOMPOSTO"] = produtoComposicao.IdProdutoComposto;
                oSQL.ParamByName["QUANTIDADE"] = produtoComposicao.Quantidade;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool RemoverPorProdutoComposto(decimal idProdutoComposto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM PRODUTOCOMPOSICAO WHERE IDPRODUTOCOMPOSTO = @IDPRODUTOCOMPOSTO";

                oSQL.ParamByName["IDPRODUTOCOMPOSTO"] = idProdutoComposto;
                return oSQL.ExecSQL() >= 1;
            }
        }

        public static bool RemoverPorProduto(decimal idProduto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM PRODUTO WHERE IDPRODUTO = @IDPRODUTO";

                oSQL.ParamByName["IDPRODUTO"] = idProduto;
                return oSQL.ExecSQL() >= 1;
            }
        }


        public static bool RemoverPorProdutoIteminventario(decimal idProduto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM ITEMINVENTARIO WHERE IDPRODUTO = @IDPRODUTO";

                oSQL.ParamByName["IDPRODUTO"] = idProduto;
                return oSQL.ExecSQL() >= 1;
            }

        }

        public static bool RemoverPorProdutoItemovimentoestoque(decimal idProduto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM MOVIMENTOESTOQUE WHERE IDPRODUTO = @IDPRODUTO";

                oSQL.ParamByName["IDPRODUTO"] = idProduto;
                return oSQL.ExecSQL() >= 1;
            }

        }


    }
}