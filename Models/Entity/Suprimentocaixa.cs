using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Suprimentocaixa
    {
        public int Idsuprimentocaixa { get; set; }
        public int? Idusuariocadastro { get; set; }
        public int? Idusuario { get; set; }
        public int? Idfluxocaixa { get; set; }
        public DateTime? Datasuprimentocaixa { get; set; }
        public decimal? Valor { get; set; }
        public string Observacao { get; set; }
    }
}
