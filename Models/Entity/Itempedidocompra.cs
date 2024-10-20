using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Itempedidocompra
    {
        public Itempedidocompra()
        {
            Movimentoestoques = new HashSet<Movimentoestoque>();
        }

        public int Iditempedidocompra { get; set; }
        public int? Idpedidocompra { get; set; }
        public int? Idproduto { get; set; }
        public decimal? Quantidade { get; set; }
        public decimal? Valorunitario { get; set; }
        public decimal? Desconto { get; set; }
        public decimal? Total { get; set; }
        public decimal? Descontoporcentagem { get; set; }
        public int? Idusuario { get; set; }
        public string Descricao { get; set; }

        public virtual Pedidocompra IdpedidocompraNavigation { get; set; }
        public virtual Produto IdprodutoNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<Movimentoestoque> Movimentoestoques { get; set; }
    }
}
