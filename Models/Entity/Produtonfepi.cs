using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Produtonfepi
    {
        public int Idprodutonfepis { get; set; }
        public int? Idprodutonfe { get; set; }
        public int? Idcstpis { get; set; }
        public decimal? Vbc { get; set; }
        public decimal? Ppis { get; set; }
        public decimal? Vpis { get; set; }

        public virtual Cstpi IdcstpisNavigation { get; set; }
        public virtual Produtonfe IdprodutonfeNavigation { get; set; }
    }
}
