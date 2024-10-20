using System;

namespace PDV.VIEW.Forms.Util
{
    public class FormaPagamentoAux
    {
        public int Identificador { get; set; }
        public int Sequencia { get; set; }
        public string Cod { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public int Pagamento { get; set; }
    }
}