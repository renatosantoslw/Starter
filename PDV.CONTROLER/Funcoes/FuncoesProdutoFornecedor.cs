using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesProdutoFornecedor
    {

        public static bool Salvar(ProdutoFornecedor ProdutoFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "INSERT INTO PRODUTOFORNECEDOR (IDPRODUTOFORNECEDOR, IDPRODUTO, IDFORNECEDOR, CPROD) VALUES (@IDPRODUTOFORNECEDOR, @IDPRODUTO, @IDFORNECEDOR, @CPROD)";
                oSQL.ParamByName["IDPRODUTOFORNECEDOR"] = ProdutoFornecedor.IDProdutoFornecedor;
                oSQL.ParamByName["IDPRODUTO"] = ProdutoFornecedor.IDProduto;
                oSQL.ParamByName["IDFORNECEDOR"] = ProdutoFornecedor.IDFornecedor;
                oSQL.ParamByName["CPROD"] = ProdutoFornecedor.CProd;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Existe(decimal IDProdutoFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PRODUTOFORNECEDOR WHERE IDPRODUTOFORNECEDOR = @IDPRODUTOFORNECEDOR";
                oSQL.ParamByName["IDPRODUTOFORNECEDOR"] = IDProdutoFornecedor;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool Remover(decimal IDProdutoFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PRODUTOFORNECEDOR WHERE IDPRODUTOFORNECEDOR = @IDPRODUTOFORNECEDOR";
                oSQL.ParamByName["IDPRODUTOFORNECEDOR"] = IDProdutoFornecedor;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return true;

                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM PRODUTOFORNECEDOR WHERE IDPRODUTOFORNECEDOR = @IDPRODUTOFORNECEDOR";
                oSQL.ParamByName["IDPRODUTOFORNECEDOR"] = IDProdutoFornecedor;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static ProdutoFornecedor GetProdutoFornecedor(decimal IDProdutoFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDPRODUTOFORNECEDOR,
IDFORNECEDOR,
IDPRODUTO,
CPROD FROM PRODUTOFORNECEDOR WHERE IDPRODUTOFORNECEDOR = @IDPRODUTOFORNECEDOR";
                oSQL.ParamByName["IDPRODUTOFORNECEDOR"] = IDProdutoFornecedor;
                oSQL.Open();

                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<ProdutoFornecedor>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetCodigosPorProduto(decimal IDProduto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT FORNECEDOR.RAZAOSOCIAL AS FORNECEDOR,
                                    FORNECEDOR.CNPJ,
                                    PRODUTOFORNECEDOR.CPROD,
                             
                                    PRODUTOFORNECEDOR.IDPRODUTOFORNECEDOR,
                                    PRODUTOFORNECEDOR.IDPRODUTO
                               FROM PRODUTOFORNECEDOR
                             INNER JOIN FORNECEDOR ON (PRODUTOFORNECEDOR.IDFORNECEDOR = FORNECEDOR.IDFORNECEDOR)
                             WHERE PRODUTOFORNECEDOR.IDPRODUTO = @IDPRODUTO";
                oSQL.ParamByName["IDPRODUTO"] = IDProduto;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetProdutoPorCodigoEProduto(decimal IDProduto, decimal IDFornecedor, string CProd)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT FORNECEDOR.RAZAOSOCIAL AS FORNECEDOR,
                                    FORNECEDOR.CNPJ,
                                    PRODUTOFORNECEDOR.CPROD,
                             
                                    PRODUTOFORNECEDOR.IDPRODUTOFORNECEDOR,
                                    PRODUTOFORNECEDOR.IDPRODUTO
                               FROM PRODUTOFORNECEDOR
                             INNER JOIN FORNECEDOR ON (PRODUTOFORNECEDOR.IDFORNECEDOR = FORNECEDOR.IDFORNECEDOR)
                             WHERE PRODUTOFORNECEDOR.IDPRODUTO = @IDPRODUTO
                               AND PRODUTOFORNECEDOR.CPROD = @CPROD
                               AND PRODUTOFORNECEDOR.IDFORNECEDOR = @IDFORNECEDOR";
                oSQL.ParamByName["IDPRODUTO"] = IDProduto;
                oSQL.ParamByName["CPROD"] = CProd;
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}