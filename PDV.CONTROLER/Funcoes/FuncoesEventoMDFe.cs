using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.MDFe;
using System;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesEventoMDFe
    {

        public static bool Salvar(EventoMDFE Evento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"INSERT INTO EVENTOMDFE(
                                      IDEVENTOMDFE, IDMOVIMENTOFISCALMDFE, NSEQEVENTO, DHEVENTO, DESCEVENTO, 
                                      NPROT, XMOTIVO, CSTAT, TIPOEVENTO)
                              VALUES (@IDEVENTOMDFE, @IDMOVIMENTOFISCALMDFE, @NSEQEVENTO, @DHEVENTO, @DESCEVENTO, 
                                      @NPROT, @XMOTIVO, @CSTAT, @TIPOEVENTO)";
                oSQL.ParamByName["IDEVENTOMDFE"] = Evento.IDEventoMDFE;
                oSQL.ParamByName["IDMOVIMENTOFISCALMDFE"] = Evento.IDMovimentoFiscalMDFe;
                oSQL.ParamByName["NSEQEVENTO"] = Evento.NSeqEvento;
                oSQL.ParamByName["DHEVENTO"] = Evento.DHEvento;
                oSQL.ParamByName["DESCEVENTO"] = Evento.DescEvento;
                oSQL.ParamByName["NPROT"] = Evento.NProt;
                oSQL.ParamByName["XMOTIVO"] = Evento.XMotivo;
                oSQL.ParamByName["CSTAT"] = Evento.CSTAT;
                oSQL.ParamByName["TIPOEVENTO"] = Evento.TipoEvento;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static int GetProxSeqEvento(decimal IDMovimentoFiscalMDFe, decimal TipoEvento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT COALESCE(MAX(COALESCE(EVENTOMDFE.NSEQEVENTO, '0')::DECIMAL), 0) + 1 AS PROXSEQ
                               FROM EVENTOMDFE
                               WHERE EVENTOMDFE.IDMOVIMENTOFISCALMDFE = @IDMOVIMENTOFISCALMDFE
                                 AND EVENTOMDFE.TIPOEVENTO = @TIPOEVENTO";
                oSQL.ParamByName["IDMOVIMENTOFISCALMDFE"] = IDMovimentoFiscalMDFe;
                oSQL.ParamByName["TIPOEVENTO"] = TipoEvento;
                oSQL.Open();
                return Convert.ToInt32(oSQL.dtDados.Rows[0][0]);
            }
        }
    }
}
