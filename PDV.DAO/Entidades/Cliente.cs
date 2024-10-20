using PDV.DAO.Atributos;
using PDV.DAO.DB.Utils;

namespace PDV.DAO.Entidades
{
    public class Cliente
    {
        [CampoTabela("IDCLIENTE")]
        [MaxLength(18)]
        public decimal IDCliente { get; set; } = Sequence.GetMaxID("CLIENTE", "IDCLIENTE");

        [CampoTabela("TIPODOCUMENTO")]
        [MaxLength(1)]
        public decimal TipoDocumento { get; set; }

        [CampoTabela("CNPJ")]
        [MaxLength(14)]
        public string CNPJ { get; set; }

        [CampoTabela("CPF")]
        [MaxLength(11)]
        public string CPF { get; set; }

        [CampoTabela("RAZAOSOCIAL")]
        [MaxLength(150)]
        public string RazaoSocial { get; set; }

        [CampoTabela("NOMEFANTASIA")]
        [MaxLength(150)]
        public string NomeFantasia { get; set; }

        [CampoTabela("NOME")]
        [MaxLength(150)]
        public string Nome { get; set; }

        [CampoTabela("INSCRICAOESTADUAL")]
        [MaxLength(14)]
        public string InscricaoEstadual { get; set; }

        [CampoTabela("INSCRICAOMUNICIPAL")]
        [MaxLength(14)]
        public string InscricaoMunicipal { get; set; }

        [CampoTabela("IDENDERECO")]
        [MaxLength(18)]
        public decimal? IDEndereco { get; set; } = -1;

        [CampoTabela("IDCONTATO")]
        [MaxLength(18)]
        public decimal? IDContato { get; set; } = -1;

        [CampoTabela("ATIVO")]
        [MaxLength(1)]
        public decimal Ativo { get; set; } = 1;

        [CampoTabela("CONSUMIDORFINAL")]
        [MaxLength(1)]
        public decimal ConsumidorFinal { get; set; } = 0;

        [CampoTabela("ESTRANGEIRO")]
        [MaxLength(1)]
        public decimal Estrangeiro { get; set; } = 0;

        [CampoTabela("DOCESTRANGEIRO")]
        [MaxLength(1)]
        public string DocEstrangeiro { get; set; }

        [CampoTabela("TIPOCONTRIBUINTE")]
        [MaxLength(1)]
        public decimal TipoContribuinte { get; set; } = 0;

        [CampoTabela("LIMITEDECREDITO")]
        public decimal LimiteDeCredito { get; set; }


        public string _CPF_CNPJ { get { return TipoDocumento == 0 ? CNPJ : CPF; } }
        public string _DESCRICAO { get { return TipoDocumento == 0 ? RazaoSocial : Nome; } }

        // Utilizado no PDV para setar o email do cliente
        public string Email { get; set; }

        public int IDVendedor { get; set; }

        public Cliente()
        {
        }
    }
}
