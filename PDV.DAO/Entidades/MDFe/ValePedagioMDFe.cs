namespace PDV.DAO.Entidades.MDFe
{
    public class ValePedagioMDFe
    {
        public decimal IDValePedagioMDFe { get; set; } = -1;
        public decimal IDMDFe { get; set; }
        public string CNPJFornecedora { get; set; }
        public string CNPJPagamento { get; set; }
        public string CPFPagamento { get; set; }
        public string NumeroCompra { get; set; }
        public decimal Valor { get; set; }

        public ValePedagioMDFe() { }

    }
}
