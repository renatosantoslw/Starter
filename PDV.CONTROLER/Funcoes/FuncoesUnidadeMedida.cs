using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesUnidadeMedida
    {
        public static bool Existe(decimal IDUnidadeMedida)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM UNIDADEDEMEDIDA WHERE IDUNIDADEDEMEDIDA = @IDUNIDADEDEMEDIDA";
                oSQL.ParamByName["IDUNIDADEDEMEDIDA"] = IDUnidadeMedida;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static UnidadeMedida GetUnidadeMedida(decimal IDUnidadeMedida)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDUNIDADEDEMEDIDA,
                                    DESCRICAO,
                                    SIGLA
                               FROM UNIDADEDEMEDIDA
                               WHERE IDUNIDADEDEMEDIDA = @IDUNIDADEDEMEDIDA";
                oSQL.ParamByName["IDUNIDADEDEMEDIDA"] = IDUnidadeMedida;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<UnidadeMedida>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static UnidadeMedida GetUnidadeMedida(string descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT TOP 1 IDUNIDADEDEMEDIDA,
                                    DESCRICAO,
                                    SIGLA
                               FROM UNIDADEDEMEDIDA
                               WHERE DESCRICAO = @DESCRICAO /*LIMIT 1*/";
                oSQL.ParamByName["DESCRICAO"] = descricao;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<UnidadeMedida>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static UnidadeMedida GetUnidadeMedidaPorSigla(string Sigla)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDUNIDADEDEMEDIDA,
                                    DESCRICAO,
                                    SIGLA
                               FROM UNIDADEDEMEDIDA
                               WHERE UPPER(SIGLA) = @SIGLA";
                oSQL.ParamByName["SIGLA"] = Sigla.ToUpper();
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<UnidadeMedida>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetUnidadesMedida(string Sigla, string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Sigla))
                    Filtros.Add(string.Format("(UPPER(SIGLA) LIKE UPPER('%{0}%'))", Sigla));

                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UPPER(DESCRICAO) LIKE UPPER('%{0}%'))", Descricao));

                oSQL.SQL = string.Format(
                   @"SELECT IDUNIDADEDEMEDIDA,
                                         DESCRICAO,
                                         SIGLA
                                    FROM UNIDADEDEMEDIDA {0} 
                                    ORDER BY DESCRICAO, SIGLA"
                   , Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                    oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Remover(decimal IDUnidadeMedida)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1 FROM PRODUTO WHERE IDUNIDADEDEMEDIDA = @IDUNIDADEDEMEDIDA";
                oSQL.ParamByName["IDUNIDADEDEMEDIDA"] = IDUnidadeMedida;
                oSQL.Open();

                if (!oSQL.IsEmpty)
                    throw new Exception("A Unidade de Medida tem vinculo com produto e não pode ser removida.");

                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM UNIDADEDEMEDIDA WHERE IDUNIDADEDEMEDIDA = @IDUNIDADEDEMEDIDA";
                oSQL.ParamByName["IDUNIDADEDEMEDIDA"] = IDUnidadeMedida;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Salvar(UnidadeMedida Unidade, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO 
                                        UNIDADEDEMEDIDA (IDUNIDADEDEMEDIDA, SIGLA, DESCRICAO)
                                     VALUES (@IDUNIDADEDEMEDIDA, @SIGLA, @DESCRICAO)";

                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE UNIDADEDEMEDIDA 
                                        SET SIGLA = @SIGLA,
                                            DESCRICAO = @DESCRICAO
                                        WHERE IDUNIDADEDEMEDIDA = @IDUNIDADEDEMEDIDA";
                        break;
                }
                oSQL.ParamByName["IDUNIDADEDEMEDIDA"] = Unidade.IDUnidadeDeMedida;
                oSQL.ParamByName["DESCRICAO"] = Unidade.Descricao;
                oSQL.ParamByName["SIGLA"] = Unidade.Sigla;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static List<UnidadeMedida> GetUnidadesMedida(int codUnidade = 0)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDUNIDADEDEMEDIDA,
                                    DESCRICAO,                                    
                                    SIGLA                                    
                               FROM UNIDADEDEMEDIDA
                              ORDER BY DESCRICAO, SIGLA";
                oSQL.Open();
                return new DataTableParser<UnidadeMedida>().ParseDataTable(oSQL.dtDados);
            }
        }
    }
    
 }

