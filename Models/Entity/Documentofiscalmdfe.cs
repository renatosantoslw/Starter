using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Documentofiscalmdfe
    {
        public Documentofiscalmdfe()
        {
            Nfereferenciadamdves = new HashSet<Nfereferenciadamdfe>();
        }

        public int Iddocumentofiscalmdfe { get; set; }
        public int? Idmdfe { get; set; }
        public int? Idmunicipiodescarga { get; set; }

        public virtual Mdfe IdmdfeNavigation { get; set; }
        public virtual Municipio IdmunicipiodescargaNavigation { get; set; }
        public virtual ICollection<Nfereferenciadamdfe> Nfereferenciadamdves { get; set; }
    }
}
