using System;

namespace PDV.DAO.Entidades.DownloadNFeEntrada
{
    public class DownloadNFe
    {
        public decimal IDDownloadNFe { get; set; }
        public decimal? IDManifestacaoDestinatario { get; set; }
        public byte[] Xml { get; set; }

        public decimal Cstat { get; set; }
        public string Motivo { get; set; }
        public decimal TpAmb { get; set; }
        public DateTime DhResp { get; set; }
        public decimal MaxNsu { get; set; }
        public decimal UltNSu { get; set; }

        public DownloadNFe() { }
    }
}
