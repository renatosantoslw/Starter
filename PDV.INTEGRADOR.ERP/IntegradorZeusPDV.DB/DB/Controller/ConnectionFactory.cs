using IntegradorZeusPDV.DB.DB.Utils;
using Npgsql;
using System;
using System.Data;

namespace IntegradorZeusPDV.DB.DB.Controller
{
    public static class ConnectionFactory
    {
        public static IDbConnection CreateConnection(string ConnectionString)
        {
            return new NpgsqlConnection(ConnectionString);
        }

        public static string CreateConnectionString(DataRow drConexao)
        {
            string usuario = drConexao["USUARIO"].ToString();
            string senha = Criptografia.DecodificaSenha(drConexao["SENHA"].ToString());
            string sgbd = drConexao["SGBD"].ToString().ToUpper();
            string formato_data = drConexao["FORMATO_DATA"].ToString();
            string usar_upper = drConexao["USAR_UPPER"].ToString();
            string schema = drConexao["SCHEMA"].ToString();
            string nao_usar_tab_sistema = drConexao["NAO_USAR_TAB_SISTEMA"].ToString();
            string database_name = drConexao["DATABASE_NAME"].ToString();
            string servidor = drConexao["SERVIDOR"].ToString();
            string dsn = drConexao["DSN"].ToString();
            string charSet = drConexao["CHAR_SET"] == DBNull.Value ? "utf8" : drConexao["CHAR_SET"].ToString();
            int porta = !string.IsNullOrEmpty(drConexao["PORTA"].ToString()) ?
                        Convert.ToInt32(drConexao["PORTA"]) :
                        0;
            int auth_windows = !string.IsNullOrEmpty(drConexao["AUTH_WINDOWS"].ToString()) ?
                                Convert.ToInt32(drConexao["AUTH_WINDOWS"]) :
                                0;

            string connectionString = "";
            string MaxPoolSize = Controlador.IniFile != null ? Controlador.IniFile.GetValue("Geral", "max_pool_size", "100") : "100";

            if (porta == 0)
                porta = 5432;

            return connectionString = String.Format("Server={0};Port={1};Database={2};User Id={3};Password={4};CommandTimeout=0;", servidor, porta, database_name, usuario, senha);
        }
    }
}
