using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class Municipio
    {
        [CampoTabela("IDMUNICIPIO")]
        [MaxLength(18)]
        public decimal IDMunicipio { get; set; } = -1;

        [CampoTabela("IDUNIDADEFEDERATIVA")]
        [MaxLength(18)]
        public decimal IDUnidadeFederativa { get; set; } = -1;

        [CampoTabela("CODIGOIBGE")]
        [MaxLength(50)]
        public string CodigoIBGE { get; set; }

        [CampoTabela("UNIDADEFEDERATIVA")]
        [MaxLength(150)]
        public string UnidadeFederativa { get; set; }

        [CampoTabela("DESCRICAO")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        public Municipio() { }
    }
}
