using NFe.Classes.Protocolo;
using NFe.Danfe.Fast.NFe;

namespace PDV.CONTROLLER.NFE.Util
{
    public class RetornoTransmissaoNFe
    {
        public decimal IDMovimentoFiscal { get; set; }
        public decimal IDVenda { get; set; }
        public NFe.Classes.NFe NFe { get; set; }
        public protNFe Protocolo { get; set; }

        public bool isAutorizada { get; set; }

        public bool isSchemaValido { get; set; }
        public string MotivoErro { get; set; }

        public DanfeFrNfe danfe { get; set; }
        public bool isVisualizar { get; set; }
        public bool isCaixaDialogo { get; set; }
        public string NomeImpressora { get; set; }

        public RetornoTransmissaoNFe()
        {

        }
    }
}
