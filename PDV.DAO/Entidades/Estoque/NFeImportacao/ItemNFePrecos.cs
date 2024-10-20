namespace PDV.DAO.Entidades.Estoque.NFeImportacao
{
    public class ItemNFePrecos
    {
        public int IDProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal Estoque { get; set; }
        public decimal CustoAnterior { get; set; }
        public decimal CustoNovo { get; set; }
        public decimal Markup { get; set; }
        public decimal ValorAnterior { get; set; }
        public decimal ValorNovo { get; set; }

        public ItemNFePrecos() { }
    }
}
