using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades.Financeiro
{
    public class ContaReceber
    {
        [CampoTabela("IDCONTARECEBER")]
        public decimal IDContaReceber { get; set; } = -1;

        [CampoTabela("IDCONTABANCARIA")]
        public decimal? IDContaBancaria { get; set; }

        [CampoTabela("IDVENDA")]
        public decimal? IDVenda { get; set; }

        [CampoTabela("IDTIPOTITULO")]
        public decimal IDCentroCusto { get; set; }

        [CampoTabela("IDCLIENTE")]
        public decimal? IDCliente { get; set; }

        [CampoTabela("IDFORMADEPAGAMENTO")]
        public decimal? IDFormaDePagamento { get; set; }

        [CampoTabela("IDHISTORICOFINANCEIRO")]
        public decimal? IDHistoricoFinanceiro { get; set; }

        [CampoTabela("TITULO")]
        public string Titulo { get; set; }

        [CampoTabela("PARCELA")]
        public decimal Parcela { get; set; } = 1;

        [CampoTabela("EMISSAO")]
        public DateTime Emissao { get; set; } = DateTime.Now;

        [CampoTabela("VENCIMENTO")]
        public DateTime Vencimento { get; set; } = DateTime.Now;

        [CampoTabela("PAGAMENTO")]
        public DateTime Pagamento { get; set; }

        [CampoTabela("COMPLMHISFIN")]
        public string ComplmHisFin { get; set; }

        [CampoTabela("FLUXO")]
        public DateTime Fluxo { get; set; } = DateTime.Now;

        [CampoTabela("VALOR")]
        public decimal Valor { get; set; }

        [CampoTabela("ORIGEM")]
        public string Origem { get; set; } = "FINANCEIRO";

        [CampoTabela("MULTA")]
        public decimal Multa { get; set; }

        [CampoTabela("JUROS")]
        public decimal Juros { get; set; }

        [CampoTabela("DESCONTO")]
        public decimal Desconto { get; set; }

        [CampoTabela("SITUACAO")]
        public decimal Situacao { get; set; } = -1;

        [CampoTabela("VALORTOTAL")]
        public decimal ValorTotal { get; set; }

        [CampoTabela("SALDO")]
        public decimal Saldo { get; set; }

        [CampoTabela("IDCONTARECEBERRENEGOCIACAO")]
        public decimal? IDContaReceberRenegociacao { get; set; }

        [CampoTabela("IDMOVIMENTOFISCAL")]
        public decimal? IDMovimentoFiscal { get; set; } = null;

        [CampoTabela("ULTIMAMODIFICACAO")]
        public DateTime UltimaModificacao { get; set; } = DateTime.Now;

        [CampoTabela("IDUSUARIO")]
        public decimal IDUsuario { get; set; }

        public ContaReceber() { }
    }
}
