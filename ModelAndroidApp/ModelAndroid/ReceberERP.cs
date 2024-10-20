namespace ModelAndroidApp.ModelAndroid
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReceberERP")]
    public partial class ReceberERP
    {
        public int ID { get; set; }

        public long IDClienteERP { get; set; }

        [Required]
        [StringLength(3)]
        public string IDEmpresaERP { get; set; }

        [Required]
        [StringLength(20)]
        public string Documento { get; set; }

        [Required]
        [StringLength(10)]
        public string Duplicata { get; set; }

        public DateTime DataEmissao { get; set; }

        public DateTime DataVencimento { get; set; }

        public decimal Valor { get; set; }

        public decimal? SaldoDevedor { get; set; }

        public DateTime? DataPagamento { get; set; }

        public decimal? ValorJurosPagos { get; set; }

        public int? Atraso { get; set; }

        [StringLength(1)]
        public string Quitado { get; set; }
    }
}
