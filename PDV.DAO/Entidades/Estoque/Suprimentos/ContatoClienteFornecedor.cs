using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades.Estoque.Suprimentos
{
    public class ContatoClienteFornecedor
    {
        [CampoTabela("IDCONTATOCLIENTEFORNECEDOR")]
        public decimal IDContatoClienteFornecedor { get; set; } = -1;

        [CampoTabela("IDFORNECEDOR")]
        public decimal? IDFornecedor { get; set; }

        [CampoTabela("IDCLIENTE")]
        public decimal? IDCliente { get; set; }

        [CampoTabela("NOME")]
        public string Nome { get; set; }

        [CampoTabela("CARGO")]
        public string Cargo { get; set; }

        [CampoTabela("EMAIL")]
        public string Email { get; set; }

        [CampoTabela("TELEFONE1")]
        public string Telefone1 { get; set; }

        [CampoTabela("TELEFONE2")]
        public string Telefone2 { get; set; }

        [CampoTabela("SEXO")]
        public decimal Sexo { get; set; }

        public ContatoClienteFornecedor() { }
    }
}
