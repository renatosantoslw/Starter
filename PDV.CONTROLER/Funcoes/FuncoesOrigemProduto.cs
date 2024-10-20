using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using System.Collections.Generic;
using System;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesOrigemProduto
    {

        public static List<OrigemProduto> GetOrigensProduto()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDORIGEMPRODUTO,
CODIGO,
DESCRICAO FROM ORIGEMPRODUTO";
                oSQL.Open();
                return new DataTableParser<OrigemProduto>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static OrigemProduto GetOrigemProduto(decimal IDOrigemProduto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDORIGEMPRODUTO,
CODIGO,
DESCRICAO FROM ORIGEMPRODUTO WHERE IDORIGEMPRODUTO = @IDORIGEMPRODUTO";
                oSQL.ParamByName["IDORIGEMPRODUTO"] = IDOrigemProduto;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<OrigemProduto>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static OrigemProduto GetOrigemProduto()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT TOP 1 * FROM ORIGEMPRODUTO /*LIMIT 1*/";
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<OrigemProduto>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static OrigemProduto GetOrigemProdutoPorCodigo(decimal Codigo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDORIGEMPRODUTO,
CODIGO,
DESCRICAO FROM ORIGEMPRODUTO WHERE CODIGO = @CODIGO";
                oSQL.ParamByName["CODIGO"] = Codigo;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<OrigemProduto>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
    }
}
