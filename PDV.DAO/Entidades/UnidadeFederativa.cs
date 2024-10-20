using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class UnidadeFederativa
    {
        [CampoTabela("IDUNIDADEFEDERATIVA")]
        [MaxLength(18)]
        public decimal IDUnidadeFederativa { get; set; } = -1;

        [CampoTabela("IDPAIS")]
        [MaxLength(18)]
        public decimal IDPais { get; set; } = -1;

        [CampoTabela("PAIS")]
        [MaxLength(150)]
        public string Pais { get; set; }

        [CampoTabela("DESCRICAO")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        [CampoTabela("SIGLA")]
        [MaxLength(10)]
        public string Sigla { get; set; }

        [CampoTabela("ALIQUOTAINTER")]
        [MaxLength(15.2)]
        public decimal AliquotaInter { get; set; }

        [CampoTabela("ALIQUOTAINTRA")]
        [MaxLength(15.2)]
        public decimal AliquotaIntra { get; set; }

        [CampoTabela("FCP")]
        [MaxLength(15.2)]
        public decimal FCP { get; set; }

        public UnidadeFederativa() { }
    }
}
