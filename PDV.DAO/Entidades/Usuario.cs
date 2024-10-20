using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class Usuario
    {
        [CampoTabela("IDUSUARIO")]
        [MaxLength(18)]
        public decimal IDUsuario { get; set; } = -1;

        [CampoTabela("NOME")]
        [MaxLength(150)]
        public string Nome { get; set; }

        [CampoTabela("LOGIN")]
        [MaxLength(50)]
        public string Login { get; set; }

        [CampoTabela("SENHA")]
        [MaxLength(150)]
        public string Senha { get; set; }

        [CampoTabela("ATIVO")]
        [MaxLength(1)]
        public decimal Ativo { get; set; } = 1;

        [CampoTabela("EMAIL")]
        [MaxLength(100)]
        public string Email { get; set; }

        [CampoTabela("IDPERFILACESSO")]
        [MaxLength(18)]
        public decimal IDPerfilAcesso { get; set; } = -1;

        [CampoTabela("PERFILACESSO")]
        [MaxLength(150)]
        public string PerfilAcesso { get; set; }

        [CampoTabela("ROOT")]
        [MaxLength(1)]
        public decimal Root { get; set; }

        [CampoTabela("IDUSUARIOSUPERVISOR")]
        [MaxLength(18)]
        public decimal IDUsuarioSupervisor { get; set; }

        [CampoTabela("PIN")]
        [MaxLength(150)]
        public string Pin { get; set; }

        [CampoTabela("FORMADESCONTO")]
        public int FormaDesconto { get; set; }
        [CampoTabela("TIPODESCONTO")]
        public int TipoDesconto { get; set; }

        [CampoTabela("ISVENDEDOR")]
        public int IsVendedor { get; set; }
        [CampoTabela("ISCOMPRADOR")]
        public int IsComprador { get; set; }

        [CampoTabela("DESCONTOMAXIMO")]
        public decimal DescontoMaximo { get; set; } = 0;
        public Usuario()
        {
        }
    }
}
