using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Movimentobancario
    {
        public int Idmovimentobancario { get; set; }
        public int? Idcontabancaria { get; set; }
        public int? Idnatureza { get; set; }
        public DateTime? Datamovimento { get; set; }
        public decimal? Valor { get; set; }
        public string Documento { get; set; }
        public decimal? Sequencia { get; set; }
        public string Historico { get; set; }
        public decimal? Tipo { get; set; }
        public DateTime? Conciliacao { get; set; }

        public virtual Contabancarium IdcontabancariaNavigation { get; set; }
        public virtual Natureza IdnaturezaNavigation { get; set; }
    }
}
