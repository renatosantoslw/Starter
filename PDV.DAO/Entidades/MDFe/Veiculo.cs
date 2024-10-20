using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.MDFe
{
    public class Veiculo
    {
        [CampoTabela("IDVEICULO")]
        public decimal IDVeiculo { get; set; } = -1;

        [CampoTabela("PLACA")]
        public string Placa { get; set; }

        [CampoTabela("CERTIFICADOPROPRIEDADE")]
        public string CertificadoPropriedade { get; set; }

        [CampoTabela("MODELO")]
        public string Modelo { get; set; }

        [CampoTabela("RENAVAM")]
        public string Renavam { get; set; }

        [CampoTabela("TARAEMKG")]
        public decimal TaraEmKG { get; set; }

        [CampoTabela("CAPACIDADEEMKG")]
        public decimal CapacidadeEmKG { get; set; }

        [CampoTabela("CAPACIDADEEMM3")]
        public decimal CapacidadeEmM3 { get; set; }

        [CampoTabela("ANOFABRICACAO")]
        public decimal AnoFabricacao { get; set; }

        [CampoTabela("ANOMODELO")]
        public decimal AnoModelo { get; set; }

        [CampoTabela("REGISTROANTT")]
        public string RegistroANTT { get; set; }

        [CampoTabela("TIPOPROPRIEDADE")]
        public decimal TipoPropriedade { get; set; }

        [CampoTabela("TIPOVEICULO")]
        public decimal TipoVeiculo { get; set; }

        [CampoTabela("TIPORODADO")]
        public decimal TipoRodado { get; set; }

        [CampoTabela("TIPOCARROCERIA")]
        public decimal TipoCarroceria { get; set; }

        [CampoTabela("IDMARCA")]
        public decimal? IDMarca { get; set; }

        [CampoTabela("ATIVO")]
        public decimal Ativo { get; set; } = 1;

        [CampoTabela("VEICULOEMUSOMDFE")]
        public decimal VeiculoEmUsoMDFe { get; set; } = 0;

        [CampoTabela("IDUNIDADEFEDERATIVA")]
        public decimal IDUnidadefederativa { get; set; } = 0;

        public string Descricao { get { return $"{Placa} - {Modelo}"; } }

        public Veiculo() { }
    }
}