using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesPais
    {
        public static bool Existe(decimal IDPais)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PAIS WHERE IDPAIS = @IDPAIS";
                oSQL.ParamByName["IDPAIS"] = IDPais;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static List<Pais> GetPaises()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT IDPAIS, CODIGO, DESCRICAO FROM PAIS ORDER BY DESCRICAO";
                oSQL.Open();
                return new DataTableParser<Pais>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static Pais GetPais(decimal IDPais)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT IDPAIS, CODIGO, DESCRICAO FROM PAIS WHERE IDPAIS = @IDPAIS";
                oSQL.ParamByName["IDPAIS"] = IDPais;
                oSQL.Open();
                return EntityUtil<Pais>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        
        public static DataTable GetPaises(string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UPPER(DESCRICAO) LIKE UPPER('%{0}%'))", Descricao));

                oSQL.SQL = string.Format("SELECT IDPAIS, DESCRICAO FROM PAIS {0} ORDER BY DESCRICAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Salvar(Pais _P, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = "INSERT INTO PAIS (IDPAIS, CODIGO, DESCRICAO) VALUES (@IDPAIS, @CODIGO, @DESCRICAO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = "UPDATE PAIS SET DESCRICAO = @DESCRICAO, CODIGO = @CODIGO WHERE IDPAIS = @IDPAIS";
                        break;
                }
                oSQL.ParamByName["IDPAIS"] = _P.IDPais;
                oSQL.ParamByName["DESCRICAO"] = _P.Descricao;
                oSQL.ParamByName["CODIGO"] = _P.Codigo;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDPais)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM UNIDADEFEDERATIVA WHERE IDPAIS = @IDPAIS";
                oSQL.ParamByName["IDPAIS"] = IDPais;
                oSQL.Open();

                if (!oSQL.IsEmpty)
                    throw new Exception("O Pais tem vinculo com Unidade Federativa e não pode ser removido.");

                oSQL.ClearAll();
                oSQL.SQL = @"SELECT 1 FROM UNIDADEFEDERATIVA WHERE IDPAIS = @IDPAIS";
                oSQL.ParamByName["IDPAIS"] = IDPais;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    throw new Exception("O Pais tem vinculo com Endereço e não pode ser remvido.");

                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM PAIS WHERE IDPAIS = @IDPAIS";
                oSQL.ParamByName["IDPAIS"] = IDPais;
                return oSQL.ExecSQL() == 1;
            }
        }

    }
}