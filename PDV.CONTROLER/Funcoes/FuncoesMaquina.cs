using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;

namespace PDV.CONTROLER.Funcoes
{
    public static class FuncoesMaquina
    {
        public static bool Salvar(Maquina maquina)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                if (Existe(maquina.Descricao))
                    oSQL.SQL = @"UPDATE MAQUINA 
                                        SET ULTIMOLOGIN = @ULTIMOLOGIN 
                                        WHERE DESCRICAO = @DESCRICAO";
                else
                {
                    oSQL.SQL = @"INSERT INTO 
                                        MAQUINA (IDMAQUINA, DESCRICAO, ULTIMOLOGIN) 
                                        VALUES (@IDMAQUINA, @DESCRICAO, @ULTIMOLOGIN)";
                    oSQL.ParamByName["IDMAQUINA"] = Sequence.GetNextID("MAQUINA", "IDMAQUINA");
                }                   
               
                oSQL.ParamByName["DESCRICAO"] = maquina.Descricao;
                oSQL.ParamByName["ULTIMOLOGIN"] = maquina.UltimoLogin;

                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Existe(string descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDMAQUINA,
DESCRICAO,
ULTIMOLOGIN FROM MAQUINA WHERE DESCRICAO = @DESCRICAO";
                oSQL.ParamByName["DESCRICAO"] = descricao;
                oSQL.Open();
                return oSQL.dtDados.Rows.Count > 0;
            }
        }

        public static Maquina GetMaquina(string descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT IDMAQUINA, DESCRICAO, ULTIMOLOGIN FROM MAQUINA WHERE DESCRICAO = @DESCRICAO";
                oSQL.ParamByName["DESCRICAO"] = descricao;
                oSQL.Open();

                if (oSQL.dtDados.Rows.Count == 0)
                    return null;
                return new DataTableParser<Maquina>().ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
    }
}
