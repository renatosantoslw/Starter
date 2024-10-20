using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class Transportadora
    {
        [CampoTabela("IDTRANSPORTADORA")]
        [MaxLength(18)]
        public decimal IDTransportadora { get; set; } = -1;

        [CampoTabela("RAZAOSOCIAL")]
        [MaxLength(150)]
        public string RazaoSocial { get; set; }

        [CampoTabela("CNPJ")]
        [MaxLength(14)]
        public string CNPJ { get; set; }

        [CampoTabela("CPF")]
        [MaxLength(11)]
        public string CPF { get; set; }

        [CampoTabela("NOME")]
        [MaxLength(150)]
        public string Nome { get; set; }

        [CampoTabela("INSCRICAOESTADUAL")]
        [MaxLength(14)]
        public decimal? InscricaoEstadual { get; set; }

        [CampoTabela("ISENTO")]
        [MaxLength(1)]
        public decimal Isento { get; set; }

        [CampoTabela("TIPODOCUMENTO")]
        [MaxLength(1)]
        public decimal TipoDocumento { get; set; }

        [CampoTabela("IDEndereco")]
        [MaxLength(18)]
        public decimal IDEndereco { get; set; } = -1;

        /* Campo Usado Somente em Tela */
        [CampoTabela("DESCRICAOTRANSPORTADORA")]
        public string DescricaoTransportadora { get; set; }


        public Transportadora() { }
    }
}