using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class Marca
    {
        [CampoTabela("IDMARCA")]
        [MaxLength(18)]
        public decimal IDMarca { get; set; } = -1;

        [CampoTabela("CODIGO")]
        [MaxLength(40)]
        public string Codigo { get; set; } = string.Empty;

        [CampoTabela("DESCRICAO")]
        [MaxLength(250)]
        public string Descricao { get; set; }

        [CampoTabela("CODIGODESCRICAO")]
        [MaxLength(280)]
        public string CodigoDescricao { get; set; }

        [CampoTabela("MARCADEVEICULO")]
        public bool MarcaDeVeiculo { get; set; }

        [CampoTabela("MARCADEPRODUTO")]
        public bool MarcaDeProduto { get; set; }
        public object ImagemMarca { get; set; }

        public Marca()
        {
        }
    }
}
