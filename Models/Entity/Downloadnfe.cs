using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Downloadnfe
    {
        public int Iddownloadnfe { get; set; }
        public int? Idmanifestacaodestinatario { get; set; }
        public decimal? Cstat { get; set; }
        public string Motivo { get; set; }
        public decimal? Tpamb { get; set; }
        public DateTime? Dhresp { get; set; }
        public decimal? Ultnsu { get; set; }
        public decimal? Maxnsu { get; set; }
        public byte[] Xml { get; set; }

        public virtual Manifestacaodestinatario IdmanifestacaodestinatarioNavigation { get; set; }
    }
}
