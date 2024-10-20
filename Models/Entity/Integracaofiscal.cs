using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Integracaofiscal
    {
        public Integracaofiscal()
        {
            ProdutoIdintegracaofiscalnfceNavigations = new HashSet<Produto>();
            ProdutoIdintegracaofiscalnfeNavigations = new HashSet<Produto>();
            Produtonves = new HashSet<Produtonfe>();
        }

        public int Idintegracaofiscal { get; set; }
        public int? Idcfop { get; set; }
        public int? Idtipooperacao { get; set; }
        public int? Idportaria { get; set; }
        public int? Idcsticms { get; set; }
        public int? Idcstipi { get; set; }
        public int? Idcstpis { get; set; }
        public int? Idcstcofins { get; set; }
        public string Descricao { get; set; }
        public decimal? Sequencia { get; set; }
        public decimal? Icms { get; set; }
        public decimal? IcmsIpi { get; set; }
        public decimal? IcmsSt { get; set; }
        public decimal? IcmsRed { get; set; }
        public decimal? IcmsRedst { get; set; }
        public decimal? IcmsDiferenciado { get; set; }
        public decimal? IcmsCdiferenciado { get; set; }
        public decimal? IcmsStCdiferenciado { get; set; }
        public decimal? IcmsStDiferenciado { get; set; }
        public decimal? IcmsDif { get; set; }
        public decimal? Estoque { get; set; }
        public decimal? Financeiro { get; set; }
        public decimal? Ipi { get; set; }

        public virtual Cfop IdcfopNavigation { get; set; }
        public virtual Cstcofin IdcstcofinsNavigation { get; set; }
        public virtual Csticm IdcsticmsNavigation { get; set; }
        public virtual Cstipi IdcstipiNavigation { get; set; }
        public virtual Cstpi IdcstpisNavigation { get; set; }
        public virtual Portarium IdportariaNavigation { get; set; }
        public virtual ICollection<Produto> ProdutoIdintegracaofiscalnfceNavigations { get; set; }
        public virtual ICollection<Produto> ProdutoIdintegracaofiscalnfeNavigations { get; set; }
        public virtual ICollection<Produtonfe> Produtonves { get; set; }
    }
}
