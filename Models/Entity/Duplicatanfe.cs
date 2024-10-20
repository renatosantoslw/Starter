using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Duplicatanfe
    {
        public int Idduplicatanfe { get; set; }
        public int? Idnfe { get; set; }
        public string Numerodocumento { get; set; }
        public DateTime? Datavencimento { get; set; }
        public decimal? Valor { get; set; }
        public string Chaveerp { get; set; }
        public int? Idformadepagamento { get; set; }
        public int? Pagamento { get; set; }

        public virtual Nfe IdnfeNavigation { get; set; }
    }
}
