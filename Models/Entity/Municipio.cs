using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Municipio
    {
        public Municipio()
        {
            Carregamentomdves = new HashSet<Carregamentomdfe>();
            Documentofiscalmdves = new HashSet<Documentofiscalmdfe>();
            Enderecos = new HashSet<Endereco>();
        }

        public int Idmunicipio { get; set; }
        public int? Idunidadefederativa { get; set; }
        public decimal? Mesorregiaogeografica { get; set; }
        public string Nomemesorregiao { get; set; }
        public decimal? Microrregiaogeografica { get; set; }
        public string Nomemicrorregiao { get; set; }
        public decimal? Codigoibge { get; set; }
        public string Descricao { get; set; }

        public virtual Unidadefederativa IdunidadefederativaNavigation { get; set; }
        public virtual ICollection<Carregamentomdfe> Carregamentomdves { get; set; }
        public virtual ICollection<Documentofiscalmdfe> Documentofiscalmdves { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
