using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Averbacaoseguradoramdfe
    {
        public int Idaverbacaoseguradoramdfe { get; set; }
        public int? Idseguradoramdfe { get; set; }
        public string Numeroaverbacao { get; set; }

        public virtual Seguradoramdfe IdseguradoramdfeNavigation { get; set; }
    }
}
