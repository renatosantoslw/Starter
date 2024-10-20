using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Cstpi
    {
        public Cstpi()
        {
            Integracaofiscals = new HashSet<Integracaofiscal>();
            Produtonfepis = new HashSet<Produtonfepi>();
        }

        public int Idcstpis { get; set; }
        public decimal? Cst { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Integracaofiscal> Integracaofiscals { get; set; }
        public virtual ICollection<Produtonfepi> Produtonfepis { get; set; }
    }
}
