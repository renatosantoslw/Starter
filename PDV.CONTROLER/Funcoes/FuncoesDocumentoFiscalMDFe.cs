using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.MDFe;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesDocumentoFiscalMDFe
    {
        public static DataTable GetDocumentosFiscal(decimal IDMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DOCUMENTOFISCALMDFE.IDDOCUMENTOFISCALMDFE,
                                    DOCUMENTOFISCALMDFE.IDMDFE,
                                    DOCUMENTOFISCALMDFE.IDMUNICIPIODESCARGA,
                                    NFEREFERENCIADAMDFE.IDNFEREFERENCIADAMDFE,
                                    UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                    
                                    NFEREFERENCIADAMDFE.CHAVENFE,
                                    MUNICIPIO.DESCRICAO AS MUNICIPIO,
                                    UNIDADEFEDERATIVA.SIGLA
                               FROM DOCUMENTOFISCALMDFE
                                 INNER JOIN NFEREFERENCIADAMDFE ON (DOCUMENTOFISCALMDFE.IDDOCUMENTOFISCALMDFE = NFEREFERENCIADAMDFE.IDDOCUMENTOFISCALMDFE)
                                 INNER JOIN MUNICIPIO ON (MUNICIPIO.IDMUNICIPIO = DOCUMENTOFISCALMDFE.IDMUNICIPIODESCARGA)
                                 INNER JOIN UNIDADEFEDERATIVA ON (MUNICIPIO.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                             WHERE DOCUMENTOFISCALMDFE.IDMDFE = @IDMDFE
                             ORDER BY MUNICIPIO.DESCRICAO, UNIDADEFEDERATIVA.SIGLA";
                oSQL.ParamByName["IDMDFE"] = IDMDFe;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool SalvarNFeReferenciada(NFeReferenciadaMDFe NFe, decimal IDMDFe, decimal IDMunicipioDescarga)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "INSERT INTO DOCUMENTOFISCALMDFE (IDDOCUMENTOFISCALMDFE, IDMDFE, IDMUNICIPIODESCARGA) VALUES (@IDDOCUMENTOFISCALMDFE, @IDMDFE, @IDMUNICIPIODESCARGA)";
                oSQL.ParamByName["IDDOCUMENTOFISCALMDFE"] = NFe.IDDocumentoFiscalMDFe;
                oSQL.ParamByName["IDMDFE"] = IDMDFe;
                oSQL.ParamByName["IDMUNICIPIODESCARGA"] = IDMunicipioDescarga;
                oSQL.ExecSQL();

                oSQL.ClearAll();

                oSQL.SQL = "INSERT INTO NFEREFERENCIADAMDFE (IDNFEREFERENCIADAMDFE, IDDOCUMENTOFISCALMDFE, CHAVENFE) VALUES (@IDNFEREFERENCIADAMDFE, @IDDOCUMENTOFISCALMDFE, @CHAVENFE)";
                oSQL.ParamByName["IDNFEREFERENCIADAMDFE"] = NFe.IDNFeReferenciadaMDFe;
                oSQL.ParamByName["IDDOCUMENTOFISCALMDFE"] = NFe.IDDocumentoFiscalMDFe;
                oSQL.ParamByName["CHAVENFE"] = NFe.ChaveNFe;
                return oSQL.ExecSQL() == 1;
            }
        }
        public static bool RemoverNFeReferenciada(decimal IDDocumentoFiscalMDFe, decimal IDNFeReferenciadaMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM NFEREFERENCIADAMDFE WHERE IDNFEREFERENCIADAMDFE = @IDNFEREFERENCIADAMDFE";
                oSQL.ParamByName["IDNFEREFERENCIADAMDFE"] = IDNFeReferenciadaMDFe;
                oSQL.ExecSQL();

                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM DOCUMENTOFISCALMDFE WHERE IDDOCUMENTOFISCALMDFE = @IDDOCUMENTOFISCALMDFE";
                oSQL.ParamByName["IDDOCUMENTOFISCALMDFE"] = IDDocumentoFiscalMDFe;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
