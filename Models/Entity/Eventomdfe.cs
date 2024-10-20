using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Eventomdfe
    {
        public int Ideventomdfe { get; set; }
        public int? Idmovimentofiscalmdfe { get; set; }
        public decimal? Nseqevento { get; set; }
        public DateTime? Dhevento { get; set; }
        public string Descevento { get; set; }
        public string Nprot { get; set; }
        public string Xmotivo { get; set; }
        public decimal? Cstat { get; set; }
        public decimal? Tipoevento { get; set; }

        public virtual Movimentofiscalmdfe IdmovimentofiscalmdfeNavigation { get; set; }
    }
}
