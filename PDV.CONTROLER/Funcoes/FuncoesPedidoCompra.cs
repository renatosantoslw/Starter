using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Estoque.PedidoDeCompra;
using PDV.DAO.Enum;
using PDV.DAO.QueryModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesPedidoCompra
    {

        public static bool Salvar(PedidoCompra Ped)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PEDIDOCOMPRA WHERE IDPEDIDOCOMPRA = @IDPEDIDOCOMPRA";
                oSQL.ParamByName["IDPEDIDOCOMPRA"] = Ped.IDPedidoCompra;
                oSQL.Open();
                bool ExisteCompra = !oSQL.IsEmpty;
                oSQL.ClearAll();

                if (!ExisteCompra)
                    oSQL.SQL = @"INSERT INTO PEDIDOCOMPRA (
                                         IDPEDIDOCOMPRA, IDFORNECEDOR, 
                                         IDFORMADEPAGAMENTO,
                                         IDTIPODEOPERACAO, IDTRANSPORTADORA, 
                                         IDUSUARIOCADASTRO, IDFLUXOCAIXA,
                                         DATAEMISSAO, DATAENTREGA,
                                         TIPOFRETE, OBSERVACAO,
                                         DATAALTERACAO, DATACANCELAMENTO,
                                         TOTAL, STATUS,
                                         MOTIVODECANCELAMENTO, IDCOMPRADOR,
                                         DATAFATURAMENTO, PAGAMENTOSDESCRICAO
                                     ) VALUES (
                                         @IDPEDIDOCOMPRA, @IDFORNECEDOR, 
                                         @IDFORMADEPAGAMENTO,
                                         @IDTIPODEOPERACAO, @IDTRANSPORTADORA, 
                                         @IDUSUARIOCADASTRO, @IDFLUXOCAIXA,
                                         CAST(@DATAEMISSAO AS DATETIME),  CAST(@DATAENTREGA AS DATETIME),
                                         @TIPOFRETE,  @OBSERVACAO,
                                         CAST(@DATAALTERACAO AS DATETIME),  CAST(@DATACANCELAMENTO AS DATETIME),
                                         @TOTAL,  @STATUS,
                                         @MOTIVODECANCELAMENTO,  @IDCOMPRADOR,
                                         CAST(@DATAFATURAMENTO AS DATETIME), @PAGAMENTOSDESCRICAO
                                     )";
                else
                    oSQL.SQL = @"UPDATE PEDIDOCOMPRA 
                                       SET IDFORNECEDOR = @IDFORNECEDOR,
                                           IDFORMADEPAGAMENTO = @IDFORMADEPAGAMENTO,
                                           IDTRANSPORTADORA = @IDTRANSPORTADORA,
                                           IDUSUARIOCADASTRO = @IDUSUARIOCADASTRO,
                                           -- IDVENDEDOR = @IDVENDEDOR,
                                           IDTIPODEOPERACAO = @IDTIPODEOPERACAO,
                                           IDFLUXOCAIXA = @IDFLUXOCAIXA,
                                           DATAEMISSAO = @DATAEMISSAO,
                                           DATAENTREGA = @DATAENTREGA,
                                           TIPOFRETE = @TIPOFRETE,
                                           OBSERVACAO = @OBSERVACAO,
                                           DATAALTERACAO = @DATAALTERACAO,
                                           DATACANCELAMENTO = @DATACANCELAMENTO,
                                           TOTAL = @TOTAL,
                                           STATUS = @STATUS,
                                           MOTIVODECANCELAMENTO = @MOTIVODECANCELAMENTO,
                                           IDCOMPRADOR = @IDCOMPRADOR,
                                           DATAFATURAMENTO = @DATAFATURAMENTO,
                                           PAGAMENTOSDESCRICAO = @PAGAMENTOSDESCRICAO
                                     WHERE IDPEDIDOCOMPRA = @IDPEDIDOCOMPRA";
                oSQL.ParamByName["IDPEDIDOCOMPRA"] = Ped.IDPedidoCompra;
                oSQL.ParamByName["IDFORNECEDOR"] = Ped.IDFornecedor;
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = Ped.IDFormaDePagamento;
                oSQL.ParamByName["IDVENDEDOR"] = Ped.IDVendedor;
                oSQL.ParamByName["IDTIPODEOPERACAO"] = Ped.IDTipoDeOperacao;
                oSQL.ParamByName["IDFLUXOCAIXA"] = Ped.IDFluxoCaixa;
                oSQL.ParamByName["IDTRANSPORTADORA"] = Ped.IDTransportadora;
                oSQL.ParamByName["IDUSUARIOCADASTRO"] = Ped.IDUsuarioCadastro;
                oSQL.ParamByName["DATAEMISSAO"] = Ped.DataEmissao;
                oSQL.ParamByName["DATAENTREGA"] = Ped.DataEntrega;
                oSQL.ParamByName["TIPOFRETE"] = Ped.TipoFrete;
                oSQL.ParamByName["OBSERVACAO"] = Ped.Observacao;
                if (Ped.DataAlteracao < DateTime.Parse("01/01/2019 00:00:00"))
                    oSQL.ParamByName["DATAALTERACAO"] = null;
                else
                    oSQL.ParamByName["DATAALTERACAO"] = Ped.DataAlteracao;
                oSQL.ParamByName["DATACANCELAMENTO"] = Ped.DataCancelamento < Ped.DataEmissao ? DateTime.Now : Ped.DataCancelamento;
                oSQL.ParamByName["TOTAL"] = Ped.Total;
                oSQL.ParamByName["STATUS"] = Ped.Status;
                oSQL.ParamByName["MOTIVODECANCELAMENTO"] = Ped.MotivoDeCancelamento;
                oSQL.ParamByName["IDCOMPRADOR"] = Ped.IDComprador;
                if (Ped.DataFaturamento < DateTime.Parse("01/01/2019 00:00:00"))
                    oSQL.ParamByName["DATAFATURAMENTO"] = null;
                else
                    oSQL.ParamByName["DATAFATURAMENTO"] = Ped.DataFaturamento;
                oSQL.ParamByName["PAGAMENTOSDESCRICAO"] = Ped.PagamentosDescricao;
                return oSQL.ExecSQL() == 1;
            }
            
        }

        public static DataTable GetComprasPorProduto(ResumoPorProdutoGenericoReportModel reportModel)
        {
            decimal status = 0;
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (reportModel.Status)
                {
                    case "ABERTO":
                        status = 0;
                        break;

                    case "FATURADO":
                        status = 1;
                        break;

                    case "CANCELADO":
                        status = 2;
                        break;

                    case "APP":
                        status = 4;
                        break;
                }
                oSQL.SQL = $@"SELECT 
                             P.CODIGO AS CODIGO,
                             P.DESCRICAO AS PRODUTO
                            ,M.DESCRICAO AS GRUPO
                            ,P.VALORCUSTO AS PRECOCUSTO
                            ,P.VALORVENDA AS PRECOVENDA
                            ,SUM(IV.DESCONTO) AS DESCONTO
                            ,SUM(IV.QUANTIDADE) AS QUANTIDADE
                            ,SUM((P.VALORCUSTO * IV.QUANTIDADE) - IV.DESCONTO )AS TOTAL
                            FROM ITEMPEDIDOCOMPRA IV
                            LEFT JOIN PRODUTO P ON P.IDPRODUTO = IV.IDPRODUTO
                            LEFT JOIN MARCA M ON M.IDMARCA = P.IDMARCA
                            LEFT Join PEDIDOCOMPRA V on V.IDPEDIDOCOMPRA = IV.IDPEDIDOCOMPRA
                            WHERE (V.{reportModel.FiltrarPor} BETWEEN @DATE1 AND @DATE2)
                             AND (V.IDTIPODEOPERACAO IN ({reportModel.IDsOperacaoString}))
                             AND (V.STATUS = @STATUS) 
                            GROUP BY 
                             P.DESCRICAO 
                            ,M.DESCRICAO 
                            ,P.VALORCUSTO 
                            ,P.VALORVENDA 
                            ,P.CODIGO
                                ";

                oSQL.ParamByName["DATE1"] = reportModel.DataDe.Date;
                oSQL.ParamByName["DATE2"] = reportModel.DataAte.Date;
                oSQL.ParamByName["STATUS"] = status;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Remover(decimal IDPedidoCompra)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM ITEMPEDIDOCOMPRA WHERE IDPEDIDOCOMPRA = @IDPEDIDOCOMPRA";
                oSQL.ParamByName["IDPEDIDOCOMPRA"] = IDPedidoCompra;
                oSQL.ExecSQL();
                oSQL.ClearAll();

     

                oSQL.SQL = "DELETE FROM NFEENTRADA WHERE IDPEDIDOCOMPRA = @IDPEDIDOCOMPRA";
                oSQL.ParamByName["IDPEDIDOCOMPRA"] = IDPedidoCompra;
                oSQL.ExecSQL();
                oSQL.ClearAll();

                oSQL.SQL = "DELETE FROM PEDIDOCOMPRA WHERE IDPEDIDOCOMPRA = @IDPEDIDOCOMPRA";
                oSQL.ParamByName["IDPEDIDOCOMPRA"] = IDPedidoCompra;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static PedidoCompra GetPedidoCompra(decimal IDPedidoCompra)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDPEDIDOCOMPRA,
IDFORNECEDOR,
IDFORMADEPAGAMENTO,
IDTRANSPORTADORA,
IDUSUARIOCADASTRO,
DATAEMISSAO,
DATAENTREGA,
TIPOFRETE,
OBSERVACAO,
DATAALTERACAO,
DATACANCELAMENTO,
TOTAL,
STATUS,
IDCOMPRADOR,
IDTIPODEOPERACAO,
IDFLUXOCAIXA,
QUANTIDADEITENS,
MOTIVODECANCELAMENTO,
DATAFATURAMENTO,
PAGAMENTOSDESCRICAO FROM PEDIDOCOMPRA WHERE IDPEDIDOCOMPRA = @IDPEDIDOCOMPRA";
                oSQL.ParamByName["IDPEDIDOCOMPRA"] = IDPedidoCompra;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<PedidoCompra>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetPedidosDeCompra(DateTime date1, DateTime date2)
        {

            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT DISTINCT PEDIDOCOMPRA.IDPEDIDOCOMPRA AS CODIGO,
                                     PEDIDOCOMPRA.DATAEMISSAO,
                                     PEDIDOCOMPRA.DATAENTREGA,
                                     PEDIDOCOMPRA.DATACANCELAMENTO,
                                     USUARIO.NOME AS USUARIO,
                                     COALESCE(TIPODEOPERACAO.NOME, '<Não Informado>') AS TIPODEOPERACAO,
                                     COALESCE(FORNECEDOR.RAZAOSOCIAL, '<Não Informado>') AS FORNECEDOR,
                                     CASE 
                                       WHEN PEDIDOCOMPRA.TIPOFRETE = 0 THEN 'CIF'
                                       WHEN PEDIDOCOMPRA.TIPOFRETE = 1 THEN 'FOB'
                                     END AS TIPOFRETE,
                                     PEDIDOCOMPRA.TOTAL,
                                     CASE 
                                       WHEN PEDIDOCOMPRA.STATUS = 0 THEN 'ABERTO'
                                       WHEN PEDIDOCOMPRA.STATUS = 1 THEN 'FATURADO'
                                       WHEN PEDIDOCOMPRA.STATUS = 2 THEN 'CANCELADO'
                                     END AS STATUS,
                                     PEDIDOCOMPRA.IDPEDIDOCOMPRA
                                FROM PEDIDOCOMPRA 
                                  INNER JOIN USUARIO ON (PEDIDOCOMPRA.IDUSUARIOCADASTRO = USUARIO.IDUSUARIO)
                                  LEFT JOIN FORNECEDOR ON (PEDIDOCOMPRA.IDFORNECEDOR = FORNECEDOR.IDFORNECEDOR)
                                  LEFT JOIN TIPODEOPERACAO ON (PEDIDOCOMPRA.IDTIPODEOPERACAO = TIPODEOPERACAO.IDTIPODEOPERACAO)
                                 WHERE DATAEMISSAO BETWEEN @DATE1 AND @DATE2                                  
                                 ORDER BY PEDIDOCOMPRA.DATAEMISSAO DESC";
                oSQL.ParamByName["DATE1"] = date1;
                oSQL.ParamByName["DATE2"] = date2;
                oSQL.Open();

                return oSQL.dtDados;
            }
        }


        public static DataTable GetPedidosDeCompraTodos()
        {

            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT DISTINCT PEDIDOCOMPRA.IDPEDIDOCOMPRA AS CODIGO,
                                     PEDIDOCOMPRA.DATAEMISSAO,
                                     PEDIDOCOMPRA.DATAENTREGA,
                                     PEDIDOCOMPRA.DATACANCELAMENTO,
                                     USUARIO.NOME AS USUARIO,
                                     COALESCE(TIPODEOPERACAO.NOME, '<Não Informado>') AS TIPODEOPERACAO,
                                     COALESCE(FORNECEDOR.RAZAOSOCIAL, '<Não Informado>') AS FORNECEDOR,
                                     CASE 
                                       WHEN PEDIDOCOMPRA.TIPOFRETE = 0 THEN 'CIF'
                                       WHEN PEDIDOCOMPRA.TIPOFRETE = 1 THEN 'FOB'
                                     END AS TIPOFRETE,
                                     PEDIDOCOMPRA.TOTAL,
                                     CASE 
                                       WHEN PEDIDOCOMPRA.STATUS = 0 THEN 'ABERTO'
                                       WHEN PEDIDOCOMPRA.STATUS = 1 THEN 'FATURADO'
                                       WHEN PEDIDOCOMPRA.STATUS = 2 THEN 'CANCELADO'
                                     END AS STATUS,
                                     PEDIDOCOMPRA.IDPEDIDOCOMPRA
                                FROM PEDIDOCOMPRA 
                                  INNER JOIN USUARIO ON (PEDIDOCOMPRA.IDUSUARIOCADASTRO = USUARIO.IDUSUARIO)
                                  LEFT JOIN FORNECEDOR ON (PEDIDOCOMPRA.IDFORNECEDOR = FORNECEDOR.IDFORNECEDOR)
                                  LEFT JOIN TIPODEOPERACAO ON (PEDIDOCOMPRA.IDTIPODEOPERACAO = TIPODEOPERACAO.IDTIPODEOPERACAO)
                                                         
                                 ORDER BY PEDIDOCOMPRA.DATAEMISSAO DESC";

                oSQL.Open();

                return oSQL.dtDados;
            }
        }












        public static DataTable GetPedidoCompraPorFornecedor(decimal IDFornecedor, DateTime DataInicial, DateTime DataFinal, string Codigo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT PEDIDOCOMPRA.IDPEDIDOCOMPRA,
                                     PEDIDOCOMPRA.DATAEMISSAO,
                                     FORNECEDOR.RAZAOSOCIAL AS FORNECEDOR,
                                     USUARIO.NOME AS USUARIO,
                                     PEDIDOCOMPRA.TOTAL,
                                     CASE 
                                       WHEN PEDIDOCOMPRA.STATUS = 0 THEN 'Aberto'
                                       WHEN PEDIDOCOMPRA.STATUS = 1 THEN 'Parcial'
                                       WHEN PEDIDOCOMPRA.STATUS = 2 THEN 'Baixado'
                                     END AS STATUS
                               FROM PEDIDOCOMPRA
                                 INNER JOIN FORNECEDOR ON (PEDIDOCOMPRA.IDFORNECEDOR = FORNECEDOR.IDFORNECEDOR)
                                 INNER JOIN USUARIO ON (PEDIDOCOMPRA.IDUSUARIOCADASTRO = USUARIO.IDUSUARIO)
                             WHERE CAST(PEDIDOCOMPRA.DATAEMISSAO AS DATE) BETWEEN @INICIOVIGENCIA AND @FIMVIGENCIA
                               AND (FORNECEDOR.IDFORNECEDOR = @IDFORNECEDOR)
                               AND CAST(PEDIDOCOMPRA.IDPEDIDOCOMPRA AS VARCHAR) ILIKE '%{Codigo}%'";
                oSQL.ParamByName["INICIOVIGENCIA"] = DataInicial;
                oSQL.ParamByName["FIMVIGENCIA"] = DataFinal;
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool AtualizarStatus(decimal IDPedidoCompra, int Status)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "UPDATE PEDIDOCOMPRA SET STATUS = @STATUS WHERE IDPEDIDOCOMPRA = @IDPEDIDOCOMPRA";
                oSQL.ParamByName["IDPEDIDOCOMPRA"] = IDPedidoCompra;
                oSQL.ParamByName["STATUS"] = Status;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool CancelaPedidoCompra(decimal IDPedidoCompra, string motivo)
        {
            //0 ABERTO
            //1 FATURADO
            //2 CANCELADO
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE PEDIDOCOMPRA 
                               SET STATUS = @STATUS,
                                   MOTIVODECANCELAMENTO = @MOTIVODECANCELAMENTO
                             WHERE IDPEDIDOCOMPRA = @IDPEDIDOCOMPRA";
                oSQL.ParamByName["IDPEDIDOCOMPRA"] = IDPedidoCompra;
                oSQL.ParamByName["MOTIVODECANCELAMENTO"] = motivo;
                oSQL.ParamByName["STATUS"] = 2;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static decimal GetFluxoCaixa()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT TOP 1 IDFLUXOCAIXA
                               FROM FLUXOCAIXA 
                            WHERE DATAFECHAMENTOCAIXA is null
                             ORDER BY IDFLUXOCAIXA DESC
                              /*LIMIT 1*/";
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return 0;
                return Convert.ToDecimal(oSQL.dtDados.Rows[0]["IDFLUXOCAIXA"]);
            }
        }
    }

}