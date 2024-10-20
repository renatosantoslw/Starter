namespace PDV.DAO.Entidades.MDFe
{
    public class VeiculoTracaoMDFe
    {
        public decimal IDVeiculoTracaoMDFe { get; set; } = -1;
        public decimal? IDProprietarioVeiculoMDFe { get; set; }
        public decimal? IDCondutor { get; set; }
        public decimal IDVeiculo { get; set; }
        public decimal IDMDFe { get; set; }

        public VeiculoTracaoMDFe() { }
    }
}
