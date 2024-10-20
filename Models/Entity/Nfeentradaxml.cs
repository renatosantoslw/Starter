using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Nfeentradaxml
    {
        public int Idnfeentradaxml { get; set; }
        public int? Idnfeentrada { get; set; }
        public byte[] Xml { get; set; }

        public virtual Nfeentradum IdnfeentradaNavigation { get; set; }
    }
}
