using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Romaneio
    {
        public int Idromaneio { get; set; }
        public string Empresa { get; set; }
        public int Status { get; set; }
        public DateTime? Datainclusao { get; set; }
        public int Transportadoraid { get; set; }
        public string Transportadoranome { get; set; }
        public int Veiculoid { get; set; }
        public string Veiculodescricao { get; set; }
        public string Motoristanome { get; set; }
        public int Motoristaid { get; set; }
        public int? Totalitens { get; set; }
        public decimal? Valortotal { get; set; }
        public string Observacao { get; set; }
        public int? Idusuario { get; set; }
    }
}
