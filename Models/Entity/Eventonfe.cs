using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Eventonfe
    {
        public int Ideventonfe { get; set; }
        public int? Idmovimentofiscal { get; set; }
        public string Nseqevento { get; set; }
        public DateTime? Dhevento { get; set; }
        public string Descevento { get; set; }
        public string Nprot { get; set; }
        public string Xcorrecao { get; set; }
        public string Xmotivo { get; set; }
        public byte[] Xml { get; set; }
        public decimal? Cstat { get; set; }
        public decimal? InutilizacaoNnfini { get; set; }
        public decimal? InutilizacaoNnffin { get; set; }
        public decimal? InutilizacaoSerie { get; set; }
        public decimal? Tipoevento { get; set; }

        public virtual Movimentofiscal IdmovimentofiscalNavigation { get; set; }
    }
}
