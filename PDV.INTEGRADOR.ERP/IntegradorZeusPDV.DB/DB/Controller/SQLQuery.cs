using IntegradorZeusPDV.DB.DB.Utils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace IntegradorZeusPDV.DB.DB.Controller
{
    public class SQLQuery : IDisposable
    {
        private int? IDConexao { get; set; }
        /// <summary>
        /// Resultado da consulta SQL quando o SQLQuery for uma instrução SELECT
        /// </summary>
        public DataTable dtDados { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, object> FieldByName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, object> ParamByName { get; set; }

        /// <summary>
        /// Instrução SQL
        /// </summary>
        public string SQL { get; set; }

        private int RecordIndex;
        private IDbCommand objCommand;
        private IDbDataAdapter objDataAdapter;
        private object objCommandBuilder;

        public long TempoDeExecucao { get; set; }

        public SQLQuery(int? _IDConexao = null)
        {
            IDConexao = _IDConexao;
            FieldByName = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
            ParamByName = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
        }

        public object GetParamByName(string Name)
        {
            if (ParamByName.ContainsKey(Name))
                return ParamByName[Name];
            return null;
        }

        public void ClearAll()
        {
            SQL = null;
            ParamByName.Clear();
            if (FieldByName != null)
                FieldByName.Clear();
            dtDados = null;
        }

        public void ClearParameters()
        {
            ParamByName.Clear();
        }

        public override string ToString()
        {
            string vsSQL = SQL;
            if (ParamByName == null || ParamByName.Count == 0)
                return vsSQL;

            foreach (KeyValuePair<string, object> vp in (from pb in ParamByName orderby pb.Key.Length descending select pb).ToList())
                vsSQL = vsSQL.Replace("@" + vp.Key, vp.Value == null ? "null" : vp.Value.ToString());
            return vsSQL;
        }

        #region Update/Insert/Delete Command
        private IDbCommand GetUpdateCommand()
        {
            return ((NpgsqlCommandBuilder)objCommandBuilder).GetUpdateCommand(true);
        }

        private IDbCommand GetInsertCommand()
        {
            return ((NpgsqlCommandBuilder)objCommandBuilder).GetInsertCommand(true);
        }

        private IDbCommand GetDeleteCommand()
        {
            return ((NpgsqlCommandBuilder)objCommandBuilder).GetDeleteCommand(true);
        }
        #endregion

        #region UpdateDataAdapter
        private int UpdateDataAdapter(DataTable dt)
        {
            return ((NpgsqlDataAdapter)objDataAdapter).Update(dt);
        }
        #endregion

        #region Append / Edit
        /// <summary>
        /// Insere uma nova linha no conjunto de dados
        /// </summary>
        public void Append()
        {
            DataRow dr = dtDados.NewRow();
            dtDados.Rows.Add(dr);
            RecordIndex = dtDados.Rows.Count - 1;
        }

        /// <summary>
        /// Edita o registro do DataTable que estiver na linha "Index" (valor padrão = 0)
        /// </summary>
        /// <param name="Index">Número da linha que será editada no DataTable</param>
        public void Edit(int Index = 0)
        {
            RecordIndex = Index;
            FieldByName.Clear();
            foreach (DataColumn dc in dtDados.Columns)
                FieldByName[dc.ColumnName] = dtDados.Rows[RecordIndex][dc.ColumnName];
        }

        #endregion

        #region FieldByName / ParamByName
        private void AtualizaValores()
        {
            if (RecordIndex >= 0 &&
                RecordIndex < dtDados.Rows.Count &&
                dtDados.Rows[RecordIndex].RowState != DataRowState.Deleted)
            {
                foreach (KeyValuePair<string, object> vp in FieldByName)
                    if (vp.Value == null || string.IsNullOrEmpty(vp.Value.ToString()))
                        switch (dtDados.Columns[vp.Key].DataType.ToString())
                        {
                            case "System.Boolean":
                                dtDados.Rows[RecordIndex][vp.Key] = false;
                                break;
                            case "System.Int16":
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Single":
                            case "System.Double":
                            case "System.Decimal":
                            case "System.DateTime":
                            case "System.TimeSpan":
                                dtDados.Rows[RecordIndex][vp.Key] = DBNull.Value;
                                break;
                            default:
                                dtDados.Rows[RecordIndex][vp.Key] = vp.Value;
                                break;
                        }
                    else
                        dtDados.Rows[RecordIndex][vp.Key] = vp.Value;
            }

            FieldByName.Clear();
        }

        private bool IsParametroIn(object Value)
        {
            return Value != null &&
                   ((System.Type)Value.GetType() == typeof(int[]) ||
                    (System.Type)Value.GetType() == typeof(string[]) ||
                    (System.Type)Value.GetType() == typeof(double[]) ||
                    (System.Type)Value.GetType() == typeof(float[]) ||
                    (System.Type)Value.GetType() == typeof(char[]) ||
                    (System.Type)Value.GetType() == typeof(object[]) ||
                    (System.Type)Value.GetType() == typeof(decimal[]));
        }

        private void AtualizaParametros()
        {
            //"tenta" escapar sql injection
            objCommand.CommandText = objCommand.CommandText.Replace(";", string.Empty); //Replace("--", string.Empty); <-- muitas queries tem "--"

            foreach (KeyValuePair<string, object> param in ParamByName)
            {
                /***************
                 * Parâmetro IN
                 ***************/
                if (IsParametroIn(param.Value))
                {
                    object[] paramIN = (object[])param.Value;
                    string[] paramNames = paramIN.Select(
                        (s, i) => String.Format("@{0}{1}", param.Key, i)
                    ).ToArray();

                    string vsIN = string.Join(",", paramNames);

                    for (int i = 0; i < paramNames.Length; i++)
                    {
                        IDbDataParameter parametro = objCommand.CreateParameter();
                        parametro.ParameterName = paramNames[i];
                        parametro.Value = paramIN[i];
                        objCommand.Parameters.Add(parametro);
                    }
                    SQL = SQL.Replace("@" + param.Key, vsIN);
                    objCommand.CommandText = SQL;
                }
                else
                {
                    IDbDataParameter parametro = objCommand.CreateParameter();
                    parametro.ParameterName = param.Key;

                    parametro.Value = DBNull.Value;
                    if (param.Value != null && !string.IsNullOrEmpty(param.Value.ToString()))
                        parametro.Value = param.Value;

                    objCommand.Parameters.Add(parametro);
                }
            }
        }
        #endregion

        #region ExecSQL / Open / Post / IsEmpty
        public void AtualizaTransacao()
        {
            objCommand.Transaction = DBUtils.CONTROLADOR.Pool[IDConexao.HasValue ? IDConexao.Value : DBUtils.IDCONEXAO_PRIMARIA].Transaction;
        }

        /// <summary>
        /// Executa instrução INSERT, UPDATE ou DELETE
        /// </summary>
        /// <returns>Quantidade de registros afetados</returns>
        public int ExecSQL()
        {
            objCommand = new NpgsqlCommand(SQL, (NpgsqlConnection)DBUtils.CONTROLADOR.Pool[IDConexao.HasValue ? IDConexao.Value : DBUtils.IDCONEXAO_PRIMARIA].Connection);
            objCommand.Transaction = DBUtils.CONTROLADOR.Pool[IDConexao.HasValue ? IDConexao.Value : DBUtils.IDCONEXAO_PRIMARIA].Transaction;
            AtualizaParametros();

            int viRetorno = 0;
            bool vbAbriuConexao = false;
            try
            {
                if (DBUtils.CONTROLADOR.Pool[IDConexao.HasValue ? IDConexao.Value : DBUtils.IDCONEXAO_PRIMARIA].Connection.State != ConnectionState.Open)
                {
                    DBUtils.CONTROLADOR.Pool[IDConexao.HasValue ? IDConexao.Value : DBUtils.IDCONEXAO_PRIMARIA].Connection.Open();
                    vbAbriuConexao = true;
                }

                viRetorno = objCommand.ExecuteNonQuery();
            }
            finally
            {
                objCommand.Dispose();
                if (vbAbriuConexao)
                    DBUtils.CONTROLADOR.Pool[IDConexao.HasValue ? IDConexao.Value : DBUtils.IDCONEXAO_PRIMARIA].Connection.Close();
            }
            return viRetorno;
        }

        /// <summary>
        /// Preenche o DataTable com o conjunto de dados oriundos da instrução SELECT
        /// </summary>
        public void Open()
        {
            bool vbAbriuConexao = false;
            try
            {
                if (DBUtils.CONTROLADOR.Pool[IDConexao.HasValue ? IDConexao.Value : DBUtils.IDCONEXAO_PRIMARIA].Connection.State != ConnectionState.Open)
                {
                    DBUtils.CONTROLADOR.Pool[IDConexao.HasValue ? IDConexao.Value : DBUtils.IDCONEXAO_PRIMARIA].Connection.Open();
                    vbAbriuConexao = true;
                }

                dtDados = new DataTable();
                objCommand = new NpgsqlCommand(SQL, (NpgsqlConnection)DBUtils.CONTROLADOR.Pool[IDConexao.HasValue ? IDConexao.Value : DBUtils.IDCONEXAO_PRIMARIA].Connection);
                objCommand.Transaction = DBUtils.CONTROLADOR.Pool[IDConexao.HasValue ? IDConexao.Value : DBUtils.IDCONEXAO_PRIMARIA].Transaction;
                AtualizaParametros();
                objDataAdapter = new NpgsqlDataAdapter(objCommand as NpgsqlCommand);
                objCommandBuilder = new NpgsqlCommandBuilder((NpgsqlDataAdapter)objDataAdapter);
                ((NpgsqlDataAdapter)objDataAdapter).Fill(dtDados);
                if (!IsEmpty)
                    Edit();
            }
            finally
            {
                if (vbAbriuConexao)
                    DBUtils.CONTROLADOR.Pool[IDConexao.HasValue ? IDConexao.Value : DBUtils.IDCONEXAO_PRIMARIA].Connection.Close();
            }
        }

        public int RecordCount
        {
            get
            {
                return IsEmpty ? 0 : dtDados.Rows.Count;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return !(dtDados != null && dtDados.Rows.Count > 0);
            }
        }
        #endregion

        public void Dispose()
        {
            if (this == null)
                return;

            if (dtDados != null)
            {
                dtDados.Dispose();
                dtDados = null;
            }

            if (FieldByName != null)
            {
                FieldByName.Clear();
                FieldByName = null;
            }

            if (objCommand != null)
            {
                objCommand.Dispose();
                objCommand = null;
            }
            objCommandBuilder = null;
            objDataAdapter = null;
            if (ParamByName != null)
            {
                ParamByName.Clear();
                ParamByName = null;
            }

            SQL = null;
        }
    }
}
