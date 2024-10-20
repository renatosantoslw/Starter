namespace ModelAndroidAppSimples
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Movimentos
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Data { get; set; }

        [StringLength(250)]
        public string Detalhe { get; set; }

        public decimal? Valor { get; set; }

        public int? IDMovimento { get; set; }

        public int? DocumentoID { get; set; }

        public int? NumeroPedido { get; set; }

        [StringLength(500)]
        public string Operacao { get; set; }

        [StringLength(500)]
        public string Pessoa { get; set; }

        public int? IDVendedor { get; set; }
    }
}
