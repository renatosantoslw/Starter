namespace ModelAndroidAppSimples
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PedidoERP")]
    public partial class PedidoERP
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Data { get; set; }

        public int? PessoaID { get; set; }

        public decimal? TotalPedido { get; set; }

        public int? PedidoID { get; set; }

        [StringLength(500)]
        public string Pessoa { get; set; }

        public int? Ent_Sai { get; set; }

        [StringLength(500)]
        public string TipoNota { get; set; }

        public int? GerouFinanceiro { get; set; }

        [StringLength(300)]
        public string Condicao { get; set; }

        public int? IDVendedor { get; set; }

        [StringLength(150)]
        public string Status { get; set; }

        [StringLength(300)]
        public string VendedorNome { get; set; }
    }
}
