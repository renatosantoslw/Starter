using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Caixa
    {
        public int? Idcaixa { get; set; }
        public string Numerocaixa { get; set; }
        public string Serialpos { get; set; }
        public string Nomepos { get; set; }
        public bool? Ativo { get; set; }
        public string Tipodevenda { get; set; }
        public int? Tipopdv { get; set; }
    }
}
