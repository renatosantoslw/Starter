using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades.PDV
{
    public class DuplicataDAC
    {
        [CampoTabela("IDDUPLICATADAC")]
        public decimal IDDuplicataDAC { get; set; }

        [CampoTabela("IDCOMPRA")]
        public decimal IDCompra { get; set; }

        [CampoTabela("IDFORMADEPAGAMENTO")]
        public decimal IDFormaDePagamento { get; set; }

        [CampoTabela("FORMADEPAGAMENTO")]
        public string FormaDePagamento { get; set; }

        [CampoTabela("DATAVENCIMENTO")]
        public DateTime DataVencimento { get; set; }

        [CampoTabela("VALOR")]
        public decimal Valor { get; set; }

        [CampoTabela("PAGAMENTO")]
        public decimal Pagamento { get; set; }
        public DuplicataDAC() { }
    }
}
