using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class CSTIcms
    {
        [CampoTabela("IDCSTICMS")]
        public decimal IDCSTIcms { get; set; }

        [CampoTabela("CSTCSOSN")]
        public decimal CSTCSOSN { get; set; }

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        public CSTIcms()
        {
        }
    }
}
