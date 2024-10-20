using PDV.DAO.Atributos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace PDV.DAO.Custom
{
    public class DataTableParser<T> where T : class
    {
        public List<T> ParseDataTable(DataTable dt)
        {
            List<T> lista = new List<T>();
            if (dt == null)
                throw new Exception("Erro de conversão de DataTable para Lista!");
            foreach (DataRow dr in dt.Rows)
                lista.Add(ParseDataRow(dr));
            return lista;
        }

        public T ParseDataRow(DataRow dr)
        {
            T o = (T)Activator.CreateInstance(typeof(T));
            PropertyInfo[] pi = typeof(T).GetProperties();

            string vsNomePropriedade = "";
            for (int i = 0; i < pi.Count(); i++)
            {
                if (pi[i].GetGetMethod().IsVirtual)
                {
                    if (pi[i].PropertyType.GetInterfaces().Length > 0 && pi[i].PropertyType.GetInterfaces()[0].FullName.Equals("System.Collections.IEnumerable"))
                        continue;
                    Type t = typeof(DataTableParser<>);
                    Type genericType = t.MakeGenericType(new System.Type[] { pi[i].PropertyType });
                    var c = Activator.CreateInstance(genericType);
                    dynamic mgm = Convert.ChangeType(c, genericType);
                    pi[i].SetValue(o, Convert.ChangeType(mgm.ParseDataRow(dr), pi[i].PropertyType), null);
                    continue;
                }

                if (pi[i].GetCustomAttributes(typeof(CampoTabela), true) == null)
                    continue;
                if (pi[i].GetCustomAttributes(typeof(CampoTabela), true).Length == 0)
                    continue;

                vsNomePropriedade = (pi[i].GetCustomAttributes(typeof(CampoTabela), true)[0] as CampoTabela).Nome;
                if (!dr.Table.Columns.Contains(vsNomePropriedade))
                    continue;

                if (pi[i].PropertyType.IsGenericType && pi[i].PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (dr[vsNomePropriedade] == DBNull.Value)
                        pi[i].SetValue(o, null, null);
                    else
                        pi[i].SetValue(o, Convert.ChangeType(dr[vsNomePropriedade], Nullable.GetUnderlyingType(pi[i].PropertyType)), null);
                }
                else
                {
                    if (dr[vsNomePropriedade] == DBNull.Value)
                        continue;
                    if (pi[i].PropertyType == typeof(object) && dr[vsNomePropriedade].GetType() == typeof(byte[]))
                        pi[i].SetValue(o, dr[vsNomePropriedade], null);
                    else
                        pi[i].SetValue(o, Convert.ChangeType(dr[vsNomePropriedade], pi[i].PropertyType), null);
                }
            }
            return o;
        }

        public DataTable ParseToDataTable(List<T> list)
        {
            DataTable dt = new DataTable();
            if (list == null)
                throw new Exception("Erro de conversão de para Lista DataTable!");

            foreach (T item in list)
            {
                DataRow dr = dt.NewRow();
                ParseToDataRow(item, dr);
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public void ParseToDataRow(T item, DataRow dr)
        {
            PropertyInfo[] pi = typeof(T).GetProperties();
            foreach (PropertyInfo p in pi)
            {
                if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (!dr.Table.Columns.Contains(p.Name))
                        dr.Table.Columns.Add(new DataColumn(p.Name, p.PropertyType.GetGenericArguments()[0]));
                    if (p.GetValue(item, null) == null)
                        dr[p.Name] = DBNull.Value;
                    else
                        dr[p.Name] = p.GetValue(item, null);
                }
                else
                {
                    if (!dr.Table.Columns.Contains(p.Name))
                        dr.Table.Columns.Add(new DataColumn(p.Name, p.PropertyType));
                    if (p.GetValue(item, null) == null)
                        continue;

                    dr[p.Name] = p.GetValue(item, null);
                }
            }
        }
    }
}
