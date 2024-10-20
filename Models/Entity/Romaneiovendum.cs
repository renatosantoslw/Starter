using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Romaneiovendum
    {
        public int Idromaneiovenda { get; set; }
        public DateTime? Datafaturamento { get; set; }
        public int Idromaneio { get; set; }
        public int Idvenda { get; set; }
        public decimal? Valortotal { get; set; }
        public string Cliente { get; set; }
        public int? Totalitens { get; set; }
        public string Observacao { get; set; }
        public int? Status { get; set; }
    }
}
