using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Proprietarioveiculomdfe
    {
        public Proprietarioveiculomdfe()
        {
            Veiculotracaomdves = new HashSet<Veiculotracaomdfe>();
        }

        public int Idproprietarioveiculomdfe { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string Rntrc { get; set; }
        public string Nome { get; set; }
        public decimal? Inscricaoestadual { get; set; }
        public int? Idunidadefederativa { get; set; }
        public decimal? Tipoproprietario { get; set; }
        public decimal? Codigoagenciaporto { get; set; }

        public virtual Unidadefederativa IdunidadefederativaNavigation { get; set; }
        public virtual ICollection<Veiculotracaomdfe> Veiculotracaomdves { get; set; }
    }
}
