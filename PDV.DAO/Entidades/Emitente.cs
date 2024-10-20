using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class Emitente
    {
        [CampoTabela("IDEMITENTE")]
        [MaxLength(18)]
        public decimal IDEmitente { get; set; } = -1;

        [CampoTabela("IDENDERECO")]
        [MaxLength(18)]
        public decimal IDEndereco { get; set; }

        [CampoTabela("CNPJ")]
        [MaxLength(14)]
        public string CNPJ { get; set; }

        [CampoTabela("RAZAOSOCIAL")]
        [MaxLength(150)]
        public string RazaoSocial { get; set; }

        [CampoTabela("NOMEFANTASIA")]
        [MaxLength(18)]
        public string NomeFantasia { get; set; }

        [CampoTabela("EMAIL")]
        [MaxLength(100)]
        public string Email { get; set; }

        [CampoTabela("CRT")]
        [MaxLength(1)]
        public decimal CRT { get; set; }

        [CampoTabela("CERTIFICADO")]
        public byte[] Certificado { get; set; }

        [CampoTabela("NOMECERTIFICADO")]
        [MaxLength(150)]
        public string NomeCertificado { get; set; }

        [CampoTabela("CSC")]
        [MaxLength(200)]
        public string CSC { get; set; }

        [CampoTabela("IDCSC")]
        [MaxLength(6)]
        public string IDCSC { get; set; }

        [CampoTabela("CNAE")]
        [MaxLength(7)]
        public decimal? CNAE { get; set; }

        [CampoTabela("INSCRICAOMUNICIPAL")]
        [MaxLength(14)]
        public string InscricaoMunicipal { get; set; }

        [CampoTabela("INSCRICAOESTADUAL")]
        [MaxLength(14)]
        public string InscricaoEstadual { get; set; }

        [CampoTabela("LOGOMARCA")]  
        public byte[] Logomarca { get; set; }

        [CampoTabela("NOMELOGOMARCA")]
        [MaxLength(150)]
        public string NomeLogomarca { get; set; }


        [CampoTabela("logopropraganda")]
        public byte[] logopropraganda { get; set; }

        [CampoTabela("nomelogopropraganda")]
        [MaxLength(150)]
        public string nomelogopropraganda { get; set; }


        [CampoTabela("SENHACERTIFICADO")]
        [MaxLength(250)]
        public string SenhaCertificado { get; set; }

        [CampoTabela("chaveerp")]
        public string chaveerp { get; set; }

        [CampoTabela("datalocal")]
        public string datalocal { get; set; }


        [CampoTabela("VersaoXML")]
        public string VersaoXML { get; set; }

        [CampoTabela("CodigoAtivacao")]
        public string CodigoAtivacao { get; set; }

        [CampoTabela("PastaInput")]
        public string PastaInput { get; set; }

        [CampoTabela("PastaOutPut")]
        public string PastaOutPut { get; set; }

        [CampoTabela("CNPJSoftwareHouse")]
        public string CNPJSoftwareHouse { get; set; }

        [CampoTabela("SignAC")]
        public string SignAC { get; set; }

        [CampoTabela("CRegTribISSQN")]
        public string CRegTribISSQN { get; set; }

        [CampoTabela("IndRatISSQN")]
        public string IndRatISSQN { get; set; }

        [CampoTabela("chaveAcessoValidador")]
        public string chaveAcessoValidador { get; set; }

        [CampoTabela("pastaxml")]
        public string PastaXml { get; set; }

        [CampoTabela("PROXIMONUMERONFE")]
        public decimal ProximoNumeroNFe { get; set; }

        [CampoTabela("PROXIMONUMERONFCE")]
        public decimal ProximoNumeroNFCe { get; set; }

        [CampoTabela("MODELOIMPRESSAODAV")]
        public decimal ModeloImpressaoDAV { get; set; }

        [CampoTabela("EMAILCONTADOR")]
        public string emailContador { get; set; }

        public Emitente()
        {
        }
    }
}
