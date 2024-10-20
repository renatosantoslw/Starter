using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.NFe;
using PDV.DAO.Enum;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesVolume
    {
        public static VolumeNFe GetVolume(decimal IDNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDVOLUMENFE, 
                                    IDNFE, 
                                    VOLUME, 
                                    NUMERO, 
                                    PESOLIQUIDO, 
                                    PESOBRUTO, 
                                    MARCA, 
                                    ESPECIE
                               FROM VOLUMENFE
                             WHERE IDNFE = @IDNFE";
                oSQL.ParamByName["IDNFE"] = IDNFe;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<VolumeNFe>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Salvar(VolumeNFe Volume, TipoOperacao Tipo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch(Tipo)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO VOLUMENFE(
                                             IDVOLUMENFE, IDNFE, VOLUME, NUMERO, PESOLIQUIDO, PESOBRUTO, MARCA, ESPECIE)
                                     VALUES (@IDVOLUMENFE, @IDNFE, @VOLUME, @NUMERO, @PESOLIQUIDO, @PESOBRUTO, @MARCA, @ESPECIE)";
                        oSQL.ParamByName["IDNFE"] = Volume.IDNFe;
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE VOLUMENFE 
                                        SET VOLUME = @VOLUME, 
                                            NUMERO = @NUMERO, 
                                            PESOLIQUIDO = @PESOLIQUIDO, 
                                            PESOBRUTO = @PESOBRUTO, 
                                            MARCA = @MARCA, 
                                            ESPECIE = @ESPECIE 
                                     WHERE IDVOLUMENFE = @IDVOLUMENFE";
                        break;
                }
                oSQL.ParamByName["IDVOLUMENFE"] = Volume.IDVolumeNFe;
                oSQL.ParamByName["VOLUME"] = Volume.Volume;
                oSQL.ParamByName["NUMERO"] = Volume.Numero;
                oSQL.ParamByName["PESOLIQUIDO"] = Volume.PesoLiquido;
                oSQL.ParamByName["PESOBRUTO"] = Volume.PesoBruto;
                oSQL.ParamByName["MARCA"] = Volume.Marca;
                oSQL.ParamByName["ESPECIE"] = Volume.Especie;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetTotalVolumesPorNFe(string ChavesNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT COUNT(NFES.IDNFE) AS QTDNFE,
                                     SUM(PESOBRUTO) AS PESOBRUTO,
                                     SUM(TOTALNFE) AS TOTALNFE                              
                               FROM (
                              SELECT DISTINCT NFE.IDNFE,
                                     SUM(VOLUMENFE.PESOBRUTO) AS PESOBRUTO,
                                     (SELECT SUM(VALOR) FROM DUPLICATANFE WHERE IDNFE = NFE.IDNFE) AS TOTALNFE       
                                FROM MOVIMENTOFISCAL
                                  INNER JOIN NFE ON (MOVIMENTOFISCAL.IDNFE = NFE.IDNFE)
                                  INNER JOIN VOLUMENFE ON (NFE.IDNFE = VOLUMENFE.IDNFE)
                              WHERE MOVIMENTOFISCAL.CHAVE IN ({ChavesNFe})
                              GROUP BY NFE.IDNFE
                              ) AS NFES";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetTotalVolumesPorMDFe(decimal IDMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT COUNT(NFES.IDNFE) AS QTDNFE,
                                     SUM(PESOBRUTO) AS PESOBRUTO,
                                     SUM(TOTALNFE) AS TOTALNFE                              
                               FROM (
                              SELECT DISTINCT NFE.IDNFE,
                                     SUM(VOLUMENFE.PESOBRUTO) AS PESOBRUTO,
                                     (SELECT SUM(VALOR) FROM DUPLICATANFE WHERE IDNFE = NFE.IDNFE) AS TOTALNFE       
                                FROM MOVIMENTOFISCAL
                                  INNER JOIN NFE ON (MOVIMENTOFISCAL.IDNFE = NFE.IDNFE)
                                  INNER JOIN VOLUMENFE ON (NFE.IDNFE = VOLUMENFE.IDNFE)
                              WHERE MOVIMENTOFISCAL.CHAVE IN (SELECT 'NFe'+NFEREFERENCIADAMDFE.CHAVENFE
                                                                FROM NFEREFERENCIADAMDFE 
                                                              INNER JOIN DOCUMENTOFISCALMDFE ON NFEREFERENCIADAMDFE.IDDOCUMENTOFISCALMDFE = DOCUMENTOFISCALMDFE.IDDOCUMENTOFISCALMDFE
                                                              WHERE DOCUMENTOFISCALMDFE.IDMDFE = @IDMDFE)
                              GROUP BY NFE.IDNFE
                              ) AS NFES";
                oSQL.ParamByName["IDMDFE"] = IDMDFe;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool ExcluirPorNFe(decimal idNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM VOLUMENFE WHERE IDNFE = @IDNFE";
                oSQL.ParamByName["IDNFE"] = idNFe;
                return oSQL.ExecSQL() >= 1;
            }
        }
    }
}
