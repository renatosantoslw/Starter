using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class CSTPis
    {
        [CampoTabela("IDCSTPIS")]
        public decimal IDCSTPis { get; set; }

        [CampoTabela("CST")]
        public decimal CST { get; set; }

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        public CSTPis() { }
    }
}
