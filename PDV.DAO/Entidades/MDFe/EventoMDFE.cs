using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades.MDFe
{
    public class EventoMDFE
    {
        [CampoTabela("IDEVENTOMDFE")]
        public decimal IDEventoMDFE { get; set; }

        [CampoTabela("IDMOVIMENTOFISCALMDFE")]
        public decimal IDMovimentoFiscalMDFe { get; set; }

        [CampoTabela("NSEQEVENTO")]
        public decimal NSeqEvento { get; set; }

        [CampoTabela("DHEVENTO")]
        public DateTime? DHEvento { get; set; }

        [CampoTabela("DESCEVENTO")]
        public string DescEvento { get; set; }

        [CampoTabela("NPROT")]
        public string NProt { get; set; }

        [CampoTabela("XMOTIVO")]
        public string XMotivo { get; set; }

        [CampoTabela("CSTAT")]
        public decimal CSTAT { get; set; }

        [CampoTabela("TIPOEVENTO")]
        public decimal TipoEvento { get; set; }

        public EventoMDFE() { }
    }
}
