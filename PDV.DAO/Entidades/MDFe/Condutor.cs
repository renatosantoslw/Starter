using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.MDFe
{
    public class Condutor
    {
        [CampoTabela("IDCONDUTOR")]
        public decimal IDCondutor { get; set; } = -1;

        [CampoTabela("CPF")]
        public string CPF { get; set; }

        [CampoTabela("NOME")]
        public string Nome { get; set; }

        [CampoTabela("ATIVO")]
        public decimal Ativo { get; set; } = 1;

        [CampoTabela("IDUNIDADEFEDERATIVA")]
        public decimal IDUnidadeFederativa { get; set; }

        public string Descricao { get { return $"{CPF} - {Nome}"; } }

        public Condutor() { }
    }
}