using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Cfop
    {
        public Cfop()
        {
            Integracaofiscals = new HashSet<Integracaofiscal>();
            Nves = new HashSet<Nfe>();
            Produtonves = new HashSet<Produtonfe>();
        }

        public int Idcfop { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal? Ativo { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Integracaofiscal> Integracaofiscals { get; set; }
        public virtual ICollection<Nfe> Nves { get; set; }
        public virtual ICollection<Produtonfe> Produtonves { get; set; }
    }
}
