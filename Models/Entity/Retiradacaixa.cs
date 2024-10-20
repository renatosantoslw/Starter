using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Retiradacaixa
    {
        public int Idretiradacaixa { get; set; }
        public int? Idfluxocaixa { get; set; }
        public decimal? Valorretirada { get; set; }
        public DateTime? Dataretirada { get; set; }

        public virtual Fluxocaixa IdfluxocaixaNavigation { get; set; }
    }
}
