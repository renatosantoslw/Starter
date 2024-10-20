using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.MDFe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesPercurso
    {
        public static bool Salvar(PercursoMDFe Percurso)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"INSERT INTO 
                                PERCURSOMDFE(IDPERCURSOMDFE, IDMDFE, IDUNIDADEFEDERATIVAPERCURSO, INICIOVIAGEM)
                             VALUES(@IDPERCURSOMDFE, @IDMDFE, @IDUNIDADEFEDERATIVAPERCURSO, @INICIOVIAGEM)";
                oSQL.ParamByName["IDPERCURSOMDFE"] = Percurso.IDPercursoMDFe;
                oSQL.ParamByName["IDMDFE"] = Percurso.IDMDFe;
                oSQL.ParamByName["IDUNIDADEFEDERATIVAPERCURSO"] = Percurso.IDUnidadeFederativaPercurso;
                oSQL.ParamByName["INICIOVIAGEM"] = Percurso.InicioViagem;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDPercursoMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PERCURSOMDFE WHERE IDPERCURSOMDFE = @IDPERCURSOMDFE";
                oSQL.ParamByName["IDPERCURSOMDFE"] = IDPercursoMDFe;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return true;

                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM PERCURSOMDFE WHERE IDPERCURSOMDFE = @IDPERCURSOMDFE";
                oSQL.ParamByName["IDPERCURSOMDFE"] = IDPercursoMDFe;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetPercursosPorMDFe(decimal IDMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.SIGLA,
                                    PERCURSOMDFE.INICIOVIAGEM,
                                    PERCURSOMDFE.IDPERCURSOMDFE,
                                    PERCURSOMDFE.IDMDFE,
                                    UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA AS IDUNIDADEFEDERATIVAPERCURSO
                               FROM PERCURSOMDFE
                             INNER JOIN UNIDADEFEDERATIVA ON (PERCURSOMDFE.IDUNIDADEFEDERATIVAPERCURSO = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                               WHERE PERCURSOMDFE.IDMDFE = @IDMDFE
                             ORDER BY PERCURSOMDFE.IDMDFE ASC";
                oSQL.ParamByName["IDMDFE"] = IDMDFe;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        
    }
}
