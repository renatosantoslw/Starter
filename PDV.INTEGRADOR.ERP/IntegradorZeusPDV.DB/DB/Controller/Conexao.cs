using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace IntegradorZeusPDV.DB.DB.Controller
{
    public class Conexao
    {
        #region Fields
        public int IDConexao { get; set; }
        public String ConnectionString { get; set; }
        public IDbTransaction Transaction { get; set; }
        public IDbConnection Connection { get; set; }
        #endregion

        #region Constructor
        public Conexao(int IDConexao, string ConnStr)
        {
            this.IDConexao = IDConexao;
            this.ConnectionString = ConnStr;
            this.Connection = ConnectionFactory.CreateConnection(this.ConnectionString);
        }

        public Conexao(DataRow drConexao)
            : this(Convert.ToInt32(drConexao["ID_CONEXAO"]), ConnectionFactory.CreateConnectionString(drConexao))
        {
        }
        #endregion

        #region BeginTransaction | Commit | Rollback
        public void BeginTransaction()
        {
            if (Connection.State != ConnectionState.Open)
            {
                this.Connect();
            }
            Transaction = Connection.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Commit(Controlador controlador)
        {
            try
            {
                if (Transaction == null)
                    return;

                Transaction.Commit();
                Transaction = null;
            }
            finally
            {
                this.Disconnect();
            }
        }

        public void Rollback()
        {
            try
            {
                if (Transaction != null)
                    Transaction.Rollback();
                Transaction = null;
            }
            finally
            {
                this.Disconnect();
            }
        }
        #endregion

        #region Connect | Disconnect
        public void Connect()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
                return;

            Connection.Open();
        }

        public void Disconnect()
        {
            try
            {
                if (Transaction != null)
                    Transaction.Rollback();
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }
        #endregion

        #region GetCommand
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public IDbCommand GetCommand(string strSQL, IDbConnection objConnection)
        {
            return new NpgsqlCommand(strSQL, (NpgsqlConnection)Connection);
        }
        #endregion

        public IDataReader GetDataReader(IDbCommand objCommand)
        {
            return (objCommand as NpgsqlCommand).ExecuteReader();
        }

        #region GetDataAdapter
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public IDbDataAdapter GetDataAdapter(string strSQL)
        {
            return new NpgsqlDataAdapter(strSQL, ConnectionString);
        }
        #endregion

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        private void AtualizaParametros(SQLQuery oSQL, IDbCommand objCommand)
        {
            foreach (KeyValuePair<string, object> param in oSQL.ParamByName)
            {
                /***************
                * Parâmetro IN
                ***************/
                if (param.Value != null &&
                    param.Value != DBNull.Value &&
                    (((System.Type)param.Value.GetType()) == typeof(int[]) ||
                    ((System.Type)param.Value.GetType()) == typeof(string[]) ||
                    ((System.Type)param.Value.GetType()) == typeof(double[]) ||
                    ((System.Type)param.Value.GetType()) == typeof(float[]) ||
                    ((System.Type)param.Value.GetType()) == typeof(char[])))
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
                    objCommand.CommandText = objCommand.CommandText.Replace("@" + param.Key, vsIN);
                }
                else
                {
                    IDbDataParameter parametro = objCommand.CreateParameter();
                    parametro.ParameterName = param.Key;
                    parametro.Value = param.Value;
                    objCommand.Parameters.Add(parametro);
                }
            }
        }


    }
}
