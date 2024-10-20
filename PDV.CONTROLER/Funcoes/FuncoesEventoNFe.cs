using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using System;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesEventoNFe
    {

        public static EventoNFe GetEventoNFe(decimal IDEventoNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDEVENTONFE,
IDMOVIMENTOFISCAL,
NSEQEVENTO,
DHEVENTO,
DESCEVENTO,
NPROT,
XCORRECAO,
XMOTIVO,
XML,
CSTAT,
INUTILIZACAO_NNFINI,
INUTILIZACAO_NNFFIN,
INUTILIZACAO_SERIE,
TIPOEVENTO FROM EVENTONFE WHERE IDEVENTONFE = @IDEVENTONFE";
                oSQL.ParamByName["IDEVENTONFE"] = IDEventoNFe;
                oSQL.Open();
                return EntityUtil<EventoNFe>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static int GetProxSeqEvento(decimal IDMovimentoFiscal, decimal TipoEvento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT COALESCE(MAX(CAST(COALESCE(EVENTONFE.NSEQEVENTO, '0') AS DECIMAL)), 0) + 1 AS PROXSEQ
                               FROM EVENTONFE
                               WHERE EVENTONFE.IDMOVIMENTOFISCAL = @IDMOVIMENTOFISCAL
                                 AND EVENTONFE.TIPOEVENTO = @TIPOEVENTO";
                oSQL.ParamByName["IDMOVIMENTOFISCAL"] = IDMovimentoFiscal;
                oSQL.ParamByName["TIPOEVENTO"] = TipoEvento;
                oSQL.Open();
                return Convert.ToInt32(oSQL.dtDados.Rows[0][0]);
            }
        }

        public static bool Salvar(EventoNFe Evento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"INSERT INTO EVENTONFE(
                                        IDEVENTONFE, IDMOVIMENTOFISCAL, NSEQEVENTO, DHEVENTO, DESCEVENTO, TIPOEVENTO,
                                        NPROT, XCORRECAO, XMOTIVO,  XML, CSTAT, INUTILIZACAO_NNFINI, INUTILIZACAO_NNFFIN, INUTILIZACAO_SERIE)
                                VALUES (@IDEVENTONFE, @IDMOVIMENTOFISCAL, @NSEQEVENTO, @DHEVENTO, @DESCEVENTO, @TIPOEVENTO,
                                        @NPROT, @XCORRECAO, @XMOTIVO, @XML, @CSTAT, @INUTILIZACAO_NNFINI, @INUTILIZACAO_NNFFIN, @INUTILIZACAO_SERIE)";
                oSQL.ParamByName["IDEVENTONFE"] = Evento.IDEventoNFe;
                oSQL.ParamByName["IDMOVIMENTOFISCAL"] = Evento.IDMovimentoFiscal;
                oSQL.ParamByName["NSEQEVENTO"] = Evento.NSeqEvento;
                oSQL.ParamByName["DHEVENTO"] = Evento.DHRecebimento;
                oSQL.ParamByName["DESCEVENTO"] = Evento.DescEvento;
                oSQL.ParamByName["NPROT"] = Evento.NProt;
                oSQL.ParamByName["XCORRECAO"] = Evento.XCorrecao;
                oSQL.ParamByName["XMOTIVO"] = Evento.XMotivo;
                oSQL.ParamByName["XML"] = Evento.XML;
                oSQL.ParamByName["CSTAT"] = Evento.CSTAT;
                oSQL.ParamByName["INUTILIZACAO_NNFINI"] = Evento.Inutilizacao_NNFIni;
                oSQL.ParamByName["INUTILIZACAO_NNFFIN"] = Evento.Inutilizacao_NNFFIN;
                oSQL.ParamByName["INUTILIZACAO_SERIE"] = Evento.Inutilizacao_Serie;
                oSQL.ParamByName["TIPOEVENTO"] = Evento.TipoEvento;
                return oSQL.ExecSQL() == 1;

             

            }
        }
    }
}