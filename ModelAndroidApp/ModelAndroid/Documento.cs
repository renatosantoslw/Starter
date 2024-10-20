namespace ModelAndroidApp.ModelAndroid
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Documento")]
    public partial class Documento
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Emissao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Vencimento { get; set; }

        [StringLength(250)]
        public string Titulo { get; set; }

        public decimal? ValorEmAberto { get; set; }

        public decimal? Valor { get; set; }

        public decimal? ValorTotal { get; set; }

        public int? IDDocumento { get; set; }

        public int? PessoaID { get; set; }

        public int? NumeroPedido { get; set; }

        public bool? Cobrado { get; set; }

        [StringLength(300)]
        public string Pessoa { get; set; }

        public int? Tipo { get; set; }

        [StringLength(400)]
        public string Detalhe { get; set; }
    }
}
