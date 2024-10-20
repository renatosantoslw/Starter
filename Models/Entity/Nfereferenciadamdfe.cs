using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Nfereferenciadamdfe
    {
        public int Idnfereferenciadamdfe { get; set; }
        public int? Iddocumentofiscalmdfe { get; set; }
        public string Chavenfe { get; set; }

        public virtual Documentofiscalmdfe IddocumentofiscalmdfeNavigation { get; set; }
    }
}
