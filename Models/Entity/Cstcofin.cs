using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Cstcofin
    {
        public Cstcofin()
        {
            Integracaofiscals = new HashSet<Integracaofiscal>();
            Produtonfecofins = new HashSet<Produtonfecofin>();
        }

        public int Idcstcofins { get; set; }
        public decimal? Cst { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Integracaofiscal> Integracaofiscals { get; set; }
        public virtual ICollection<Produtonfecofin> Produtonfecofins { get; set; }
    }
}
