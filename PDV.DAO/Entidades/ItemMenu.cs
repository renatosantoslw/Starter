using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class ItemMenu
    {
        [CampoTabela("IDITEMMENU")]
        public decimal IDItemMenu { get; set; }

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        [CampoTabela("ITEMSUPERIOR")]
        public string ItemSuperior { get; set; }

        [CampoTabela("IDITEMMENUSUPERIOR")]
        public decimal? IDItemMenuSuperior { get; set; }

        public ItemMenu()
        {
        }
    }
}
