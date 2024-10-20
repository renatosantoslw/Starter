using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class IntegracaoFiscal
    {
        [CampoTabela("IDINTEGRACAOFISCAL")]
        public int IDIntegracaoFiscal { get; set; }

        [CampoTabela("IDCFOP")]
        public decimal IDCFOP { get; set; }

        [CampoTabela("IDTIPOOPERACAO")]
        public decimal IDTipoOperacao { get; set; }

        [CampoTabela("IDPORTARIA")]
        public decimal? IDPortaria { get; set; }

        [CampoTabela("IDCSTICMS")]
        public decimal IDCSTIcms { get; set; }

        [CampoTabela("IDCSTIPI")]
        public decimal IDCSTIpi { get; set; }

        [CampoTabela("IDCSTPIS")]
        public decimal IDCSTPis { get; set; }

        [CampoTabela("IDCSTCOFINS")]
        public decimal IDCSTCofins { get; set; }

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        [CampoTabela("SEQUENCIA")]
        public decimal Sequencia { get; set; } = 1;

        [CampoTabela("ICMS")]
        public decimal ICMS { get; set; }

        [CampoTabela("ICMS_IPI")]
        public decimal ICMS_IPI { get; set; }

        [CampoTabela("ICMS_ST")]
        public decimal ICMS_ST { get; set; }

        [CampoTabela("ICMS_RED")]
        public decimal ICMS_RED { get; set; }

        [CampoTabela("ICMS_REDST")]
        public decimal ICMS_REDST { get; set; }

        [CampoTabela("ICMS_DIFERENCIADO")]
        public decimal ICMS_DIFERENCIADO { get; set; }

        [CampoTabela("ICMS_CDIFERENCIADO")]
        public decimal ICMS_CDIFERENCIADO { get; set; }

        [CampoTabela("ICMS_ST_DIFERENCIADO")]
        public decimal ICMS_ST_DIFERENCIADO { get; set; }

        [CampoTabela("ICMS_ST_CDIFERENCIADO")]
        public decimal ICMS_ST_CDIFERENCIADO { get; set; }

        [CampoTabela("ICMS_DIF")]
        public decimal ICMS_DIF { get; set; }

        [CampoTabela("ESTOQUE")]
        public decimal Estoque { get; set; }

        [CampoTabela("FINANCEIRO")]
        public decimal Financeiro { get; set; }

        [CampoTabela("IPI")]
        public decimal IPI { get; set; }

        [CampoTabela("IDCFOPFORA")]
        public decimal? IDCFOPFORA { get; set; }

        [CampoTabela("IDCFOPDEVOLUCAO")]
        public decimal? IDCFOPDEVOLUCAO { get; set; }

        [CampoTabela("IDCFOPDEVOLUCAOFORA")]
        public decimal? IDCFOPDEVOLUCAOFORA { get; set; }

        public static readonly int IntegracaoNFCe = 1;

        public static readonly int IntegracaoNFe = 2;

        public IntegracaoFiscal()
        {

        }
    }
}

