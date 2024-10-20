using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesCategoria
    {
        public static bool Existe(decimal IDCategoria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CATEGORIA WHERE IDCATEGORIA = @IDCATEGORIA";
                oSQL.ParamByName["IDCATEGORIA"] = IDCategoria;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
        public static bool Existe(string descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CATEGORIA WHERE DESCRICAO = @DESCRICAO";
                oSQL.ParamByName["DESCRICAO"] = descricao;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
        public static Categoria GetCategoria(decimal IDCATEGORIA)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCATEGORIA,
                                    CODIGO,
                                    DESCRICAO, Imagem
                               FROM CATEGORIA
                             WHERE IDCATEGORIA = @IDCATEGORIA";
                oSQL.ParamByName["IDCATEGORIA"] = IDCATEGORIA;
                oSQL.Open();
                return EntityUtil<Categoria>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static Categoria GetCategoria(string descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT TOP 1 IDCATEGORIA,
                                    CODIGO,
                                    DESCRICAO, Imagem
                               FROM CATEGORIA
                             WHERE DESCRICAO = @DESCRICAO ";
                oSQL.ParamByName["DESCRICAO"] = descricao;
                oSQL.Open();
                if (oSQL.dtDados.Rows.Count > 0)
                    return EntityUtil<Categoria>.ParseDataRow(oSQL.dtDados.Rows[0]);
                else
                    return null;
            }
        }

        public static DataTable GetCategorias(string Codigo, string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Codigo))
                    Filtros.Add(string.Format("(UPPER(CODIGO) LIKE UPPER('%{0}%'))", Codigo));

                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UPPER(DESCRICAO) LIKE UPPER('%{0}%'))", Descricao));

                oSQL.SQL = string.Format(
                           @"SELECT IDCATEGORIA,
                                    CODIGO,
                                    DESCRICAO
                               FROM CATEGORIA {0}
                             ORDER BY DESCRICAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<Categoria> GetCategorias()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCATEGORIA,
                                    CODIGO,
                                    DESCRICAO,
                                    ISNULL(CODIGO, '') + ' - ' + ISNULL(DESCRICAO, '') AS CODIGODESCRICAO, IMAGEM as IMAGEM
                               FROM CATEGORIA
                             ORDER BY CODIGO, DESCRICAO";
                oSQL.Open();
                return new DataTableParser<Categoria>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<Categoria> GetCategoriasParaVender()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT C.IDCATEGORIA,
                                    C.CODIGO,
                                    C.DESCRICAO,
                                    ISNULL(C.CODIGO, '')+' - '+ISNULL(C.DESCRICAO, '') AS CODIGODESCRICAO, C.IMAGEM as IMAGEM
                               FROM CATEGORIA AS C
							  JOIN PRODUTO AS P ON (P.IDCATEGORIA = C.IDCATEGORIA)
							  WHERE P.PARAVENDER = 1
                             ORDER BY DESCRICAO,CODIGO";
                oSQL.Open();
                return new DataTableParser<Categoria>().ParseDataTable(oSQL.dtDados);
            }
        }


        public static bool Salvar(Categoria _Categoria, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = "INSERT INTO CATEGORIA (IDCATEGORIA, CODIGO, DESCRICAO,IMAGEM) VALUES (@IDCATEGORIA, @CODIGO, @DESCRICAO,CONVERT(varbinary(max),@IMAGEM))";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CATEGORIA
                                      SET CODIGO = @CODIGO,
                                          DESCRICAO = @DESCRICAO,IMAGEM = CONVERT(varbinary(max),@IMAGEM)
                                          WHERE IDCATEGORIA = @IDCATEGORIA";
                        break;
                }
                oSQL.ParamByName["IDCATEGORIA"] = _Categoria.IDCategoria;
                oSQL.ParamByName["CODIGO"] = _Categoria.Codigo;
                oSQL.ParamByName["DESCRICAO"] = _Categoria.Descricao;
                oSQL.ParamByName["IMAGEM"] = _Categoria.Imagem;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDCategoria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PRODUTO WHERE COALESCE(IDCATEGORIA, IDSUBCATEGORIA) = @IDCATEGORIA";
                oSQL.ParamByName["IDCATEGORIA"] = IDCategoria;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    throw new Exception("A Categoria tem vínculo com produto e não pode ser removido.");

                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM CATEGORIA WHERE IDCATEGORIA = @IDCATEGORIA";
                oSQL.ParamByName["IDCATEGORIA"] = IDCategoria;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
