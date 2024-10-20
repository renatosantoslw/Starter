using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Duplicatadac
    {
        public int Idduplicatadac { get; set; }
        public int? Idformadepagamento { get; set; }
        public int? Idcompra { get; set; }
        public DateTime? Datavencimento { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Pagamento { get; set; }
    }
}
