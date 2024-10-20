using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Baixapagamento
    {
        public Baixapagamento()
        {
            Chequecontapagars = new HashSet<Chequecontapagar>();
        }

        public int Idbaixapagamento { get; set; }
        public int? Idcontapagar { get; set; }
        public int? Idformadepagamento { get; set; }
        public int? Idcontabancaria { get; set; }
        public int? Idhistoricofinanceiro { get; set; }
        public string Complmhisfin { get; set; }
        public DateTime? Baixa { get; set; }
        public decimal? Multa { get; set; }
        public decimal? Juros { get; set; }
        public decimal? Desconto { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? Dataconciliacao { get; set; }

        public virtual Contabancarium IdcontabancariaNavigation { get; set; }
        public virtual Contapagar IdcontapagarNavigation { get; set; }
        public virtual Formadepagamento IdformadepagamentoNavigation { get; set; }
        public virtual Historicofinanceiro IdhistoricofinanceiroNavigation { get; set; }
        public virtual ICollection<Chequecontapagar> Chequecontapagars { get; set; }
    }
}
