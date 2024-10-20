using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Produtonfepartilhaicm
    {
        public int Idprodutonfepartilhaicms { get; set; }
        public int? Idprodutonfe { get; set; }
        public decimal? Vbcufdest { get; set; }
        public decimal? Pfcpufdest { get; set; }
        public decimal? Picmsufdest { get; set; }
        public decimal? Picmsinter { get; set; }
        public decimal? Picmsinterpart { get; set; }
        public decimal? Vfcpufdest { get; set; }
        public decimal? Vicmsufdest { get; set; }
        public decimal? Vicmsufremet { get; set; }

        public virtual Produtonfe IdprodutonfeNavigation { get; set; }
    }
}
