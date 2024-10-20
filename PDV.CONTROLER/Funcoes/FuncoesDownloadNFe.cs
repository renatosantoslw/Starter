using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.DownloadNFeEntrada;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesDownloadNFe
    {
        public static bool Salvar(DownloadNFe Down)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"INSERT INTO DOWNLOADNFE
                                (IDDOWNLOADNFE, IDMANIFESTACAODESTINATARIO, CSTAT, MOTIVO, TPAMB, DHRESP, ULTNSU, MAXNSU, XML)
                             VALUES (@IDDOWNLOADNFE, @IDMANIFESTACAODESTINATARIO, @CSTAT, @MOTIVO, @TPAMB, @DHRESP, @ULTNSU, @MAXNSU, @XML)";
                oSQL.ParamByName["IDDOWNLOADNFE"] = Down.IDDownloadNFe;
                oSQL.ParamByName["IDMANIFESTACAODESTINATARIO"] = Down.IDManifestacaoDestinatario;
                oSQL.ParamByName["XML"] = Down.Xml;
                oSQL.ParamByName["CSTAT"] = Down.Cstat;
                oSQL.ParamByName["MOTIVO"] = Down.Motivo;
                oSQL.ParamByName["TPAMB"] = Down.TpAmb;
                oSQL.ParamByName["DHRESP"] = Down.DhResp;
                oSQL.ParamByName["ULTNSU"] = Down.UltNSu;
                oSQL.ParamByName["MAXNSU"] = Down.MaxNsu;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
