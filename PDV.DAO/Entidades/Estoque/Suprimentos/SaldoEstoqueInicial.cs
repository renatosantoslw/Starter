using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades.Estoque.Suprimentos
{
    public class SaldoEstoqueInicial
    {
        [CampoTabela("IDSALDOESTOQUEINICIAL")]
        public decimal IDSaldoEstoqueInicial { get; set; } = -1;

        [CampoTabela("IDALMOXARIFADO")]
        public decimal IDAlmoxarifado { get; set; }

        [CampoTabela("IDPRODUTO")]
        public decimal IDProduto { get; set; }

        [CampoTabela("DATACADASTRO")]
        public DateTime DataCadastro { get; set; }

        [CampoTabela("QUANTIDADE")]
        public decimal Quantidade { get; set; }

        [CampoTabela("VALOR")]
        public decimal Valor { get; set; }

        public SaldoEstoqueInicial() { }
    }
}
