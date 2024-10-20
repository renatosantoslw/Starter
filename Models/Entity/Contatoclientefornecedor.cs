using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Contatoclientefornecedor
    {
        public int Idcontatoclientefornecedor { get; set; }
        public int? Idfornecedor { get; set; }
        public int? Idcliente { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public decimal? Sexo { get; set; }
        public DateTime? Datanascimento { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual Fornecedor IdfornecedorNavigation { get; set; }
    }
}
