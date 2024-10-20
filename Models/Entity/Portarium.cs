using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Portarium
    {
        public Portarium()
        {
            Integracaofiscals = new HashSet<Integracaofiscal>();
        }

        public int Idportaria { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Integracaofiscal> Integracaofiscals { get; set; }
    }
}
