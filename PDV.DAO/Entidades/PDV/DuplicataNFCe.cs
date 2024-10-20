using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades.PDV
{
    public class DuplicataNFCe
    {
        [CampoTabela("IDDUPLICATANFCE")]
        public decimal IDDuplicataNFCe { get; set; }

        [CampoTabela("IDVENDA")]
        public decimal IDVenda { get; set; }

        [CampoTabela("IDFORMADEPAGAMENTO")]
        public decimal IDFormaDePagamento { get; set; }

        [CampoTabela("FORMADEPAGAMENTO")]
        public string FormaDePagamento { get; set; }

        [CampoTabela("NUMEROPARCELA")]
        public decimal NumeroParcela { get; set; } // Usado somente em tela.

        [CampoTabela("DATAVENCIMENTO")]
        public DateTime DataVencimento { get; set; }

        [CampoTabela("DATAPAGAMENTO")]
        public DateTime DataPagamento { get; set; }

        [CampoTabela("VALOR")]
        public decimal Valor { get; set; }

        
        [CampoTabela("TROCO")]
        public decimal Troco { get; set; }

        [CampoTabela("PAGAMENTO")]
        public decimal Pagamento { get; set; }

        /* Campo Utilizado Somente em tela, não utilizado em banco de dados. */

        public string  Controle { get; set; }

        

        public DuplicataNFCe() { }
    }
}
