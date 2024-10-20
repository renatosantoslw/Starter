using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.MDFe;
using PDV.DAO.Enum;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesProprietario
    {
        public static bool Salvar(ProprietarioVeiculoMDFe Prop, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch(Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO PROPRIETARIOVEICULOMDFE(
                                             IDPROPRIETARIOVEICULOMDFE, CNPJ, CPF, RNTRC, NOME, INSCRICAOESTADUAL, 
                                             IDUNIDADEFEDERATIVA, TIPOPROPRIETARIO, CODIGOAGENCIAPORTO)
                                     VALUES (@IDPROPRIETARIOVEICULOMDFE, @CNPJ, @CPF, @RNTRC, @NOME, @INSCRICAOESTADUAL, 
                                             @IDUNIDADEFEDERATIVA, @TIPOPROPRIETARIO, @CODIGOAGENCIAPORTO);";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE PROPRIETARIOVEICULOMDFE
                                       SET CNPJ = @CNPJ, 
                                           CPF = @CPF,
                                           RNTRC = @RNTRC, 
                                           NOME = @NOME, 
                                           INSCRICAOESTADUAL = @INSCRICAOESTADUAL, 
                                           IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA,
                                           TIPOPROPRIETARIO = @TIPOPROPRIETARIO, 
                                           CODIGOAGENCIAPORTO = @CODIGOAGENCIAPORTO
                                     WHERE IDPROPRIETARIOVEICULOMDFE = @IDPROPRIETARIOVEICULOMDFE";
                        break;
                }
                oSQL.ParamByName["IDPROPRIETARIOVEICULOMDFE"] = Prop.IDProprietarioVeiculoMDFe;
                oSQL.ParamByName["CNPJ"] = Prop.CNPJ;
                oSQL.ParamByName["CPF"] = Prop.CPF;
                oSQL.ParamByName["RNTRC"] = Prop.RNTRC;
                oSQL.ParamByName["NOME"] = Prop.Nome;
                oSQL.ParamByName["INSCRICAOESTADUAL"] = Prop.InscricaoEstadual;
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = Prop.IDUnidadeFederativa;
                oSQL.ParamByName["TIPOPROPRIETARIO"] = Prop.TipoProprietario;
                oSQL.ParamByName["CODIGOAGENCIAPORTO"] = Prop.CodigoAgenciaPorto;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static ProprietarioVeiculoMDFe GetProprietario(decimal IDProprietarioVeiculoMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDPROPRIETARIOVEICULOMDFE,
CNPJ,
CPF,
RNTRC,
NOME,
INSCRICAOESTADUAL,
IDUNIDADEFEDERATIVA,
TIPOPROPRIETARIO,
CODIGOAGENCIAPORTO FROM PROPRIETARIOVEICULOMDFE WHERE IDPROPRIETARIOVEICULOMDFE = @IDPROPRIETARIOVEICULOMDFE";
                oSQL.ParamByName["IDPROPRIETARIOVEICULOMDFE"] = IDProprietarioVeiculoMDFe;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<ProprietarioVeiculoMDFe>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Existe(decimal IDProprietarioVeiculoMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PROPRIETARIOVEICULOMDFE WHERE IDPROPRIETARIOVEICULOMDFE = @IDPROPRIETARIOVEICULOMDFE";
                oSQL.ParamByName["IDPROPRIETARIOVEICULOMDFE"] = IDProprietarioVeiculoMDFe;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool Remover(decimal IDProprietarioVeiculoMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM PROPRIETARIOVEICULOMDFE WHERE IDPROPRIETARIOVEICULOMDFE = @IDPROPRIETARIOVEICULOMDFE";
                oSQL.ParamByName["IDPROPRIETARIOVEICULOMDFE"] = IDProprietarioVeiculoMDFe;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetProprietarios(string Nome, string CpfCnpj)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT IDPROPRIETARIOVEICULOMDFE,
                                     CNPJ,
                                     CPF,
                                     COALESCE(CNPJ, CPF) AS CPFCNPJ,
                                     NOME,
                                     RNTRC,
                                     INSCRICAOESTADUAL, 
                                     IDUNIDADEFEDERATIVA,
                                     TIPOPROPRIETARIO,
                                     CODIGOAGENCIAPORTO
                               FROM PROPRIETARIOVEICULOMDFE
                              WHERE UPPER(NOME) LIKE UPPER('%{Nome}%')
                               AND (UPPER(CPF) LIKE UPPER('%{CpfCnpj}%') OR UPPER(CNPJ) LIKE UPPER('%{CpfCnpj}%'))";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<ProprietarioVeiculoMDFe> GetProprietarios()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDPROPRIETARIOVEICULOMDFE,
CNPJ,
CPF,
RNTRC,
NOME,
INSCRICAOESTADUAL,
IDUNIDADEFEDERATIVA,
TIPOPROPRIETARIO,
CODIGOAGENCIAPORTO FROM PROPRIETARIOVEICULOMDFE";
                oSQL.Open();
                return new DataTableParser<ProprietarioVeiculoMDFe>().ParseDataTable(oSQL.dtDados);
            }
        }
    }
}
