using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Perfilacesso
    {
        public Perfilacesso()
        {
            Perfilacessoitemmenus = new HashSet<Perfilacessoitemmenu>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Idperfilacesso { get; set; }
        public string Descricao { get; set; }
        public decimal? Ativo { get; set; }
        public int? Isadmin { get; set; }

        public virtual ICollection<Perfilacessoitemmenu> Perfilacessoitemmenus { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
