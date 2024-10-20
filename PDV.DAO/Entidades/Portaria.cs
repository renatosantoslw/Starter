using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class Portaria
    {
        [CampoTabela("IDPORTARIA")]
        [MaxLength(18)]
        public decimal IDPortaria { get; set; }

        [CampoTabela("TITULO")]
        [MaxLength(250)]
        public string Titulo { get; set; }

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        public Portaria()
        {

        }
    }
}
