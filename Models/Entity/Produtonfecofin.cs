using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Produtonfecofin
    {
        public int Idprodutonfecofins { get; set; }
        public int? Idprodutonfe { get; set; }
        public int? Idcstcofins { get; set; }
        public decimal? Vbc { get; set; }
        public decimal? Pcofins { get; set; }
        public decimal? Vcofins { get; set; }

        public virtual Cstcofin IdcstcofinsNavigation { get; set; }
        public virtual Produtonfe IdprodutonfeNavigation { get; set; }
    }
}
