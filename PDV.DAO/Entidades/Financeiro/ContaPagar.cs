using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades.Financeiro
{
    public class ContaPagar
    {
        [CampoTabela("IDCONTAPAGAR")]
        public decimal IDContaPagar { get; set; } = -1;

        [CampoTabela("IDCONTABANCARIA")]
        public decimal? IDContaBancaria { get; set; }

        [CampoTabela("IDPEDIDOCOMPRA")]
        public decimal? IDPedidoCompra { get; set; }

        [CampoTabela("IDTIPOTITULO")]
        public decimal IDCentroCusto { get; set; }

        [CampoTabela("IDFORNECEDOR")]
        public decimal? IDFornecedor { get; set; }

        [CampoTabela("IDFORMADEPAGAMENTO")]
        public decimal IDFormaDePagamento { get; set; }

        [CampoTabela("IDHISTORICOFINANCEIRO")]
        public decimal IDHistoricoFinanceiro { get; set; }

        [CampoTabela("TITULO")]
        public string Titulo { get; set; }

        [CampoTabela("PARCELA")]
        public decimal Parcela { get; set; } = 1;

        [CampoTabela("EMISSAO")]
        public DateTime Emissao { get; set; } = DateTime.Now;

        [CampoTabela("VENCIMENTO")]
        public DateTime Vencimento { get; set; } = DateTime.Now;

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

        [CampoTabela("IDNFEENTRADA")]
        public decimal? IDNFeEntrada { get; set; }

        [CampoTabela("ORD")]
        public string Ord { get; set; }



        public static readonly int Cancelado = 0;
        public static readonly int Aberto = 1;
        public static readonly int Parcial = 2;
        public static readonly int Baixado = 3;
        public ContaPagar() { }
    }
}