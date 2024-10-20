namespace IntegradorZeusPDV.MODEL.ClassesPDV
{
    public class Usuario
    {
        public decimal IDUsuario { get; set; } = -1;

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public decimal Ativo { get; set; } = 1;

        public string Email { get; set; }

        public decimal IDPerfilAcesso { get; set; } = -1;

        public string PerfilAcesso { get; set; }

        public decimal Root { get; set; }

        public decimal IDUsuarioSupervisor { get; set; }

        public string Pin { get; set; }

        public string ChaveERP { get; set; }

        public Usuario()
        {
        }
    }
}
