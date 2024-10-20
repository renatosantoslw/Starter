using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Unidadefederativa
    {
        public Unidadefederativa()
        {
            Carregamentomdves = new HashSet<Carregamentomdfe>();
            Condutors = new HashSet<Condutor>();
            Documentoreferenciadonves = new HashSet<Documentoreferenciadonfe>();
            Enderecos = new HashSet<Endereco>();
            Mdves = new HashSet<Mdfe>();
            Municipios = new HashSet<Municipio>();
            Ncms = new HashSet<Ncm>();
            Percursomdves = new HashSet<Percursomdfe>();
            Produtonfeicms = new HashSet<Produtonfeicm>();
            Proprietarioveiculomdves = new HashSet<Proprietarioveiculomdfe>();
            Veiculos = new HashSet<Veiculo>();
        }

        public int Idunidadefederativa { get; set; }
        public int? Idpais { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public decimal? Aliquotainter { get; set; }
        public decimal? Aliquotaintra { get; set; }
        public decimal? Fcp { get; set; }

        public virtual Pai IdpaisNavigation { get; set; }
        public virtual ICollection<Carregamentomdfe> Carregamentomdves { get; set; }
        public virtual ICollection<Condutor> Condutors { get; set; }
        public virtual ICollection<Documentoreferenciadonfe> Documentoreferenciadonves { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Mdfe> Mdves { get; set; }
        public virtual ICollection<Municipio> Municipios { get; set; }
        public virtual ICollection<Ncm> Ncms { get; set; }
        public virtual ICollection<Percursomdfe> Percursomdves { get; set; }
        public virtual ICollection<Produtonfeicm> Produtonfeicms { get; set; }
        public virtual ICollection<Proprietarioveiculomdfe> Proprietarioveiculomdves { get; set; }
        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}
