using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.DownloadNFeEntrada;
using System;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesManifestacaoDestinatario
    {
        public static ManifestacaoDestinatario GetManifestoPorChave(string Chave)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDMANIFESTACAODESTINATARIO,
CHAVENFE,
TIPOAMBIENTE,
ORGAO,
CSTAT,
MOTIVO,
TIPOMANIFESTACAO,
NUMEROEVENTO FROM MANIFESTACAODESTINATARIO WHERE CHAVENFE = @CHAVENFE ORDER BY IDMANIFESTACAODESTINATARIO DESC";
                oSQL.ParamByName["CHAVENFE"] = Chave;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<ManifestacaoDestinatario>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Salvar(ManifestacaoDestinatario Manifesto)
        {
            try
            {
                using (SQLQuery oSQL = new SQLQuery())
                {
                    oSQL.SQL = @"INSERT INTO MANIFESTACAODESTINATARIO
                               (IDMANIFESTACAODESTINATARIO, CHAVENFE, TIPOAMBIENTE, ORGAO, CSTAT, MOTIVO, TIPOMANIFESTACAO, NUMEROEVENTO)
                             VALUES 
                               (@IDMANIFESTACAODESTINATARIO, @CHAVENFE, @TIPOAMBIENTE, @ORGAO, @CSTAT, @MOTIVO, @TIPOMANIFESTACAO, @NUMEROEVENTO)";
                    oSQL.ParamByName["IDMANIFESTACAODESTINATARIO"] = Manifesto.IDManifestacaoDestinatario;
                    oSQL.ParamByName["CHAVENFE"] = Manifesto.ChaveNFe;
                    oSQL.ParamByName["TIPOAMBIENTE"] = Manifesto.TipoAmbiente;
                    oSQL.ParamByName["ORGAO"] = Manifesto.Orgao;
                    oSQL.ParamByName["CSTAT"] = Manifesto.Cstat;
                    oSQL.ParamByName["MOTIVO"] = Manifesto.Motivo;
                    oSQL.ParamByName["TIPOMANIFESTACAO"] = Manifesto.TipoManifestacao;
                    oSQL.ParamByName["NUMEROEVENTO"] = Manifesto.NumeroEvento;
                    return oSQL.ExecSQL() == 1;
                }
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public static int GetProximoCodigoEvento(decimal TipoAmbiente, string ChaveNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT COALESCE(MAX(COALESCE(NUMEROEVENTO, 1)), 1) + 1
                               FROM MANIFESTACAODESTINATARIO
                             WHERE TIPOAMBIENTE = @TIPOAMBIENTE
                               AND CHAVENFE = @CHAVENFE";
                oSQL.ParamByName["TIPOAMBIENTE"] = TipoAmbiente;
                oSQL.ParamByName["CHAVENFE"] = ChaveNFe;
                oSQL.Open();
                return oSQL.IsEmpty ? 1 : Convert.ToInt32(oSQL.dtDados.Rows[0][0]);
            }
        }


    }
}
