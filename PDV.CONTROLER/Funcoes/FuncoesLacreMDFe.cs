using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.MDFe;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesLacreMDFe
    {
        public static bool Salvar(LacreRodoviarioMDFe Lacre)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "INSERT INTO LACRERODOVIARIOMDFE (IDLACRERODOVIARIOMDFE, IDMDFE, NUMERO) VALUES (@IDLACRERODOVIARIOMDFE, @IDMDFE, @NUMERO)";
                oSQL.ParamByName["IDLACRERODOVIARIOMDFE"] = Lacre.IDLacreRodoviarioMDFe;
                oSQL.ParamByName["IDMDFE"] = Lacre.IDMDFe;
                oSQL.ParamByName["NUMERO"] = Lacre.Numero;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDLacreRodoviarioMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM LACRERODOVIARIOMDFE WHERE IDLACRERODOVIARIOMDFE = @IDLACRERODOVIARIOMDFE";
                oSQL.ParamByName["IDLACRERODOVIARIOMDFE"] = IDLacreRodoviarioMDFe;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return true;

                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM LACRERODOVIARIOMDFE WHERE IDLACRERODOVIARIOMDFE = @IDLACRERODOVIARIOMDFE";
                oSQL.ParamByName["IDLACRERODOVIARIOMDFE"] = IDLacreRodoviarioMDFe;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetLacresPorMDFe(decimal IDMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDLACRERODOVIARIOMDFE,
IDMDFE,
NUMERO FROM LACRERODOVIARIOMDFE WHERE IDMDFE = @IDMDFE ORDER BY NUMERO";
                oSQL.ParamByName["IDMDFE"] = IDMDFe;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}
