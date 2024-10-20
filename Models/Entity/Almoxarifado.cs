using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Almoxarifado
    {
        public Almoxarifado()
        {
            Iteminventarios = new HashSet<Iteminventario>();
            ItemtransferenciaestoqueIdalmoxarifadoentradaNavigations = new HashSet<Itemtransferenciaestoque>();
            ItemtransferenciaestoqueIdalmoxarifadosaidaNavigations = new HashSet<Itemtransferenciaestoque>();
            Movimentoestoques = new HashSet<Movimentoestoque>();
            ProdutoIdalmoxarifadoentradaNavigations = new HashSet<Produto>();
            ProdutoIdalmoxarifadosaidaNavigations = new HashSet<Produto>();
            Saldoestoqueinicials = new HashSet<Saldoestoqueinicial>();
        }

        public int Idalmoxarifado { get; set; }
        public string Descricao { get; set; }
        public decimal? Tipo { get; set; }

        public virtual ICollection<Iteminventario> Iteminventarios { get; set; }
        public virtual ICollection<Itemtransferenciaestoque> ItemtransferenciaestoqueIdalmoxarifadoentradaNavigations { get; set; }
        public virtual ICollection<Itemtransferenciaestoque> ItemtransferenciaestoqueIdalmoxarifadosaidaNavigations { get; set; }
        public virtual ICollection<Movimentoestoque> Movimentoestoques { get; set; }
        public virtual ICollection<Produto> ProdutoIdalmoxarifadoentradaNavigations { get; set; }
        public virtual ICollection<Produto> ProdutoIdalmoxarifadosaidaNavigations { get; set; }
        public virtual ICollection<Saldoestoqueinicial> Saldoestoqueinicials { get; set; }
    }
}
