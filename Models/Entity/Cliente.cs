using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Cliente
    {
        public Cliente()
        {
            Contarecebers = new HashSet<Contareceber>();
            Contatoclientefornecedors = new HashSet<Contatoclientefornecedor>();
            Historicoclientefornecedors = new HashSet<Historicoclientefornecedor>();
        }

        public int Idcliente { get; set; }
        public int? Idcontato { get; set; }
        public int? Idendereco { get; set; }
        public int? Tipodocumento { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string Razaosocial { get; set; }
        public string Inscricaoestadual { get; set; }
        public string Inscricaomunicipal { get; set; }
        public string Nome { get; set; }
        public string Nomefantasia { get; set; }
        public decimal? Ativo { get; set; }
        public decimal? Consumidorfinal { get; set; }
        public decimal? Estrangeiro { get; set; }
        public string Docestrangeiro { get; set; }
        public decimal? Tipocontribuinte { get; set; }
        public string Chaveerp { get; set; }
        public int? Idvendedor { get; set; }
        public decimal? Limitedecredito { get; set; }

        public virtual ICollection<Contareceber> Contarecebers { get; set; }
        public virtual ICollection<Contatoclientefornecedor> Contatoclientefornecedors { get; set; }
        public virtual ICollection<Historicoclientefornecedor> Historicoclientefornecedors { get; set; }
    }
}
