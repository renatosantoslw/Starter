using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using System;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesContaRecCobranca
    {
        public static ContaRecCobranca GetcontaRecCobranca(decimal IDContaCobranca, string NossoNumero, string NumeroDocumento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONTARECCOBRANCA,
IDCONTARECEBER,
EMISSAO,
VENCIMENTO,
VALOR,
NOSSONUMERO,
STATUS,
IDCONTACOBRANCA,
NUMERODOCUMENTO,
NUMEROCONTROLEPARTICIPANTE,
CANCELAMENTO 
                               FROM CONTARECCOBRANCA
                             WHERE IDCONTACOBRANCA = @IDCONTACOBRANCA
                               AND NOSSONUMERO = @NOSSONUMERO
                               AND NUMERODOCUMENTO = @NUMERODOCUMENTO";
                oSQL.ParamByName["IDCONTACOBRANCA"] = IDContaCobranca;
                oSQL.ParamByName["NOSSONUMERO"] = NossoNumero;
                oSQL.ParamByName["NUMERODOCUMENTO"] = NumeroDocumento;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<ContaRecCobranca>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static ContaRecCobranca GetContaRecCobranca(decimal IDContaRecCobranca)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONTARECCOBRANCA,
IDCONTARECEBER,
EMISSAO,
VENCIMENTO,
VALOR,
NOSSONUMERO,
STATUS,
IDCONTACOBRANCA,
NUMERODOCUMENTO,
NUMEROCONTROLEPARTICIPANTE,
CANCELAMENTO FROM CONTARECCOBRANCA WHERE IDCONTACOBRANCA = @IDCONTACOBRANCA";
                oSQL.ParamByName["IDCONTARECCOBRANCA"] = IDContaRecCobranca;
                oSQL.Open();
                return EntityUtil<ContaRecCobranca>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Salvar(ContaRecCobranca ContaRecCobranca, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO CONTARECCOBRANCA(IDCONTARECCOBRANCA, IDCONTARECEBER, EMISSAO, VENCIMENTO, VALOR, NOSSONUMERO, STATUS, IDCONTACOBRANCA, NUMERODOCUMENTO, NUMEROCONTROLEPARTICIPANTE, CANCELAMENTO)
                                       VALUES (@IDCONTARECCOBRANCA, @IDCONTARECEBER, @EMISSAO, @VENCIMENTO, @VALOR, @NOSSONUMERO, @STATUS, @IDCONTACOBRANCA, @NUMERODOCUMENTO, @NUMEROCONTROLEPARTICIPANTE, @CANCELAMENTO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CONTARECCOBRANCA
                                       SET  IDCONTARECCOBRANCA = @IDCONTARECCOBRANCA, 
                                            IDCONTARECEBER     = @IDCONTARECEBER, 
                                            EMISSAO            = @EMISSAO, 
                                            VENCIMENTO         = @VENCIMENTO, 
                                            VALOR              = @VALOR,
                                            NOSSONUMERO        = @NOSSONUMERO, 
                                            STATUS             = @STATUS, 
                                            IDCONTACOBRANCA    = @IDCONTACOBRANCA,
                                            NUMERODOCUMENTO    = @NUMERODOCUMENTO,
                                            CANCELAMENTO       = @CANCELAMENTO,
                                            NUMEROCONTROLEPARTICIPANTE = @NUMEROCONTROLEPARTICIPANTE
                                     WHERE IDCONTARECCOBRANCA  = @IDCONTARECCOBRANCA";
                        break;
                }
                oSQL.ParamByName["IDCONTARECCOBRANCA"] = ContaRecCobranca.IDContasRecobranca;
                oSQL.ParamByName["IDCONTARECEBER"] = ContaRecCobranca.IDContaReceber;
                oSQL.ParamByName["EMISSAO"] = ContaRecCobranca.Emissao;
                oSQL.ParamByName["VENCIMENTO"] = ContaRecCobranca.Vencimento;
                oSQL.ParamByName["VALOR"] = ContaRecCobranca.Valor;
                oSQL.ParamByName["NOSSONUMERO"] = ContaRecCobranca.NossoNumero;
                oSQL.ParamByName["STATUS"] = ContaRecCobranca.Status;
                oSQL.ParamByName["IDCONTACOBRANCA"] = ContaRecCobranca.IDContaCobranca;
                oSQL.ParamByName["NUMERODOCUMENTO"] = ContaRecCobranca.NumeroDocumento;
                oSQL.ParamByName["NUMEROCONTROLEPARTICIPANTE"] = ContaRecCobranca.NumeroControleParticipante;
                oSQL.ParamByName["CANCELAMENTO"] = ContaRecCobranca.Cancelamento;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDCONTARECCOBRANCA)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM CONTARECCOBRANCA WHERE IDCONTARECCOBRANCA = @IDCONTARECCOBRANCA";
                oSQL.ParamByName["IDCONTARECCOBRANCA"] = IDCONTARECCOBRANCA;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetDuplicatas(string Cliente, decimal IDContaBancaria,
            DateTime InicioEmissao, DateTime FimEmissao, DateTime InicioVencimento,
            DateTime FimVencimento, decimal IDFormaPagamento, decimal[] ArrayStatus)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT CONTARECEBER.IDCONTARECEBER,
                                    CONTARECCOBRANCA.IDCONTARECCOBRANCA,
                                    CASE 
                                       WHEN CONTARECEBER.IDCLIENTE IS NULL THEN 'Cliente Não Informado'
                                       WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.NOME
                                       WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.NOMEFANTASIA
                                    END AS CLIENTE,
                                    CONTARECEBER.PARCELA,
                                    CONTARECEBER.SALDO,
                                    CONTARECEBER.VALORTOTAL,
                                    COALESCE(CONTARECCOBRANCA.VALOR, 0) AS VALORDUPLICATA,
                                    CONTARECEBER.EMISSAO AS EMISSAOTITULO,
                                    CONTARECEBER.VENCIMENTO AS VENCIMENTOTITULO,
                                    CONTARECCOBRANCA.EMISSAO AS EMISSAODUPLICATA,
                                    CONTARECCOBRANCA.VENCIMENTO AS VENCIMENTODUPLICATA,
                                    CASE 
                                      WHEN TITULO IS NULL THEN ORIGEM
                                      ELSE ORIGEM+'-'+COALESCE(TITULO, '') 
                                    END AS ORIGEM,
                                    CASE
                                      WHEN CONTARECEBER.SITUACAO = 0 THEN 'CANCELADO'
                                      WHEN CONTARECEBER.SITUACAO = 1 THEN 'ABERTO'
                                      WHEN CONTARECEBER.SITUACAO = 2 THEN 'PARCIAL'
                                      WHEN CONTARECEBER.SITUACAO = 3 THEN 'BAIXADO'
                                    END AS SITUACAOTITULO,       
                                    CASE 
                                      WHEN COALESCE(CONTARECCOBRANCA.STATUS, 0) = 0 THEN 'Aberto'
                                      WHEN CONTARECCOBRANCA.STATUS = 1 THEN 'Impresso'
                                      WHEN CONTARECCOBRANCA.STATUS = 2 THEN 'Cancelado'
                                      WHEN CONTARECCOBRANCA.STATUS = 3 THEN 'Em Remessa'
                                      WHEN CONTARECCOBRANCA.STATUS = 4 THEN 'Baixado'
                                    END AS STATUSDUPLICATA,
                                    COALESCE(CONTARECCOBRANCA.STATUS, 0) AS STATUS
                               FROM CONTARECEBER
                                  LEFT JOIN CONTARECCOBRANCA ON CONTARECEBER.IDCONTARECEBER = CONTARECCOBRANCA.IDCONTARECEBER
                                 LEFT JOIN CLIENTE ON CONTARECEBER.IDCLIENTE = CLIENTE.IDCLIENTE
                               WHERE CONTARECEBER.VENCIMENTO BETWEEN @INICIOVENCIMENTOCONTARECEBER AND @FIMVENCIMENTOCONTARECEBER
                                 --AND COALESCE(CONTARECCOBRANCA.VENCIMENTO, CONTARECEBER.VENCIMENTO) BETWEEN @INICIOVENCIMENTOCONTARECCOBRANCA AND @FIMVENCIMENTOCONTARECCOBRANCA
                                 AND CONTARECEBER.EMISSAO BETWEEN @INICIOEMISSAOCONTARECEBER AND @FIMEMISSAOCONTACONTARECEBER
                                 --AND COALESCE(CONTARECCOBRANCA.EMISSAO, CONTARECEBER.EMISSAO) BETWEEN @INICIOEMISSAOCONTARECCOBRANCA AND @FIMEMISSAOCONTARECCOBRANCA
                                 AND (UPPER(COALESCE(CLIENTE.NOME, '')) LIKE UPPER('%{Cliente}%') OR UPPER(COALESCE(CLIENTE.NOMEFANTASIA, '')) LIKE UPPER('%{Cliente}%'))
                                -- AND CONTARECEBER.IDFORMADEPAGAMENTO = {IDFormaPagamento}
                                 AND (CONTARECEBER.IDCONTABANCARIA = @IDCONTABANCARIA OR CONTARECEBER.IDCONTABANCARIA IS NULL)
                                 AND CONTARECEBER.SITUACAO IN (1,2)
                              AND COALESCE(CONTARECCOBRANCA.STATUS, 0) IN ({string.Join(",", ArrayStatus)})
                             -- ORDER BY COALESCE(CONTARECCOBRANCA.EMISSAO, CONTARECEBER.EMISSAO) DESC, CONTARECEBER.PARCELA
";
                oSQL.ParamByName["INICIOVENCIMENTOCONTARECEBER"] = InicioVencimento;
                oSQL.ParamByName["FIMVENCIMENTOCONTARECEBER"] = FimVencimento;
               
                oSQL.ParamByName["INICIOVENCIMENTOCONTARECCOBRANCA"] = InicioVencimento;
                oSQL.ParamByName["FIMVENCIMENTOCONTARECCOBRANCA"] = FimVencimento;

                oSQL.ParamByName["INICIOEMISSAOCONTARECEBER"] = InicioEmissao;
                oSQL.ParamByName["FIMEMISSAOCONTACONTARECEBER"] = FimEmissao;

                oSQL.ParamByName["INICIOEMISSAOCONTARECCOBRANCA"] = InicioEmissao;
                oSQL.ParamByName["FIMEMISSAOCONTARECCOBRANCA"] = FimEmissao;
                oSQL.ParamByName["IDCONTABANCARIA"] = IDContaBancaria;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool UpdateStatus(decimal IDContaRecCobranca, decimal Status, DateTime? Cancelamento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE CONTARECCOBRANCA 
                                SET STATUS = @STATUS,
                                    CANCELAMENTO = @CANCELAMENTO
                             WHERE IDCONTARECCOBRANCA = @IDCONTARECCOBRANCA";
                oSQL.ParamByName["IDCONTARECCOBRANCA"] = IDContaRecCobranca;
                oSQL.ParamByName["STATUS"] = Status;
                oSQL.ParamByName["CANCELAMENTO"] = Cancelamento;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}