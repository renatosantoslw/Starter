using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoMFE
{
    public class RetornosVFPE
    {
        public RetornosVFPE(int idPagamento, bool idLocal)
        {
            IdPagamento = idPagamento;
            IdLocal = idLocal;
        }

        /// <summary>
        /// Código do Pagamento
        /// </summary>
        public int IdPagamento { get; set; }

        /// <summary>
        /// Informa se o IdPagamento é Local ou Oficial
        /// <para>False: Oficial</para>
        /// <para>True: Local</para>
        /// </summary>
        public bool IdLocal { get; set; }

        /// <summary>
        /// Enviado os Dados de Cartão
        /// <para>False: Não Enviado</para>
        /// <para>True: Enviado</para>
        /// </summary>
        public bool MfeEnviadoDadosCartao { get; set; }


        /// <summary>
        /// Código da Resposta Fiscal
        /// </summary>
        public long IdRespostaFiscal { get; set; }

        /// <summary>
        /// Número da Autorização do Cartão
        /// </summary>
        public string Autorizacao { get; set; }

        /// <summary>
        /// Sequencial de 6 Números iniciais do cartão
        /// </summary>
        public string BinCartao { get; set; }

        /// <summary>
        /// Nome do Titular do cartão
        /// </summary>
        public string DonoCartao { get; set; }

        /// <summary>
        /// Data de Validade do cartão
        /// </summary>
        public string DataExpiracao { get; set; }

        /// <summary>
        /// Adquirente que realizou a aprovação
        /// </summary>
        public string Adquirente { get; set; }

        /// <summary>
        /// Tipo da Bandeira do cartão
        /// </summary>
        public string  Bandeira { get; set; }

        /// <summary>
        /// Quantidade de Parcelas
        /// </summary>
        public int QtdParcelas { get; set; }

        /// <summary>
        /// Últimos 4 dígitos do cartão
        /// </summary>
        public string UltimosQuatroDigitos { get; set; }

        /// <summary>
        /// Número Sequencial Único do pagamento
        /// </summary>
        public string NSU { get; set; }

        /// <summary>
        /// Valor do Pagamento
        /// </summary>
        public decimal ValorCartao { get; set; }


    }
}
