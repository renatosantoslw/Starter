using Npgsql;
using PDV.DAO.Atributos;
using System;
using System.Collections.Generic;

namespace PDV.DAO.Entidades.PDV
{
    public class Venda
    {
        [CampoTabela("IDVENDA")]
        public decimal IDVenda { get; set; } = -1;

        [CampoTabela("QUANTIDADEITENS")]
        public decimal QuantidadeItens { get; set; }
        
        [CampoTabela("VALORTOTAL")]
        public decimal ValorTotal { get; set; }

        [CampoTabela("IDVENDEDOR")]
        public decimal? IDVendedor { get; set; }

        [CampoTabela("IDTIPODEOPERACAO")]
        public decimal IDTipoDeOperacao { get; set; }

        [CampoTabela("DINHEIRO")]
        public decimal Dinheiro { get; set; }

        [CampoTabela("TROCO")]
        public decimal Troco { get; set; }

        [CampoTabela("DATACADASTRO")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        [CampoTabela("IDUSUARIO")]
        public decimal IDUsuario { get; set; }

        [CampoTabela("IDCLIENTE")]
        public decimal? IDCliente { get; set; } = null;

        [CampoTabela("IDFLUXOCAIXA")]
        public decimal IDFluxoCaixa { get; set; }

        [CampoTabela("IDCOMANDA")]
        public decimal? IDComanda { get; set; }

        [CampoTabela("IDCOMANDAUTILIZADA")]
        public decimal? IDComandaUtilizada { get; set; }
        
        public int IDFormaPagamento { get; set; }

        [CampoTabela("OBSERVACAO")]
        public string Observacao { get; set; }

        [CampoTabela("STATUS")]
        public Int64 Status { get; set; }

        [CampoTabela("PAGAMENTOSDESCRICAO")]
        public string PagamentosDescricao { get; set; }

        [CampoTabela("IDRESPOSTAFISCAL")]
        public string IdRespostaFiscal { get; set; }



        [CampoTabela("MOTIVODECANCELAMENTO")]
        public string MotivoDeCancelamento { get; set; }

        [CampoTabela("DATAFATURAMENTO")]    
        public DateTime? DataFaturamento { get; set; }

        [CampoTabela("OBRA")]
        public string Obra { get; set; }

        [CampoTabela("VALORAVISTAPROPOSTO")]
        public decimal ValorAVistaProposto { get; set; }

        [CampoTabela("TIPODEVENDA")]
        public int TipoDeVenda { get; set; }

        public static readonly int PDV = 1;
        public static readonly int DAV = 2;


        public Venda()
        {
        }
    }
  
}
