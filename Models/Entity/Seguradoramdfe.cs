using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Seguradoramdfe
    {
        public Seguradoramdfe()
        {
            Averbacaoseguradoramdves = new HashSet<Averbacaoseguradoramdfe>();
        }

        public int Idseguradoramdfe { get; set; }
        public int? Idseguradora { get; set; }
        public int? Idmdfe { get; set; }
        public string Numeroapolice { get; set; }
        public int? Idresponsavelsegurocargamdfe { get; set; }

        public virtual Mdfe IdmdfeNavigation { get; set; }
        public virtual Responsavelsegurocargamdfe IdresponsavelsegurocargamdfeNavigation { get; set; }
        public virtual Seguradora IdseguradoraNavigation { get; set; }
        public virtual ICollection<Averbacaoseguradoramdfe> Averbacaoseguradoramdves { get; set; }
    }
}
