namespace ModelAndroidApp.ModelAndroid
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nota")]
    public partial class Nota
    {
        public int ID { get; set; }

        public DateTime? Data { get; set; }

        public int? IDVendedor { get; set; }

        [StringLength(500)]
        public string VendedorNome { get; set; }

        public int IDCliente { get; set; }

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

        [StringLength(50)]
        public string FormaPagamento { get; set; }

        
        public int? Ent_Sai { get; set; }

        [StringLength(150)]
        public string tipoNota { get; set; }

        

        public decimal? ValorEntrada { get; set; }

        public short? QtdParcelas { get; set; }

        [StringLength(1)]
        public string FormaPgto { get; set; }

        public decimal? SaldoaFinanciar { get; set; }

        public int? IDEmpresa { get; set; }

        [StringLength(3)]
        public string IDEmpresaERP { get; set; }

        [StringLength(50)]
        public string NumeroNFe { get; set; }

      
    }
}
