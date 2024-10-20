using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Centrocusto
    {
        public int Idcentrocusto { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public int? Tipodemovimento { get; set; }
    }
}
