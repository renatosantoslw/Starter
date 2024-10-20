using IntegradorZeusPDV.DB;
using IntegradorZeusPDV.DB.DB.Controller;
using IntegradorZeusPDV.DB.DB.Utils;
using IntegradorZeusPDV.MODEL.ClassesPDV;

namespace IntegradorZeusPDV.CONTROLLER.Funcoes
{
    public class FuncoesEmitente
    {
        public static bool SalvarEmitente(Emitente _Emitente, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO EMITENTE(
                                                 IDEMITENTE, IDENDERECO, CNPJ, RAZAOSOCIAL, NOMEFANTASIA, EMAIL, 
                                                 CRT, CERTIFICADO, CSC, IDCSC, CNAE, INSCRICAOMUNICIPAL, 
                                                 INSCRICAOESTADUAL, LOGOMARCA, NOMECERTIFICADO, NOMELOGOMARCA, SENHACERTIFICADO)
                                         VALUES (@IDEMITENTE, @IDENDERECO, @CNPJ, @RAZAOSOCIAL, @NOMEFANTASIA, @EMAIL, 
                                                 @CRT, @CERTIFICADO, @CSC, @IDCSC, @CNAE, @INSCRICAOMUNICIPAL, 
                                                 @INSCRICAOESTADUAL, @LOGOMARCA, @NOMECERTIFICADO, @NOMELOGOMARCA, @SENHACERTIFICADO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE EMITENTE
                                       SET IDENDERECO = @IDENDERECO, CNPJ = @CNPJ, RAZAOSOCIAL = @RAZAOSOCIAL, NOMEFANTASIA = @NOMEFANTASIA, 
                                           EMAIL = @EMAIL, CRT = @CRT, CERTIFICADO = @CERTIFICADO, CSC = @CSC, IDCSC = @IDCSC, 
                                           CNAE = @CNAE, INSCRICAOMUNICIPAL = @INSCRICAOMUNICIPAL, INSCRICAOESTADUAL = @INSCRICAOESTADUAL, LOGOMARCA = @LOGOMARCA,
                                           NOMECERTIFICADO = @NOMECERTIFICADO, NOMELOGOMARCA = @NOMELOGOMARCA, SENHACERTIFICADO = @SENHACERTIFICADO
                                     WHERE IDEMITENTE = @IDEMITENTE";
                        break;
                }
                oSQL.ParamByName["IDEMITENTE"] = _Emitente.IDEmitente;
                oSQL.ParamByName["IDENDERECO"] = _Emitente.IDEndereco;
                oSQL.ParamByName["CNPJ"] = _Emitente.CNPJ;
                oSQL.ParamByName["RAZAOSOCIAL"] = _Emitente.RazaoSocial;
                oSQL.ParamByName["NOMEFANTASIA"] = _Emitente.NomeFantasia;
                oSQL.ParamByName["EMAIL"] = _Emitente.Email;
                oSQL.ParamByName["CRT"] = _Emitente.CRT;
                oSQL.ParamByName["CERTIFICADO"] = _Emitente.Certificado;
                oSQL.ParamByName["CSC"] = _Emitente.CSC;
                oSQL.ParamByName["IDCSC"] = _Emitente.IDCSC;
                oSQL.ParamByName["CNAE"] = _Emitente.CNAE;
                oSQL.ParamByName["INSCRICAOMUNICIPAL"] = _Emitente.InscricaoMunicipal;
                oSQL.ParamByName["INSCRICAOESTADUAL"] = _Emitente.InscricaoEstadual;
                oSQL.ParamByName["LOGOMARCA"] = _Emitente.Logomarca;
                oSQL.ParamByName["NOMECERTIFICADO"] = _Emitente.NomeCertificado;
                oSQL.ParamByName["NOMELOGOMARCA"] = _Emitente.NomeLogomarca;
                oSQL.ParamByName["SENHACERTIFICADO"] = _Emitente.SenhaCertificado;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static Emitente GetEmitente()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDEMITENTE, 
                                    IDENDERECO, 
                                    CNPJ, 
                                    RAZAOSOCIAL, 
                                    NOMEFANTASIA, 
                                    EMAIL, 
                                    CRT,
                                    CERTIFICADO, 
                                    CSC, 
                                    IDCSC, 
                                    CNAE, 
                                    INSCRICAOMUNICIPAL, 
                                    INSCRICAOESTADUAL, 
                                    LOGOMARCA,
                                    NOMECERTIFICADO,
                                    NOMELOGOMARCA,
                                    SENHACERTIFICADO
                               FROM EMITENTE";
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Emitente>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

    }
}