namespace ModelAndroidAppSimples
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PedidoItemERP")]
    public partial class PedidoItemERP
    {
        public int ID { get; set; }

        [StringLength(150)]
        public string ProdutoNome { get; set; }

        public decimal? Quantidade { get; set; }

        [StringLength(10)]
        public string Unidade { get; set; }

        public decimal? Valor { get; set; }

        public decimal? Desconto { get; set; }

        public decimal? Total { get; set; }

        public int? PedidoID { get; set; }

        public int? IDVendedor { get; set; }

        public int? Ent_Sai { get; set; }

        [StringLength(500)]
        public string VendedorNome { get; set; }

        public DateTime? Data { get; set; }

        public int? IDPedidoItem { get; set; }
    }
}
