namespace IntegradorZeusPDV.MODEL.ClassesPDV
{
    public class Emitente
    {
        public decimal IDEmitente { get; set; } = -1;
        public decimal? IDEndereco { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public decimal CRT { get; set; }
        public byte[] Certificado { get; set; }
        public string NomeCertificado { get; set; }
        public string CSC { get; set; }
        public string IDCSC { get; set; }
        public decimal? CNAE { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string InscricaoEstadual { get; set; }
        public byte[] Logomarca { get; set; }
        public string NomeLogomarca { get; set; }
        public string SenhaCertificado { get; set; }

        public Emitente() { }
    }
}