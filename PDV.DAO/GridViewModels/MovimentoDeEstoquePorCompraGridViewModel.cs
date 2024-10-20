using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.GridViewModels
{
    public class MovimentoDeEstoquePorCompraGridViewModel
    {
        [CampoTabela(nameof(IDPedidoCompra))]
        public int IDPedidoCompra { get; set; }

        [CampoTabela(nameof(EAN))]
        public string EAN { get; set; }

        [CampoTabela(nameof(Produto))]
        public string Produto { get; set; }

        [CampoTabela(nameof(DataFaturamento))]
        public DateTime DataFaturamento { get; set; }

        [CampoTabela(nameof(Operacao))]
        public string Operacao { get; set; }

        [CampoTabela(nameof(Grupo))]
        public string Grupo { get; set; }

        [CampoTabela(nameof(Quantidade))]
        public int Quantidade { get; set; }
    }
}
