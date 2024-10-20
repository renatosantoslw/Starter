using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Transferenciaestoque
    {
        public Transferenciaestoque()
        {
            Itemtransferenciaestoques = new HashSet<Itemtransferenciaestoque>();
        }

        public int Idtransferenciaestoque { get; set; }
        public DateTime? Datatransferencia { get; set; }
        public string Observacao { get; set; }

        public virtual ICollection<Itemtransferenciaestoque> Itemtransferenciaestoques { get; set; }
    }
}
