namespace IntegradorZeusPDV.MODEL.ClassesPDV
{
    public class ItemVenda
    {
        public decimal IDItemVenda { get; set; }

        public decimal IDProduto { get; set; }

        public Produto Produto { get; set; }

        public decimal IDVenda { get; set; }

        public string CodigoItem { get; set; }

        public string DescricaoItem { get; set; }

        public decimal DescontoPorcentagem { get; set; }

        public decimal DescontoValor { get; set; }

        public decimal Quantidade { get; set; }

        public decimal ValorUnitarioItem { get; set; }

        public decimal ValorTotalItem { get; set; }

        public decimal IDUsuario { get; set; }

        public ItemVenda() { }
    }
}
