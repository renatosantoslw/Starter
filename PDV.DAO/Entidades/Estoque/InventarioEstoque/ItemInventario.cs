namespace PDV.DAO.Entidades.Estoque.InventarioEstoque
{
    public class ItemInventario
    {
        public decimal IDItemInventario { get; set; }
        public decimal IDInventario { get; set; }
        public decimal IDAlmoxarifado { get; set; }
        public decimal IDProduto { get; set; }
        public decimal Quantidade { get; set; }

        public ItemInventario() { }
    }
}
