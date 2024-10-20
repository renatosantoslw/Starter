namespace PDV.DAO.Custom.Configuracoes
{
    public class CFG_DanfeNFCe
    {
        public string EmissaoNormal { get; set; } = "1";
        public string EmissaoContingencia { get; set; } = "1";
        public decimal MargemEsquerda { get; set; } = 0;
        public decimal MargemDireita { get; set; } = 0;
        public string ImprimirDescontoItem { get; set; } = "1";
        public string ModoImpressao { get; set; } = "1";
        public string NomeImpressora { get; set; } = string.Empty;
        public string ExibirCaixaDialogo { get; set; } = "1";

        public CFG_DanfeNFCe()
        {

        }
    }
}
