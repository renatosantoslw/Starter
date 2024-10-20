using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.VIEW.Integração_Migrados.Model
{
    public class VWContasReceber
    {
        public int ID { get; set; }
        public string  Nome { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal  Valor { get; set; }
        public string  Parcela { get; set; }

        public int  NumeroPedido { get; set; }

    }
}
