using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.NFe;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesDocumentoReferenciadoNFe
    {
        public static List<DocumentoReferenciado> GetTiposDocumentoReferenciado()
        {
            List<DocumentoReferenciado> Docs = new List<DocumentoReferenciado>();
            Docs.Add(new DocumentoReferenciado() { Codigo = 55, Descricao = "NF-e [Modelo 55]" });
            Docs.Add(new DocumentoReferenciado() { Codigo = 65, Descricao = "NFC-e [Modelo 65]" });
            return Docs;
        }

        public static DataTable GetDocumentosReferenciadosNFe(decimal IDNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DOCUMENTOREFERENCIADONFE.IDDOCUMENTOREFERENCIADONFE,
                                    DOCUMENTOREFERENCIADONFE.IDNFE,
                                    DOCUMENTOREFERENCIADONFE.IDUNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.SIGLA AS UNIDADEFEDERATIVA,
                                    DOCUMENTOREFERENCIADONFE.CHAVE,
                                    DOCUMENTOREFERENCIADONFE.CODIGODOCUMENTOREFERENCIADO,
                                    CASE 
                                      WHEN DOCUMENTOREFERENCIADONFE.CODIGODOCUMENTOREFERENCIADO = 55 THEN 'NF-e [Modelo 55]'
                                      WHEN DOCUMENTOREFERENCIADONFE.CODIGODOCUMENTOREFERENCIADO = 65 THEN 'NF-e [Modelo 65]'
                                    END AS DOCUMENTOREFERENCIADO
                               FROM DOCUMENTOREFERENCIADONFE
                                 INNER JOIN UNIDADEFEDERATIVA ON (DOCUMENTOREFERENCIADONFE.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                            WHERE DOCUMENTOREFERENCIADONFE.IDNFE = @IDNFE";
                oSQL.ParamByName["IDNFE"] = IDNFe;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Salvar(DocumentoReferenciadoNFe Doc)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"INSERT INTO DOCUMENTOREFERENCIADONFE
                               (IDDOCUMENTOREFERENCIADONFE, IDNFE, IDUNIDADEFEDERATIVA, CHAVE, CODIGODOCUMENTOREFERENCIADO)
                             VALUES
                               (@IDDOCUMENTOREFERENCIADONFE, @IDNFE, @IDUNIDADEFEDERATIVA, @CHAVE, @CODIGODOCUMENTOREFERENCIADO)";
                oSQL.ParamByName["IDNFE"] = Doc.IDNFe;
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = Doc.IDUnidadeFederativa;
                oSQL.ParamByName["CHAVE"] = Doc.Chave;
                oSQL.ParamByName["CODIGODOCUMENTOREFERENCIADO"] = Doc.CodigoDocumentoReferenciado;
                oSQL.ParamByName["IDDOCUMENTOREFERENCIADONFE"] = Doc.IDDocumentoReferenciadoNFe;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDDocumentoReferenciadoNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM DOCUMENTOREFERENCIADONFE WHERE IDDOCUMENTOREFERENCIADONFE = @IDDOCUMENTOREFERENCIADONFE";
                oSQL.ParamByName["IDDOCUMENTOREFERENCIADONFE"] = IDDocumentoReferenciadoNFe;
                return oSQL.ExecSQL() >= 0;
            }
        }
    }
}
