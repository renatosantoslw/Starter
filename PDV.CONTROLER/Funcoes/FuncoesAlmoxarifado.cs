using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.DAO.Enum;
using System.Data;
using System;
using System.Collections.Generic;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesAlmoxarifado
    {
        public static bool Salvar(Almoxarifado Almoxarifado, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO ALMOXARIFADO
                                        (IDALMOXARIFADO, DESCRICAO, TIPO)
                                     VALUES
                                        (@IDALMOXARIFADO, @DESCRICAO, @TIPO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE ALMOXARIFADO
                                      SET DESCRICAO = @DESCRICAO,
                                          TIPO = @TIPO
                                      WHERE IDALMOXARIFADO = @IDALMOXARIFADO";
                        break;
                }
                oSQL.ParamByName["IDALMOXARIFADO"] = Almoxarifado.IDAlmoxarifado;
                oSQL.ParamByName["DESCRICAO"] = Almoxarifado.Descricao;
                oSQL.ParamByName["TIPO"] = Almoxarifado.Tipo;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDAlmoxarifado)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM ALMOXARIFADO WHERE IDALMOXARIFADO = @IDALMOXARIFADO";
                oSQL.ParamByName["IDALMOXARIFADO"] = IDAlmoxarifado;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Existe(decimal IDAlmoxarifado)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM ALMOXARIFADO WHERE IDALMOXARIFADO = @IDALMOXARIFADO";
                oSQL.ParamByName["IDALMOXARIFADO"] = IDAlmoxarifado;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static DataTable GetAlmoxarifados(string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT ALMOXARIFADO.DESCRICAO,
                                     CASE
                                      WHEN ALMOXARIFADO.TIPO = 1 THEN 'Estoque'
                                      WHEN ALMOXARIFADO.TIPO = 2 THEN 'Produção'
                                      WHEN ALMOXARIFADO.TIPO = 3 THEN 'Quarentena'
                                     END AS DESCRICAOTIPO,
                                     ALMOXARIFADO.IDALMOXARIFADO,
                                     ALMOXARIFADO.TIPO
                                FROM ALMOXARIFADO 
                              WHERE UPPER(DESCRICAO) LIKE UPPER('%{Descricao}%')";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static Almoxarifado GetAlmoxarifado(decimal IDAlmoxarifado)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDALMOXARIFADO,
DESCRICAO,
TIPO FROM ALMOXARIFADO WHERE IDALMOXARIFADO = @IDALMOXARIFADO";
                oSQL.ParamByName["IDALMOXARIFADO"] = IDAlmoxarifado;
                oSQL.Open();
                return EntityUtil<Almoxarifado>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static Almoxarifado GetAlmoxarifado()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT TOP 1 * FROM ALMOXARIFADO ";
                oSQL.Open();
                return EntityUtil<Almoxarifado>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static List<Almoxarifado> GetAlmoxarifados()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT IDALMOXARIFADO, DESCRICAO, TIPO FROM ALMOXARIFADO ORDER BY DESCRICAO, TIPO";
                oSQL.Open();
                return new DataTableParser<Almoxarifado>().ParseDataTable(oSQL.dtDados);
            }
        }
    }
}
