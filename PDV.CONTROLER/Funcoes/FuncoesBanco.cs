using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Financeiro;
using System.Collections.Generic;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesBanco
    {
        public static List<Banco> GetBancos()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT * FROM BANCO";
                oSQL.Open();
                return new DataTableParser<Banco>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static Banco GetBanco(decimal IDContaBancaria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT BANCO.*
                               FROM CONTABANCARIA
                                 INNER JOIN BANCO ON (CONTABANCARIA.IDBANCO = BANCO.IDBANCO)
                             WHERE CONTABANCARIA.IDCONTABANCARIA = @IDCONTABANCARIA";
                oSQL.ParamByName["IDCONTABANCARIA"] = IDContaBancaria;
                oSQL.Open();
                return EntityUtil<Banco>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        //public void GravarLista<T>(List<T> listaBanco, List<T> listaTela)
        //{
        //    return ;
        //}
    }
}
