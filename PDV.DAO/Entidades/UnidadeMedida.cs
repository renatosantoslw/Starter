using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class UnidadeMedida
    {
        [CampoTabela("IDUNIDADEDEMEDIDA")]
        [MaxLength(18)]
        public int IDUnidadeDeMedida { get; set; }

        [CampoTabela("DESCRICAO")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        [CampoTabela("SIGLA")]
        [MaxLength(4)]
        public string Sigla { get; set; }

        public UnidadeMedida()
        {
        }
    }
}
