using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class PerfilAcesso
    {
        [CampoTabela("IDPERFILACESSO")]
        [MaxLength(18)]
        public decimal IDPerfilAcesso { get; set; }

        [CampoTabela("DESCRICAO")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        [CampoTabela("ATIVO")]
        [MaxLength(1)]
        public decimal Ativo { get; set; } = 1;

        [CampoTabela("ISADMIN")]
        [MaxLength(1)]
        public decimal IsAdmin { get; set; } = 0;

        public PerfilAcesso()
        {
        }
    }
}
