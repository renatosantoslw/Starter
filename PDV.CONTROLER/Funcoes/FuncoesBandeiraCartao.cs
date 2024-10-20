using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesBandeiraCartao
    {
        public static bool Existe(decimal IDBandeiraCartao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM BANDEIRACARTAO WHERE IDBANDEIRACARTAO = @IDBANDEIRACARTAO";
                oSQL.ParamByName["IDBANDEIRACARTAO"] = IDBandeiraCartao;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static BandeiraCartao GetBandeira(decimal IDBandeiraCartao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDBANDEIRACARTAO,
                                    CODIGO,
                                    DESCRICAO
                               FROM BANDEIRACARTAO 
                             WHERE IDBANDEIRACARTAO = @IDBANDEIRACARTAO";
                oSQL.ParamByName["IDBANDEIRACARTAO"] = IDBandeiraCartao;
                oSQL.Open();
                return EntityUtil<BandeiraCartao>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetBandeiras(string Codigo, string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Codigo))
                    Filtros.Add(string.Format("(UPPER(CODIGO::VARCHAR) LIKE UPPER('%{0}%'))", Codigo));

                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UPPER(DESCRICAO) LIKE UPPER('%{0}%'))", Descricao));

                oSQL.SQL = string.Format(
                           @"SELECT IDBANDEIRACARTAO,
                                    CODIGO,
                                    DESCRICAO
                               FROM BANDEIRACARTAO {0}
                             ORDER BY CODIGO, DESCRICAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }


        public static List<BandeiraCartao> GetBandeiras()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDBANDEIRACARTAO,
                                    CODIGO,
                                    DESCRICAO,
                                    CAST(CODIGO AS VARCHAR) + ' - ' + DESCRICAO AS CODIGODESCRICAO
                               FROM BANDEIRACARTAO 
                             ORDER BY CODIGO, DESCRICAO";
                oSQL.Open();
                return new DataTableParser<BandeiraCartao>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool Salvar(BandeiraCartao _BandeiraCartao, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = "INSERT INTO BANDEIRACARTAO (IDBANDEIRACARTAO, CODIGO, DESCRICAO) VALUES (@IDBANDEIRACARTAO, @CODIGO, @DESCRICAO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE BANDEIRACARTAO
                                      SET CODIGO = @CODIGO,
                                          DESCRICAO = @DESCRICAO
                                     WHERE IDBANDEIRACARTAO = @IDBANDEIRACARTAO";
                        break;
                }
                oSQL.ParamByName["IDBANDEIRACARTAO"] = _BandeiraCartao.IDBandeiraCartao;
                oSQL.ParamByName["CODIGO"] = _BandeiraCartao.Codigo;
                oSQL.ParamByName["DESCRICAO"] = _BandeiraCartao.Descricao;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDBandeiraCartao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM FORMADEPAGAMENTO WHERE IDBANDEIRACARTAO = @IDBANDEIRACARTAO";
                oSQL.ParamByName["IDBANDEIRACARTAO"] = IDBandeiraCartao;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    throw new Exception("A Bandeira tem vínculo com produto e não pode ser removido.");

                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM BANDEIRACARTAO WHERE IDBANDEIRACARTAO = @IDBANDEIRACARTAO";
                oSQL.ParamByName["IDBANDEIRACARTAO"] = IDBandeiraCartao;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
