using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Ciotmdfe
    {
        public int Idciotmdfe { get; set; }
        public int? Idmdfe { get; set; }
        public decimal? Codigo { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }

        public virtual Mdfe IdmdfeNavigation { get; set; }
    }
}
