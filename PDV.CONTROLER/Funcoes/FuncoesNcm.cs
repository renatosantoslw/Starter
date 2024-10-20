using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesNcm
    {
        public static bool Existe(decimal IDNcm)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM NCM WHERE IDNCM = @IDNCM";
                oSQL.ParamByName["IDNCM"] = IDNcm;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
        public static bool Existe(string descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM NCM WHERE DESCRICAO = @DESCRICAO";
                oSQL.ParamByName["DESCRICAO"] = descricao;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
        public static Ncm GetNCMPorCodigo(decimal Codigo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT NCM.IDNCM,
                                   NCM.CODIGO,
                                    NCM.DESCRICAO
                               FROM NCM 
                             WHERE CODIGO = @CODIGO";
                oSQL.ParamByName["CODIGO"] = Codigo;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Ncm>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Ncm GetNCM(decimal IDNcm)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT NCM.IDNCM,
                                   NCM.CODIGO,
                                    NCM.DESCRICAO
                               FROM NCM 
                             WHERE IDNCM = @IDNCM";
                oSQL.ParamByName["IDNCM"] = IDNcm;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Ncm>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Ncm GetNCM(string descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT TOP 1 NCM.IDNCM,
                                    NCM.CODIGO,
                                    NCM.DESCRICAO
                               FROM NCM 
                             WHERE DESCRICAO = @DESCRICAO /*LIMIT 1*/";
                oSQL.ParamByName["DESCRICAO"] = descricao;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Ncm>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static List<Ncm> GetNCMObjeto()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDNCM,
IDUNIDADEFEDERATIVA,
CODIGO,
EX,
TIPO,
DESCRICAO,
NACIONALFEDERAL,
IMPORTADOSFEDERAL,
ESTADUAL,
MUNICIPAL,
VIGENCIAINICIO,
VIGENCIAFIM,
CHAVE,
VERSAO,
FONTE
                               FROM NCM ";
                            
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<List<Ncm>>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetNcms(string Codigo, string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Codigo))
                    Filtros.Add(string.Format("(UPPER(CODIGO) LIKE UPPER('%{0}%'))", Codigo));

                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UPPER(DESCRICAO) LIKE UPPER('%{0}%'))", Descricao));

                oSQL.SQL = string.Format(
                           @"SELECT NCM.IDNCM,
                                        NCM.CODIGO,
                                        NCM.DESCRICAO
                               FROM NCM {0}
                             ORDER BY CODIGO, DESCRICAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }


        public static DataTable GetNcms(string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = string.Format(@"SELECT NCM.IDNCM,
                                                  NCM.CODIGO,
                                                  NCM.DESCRICAO,
                                                  CAST(NCM.CODIGO AS VARCHAR) + ' - ' + NCM.DESCRICAO AS CODIGODESCRICAO
                                             FROM NCM
                                              WHERE UPPER(CAST(NCM.CODIGO AS VARCHAR)) LIKE '%{0}%' OR UPPER(NCM.DESCRICAO) LIKE '%{0}%'
                                           ORDER BY CODIGO, DESCRICAO", Descricao.ToUpper());
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Salvar(Ncm _Ncm, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = "INSERT INTO NCM (IDNCM, CODIGO, DESCRICAO) VALUES (@IDNCM, @CODIGO, @DESCRICAO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE NCM
                                          SET CODIGO = @CODIGO,
                                              DESCRICAO = @DESCRICAO
                                         WHERE IDNCM = @IDNCM";
                        break;
                }
                oSQL.ParamByName["IDNCM"] = _Ncm.IDNCM;
                oSQL.ParamByName["CODIGO"] = _Ncm.Codigo;
                oSQL.ParamByName["DESCRICAO"] = _Ncm.Descricao;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDNcm)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PRODUTO WHERE IDNCM = @IDNCM";
                oSQL.ParamByName["IDNCM"] = IDNcm;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    throw new Exception("O NCM tem vínculo com produto e não pode ser removido.");

                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM NCM WHERE IDNCM = @IDNCM";
                oSQL.ParamByName["IDNCM"] = IDNcm;
                return oSQL.ExecSQL() == 1;
            }
        }


        public static bool RemoverTodos()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM NCM";
                oSQL.Open();
                return oSQL.ExecSQL() == 1;
            }
        }



        /* Fuñções que eram da tabela de tributos do IBPT */
        public static Ncm GetItemTributoVigente(decimal NCM, decimal? ExTipi, DateTime DataVigencia)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CODIGO,
                                    DESCRICAO,
                                    NACIONALFEDERAL,
                                    ESTADUAL,
                                    MUNICIPAL,
                                    VIGENCIAINICIO,
                                    VIGENCIAFIM,
                                    VERSAO,
                                    FONTE,
                                    CHAVE,
                                    EX
                               FROM NCM
                             WHERE CODIGO = @CODIGO
                               AND TIPO = 0
                               --AND COALESCE(EX, -1) = @EXTIPI
                               AND @DATE BETWEEN VIGENCIAINICIO AND VIGENCIAFIM";
                oSQL.ParamByName["CODIGO"] = NCM;
                oSQL.ParamByName["DATE"] = DataVigencia;
                oSQL.ParamByName["EXTIPI"] = ExTipi.HasValue ? ExTipi : -1;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Ncm>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetTributosIBPT()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDNCM,
