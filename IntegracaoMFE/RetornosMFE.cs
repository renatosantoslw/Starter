namespace IntegracaoMFE
{
    public class RetornosMFE
    {
        public RetornosMFE(int codigoRetorno, string descricaoRetorno)
        {
            CodigoRetorno = codigoRetorno;
            DescricaoRetorno = descricaoRetorno;
            MensagemRetornoCompleto = DescricaoRetorno;
        }
        public RetornosMFE(int codigoRetorno, string descricaoRetorno, int numeroSessao)
        {
            CodigoRetorno = codigoRetorno;
            DescricaoRetorno = descricaoRetorno;
            NumeroSessao = numeroSessao;
        }
        public RetornosMFE(int codigoRetorno, string descricaoRetorno, string mensagemRetornoCompleto) : this(codigoRetorno, descricaoRetorno)
        {
            MensagemRetornoCompleto = mensagemRetornoCompleto;
        }

        public RetornosMFE(int codigoRetorno, string descricaoRetorno, int numeroSessao, string mensagemRetornoCompleto) : this(codigoRetorno, descricaoRetorno, mensagemRetornoCompleto)
        {
            NumeroSessao = numeroSessao;
        }

        /// <summary>
        /// Código de Retorno do MFE
        /// </summary>
        public int CodigoRetorno { get; set; }

        /// <summary>
        /// Descrição do Retorno do MFE
        /// </summary>
        public string DescricaoRetorno { get; set; }
        
        /// <summary>
        /// Mensagem Completa de retorno da Integração
        /// </summary>
        public string MensagemRetornoCompleto { get; set; }
        
        /// <summary>
        /// Número da Sessão
        /// </summary>
        public int NumeroSessao { get; set; }

        /// <summary>
        /// MFE Autorizado
        /// </summary>
        public bool Autorizada() => CodigoRetorno == 6000;

        /// <summary>
        /// MFE Cancelado
        /// </summary>
        public bool Cancelada() => CodigoRetorno == 7000;

        /// <summary>
        /// MFE Em Operação
        /// </summary>
        public bool MfeEmOperacao() => CodigoRetorno == 8000;

        /// <summary>
        /// VFe Realizada com Sucesso
        /// </summary>
        /// <returns></returns>
        public bool VFeRealizada() => CodigoRetorno == 1;
    }
}
