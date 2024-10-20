using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.MDFe;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesResponsavelSeguroCargaMDFe
    {
        public static bool Salvar(ResponsavelSeguroCargaMDFe Responsavel, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO 
                                         RESPONSAVELSEGUROCARGAMDFE (IDRESPONSAVELSEGUROCARGAMDFE, RESPONSAVELSEGURO, CNPJ, CPF)
                                     VALUES (@IDRESPONSAVELSEGUROCARGAMDFE, @RESPONSAVELSEGURO, @CNPJ, @CPF)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE RESPONSAVELSEGUROCARGAMDFE
                                        SET RESPONSAVELSEGURO = @RESPONSAVELSEGURO, 
                                            CNPJ = @CNPJ, 
                                            CPF = @CPF
                                        WHERE IDRESPONSAVELSEGUROCARGAMDFE = @IDRESPONSAVELSEGUROCARGAMDFE";
                        break;
                }
                oSQL.ParamByName["IDRESPONSAVELSEGUROCARGAMDFE"] = Responsavel.IDResponsavelSeguroCargaMDFe;
                oSQL.ParamByName["RESPONSAVELSEGURO"] = Responsavel.ResponsavelSeguro;
                oSQL.ParamByName["CNPJ"] = Responsavel.CNPJ;
                oSQL.ParamByName["CPF"] = Responsavel.CPF;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static ResponsavelSeguroCargaMDFe GetResponsavel(decimal IDResponsavelSeguroCargaMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDRESPONSAVELSEGUROCARGAMDFE,
RESPONSAVELSEGURO,
CNPJ,
CPF FROM RESPONSAVELSEGUROCARGAMDFE WHERE IDRESPONSAVELSEGUROCARGAMDFE = @IDRESPONSAVELSEGUROCARGAMDFE";
                oSQL.ParamByName["IDRESPONSAVELSEGUROCARGAMDFE"] = IDResponsavelSeguroCargaMDFe;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<ResponsavelSeguroCargaMDFe>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Remover(decimal IDResponsavelSeguroCargaMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1 FROM RESPONSAVELSEGUROCARGAMDFE WHERE IDRESPONSAVELSEGUROCARGAMDFE = @IDRESPONSAVELSEGUROCARGAMDFE";
                oSQL.ParamByName["IDRESPONSAVELSEGUROCARGAMDFE"] = IDResponsavelSeguroCargaMDFe;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return true;

                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM RESPONSAVELSEGUROCARGAMDFE WHERE IDRESPONSAVELSEGUROCARGAMDFE = @IDRESPONSAVELSEGUROCARGAMDFE";
                oSQL.ParamByName["IDRESPONSAVELSEGUROCARGAMDFE"] = IDResponsavelSeguroCargaMDFe;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
