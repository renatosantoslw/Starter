using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Iteminventario
    {
        public Iteminventario()
        {
            Movimentoestoques = new HashSet<Movimentoestoque>();
        }

        public int Iditeminventario { get; set; }
        public int? Idinventario { get; set; }
        public int? Idproduto { get; set; }
        public int? Idalmoxarifado { get; set; }
        public decimal? Quantidade { get; set; }

        public virtual Almoxarifado IdalmoxarifadoNavigation { get; set; }
        public virtual Inventario IdinventarioNavigation { get; set; }
        public virtual Produto IdprodutoNavigation { get; set; }
        public virtual ICollection<Movimentoestoque> Movimentoestoques { get; set; }
    }
}
