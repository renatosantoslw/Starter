using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.MDFe;
using PDV.DAO.Enum;
using PDV.DAO.Custom;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesMDFe
    {
        public static bool Salvar(ManifestoDocumentoFiscalEletronico MDFe, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO MDFE(
                                                 IDMDFE, TIPOAMBIENTE, TIPOEMITENTE, TIPOTRANSPORTADOR, MODELO, 
                                                 SERIE, NMDF, CMDF, MODALIDADETRANSPORTE, EMISSAO, TIPOEMISSAO, 
                                                 IDEMITENTE, INFORMACOESADICIONAIS, INFORMACOESCOMPLEMENTARES, 
                                                 DATACADASTRO, CODIGOUNPESOCARGA, IDUNIDADEFEDERATIVADESCARREGAMENTO, PESOBRUTOTOTAL)
                                         VALUES (@IDMDFE, @TIPOAMBIENTE, @TIPOEMITENTE, @TIPOTRANSPORTADOR, @MODELO, 
                                                 @SERIE, @NMDF, @CMDF, @MODALIDADETRANSPORTE, @EMISSAO, @TIPOEMISSAO, 
                                                 @IDEMITENTE, @INFORMACOESADICIONAIS, @INFORMACOESCOMPLEMENTARES, 
                                                 @DATACADASTRO, @CODIGOUNPESOCARGA, @IDUNIDADEFEDERATIVADESCARREGAMENTO, @PESOBRUTOTOTAL)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE MDFE
                                       SET TIPOAMBIENTE = @TIPOAMBIENTE,
                                           TIPOEMITENTE = @TIPOEMITENTE,
                                           TIPOTRANSPORTADOR = @TIPOTRANSPORTADOR, 
                                           MODELO = @MODELO,
                                           SERIE = @SERIE,
                                           NMDF = @NMDF,
                                           CMDF = @CMDF,
                                           MODALIDADETRANSPORTE = @MODALIDADETRANSPORTE,
                                           EMISSAO = @EMISSAO, 
                                           TIPOEMISSAO = @TIPOEMISSAO,
                                           IDEMITENTE = @IDEMITENTE,
                                           INFORMACOESADICIONAIS = @INFORMACOESADICIONAIS, 
                                           INFORMACOESCOMPLEMENTARES = @INFORMACOESCOMPLEMENTARES,
                                           DATACADASTRO = @DATACADASTRO,
                                           CODIGOUNPESOCARGA = @CODIGOUNPESOCARGA,
                                           IDUNIDADEFEDERATIVADESCARREGAMENTO = @IDUNIDADEFEDERATIVADESCARREGAMENTO,
                                           PESOBRUTOTOTAL = @PESOBRUTOTOTAL
                                     WHERE IDMDFE = @IDMDFE";
                        break;
                }
                oSQL.ParamByName["IDMDFE"] = MDFe.IDMDFe;
                oSQL.ParamByName["TIPOAMBIENTE"] = MDFe.TipoAmbiente;
                oSQL.ParamByName["TIPOEMITENTE"] = MDFe.TipoEmitente;
                oSQL.ParamByName["TIPOTRANSPORTADOR"] = MDFe.TipoTransportador;
                oSQL.ParamByName["MODELO"] = MDFe.Modelo;
                oSQL.ParamByName["SERIE"] = MDFe.Serie;
                oSQL.ParamByName["NMDF"] = MDFe.NMDF;
                oSQL.ParamByName["CMDF"] = MDFe.CMDF;
                oSQL.ParamByName["MODALIDADETRANSPORTE"] = MDFe.ModalidadeTransporte;
                oSQL.ParamByName["EMISSAO"] = MDFe.Emissao;
                oSQL.ParamByName["TIPOEMISSAO"] = MDFe.TipoEmissao;
                oSQL.ParamByName["IDEMITENTE"] = MDFe.IDEmitente;
                oSQL.ParamByName["INFORMACOESADICIONAIS"] = MDFe.InformacoesAdicionais;
                oSQL.ParamByName["INFORMACOESCOMPLEMENTARES"] = MDFe.InformacoesComplementares;
                oSQL.ParamByName["DATACADASTRO"] = MDFe.DataCadastro;
                oSQL.ParamByName["CODIGOUNPESOCARGA"] = MDFe.CodigoUNPesoCarga;
                oSQL.ParamByName["IDUNIDADEFEDERATIVADESCARREGAMENTO"] = MDFe.IDUnidadeFederativaDescarregamento;
                oSQL.ParamByName["PESOBRUTOTOTAL"] = MDFe.PesoBrutoTotal;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Existe(decimal IDMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM MDFE WHERE IDMDFE = @IDMDFE";
                oSQL.ParamByName["IDMDFE"] = IDMDFe;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static ManifestoDocumentoFiscalEletronico GetMDFe(decimal IDMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDMDFE,
TIPOAMBIENTE,
TIPOEMITENTE,
TIPOTRANSPORTADOR,
MODELO,
SERIE,
NMDF,
CMDF,
MODALIDADETRANSPORTE,
EMISSAO,
TIPOEMISSAO,
IDEMITENTE,
INFORMACOESADICIONAIS,
INFORMACOESCOMPLEMENTARES,
DATACADASTRO,
IDUNIDADEFEDERATIVADESCARREGAMENTO,
CODIGOUNPESOCARGA,
PESOBRUTOTOTAL FROM MDFE WHERE IDMDFE = @IDMDFE";
                oSQL.ParamByName["IDMDFE"] = IDMDFe;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<ManifestoDocumentoFiscalEletronico>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
    }
}
