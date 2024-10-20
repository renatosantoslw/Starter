using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Bandeiracartao
    {
        public Bandeiracartao()
        {
            Formadepagamentos = new HashSet<Formadepagamento>();
        }

        public int Idbandeiracartao { get; set; }
        public decimal? Codigo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Formadepagamento> Formadepagamentos { get; set; }
    }
}
