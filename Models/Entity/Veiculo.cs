using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Veiculo
    {
        public Veiculo()
        {
            Veiculotracaomdves = new HashSet<Veiculotracaomdfe>();
        }

        public int Idveiculo { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Renavam { get; set; }
        public decimal? Taraemkg { get; set; }
        public decimal? Capacidadeemkg { get; set; }
        public decimal? Capacidadeemm3 { get; set; }
        public decimal? Anofabricacao { get; set; }
        public decimal? Anomodelo { get; set; }
        public decimal? Tipopropriedade { get; set; }
        public decimal? Tipoveiculo { get; set; }
        public decimal? Tiporodado { get; set; }
        public decimal? Tipocarroceria { get; set; }
        public int? Idmarca { get; set; }
        public decimal? Ativo { get; set; }
        public decimal? Veiculoemusomdfe { get; set; }
        public int? Idunidadefederativa { get; set; }

        public virtual Marca IdmarcaNavigation { get; set; }
        public virtual Unidadefederativa IdunidadefederativaNavigation { get; set; }
        public virtual ICollection<Veiculotracaomdfe> Veiculotracaomdves { get; set; }
    }
}
