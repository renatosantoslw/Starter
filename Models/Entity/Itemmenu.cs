using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Itemmenu
    {
        public Itemmenu()
        {
            InverseIditemmenusuperiorNavigation = new HashSet<Itemmenu>();
            Perfilacessoitemmenus = new HashSet<Perfilacessoitemmenu>();
        }

        public int Iditemmenu { get; set; }
        public string Descricao { get; set; }
        public int? Iditemmenusuperior { get; set; }

        public virtual Itemmenu IditemmenusuperiorNavigation { get; set; }
        public virtual ICollection<Itemmenu> InverseIditemmenusuperiorNavigation { get; set; }
        public virtual ICollection<Perfilacessoitemmenu> Perfilacessoitemmenus { get; set; }
    }
}
