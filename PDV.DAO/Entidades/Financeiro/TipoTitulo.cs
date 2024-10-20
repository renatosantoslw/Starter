using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.Financeiro
{
    public class CentroCusto
    {
        [CampoTabela("IDCENTROCUSTO")]
        public decimal IDCentroCusto { get; set; } = -1;

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        [CampoTabela("SIGLA")]
        public string Sigla { get; set; }

        [CampoTabela("TIPODEMOVIMENTO")]
        public int TipoDeMovimento { get; set; }



        public static readonly int Entrada = 0;
        public static readonly int Saida = 1;

        public CentroCusto() { }
    }
}
