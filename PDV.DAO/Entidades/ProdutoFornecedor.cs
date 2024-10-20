using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class ProdutoFornecedor
    {
        [CampoTabela("IDPRODUTOFORNECEDOR")]
        public decimal IDProdutoFornecedor { get; set; } = -1;

        [CampoTabela("IDPRODUTO")]
        public decimal IDProduto { get; set; }

        [CampoTabela("IDFORNECEDOR")]
        public decimal IDFornecedor { get; set; }

        [CampoTabela("CPROD")]
        public string CProd { get; set; }

        public ProdutoFornecedor() { }
    }
}