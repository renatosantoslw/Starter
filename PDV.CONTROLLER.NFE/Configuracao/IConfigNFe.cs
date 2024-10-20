namespace PDV.CONTROLLER.NFE.Configuracao
{
    public class IConfigNFe
    {
        public string CaminhoSolution = string.Empty;
        public ConfiguracaoNFe CONFIG_NFe
        {
            get { return new ConfiguracaoNFe(CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW\\App_Data\\Schemas" : "\\App_Data\\Schemas")); }
        }

    }
}
