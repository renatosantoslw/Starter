using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Pai
    {
        public Pai()
        {
            Enderecos = new HashSet<Endereco>();
            Unidadefederativas = new HashSet<Unidadefederativa>();
        }

        public int Idpais { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Unidadefederativa> Unidadefederativas { get; set; }
    }
}
