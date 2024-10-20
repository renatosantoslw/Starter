using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.NFe;
using System.Collections.Generic;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesFinalidade
    {
        public static Finalidade GetFinalidade(decimal IDFinalidade)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDFINALIDADE,
CODIGO,
DESCRICAO FROM FINALIDADE WHERE IDFINALIDADE = @IDFINALIDADE";
                oSQL.ParamByName["IDFINALIDADE"] = IDFinalidade;
                oSQL.Open();
                return EntityUtil<Finalidade>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static List<Finalidade> GetFinalidades()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDFINALIDADE,
CODIGO,
DESCRICAO FROM FINALIDADE";
                oSQL.Open();
                return new DataTableParser<Finalidade>().ParseDataTable(oSQL.dtDados);
            }
        }
    }
}
