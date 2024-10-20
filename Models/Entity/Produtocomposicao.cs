using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Produtocomposicao
    {
        public int Idprodutocomposicao { get; set; }
        public int? Idproduto { get; set; }
        public int? Idprodutocomposto { get; set; }
        public decimal? Quantidade { get; set; }
    }
}
