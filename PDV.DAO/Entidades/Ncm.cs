using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades
{
    public class Ncm
    {
        [CampoTabela("IDNCM")]
        [MaxLength(18)]
        public decimal IDNCM { get; set; }

        [CampoTabela("IDUNIDADEFEDERATIVA")]
        [MaxLength(18)]
        public decimal IDUnidadeFederativa { get; set; }

        [CampoTabela("CODIGO")]
        [MaxLength(9)]
        public decimal Codigo { get; set; }

        [CampoTabela("EX")]
        [MaxLength(9)]
        public decimal? Ex { get; set; }

        [CampoTabela("TIPO")]
        [MaxLength(1)]
        public decimal Tipo { get; set; }

        [CampoTabela("DESCRICAO")]
        [MaxLength(1000)]
        public string Descricao { get; set; }

        [CampoTabela("NACIONALFEDERAL")]
        [MaxLength(7.2)]
        public decimal NacionalFederal { get; set; }

        [CampoTabela("IMPORTADOSFEDERAL")]
        [MaxLength(7.2)]
        public decimal ImportadosFederal { get; set; }

        [CampoTabela("ESTADUAL")]
        [MaxLength(7.2)]
        public decimal Estadual { get; set; }

        [CampoTabela("MUNICIPAL")]
        [MaxLength(7.2)]
        public decimal Municipal { get; set; }

        [CampoTabela("VIGENCIAINICIO")]
        [MaxLength(10)]
        public DateTime VigenciaInicio { get; set; }

        [CampoTabela("VIGENCIAFIM")]
        [MaxLength(10)]
        public DateTime VigenciaFim { get; set; }

        [CampoTabela("CHAVE")]
        [MaxLength(100)]
        public string Chave { get; set; }

        [CampoTabela("VERSAO")]
        [MaxLength(100)]
        public string Versao { get; set; }

        [CampoTabela("FONTE")]
        [MaxLength(100)]
        public string Fonte { get; set; }

        [CampoTabela("CODIGODESCRICAO")]
        [MaxLength(280)]
        public string CodigoDescricao { get; set; }

        public Ncm()
        {
        }

    }
}
