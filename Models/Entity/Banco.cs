using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Banco
    {
        public Banco()
        {
            Contabancaria = new HashSet<Contabancarium>();
        }

        public int Idbanco { get; set; }
        public decimal? Codbacen { get; set; }
        public string Nome { get; set; }
        public string Site { get; set; }

        public virtual ICollection<Contabancarium> Contabancaria { get; set; }
    }
}
