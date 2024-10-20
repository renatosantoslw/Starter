using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesCFOP
    {
        public static bool Existe(decimal IDCfop)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CFOP WHERE IDCFOP = @IDCFOP";
                oSQL.ParamByName["IDCFOP"] = IDCfop;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static Cfop GetCFOP(decimal IDCfop)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CFOP.IDCFOP,
                                    CFOP.CODIGO,
                                    CFOP.DESCRICAO,
                                    ATIVO,
                                    TIPO
                               FROM CFOP 
                             WHERE IDCFOP = @IDCFOP";
                oSQL.ParamByName["IDCFOP"] = IDCfop;
                oSQL.Open();


                return EntityUtil<Cfop>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Cfop GetCFOPPorCodigo(string Codigo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CFOP.IDCFOP,
                                    CFOP.CODIGO,
                                    CFOP.DESCRICAO,
                                    ATIVO,
                                    TIPO
                               FROM CFOP 
                             WHERE CODIGO = @CODIGO";
                oSQL.ParamByName["CODIGO"] = Codigo;
                oSQL.Open();


                return EntityUtil<Cfop>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetCFOPS(string Codigo, string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Codigo))
                    Filtros.Add(string.Format("(UPPER(CODIGO) LIKE UPPER('%{0}%'))", Codigo));

                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UPPER(DESCRICAO) LIKE UPPER('%{0}%'))", Descricao));

                oSQL.SQL = string.Format(
                           @"SELECT CFOP.IDCFOP,
                                    CFOP.CODIGO,
                                    CFOP.DESCRICAO,
                                    ATIVO
                               FROM CFOP {0}
                             ORDER BY CODIGO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
       


        public static List<Cfop> GetCFOPSAtivos()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CFOP.IDCFOP,
                            CFOP.CODIGO,
                            CFOP.DESCRICAO,
                            cast(CFOP.CODIGO as varchar) + ' - ' + cast(CFOP.DESCRICAO as varchar) AS CODIGODESCRICAO,
                             CFOP.TIPO
                             FROM CFOP 
                             WHERE ATIVO = 1
                            ORDER BY CODIGO, cast(DESCRICAO as varchar)";
                oSQL.Open();
                return new DataTableParser<Cfop>().ParseDataTable(oSQL.dtDados);
            }
        }

        
        public static List<Cfop> GetCFOPSAtivoPorTIPO(int Tipo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CFOP.IDCFOP,
                            CFOP.CODIGO,
                            CFOP.DESCRICAO,
                            cast(CFOP.CODIGO as varchar) + ' - ' + cast(CFOP.DESCRICAO as varchar) AS CODIGODESCRICAO,
                             CFOP.TIPO
                             FROM CFOP 
                             WHERE ATIVO = 1 and TIPO = @TIPO
                            ORDER BY CODIGO, cast(DESCRICAO as varchar)";


                oSQL.ParamByName["TIPO"] = Tipo;
                oSQL.Open();
                return new DataTableParser<Cfop>().ParseDataTable(oSQL.dtDados);
            }
        }





        public static bool Salvar(Cfop _Cfop, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = "INSERT INTO CFOP (IDCFOP, CODIGO, DESCRICAO, ATIVO) VALUES (@IDCFOP, @CODIGO, @DESCRICAO, @ATIVO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CFOP
                                      SET CODIGO = @CODIGO,
                                          DESCRICAO = @DESCRICAO,
                                          ATIVO = @ATIVO
                                     WHERE IDCFOP = @IDCFOP";
                        break;
                }
                oSQL.ParamByName["IDCFOP"] = _Cfop.IDCfop;
                oSQL.ParamByName["CODIGO"] = _Cfop.Codigo;
                oSQL.ParamByName["DESCRICAO"] = _Cfop.Descricao;
                oSQL.ParamByName["ATIVO"] = _Cfop.Ativo;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDCfop)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CFOP WHERE IDCFOP = @IDCFOP";
                oSQL.ParamByName["IDCFOP"] = IDCfop;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    throw new Exception("O CFOP tem vínculo com produto e não pode ser removido.");

                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM CFOP WHERE IDCFOP = @IDCFOP";
                oSQL.ParamByName["IDCFOP"] = IDCfop;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
