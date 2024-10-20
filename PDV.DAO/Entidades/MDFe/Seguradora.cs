using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.MDFe
{
    public class Seguradora
    {
        [CampoTabela("IDSEGURADORA")]
        public decimal IDSeguradora { get; set; } = -1;

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        [CampoTabela("CNPJ")]
        public string CNPJ { get; set; }

        [CampoTabela("ATIVO")]
        public decimal Ativo { get; set; } = 1;

        public string DescricaoFormatada { get { return $"{CNPJ} - {Descricao}"; } }

        public Seguradora() { }
    }
}
