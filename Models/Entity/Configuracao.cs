using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Configuracao
    {
        public int Idconfiguracao { get; set; }
        public string Chave { get; set; }
        public byte[] Valor { get; set; }
    }
}
