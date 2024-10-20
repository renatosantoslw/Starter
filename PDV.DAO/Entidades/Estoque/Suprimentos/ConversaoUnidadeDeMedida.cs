using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.Estoque.Suprimentos
{
    public class ConversaoUnidadeDeMedida
    {

        [CampoTabela("IDCONVERSAOUNIDADEDEMEDIDA")]
        public int IDConversaoUnidadeDeMedida { get; set; } = -1;

        [CampoTabela("IDPRODUTO")]
        public int? IDProduto { get; set; } = null;

        [CampoTabela("IDUNIDADEDEMEDIDAENTRADA")]
        public int IDUnidadeDeMedidaEntrada { get; set; } = -1;

        [CampoTabela("IDUNIDADEDEMEDIDASAIDA")]
        public int IDUnidadeDeMedidaSaida { get; set; } = -1;

        [CampoTabela("FATOR")]
        public decimal Fator { get; set; } = 1;

        [CampoTabela("UNENTRADA")]
        public string UNENTRADA { get; set; }

        [CampoTabela("UNSAIDA")]
        public string UNSAIDA { get; set; }

        [CampoTabela("CALCULO")]
        public string CALCULO { get; set; }

        [CampoTabela("IDFORNECEDOR")]
        public int IDFORNECEDOR { get; set; }

        [CampoTabela("CODIGOPRODUTOFORNECEDOR")]
        public string CODIGOPRODUTOFORNECEDOR { get; set; }



        public string Descricao { get { return $"Entrada: {UNENTRADA},Calculo:{CALCULO} - Qtd: {Fator} Saida: {UNSAIDA} "; } }

        public ConversaoUnidadeDeMedida() { }
    }
}
