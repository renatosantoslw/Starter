using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Servico
    {
        public int Idservico { get; set; }
        public string Descricao { get; set; }
        public int? Idcategoria { get; set; }
        public int? Idunidadedemedida { get; set; }
        public decimal? Valor { get; set; }
    }
}
