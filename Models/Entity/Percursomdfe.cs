using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Percursomdfe
    {
        public int Idpercursomdfe { get; set; }
        public int? Idmdfe { get; set; }
        public int? Idunidadefederativapercurso { get; set; }
        public DateTime? Inicioviagem { get; set; }

        public virtual Mdfe IdmdfeNavigation { get; set; }
        public virtual Unidadefederativa IdunidadefederativapercursoNavigation { get; set; }
    }
}
