using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Carregamentomdfe
    {
        public int Idcarregamentomdfe { get; set; }
        public int? Idmdfe { get; set; }
        public int? Idunidadefederativacarregamento { get; set; }
        public int? Idmunicipiocarregamento { get; set; }

        public virtual Mdfe IdmdfeNavigation { get; set; }
        public virtual Municipio IdmunicipiocarregamentoNavigation { get; set; }
        public virtual Unidadefederativa IdunidadefederativacarregamentoNavigation { get; set; }
    }
}
