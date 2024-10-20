using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class BandeiraCartao
    {
        [CampoTabela("IDBANDEIRACARTAO")]
        [MaxLength(18)]
        public decimal IDBandeiraCartao { get; set; } = -1;

        [CampoTabela("CODIGO")]
        [MaxLength(2)]
        public decimal Codigo { get; set; } = -1;

        [CampoTabela("DESCRICAO")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        [CampoTabela("CODIGODESCRICAO")]
        [MaxLength(200)]
        public string CodigoDescricao { get; set; }

        public BandeiraCartao()
        {
        }
    }
}
