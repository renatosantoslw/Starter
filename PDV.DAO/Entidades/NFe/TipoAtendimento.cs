using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.NFe
{
    public class TipoAtendimento
    {
        [CampoTabela("IDTIPOATENDIMENTO")]
        public decimal IDTipoAtendimento { get; set; } = -1;

        [CampoTabela("CODIGO")]
        public string Codigo { get; set; }

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        public TipoAtendimento() { }
    }
}