IDUNIDADEFEDERATIVA,
CODIGO,
EX,
TIPO,
DESCRICAO,
NACIONALFEDERAL,
IMPORTADOSFEDERAL,
ESTADUAL,
MUNICIPAL,
VIGENCIAINICIO,
VIGENCIAFIM,
CHAVE,
VERSAO,
FONTE FROM NCM";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Salvar(Ncm Tabela)
        {
            try
            {

                using (SQLQuery oSQL = new SQLQuery())
                {
                    oSQL.SQL = @"SELECT IDNCM
                               FROM NCM
                                WHERE CODIGO = @CODIGO
                                  AND COALESCE(EX, -1) = @EX
                                  AND IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA";
                    oSQL.ParamByName["CODIGO"] = Tabela.Codigo;
                    oSQL.ParamByName["EX"] = Tabela.Ex.HasValue ? Tabela.Ex.Value : -1;
                    oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = Tabela.IDUnidadeFederativa;
                    oSQL.Open();

                    if (oSQL.IsEmpty)
                    {
                        oSQL.ClearAll();
                        oSQL.SQL = @"INSERT INTO NCM(
                                             IDNCM, CODIGO, EX, TIPO, DESCRICAO, NACIONALFEDERAL, 
                                             IMPORTADOSFEDERAL, ESTADUAL, MUNICIPAL, VIGENCIAINICIO, VIGENCIAFIM, 
                                             CHAVE, VERSAO, FONTE, IDUNIDADEFEDERATIVA)
                                     VALUES (@IDNCM, @CODIGO, @EX, @TIPO, @DESCRICAO, @NACIONALFEDERAL, 
                                             @IMPORTADOSFEDERAL, @ESTADUAL, @MUNICIPAL, @VIGENCIAINICIO, @VIGENCIAFIM, 
                                             @CHAVE, @VERSAO, @FONTE, @IDUNIDADEFEDERATIVA)";
                        oSQL.ParamByName["IDNCM"] = Sequence.GetNextID("NCM", "IDNCM");
                    }
                    else
                    {
                        decimal ID = Convert.ToDecimal(oSQL.dtDados.Rows[0]["IDNCM"]);
                        oSQL.ClearAll();
                        oSQL.SQL = @"UPDATE NCM
                                   SET CODIGO=@CODIGO, EX=@EX, TIPO=@TIPO, DESCRICAO=@DESCRICAO, 
                                       NACIONALFEDERAL=@NACIONALFEDERAL, IMPORTADOSFEDERAL=@IMPORTADOSFEDERAL, ESTADUAL=@ESTADUAL, MUNICIPAL=@MUNICIPAL, 
                                       VIGENCIAINICIO=@VIGENCIAINICIO, VIGENCIAFIM=@VIGENCIAFIM, CHAVE=@CHAVE, VERSAO=@VERSAO, FONTE=@FONTE, IDUNIDADEFEDERATIVA=@IDUNIDADEFEDERATIVA
                                 WHERE IDNCM=@IDNCM";
                        oSQL.ParamByName["IDNCM"] = ID;
                    }




                    oSQL.ParamByName["CODIGO"] = Tabela.Codigo;
                    oSQL.ParamByName["EX"] = DBNull.Value;
                    if (Tabela.Ex.HasValue)
                        oSQL.ParamByName["EX"] = Tabela.Ex.Value;
                    oSQL.ParamByName["TIPO"] = Tabela.Tipo;
                    oSQL.ParamByName["DESCRICAO"] = Tabela.Descricao;
                    oSQL.ParamByName["NACIONALFEDERAL"] = Tabela.NacionalFederal;
                    oSQL.ParamByName["IMPORTADOSFEDERAL"] = Tabela.ImportadosFederal;
                    oSQL.ParamByName["ESTADUAL"] = Tabela.Estadual;
                    oSQL.ParamByName["MUNICIPAL"] = Tabela.Municipal;
                    oSQL.ParamByName["VIGENCIAINICIO"] = Tabela.VigenciaInicio;
                    oSQL.ParamByName["VIGENCIAFIM"] = Tabela.VigenciaFim;
                    oSQL.ParamByName["CHAVE"] = Tabela.Chave;
                    oSQL.ParamByName["VERSAO"] = Tabela.Versao;
                    oSQL.ParamByName["FONTE"] = Tabela.Fonte;
                    oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = Tabela.IDUnidadeFederativa;
                    return oSQL.ExecSQL() == 1;
                }
            }
            catch { return false; }
        }


        public static bool SalvarIBPT(Ncm Tabela)
        {
            try
            {

                using (SQLQuery oSQL = new SQLQuery())
                {
             
                        oSQL.ClearAll();
                        oSQL.SQL = @"INSERT INTO NCM(
                                             IDNCM, CODIGO, EX, TIPO, DESCRICAO, NACIONALFEDERAL, 
                                             IMPORTADOSFEDERAL, ESTADUAL, MUNICIPAL, VIGENCIAINICIO, VIGENCIAFIM, 
                                             CHAVE, VERSAO, FONTE, IDUNIDADEFEDERATIVA)
                                     VALUES (@IDNCM, @CODIGO, @EX, @TIPO, @DESCRICAO, @NACIONALFEDERAL, 
                                             @IMPORTADOSFEDERAL, @ESTADUAL, @MUNICIPAL, @VIGENCIAINICIO, @VIGENCIAFIM, 
                                             @CHAVE, @VERSAO, @FONTE, @IDUNIDADEFEDERATIVA)";
                        oSQL.ParamByName["IDNCM"] = Tabela.Codigo;
                                         
           

                    oSQL.ParamByName["CODIGO"] = Tabela.Codigo;
                    oSQL.ParamByName["EX"] = DBNull.Value;
                    if (Tabela.Ex.HasValue)
                        oSQL.ParamByName["EX"] = Tabela.Ex.Value;

                    oSQL.ParamByName["TIPO"] = Tabela.Tipo;
                    oSQL.ParamByName["DESCRICAO"] = Tabela.Descricao;
                    oSQL.ParamByName["NACIONALFEDERAL"] = Tabela.NacionalFederal;
                    oSQL.ParamByName["IMPORTADOSFEDERAL"] = Tabela.ImportadosFederal;
                    oSQL.ParamByName["ESTADUAL"] = Tabela.Estadual;
                    oSQL.ParamByName["MUNICIPAL"] = Tabela.Municipal;
                    oSQL.ParamByName["VIGENCIAINICIO"] = Tabela.VigenciaInicio;
                    oSQL.ParamByName["VIGENCIAFIM"] = Tabela.VigenciaFim;
                    oSQL.ParamByName["CHAVE"] = Tabela.Chave;
                    oSQL.ParamByName["VERSAO"] = Tabela.Versao;
                    oSQL.ParamByName["FONTE"] = Tabela.Fonte;
                    oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = Tabela.IDUnidadeFederativa;
                    return oSQL.ExecSQL() == 1;
                }
            }
            catch { return false; }
        }




        public static Ncm GetVigenciaIBPT()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT MIN(VIGENCIAINICIO) AS VIGENCIAINICIO,
                                    MIN(VIGENCIAFIM) AS VIGENCIAFIM,
                                    CHAVE
                               FROM NCM
                             GROUP BY CHAVE";
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Ncm>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
    }
}