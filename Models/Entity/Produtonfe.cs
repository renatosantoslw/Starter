using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Produtonfe
    {
        public Produtonfe()
        {
            Movimentoestoques = new HashSet<Movimentoestoque>();
            Produtonfecofins = new HashSet<Produtonfecofin>();
            Produtonfeicms = new HashSet<Produtonfeicm>();
            Produtonfepartilhaicms = new HashSet<Produtonfepartilhaicm>();
            Produtonfepis = new HashSet<Produtonfepi>();
        }

        public int Idprodutonfe { get; set; }
        public int? Idintegracaofiscal { get; set; }
        public int? Idnfe { get; set; }
        public int? Idproduto { get; set; }
        public int? Idunidadedemedida { get; set; }
        public int? Idcfop { get; set; }
        public int? Sequencia { get; set; }
        public decimal? Frete { get; set; }
        public decimal? Outrasdespesas { get; set; }
        public decimal? Desconto { get; set; }
        public decimal? Seguro { get; set; }
        public decimal? Quantidade { get; set; }
        public decimal? Valorunitario { get; set; }

        public virtual Cfop IdcfopNavigation { get; set; }
        public virtual Integracaofiscal IdintegracaofiscalNavigation { get; set; }
        public virtual Nfe IdnfeNavigation { get; set; }
        public virtual Produto IdprodutoNavigation { get; set; }
        public virtual Unidadedemedidum IdunidadedemedidaNavigation { get; set; }
        public virtual ICollection<Movimentoestoque> Movimentoestoques { get; set; }
        public virtual ICollection<Produtonfecofin> Produtonfecofins { get; set; }
        public virtual ICollection<Produtonfeicm> Produtonfeicms { get; set; }
        public virtual ICollection<Produtonfepartilhaicm> Produtonfepartilhaicms { get; set; }
        public virtual ICollection<Produtonfepi> Produtonfepis { get; set; }
    }
}
