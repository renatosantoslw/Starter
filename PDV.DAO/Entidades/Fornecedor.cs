using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class Fornecedor
    {
        [CampoTabela("IDFORNECEDOR")]
        [MaxLength(18)]
        public decimal IDFornecedor { get; set; } = -1;

        [CampoTabela("RAZAOSOCIAL")]
        [MaxLength(150)]
        public string RazaoSocial { get; set; }

        [CampoTabela("CNPJ")]
        [MaxLength(14)]
        public string CNPJ { get; set; }

        [CampoTabela("INSCRICAOESTADUAL")]
        public decimal? InscricaoEstadual { get; set; }

        [CampoTabela("ISENTO")]
        public decimal Isento { get; set; }

        [CampoTabela("IDENDERECO")]
        public decimal IDEndereco { get; set; }

        [CampoTabela("EMAIL")]
        public string Email { get; set; }


        public string Descricao { get; set; }
        public Fornecedor() { }
    }
}