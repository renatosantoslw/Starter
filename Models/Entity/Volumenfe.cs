using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Volumenfe
    {
        public int Idvolumenfe { get; set; }
        public int? Idnfe { get; set; }
        public string Volume { get; set; }
        public string Numero { get; set; }
        public decimal? Pesoliquido { get; set; }
        public decimal? Pesobruto { get; set; }
        public string Marca { get; set; }
        public string Especie { get; set; }

        public virtual Nfe IdnfeNavigation { get; set; }
    }
}
