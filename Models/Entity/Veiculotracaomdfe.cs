using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Veiculotracaomdfe
    {
        public int Idveiculotracaomdfe { get; set; }
        public int? Idproprietarioveiculomdfe { get; set; }
        public int? Idcondutor { get; set; }
        public int? Idveiculo { get; set; }
        public int? Idmdfe { get; set; }

        public virtual Condutor IdcondutorNavigation { get; set; }
        public virtual Mdfe IdmdfeNavigation { get; set; }
        public virtual Proprietarioveiculomdfe IdproprietarioveiculomdfeNavigation { get; set; }
        public virtual Veiculo IdveiculoNavigation { get; set; }
    }
}
