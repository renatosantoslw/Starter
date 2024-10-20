using System;
using System.Collections.Generic;
using System.Data;
using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesEmitente
    {
        public static EmailEmitente GetEmailEmitente(decimal IDEmitente)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT AUTORIZARENVIAREMAIL,
                                    AUTORIZARASSUNTO,
                                    AUTORIZARMENSAGEM,
                                    CANCELARENVIAREMAIL,
                                    CANCELARASSUNTO,
                                    CANCELARMENSAGEM,
                                    IDEMAILEMITENTE
                               FROM EMAILEMITENTE
                             WHERE IDEMITENTE = @IDEMITENTE";
                oSQL.ParamByName["IDEMITENTE"] = IDEmitente;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<EmailEmitente>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetEmitentePesquisa(string Nome_RazaoSocial, string CPF_CNPJ, string InscricaoEstadual)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Nome_RazaoSocial))
                    Filtros.Add(string.Format("(UPPER(RAZAOSOCIAL) LIKE UPPER('%{0}%') OR UPPER(NOME) LIKE UPPER('%{0}%'))", Nome_RazaoSocial));

                if (!string.IsNullOrEmpty(CPF_CNPJ))
                    Filtros.Add(string.Format("(CNPJ LIKE UPPER('%{0}%') OR CPF LIKE UPPER('%{0}%'))", CPF_CNPJ));

                if (!string.IsNullOrEmpty(InscricaoEstadual))
                    Filtros.Add(string.Format("(INSCRICAOESTADUAL::VARCHAR LIKE UPPER('%{0}%'))", InscricaoEstadual));

                oSQL.SQL = string.Format(@"SELECT IDEMITENTE,
                                                  RAZAOSOCIAL AS DESCRICAO,
                                                  CNPJ AS NUMERODOCUMENTO,
                                                  INSCRICAOESTADUAL,
                                                 'JURIDICA' TIPO,
                                                  ATIVO
                                           FROM EMITENTE {0}
                                           ORDER BY RAZAOSOCIAL ", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool SalvarEmailEmitente(EmailEmitente Email, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO 
                                        EMAILEMITENTE (IDEMAILEMITENTE, IDEMITENTE, AUTORIZARENVIAREMAIL, 
                                                       AUTORIZARASSUNTO, AUTORIZARMENSAGEM, CANCELARENVIAREMAIL, 
                                                       CANCELARASSUNTO, CANCELARMENSAGEM)
                                     VALUES (@IDEMAILEMITENTE, @IDEMITENTE, @AUTORIZARENVIAREMAIL, 
                                             @AUTORIZARASSUNTO, @AUTORIZARMENSAGEM, @CANCELARENVIAREMAIL, 
                                             @CANCELARASSUNTO, @CANCELARMENSAGEM)";
                        oSQL.ParamByName["IDEMITENTE"] = Email.IDEmitente;
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE EMAILEMITENTE
                                       SET AUTORIZARENVIAREMAIL = @AUTORIZARENVIAREMAIL,
                                           AUTORIZARASSUNTO = @AUTORIZARASSUNTO,
                                           AUTORIZARMENSAGEM = @AUTORIZARMENSAGEM,
                                           CANCELARENVIAREMAIL = @CANCELARENVIAREMAIL,
                                           CANCELARASSUNTO = @CANCELARASSUNTO,
                                           CANCELARMENSAGEM = @CANCELARMENSAGEM
		                             WHERE IDEMAILEMITENTE = @IDEMAILEMITENTE";
                        break;
                }
                oSQL.ParamByName["AUTORIZARENVIAREMAIL"] = Email.AutorizarEnviarEmail;
                oSQL.ParamByName["AUTORIZARASSUNTO"] = Email.AutorizarAssunto;
                oSQL.ParamByName["AUTORIZARMENSAGEM"] = Email.AutorizarMensagem;
                oSQL.ParamByName["CANCELARENVIAREMAIL"] = Email.CancelarEnviarEmail;
                oSQL.ParamByName["CANCELARASSUNTO"] = Email.CancelarAssunto;
                oSQL.ParamByName["CANCELARMENSAGEM"] = Email.CancelarMensagem;
                oSQL.ParamByName["IDEMAILEMITENTE"] = Email.IDEmailEmitente;
                return oSQL.ExecSQL() == 1;
            }
        }


        /* Funções Emitente */

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
                                                 INSCRICAOESTADUAL, LOGOMARCA, NOMECERTIFICADO, NOMELOGOMARCA, SENHACERTIFICADO,
                                                VERSAOXML ,CODIGOATIVACAO ,PASTAINPUT ,PASTAOUTPUT  ,CNPJSOFTWAREHOUSE ,SIGNAC ,CREGTRIBISSQN  ,INDRATISSQN ,CHAVEACESSOVALIDADOR,PASTAXML
                                                LOGOPROPRAGANDA, NOMELOGOPROPRAGANDA,
                                                  PROXIMONUMERONFE, PROXIMONUMERONFCE, MODELOIMPRESSAODAV, EMAILCONTADOR)
                                         VALUES (@IDEMITENTE, @IDENDERECO, @CNPJ, @RAZAOSOCIAL, @NOMEFANTASIA, @EMAIL, 
                                                 @CRT, @CERTIFICADO, @CSC, @IDCSC, @CNAE, @INSCRICAOMUNICIPAL, 
                                                 @INSCRICAOESTADUAL, @LOGOMARCA, @NOMECERTIFICADO, @NOMELOGOMARCA, @SENHACERTIFICADO,
                                                @VERSAOXML ,@CODIGOATIVACAO ,@PASTAINPUT ,@PASTAOUTPUT  ,@CNPJSOFTWAREHOUSE ,@SIGNAC ,@CREGTRIBISSQN  ,@INDRATISSQN ,@CHAVEACESSOVALIDADOR,@PASTAXML,
                                                  @LOGOPROPRAGANDA,@NOMELOGOPROPRAGANDA,
                                                   @PROXIMONUMERONFE, @PROXIMONUMERONFCE, @MODELOIMPRESSAODAV, @EMAILCONTADOR)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE EMITENTE
                                       SET IDENDERECO               = @IDENDERECO,
                                        CNPJ                        = @CNPJ,
                                        RAZAOSOCIAL                 = @RAZAOSOCIAL,
                                        NOMEFANTASIA                = @NOMEFANTASIA,
                                        EMAIL                       = @EMAIL,
                                        CRT                         = @CRT,
                                        CERTIFICADO                 = @CERTIFICADO,
                                        CSC                         = @CSC,
                                        IDCSC                       = @IDCSC,
                                        CNAE                        = @CNAE,
                                        INSCRICAOMUNICIPAL          = @INSCRICAOMUNICIPAL,
                                        INSCRICAOESTADUAL           = @INSCRICAOESTADUAL,
                                        LOGOMARCA                    = @LOGOMARCA,
                                        NOMECERTIFICADO             = @NOMECERTIFICADO,
                                        NOMELOGOMARCA               = @NOMELOGOMARCA,
                                        SENHACERTIFICADO            = @SENHACERTIFICADO,
                                        VERSAOXML                   = @VERSAOXML  ,
                                        CODIGOATIVACAO              = @CODIGOATIVACAO ,
                                        PASTAINPUT                  = @PASTAINPUT ,
                                        PASTAOUTPUT                 = @PASTAOUTPUT  ,
                                        CNPJSOFTWAREHOUSE           = @CNPJSOFTWAREHOUSE ,
                                        SIGNAC                      = @SIGNAC ,
                                        CREGTRIBISSQN               = @CREGTRIBISSQN  ,
                                        INDRATISSQN                 = @INDRATISSQN ,
                                        CHAVEACESSOVALIDADOR        = @CHAVEACESSOVALIDADOR,
                                        LOGOPROPRAGANDA = @LOGOPROPRAGANDA,
                                        NOMELOGOPROPRAGANDA = @NOMELOGOPROPRAGANDA,
                                        PROXIMONUMERONFE = @PROXIMONUMERONFE,
                                        PROXIMONUMERONFCE = @PROXIMONUMERONFCE,
                                        MODELOIMPRESSAODAV = @MODELOIMPRESSAODAV,
                                        PASTAXML = @PASTAXML,
                                        EMAILCONTADOR = @EMAILCONTADOR
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
                oSQL.ParamByName["VersaoXML"] = _Emitente.VersaoXML;
                oSQL.ParamByName["CodigoAtivacao"] = _Emitente.CodigoAtivacao;
                oSQL.ParamByName["PASTAINPUT"] = _Emitente.PastaInput;
                oSQL.ParamByName["PASTAOUTPUT"] = _Emitente.PastaOutPut;
                oSQL.ParamByName["CNPJSOFTWAREHOUSE"] = _Emitente.CNPJSoftwareHouse;
                oSQL.ParamByName["SignAC"] = _Emitente.SignAC;
                oSQL.ParamByName["CRegTribISSQN"] = _Emitente.CRegTribISSQN;
                oSQL.ParamByName["IndRatISSQN"] = _Emitente.IndRatISSQN;
                oSQL.ParamByName["chaveAcessoValidador"] = _Emitente.chaveAcessoValidador;
                oSQL.ParamByName["pastaxml"] = _Emitente.PastaXml;
                oSQL.ParamByName["logopropraganda"] = _Emitente.logopropraganda;
                oSQL.ParamByName["nomelogopropraganda"] = _Emitente.nomelogopropraganda;
                oSQL.ParamByName["PROXIMONUMERONFE"] = _Emitente.ProximoNumeroNFe;
                oSQL.ParamByName["PROXIMONUMERONFCE"] = _Emitente.ProximoNumeroNFCe;
                oSQL.ParamByName["MODELOIMPRESSAODAV"] = _Emitente.ModeloImpressaoDAV;
                oSQL.ParamByName["EMAILCONTADOR"] = _Emitente.emailContador;
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
                                    SENHACERTIFICADO, 
                                    chaveerp,
                                    datalocal,
                                    VersaoXML ,
                                    CodigoAtivacao ,
                                    PastaInput ,
                                    PastaOutPut  ,
                                    CNPJSoftwareHouse ,
                                    SignAC ,
                                    CRegTribISSQN  ,
                                    IndRatISSQN ,
                                    chaveAcessoValidador,pastaxml,
                                        logopropraganda,
                                        nomelogopropraganda,
                                        PROXIMONUMERONFE,
                                        PROXIMONUMERONFCE,
                                        MODELOIMPRESSAODAV,
                                    EMAILCONTADOR
                               FROM EMITENTE";
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Emitente>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Emitente GetEmitentePorID(decimal IDEmitente)
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
                                    SENHACERTIFICADO,
                                    chaveerp,
                                    datalocal,
                                    VersaoXML ,
                                    CodigoAtivacao ,
                                    PastaInput ,
                                    PastaOutPut  ,
                                    CNPJSoftwareHouse ,
                                    SignAC ,
                                    CRegTribISSQN  ,
                                    IndRatISSQN ,
                                    chaveAcessoValidador,
                                    emailContador
                               FROM EMITENTE WHERE IDEMITENTE =@IDEMITENTE ";
                oSQL.ParamByName["IDEMITENTE"] = IDEmitente;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Emitente>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static UnidadeFederativa GetUnidadeFederativaPorEmitente()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT UNIDADEFEDERATIVA.*
                               FROM EMITENTE
                                 INNER JOIN ENDERECO ON (EMITENTE.IDENDERECO = ENDERECO.IDENDERECO)
                                 INNER JOIN UNIDADEFEDERATIVA ON (ENDERECO.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)";
                oSQL.Open();
                return EntityUtil<UnidadeFederativa>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static bool AtualizarChave(string Chave, string DataLocal)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE emitente
                                       SET chaveerp = @chaveerp , datalocal = @datalocal ";
                oSQL.ParamByName["chaveerp"] = Chave;
                oSQL.ParamByName["datalocal"] = DataLocal;

                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
