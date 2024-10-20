using PDV.DAO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.CONTROLLER.NFCE.Util
{
    public class TributoNFCe
    {
        public decimal IDProduto { get; set; }

        public decimal PercentualEstadual { get; set; }

        public decimal PercentualFederal { get; set; }

        public decimal PercentualMunicipal { get; set; }

        public Ncm NCM { get; set; }

        public TributoNFCe()
        {
        }
    }
}
