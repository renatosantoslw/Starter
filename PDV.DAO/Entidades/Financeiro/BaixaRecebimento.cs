using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades.Financeiro
{
    public class BaixaRecebimento
    {
        [CampoTabela("IDBAIXARECEBIMENTO")]
        public decimal IDBaixaRecebimento { get; set; }

        [CampoTabela("IDCONTARECEBER")]
        public decimal IDContaReceber { get; set; }

        [CampoTabela("IDFORMADEPAGAMENTO")]
        public decimal IDFormaDePagamento { get; set; }

        [CampoTabela("IDCONTABANCARIA")]
        public decimal IDContaBancaria { get; set; }

        [CampoTabela("IDHISTORICOFINANCEIRO")]
        public decimal IDHistoricoFinanceiro { get; set; }

        [CampoTabela("COMPLMHISFIN")]
        public string ComplmHisFin { get; set; }

        [CampoTabela("BAIXA")]
        public DateTime Baixa { get; set; } = DateTime.Now;

        [CampoTabela("MULTA")]
        public decimal Multa { get; set; }

        [CampoTabela("JUROS")]
        public decimal Juros { get; set; }

        [CampoTabela("DESCONTO")]
        public decimal Desconto { get; set; }

        [CampoTabela("VALOR")]
        public decimal Valor { get; set; }

        [CampoTabela("DATACONCILIACAO")]
        public DateTime? DataConciliacao { get; set; }

        [CampoTabela("IDFLUXOCAIXA")]
        public decimal IDFluxoCaixa { get; set; }

        public BaixaRecebimento() { }
    }
}