using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class Endereco
    {
        [CampoTabela("IDENDERECO")]
        [MaxLength(18)]
        public decimal IDEndereco { get; set; } = -1;

        [CampoTabela("LOGRADOURO")]
        [MaxLength(150)]
        public string Logradouro { get; set; }

        [CampoTabela("NUMERO")]
        [MaxLength(255)]
        public string Numero { get; set; }

        [CampoTabela("CEP")]
        [MaxLength(8)]
        public string Cep { get; set; }

        [CampoTabela("COMPLEMENTO")]
        [MaxLength(150)]
        public string Complemento { get; set; }

        [CampoTabela("BAIRRO")]
        [MaxLength(150)]
        public string Bairro { get; set; }

        [CampoTabela("IDPAIS")]
        [MaxLength(18)]
        public decimal? IDPais { get; set; }

        [CampoTabela("PAIS")]
        [MaxLength(150)]
        public string Pais { get; set; }

        [CampoTabela("IDUNIDADEFEDERATIVA")]
        [MaxLength(18)]
        public decimal? IDUnidadeFederativa { get; set; }

        [CampoTabela("UNIDADEFEDERATIVA")]
        [MaxLength(150)]
        public string UnidadeFederativa { get; set; }

        [CampoTabela("IDMUNICIPIO")]
        [MaxLength(18)]
        public decimal? IDMunicipio { get; set; }

        [CampoTabela("MUNICIPIO")]
        [MaxLength(150)]
        public string Municipio { get; set; }

        [CampoTabela("TELEFONE")]
        [MaxLength(10)]
        public string Telefone { get; set; }

        public Endereco() { }
    }
}
