using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Finalidade
    {
        public Finalidade()
        {
            Nves = new HashSet<Nfe>();
        }

        public int Idfinalidade { get; set; }
        public decimal? Codigo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Nfe> Nves { get; set; }
    }
}
