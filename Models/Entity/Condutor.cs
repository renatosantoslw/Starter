using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Condutor
    {
        public Condutor()
        {
            Veiculotracaomdves = new HashSet<Veiculotracaomdfe>();
        }

        public int Idcondutor { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public decimal? Ativo { get; set; }
        public int? Idunidadefederativa { get; set; }

        public virtual Unidadefederativa IdunidadefederativaNavigation { get; set; }
        public virtual ICollection<Veiculotracaomdfe> Veiculotracaomdves { get; set; }
    }
}
