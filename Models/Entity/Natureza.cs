using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Natureza
    {
        public Natureza()
        {
            InverseIdnaturezasuperiorNavigation = new HashSet<Natureza>();
            Movimentobancarios = new HashSet<Movimentobancario>();
        }

        public int Idnatureza { get; set; }
        public string Conta { get; set; }
        public string Descricao { get; set; }
        public string Aplicacao { get; set; }
        public decimal? Tipo { get; set; }
        public int? Idnaturezasuperior { get; set; }

        public virtual Natureza IdnaturezasuperiorNavigation { get; set; }
        public virtual ICollection<Natureza> InverseIdnaturezasuperiorNavigation { get; set; }
        public virtual ICollection<Movimentobancario> Movimentobancarios { get; set; }
    }
}
