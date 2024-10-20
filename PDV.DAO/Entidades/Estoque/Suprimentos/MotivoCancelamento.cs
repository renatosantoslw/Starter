using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.Estoque.Suprimentos
{
    public class MotivoCancelamento
    {
        [CampoTabela("IDMOTIVOCANCELAMENTO")]
        public decimal IDMotivoCancelamento { get; set; } = -1;

        [CampoTabela("NOME")]
        public string Nome { get; set; }

        [CampoTabela("TIPO")]
        public decimal Tipo { get; set; } //0 - Compra, 1 - Venda

        [CampoTabela("TIPOCANCELAMENTO")]
        public string TipoCancelamento { get; set; }
        
        public MotivoCancelamento() { }
    }
}
