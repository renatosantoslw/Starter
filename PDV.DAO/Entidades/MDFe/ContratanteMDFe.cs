namespace PDV.DAO.Entidades.MDFe
{
    public class ContratanteMDFe
    {
        public decimal IDContratanteMDFe { get; set; } = -1;
        public decimal IDMDFe { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }

        public ContratanteMDFe() { }
    }
}
