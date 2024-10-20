using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.NFe
{
    public class DocumentoReferenciadoNFe
    {
        [CampoTabela("IDDOCUMENTOREFERENCIADONFE")]
        public decimal IDDocumentoReferenciadoNFe { get; set; } = -1;

        [CampoTabela("CHAVE")]
        public string Chave { get; set; }

        [CampoTabela("IDUNIDADEFEDERATIVA")]
        public decimal IDUnidadeFederativa { get; set; }

        [CampoTabela("UNIDADEFEDERATIVA")]
        public string UnidadeFederativa { get; set; }

        [CampoTabela("CODIGODOCUMENTOREFERENCIADO")]
        public int CodigoDocumentoReferenciado { get; set; }

        [CampoTabela("DOCUMENTOREFERENCIADO")]
        public string DocumentoReferenciado { get; set; }

        [CampoTabela("IDNFE")]
        public decimal IDNFe { get; set; }

        public DocumentoReferenciadoNFe() { }
    }
}
