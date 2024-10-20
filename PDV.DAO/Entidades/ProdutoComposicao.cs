using PDV.DAO.Atributos;
namespace PDV.DAO.Entidades
{
    public class ProdutoComposicao
    {
        [CampoTabela("IDPRODUTOCOMPOSICAO")]
        public decimal IdProdutoComposicao { get; set; } = -1;

        [CampoTabela("IDPRODUTO")]
        public decimal IdProduto { get; set; } = -1;

        [CampoTabela("IDPRODUTOCOMPOSTO")]
        public decimal IdProdutoComposto { get; set; } = -1;

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        [CampoTabela("QUANTIDADE")]
        public decimal Quantidade { get; set; }

        
    }
}