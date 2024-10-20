using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.Financeiro
{
    public class ContaCobranca
    {
        [CampoTabela("IDCONTACOBRANCA")]
        public decimal IDContaCobranca { get; set; } = -1;

        [CampoTabela("IDCONTABANCARIA")]
        public decimal IDContaBancaria { get; set; }

        [CampoTabela("LEIAUTE")]
        public string Leiaute { get; set; }

        [CampoTabela("ESPECIEDOC")]
        public string EspecieDoc { get; set; }

        [CampoTabela("ACEITE")]
        public decimal Aceite { get; set; }

        [CampoTabela("CARTEIRA")]
        public string Carteira { get; set; }

        [CampoTabela("REGISTRO")]
        public decimal? Registro { get; set; }

        [CampoTabela("ESPECIE")]
        public string Especie { get; set; }

        [CampoTabela("CEDENTE")]
        public string Cedente { get; set; }

        [CampoTabela("NOSSONUMERO")]
        public decimal? NossoNumero { get; set; }

        [CampoTabela("ATIVO")]
        public decimal Ativo { get; set; } = 1;

        [CampoTabela("INSTRUCOES")]
        public string Instrucoes { get; set; }

        [CampoTabela("DIASPAGTO")]
        public decimal? DiasPagto { get; set; }

        [CampoTabela("TAXA")]
        public decimal? Taxa { get; set; }

        [CampoTabela("LOCALPAGTO")]
        public string LocalPagto { get; set; }

        [CampoTabela("IDFORMADEPAGAMENTO")]
        public decimal IDFormaDePagamento { get; set; }

        [CampoTabela("VALORMULTA")]
        public decimal ValorMulta { get; set; }

        [CampoTabela("PERCENTUALJUROS")]
        public decimal PercentualJuros { get; set; }

        /* Campo usado para gerar as duplicatas, não existe em banco */
        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        [CampoTabela("VARIACAOCARTEIRA")]
        public string VariacaoCarteira { get; set; }

        [CampoTabela("CNAB")]
        public decimal CNAB { get; set; } = 0;

        [CampoTabela("NUMEROREMESSA")]
        public decimal NumeroRemessa { get; set; } = 0;

        public ContaCobranca() { }
    }
}
