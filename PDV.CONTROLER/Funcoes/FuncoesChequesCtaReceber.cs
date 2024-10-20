using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesChequesCtaReceber
    {
        public static bool Existe(decimal IDCHEQUECONTARECEBER)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CHEQUECONTARECEBER WHERE IDCHEQUECONTARECEBER = @IDCHEQUECONTARECEBER";
                oSQL.ParamByName["IDCHEQUECONTARECEBER"] = IDCHEQUECONTARECEBER;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
        
        public static DataTable GetChequeContaReceber(decimal IDBaixaRecebimento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CHEQUECONTARECEBER.IDCHEQUECONTARECEBER,
                                    CHEQUECONTARECEBER.NUMERO,
                                    CHEQUECONTARECEBER.EMISSAO,
                                    CHEQUECONTARECEBER.VENCIMENTO,
                                    CHEQUECONTARECEBER.VALOR,
                             
                                    CHEQUECONTARECEBER.CRUZADO,
                                    CHEQUECONTARECEBER.COMPENSADO,
                                    CHEQUECONTARECEBER.DATACOMPENSACAO,
                                    CHEQUECONTARECEBER.DEVOLVIDO,
                                    CHEQUECONTARECEBER.DATADEVOLUCAO,
                                    CHEQUECONTARECEBER.REPASSE,
                                    CHEQUECONTARECEBER.DATAREPASSE,
                                    CHEQUECONTARECEBER.OBSREPASSE,
                                    CHEQUECONTARECEBER.IDBAIXARECEBIMENTO
                               FROM CHEQUECONTARECEBER
                             WHERE CHEQUECONTARECEBER.IDBAIXARECEBIMENTO = @IDBAIXARECEBIMENTO";
                oSQL.ParamByName["IDBAIXARECEBIMENTO"] = IDBaixaRecebimento;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Salvar(ChequeContaReceber chequeContaReceber, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO CHEQUECONTARECEBER(IDCHEQUECONTARECEBER, 
                                                                    IDBAIXARECEBIMENTO, 
                                                                    NUMERO, 
                                                                    VALOR, 
                                                                    EMISSAO, 
                                                                    VENCIMENTO, 
                                                                    CRUZADO,
                                                                    COMPENSADO, 
                                                                    DATACOMPENSACAO, 
                                                                    DEVOLVIDO, 
                                                                    DATADEVOLUCAO, 
                                                                    REPASSE, 
                                                                    DATAREPASSE, 
                                                                    OBSREPASSE)
                                       VALUES (@IDCHEQUECONTARECEBER,
                                               @IDBAIXARECEBIMENTO, 
                                               @NUMERO, 
                                               @VALOR, 
                                               @EMISSAO, 
                                               @VENCIMENTO, 
                                               @CRUZADO, 
                                               @COMPENSADO, 
                                               @DATACOMPENSACAO, 
                                               @DEVOLVIDO, 
                                               @DATADEVOLUCAO, 
                                               @REPASSE, 
                                               @DATAREPASSE, 
                                               @OBSREPASSE)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CHEQUECONTARECEBER
                                       SET  IDCHEQUECONTARECEBER  = @IDCHEQUECONTARECEBER,                                               
                                            IDBAIXARECEBIMENTO = @IDBAIXARECEBIMENTO, 
                                            NUMERO           = @NUMERO, 
                                            VALOR            = @VALOR, 
                                            EMISSAO          = @EMISSAO, 
                                            VENCIMENTO       = @VENCIMENTO, 
                                            CRUZADO          = @CRUZADO, 
                                            COMPENSADO       = @COMPENSADO, 
                                            DATACOMPENSACAO  = @DATACOMPENSACAO, 
                                            DEVOLVIDO        = @DEVOLVIDO, 
                                            DATADEVOLUCAO    = @DATADEVOLUCAO,
                                            REPASSE          = @REPASSE, 
                                            DATAREPASSE      = @DATAREPASSE,
                                            OBSREPASSE       = @OBSREPASSE
                                     WHERE IDCHEQUECONTARECEBER = @IDCHEQUECONTARECEBER";
                        break;
                }
                oSQL.ParamByName["IDCHEQUECONTARECEBER"] = chequeContaReceber.IDChequeContaReceber;
                oSQL.ParamByName["IDBAIXARECEBIMENTO"] = chequeContaReceber.IDBaixaRecebimento;
                oSQL.ParamByName["NUMERO"] = chequeContaReceber.Numero;
                oSQL.ParamByName["VALOR"] = chequeContaReceber.Valor;
                oSQL.ParamByName["EMISSAO"] = chequeContaReceber.Emissao;
                oSQL.ParamByName["VENCIMENTO"] = chequeContaReceber.Vencimento;
                oSQL.ParamByName["CRUZADO"] = chequeContaReceber.Cruzado;
                oSQL.ParamByName["COMPENSADO"] = chequeContaReceber.Compensado;
                oSQL.ParamByName["DATACOMPENSACAO"] = chequeContaReceber.DataCompensacao;
                oSQL.ParamByName["DEVOLVIDO"] = chequeContaReceber.Devolvido;
                oSQL.ParamByName["DATADEVOLUCAO"] = chequeContaReceber.DataDevolucao;
                oSQL.ParamByName["REPASSE"] = chequeContaReceber.Repasse;
                oSQL.ParamByName["DATAREPASSE"] = chequeContaReceber.DataRepasse;
                oSQL.ParamByName["OBSREPASSE"] = chequeContaReceber.ObsRepasse;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDCHEQUECONTARECEBER)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM CHEQUECONTARECEBER WHERE IDCHEQUECONTARECEBER = @IDCHEQUECONTARECEBER";
                oSQL.ParamByName["IDCHEQUECONTARECEBER"] = IDCHEQUECONTARECEBER;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
