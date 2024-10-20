using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.DAO.Enum;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesRequisitante
    {
        public static bool Salvar(Requisitante Req, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO REQUISITANTE
                                       (IDREQUISITANTE, IDCENTROCUSTO, NOME)
                                     VALUES
                                       (@IDREQUISITANTE, @IDCENTROCUSTO, @NOME)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE REQUISITANTE
                                       SET IDCENTROCUSTO = @IDCENTROCUSTO,
                                           NOME = @NOME
                                       WHERE IDREQUISITANTE = @IDREQUISITANTE";
                        break;
                }
                oSQL.ParamByName["IDREQUISITANTE"] = Req.IDRequisitante;
                oSQL.ParamByName["NOME"] = Req.Nome;
                oSQL.ParamByName["IDCENTROCUSTO"] = Req.IDCentroCusto;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDRequisitante)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM REQUISITANTE WHERE IDREQUISITANTE = @IDREQUISITANTE";
                oSQL.ParamByName["IDREQUISITANTE"] = IDRequisitante;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Existe(decimal IDRequisitante)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM REQUISITANTE WHERE IDREQUISITANTE = @IDREQUISITANTE";
                oSQL.ParamByName["IDREQUISITANTE"] = IDRequisitante;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static Requisitante GetRequisitante(decimal IDRequisitante)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDREQUISITANTE,
NOME,
IDCENTROCUSTO FROM REQUISITANTE WHERE IDREQUISITANTE = @IDREQUISITANTE";
                oSQL.ParamByName["IDREQUISITANTE"] = IDRequisitante;
                oSQL.Open();
                return EntityUtil<Requisitante>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetRequisitantes(string Nome)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT REQUISITANTE.NOME,
                                     CENTROCUSTO.DESCRICAO AS CENTROCUSTO,
                              
                                     REQUISITANTE.IDREQUISITANTE,
                                     REQUISITANTE.IDCENTROCUSTO
                                FROM REQUISITANTE
                                 INNER JOIN CENTROCUSTO ON (REQUISITANTE.IDCENTROCUSTO = CENTROCUSTO.IDCENTROCUSTO)
                              WHERE UPPER(REQUISITANTE.NOME) LIKE UPPER('%{Nome}%')";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}
