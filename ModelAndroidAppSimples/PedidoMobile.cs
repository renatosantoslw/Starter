namespace ModelAndroidAppSimples
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PedidoMobile")]
    public partial class PedidoMobile
    {
        public int ID { get; set; }

        public DateTime? Data { get; set; }

        public int? IDVendedor { get; set; }

        [StringLength(500)]
        public string VendedorNome { get; set; }

        public int? IDCliente { get; set; }

        [StringLength(500)]
        public string ClienteNome { get; set; }

        public int? IDCondicao { get; set; }

        public decimal? TotalProduto { get; set; }

        public decimal? PercDesconto { get; set; }

        public decimal? ValorDesconto { get; set; }

        public decimal? ValorAcrescimo { get; set; }

        public decimal? TotalPedido { get; set; }

        [StringLength(500)]
        public string Observacao { get; set; }

        public int? IDPedido { get; set; }

        public bool? Confirmado { get; set; }

        public bool? Importado { get; set; }

        public int? IDTipoPedido { get; set; }

        [StringLength(300)]
        public string CondicaoNome { get; set; }
    }
}
