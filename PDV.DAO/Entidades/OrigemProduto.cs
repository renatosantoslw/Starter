using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class OrigemProduto
    {
        [CampoTabela("IDORIGEMPRODUTO")]
        public decimal IDOrigemProduto { get; set; }

        [CampoTabela("CODIGO")]
        public decimal Codigo { get; set; }

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        public OrigemProduto() { }
    }
}
