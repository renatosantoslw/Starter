using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Mdfe
    {
        public Mdfe()
        {
            Carregamentomdves = new HashSet<Carregamentomdfe>();
            Ciotmdves = new HashSet<Ciotmdfe>();
            Contratantemdves = new HashSet<Contratantemdfe>();
            Documentofiscalmdves = new HashSet<Documentofiscalmdfe>();
            Lacrerodoviariomdves = new HashSet<Lacrerodoviariomdfe>();
            Movimentofiscalmdves = new HashSet<Movimentofiscalmdfe>();
            Percursomdves = new HashSet<Percursomdfe>();
            Seguradoramdves = new HashSet<Seguradoramdfe>();
            Valepedagiomdves = new HashSet<Valepedagiomdfe>();
            Veiculotracaomdves = new HashSet<Veiculotracaomdfe>();
        }

        public int Idmdfe { get; set; }
        public decimal? Tipoambiente { get; set; }
        public decimal? Tipoemitente { get; set; }
        public decimal? Tipotransportador { get; set; }
        public decimal? Modelo { get; set; }
        public decimal? Serie { get; set; }
        public decimal? Nmdf { get; set; }
        public decimal? Cmdf { get; set; }
        public decimal? Modalidadetransporte { get; set; }
        public DateTime? Emissao { get; set; }
        public decimal? Tipoemissao { get; set; }
        public int? Idemitente { get; set; }
        public string Informacoesadicionais { get; set; }
        public string Informacoescomplementares { get; set; }
        public DateTime? Datacadastro { get; set; }
        public int? Idunidadefederativadescarregamento { get; set; }
        public decimal? Codigounpesocarga { get; set; }
        public decimal? Pesobrutototal { get; set; }

        public virtual Emitente IdemitenteNavigation { get; set; }
        public virtual Unidadefederativa IdunidadefederativadescarregamentoNavigation { get; set; }
        public virtual ICollection<Carregamentomdfe> Carregamentomdves { get; set; }
        public virtual ICollection<Ciotmdfe> Ciotmdves { get; set; }
        public virtual ICollection<Contratantemdfe> Contratantemdves { get; set; }
        public virtual ICollection<Documentofiscalmdfe> Documentofiscalmdves { get; set; }
        public virtual ICollection<Lacrerodoviariomdfe> Lacrerodoviariomdves { get; set; }
        public virtual ICollection<Movimentofiscalmdfe> Movimentofiscalmdves { get; set; }
        public virtual ICollection<Percursomdfe> Percursomdves { get; set; }
        public virtual ICollection<Seguradoramdfe> Seguradoramdves { get; set; }
        public virtual ICollection<Valepedagiomdfe> Valepedagiomdves { get; set; }
        public virtual ICollection<Veiculotracaomdfe> Veiculotracaomdves { get; set; }
    }
}
