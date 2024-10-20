using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Produtofornecedor
    {
        public int Idprodutofornecedor { get; set; }
        public int? Idfornecedor { get; set; }
        public int? Idproduto { get; set; }
        public string Cprod { get; set; }

        public virtual Fornecedor IdfornecedorNavigation { get; set; }
        public virtual Produto IdprodutoNavigation { get; set; }
    }
}
