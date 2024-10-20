using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class CSTCofins
    {
        [CampoTabela("IDCSTCOFINS")]
        public decimal IDCSTCofins { get; set; }

        [CampoTabela("CST")]
        public decimal CST { get; set; }

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        public CSTCofins() { }
    }
}
