using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades
{
    public class MovimentoFiscal
    {
        [CampoTabela("IDMOVIMENTOFISCAL")]
        [MaxLength(18)]
        public decimal IDMovimentoFiscal { get; set; }

        [CampoTabela("SERIE")]
        [MaxLength(18)]
        public decimal Serie { get; set; }

        [CampoTabela("XMLENVIO")]
        public byte[] XMLEnvio { get; set; }

        [CampoTabela("XMLCANCELAMENTO")]
        public byte[] XmlCancelamento { get; set; }

        [CampoTabela("XMLRETORNO")]
        public byte[] XMLRetorno { get; set; }

        [CampoTabela("EMITIDA")]
        [MaxLength(1)]
        public decimal Emitida { get; set; }

        [CampoTabela("CANCELADA")]
        [MaxLength(1)]
        public decimal Cancelada { get; set; }

        [CampoTabela("DATAEMISSAO")]
        public DateTime DataEmissao { get; set; }

        [CampoTabela("IDVENDA")]
        [MaxLength(18)]
        public decimal? IDVenda { get; set; }

        [CampoTabela("CHAVE")]
        [MaxLength(150)]
        public string Chave { get; set; }

        [CampoTabela("CSTAT")]
        [MaxLength(10)]
        public decimal? cStat { get; set; }

        [CampoTabela("XMOTIVO")]
        [MaxLength(500)]
        public string xMotivo { get; set; }

        [CampoTabela("DHRECBTO")]
        public DateTime? DataRecebimento { get; set; }

        [CampoTabela("CONTINGENCIA")]
        [MaxLength(18)]
        public decimal Contingencia { get; set; }

        [CampoTabela("NUMERO")]
        [MaxLength(18)]
        public decimal Numero { get; set; }

        [CampoTabela("TIPODOCUMENTO")]
        [MaxLength(2)]
        public decimal TipoDocumento { get; set; }

        [CampoTabela("AMBIENTE")]
        [MaxLength(1)]
        public decimal Ambiente { get; set; }

        [CampoTabela("IDNFE")]
        public decimal? IDNFe { get; set; }

        [CampoTabela("IDNFE")]
        public String Protocolo { get; set; }

        public MovimentoFiscal()
        {

        }

    }
}
