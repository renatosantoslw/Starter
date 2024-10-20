using System.Collections.Generic;

namespace PDV.DAO.Entidades
{
    public class Email
    {
        public const string EMAIL_SMTP = "CONFIG_EMAIL_SMTP";
        public const string EMAIL_SMTP_PORT = "CONFIG_EMAIL_PORTA";
        public const string EMAIL_TLS = "CONFIG_EMAIL_TSL";
        public const string EMAIL_SSL = "CONFIG_EMAIL_SSL";
        public const string EMAIL_TIMEOUT = "CONFIG_EMAIL_TIMEOUT";
        public const string EMAIL_USUARIO = "CONFIG_EMAIL_EMAIL";
        public const string EMAIL_SENHA = "CONFIG_EMAIL_SENHA";
        public const string EMAIL_REMETENTE = "CONFIG_EMAIL_REMETENTE";
        public const string EMAIL_NOME_REMETENTE = "CONFIG_EMAIL_NOME_REMETENTE";

        public string TimeOut { get; set; }
        public string Porta { get; set; }
        public string ServidorEmail { get; set; }
        public string UsarSSL { get; set; }
        public string UsarTLS { get; set; }
        public string UsarAutenticacao { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public string EmailRemetente { get; set; }
        public string NomeRemetente { get; set; }
        public List<string> EmailDestinatario { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public string Titulo { get; set; }

        public List<byte[]> Anexos { get; set; } = null;

        public Email()
        {
        }
    }
}
