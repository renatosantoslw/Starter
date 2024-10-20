using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Sangriacaixa
    {
        public int Idsangriacaixa { get; set; }
        public int? Idusuariocadastro { get; set; }
        public int? Idusuario { get; set; }
        public int? Idfluxocaixa { get; set; }
        public DateTime? Datasangria { get; set; }
        public decimal? Valor { get; set; }
        public string Observacao { get; set; }

        public virtual Fluxocaixa IdfluxocaixaNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual Usuario IdusuariocadastroNavigation { get; set; }
    }
}
