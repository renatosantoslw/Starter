namespace PDV.DAO.Entidades.MDFe
{
    public class SeguradoraMDFe
    {
        public decimal IDSeguradoraMDFe { get; set; } = -1;
        public decimal IDSeguradora { get; set; }
        public decimal IDMDFe { get; set; }
        public string NumeroApolice { get; set; }
        public decimal IDResponsavelSeguroCargaMDFe { get; set; }

        public SeguradoraMDFe() { }
    }
}
