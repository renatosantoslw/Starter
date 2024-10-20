using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.NFe;
using PDV.DAO.Enum;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesProdutoNFe
    {
        public static DataTable GetProdutos(decimal IDNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"WITH VALORICMSPRODUTO AS (
                                SELECT IDPRODUTONFE,
                                       SUM(VICMSST) AS ICMSST
                                  FROM PRODUTONFEICMS
                                GROUP BY IDPRODUTONFE
                             )
                             
                             SELECT PRODUTONFE.IDPRODUTONFE,
                                    PRODUTO.CODIGO,
                                    PRODUTO.DESCRICAO AS PRODUTO,
                                    CSTICMS.CSTCSOSN,
                                    CFOP.CODIGO AS CFOP,
                                    PRODUTONFE.QUANTIDADE,
                                    PRODUTONFE.VALORUNITARIO,
                                    PRODUTONFE.DESCONTO,
                                    (((PRODUTONFE.VALORUNITARIO + PRODUTONFE.OUTRASDESPESAS + PRODUTONFE.FRETE + PRODUTONFE.SEGURO) *PRODUTONFE.QUANTIDADE) + VALORICMSPRODUTO.ICMSST) - DESCONTO AS VALORTOTAL,
                                    CASE 
                                      WHEN INTEGRACAOFISCAL.FINANCEIRO = 1 THEN (((PRODUTONFE.VALORUNITARIO + PRODUTONFE.OUTRASDESPESAS + PRODUTONFE.FRETE + PRODUTONFE.SEGURO) *PRODUTONFE.QUANTIDADE) + VALORICMSPRODUTO.ICMSST) - DESCONTO
                                      WHEN INTEGRACAOFISCAL.FINANCEIRO = 0 THEN 0
                                    END AS TOTALFINANCEIRO,
                                    PRODUTONFE.IDPRODUTONFE,
                                    PRODUTONFE.IDNFE,
                                    PRODUTONFE.IDPRODUTO,
                                    PRODUTONFE.FRETE,
                                    PRODUTONFE.OUTRASDESPESAS,
                                    PRODUTONFE.SEQUENCIA,
                                    PRODUTONFE.SEGURO,
                                    PRODUTONFE.IDINTEGRACAOFISCAL,
                                    UNIDADEDEMEDIDA.IDUNIDADEDEMEDIDA,
                                    PRODUTONFE.IDCFOP
                               FROM PRODUTONFE
                                 INNER JOIN PRODUTO ON (PRODUTONFE.IDPRODUTO = PRODUTO.IDPRODUTO)
                                 INNER JOIN VALORICMSPRODUTO ON (PRODUTONFE.IDPRODUTONFE = VALORICMSPRODUTO.IDPRODUTONFE)
                                 INNER JOIN UNIDADEDEMEDIDA ON (UNIDADEDEMEDIDA.IDUNIDADEDEMEDIDA = PRODUTO.IDUNIDADEDEMEDIDA) 
                                 INNER JOIN INTEGRACAOFISCAL ON (PRODUTO.IDINTEGRACAOFISCALNFE = INTEGRACAOFISCAL.IDINTEGRACAOFISCAL)
                                 INNER JOIN CSTICMS ON (INTEGRACAOFISCAL.IDCSTICMS = CSTICMS.IDCSTICMS)
                                 INNER JOIN CFOP ON (PRODUTONFE.IDCFOP = CFOP.IDCFOP)
                             WHERE PRODUTONFE.IDNFE = @IDNFE";
                oSQL.ParamByName["IDNFE"] = IDNFe;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Salvar(ProdutoNFe Prod, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO PRODUTONFE(
                                             IDPRODUTONFE, IDNFE, IDPRODUTO, IDCFOP, SEQUENCIA, FRETE, OUTRASDESPESAS, QUANTIDADE, VALORUNITARIO, DESCONTO, SEGURO, IDINTEGRACAOFISCAL, IDUNIDADEDEMEDIDA)
                                     VALUES (@IDPRODUTONFE, @IDNFE, @IDPRODUTO, @IDCFOP, @SEQUENCIA, @FRETE, @OUTRASDESPESAS, @QUANTIDADE, @VALORUNITARIO, @DESCONTO, @SEGURO, @IDINTEGRACAOFISCAL, @IDUNIDADEDEMEDIDA)";
                        oSQL.ParamByName["IDNFE"] = Prod.IDNFe;

                        oSQL.ParamByName["IDPRODUTO"] = Prod.IDProduto;                        
                        oSQL.ParamByName["IDINTEGRACAOFISCAL"] = Prod.IDIntegracaoFiscal;
                        oSQL.ParamByName["SEQUENCIA"] = Prod.Sequencia;
                        oSQL.ParamByName["IDUNIDADEDEMEDIDA"] = Prod.IDUnidadeDeMedida;
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE PRODUTONFE
                                        SET FRETE = @FRETE,
                                            OUTRASDESPESAS = @OUTRASDESPESAS,
                                            QUANTIDADE = @QUANTIDADE,
                                            VALORUNITARIO = @VALORUNITARIO,
                                            DESCONTO = @DESCONTO,
                                            SEGURO = @SEGURO,
                                            IDCFOP = @IDCFOP
                                    WHERE IDPRODUTONFE = @IDPRODUTONFE";
                        break;
                }
                oSQL.ParamByName["IDPRODUTONFE"] = Prod.IDProdutoNFe;
                oSQL.ParamByName["FRETE"] = Prod.Frete;
                oSQL.ParamByName["OUTRASDESPESAS"] = Prod.OutrasDespesas;
                oSQL.ParamByName["QUANTIDADE"] = Prod.Quantidade;
                oSQL.ParamByName["VALORUNITARIO"] = Prod.ValorUnitario;
                oSQL.ParamByName["DESCONTO"] = Prod.Desconto;
                oSQL.ParamByName["SEGURO"] = Prod.Seguro;
                oSQL.ParamByName["IDCFOP"] = Prod.IDCFOP;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDProdutoNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM PRODUTONFEICMS WHERE IDPRODUTONFE = @IDPRODUTONFE";
                oSQL.ParamByName["IDPRODUTONFE"] = IDProdutoNFe;
                oSQL.ExecSQL();
                oSQL.ClearAll();

                oSQL.SQL = "DELETE FROM PRODUTONFEPIS WHERE IDPRODUTONFE = @IDPRODUTONFE";
                oSQL.ParamByName["IDPRODUTONFE"] = IDProdutoNFe;
                oSQL.ExecSQL();
                oSQL.ClearAll();

                oSQL.SQL = "DELETE FROM PRODUTONFECOFINS WHERE IDPRODUTONFE = @IDPRODUTONFE";
                oSQL.ParamByName["IDPRODUTONFE"] = IDProdutoNFe;
                oSQL.ExecSQL();
                oSQL.ClearAll();

                oSQL.SQL = "DELETE FROM PRODUTONFEPARTILHAICMS WHERE IDPRODUTONFE = @IDPRODUTONFE";
                oSQL.ParamByName["IDPRODUTONFE"] = IDProdutoNFe;
                oSQL.ExecSQL();
                oSQL.ClearAll();

                oSQL.SQL = "DELETE FROM PRODUTONFE WHERE IDPRODUTONFE = @IDPRODUTONFE";
                oSQL.ParamByName["IDPRODUTONFE"] = IDProdutoNFe;
                return oSQL.ExecSQL() >= 1;
            }
        }
    }
}
