using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Endereco
    {
        public Endereco()
        {
            Fornecedors = new HashSet<Fornecedor>();
        }

        public int Idendereco { get; set; }
        public int? Idmunicipio { get; set; }
        public int? Idunidadefederativa { get; set; }
        public int? Idpais { get; set; }
        public string Logradouro { get; set; }
        public decimal? Numero { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Telefone { get; set; }

        public virtual Municipio IdmunicipioNavigation { get; set; }
        public virtual Pai IdpaisNavigation { get; set; }
        public virtual Unidadefederativa IdunidadefederativaNavigation { get; set; }
        public virtual ICollection<Fornecedor> Fornecedors { get; set; }
    }
}
