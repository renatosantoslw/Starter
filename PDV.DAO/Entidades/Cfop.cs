using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class Cfop
    {
        [CampoTabela("IDCFOP")]
        [MaxLength(18)]
        public decimal IDCfop { get; set; }

        [CampoTabela("CODIGO")]
        [MaxLength(4)]
        public string Codigo { get; set; }

        [CampoTabela("DESCRICAO")]
        [MaxLength(250)]
        public string Descricao { get; set; }

        [CampoTabela("CODIGODESCRICAO")]
        public string CodigoDescricao { get; set; }

        [CampoTabela("ATIVO")]
        [MaxLength(1)]
        public decimal Ativo { get; set; } = 1;

        [CampoTabela("TIPO")]
        [MaxLength(1)]
        public string Tipo { get; set; }

        public Cfop()
        {
        }
    }
}
