using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades
{
    public class EventoNFe
    {
        [CampoTabela("IDEVENTONFE")]
        public decimal IDEventoNFe { get; set; } = -1;

        [CampoTabela("IDMOVIMENTOFISCAL")]
        public decimal? IDMovimentoFiscal { get; set; }


        [CampoTabela("CSTAT")]
        public decimal CSTAT { get; set; }

        [CampoTabela("NSEQEVENTO")]
        public string NSeqEvento { get; set; }

        [CampoTabela("DESCEVENTO")]
        public string DescEvento { get; set; }

        [CampoTabela("DHRECEBIMENTO")]
        public DateTime DHRecebimento { get; set; }

        [CampoTabela("NPROT")]
        public string NProt { get; set; }

        [CampoTabela("XCORRECAO")]
        public string XCorrecao { get; set; }

        [CampoTabela("XMOTIVO")]
        public string XMotivo { get; set; }
        
        [CampoTabela("XML")]
        public byte[] XML { get; set; }

        [CampoTabela("INUTILIZACAO_NNFINI")]
        public decimal? Inutilizacao_NNFIni { get; set; }

        [CampoTabela("INUTILIZACAO_NNFFIN")]
        public decimal? Inutilizacao_NNFFIN { get; set; }

        [CampoTabela("INUTILIZACAO_SERIE")]
        public decimal? Inutilizacao_Serie { get; set; }

        [CampoTabela("TIPOEVENTO")]
        public decimal TipoEvento { get; set; }

        public EventoNFe() { }
    }
}
