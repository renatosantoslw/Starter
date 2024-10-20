using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Inventario
    {
        public Inventario()
        {
            Iteminventarios = new HashSet<Iteminventario>();
        }

        public int Idinventario { get; set; }
        public DateTime? Datainventario { get; set; }

        public virtual ICollection<Iteminventario> Iteminventarios { get; set; }
    }
}
