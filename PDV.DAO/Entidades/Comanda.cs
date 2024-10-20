using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class Comanda
    {
        [CampoTabela("IDCOMANDA")]
        [MaxLength(18)]
        public decimal IDComanda { get; set; }

        [CampoTabela("CODIGO")]
        [MaxLength(14)]
        public string Codigo { get; set; }

        [CampoTabela("DESCRICAO")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        /* Campo Usado no Android, NÃO EXISTE NO BANCO */
        [CampoTabela("IDVENDA")]
        [MaxLength(18)]
        public decimal? IDVenda { get; set; }

        /* Campo Usado no Android, NÃO EXISTE NO BANCO */
        [CampoTabela("CPF")]
        [MaxLength(18)]
        public decimal? CPF { get; set; }

        /* Campo Usado no Android, NÃO EXISTE NO BANCO */
        [CampoTabela("STATUS")]
        [MaxLength(18)]
        public bool Status { get; set; }

        [CampoTabela("NomeCliente")]
        [MaxLength(18)]
        public decimal NomeCliente { get; set; }

        public Comanda()
        {
        }
    }
}
