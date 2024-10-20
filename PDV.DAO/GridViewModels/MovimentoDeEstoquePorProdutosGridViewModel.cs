using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.GridViewModels
{
    public class MovimentoDeEstoquePorProdutoGridViewModel
    {
        [CampoTabela(nameof(IDProduto))]
        public decimal IDProduto { get; set; }

        [CampoTabela(nameof(CDeBarras))]
        public string CDeBarras { get; set; }

        [CampoTabela(nameof(Produto))]
        public string Produto { get; set; }

        [CampoTabela(nameof(ValorCusto))]
        public decimal ValorCusto { get; set; }

        [CampoTabela(nameof(ValorVenda))]
        public decimal ValorVenda { get; set; }

        [CampoTabela(nameof(Grupo))]
        public string Grupo { get; set; }

        [CampoTabela(nameof(Entrada))]
        public decimal Entrada { get; set; }

        [CampoTabela(nameof(Saida))]
        public decimal Saida { get; set; }

        [CampoTabela(nameof(Total))]
        public decimal Total { get; set; }
    }
}
