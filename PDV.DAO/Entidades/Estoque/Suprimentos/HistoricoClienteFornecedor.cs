using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades.Estoque.Suprimentos
{
    public class HistoricoClienteFornecedor
    {
        [CampoTabela("IDHISTORICOCLIENTEFORNECEDOR")]
        public decimal IDHistoricoClienteFornecedor { get; set; } = -1;

        [CampoTabela("IDFORNECEDOR")]
        public decimal? IDFornecedor { get; set; }

        [CampoTabela("IDCLIENTE")]
        public decimal? IDCliente { get; set; }

        [CampoTabela("DATAHISTORICO")]
        public DateTime DataHistorico { get; set; } = DateTime.Now;

        [CampoTabela("ASSUNTO")]
        public string Assunto { get; set; }

        [CampoTabela("OBSERVACAO")]
        public string Observacao { get; set; }

        public HistoricoClienteFornecedor() { }
    }
}