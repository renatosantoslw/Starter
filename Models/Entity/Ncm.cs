using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Ncm
    {
        public int Idncm { get; set; }
        public int? Idunidadefederativa { get; set; }
        public decimal? Codigo { get; set; }
        public decimal? Ex { get; set; }
        public decimal? Tipo { get; set; }
        public string Descricao { get; set; }
        public decimal? Nacionalfederal { get; set; }
        public decimal? Importadosfederal { get; set; }
        public decimal? Estadual { get; set; }
        public decimal? Municipal { get; set; }
        public DateTime? Vigenciainicio { get; set; }
        public DateTime? Vigenciafim { get; set; }
        public string Chave { get; set; }
        public string Versao { get; set; }
        public string Fonte { get; set; }

        public virtual Unidadefederativa IdunidadefederativaNavigation { get; set; }
    }
}
