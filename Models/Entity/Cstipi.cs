using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Cstipi
    {
        public Cstipi()
        {
            Integracaofiscals = new HashSet<Integracaofiscal>();
        }

        public int Idcstipi { get; set; }
        public decimal? Cst { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Integracaofiscal> Integracaofiscals { get; set; }
    }
}
