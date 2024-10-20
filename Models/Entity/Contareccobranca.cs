using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Contareccobranca
    {
        public int Idcontareccobranca { get; set; }
        public int? Idcontareceber { get; set; }
        public DateTime? Emissao { get; set; }
        public DateTime? Vencimento { get; set; }
        public decimal? Valor { get; set; }
        public string Nossonumero { get; set; }
        public decimal? Status { get; set; }
        public int? Idcontacobranca { get; set; }
        public string Numerodocumento { get; set; }
        public string Numerocontroleparticipante { get; set; }
        public DateTime? Cancelamento { get; set; }

        public virtual Contacobranca IdcontacobrancaNavigation { get; set; }
        public virtual Contareceber IdcontareceberNavigation { get; set; }
    }
}
