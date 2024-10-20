using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Manifestacaodestinatario
    {
        public Manifestacaodestinatario()
        {
            Downloadnves = new HashSet<Downloadnfe>();
        }

        public int Idmanifestacaodestinatario { get; set; }
        public string Chavenfe { get; set; }
        public decimal? Tipoambiente { get; set; }
        public decimal? Orgao { get; set; }
        public decimal? Cstat { get; set; }
        public string Motivo { get; set; }
        public decimal? Tipomanifestacao { get; set; }
        public decimal? Numeroevento { get; set; }

        public virtual ICollection<Downloadnfe> Downloadnves { get; set; }
    }
}
