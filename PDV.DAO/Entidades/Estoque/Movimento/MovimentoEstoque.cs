using System;

namespace PDV.DAO.Entidades.Estoque.Movimento
{
    public class MovimentoEstoque
    {
        public decimal IDMovimentoEstoque { get; set; }
        public decimal IDProduto { get; set; }
        public decimal? IDItemNFeEntrada { get; set; }
        public decimal? IDItemVenda { get; set; }
        public decimal ? IDItemPedidoCompra { get; set; }
        public decimal? IDProdutoNFe { get; set; }
        public decimal? IDItemInventario { get; set; }
        public decimal? IDAlmoxarifado { get; set; }
        public decimal? IDItemTransferenciaEstoque { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataMovimento { get; set; }
        public decimal SaldoAtual { get; set; } = 0;
        public decimal Tipo { get; set; } // 0 Entrada, 1 Saida
        public string Descricao { get; set; }

        public static readonly int Entrada = 0;
        public static readonly int Saida = 1;

        public MovimentoEstoque() { }
    }
}