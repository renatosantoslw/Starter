using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using System.Collections.Generic;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesCst
    {
        public static CSTIcms GetCSTIcmsPorID(decimal IDCSTIcms)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = string.Format(@"SELECT IDCSTICMS,
CSTCSOSN,
DESCRICAO FROM CSTICMS WHERE IDCSTICMS = @IDCSTICMS");
                oSQL.ParamByName["IDCSTICMS"] = IDCSTIcms;
                oSQL.Open();
                return EntityUtil<CSTIcms>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static CSTIcms GetCSTIcmsPorCodigo(decimal Codigo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = string.Format(@"SELECT IDCSTICMS,
CSTCSOSN,
DESCRICAO FROM CSTICMS WHERE CSTCSOSN = @CSTCSOSN");
                oSQL.ParamByName["CSTCSOSN"] = Codigo;
                oSQL.Open();
                return EntityUtil<CSTIcms>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static List<CSTIcms> GetCSTIcms(decimal CRT)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = string.Format(@"SELECT IDCSTICMS,
CSTCSOSN,
DESCRICAO FROM CSTICMS WHERE {0}", CRT == 1 ? "CSTCSOSN BETWEEN 101 AND 900" : "CSTCSOSN BETWEEN 0 AND 90");
                oSQL.Open();
                return new DataTableParser<CSTIcms>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<CSTIpi> GetCSTIpi()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCSTIPI,
CST,
DESCRICAO FROM CSTIPI ORDER BY IDCSTIPI";
                oSQL.Open();
                return new DataTableParser<CSTIpi>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static CSTIpi GetCSTIpi(decimal IDCSTIpi)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCSTIPI,
CST,
DESCRICAO FROM CSTIPI WHERE IDCSTIPI = @IDCSTIPI";
                oSQL.ParamByName["IDCSTIPI"] = IDCSTIpi;
                oSQL.Open();
                return EntityUtil<CSTIpi>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static List<CSTPis> GetCSTPis()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCSTPIS,
CST,
DESCRICAO FROM CSTPIS ORDER BY IDCSTPIS";//SELECT IDCSTIPI,CST,DESCRICAO FROM CSTPIS ORDER BY IDCSTPIS
                oSQL.Open();
                return new DataTableParser<CSTPis>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static CSTPis GetCSTPis(decimal IDCSTPis)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCSTPIS,
CST,
DESCRICAO FROM CSTPIS WHERE IDCSTPIS = @IDCSTPIS";
                oSQL.ParamByName["IDCSTPIS"] = IDCSTPis;
                oSQL.Open();
                return EntityUtil<CSTPis>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static CSTPis GetCSTPisPorCST(decimal CST)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCSTPIS,
CST,
DESCRICAO FROM CSTPIS WHERE CST = @CST";
                oSQL.ParamByName["CST"] = CST;
                oSQL.Open();
                return EntityUtil<CSTPis>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static CSTCofins GetCSTCofinsPorCST(decimal CST)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCSTCOFINS,
CST,
DESCRICAO FROM CSTCOFINS WHERE CST = @CST";
                oSQL.ParamByName["CST"] = CST;
                oSQL.Open();
                return EntityUtil<CSTCofins>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }


        public static List<CSTCofins> GetCSTCofins()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCSTCOFINS,
CST,
DESCRICAO FROM CSTCOFINS ORDER BY IDCSTCOFINS";
                oSQL.Open();
                return new DataTableParser<CSTCofins>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static CSTCofins GetCSTCofins(decimal IDCSTCofins)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCSTCOFINS,
CST,
DESCRICAO FROM CSTCOFINS WHERE IDCSTCOFINS = @IDCSTCOFINS";
                oSQL.ParamByName["IDCSTCOFINS"] = IDCSTCofins;
                oSQL.Open();
                return EntityUtil<CSTCofins>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
    }
}
