using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;

namespace PDV.CONTROLER.FuncoesAndroid
{
    public class FuncoesConfiguracao
    {
        public static Configuracao GetConfiguracao(string Chave)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT C.* FROM CONFIGURACAO C WHERE CHAVE = @CHAVE";
                oSQL.ParamByName["CHAVE"] = Chave;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Configuracao>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
    }
}
