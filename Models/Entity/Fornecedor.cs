using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            Contapagars = new HashSet<Contapagar>();
            Contatoclientefornecedors = new HashSet<Contatoclientefornecedor>();
            Historicoclientefornecedors = new HashSet<Historicoclientefornecedor>();
            Nfeentrada = new HashSet<Nfeentradum>();
            Pedidocompras = new HashSet<Pedidocompra>();
            Produtofornecedors = new HashSet<Produtofornecedor>();
        }

        public int Idfornecedor { get; set; }
        public string Razaosocial { get; set; }
        public string Cnpj { get; set; }
        public decimal? Inscricaoestadual { get; set; }
        public decimal? Isento { get; set; }
        public string Email { get; set; }
        public int? Idendereco { get; set; }

        public virtual Endereco IdenderecoNavigation { get; set; }
        public virtual ICollection<Contapagar> Contapagars { get; set; }
        public virtual ICollection<Contatoclientefornecedor> Contatoclientefornecedors { get; set; }
        public virtual ICollection<Historicoclientefornecedor> Historicoclientefornecedors { get; set; }
        public virtual ICollection<Nfeentradum> Nfeentrada { get; set; }
        public virtual ICollection<Pedidocompra> Pedidocompras { get; set; }
        public virtual ICollection<Produtofornecedor> Produtofornecedors { get; set; }
    }
}
