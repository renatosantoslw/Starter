using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Duplicatanfce
    {
        public int Idduplicatanfce { get; set; }
        public int? Idformadepagamento { get; set; }
        public int? Idvenda { get; set; }
        public DateTime? Datavencimento { get; set; }
        public decimal? Valor { get; set; }
        public string Chaveerp { get; set; }
        public DateTime? Datapagamento { get; set; }
        public string Controle { get; set; }
        public decimal? Pagamento { get; set; }
        public decimal? Troco { get; set; }

        public virtual Formadepagamento IdformadepagamentoNavigation { get; set; }
        public virtual Vendum IdvendaNavigation { get; set; }
    }
}
