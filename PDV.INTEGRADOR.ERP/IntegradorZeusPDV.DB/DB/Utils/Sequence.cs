using IntegradorZeusPDV.DB.DB.Controller;
using System;
using System.Collections;
using System.Diagnostics;


namespace IntegradorZeusPDV.DB.DB.Utils
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
                    oSQL.SQL = string.Format("SELECT * FROM PG_CLASS WHERE RELKIND = 'S' AND RELNAME ILIKE '{0}'", Key);
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
                        oSQL.SQL = string.Format("SELECT NEXT VALUE FOR ('{0}')", Field.ToUpper().Trim());
                        Debug.Print(string.Format("SELECT NEXT VALUE FOR ('{0}')", Field.ToUpper().Trim()));

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
            catch
            {
                return 1;
            }
        }

        public static bool AtualizarValorSequence(string NomeSequence, decimal Valor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DROP SEQUENCE IF EXISTS " + NomeSequence;
                oSQL.ExecSQL();
                oSQL.ClearAll();

                oSQL.SQL = $"CREATE SEQUENCE {NomeSequence} START WITH {Valor}";
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
                    oSQL.SQL = String.Format("SELECT COALESCE(MAX({0}), 0) + 1 FROM {1}", Campo, Tabela);
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
                    oSQL.SQL = "SELECT LAST_VALUE FROM " + Seq;
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