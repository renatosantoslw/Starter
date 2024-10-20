using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.Financeiro
{
    public class HistoricoFinanceiro
    {
        [CampoTabela("IDHISTORICOFINANCEIRO")]
        public decimal IDHistoricoFinanceiro { get; set; } = -1;

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        [CampoTabela("TIPODEMOVIMENTO")]
        public int TipoDeMovimento { get; set; }


        public static readonly int Entrada = 0;
        public static readonly int Saida = 1;


        public HistoricoFinanceiro() { }
    }
}