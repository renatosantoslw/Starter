using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Requisitante
    {
        public int Idrequisitante { get; set; }
        public string Nome { get; set; }
        public int? Idcentrocusto { get; set; }
    }
}
