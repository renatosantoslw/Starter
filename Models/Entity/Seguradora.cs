using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Seguradora
    {
        public Seguradora()
        {
            Seguradoramdves = new HashSet<Seguradoramdfe>();
        }

        public int Idseguradora { get; set; }
        public string Descricao { get; set; }
        public string Cnpj { get; set; }
        public decimal? Ativo { get; set; }

        public virtual ICollection<Seguradoramdfe> Seguradoramdves { get; set; }
    }
}
