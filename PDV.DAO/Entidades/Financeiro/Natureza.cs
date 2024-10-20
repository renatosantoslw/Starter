using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.Financeiro
{
    public class Natureza
    {
        [CampoTabela("IDNATUREZA")]
        public decimal IDNatureza { get; set; } = -1;

        [CampoTabela("CONTA")]
        public string Conta { get; set; }

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        [CampoTabela("APLICACAO")]
        public string Aplicacao { get; set; }

        [CampoTabela("TIPO")]
        public decimal Tipo { get; set; }

        [CampoTabela("IDNATUREZASUPERIOR")]
        public decimal? IDNaturezaSuperior { get; set; }

        public Natureza() { }
    }
}