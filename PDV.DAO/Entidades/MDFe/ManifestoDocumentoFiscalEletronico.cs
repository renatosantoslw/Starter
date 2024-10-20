using System;

namespace PDV.DAO.Entidades.MDFe
{
    public class ManifestoDocumentoFiscalEletronico
    {
        public decimal IDMDFe { get; set; } = -1;
        public decimal TipoAmbiente { get; set; }
        public decimal TipoEmitente { get; set; } = 2;
        public decimal TipoTransportador { get; set; }
        public decimal Modelo { get; set; }
        public decimal Serie { get; set; }
        public decimal NMDF { get; set; }
        public decimal CMDF { get; set; }
        public decimal ModalidadeTransporte { get; set; }
        public DateTime Emissao { get; set; } = DateTime.Now;
        public decimal TipoEmissao { get; set; }
        public decimal IDEmitente { get; set; }
        public string InformacoesAdicionais { get; set; }
        public string InformacoesComplementares { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public decimal CodigoUNPesoCarga { get; set; } = 1;

        public decimal IDUnidadeFederativaDescarregamento { get; set; }

        public decimal PesoBrutoTotal { get; set; }

        public ManifestoDocumentoFiscalEletronico() { }
    }
}
