namespace PDV.CONTROLLER.NFCE.Configuracao
{
    public class IConfigNFCe
    {
        public string CaminhoSolution = string.Empty;
        public ConfiguracaoNfce CONFIG_NFCe
        {
            get { return new ConfiguracaoNfce(CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW\\App_Data\\Schemas" : "\\App_Data\\Schemas")); }
        }
    }
}
