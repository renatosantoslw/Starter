using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.NFe;
using System.Collections.Generic;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesTipoAtendimento
    {
        public static TipoAtendimento GetTipoAtendimento(decimal IDTipoAtendimento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDTIPOATENDIMENTO,
CODIGO,
DESCRICAO FROM TIPOATENDIMENTO WHERE IDTIPOATENDIMENTO = @IDTIPOATENDIMENTO";
                oSQL.ParamByName["IDTIPOATENDIMENTO"] = IDTipoAtendimento;
                oSQL.Open();
                return EntityUtil<TipoAtendimento>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static List<TipoAtendimento> GetTiposAtendimento()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDTIPOATENDIMENTO,
CODIGO,
DESCRICAO FROM TIPOATENDIMENTO";
                oSQL.Open();
                return new DataTableParser<TipoAtendimento>().ParseDataTable(oSQL.dtDados);
            }
        }
    }
}
