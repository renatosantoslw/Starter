using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Csticm
    {
        public Csticm()
        {
            Integracaofiscals = new HashSet<Integracaofiscal>();
            Produtonfeicms = new HashSet<Produtonfeicm>();
        }

        public int Idcsticms { get; set; }
        public decimal? Cstcsosn { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Integracaofiscal> Integracaofiscals { get; set; }
        public virtual ICollection<Produtonfeicm> Produtonfeicms { get; set; }
    }
}
