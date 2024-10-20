using System;

namespace PDV.DAO.Custom
{
    public class VersaoModulo
    {
        public Version VersaoAtual { get; set; }
        public Version VersaoDisponivel { get; set; }
        public bool Disponivel
        {
            get
            {
                return (VersaoAtual != null && VersaoDisponivel != null) ? VersaoDisponivel > VersaoAtual : false;
            }
        }

        public VersaoModulo() { }
    }
}
