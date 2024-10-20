using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades.Estoque.PedidoDeCompra
{
    public class PedidoCompra
    {
        [CampoTabela("IDPEDIDOCOMPRA")]
        public decimal IDPedidoCompra { get; set; } = -1;

        [CampoTabela("IDFORNECEDOR")]
        public decimal? IDFornecedor { get; set; }

        [CampoTabela("IDFORMADEPAGAMENTO")]
        public decimal? IDFormaDePagamento { get; set; }

        [CampoTabela("IDVENDEDOR")]
        public decimal IDVendedor { get; set; }

        [CampoTabela("IDTIPODEOPERACAO")]
        public decimal IDTipoDeOperacao { get; set; } = -1;

        [CampoTabela("IDTRANSPORTADORA")]
        public decimal? IDTransportadora { get; set; }

        [CampoTabela("IDUSUARIOCADASTRO")]
        public decimal IDUsuarioCadastro { get; set; }

        [CampoTabela("DATAEMISSAO")]
        public DateTime DataEmissao { get; set; } = DateTime.Now;

        [CampoTabela("DATAENTREGA")]
        public DateTime? DataEntrega { get; set; }

        [CampoTabela("TIPOFRETE")]
        public decimal TipoFrete { get; set; }

        [CampoTabela("OBSERVACAO")]
        public string Observacao { get; set; }

        [CampoTabela("DATAALTERACAO")]
        public DateTime DataAlteracao { get; set; }

        [CampoTabela("DATACANCELAMENTO")]
        public DateTime? DataCancelamento { get; set; }

        [CampoTabela("TOTAL")]
        public decimal Total { get; set; }

        [CampoTabela("STATUS")]
        public decimal Status { get; set; } //0-Aberto, 1-Faturado, 2-Cancelado

        [CampoTabela("IDFLUXOCAIXA")]
        public decimal IDFluxoCaixa{get; set;}

        [CampoTabela("QUANTIDADEITENS")]
        public decimal QuantidadeItens { get; set; }

        [CampoTabela("MOTIVODECANCELAMENTO")]
        public string MotivoDeCancelamento { get; set; }

        [CampoTabela("IDCOMPRADOR")]
        public decimal IDComprador { get; set; } = -1;

        [CampoTabela("DATAFATURAMENTO")]
        public DateTime DataFaturamento { get; set; }

        [CampoTabela("PAGAMENTOSDESCRICAO")]
        public string PagamentosDescricao { get; set; }
        public PedidoCompra() { }
    }
}