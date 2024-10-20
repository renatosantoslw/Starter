using PDV.DAO.DB.Controller;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesAtualizador
    {
        public static void ExecutaNonQuery(string InstrucaoSQL)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = InstrucaoSQL;
                oSQL.ExecSQL();
            }
        }
    }
}