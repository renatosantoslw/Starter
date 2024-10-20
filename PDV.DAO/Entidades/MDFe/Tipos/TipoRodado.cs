using System.Collections.Generic;

namespace PDV.DAO.Entidades.MDFe.Tipos
{
    public class TipoRodado
    {
        public decimal IDTipoRodado { get; set; }
        public string Descricao { get; set; }

        public TipoRodado() { }

        public static List<TipoRodado> GetTipos()
        {
            List<TipoRodado> Tipos = new List<TipoRodado>();
            Tipos.Add(new TipoRodado { IDTipoRodado = 1, Descricao = "Truck" });
            Tipos.Add(new TipoRodado { IDTipoRodado = 2, Descricao = "Toco" });
            Tipos.Add(new TipoRodado { IDTipoRodado = 3, Descricao = "Cavalo Mecânico" });
            Tipos.Add(new TipoRodado { IDTipoRodado = 4, Descricao = "VAN" });
            Tipos.Add(new TipoRodado { IDTipoRodado = 5, Descricao = "Utilitário" });
            Tipos.Add(new TipoRodado { IDTipoRodado = 6, Descricao = "Outros" });
            return Tipos;
        }
    }
}
