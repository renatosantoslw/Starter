using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades.Financeiro
{
    public class ContaRecCobranca
    {
        [CampoTabela("IDCONTARECCOBRANCA")]
        public decimal IDContasRecobranca { get; set; }

        [CampoTabela("IDCONTARECEBER")]
        public decimal IDContaReceber { get; set; }

        [CampoTabela("EMISSAO")]
        public DateTime Emissao { get; set; }

        [CampoTabela("VENCIMENTO")]
        public DateTime Vencimento { get; set; }

        [CampoTabela("VALOR")]
        public decimal Valor { get; set; }

        [CampoTabela("NOSSONUMERO")]
        public string NossoNumero { get; set; }

        [CampoTabela("STATUS")]
        public decimal Status { get; set; }

        [CampoTabela("IDCONTACOBRANCA")]
        public decimal IDContaCobranca { get; set; }

        [CampoTabela("NUMERODOCUMENTO")]
        public string NumeroDocumento { get; set; }

        [CampoTabela("NUMEROCONTROLEPARTICIPANTE")]
        public string NumeroControleParticipante { get; set; }

        [CampoTabela("CANCELAMENTO")]
        public DateTime? Cancelamento { get; set; }

        public ContaRecCobranca() { }
    }
}