using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class TipoDeOperacao
    {
        [CampoTabela("IDTIPODEOPERACAO")]
        public decimal IDTipoDeOperacao { get; set; }

        [CampoTabela("IDOPERACAOFISCAL")]
        public decimal IDOperacaoFiscal { get; set; }

        [CampoTabela("IDFINALIDADE")]
        public decimal IDFinalidade { get; set; } = -1;

        [CampoTabela("IDTIPOTATENDIMENTO")]
        public decimal IDTipoAtendimento { get; set; } = -1;

        [CampoTabela("IDTRANSPORTADORA")]
        public decimal IDTransportadora { get; set; }

        [CampoTabela("TIPODEFRETE")]
        public int TipoDeFrete { get; set; } = -1;

        [CampoTabela("MODELODOCUMENTO")]
        public int ModeloDocumento { get; set; }

        [CampoTabela("NOME")]
        public string Nome { get; set; }

        [CampoTabela("CONTROLARESTOQUE")]
        public bool ControlarEstoque { get; set; }

        [CampoTabela("PERMITEESTOQUENEGATIVO")]
        public bool PermiteEstoqueNegativo { get; set; }

        [CampoTabela("LIMITECREDITO")]
        public bool LimiteCredito { get; set; }

        [CampoTabela("INFORMACOESCOMPLEMENTARES")]
        public string InformacoesComplementares { get; set; }

        [CampoTabela("SERIE")]
        public int Serie { get; set; }

        [CampoTabela("GERARFINANCEIRO")]
        public bool GerarFinanceiro { get; set; }

        [CampoTabela("IDTIPOTITULO")]
        public decimal IdCentroCusto { get; set; }

        [CampoTabela("IDHISTORICOFINANCEIRO")]
        public decimal IDHistoricoFinanceiro { get; set; }

        [CampoTabela("IDCONTABANCARIA")]
        public decimal IDContaBancaria { get; set; }

        [CampoTabela("TIPODEMOVIMENTO")]
        public decimal TipoDeMovimento { get; set; }


        public static readonly int Entrada = 0;
        public static readonly int Saida = 1;


        public TipoDeOperacao()
        {

        }
    }
}
