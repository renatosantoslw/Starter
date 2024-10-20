using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Conferenciacaixapdv
    {
        public int Idconferenciacaixapdv { get; set; }
        public DateTime? Data { get; set; }
        public int? Idfluxocaixa { get; set; }
        public int? Idformapagamento { get; set; }
        public string Nomeformapagamento { get; set; }
        public decimal? Valordigitado { get; set; }
        public decimal? Valorcalculado { get; set; }
        public decimal? Diferenca { get; set; }
    }
}
