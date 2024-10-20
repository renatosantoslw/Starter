using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Talonario
    {
        public Talonario()
        {
            Chequecontapagars = new HashSet<Chequecontapagar>();
        }

        public int Idtalonario { get; set; }
        public int? Idcontabancaria { get; set; }
        public string Numero { get; set; }
        public DateTime? Emissao { get; set; }
        public decimal? Inicio { get; set; }
        public decimal? Fim { get; set; }
        public decimal? Ativo { get; set; }
        public byte[] Obs { get; set; }

        public virtual Contabancarium IdcontabancariaNavigation { get; set; }
        public virtual ICollection<Chequecontapagar> Chequecontapagars { get; set; }
    }
}
