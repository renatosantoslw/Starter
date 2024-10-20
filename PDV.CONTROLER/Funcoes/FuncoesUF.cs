using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesUF
    {
        public static bool Existe(decimal IDUnidadeFederativa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM UNIDADEFEDERATIVA WHERE IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA";
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = IDUnidadeFederativa;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static UnidadeFederativa GetUnidadeFederativa(decimal IDUnidadeFederativa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.*
                               FROM UNIDADEFEDERATIVA
                                 INNER JOIN PAIS ON(UNIDADEFEDERATIVA.IDPAIS = PAIS.IDPAIS)
                               WHERE UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA";
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = IDUnidadeFederativa;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<UnidadeFederativa>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static UnidadeFederativa GetUnidadeFederativa(string sigla)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.*
                               FROM UNIDADEFEDERATIVA
                                 INNER JOIN PAIS ON(UNIDADEFEDERATIVA.IDPAIS = PAIS.IDPAIS)
                               WHERE UNIDADEFEDERATIVA.SIGLA = @SIGLA";
                oSQL.ParamByName["SIGLA"] = sigla;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<UnidadeFederativa>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static UnidadeFederativa GetUnidadeFederativaPorSigla(string Sigla)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.*
                               FROM UNIDADEFEDERATIVA
                                 INNER JOIN PAIS ON(UNIDADEFEDERATIVA.IDPAIS = PAIS.IDPAIS)
                               WHERE UPPER(UNIDADEFEDERATIVA.SIGLA) = @SIGLA";
                oSQL.ParamByName["SIGLA"] = Sigla.ToUpper();
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<UnidadeFederativa>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static List<UnidadeFederativa> GetUnidadeFederativaPorCodigoPais(string CodigoPais)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.DESCRICAO,
                                    UNIDADEFEDERATIVA.SIGLA,
                               
                                    PAIS.IDPAIS,
                                    PAIS.DESCRICAO AS PAIS
                               FROM UNIDADEFEDERATIVA
                                 INNER JOIN PAIS ON(UNIDADEFEDERATIVA.IDPAIS = PAIS.IDPAIS)
                               WHERE PAIS.CODIGO = @CODIGO";
                oSQL.ParamByName["CODIGO"] = CodigoPais;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return new DataTableParser<UnidadeFederativa>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static DataTable GetUnidadesFederativa(string Sigla, string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Sigla))
                    Filtros.Add(string.Format("(UPPER(UNIDADEFEDERATIVA.SIGLA) LIKE UPPER('%{0}%'))", Sigla));

                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UPPER(UNIDADEFEDERATIVA.DESCRICAO) LIKE UPPER('%{0}%'))", Descricao));

                oSQL.SQL = string.Format(
                           @"SELECT UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.DESCRICAO AS UNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.SIGLA,
                             
                                    PAIS.IDPAIS,
                                    PAIS.DESCRICAO AS PAIS
                               FROM UNIDADEFEDERATIVA
                                 INNER JOIN PAIS ON (UNIDADEFEDERATIVA.IDPAIS = PAIS.IDPAIS)
                               {0} ORDER BY UNIDADEFEDERATIVA.DESCRICAO, PAIS.DESCRICAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Remover(decimal IDUnidadeFederativa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM MUNICIPIO WHERE IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA";
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = IDUnidadeFederativa;
                oSQL.Open();

                if (!oSQL.IsEmpty)
                    throw new Exception("A Unidade Federativa tem vinculo com município e não pode ser removida.");

                oSQL.ClearAll();
                oSQL.SQL = @"SELECT 1 FROM ENDERECO WHERE IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA";
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = IDUnidadeFederativa;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    throw new Exception("A Unidade Federativa tem vinculo com Endereço e não pode ser remvido.");

                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM UNIDADEFEDERATIVA WHERE IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA";
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = IDUnidadeFederativa;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Salvar(UnidadeFederativa UF, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO 
                                        UNIDADEFEDERATIVA (IDUNIDADEFEDERATIVA, SIGLA, DESCRICAO, IDPAIS, ALIQUOTAINTER, ALIQUOTAINTRA, FCP)
                                     VALUES (@IDUNIDADEFEDERATIVA, @SIGLA, @DESCRICAO, @IDPAIS, @ALIQUOTAINTER, @ALIQUOTAINTRA, @FCP)";

                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE UNIDADEFEDERATIVA 
                                        SET SIGLA = @SIGLA,
                                            DESCRICAO = @DESCRICAO,
                                            IDPAIS = @IDPAIS,
                                            ALIQUOTAINTER = @ALIQUOTAINTER,
                                            ALIQUOTAINTRA = @ALIQUOTAINTRA,
                                            FCP = @FCP
                                        WHERE IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA";
                        break;
                }
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = UF.IDUnidadeFederativa;
                oSQL.ParamByName["IDPAIS"] = UF.IDPais;
                oSQL.ParamByName["DESCRICAO"] = UF.Descricao;
                oSQL.ParamByName["SIGLA"] = UF.Sigla;
                oSQL.ParamByName["ALIQUOTAINTER"] = UF.AliquotaInter;
                oSQL.ParamByName["ALIQUOTAINTRA"] = UF.AliquotaIntra;
                oSQL.ParamByName["FCP"] = UF.FCP;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static List<UnidadeFederativa> GetUnidadesFederativa(decimal IDPais)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDUNIDADEFEDERATIVA,
                                    IDPAIS,
                                    SIGLA, 
                                    DESCRICAO 
                             FROM UNIDADEFEDERATIVA
                              WHERE IDPAIS = @IDPAIS";
                oSQL.ParamByName["IDPAIS"] = IDPais;
                oSQL.Open();
                return new DataTableParser<UnidadeFederativa>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<UnidadeFederativa> GetUnidadesFederativa()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.IDPAIS,
                                    UNIDADEFEDERATIVA.SIGLA, 
                                    UNIDADEFEDERATIVA.DESCRICAO 
                             FROM UNIDADEFEDERATIVA
                               INNER JOIN PAIS ON (UNIDADEFEDERATIVA.IDPAIS = PAIS.IDPAIS)
                              ORDER BY UNIDADEFEDERATIVA.SIGLA";
                oSQL.Open();
                return new DataTableParser<UnidadeFederativa>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<UnidadeFederativa> GetUnidadesFederativaNFe()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.SIGLA
                             FROM UNIDADEFEDERATIVA
                               INNER JOIN PAIS ON (UNIDADEFEDERATIVA.IDPAIS = PAIS.IDPAIS)
                              ORDER BY UNIDADEFEDERATIVA.SIGLA";
                oSQL.Open();
                return new DataTableParser<UnidadeFederativa>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static DataTable GetUnidadesFederativaComAliquotasICMS()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDUNIDADEFEDERATIVA, 
                                    IDPAIS, 
                                    SIGLA, 
                                    COALESCE(ALIQUOTAINTER, 0) AS ALIQUOTAINTER, 
                                    COALESCE(ALIQUOTAINTRA, 0) AS ALIQUOTAINTRA,
                                    COALESCE(FCP, 0) AS FCP
                            FROM UNIDADEFEDERATIVA";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static UnidadeFederativa GetUnidadesFederativaComAliquotasICMS(decimal IDEmitente)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA, 
                                     UNIDADEFEDERATIVA.IDPAIS, 
                                     UNIDADEFEDERATIVA.SIGLA, 
                                     COALESCE(ALIQUOTAINTER, 0) AS ALIQUOTAINTER, 
                                     COALESCE(ALIQUOTAINTRA, 0) AS ALIQUOTAINTRA,
                                     COALESCE(FCP, 0) AS FCP
                               
                             FROM UNIDADEFEDERATIVA
                               INNER JOIN ENDERECO ON (UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA = ENDERECO.IDUNIDADEFEDERATIVA)
                               INNER JOIN EMITENTE ON (EMITENTE.IDENDERECO = ENDERECO.IDENDERECO)
                            WHERE EMITENTE.IDEMITENTE = @IDEMITENTE";
                oSQL.ParamByName["IDEMITENTE"] = IDEmitente;
                oSQL.Open();
                return EntityUtil<UnidadeFederativa>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static UnidadeFederativa GetUnidadesFederativaComAliquotasICMS_PorUF(decimal IDUnidadeFederativa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA, 
                                     UNIDADEFEDERATIVA.IDPAIS, 
                                     UNIDADEFEDERATIVA.SIGLA, 
                                     COALESCE(ALIQUOTAINTER, 0) AS ALIQUOTAINTER, 
                                     COALESCE(ALIQUOTAINTRA, 0) AS ALIQUOTAINTRA,
                                     COALESCE(FCP, 0) AS FCP
                               
                             FROM UNIDADEFEDERATIVA
                               INNER JOIN ENDERECO ON (UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA = ENDERECO.IDUNIDADEFEDERATIVA)
                            WHERE UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA";
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = IDUnidadeFederativa;
                oSQL.Open();
                return EntityUtil<UnidadeFederativa>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
    }
}
