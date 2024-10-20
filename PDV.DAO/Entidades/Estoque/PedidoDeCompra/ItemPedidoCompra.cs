using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.Estoque.PedidoDeCompra
{
    public class ItemPedidoCompra
    {
        [CampoTabela("IDITEMPEDIDOCOMPRA")]
        public decimal IDItemPedidoCompra { get; set; }

        [CampoTabela("IDPEDIDOCOMPRA")]
        public decimal IDPedidoCompra { get; set; }

        [CampoTabela("CODIGOITEM")]
        public string CodigoItem { get; set; }

        [CampoTabela("IDUSUARIO")]
        public decimal IDUsuario { get; set; }

        [CampoTabela("IDPRODUTO")]
        public decimal IDProduto { get; set; }

        [CampoTabela("DESCRICAOITEM")]
        public string DescricaoItem { get; set; }

        [CampoTabela("QUANTIDADE")]
        public decimal Quantidade { get; set; }

        [CampoTabela("VALORUNITARIO")]
        public decimal ValorUnitario { get; set; }

        [CampoTabela("DESCONTOPORCENTAGEM")]
        public decimal DescontoPorcentagem { get; set; }

        [CampoTabela("DESCONTO")]
        public decimal DescontoValor { get; set; }

        

        [CampoTabela("VALORTOTALITEM")]
        public decimal Total { get; set; }


        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        

        [CampoTabela("ITEM")]
        [MaxLength(18)]
        public decimal Item { get; set; }

        public ItemPedidoCompra() { }
    }
}