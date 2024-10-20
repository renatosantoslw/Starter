using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesPortaria
    {
        public static bool Remover(decimal IDPortaria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM PORTARIA WHERE IDPORTARIA = @IDPORTARIA";
                oSQL.ParamByName["IDPORTARIA"] = IDPortaria;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Existe(decimal IDPortaria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PORTARIA WHERE IDPORTARIA = @IDPORTARIA";
                oSQL.ParamByName["IDPORTARIA"] = IDPortaria;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool Salvar(Portaria Port, TipoOperacao Operacao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Operacao)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = "INSERT INTO PORTARIA (IDPORTARIA, TITULO, DESCRICAO) VALUES (@IDPORTARIA, @TITULO, @DESCRICAO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE PORTARIA SET TITULO = @TITULO, DESCRICAO = @DESCRICAO WHERE IDPORTARIA = @IDPORTARIA";
                        break;
                }
                oSQL.ParamByName["IDPORTARIA"] = Port.IDPortaria;
                oSQL.ParamByName["TITULO"] = Port.Titulo;
                oSQL.ParamByName["DESCRICAO"] = Port.Descricao;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetPortarias(string Titulo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = string.Format("SELECT IDPORTARIA,TITULO,DESCRICAO FROM PORTARIA WHERE UPPER(TITULO) LIKE '%{0}%'", Titulo.ToUpper());
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<Portaria> GetPortarias()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDPORTARIA,
TITULO,
DESCRICAO FROM PORTARIA";
                oSQL.Open();
                return new DataTableParser<Portaria>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static Portaria GetPortaria(decimal IDPortaria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDPORTARIA,
TITULO,
DESCRICAO FROM PORTARIA WHERE IDPORTARIA = @IDPORTARIA";
                oSQL.ParamByName["IDPORTARIA"] = IDPortaria;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Portaria>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
    }
}
