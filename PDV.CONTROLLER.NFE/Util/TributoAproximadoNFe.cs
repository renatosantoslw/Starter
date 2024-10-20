using PDV.DAO.Entidades;

namespace PDV.CONTROLLER.NFE.Util
{
    public class TributoAproximadoNFe
    {
        public decimal IDProduto { get; set; }

        public decimal PercentualEstadual { get; set; }

        public decimal PercentualFederal { get; set; }

        public decimal PercentualMunicipal { get; set; }

        public Ncm NCM { get; set; }

        public TributoAproximadoNFe() { }
    }
}
