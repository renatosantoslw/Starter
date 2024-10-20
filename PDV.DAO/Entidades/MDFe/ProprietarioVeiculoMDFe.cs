using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.MDFe
{
    public class ProprietarioVeiculoMDFe
    {
        [CampoTabela("IDPROPRIETARIOVEICULOMDFE")]
        public decimal IDProprietarioVeiculoMDFe { get; set; } = -1;

        [CampoTabela("CNPJ")]
        public string CNPJ { get; set; }

        [CampoTabela("CPF")]
        public string CPF { get; set; }

        [CampoTabela("RNTRC")]
        public string RNTRC { get; set; }

        [CampoTabela("NOME")]
        public string Nome { get; set; }

        [CampoTabela("INSCRICAOESTADUAL")]
        public decimal? InscricaoEstadual { get; set; }

        [CampoTabela("IDUNIDADEFEDERATIVA")]
        public decimal IDUnidadeFederativa { get; set; }

        [CampoTabela("TIPOPROPRIETARIO")]
        public decimal TipoProprietario { get; set; }

        [CampoTabela("CODIGOAGENCIAPORTO")]
        public decimal? CodigoAgenciaPorto { get; set; }

        public string Descricao { get { return $"{(string.IsNullOrEmpty(CPF) ? CNPJ : CPF)} - {Nome}"; } }

        public ProprietarioVeiculoMDFe() { }
    }
}