using PDV.DAO.Atributos;
using System.Net;

namespace PDV.DAO.Entidades
{
    public class Maquina
    {
        [CampoTabela("IDMAQUINA")]
        public decimal IDMaquina { get; set; }

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        [CampoTabela("ULTIMOLOGIN")]
        public string UltimoLogin { get; set; }

        public Maquina(string login)
        {
            UltimoLogin = login;
            Descricao = Dns.GetHostName();
        }

        public Maquina()
        {

        }
    }
}
