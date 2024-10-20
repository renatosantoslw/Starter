using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.NFe
{
    public class ProdutoNFeICMS
    {

        [CampoTabela("IDPRODUTONFEICMS")]
        public decimal IDProdutoNFeICMS { get; set; }

        [CampoTabela("IDORIGEMPRODUTO")]
        public decimal IDOrigemProduto { get; set; }

        [CampoTabela("IDCSTICMS")]
        public decimal IDCstICMS { get; set; }

        [CampoTabela("IDUNIDADEFEDERATIVAST")]
        public decimal IDUnidadeFederativaST { get; set; }

        [CampoTabela("IDPRODUTONFE")]
        public decimal IDProdutoNFe { get; set; }

        [CampoTabela("MODBC")]
        public decimal ModBC { get; set; }

        [CampoTabela("PREDBC")]
        public decimal PRedBC { get; set; }

        [CampoTabela("VBC")]
        public decimal VBc { get; set; }

        [CampoTabela("PICMS")]
        public decimal PIcms { get; set; }

        [CampoTabela("VICMS")]
        public decimal VIcms { get; set; }

        [CampoTabela("MODBCST")]
        public decimal ModBCST { get; set; }

        [CampoTabela("PMVAST")]
        public decimal PMVAST { get; set; }

        [CampoTabela("PREDBCST")]
        public decimal PRedBcST { get; set; }

        [CampoTabela("VBCST")]
        public decimal VBcST { get; set; }

        [CampoTabela("PICMSST")]
        public decimal PIcmsST { get; set; }

        [CampoTabela("VICMSST")]
        public decimal VIcmsST { get; set; }

        [CampoTabela("PCREDSN")]
        public decimal PCredSN { get; set; }

        [CampoTabela("VCREDICMSSN")]
        public decimal VCredIcmsSN { get; set; }

        [CampoTabela("PDIF")]
        public decimal PDif { get; set; }

        [CampoTabela("VICMSDIF")]
        public decimal VIcmsDif { get; set; }

        public ProdutoNFeICMS() { }
    }
}