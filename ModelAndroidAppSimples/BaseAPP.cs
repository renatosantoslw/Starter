namespace ModelAndroidAppSimples
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaseAPP")]
    public partial class BaseAPP
    {
        public int ID { get; set; }

        public string Cliente { get; set; }

        public string Vendedores { get; set; }

        public string Condicao { get; set; }

        public string Produto { get; set; }

        public string Pedido { get; set; }

        public string PedidoItem { get; set; }

        public string Documento { get; set; }

        public string Movimento { get; set; }
    }
}
