using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Historicoclientefornecedor
    {
        public int Idhistoricoclientefornecedor { get; set; }
        public int? Idfornecedor { get; set; }
        public int? Idcliente { get; set; }
        public DateTime? Datahistorico { get; set; }
        public string Assunto { get; set; }
        public string Observacao { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual Fornecedor IdfornecedorNavigation { get; set; }
    }
}
