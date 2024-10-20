using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Perfilacessoitemmenu
    {
        public int Idperfilacessoitemmenu { get; set; }
        public int? Iditemmenu { get; set; }
        public int? Idperfilacesso { get; set; }

        public virtual Itemmenu IditemmenuNavigation { get; set; }
        public virtual Perfilacesso IdperfilacessoNavigation { get; set; }
    }
}
