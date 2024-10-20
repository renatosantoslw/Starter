using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class Pais
    {
        [CampoTabela("IDPAIS")]
        [MaxLength(18)]
        public decimal IDPais { get; set; }


        [CampoTabela("CODIGO")]
        [MaxLength(50)]
        public string Codigo { get; set; }

        [CampoTabela("DESCRICAO")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        public Pais() { }
    }
}
