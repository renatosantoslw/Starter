using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.Estoque.Suprimentos
{
    public class Requisitante
    {
        [CampoTabela("IDREQUISITANTE")]
        public decimal IDRequisitante { get; set; } = -1;

        [CampoTabela("IDCENTROCUSTO")]
        public decimal IDCentroCusto { get; set; } = -1;

        [CampoTabela("NOME")]
        public string Nome { get; set; }

        public Requisitante() { }
    }
}
