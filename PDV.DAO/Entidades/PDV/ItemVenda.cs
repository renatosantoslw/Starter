using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.PDV
{
    public class ItemVenda
    {
        [CampoTabela("IDITEMVENDA")]
        [MaxLength(18)]
        public decimal IDItemVenda { get; set; }

        [CampoTabela("IDPRODUTO")]
        [MaxLength(18)]
        public decimal IDProduto { get; set; }        

        [CampoTabela("IDVENDA")]
        [MaxLength(18)]
        public decimal IDVenda { get; set; }

        /* Campos para fazer o controle na tela do PDV */
        [CampoTabela("CODIGOITEM")]
        public string CodigoItem { get; set; }

        [CampoTabela("DESCRICAOITEM")]
        public string DescricaoItem { get; set; }

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        [CampoTabela("DESCONTOPORCENTAGEM")]
        [MaxLength(7.2)]
        public decimal DescontoPorcentagem { get; set; }

        [CampoTabela("DESCONTOVALOR")]
        [MaxLength(7.2)]
        public decimal DescontoValor { get; set; }

        [CampoTabela("QUANTIDADE")]
        [MaxLength(7.2)]
        public decimal Quantidade { get; set; }

        [CampoTabela("VALORUNITARIOITEM")]
        [MaxLength(7.2)]
        public decimal ValorUnitarioItem { get; set; }

        [CampoTabela("SUBTOTAL")]
        [MaxLength(7.2)]
        public decimal Subtotal { get; set; }

        [CampoTabela("IDUSUARIO")]
        [MaxLength(18)]
        public decimal IDUsuario { get; set; }

        [CampoTabela("MARCA")]
        public string Marca { get; set; }

        [CampoTabela("ITEM")]
        [MaxLength(18)]
        public decimal Item { get; set; }

        [CampoTabela("ALTURA")]
        public decimal Altura { get; set; }

        [CampoTabela("LARGURA")]
        public decimal Largura { get; set; }

        [CampoTabela("AREA")]
        public decimal Area { get; set; }

        public ItemVenda()
        {
        }
    }
}
