using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.MDFe;
using PDV.DAO.Enum;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesSeguradoraMDFe
    {
        public static bool Salvar(SeguradoraMDFe Seguradora, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO SEGURADORAMDFE 
                                        (IDSEGURADORAMDFE, IDSEGURADORA, IDMDFE, NUMEROAPOLICE, IDRESPONSAVELSEGUROCARGAMDFE)
                                     VALUES (@IDSEGURADORAMDFE, @IDSEGURADORA, @IDMDFE, @NUMEROAPOLICE, @IDRESPONSAVELSEGUROCARGAMDFE)";
                        oSQL.ParamByName["IDMDFE"] = Seguradora.IDMDFe;
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE SEGURADORAMDFE
                                       SET IDSEGURADORA = @IDSEGURADORA,
                                           NUMEROAPOLICE = @NUMEROAPOLICE,
                                           IDRESPONSAVELSEGUROCARGAMDFE = @IDRESPONSAVELSEGUROCARGAMDFE
                                       WHERE IDSEGURADORAMDFE = @IDSEGURADORAMDFE";
                        break;
                }
                oSQL.ParamByName["IDSEGURADORAMDFE"] = Seguradora.IDSeguradoraMDFe;
                oSQL.ParamByName["IDSEGURADORA"] = Seguradora.IDSeguradora;
                oSQL.ParamByName["IDMDFE"] = Seguradora.IDMDFe;
                oSQL.ParamByName["NUMEROAPOLICE"] = Seguradora.NumeroApolice;
                oSQL.ParamByName["IDRESPONSAVELSEGUROCARGAMDFE"] = Seguradora.IDResponsavelSeguroCargaMDFe;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDSeguradoraMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1 FROM SEGURADORAMDFE WHERE IDSEGURADORAMDFE = @IDSEGURADORAMDFE";
                oSQL.ParamByName["IDSEGURADORAMDFE"] = IDSeguradoraMDFe;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return true;

                oSQL.SQL = @"DELETE FROM SEGURADORAMDFE WHERE IDSEGURADORAMDFE = @IDSEGURADORAMDFE";
                oSQL.ParamByName["IDSEGURADORAMDFE"] = IDSeguradoraMDFe;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetSegurosPorMDFe(decimal IDMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT SEGURADORAMDFE.NUMEROAPOLICE,
                                    SEGURADORA.DESCRICAO AS SEGURADORA,
                                    CASE 
                                      WHEN COALESCE(RESPONSAVELSEGUROCARGAMDFE.CNPJ, '') = '' AND COALESCE(RESPONSAVELSEGUROCARGAMDFE.CPF, '') = '' THEN '<Não Informado>'
                                      ELSE COALESCE(RESPONSAVELSEGUROCARGAMDFE.CPF, RESPONSAVELSEGUROCARGAMDFE.CNPJ)
                                    END AS RESPONSAVEL,
                             
                                    SEGURADORAMDFE.IDSEGURADORAMDFE,
                                    SEGURADORAMDFE.IDSEGURADORA,
                                    SEGURADORAMDFE.IDMDFE,
                                    SEGURADORAMDFE.IDRESPONSAVELSEGUROCARGAMDFE,
                                    RESPONSAVELSEGUROCARGAMDFE.RESPONSAVELSEGURO,
                                    RESPONSAVELSEGUROCARGAMDFE.CPF,
                                    RESPONSAVELSEGUROCARGAMDFE.CNPJ
                               FROM SEGURADORAMDFE
                                INNER JOIN SEGURADORA ON (SEGURADORAMDFE.IDSEGURADORA = SEGURADORA.IDSEGURADORA)
                                 LEFT JOIN RESPONSAVELSEGUROCARGAMDFE ON (SEGURADORAMDFE.IDRESPONSAVELSEGUROCARGAMDFE = RESPONSAVELSEGUROCARGAMDFE.IDRESPONSAVELSEGUROCARGAMDFE)
                             WHERE SEGURADORAMDFE.IDMDFE = @IDMDFE
                             ORDER BY SEGURADORA.DESCRICAO";
                oSQL.ParamByName["IDMDFE"] = IDMDFe;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }


    }
}
