using System;

namespace PDV.DAO.Entidades.PDV
{
    public class RetiradaCaixa
    {
        public decimal IDRetiradaCaixa { get; set; }

        public decimal IDFluxoCaixa { get; set; }

        public decimal ValorRetirada { get; set; }

        public DateTime DataRetirada { get; set; }

        public RetiradaCaixa()
        {
        }

    }
}
