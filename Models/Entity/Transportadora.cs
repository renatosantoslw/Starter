using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Transportadora
    {
        public Transportadora()
        {
            Nfeentrada = new HashSet<Nfeentradum>();
            Pedidocompras = new HashSet<Pedidocompra>();
        }

        public int Idtransportadora { get; set; }
        public int? Idendereco { get; set; }
        public string Razaosocial { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public decimal? Inscricaoestadual { get; set; }
        public int? Isento { get; set; }
        public int? Tipodocumento { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Nfeentradum> Nfeentrada { get; set; }
        public virtual ICollection<Pedidocompra> Pedidocompras { get; set; }
    }
}
