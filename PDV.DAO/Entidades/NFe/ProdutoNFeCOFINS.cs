using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.NFe
{
    public class ProdutoNFeCOFINS
    {
        [CampoTabela("IDPRODUTONFECOFINS")]
        public decimal IDProdutoNFeCOFINS { get; set; }

        [CampoTabela("IDPRODUTONFE")]
        public decimal IDProdutoNFe { get; set; }

        [CampoTabela("IDCSTCOFINS")]
        public decimal IDCstCOFINS { get; set; }

        [CampoTabela("VBC")]
        public decimal VBc { get; set; }

        [CampoTabela("PCOFINS")]
        public decimal PCOFINS { get; set; }

        [CampoTabela("VCOFINS")]
        public decimal VCOFINS { get; set; }

        public ProdutoNFeCOFINS() { }
    }
}
