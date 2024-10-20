using PDV.DAO.DB.Controller;
using System;
using System.Collections;
using System.Linq;
using System.Diagnostics;

namespace PDV.DAO.DB.Utils
{
    public class Sequence
    {
        private static Hashtable HashSequences = new Hashtable();

        private static string GetCreateSequence(string Name, decimal Next)
        {
            return string.Format("CREATE SEQUENCE {0} START WITH {1} INCREMENT BY 1", Name.ToUpper().Trim(), Next);
        }

        private static string GetMaxStatement(string Table, string Field)
        {
            return string.Format("SELECT COALESCE(MAX({0}) + 1, 1) FROM {1}", Field, Table);
        }

        private static bool SequenceExists(string Key)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                try
                {
                    oSQL.SQL = string.Format("select * from sys.sequences where object_id = object_id ('{0}')", Key);
                   // select * from sys.sequences where object_id = object_id('IDCONTARECEBER')
                    oSQL.Open();
                    return oSQL.dtDados.Rows.Count > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static int GetMaxID(string Table, string Field)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                try
                {
                    oSQL.SQL = GetMaxStatement(Table, Field);
                    oSQL.Open();

                    int id = Convert.ToInt32(oSQL.dtDados.Rows[0][0]);
                    if (id < 1)
                        throw new Exception();
                    return id;
                }
                catch
                {
                    return 1;
                }
            }
        }

        public static int GetNextID(string Table, string Field = "")
        {
            try
            {
                if (string.IsNullOrEmpty(Field))
                    Field = "ID" + Table;

                if (!HashSequences.Contains(Field))
                    if (SequenceExists(Field))
                        HashSequences.Add(Field, Table);

                using (SQLQuery oSQL = new SQLQuery())
                {
                    if (HashSequences.Contains(Field))
                    {
                        oSQL.SQL = string.Format("SELECT NEXT VALUE FOR {0}", Field.ToUpper().Trim());
                        
                  
                        oSQL.Open();

                        return Convert.ToInt32(oSQL.dtDados.Rows[0][0]);
                    }
                    else
                    {
                        oSQL.SQL = GetCreateSequence(Field, GetMaxID(Table, Field));
                        oSQL.ExecSQL();

                        return GetNextID(Table, Field);
                    }
                }
            }
            catch  (Exception ex)
            {
                return 1;
            }
        }


        public static bool AtualizarValorSequence(string NomeSequence, decimal Valor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                //2019  oSQL.SQL = "DROP SEQUENCE IF EXISTS " + NomeSequence;
                oSQL.SQL = "IF EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].["+ NomeSequence + "]') AND type = 'SO') drop sequence " + NomeSequence;

                oSQL.ExecSQL();
                oSQL.ClearAll();

                //2019 oSQL.SQL = $"CREATE SEQUENCE {NomeSequence} START WITH REPLACE('{Valor}', ',', '.')";


                oSQL.SQL = $"CREATE SEQUENCE "+ NomeSequence + " START WITH "+ Valor + " INCREMENT BY 1";
               
                    oSQL.ExecSQL();
                return true;

                
            }
        }

        public static int GetProxCodigo(string Tabela, string Campo = "CODIGO")
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                try
                {
                    oSQL.SQL = String.Format("SELECT COALESCE(MAX(CAST({0} AS NUMERIC)), 0) + 1 FROM {1}", Campo, Tabela);

                   


                    oSQL.Open();

                    return Convert.ToInt32(oSQL.dtDados.Rows[0][0]);
                }
                catch
                {
                    return 1;
                }
            }
        }

        public static int GetValorAtualSequence(string Seq, int? IDConexao = null)
        {
            try
            {
                using (SQLQuery oSQL = new SQLQuery(IDConexao))
                {
                    oSQL.SQL = "SELECT current_value FROM sys.sequences WHERE name =" + Seq;
                    


                    oSQL.Open();
                    return Convert.ToInt32(oSQL.dtDados.Rows[0][0]);
                }
            }
            catch
            {
                return 1;
            }
        }
    }
}