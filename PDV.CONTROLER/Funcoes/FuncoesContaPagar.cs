using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using System;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesContaPagar
    {
        public static bool Salvar(ContaPagar Conta, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO CONTAPAGAR(
                                                 IDCONTAPAGAR, IDCONTABANCARIA, IDCENTROCUSTO, IDFORNECEDOR, IDFORMADEPAGAMENTO, 
                                                 IDHISTORICOFINANCEIRO, IDPEDIDOCOMPRA, TITULO, PARCELA, EMISSAO, 
                                                 VENCIMENTO, COMPLMHISFIN, FLUXO, VALOR, ORIGEM, MULTA, JUROS, 
                                                 DESCONTO, SITUACAO, VALORTOTAL, SALDO, IDNFEENTRADA,ORD)
                                         VALUES (@IDCONTAPAGAR, @IDCONTABANCARIA, @IDCENTROCUSTO, @IDFORNECEDOR, @IDFORMADEPAGAMENTO, 
                                                 @IDHISTORICOFINANCEIRO, @IDPEDIDOCOMPRA, @TITULO, @PARCELA, @EMISSAO, 
                                                 @VENCIMENTO, @COMPLMHISFIN, @FLUXO, @VALOR, @ORIGEM, @MULTA, @JUROS, 
                                                 @DESCONTO, @SITUACAO, @VALORTOTAL, @SALDO, @IDNFEENTRADA,@ORD)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CONTAPAGAR
                                       SET IDCONTABANCARIA = @IDCONTABANCARIA,
                                           IDCENTROCUSTO = @IDCENTROCUSTO,
                                           IDFORNECEDOR = @IDFORNECEDOR, 
                                           IDFORMADEPAGAMENTO = @IDFORMADEPAGAMENTO,
                                           IDHISTORICOFINANCEIRO = @IDHISTORICOFINANCEIRO,
                                           TITULO = @TITULO, 
                                           PARCELA = @PARCELA, 
                                           EMISSAO = @EMISSAO, 
                                           VENCIMENTO = @VENCIMENTO, 
                                           COMPLMHISFIN = @COMPLMHISFIN, 
                                           FLUXO = @FLUXO, 
                                           VALOR = @VALOR, 
                                           ORIGEM = @ORIGEM, 
                                           MULTA = @MULTA, 
                                           JUROS = @JUROS, 
                                           DESCONTO = @DESCONTO, 
                                           SITUACAO = @SITUACAO, 
                                           VALORTOTAL = @VALORTOTAL, 
                                           SALDO = @SALDO,
                                           IDNFEENTRADA = @IDNFEENTRADA, ORD = @ORD
                                     WHERE IDCONTAPAGAR = @IDCONTAPAGAR";
                        break;
                }
                oSQL.ParamByName["IDCONTAPAGAR"] = Conta.IDContaPagar;
                oSQL.ParamByName["IDCONTABANCARIA"] = Conta.IDContaBancaria;
                oSQL.ParamByName["IDCENTROCUSTO"] = Conta.IDCentroCusto;
                oSQL.ParamByName["IDFORNECEDOR"] = Conta.IDFornecedor;
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = Conta.IDFormaDePagamento;
                oSQL.ParamByName["IDHISTORICOFINANCEIRO"] = Conta.IDHistoricoFinanceiro;
                oSQL.ParamByName["IDPEDIDOCOMPRA"] = Conta.IDPedidoCompra;
                oSQL.ParamByName["TITULO"] = Conta.Titulo;
                oSQL.ParamByName["PARCELA"] = Conta.Parcela;
                oSQL.ParamByName["EMISSAO"] = Conta.Emissao;
                oSQL.ParamByName["VENCIMENTO"] = Conta.Vencimento;
                oSQL.ParamByName["COMPLMHISFIN"] = Conta.ComplmHisFin;
                oSQL.ParamByName["FLUXO"] = Conta.Fluxo;
                oSQL.ParamByName["VALOR"] = Conta.Valor;
                oSQL.ParamByName["ORIGEM"] = Conta.Origem;
                oSQL.ParamByName["MULTA"] = Conta.Multa;
                oSQL.ParamByName["JUROS"] = Conta.Juros;
                oSQL.ParamByName["DESCONTO"] = Conta.Desconto;
                oSQL.ParamByName["SITUACAO"] = Conta.Situacao;
                oSQL.ParamByName["VALORTOTAL"] = Conta.ValorTotal;
                oSQL.ParamByName["SALDO"] = Conta.Saldo;
                oSQL.ParamByName["IDNFEENTRADA"] = Conta.IDNFeEntrada;
                oSQL.ParamByName["ORD"] = Conta.Ord;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static object GetContaPagarAgrupadasPorFormaDePagamento(DateTime dateDe, DateTime dateAte, string filtrarPor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT 
                                FP.DESCRICAO,
                                SUM(CP.VALORTOTAL) AS SOMA
                            FROM
                            CONTAPAGAR CP
                            JOIN FORMADEPAGAMENTO FP ON (CP.IDFORMADEPAGAMENTO = FP.IDFORMADEPAGAMENTO)
                            WHERE ({filtrarPor} BETWEEN @DATADE AND @DATAATE)
                            GROUP BY FP.DESCRICAO
                            ORDER BY SOMA DESC

                        ";

                oSQL.ParamByName["DATADE"] = dateDe;
                oSQL.ParamByName["DATAATE"] = dateAte;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static object GetContasPagarAgrupadasPorSituacao(DateTime dataDe, DateTime dataAte, string filtrarPor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT
                        CASE
                            WHEN SITUACAO = {StatusConta.Aberto} THEN 'ABERTO'
                            WHEN SITUACAO = {StatusConta.Parcial} THEN 'PARCIAL'
                            WHEN SITUACAO = {StatusConta.Cancelado} THEN 'CANCELADO'
                            WHEN SITUACAO = {StatusConta.Baixado} THEN 'BAIXADO'
                        END AS STATUS,
                        SUM(VALORTOTAL) AS SOMA
                        FROM CONTAPAGAR
                        WHERE ({filtrarPor} BETWEEN @DATADE AND @DATAATE)
                        GROUP BY SITUACAO
                        ORDER BY SOMA DESC";
                oSQL.ParamByName["DATADE"] = dataDe;
                oSQL.ParamByName["DATAATE"] = dataAte;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Remover(decimal IDContaPagar)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM CONTAPAGAR WHERE IDCONTAPAGAR = @IDCONTAPAGAR";
                oSQL.ParamByName["IDCONTAPAGAR"] = IDContaPagar;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetContas(DateTime date1, DateTime date2)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT DISTINCT CONTAPAGAR.IDCONTAPAGAR,
                                     CONTAPAGAR.IDPEDIDOCOMPRA,
                                     CONTAPAGAR.IDFORNECEDOR,
                                     FORNECEDOR.RAZAOSOCIAL AS FORNECEDOR,
                                     ISNULL(cast(CONTAPAGAR.ORD as varchar(30)), '') + ' / ' + ISNULL(CAST(CONTAPAGAR.PARCELA AS VARCHAR(30)), '') AS PARCELA ,
                                     CONTAPAGAR.EMISSAO,
                                     CONTAPAGAR.VENCIMENTO,
                                    FORMADEPAGAMENTO.IDENTIFICACAO AS FORMAPAGAMENTO,
                                     CASE 
                                       WHEN TITULO IS NULL THEN ORIGEM
                                       ELSE ISNULL(ORIGEM, '') + '-' + ISNULL(COALESCE(TITULO, ''), '') 
                                      END AS ORIGEM,
                                     CONTAPAGAR.VALORTOTAL,
                                     CASE
                                       WHEN CONTAPAGAR.SITUACAO = 0 THEN 'CANCELADO'
                                       WHEN CONTAPAGAR.SITUACAO = 1 THEN 'ABERTO'
                                       WHEN CONTAPAGAR.SITUACAO = 2 THEN 'PARCIAL'
                                       WHEN CONTAPAGAR.SITUACAO = 3 THEN 'BAIXADO'
                                     END AS SITUACAO,
                                    CONTAPAGAR.COMPLMHISFIN as DETALHE
                                FROM CONTAPAGAR
                                  INNER JOIN FORMADEPAGAMENTO ON (CONTAPAGAR.IDFORMADEPAGAMENTO = FORMADEPAGAMENTO.IDFORMADEPAGAMENTO)
                                   LEFT JOIN FORNECEDOR ON (CONTAPAGAR.IDFORNECEDOR = FORNECEDOR.IDFORNECEDOR)
                            WHERE CONTAPAGAR.EMISSAO BETWEEN @DATE1 AND @DATE2
                              ORDER BY CONTAPAGAR.IDCONTAPAGAR DESC,
                                       ISNULL(cast(CONTAPAGAR.ORD as varchar(30)), '') + ' / ' + ISNULL(CAST(CONTAPAGAR.PARCELA AS VARCHAR(30)), '')";
                oSQL.ParamByName["DATE1"] = date1;
                oSQL.ParamByName["DATE2"] = date2;

                oSQL.Open();

                return oSQL.dtDados;
            }
        }


        public static DataTable GetContasTudo()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT DISTINCT 
                                     CONTAPAGAR.IDCONTAPAGAR as ID,
                                     FORNECEDOR.RAZAOSOCIAL AS FORNECEDOR,
                                     CONTAPAGAR.ORD + ' / ' +CONTAPAGAR.PARCELA AS PARCELA ,
                                     CONTAPAGAR.EMISSAO as EMISSAO,
                                     CONTAPAGAR.VENCIMENTO as VENCIMENTO,
                                    
                                     CONTAPAGAR.VALORTOTAL,
                                     CASE
                                       WHEN CONTAPAGAR.SITUACAO = 0 THEN 'CANCELADO'
                                       WHEN CONTAPAGAR.SITUACAO = 1 THEN 'ABERTO'
                                       WHEN CONTAPAGAR.SITUACAO = 2 THEN 'PARCIAL'
                                       WHEN CONTAPAGAR.SITUACAO = 3 THEN 'BAIXADO'
                                     END AS SITUACAO,
                                    CONTAPAGAR.COMPLMHISFIN as DETALHE
                                FROM CONTAPAGAR
                                  INNER JOIN FORMADEPAGAMENTO ON (CONTAPAGAR.IDFORMADEPAGAMENTO = FORMADEPAGAMENTO.IDFORMADEPAGAMENTO)
                                   LEFT JOIN FORNECEDOR ON (CONTAPAGAR.IDFORNECEDOR = FORNECEDOR.IDFORNECEDOR)
                              ORDER BY CONTAPAGAR.EMISSAO ";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static ContaPagar GetContaPagar(decimal IDContaPagar)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONTAPAGAR,
IDCONTABANCARIA,
IDCENTROCUSTO,
IDFORNECEDOR,
IDFORMADEPAGAMENTO,
IDHISTORICOFINANCEIRO,
TITULO,
PARCELA,
EMISSAO,
VENCIMENTO,
COMPLMHISFIN,
FLUXO,
VALOR,
ORIGEM,
MULTA,
JUROS,
DESCONTO,
SITUACAO,
VALORTOTAL,
SALDO,
IDNFEENTRADA,
ORD,
IDPEDIDOCOMPRA FROM CONTAPAGAR WHERE IDCONTAPAGAR = @IDCONTAPAGAR";
                oSQL.ParamByName["IDCONTAPAGAR"] = IDContaPagar;
                oSQL.Open();
                return EntityUtil<ContaPagar>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static System.Collections.Generic.List<ContaPagar> GetContaPagarLista()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONTAPAGAR,
IDCONTABANCARIA,
IDCENTROCUSTO,
IDFORNECEDOR,
IDFORMADEPAGAMENTO,
IDHISTORICOFINANCEIRO,
TITULO,
PARCELA,
EMISSAO,
VENCIMENTO,
COMPLMHISFIN,
FLUXO,
VALOR,
ORIGEM,
MULTA,
JUROS,
DESCONTO,
SITUACAO,
VALORTOTAL,
SALDO,
IDNFEENTRADA,
ORD,
IDPEDIDOCOMPRA FROM CONTAPAGAR ";
                oSQL.Open();
                return new DataTableParser<ContaPagar>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool CancelarContaPagarDocumento(decimal IDPedidoCompra)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE CONTAPAGAR 
                                SET SITUACAO = 0, --Cancelado
                                complmhisfin = 'CANCELAMENTO DE FATURAMENTO.'

                             WHERE IDPEDIDOCOMPRA = @IDPEDIDOCOMPRA";
                oSQL.ParamByName["IDPEDIDOCOMPRA"] = IDPedidoCompra;
                return oSQL.ExecSQL() >= 1;
            }
        }
        public static bool Existe(decimal IDContaPagar)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CONTAPAGAR WHERE IDCONTAPAGAR = @IDCONTAPAGAR";
                oSQL.ParamByName["IDCONTAPAGAR"] = IDContaPagar;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
    }
}