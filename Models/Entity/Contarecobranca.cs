using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Contarecobranca
    {
        public int Idcontarecobranca { get; set; }
        public int? Idcontareceber { get; set; }
        public DateTime? Emissao { get; set; }
        public DateTime? Vencimento { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Nossonumero { get; set; }
        public decimal? Status { get; set; }

        public virtual Contareceber IdcontareceberNavigation { get; set; }
    }
}
