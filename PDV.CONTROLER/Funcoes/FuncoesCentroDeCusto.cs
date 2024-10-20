using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesCentroCusto
    {
        public static bool Salvar(CentroCusto _Tipo, TipoOperacao Tipo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Tipo)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO 
                                       CENTROCUSTO (IDCENTROCUSTO, DESCRICAO, SIGLA, TIPODEMOVIMENTO)
                                     VALUES (@IDCENTROCUSTO, @DESCRICAO, @SIGLA, @TIPODEMOVIMENTO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CENTROCUSTO
                                       SET DESCRICAO = @DESCRICAO,
                                           SIGLA = @SIGLA,
                                           TIPODEMOVIMENTO = @TIPODEMOVIMENTO
                                       WHERE IDCENTROCUSTO = @IDCENTROCUSTO";
                        break;
                }
                oSQL.ParamByName["IDCENTROCUSTO"] = _Tipo.IDCentroCusto;
                oSQL.ParamByName["DESCRICAO"] = _Tipo.Descricao;
                oSQL.ParamByName["SIGLA"] = _Tipo.Sigla;
                oSQL.ParamByName["TIPODEMOVIMENTO"] = _Tipo.TipoDeMovimento;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal idCentro)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM CENTROCUSTO WHERE IDCENTROCUSTO = @IDCENTROCUSTO";
                oSQL.ParamByName["IDCENTROCUSTO"] = idCentro;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetCentroCusto(string Descricao, string Sigla)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UPPER(DESCRICAO) LIKE UPPER('%{0}%'))", Descricao));

                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UPPER(SIGLA) LIKE UPPER('%{0}%'))", Sigla));

                oSQL.SQL = string.Format(@"SELECT IDCENTROCUSTO,
DESCRICAO,
SIGLA,
TIPODEMOVIMENTO FROM CENTROCUSTO {0} ORDER BY DESCRICAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Existe(decimal idCentro)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CENTROCUSTO WHERE IDCENTROCUSTO = @IDCENTROCUSTO";
                oSQL.ParamByName["IDCENTROCUSTO"] = idCentro;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static List<CentroCusto> GetCentrosCusto()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCENTROCUSTO,
DESCRICAO,
SIGLA,
TIPODEMOVIMENTO FROM CENTROCUSTO";
                oSQL.Open();
                return new DataTableParser<CentroCusto>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<CentroCusto> GetCentrosCusto(int tipoDeMovimento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCENTROCUSTO,
DESCRICAO,
SIGLA,
TIPODEMOVIMENTO FROM CENTROCUSTO WHERE TIPODEMOVIMENTO = @TIPODEMOVIMENTO";
                oSQL.ParamByName["TIPODEMOVIMENTO"] = tipoDeMovimento;
                oSQL.Open();
                return new DataTableParser<CentroCusto>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static CentroCusto GetCentroCusto(decimal idCentro)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCENTROCUSTO,
DESCRICAO,
SIGLA,
TIPODEMOVIMENTO FROM CENTROCUSTO WHERE IDCENTROCUSTO = @IDCENTROCUSTO";
                oSQL.ParamByName["IDCENTROCUSTO"] = idCentro;
                oSQL.Open();
                return EntityUtil<CentroCusto>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }


    }
}
