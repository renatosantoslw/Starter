using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Produtonfeicm
    {
        public int Idprodutonfeicms { get; set; }
        public int? Idorigemproduto { get; set; }
        public int? Idcsticms { get; set; }
        public int? Idunidadefederativast { get; set; }
        public int? Idprodutonfe { get; set; }
        public decimal? Modbc { get; set; }
        public decimal? Predbc { get; set; }
        public decimal? Vbc { get; set; }
        public decimal? Picms { get; set; }
        public decimal? Vicms { get; set; }
        public decimal? Modbcst { get; set; }
        public decimal? Pmvast { get; set; }
        public decimal? Predbcst { get; set; }
        public decimal? Vbcst { get; set; }
        public decimal? Picmsst { get; set; }
        public decimal? Vicmsst { get; set; }
        public decimal? Pcredsn { get; set; }
        public decimal? Vcredicmssn { get; set; }
        public decimal? Pdif { get; set; }
        public decimal? Vicmsdif { get; set; }

        public virtual Csticm IdcsticmsNavigation { get; set; }
        public virtual Produtonfe IdprodutonfeNavigation { get; set; }
        public virtual Unidadefederativa IdunidadefederativastNavigation { get; set; }
    }
}
