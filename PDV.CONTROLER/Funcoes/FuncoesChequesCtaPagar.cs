using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesChequesCtaPagar
    {
        public static bool Existe(decimal IDCHEQUECONTAPAGAR)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CHEQUECONTAPAGAR WHERE IDCHEQUECONTAPAGAR = @IDCHEQUECONTAPAGAR";
                oSQL.ParamByName["IDCHEQUECONTAPAGAR"] = IDCHEQUECONTAPAGAR;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
        public static DataTable GetChequeContaPagar(decimal IDBaixaPagamento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CHEQUECONTAPAGAR.IDCHEQUECONTAPAGAR,
                                    CHEQUECONTAPAGAR.NUMERO,
                                    CHEQUECONTAPAGAR.EMISSAO,
                                    CHEQUECONTAPAGAR.VENCIMENTO,
                                    CHEQUECONTAPAGAR.VALOR,
                             
                                    CHEQUECONTAPAGAR.CRUZADO,
                                    CHEQUECONTAPAGAR.COMPENSADO,
                                    CHEQUECONTAPAGAR.DATACOMPENSACAO,
                                    CHEQUECONTAPAGAR.DEVOLVIDO,
                                    CHEQUECONTAPAGAR.DATADEVOLUCAO,
                                    CHEQUECONTAPAGAR.IDBAIXAPAGAMENTO,
                                    CHEQUECONTAPAGAR.IDTALONARIO
                               FROM CHEQUECONTAPAGAR
                             WHERE CHEQUECONTAPAGAR.IDBAIXAPAGAMENTO = @IDBAIXAPAGAMENTO";
                oSQL.ParamByName["IDBAIXAPAGAMENTO"] = IDBaixaPagamento;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Salvar(ChequeContaPagar chequeContaPagar, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO CHEQUECONTAPAGAR(IDCHEQUECONTAPAGAR, IDTALONARIO, IDBAIXAPAGAMENTO, 
                                                                  NUMERO, VALOR, EMISSAO, VENCIMENTO, CRUZADO, COMPENSADO, DATACOMPENSACAO, DEVOLVIDO, DATADEVOLUCAO)
                                       VALUES (@IDCHEQUECONTAPAGAR, @IDTALONARIO, @IDBAIXAPAGAMENTO, 
                                               @NUMERO, @VALOR, @EMISSAO, @VENCIMENTO, @CRUZADO, @COMPENSADO, @DATACOMPENSACAO, @DEVOLVIDO, @DATADEVOLUCAO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CHEQUECONTAPAGAR
                                       SET  IDCHEQUECONTAPAGAR = @IDCHEQUECONTAPAGAR, 
                                                IDTALONARIO = @IDTALONARIO, 
                                                IDBAIXAPAGAMENTO = @IDBAIXAPAGAMENTO, 
                                                NUMERO = @NUMERO, 
                                                VALOR = @VALOR, 
                                                EMISSAO = @EMISSAO, 
                                                VENCIMENTO = @VENCIMENTO, 
                                                CRUZADO = @CRUZADO, 
                                                COMPENSADO = @COMPENSADO, 
                                                DATACOMPENSACAO = @DATACOMPENSACAO, 
                                                DEVOLVIDO = @DEVOLVIDO, 
                                                DATADEVOLUCAO = @DATADEVOLUCAO
                                     WHERE IDCHEQUECONTAPAGAR = @IDCHEQUECONTAPAGAR";
                        break;
                }
                oSQL.ParamByName["IDCHEQUECONTAPAGAR"] = chequeContaPagar.IDChequeContaPagar;
                oSQL.ParamByName["IDTALONARIO"] = chequeContaPagar.IDTalonario;
                oSQL.ParamByName["IDBAIXAPAGAMENTO"] = chequeContaPagar.IDBaixaPagamento;
                oSQL.ParamByName["NUMERO"] = chequeContaPagar.Numero;
                oSQL.ParamByName["VALOR"] = chequeContaPagar.Valor;
                oSQL.ParamByName["EMISSAO"] = chequeContaPagar.Emissao;
                oSQL.ParamByName["VENCIMENTO"] = chequeContaPagar.Vencimento;
                oSQL.ParamByName["CRUZADO"] = chequeContaPagar.Cruzado;
                oSQL.ParamByName["COMPENSADO"] = chequeContaPagar.Compensado;
                oSQL.ParamByName["DATACOMPENSACAO"] = chequeContaPagar.DataCompensacao;
                oSQL.ParamByName["DEVOLVIDO"] = chequeContaPagar.Devolvido;
                oSQL.ParamByName["DATADEVOLUCAO"] = chequeContaPagar.DataDevolucao;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDChequeContaPagar)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM CHEQUECONTAPAGAR WHERE IDCHEQUECONTAPAGAR = @IDCHEQUECONTAPAGAR";
                oSQL.ParamByName["IDCHEQUECONTAPAGAR"] = IDChequeContaPagar;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
