using System.Collections.Generic;

namespace PDV.DAO.Entidades.MDFe.Tipos
{
    public class TipoTransportador
    {
        public decimal IDTransportador { get; set; }
        public string Descricao { get; set; }

        public TipoTransportador() { }

        public static List<TipoTransportador> GetTipos()
        {
            List<TipoTransportador> Tipos = new List<TipoTransportador>();
            Tipos.Add(new TipoTransportador { IDTransportador = 1, Descricao = "ETC" });
            Tipos.Add(new TipoTransportador { IDTransportador = 2, Descricao = "TAC" });
            Tipos.Add(new TipoTransportador { IDTransportador = 3, Descricao = "CTC" });
            return Tipos;
        }
    }
}
