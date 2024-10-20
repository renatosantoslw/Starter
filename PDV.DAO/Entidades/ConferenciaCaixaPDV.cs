using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.DAO.Entidades
{
    public class ConferenciaCaixaPDV
    {
        public decimal IdConferenciaCaixaPDV { get; set; }

        public DateTime Data { get; set; }

        public decimal IdFluxoCaixa { get; set; }

        public decimal IdFormaPagamento { get; set; }

        public string NomeFormaPagamento { get; set; }

        public decimal valordigitado { get; set; }

        public decimal valorcalculado { get; set; }

        public decimal diferenca { get; set; }
    }
}
