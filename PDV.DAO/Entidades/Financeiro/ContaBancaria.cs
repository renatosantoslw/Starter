using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.Financeiro
{
    public class ContaBancaria
    {
        [CampoTabela("IDCONTABANCARIA")]
        public decimal IDContaBancaria { get; set; } = -1;

        [CampoTabela("IDBANCO")]
        public decimal? IDBanco { get; set; }

        [CampoTabela("NOME")]
        public string Nome { get; set; }

        [CampoTabela("AGENCIA")]
        public string Agencia { get; set; }

        [CampoTabela("DIGITOAGENCIA")]
        public string DigitoAgencia { get; set; }        

        [CampoTabela("CONTA")]
        public string Conta { get; set; }

        [CampoTabela("DIGITO")]
        public string Digito { get; set; }

        [CampoTabela("ATIVO")]
        public decimal Ativo { get; set; } = 1;

        [CampoTabela("CAIXA")]
        public decimal Caixa { get; set; }

        [CampoTabela("OPERACAO")]
        public string Operacao { get; set; }

        public ContaBancaria() { }
    }
}