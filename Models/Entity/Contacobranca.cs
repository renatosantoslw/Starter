using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Contacobranca
    {
        public Contacobranca()
        {
            Contareccobrancas = new HashSet<Contareccobranca>();
        }

        public int Idcontacobranca { get; set; }
        public int? Idcontabancaria { get; set; }
        public string Leiaute { get; set; }
        public string Especiedoc { get; set; }
        public decimal? Aceite { get; set; }
        public string Carteira { get; set; }
        public decimal? Registro { get; set; }
        public string Especie { get; set; }
        public string Cedente { get; set; }
        public decimal? Nossonumero { get; set; }
        public decimal? Ativo { get; set; }
        public string Instrucoes { get; set; }
        public decimal? Diaspagto { get; set; }
        public decimal? Taxa { get; set; }
        public string Localpagto { get; set; }
        public decimal? Valormulta { get; set; }
        public decimal? Percentualjuros { get; set; }
        public int? Idformadepagamento { get; set; }
        public string Variacaocarteira { get; set; }
        public decimal? Cnab { get; set; }
        public decimal? Numeroremessa { get; set; }

        public virtual Contabancarium IdcontabancariaNavigation { get; set; }
        public virtual Formadepagamento IdformadepagamentoNavigation { get; set; }
        public virtual ICollection<Contareccobranca> Contareccobrancas { get; set; }
    }
}
