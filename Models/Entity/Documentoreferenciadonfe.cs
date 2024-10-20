using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Documentoreferenciadonfe
    {
        public int Iddocumentoreferenciadonfe { get; set; }
        public int? Idnfe { get; set; }
        public int? Idunidadefederativa { get; set; }
        public string Chave { get; set; }
        public int? Codigodocumentoreferenciado { get; set; }

        public virtual Nfe IdnfeNavigation { get; set; }
        public virtual Unidadefederativa IdunidadefederativaNavigation { get; set; }
    }
}
