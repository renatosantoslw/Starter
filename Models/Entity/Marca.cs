using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Marca
    {
        public Marca()
        {
            Produtos = new HashSet<Produto>();
            Veiculos = new HashSet<Veiculo>();
        }

        public int Idmarca { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Chaveerp { get; set; }
        public bool? Marcadeveiculo { get; set; }
        public bool? Marcadeproduto { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}
