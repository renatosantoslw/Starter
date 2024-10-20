using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class Categoria
    {

        [CampoTabela("IDCATEGORIA")]
        [MaxLength(18)]
        public decimal IDCategoria { get; set; } = -1;

        [CampoTabela("CODIGO")]
        [MaxLength(6)]
        public string Codigo { get; set; }

        [CampoTabela("DESCRICAO")]
        [MaxLength(200)]
        public string Descricao { get; set; }

        [CampoTabela("SUBCATEGORIAS")]
        public string SubCategorias { get; set; }
        [CampoTabela("IMAGEM")]
        public byte[] Imagem { get; set; }

        public Categoria()
        {
        }
    }
}
