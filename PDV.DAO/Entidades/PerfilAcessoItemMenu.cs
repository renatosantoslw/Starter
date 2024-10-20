using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class PerfilAcessoItemMenu
    {
        [CampoTabela("IDPERFILACESSOITEMMENU")]
        [MaxLength(18)]
        public decimal IDPerfilAcessoItemMenu { get; set; }

        [CampoTabela("IDPERFILACESSO")]
        [MaxLength(18)]
        public decimal IDPerfilAcesso { get; set; }

        [CampoTabela("IDITEMMENU")]
        [MaxLength(18)]
        public decimal IDItemMenu { get; set; }

        public PerfilAcessoItemMenu()
        {
        }
    }
}
