using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Valepedagiomdfe
    {
        public int Idvalepedagiomdfe { get; set; }
        public int? Idmdfe { get; set; }
        public string Cnpjfornecedora { get; set; }
        public string Cnpjpagamento { get; set; }
        public string Cpfpagamento { get; set; }
        public string Numerocompra { get; set; }
        public decimal? Valor { get; set; }

        public virtual Mdfe IdmdfeNavigation { get; set; }
    }
}
