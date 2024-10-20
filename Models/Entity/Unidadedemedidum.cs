using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Unidadedemedidum
    {
        public Unidadedemedidum()
        {
            ConversaounidadedemedidumIdunidadedemedidaentradaNavigations = new HashSet<Conversaounidadedemedidum>();
            ConversaounidadedemedidumIdunidadedemedidasaidaNavigations = new HashSet<Conversaounidadedemedidum>();
            Produtonves = new HashSet<Produtonfe>();
            Produtos = new HashSet<Produto>();
        }

        public int Idunidadedemedida { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }

        public virtual ICollection<Conversaounidadedemedidum> ConversaounidadedemedidumIdunidadedemedidaentradaNavigations { get; set; }
        public virtual ICollection<Conversaounidadedemedidum> ConversaounidadedemedidumIdunidadedemedidasaidaNavigations { get; set; }
        public virtual ICollection<Produtonfe> Produtonves { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
