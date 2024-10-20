using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.NFe
{
    public class VolumeNFe
    {
        [CampoTabela("IDVOLUMENFE")]
        public decimal IDVolumeNFe { get; set; } = -1;

        [CampoTabela("VOLUME")]
        public string Volume { get; set; }

        [CampoTabela("NUMERO")]
        public string Numero { get; set; }

        [CampoTabela("PESOLIQUIDO")]
        public decimal PesoLiquido { get; set; }

        [CampoTabela("PESOBRUTO")]
        public decimal PesoBruto { get; set; }

        [CampoTabela("MARCA")]
        public string Marca { get; set; }

        [CampoTabela("ESPECIE")]
        public string Especie { get; set; }        

        [CampoTabela("IDNFE")]
        public decimal IDNFe { get; set; }

        public VolumeNFe() { }
    }
}
