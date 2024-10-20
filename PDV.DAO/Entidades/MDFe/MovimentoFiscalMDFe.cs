using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades.MDFe
{
    public class MovimentoFiscalMDFe
    {
        [CampoTabela("IDMOVIMENTOFISCALMDFE")]
        public decimal IDMovimentoFiscalMDFe { get; set; }

        [CampoTabela("IDMDFE")]
        public decimal IDMDFe { get; set; }

        [CampoTabela("SERIE")]
        public decimal Serie { get; set; }

        [CampoTabela("XMLENVIO")]
        public byte[] XmlEnvio { get; set; }

        [CampoTabela("XMLRETORNO")]
        public byte[] XmlRetorno { get; set; }

        [CampoTabela("EMITIDA")]
        public decimal Emitida { get; set; }

        [CampoTabela("CANCELADA")]
        public decimal Cancelada { get; set; }

        [CampoTabela("EMISSAO")]
        public DateTime Emissao { get; set; }

        [CampoTabela("CHAVE")]
        public string Chave { get; set; }

        [CampoTabela("CSTAT")]
        public decimal CSTAT { get; set; }

        [CampoTabela("MOTIVO")]
        public string Motivo { get; set; }

        [CampoTabela("RECEBIMENTO")]
        public DateTime Recebimento { get; set; }

        [CampoTabela("AMBIENTE")]
        public decimal Ambiente { get; set; }

        [CampoTabela("NUMERO")]
        public decimal Numero { get; set; }

        [CampoTabela("TIPODOCUMENTO")]
        public decimal TipoDocumento { get; set; }

        [CampoTabela("ENCERRADA")]
        public decimal Encerrada { get; set; }

        public MovimentoFiscalMDFe() { }
    }
}
