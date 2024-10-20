using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Fluxocaixa
    {
        public Fluxocaixa()
        {
            Retiradacaixas = new HashSet<Retiradacaixa>();
            Sangriacaixas = new HashSet<Sangriacaixa>();
        }

        public int Idfluxocaixa { get; set; }
        public int? Idusuario { get; set; }
        public decimal? Valorcaixa { get; set; }
        public DateTime? Dataaberturacaixa { get; set; }
        public DateTime? Datafechamentocaixa { get; set; }
        public decimal? Aberto { get; set; }
        public decimal? Valorfechamentocaixa { get; set; }
        public string Observacao { get; set; }
        public int? Caixaid { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<Retiradacaixa> Retiradacaixas { get; set; }
        public virtual ICollection<Sangriacaixa> Sangriacaixas { get; set; }
    }
}
