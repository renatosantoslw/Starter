using System.Collections.Generic;

namespace PDV.DAO.Entidades.MDFe.Tipos
{
    public class TipoEmitente
    {
        public decimal IDTipoEmitente { get; set; }
        public string Descricao { get; set; }

        public static List<TipoEmitente> GetTipos()
        {
            List<TipoEmitente> Tipos = new List<TipoEmitente>();
            //Tipos.Add(new TipoEmitente { IDTipoEmitente = 1, Descricao = "Prestador de Serviço de Transporte" });
            Tipos.Add(new TipoEmitente { IDTipoEmitente = 2, Descricao = "Transportador de Carga Própria" });
            return Tipos;
        }
    }
}
