using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Comandum
    {
        public Comandum()
        {
            VendumIdcomandaNavigations = new HashSet<Vendum>();
            VendumIdcomandautilizadaNavigations = new HashSet<Vendum>();
        }

        public int Idcomanda { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Nomecliente { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Vendum> VendumIdcomandaNavigations { get; set; }
        public virtual ICollection<Vendum> VendumIdcomandautilizadaNavigations { get; set; }
    }
}
