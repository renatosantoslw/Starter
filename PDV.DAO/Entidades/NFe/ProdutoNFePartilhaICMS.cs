using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.NFe
{
    public class ProdutoNFePartilhaICMS
    {
        [CampoTabela("IDPRODUTONFEPARTILHAICMS")]
        public decimal IDProdutoNFePartilhaICMS { get; set; }

        [CampoTabela("IDPRODUTONFE")]
        public decimal IDProdutoNFe { get; set; }

        [CampoTabela("VBCUFDEST")]
        public decimal VBcUFDest { get; set; }

        [CampoTabela("PFCPUFDEST")]
        public decimal PFcpUFDest { get; set; }

        [CampoTabela("PICMSUFDEST")]
        public decimal PIcmsUFDest { get; set; }

        [CampoTabela("PICMSINTER")]
        public decimal PIcmsInter { get; set; }

        [CampoTabela("PICMSINTERPART")]
        public decimal PIcmsInterPart { get; set; }

        [CampoTabela("VFCPUFDEST")]
        public decimal VFcpUFDest { get; set; }

        [CampoTabela("VICMSUFDEST")]
        public decimal VIcmsUFDest { get; set; }

        [CampoTabela("VICMSUFREMET")]
        public decimal VIcmsUFRemet { get; set; }

        public ProdutoNFePartilhaICMS() { }
    }
}