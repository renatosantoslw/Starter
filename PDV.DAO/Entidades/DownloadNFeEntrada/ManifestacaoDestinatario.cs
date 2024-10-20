namespace PDV.DAO.Entidades.DownloadNFeEntrada
{
    public class ManifestacaoDestinatario
    {
        public decimal IDManifestacaoDestinatario { get; set; } = -1;
        public string ChaveNFe { get; set; }
        public decimal TipoAmbiente { get; set; }
        public decimal Orgao { get; set; }
        public decimal Cstat { get; set; }
        public string Motivo { get; set; }
        public decimal TipoManifestacao { get; set; }
        public decimal NumeroEvento { get; set; }

        public ManifestacaoDestinatario() { }
    }
}
