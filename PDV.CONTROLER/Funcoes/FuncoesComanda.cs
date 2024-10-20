using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesComanda
    {
        public static bool Salvar(Comanda _Comanda, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = "INSERT INTO COMANDA (IDCOMANDA, CODIGO, DESCRICAO) VALUES (@IDCOMANDA, @CODIGO, @DESCRICAO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE COMANDA
                                      SET CODIGO = @CODIGO,
                                          DESCRICAO = @DESCRICAO
                                      WHERE IDCOMANDA = @IDCOMANDA";
                        break;
                }
                oSQL.ParamByName["IDCOMANDA"] = _Comanda.IDComanda;
                oSQL.ParamByName["CODIGO"] = _Comanda.Codigo;
                oSQL.ParamByName["DESCRICAO"] = _Comanda.Descricao;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool AtualizaStatusComanda(decimal? IDComanda , string Abrir)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                if (Abrir == "1")
                {
                    oSQL.SQL = @"UPDATE COMANDA SET STATUS = '1' WHERE IDCOMANDA = @IDCOMANDA";
                    oSQL.ParamByName["IDCOMANDA"] = IDComanda;
                    oSQL.Open();
                    return oSQL.ExecSQL() == 1;
                }
                else
                {
                    oSQL.SQL = @"UPDATE COMANDA SET STATUS = null WHERE IDCOMANDA = @IDCOMANDA";
                    oSQL.ParamByName["IDCOMANDA"] = IDComanda;
                    oSQL.Open();
                    return oSQL.ExecSQL() == 1;
                }
            }
        }


        public static bool Remover(decimal IDComanda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                // Validar quando remover.

                oSQL.SQL = @"DELETE FROM COMANDA WHERE IDCOMANDA = @IDCOMANDA";
                oSQL.ParamByName["IDCOMANDA"] = IDComanda;
                oSQL.Open();
                return oSQL.ExecSQL() == 1;
            }
        }
        public static bool RemoverTudo()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                // Validar quando remover.

                oSQL.SQL = @"DELETE FROM COMANDA ";
                oSQL.Open();
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetComandas(string Codigo, string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Codigo))
                    Filtros.Add(string.Format("(UPPER(CODIGO) LIKE UPPER('%{0}%'))", Codigo));

                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UPPER(DESCRICAO) LIKE UPPER('%{0}%'))", Descricao));

                oSQL.SQL = string.Format("SELECT IDCOMANDA, CODIGO, DESCRICAO FROM COMANDA {0} ORDER BY CODIGO, DESCRICAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetComandasAberta(string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT COMANDA.IDCOMANDA,
                                     COMANDA.CODIGO,
                                     COMANDA.DESCRICAO
                                FROM COMANDA
                              WHERE (UPPER(COMANDA.CODIGO) LIKE UPPER('%{Descricao}%')
                                OR UPPER(COMANDA.DESCRICAO) LIKE UPPER('%{Descricao}%'))
                              AND COMANDA.IDCOMANDA NOT IN (SELECT COALESCE(VENDA.IDCOMANDA , -1)
                                                              FROM VENDA 
                                                            WHERE VENDA.IDCOMANDAUTILIZADA IS NULL
                                                              AND VENDA.IDVENDA NOT IN (SELECT IDVENDA FROM DUPLICATANFCE))";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static Comanda GetComanda(decimal? IDComanda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT IDCOMANDA, CODIGO, DESCRICAO FROM COMANDA WHERE IDCOMANDA = @IDCOMANDA";
                oSQL.ParamByName["IDCOMANDA"] = IDComanda;
                oSQL.Open();

                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Comanda>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static List<Comanda> GetComandaLista()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCOMANDA, CONVERT(INT,CODIGO)AS CODIGO, DESCRICAO, STATUS FROM COMANDA ORDER BY CODIGO";

                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Comanda>.ParseDataTable(oSQL.dtDados);
            }
        }


        public static bool ExistePorCodigo(string Codigo, decimal IDComanda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM COMANDA WHERE CODIGO = @CODIGO AND IDCOMANDA <> @IDCOMANDA";
                oSQL.ParamByName["CODIGO"] = Codigo;
                oSQL.ParamByName["IDCOMANDA"] = IDComanda;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool Existe(decimal IDComanda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM COMANDA WHERE IDCOMANDA = @IDCOMANDA";
                oSQL.ParamByName["IDCOMANDA"] = IDComanda;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
    }
}
