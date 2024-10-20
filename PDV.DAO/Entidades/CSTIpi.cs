using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class CSTIpi
    {
        [CampoTabela("IDCSTIPI")]
        public decimal IDCSTIpi { get; set; }

        [CampoTabela("CST")]
        public decimal CST { get; set; }

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        public CSTIpi() { }
    }
}
