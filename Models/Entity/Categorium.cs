using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Categorium
    {
        public Categorium()
        {
            ProdutoIdcategoriaNavigations = new HashSet<Produto>();
            ProdutoIdsubcategoriaNavigations = new HashSet<Produto>();
        }

        public int Idcategoria { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }

        public virtual ICollection<Produto> ProdutoIdcategoriaNavigations { get; set; }
        public virtual ICollection<Produto> ProdutoIdsubcategoriaNavigations { get; set; }
    }
}
