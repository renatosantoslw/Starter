namespace ModelAndroidAppSimples
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PedidoItemMobile")]
    public partial class PedidoItemMobile
    {
        public int ID { get; set; }

        public int? IDPedido { get; set; }

        public int? IDSequencia { get; set; }

        public int? IDProduto { get; set; }

        [StringLength(500)]
        public string ProdutoNome { get; set; }

        public decimal? Quantidade { get; set; }

        public int? IDUnidade { get; set; }

        [StringLength(500)]
        public string UnidadeNome { get; set; }

        public decimal? Valor { get; set; }

        public decimal? SubTotal { get; set; }

        public decimal? PercDesconto { get; set; }

        public decimal? ValorDesconto { get; set; }

        public decimal? Total { get; set; }

        public int? Bfaturado { get; set; }

        public int? IDPedidoItem { get; set; }

        public bool? Confirmado { get; set; }

        public bool? Importado { get; set; }

        public int? IDVendedor { get; set; }

        public DateTime? Data { get; set; }
    }
}
