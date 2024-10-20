using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Origemproduto
    {
        public Origemproduto()
        {
            Produtos = new HashSet<Produto>();
        }

        public int Idorigemproduto { get; set; }
        public decimal? Codigo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
