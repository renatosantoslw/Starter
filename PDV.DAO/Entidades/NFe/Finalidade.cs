using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.NFe
{
    public class Finalidade
    {
        [CampoTabela("IDFINALIDADE")]
        public decimal IDFinalidade { get; set; } = -1;

        [CampoTabela("CODIGO")]
        public string Codigo { get; set; }

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        public Finalidade() { }

    }
}
