using System;

namespace PDV.DAO.Entidades.Estoque.InventarioEstoque
{
    public class Inventario
    {
        public decimal IDInventario { get; set; } = -1;

        public DateTime DataInventario { get; set; } = DateTime.Now;

        public Inventario() { }
    }
}
