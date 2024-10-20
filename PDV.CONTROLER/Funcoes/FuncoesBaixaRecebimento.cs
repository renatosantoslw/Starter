using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesBaixaRecebimento
    {
        public static bool Salvar(BaixaRecebimento BaixaRecebimento, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO BAIXARECEBIMENTO(IDBAIXARECEBIMENTO, IDCONTARECEBER, IDFORMADEPAGAMENTO, IDCONTABANCARIA, IDHISTORICOFINANCEIRO, 
                                        COMPLMHISFIN, BAIXA, MULTA, JUROS, DESCONTO, VALOR, DATACONCILIACAO, IDFLUXOCAIXA)
                                       VALUES (@IDBAIXARECEBIMENTO, @IDCONTARECEBER, @IDFORMADEPAGAMENTO, @IDCONTABANCARIA, @IDHISTORICOFINANCEIRO, 
                                        @COMPLMHISFIN, @BAIXA, @MULTA, @JUROS, @DESCONTO, @VALOR, @DATACONCILIACAO, @IDFLUXOCAIXA)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE BAIXARECEBIMENTO
                                       SET  IDBAIXARECEBIMENTO    = @IDBAIXARECEBIMENTO, 
                                            IDCONTARECEBER        = @IDCONTARECEBER, 
                                            IDFORMADEPAGAMENTO    = @IDFORMADEPAGAMENTO, 
                                            IDCONTABANCARIA       = @IDCONTABANCARIA, 
                                            IDHISTORICOFINANCEIRO = @IDHISTORICOFINANCEIRO,
                                            COMPLMHISFIN          = @COMPLMHISFIN, 
                                            BAIXA                 = @BAIXA, 
                                            MULTA                 = @MULTA,
                                            JUROS                 = @JUROS,
                                            DESCONTO              = @DESCONTO, 
                                            VALOR                 = @VALOR, 
                                            DATACONCILIACAO       = @DATACONCILIACAO,
                                            IDFLUXOCAIXA          = @IDFLUXOCAIXA
                                     WHERE IDBAIXARECEBIMENTO     = @IDBAIXARECEBIMENTO";
                        break;
                }
                oSQL.ParamByName["IDBAIXARECEBIMENTO"] = BaixaRecebimento.IDBaixaRecebimento;
                oSQL.ParamByName["IDCONTARECEBER"] = BaixaRecebimento.IDContaReceber;
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = BaixaRecebimento.IDFormaDePagamento;
                oSQL.ParamByName["IDCONTABANCARIA"] = BaixaRecebimento.IDContaBancaria;
                oSQL.ParamByName["IDHISTORICOFINANCEIRO"] = BaixaRecebimento.IDHistoricoFinanceiro;
                oSQL.ParamByName["COMPLMHISFIN"] = BaixaRecebimento.ComplmHisFin;
                oSQL.ParamByName["BAIXA"] = BaixaRecebimento.Baixa;
                oSQL.ParamByName["MULTA"] = BaixaRecebimento.Multa;
                oSQL.ParamByName["JUROS"] = BaixaRecebimento.Juros;
                oSQL.ParamByName["DESCONTO"] = BaixaRecebimento.Desconto;
                oSQL.ParamByName["VALOR"] = BaixaRecebimento.Valor;
                oSQL.ParamByName["DATACONCILIACAO"] = BaixaRecebimento.DataConciliacao;
                oSQL.ParamByName["IDFLUXOCAIXA"] = BaixaRecebimento.IDFluxoCaixa;

                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDBAIXARECEBIMENTO)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM CHEQUECONTARECEBER WHERE IDBAIXARECEBIMENTO = @IDBAIXARECEBIMENTO";
                oSQL.ParamByName["IDBAIXARECEBIMENTO"] = IDBAIXARECEBIMENTO;
                oSQL.ExecSQL();

                oSQL.ClearAll();

                oSQL.SQL = "DELETE FROM BAIXARECEBIMENTO WHERE IDBAIXARECEBIMENTO = @IDBAIXARECEBIMENTO";
                oSQL.ParamByName["IDBAIXARECEBIMENTO"] = IDBAIXARECEBIMENTO;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetBaixas(decimal IDContaReceber)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT BAIXARECEBIMENTO.IDBAIXARECEBIMENTO,
                                    BAIXARECEBIMENTO.BAIXA,
                                    CONTABANCARIA.NOME AS CONTABANCARIA,
                                    BAIXARECEBIMENTO.VALOR,
                                    BAIXARECEBIMENTO.MULTA,
                                    BAIXARECEBIMENTO.JUROS,
                                    BAIXARECEBIMENTO.DESCONTO,
                                    (COALESCE(BAIXARECEBIMENTO.VALOR, 0) - COALESCE(BAIXARECEBIMENTO.DESCONTO, 0)) + COALESCE(BAIXARECEBIMENTO.MULTA, 0) + COALESCE(BAIXARECEBIMENTO.JUROS, 0) AS TOTAL,
                                    BAIXARECEBIMENTO.IDCONTARECEBER,
                                    BAIXARECEBIMENTO.IDFORMADEPAGAMENTO,
                                    BAIXARECEBIMENTO.IDCONTABANCARIA,
                                    BAIXARECEBIMENTO.IDHISTORICOFINANCEIRO,
                                    BAIXARECEBIMENTO.COMPLMHISFIN,
                                    BAIXARECEBIMENTO.DATACONCILIACAO
                               FROM BAIXARECEBIMENTO
                                 INNER JOIN CONTABANCARIA ON (BAIXARECEBIMENTO.IDCONTABANCARIA = CONTABANCARIA.IDCONTABANCARIA)
                             WHERE BAIXARECEBIMENTO.IDCONTARECEBER = @IDCONTARECEBER";
                oSQL.ParamByName["IDCONTARECEBER"] = IDContaReceber;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}
