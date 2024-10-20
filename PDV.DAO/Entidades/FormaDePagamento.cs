using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class FormaDePagamento
    {
        [CampoTabela("IDFORMADEPAGAMENTO")]
        [MaxLength(18)]
        public decimal IDFormaDePagamento { get; set; } = -1;

        [CampoTabela("CODIGO")]
        [MaxLength(2)]
        public decimal Codigo { get; set; } = -1;

        [CampoTabela("DESCRICAO")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        [CampoTabela("IDBANDEIRACARTAO")]
        [MaxLength(18)]
        public decimal? IDBandeiraCartao { get; set; }

        [CampoTabela("CARTAOBANDEIRA")]
        [MaxLength(250)]
        public string CartaoBandeira { get; set; }

        [CampoTabela("FORMADEPAGAMENTOBANDEIRA")]
        [MaxLength(250)]
        public string FormaDePagamentoBandeira { get; set; }

        [CampoTabela("ATIVO")]
        public decimal Ativo { get; set; } = 1;

        [CampoTabela("TEF")]
        public int TEF { get; set; }

        [CampoTabela("PDV")]
        public int PDV { get; set; }

        [CampoTabela("FISCAL")]
        public int? FISCAL { get; set; }

        [CampoTabela("IDENTIFICACAO")]
        public string Identificacao { get; set; }

        [CampoTabela("Transacao")]
        public int Transacao { get; set; }

        [CampoTabela("Usa_Calendario_Comercial")]
        public string Usa_Calendario_Comercial { get; set; }

        [CampoTabela("Qtd_Parcelas")]
        public int Qtd_Parcelas { get; set; } = 1;

        [CampoTabela("Dias_Intervalo")]
        public int Dias_Intervalo { get; set; }

        [CampoTabela("Fator_Dup_Com_Entrada")]
        public decimal Fator_Dup_Com_Entrada { get; set; }

        [CampoTabela("Fator_Dup_Sem_Entrada")]
        public decimal Fator_Dup_Sem_Entrada { get; set; }

        [CampoTabela("Fator_Cheq_Com_Entrada")]
        public decimal Fator_Cheq_Com_Entrada { get; set; }

        [CampoTabela("Fator_Cheq_Sem_Entrada")]
        public decimal Fator_Cheq_Sem_Entrada { get; set; }

        [CampoTabela("Periodicidade")]
        public string Periodicidade { get; set; }


        public string IdentificacaoDescricao
        {
            get { return $"Descrição: {FormaDePagamentoBandeira} - Identificação: {(string.IsNullOrEmpty(Identificacao) ? "<Não Informado>" : Identificacao)}"; }
        }

        public string IdentificacaoDescricaoForma
        {
            get { return $"{Descricao}{(string.IsNullOrEmpty(Identificacao) ? string.Empty : " - " + Identificacao)}"; }
        }

        public string IdentificacaoDescricaoFormaBandeira
        {
            get { return $"{FormaDePagamentoBandeira}{(string.IsNullOrEmpty(Identificacao) ? string.Empty : " - " + Identificacao)}"; }
        }

        public bool IsDinheiro { get => Codigo == 1; }

        public FormaDePagamento()
        {
        }

        public FormaDePagamento(decimal CODIGO, string DESCRICAO)
        {
            Codigo = CODIGO;
            Descricao = DESCRICAO;
        }

        public static readonly int CodigoDinheiro = 1;

        public static readonly int AVista = 1;
        public static readonly int APrazo = 2;
    }
}
