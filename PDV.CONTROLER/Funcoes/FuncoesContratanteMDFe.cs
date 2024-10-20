using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.MDFe;
using System.Data;
using System;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesContratanteMDFe
    {
        public static bool Salvar(ContratanteMDFe Contratante)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "INSERT INTO CONTRATANTEMDFE (IDCONTRATANTEMDFE, IDMDFE, CPF, CNPJ) VALUES (@IDCONTRATANTEMDFE, @IDMDFE, @CPF, @CNPJ)";
                oSQL.ParamByName["IDCONTRATANTEMDFE"] = Contratante.IDContratanteMDFe;
                oSQL.ParamByName["IDMDFE"] = Contratante.IDMDFe;
                oSQL.ParamByName["CPF"] = Contratante.CPF;
                oSQL.ParamByName["CNPJ"] = Contratante.CNPJ;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetContratantesPorMDFe(decimal IDMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONTRATANTEMDFE,
                                    CPF,
                                    CNPJ,
                                    COALESCE(CPF, CNPJ) AS CPFCNPJ,
                                    IDMDFE
                               FROM CONTRATANTEMDFE 
                             WHERE IDMDFE = @IDMDFE
                             ORDER BY COALESCE(CPF, CNPJ)";
                oSQL.ParamByName["IDMDFE"] = IDMDFe;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Remover(decimal IDContratanteMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CONTRATANTEMDFE WHERE IDCONTRATANTEMDFE = @IDCONTRATANTEMDFE";
                oSQL.ParamByName["IDCONTRATANTEMDFE"] = IDContratanteMDFe;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return true;

                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM CONTRATANTEMDFE WHERE IDCONTRATANTEMDFE = @IDCONTRATANTEMDFE";
                oSQL.ParamByName["IDCONTRATANTEMDFE"] = IDContratanteMDFe;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
