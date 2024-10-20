using System;

namespace IntegradorZeusPDV.MODEL.ClassesPDV
{
    public class MovimentoFiscal
    {
        public decimal IDMovimentoFiscal { get; set; }

        public decimal Serie { get; set; }

        public byte[] XMLEnvio { get; set; }

        public byte[] XMLRetorno { get; set; }

        public decimal Emitida { get; set; }

        public decimal Cancelada { get; set; }

        public DateTime DataEmissao { get; set; }

        public decimal? IDVenda { get; set; }

        public string Chave { get; set; }

        public decimal? cStat { get; set; }

        public string xMotivo { get; set; }

        public DateTime? DataRecebimento { get; set; }

        public decimal Contingencia { get; set; }

        public decimal Numero { get; set; }

        public decimal TipoDocumento { get; set; }

        public decimal Ambiente { get; set; }

        public decimal? IDNFe { get; set; }

        public MovimentoFiscal()
        {

        }
    }
}
