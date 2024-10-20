using MDFe.Classes.Retorno;
using MDFe.Damdfe.Fast;

namespace PDV.CONTROLLER.MDFE.Util
{
    public class RetornoTransmissaoMDFe
    {
        public decimal IDMovimentoFiscalMDFe { get; set; }
        public decimal IDMDFe { get; set; }
        public MDFeProcMDFe MDFeComProtocolo { get; set; }

        public bool isAutorizada { get; set; }

        public bool isSchemaValido { get; set; }
        public string Motivo { get; set; }

        public DamdfeFrMDFe Danfe { get; set; }
        public bool isCaixaDialogo { get; set; }
        public string NomeImpressora { get; set; }

        public RetornoTransmissaoMDFe()
        {
        }
    }
}