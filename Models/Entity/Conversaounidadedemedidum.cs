using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Conversaounidadedemedidum
    {
        public Conversaounidadedemedidum()
        {
            Itemnfeentrada = new HashSet<Itemnfeentradum>();
        }

        public int Idconversaounidadedemedida { get; set; }
        public int? Idproduto { get; set; }
        public int? Idunidadedemedidaentrada { get; set; }
        public int? Idunidadedemedidasaida { get; set; }
        public decimal? Fator { get; set; }
        public string Calculo { get; set; }

        public virtual Unidadedemedidum IdunidadedemedidaentradaNavigation { get; set; }
        public virtual Unidadedemedidum IdunidadedemedidasaidaNavigation { get; set; }
        public virtual ICollection<Itemnfeentradum> Itemnfeentrada { get; set; }
    }
}
