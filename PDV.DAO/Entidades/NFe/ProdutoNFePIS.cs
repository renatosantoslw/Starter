using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.NFe
{
    public class ProdutoNFePIS
    {
        [CampoTabela("IDPRODUTONFEPIS")]
        public decimal IDProdutoNFePIS { get; set; }

        [CampoTabela("IDPRODUTONFE")]
        public decimal IDProdutoNFe { get; set; }

        [CampoTabela("IDCSTPIS")]
        public decimal IDCstPIS { get; set; }

        [CampoTabela("VBC")]
        public decimal VBc { get; set; }

        [CampoTabela("PPIS")]
        public decimal PPis { get; set; }

        [CampoTabela("VPIS")]
        public decimal VPis { get; set; }

        public ProdutoNFePIS() { }
    }
}