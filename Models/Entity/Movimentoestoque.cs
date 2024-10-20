using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Movimentoestoque
    {
        public int Idmovimentoestoque { get; set; }
        public int? Idproduto { get; set; }
        public decimal? Tipo { get; set; }
        public int? Iditemnfeentrada { get; set; }
        public int? Iditemvenda { get; set; }
        public int? Idprodutonfe { get; set; }
        public int? Iditeminventario { get; set; }
        public int? Idalmoxarifado { get; set; }
        public int? Iditemtransferenciaestoque { get; set; }
        public decimal? Quantidade { get; set; }
        public DateTime? Datamovimento { get; set; }
        public decimal? Saldoatual { get; set; }
        public decimal? Saldoalmoxarifado { get; set; }
        public int? Iditempedidocompra { get; set; }
        public string Descricao { get; set; }

        public virtual Almoxarifado IdalmoxarifadoNavigation { get; set; }
        public virtual Iteminventario IditeminventarioNavigation { get; set; }
        public virtual Itemnfeentradum IditemnfeentradaNavigation { get; set; }
        public virtual Itempedidocompra IditempedidocompraNavigation { get; set; }
        public virtual Itemtransferenciaestoque IditemtransferenciaestoqueNavigation { get; set; }
        public virtual Itemvendum IditemvendaNavigation { get; set; }
        public virtual Produto IdprodutoNavigation { get; set; }
        public virtual Produtonfe IdprodutonfeNavigation { get; set; }
    }
}
