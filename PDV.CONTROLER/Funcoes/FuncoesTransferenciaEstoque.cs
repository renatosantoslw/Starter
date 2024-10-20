using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Estoque.Transferencia;
using PDV.DAO.Enum;
using System;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesTransferenciaEstoque
    {
        public static bool Salvar(TransferenciaEstoque Transf, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch(Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO TRANSFERENCIAESTOQUE 
                                       (IDTRANSFERENCIAESTOQUE, DATATRANSFERENCIA, OBSERVACAO)
                                     VALUES (@IDTRANSFERENCIAESTOQUE, @DATATRANSFERENCIA, @OBSERVACAO)";
                        oSQL.ParamByName["DATATRANSFERENCIA"] = Transf.DataTransferencia;
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = "UPDATE TRANSFERENCIAESTOQUE SET OBSERVACAO = @OBSERVACAO WHERE IDTRANSFERENCIAESTOQUE = @IDTRANSFERENCIAESTOQUE";
                        break;
                }
                oSQL.ParamByName["IDTRANSFERENCIAESTOQUE"] = Transf.IDTransferenciaEstoque;
                oSQL.ParamByName["OBSERVACAO"] = Transf.Observacao;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDTransferenciaEstoque)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM TRANSFERENCIAESTOQUE WHERE IDTRANSFERENCIAESTOQUE = @IDTRANSFERENCIAESTOQUE";
                oSQL.ParamByName["IDTRANSFERENCIAESTOQUE"] = IDTransferenciaEstoque;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static TransferenciaEstoque GetTransferencia(decimal IDTransferenciaEstoque)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDTRANSFERENCIAESTOQUE,
DATATRANSFERENCIA,
OBSERVACAO FROM TRANSFERENCIAESTOQUE WHERE IDTRANSFERENCIAESTOQUE = @IDTRANSFERENCIAESTOQUE";
                oSQL.ParamByName["IDTRANSFERENCIAESTOQUE"] = IDTransferenciaEstoque;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<TransferenciaEstoque>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetTransferencia(DateTime DataInicio, DateTime DataFim)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDTRANSFERENCIAESTOQUE,
DATATRANSFERENCIA,
OBSERVACAO FROM TRANSFERENCIAESTOQUE WHERE DATATRANSFERENCIA BETWEEN @INICIO AND @FIM";
                oSQL.ParamByName["INICIO"] = DataInicio;
                oSQL.ParamByName["FIM"] = DataFim;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}
