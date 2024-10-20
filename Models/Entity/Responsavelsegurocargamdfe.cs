using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Responsavelsegurocargamdfe
    {
        public Responsavelsegurocargamdfe()
        {
            Seguradoramdves = new HashSet<Seguradoramdfe>();
        }

        public int Idresponsavelsegurocargamdfe { get; set; }
        public decimal? Responsavelseguro { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }

        public virtual ICollection<Seguradoramdfe> Seguradoramdves { get; set; }
    }
}
