using NFe.Danfe.Fast.NFe;

namespace PDV.CONTROLLER.EVENTONFE.Classes
{
    public class RetornoEventoImpressao
    {
        public DanfeFrEvento Danfe { get; set; }
        public bool isVisualizar { get; set; }
        public string NomeImpressora { get; set; }
        public bool isCaixaDialogo { get; set; }

        public RetornoEventoImpressao() { }
    }
}
