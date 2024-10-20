using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Itemvendum
    {
        public Itemvendum()
        {
            Movimentoestoques = new HashSet<Movimentoestoque>();
        }

        public int Iditemvenda { get; set; }
        public int? Idusuario { get; set; }
        public int? Idproduto { get; set; }
        public int? Idvenda { get; set; }
        public decimal? Quantidade { get; set; }
        public decimal? Descontoporcentagem { get; set; }
        public decimal? Descontovalor { get; set; }
        public decimal? Valorunitarioitem { get; set; }
        public string Descricao { get; set; }
        public decimal? Altura { get; set; }
        public decimal? Largura { get; set; }
        public decimal? Area { get; set; }
        public decimal? Subtotal { get; set; }

        public virtual Produto IdprodutoNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual Vendum IdvendaNavigation { get; set; }
        public virtual ICollection<Movimentoestoque> Movimentoestoques { get; set; }
    }
}
