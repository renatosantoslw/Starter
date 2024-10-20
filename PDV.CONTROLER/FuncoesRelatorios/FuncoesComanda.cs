using PDV.DAO.DB.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.CONTROLER.FuncoesRelatorios
{
    public class FuncoesComanda
    {

        public static DataTable GetComandas(decimal CodigoInicial, decimal CodigoFinal)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCOMANDA,
                                    CODIGO,
                                    DESCRICAO
                               FROM COMANDA
                             WHERE CODIGO::NUMERIC(15) >= @CODIGOINICIAL
                               AND CODIGO::NUMERIC(15) <= @CODIGOFINAL";
                oSQL.ParamByName["CODIGOINICIAL"] = CodigoInicial;
                oSQL.ParamByName["CODIGOFINAL"] = CodigoFinal;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }


    }
}
