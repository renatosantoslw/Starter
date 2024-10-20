namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CondicaoParcela")]
    public partial class CondicaoParcela
    {
        public int ID { get; set; }

        public int IDCondicao { get; set; }

        public int Parcela { get; set; }

        [Required]
        [StringLength(10)]
        public string TipoDt { get; set; }

        public DateTime? Dt { get; set; }

        public int? DiaMes { get; set; }

        [StringLength(15)]
        public string TipoVlr { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VlrPerc { get; set; }

        public byte? Entrada { get; set; }

        public int? IDTipoDocumento { get; set; }

        public byte? bAVista { get; set; }

        public virtual Condicao Condicao { get; set; }
    }
}
