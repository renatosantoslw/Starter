using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.DAO.Enum;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesMotivoCancelamento
    {
        public static bool Salvar(MotivoCancelamento Motivo, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO MOTIVOCANCELAMENTO (IDMOTIVOCANCELAMENTO, NOME, TIPO) VALUES (@IDMOTIVOCANCELAMENTO, @NOME, @TIPO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE MOTIVOCANCELAMENTO
                                      SET NOME = @NOME,
                                          TIPO = @TIPO
                                      WHERE IDMOTIVOCANCELAMENTO = @IDMOTIVOCANCELAMENTO";
                        break;
                }
                oSQL.ParamByName["IDMOTIVOCANCELAMENTO"] = Motivo.IDMotivoCancelamento;
                oSQL.ParamByName["NOME"] = Motivo.Nome;
                oSQL.ParamByName["TIPO"] = Motivo.Tipo;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDMotivoCancelamento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM MOTIVOCANCELAMENTO WHERE IDMOTIVOCANCELAMENTO = @IDMOTIVOCANCELAMENTO";
                oSQL.ParamByName["IDMOTIVOCANCELAMENTO"] = IDMotivoCancelamento;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static MotivoCancelamento GetMotivo(decimal IDMotivoCancelamento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDMOTIVOCANCELAMENTO,
NOME,
TIPO FROM MOTIVOCANCELAMENTO WHERE IDMOTIVOCANCELAMENTO = @IDMOTIVOCANCELAMENTO";
                oSQL.ParamByName["IDMOTIVOCANCELAMENTO"] = IDMotivoCancelamento;
                oSQL.Open();
                return EntityUtil<MotivoCancelamento>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetMotivos(string Nome)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT MOTIVOCANCELAMENTO.NOME,
                                     CASE
                                       WHEN MOTIVOCANCELAMENTO.TIPO = 0 THEN 'Compra'
                                       WHEN MOTIVOCANCELAMENTO.TIPO = 1 THEN 'Venda'
                                     END AS TIPOCANCELAMENTO,
                                     MOTIVOCANCELAMENTO.IDMOTIVOCANCELAMENTO,
                                     MOTIVOCANCELAMENTO.TIPO
                                FROM MOTIVOCANCELAMENTO
                              WHERE UPPER(NOME) LIKE UPPER('%{Nome}%')";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Existe(decimal IDMotivoCancelamento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM MOTIVOCANCELAMENTO WHERE IDMOTIVOCANCELAMENTO = @IDMOTIVOCANCELAMENTO";
                oSQL.ParamByName["IDMOTIVOCANCELAMENTO"] = IDMotivoCancelamento;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
    }
}
