namespace PDV.DAO.Entidades.Estoque.Transferencia
{
    public class ItemTransferenciaEstoque
    {
        public decimal IDItemTransferenciaEstoque { get; set; } = -1;
        public decimal IDTransferenciaEstoque { get; set; }
        public decimal IDProduto { get; set; }
        public decimal IDAlmoxarifadoEntrada { get; set; }
        public decimal IDAlmoxarifadoSaida { get; set; }
        public decimal Quantidade { get; set; }

        public ItemTransferenciaEstoque() { }
    }
}
