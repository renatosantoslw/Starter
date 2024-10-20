using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.DAO.Enum;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesConversaoUnidadeMedida
    {
        public static bool Salvar(ConversaoUnidadeDeMedida Conversao, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch(Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO CONVERSAOUNIDADEDEMEDIDA
                                        (IDCONVERSAOUNIDADEDEMEDIDA, IDPRODUTO, IDUNIDADEDEMEDIDAENTRADA, IDUNIDADEDEMEDIDASAIDA, FATOR, CALCULO,CODIGOPRODUTOFORNECEDOR,IDFORNECEDOR)
                                     VALUES 
                                        (@IDCONVERSAOUNIDADEDEMEDIDA, @IDPRODUTO, @IDUNIDADEDEMEDIDAENTRADA, @IDUNIDADEDEMEDIDASAIDA, @FATOR,@CALCULO,@CODIGOPRODUTOFORNECEDOR,@IDFORNECEDOR)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CONVERSAOUNIDADEDEMEDIDA
                                      SET IDPRODUTO = @IDPRODUTO,
                                          IDUNIDADEDEMEDIDAENTRADA = @IDUNIDADEDEMEDIDAENTRADA,
                                          IDUNIDADEDEMEDIDASAIDA = IDUNIDADEDEMEDIDASAIDA,
                                          FATOR = @FATOR, CALCULO = @CALCULO,
                                           IDFORNECEDOR = @IDFORNECEDOR, 
                                    CODIGOPRODUTOFORNECEDOR = @CODIGOPRODUTOFORNECEDOR

                                      WHERE IDCONVERSAOUNIDADEDEMEDIDA = @IDCONVERSAOUNIDADEDEMEDIDA";
                        break; 
                }

                oSQL.ParamByName["IDCONVERSAOUNIDADEDEMEDIDA"] = Conversao.IDConversaoUnidadeDeMedida;
                oSQL.ParamByName["IDPRODUTO"] = Conversao.IDProduto;
                oSQL.ParamByName["IDUNIDADEDEMEDIDAENTRADA"] = Conversao.IDUnidadeDeMedidaEntrada;
                oSQL.ParamByName["IDUNIDADEDEMEDIDASAIDA"] = Conversao.IDUnidadeDeMedidaSaida;
                oSQL.ParamByName["FATOR"] = Conversao.Fator;

                oSQL.ParamByName["CALCULO"] = Conversao.CALCULO;
                oSQL.ParamByName["IDFORNECEDOR"] = Conversao.IDFORNECEDOR;
                oSQL.ParamByName["CODIGOPRODUTOFORNECEDOR"] = Conversao.CODIGOPRODUTOFORNECEDOR;


                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDConversaoUnidadeDeMedida)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM CONVERSAOUNIDADEDEMEDIDA WHERE IDCONVERSAOUNIDADEDEMEDIDA = @IDCONVERSAOUNIDADEDEMEDIDA";
                oSQL.ParamByName["IDCONVERSAOUNIDADEDEMEDIDA"] = IDConversaoUnidadeDeMedida;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetConversoes()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT 
                                     UNENTRADA.SIGLA AS 'UN.MEDIDA ENTRADA',
                                     CONVERSAOUNIDADEDEMEDIDA.CALCULO,  
                                     CONVERSAOUNIDADEDEMEDIDA.FATOR AS QUANTIDADE,
                                     UNSAIDA.SIGLA AS 'UN.MEDIDA SAIDA',  
                                     CONVERSAOUNIDADEDEMEDIDA.IDCONVERSAOUNIDADEDEMEDIDA,
                                     CONVERSAOUNIDADEDEMEDIDA.IDPRODUTO,       
                                     CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDAENTRADA,
                                     CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDASAIDA,
					                 CONVERSAOUNIDADEDEMEDIDA.IDFORNECEDOR,
									 CONVERSAOUNIDADEDEMEDIDA.CODIGOPRODUTOFORNECEDOR
                                FROM CONVERSAOUNIDADEDEMEDIDA
                                -- INNER JOIN PRODUTO ON (CONVERSAOUNIDADEDEMEDIDA.IDPRODUTO = PRODUTO.IDPRODUTO)
                                 INNER JOIN UNIDADEDEMEDIDA UNENTRADA ON (CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDAENTRADA = UNENTRADA.IDUNIDADEDEMEDIDA)
                                 INNER JOIN UNIDADEDEMEDIDA UNSAIDA ON (CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDASAIDA = UNSAIDA.IDUNIDADEDEMEDIDA)
                              --WHERE UPPER(PRODUTO.DESCRICAO) LIKE UPPER('%%')";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }



        public static DataTable GetConversoesOLD(string Produto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT PRODUTO.DESCRICAO AS PRODUTO,
                                     UNENTRADA.SIGLA AS 'UN.MEDIDA ENTRADA',
                                     CONVERSAOUNIDADEDEMEDIDA.CALCULO,  
                                     CONVERSAOUNIDADEDEMEDIDA.FATOR AS QUANTIDADE,
                                     UNSAIDA.SIGLA AS 'UN.MEDIDA SAIDA',  
                                     CONVERSAOUNIDADEDEMEDIDA.IDCONVERSAOUNIDADEDEMEDIDA,
                                     CONVERSAOUNIDADEDEMEDIDA.IDPRODUTO,       
                                     CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDAENTRADA,
                                     CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDASAIDA
                                FROM CONVERSAOUNIDADEDEMEDIDA
                                 INNER JOIN PRODUTO ON (CONVERSAOUNIDADEDEMEDIDA.IDPRODUTO = PRODUTO.IDPRODUTO)
                                 INNER JOIN UNIDADEDEMEDIDA UNENTRADA ON (CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDAENTRADA = UNENTRADA.IDUNIDADEDEMEDIDA)
                                 INNER JOIN UNIDADEDEMEDIDA UNSAIDA ON (CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDASAIDA = UNSAIDA.IDUNIDADEDEMEDIDA)
                              WHERE UPPER(PRODUTO.DESCRICAO) LIKE UPPER('%{Produto}%')";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }


        public static ConversaoUnidadeDeMedida GetConversao(int IDConversaoUnidadeDeMedida)
        {
            if (IDConversaoUnidadeDeMedida == 0)
                return null;

            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONVERSAOUNIDADEDEMEDIDA,
IDPRODUTO,
IDUNIDADEDEMEDIDAENTRADA,
IDUNIDADEDEMEDIDASAIDA,
FATOR,CALCULO, 
IDFORNECEDOR,
CODIGOPRODUTOFORNECEDOR

FROM CONVERSAOUNIDADEDEMEDIDA WHERE IDCONVERSAOUNIDADEDEMEDIDA = @IDCONVERSAOUNIDADEDEMEDIDA";
                oSQL.ParamByName["IDCONVERSAOUNIDADEDEMEDIDA"] = IDConversaoUnidadeDeMedida;
                oSQL.Open();
                return EntityUtil<ConversaoUnidadeDeMedida>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Existe(decimal IDConversaoUnidadeDeMedida)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CONVERSAOUNIDADEDEMEDIDA WHERE IDCONVERSAOUNIDADEDEMEDIDA = @IDCONVERSAOUNIDADEDEMEDIDA";
                oSQL.ParamByName["IDCONVERSAOUNIDADEDEMEDIDA"] = IDConversaoUnidadeDeMedida;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static List<ConversaoUnidadeDeMedida> GetConversoesPorProduto(decimal IDProduto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CONVERSAOUNIDADEDEMEDIDA.IDCONVERSAOUNIDADEDEMEDIDA,
                                    CONVERSAOUNIDADEDEMEDIDA.IDPRODUTO,       
                                    CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDAENTRADA,
                                    CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDASAIDA,
                                    CONVERSAOUNIDADEDEMEDIDA.FATOR,
                                    UNSAI.SIGLA AS UNSAIDA,
                                    UNENT.SIGLA AS UNENTRADA,
                                    CONVERSAOUNIDADEDEMEDIDA.CALCULO,
                                    CONVERSAOUNIDADEDEMEDIDA.IDFORNECEDOR,
                                    CONVERSAOUNIDADEDEMEDIDA.CODIGOPRODUTOFORNECEDOR
                               FROM CONVERSAOUNIDADEDEMEDIDA
                                INNER JOIN UNIDADEDEMEDIDA UNENT ON (CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDAENTRADA = UNENT.IDUNIDADEDEMEDIDA)
                                INNER JOIN UNIDADEDEMEDIDA UNSAI ON (CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDASAIDA = UNSAI.IDUNIDADEDEMEDIDA)
                             WHERE CONVERSAOUNIDADEDEMEDIDA.IDPRODUTO = @IDPRODUTO";
                oSQL.ParamByName["IDPRODUTO"] = IDProduto;
                oSQL.Open();
                return new DataTableParser<ConversaoUnidadeDeMedida>().ParseDataTable(oSQL.dtDados);
            }
        }


        public static ConversaoUnidadeDeMedida GetConversoesPorProdutoFornecedor(decimal IDProduto, long IDProdutoFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CONVERSAOUNIDADEDEMEDIDA.IDCONVERSAOUNIDADEDEMEDIDA,
                                    CONVERSAOUNIDADEDEMEDIDA.IDPRODUTO,       
                                    CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDAENTRADA,
                                    CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDASAIDA,
                                    CONVERSAOUNIDADEDEMEDIDA.FATOR,
                                    UNSAI.SIGLA AS UNSAIDA,
                                    UNENT.SIGLA AS UNENTRADA,
                                    CONVERSAOUNIDADEDEMEDIDA.CALCULO,
                                    CONVERSAOUNIDADEDEMEDIDA.IDFORNECEDOR,
                                    CONVERSAOUNIDADEDEMEDIDA.CODIGOPRODUTOFORNECEDOR
                               FROM CONVERSAOUNIDADEDEMEDIDA
                                INNER JOIN UNIDADEDEMEDIDA UNENT ON (CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDAENTRADA = UNENT.IDUNIDADEDEMEDIDA)
                                INNER JOIN UNIDADEDEMEDIDA UNSAI ON (CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDASAIDA = UNSAI.IDUNIDADEDEMEDIDA)
                             WHERE CONVERSAOUNIDADEDEMEDIDA.IDPRODUTO = @IDPRODUTO AND CONVERSAOUNIDADEDEMEDIDA.CODIGOPRODUTOFORNECEDOR = @IDPRODUTOFORNECEDOR";
                oSQL.ParamByName["IDPRODUTO"] = IDProduto;
                oSQL.ParamByName["IDPRODUTOFORNECEDOR"] = IDProdutoFornecedor;
                oSQL.Open();

                if (oSQL.dtDados.Rows.Count > 0)
                    return EntityUtil<ConversaoUnidadeDeMedida>.ParseDataRow(oSQL.dtDados.Rows[0]);

                return null;
            }
        }

        public static List<ConversaoUnidadeDeMedida> GetConversoesPorProdutoTodos()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CONVERSAOUNIDADEDEMEDIDA.IDCONVERSAOUNIDADEDEMEDIDA,
                                    CONVERSAOUNIDADEDEMEDIDA.IDPRODUTO,   
                                    CONVERSAOUNIDADEDEMEDIDA.CALCULO,  
                                    CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDAENTRADA,
                                    CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDASAIDA,
                                    CONVERSAOUNIDADEDEMEDIDA.FATOR,
                                    UNENT.SIGLA AS UNENTRADA,
                                    UNSAI.SIGLA AS UNSAIDA
                               FROM CONVERSAOUNIDADEDEMEDIDA
                                INNER JOIN UNIDADEDEMEDIDA UNENT ON (CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDAENTRADA = UNENT.IDUNIDADEDEMEDIDA)
                                INNER JOIN UNIDADEDEMEDIDA UNSAI ON (CONVERSAOUNIDADEDEMEDIDA.IDUNIDADEDEMEDIDASAIDA = UNSAI.IDUNIDADEDEMEDIDA)
                           ";
            
                oSQL.Open();
                return new DataTableParser<ConversaoUnidadeDeMedida>().ParseDataTable(oSQL.dtDados);
            }
        }


    }
}