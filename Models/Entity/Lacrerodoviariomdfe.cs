using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Lacrerodoviariomdfe
    {
        public int Idlacrerodoviariomdfe { get; set; }
        public int? Idmdfe { get; set; }
        public string Numero { get; set; }

        public virtual Mdfe IdmdfeNavigation { get; set; }
    }
}
