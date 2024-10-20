using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using PDV.DAO.Entidades;

namespace PDV.DAO.Custom
{
    public class EntityUtil<T> where T : class
    {
        public static List<T> ParseDataTable(DataTable dt)
        {
            if (dt == null)
                return null;

            List<T> lista = new List<T>();
            foreach (DataRow dr in dt.Rows)
                lista.Add(ParseDataRow(dr));
            return lista;
        }

        public static T ParseDataRow(DataRow dr)
        {
            return ParseDataRow(dr, null);
        }

        public static T ParseDataRow(DataRow dr, object[] parametros)
        {
            if (dr == null)
                return null;

            T o = (T)Activator.CreateInstance(typeof(T), parametros);
            PropertyInfo[] pi = typeof(T).GetProperties();
            for (int i = 0; i < pi.Count(); i++)
            {
                if (!dr.Table.Columns.Contains(pi[i].Name))
                    continue;

                if (pi[i].PropertyType.IsGenericType && pi[i].PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (dr[pi[i].Name] == DBNull.Value)
                        pi[i].SetValue(o, null, null);
                    else
                        pi[i].SetValue(o, Convert.ChangeType(dr[pi[i].Name], Nullable.GetUnderlyingType(pi[i].PropertyType)), null);
                }
                else
                {
                    if (dr[pi[i].Name] == DBNull.Value)
                        continue;

                    pi[i].SetValue(o, Convert.ChangeType(dr[pi[i].Name], pi[i].PropertyType), null);
                }
            }

            return o;
        }

        public static bool ParseToDataTable(List<T> o, DataTable dt, DateTime hoje)
        {
            using (DataTable dt2 = dt.Copy())
            {
                foreach (T ozinho in o)
                    if (!ParseToDataTable(ozinho, dt2, hoje))
                        return false;
                dt = dt2.Copy();
            }
            return true;
        }

        public static bool ParseToDataTable(T o, DataTable dt, DateTime hoje)
        {
            try
            {
                DataRow dr = dt.NewRow();
                ParseToDataRow(o, dr, hoje);
                dt.Rows.Add(dr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void ParseToDataRow(T o, DataRow dr, DateTime hoje)
        {
            PropertyInfo[] pi = typeof(T).GetProperties();
            for (int i = 0; i < pi.Count(); i++)
            {
                if (!dr.Table.Columns.Contains(pi[i].Name))
                    continue;

                if (pi[i].PropertyType.IsGenericType && pi[i].PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (pi[i].GetValue(o, null) == null)
                        dr[pi[i].Name] = DBNull.Value;
                    else
                        dr[pi[i].Name] = pi[i].GetValue(o, null);
                }
                else
                {
                    if (pi[i].GetValue(o, null) == null)
                        continue;

                    dr[pi[i].Name] = pi[i].GetValue(o, null);
                }
            }

            if (dr.Table.Columns.Contains("VIGENTE") &&
                dr.Table.Columns.Contains("DATAINICIOVIGENCIA") &&
                dr.Table.Columns.Contains("DATAFIMVIGENCIA"))
            {
                DateTime? dataInicioVigencia = dr["DATAINICIOVIGENCIA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATAINICIOVIGENCIA"]);
                DateTime? dataFimVigencia = dr["DATAFIMVIGENCIA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATAFIMVIGENCIA"]);
                dr["VIGENTE"] = AvaliaVigencia(dataInicioVigencia, dataFimVigencia, hoje);
            }
        }

        private static bool AvaliaVigencia(DateTime? inicio, DateTime? fim, DateTime hoje)
        {
            //hoje = hoje ?? GetCurrentDateTimeFromPostgres().Date;

            if (!inicio.HasValue)
                inicio = hoje.Date;

            if (!fim.HasValue)
                fim = hoje.Date;

            if (inicio.Value.Date > hoje.Date)
                return false;

            if (fim.Value.Date < hoje.Date)
                return false;

            return true;
        }
    }
}
