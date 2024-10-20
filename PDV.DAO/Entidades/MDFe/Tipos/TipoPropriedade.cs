using System.Collections.Generic;

namespace PDV.DAO.Entidades.MDFe.Tipos
{
    public class TipoPropriedade
    {
        public decimal IDTipoPropriedade { get; set; }
        public string Descricao { get; set; }

        public TipoPropriedade() { }

        public static List<TipoPropriedade> GetTipos()
        {
            List<TipoPropriedade> Tipos = new List<TipoPropriedade>();
            Tipos.Add(new TipoPropriedade { IDTipoPropriedade = 0, Descricao = "TAC - Agregado" });
            Tipos.Add(new TipoPropriedade { IDTipoPropriedade = 1, Descricao = "TAC - Independente" });
            Tipos.Add(new TipoPropriedade { IDTipoPropriedade = 2, Descricao = "Outros" });
            return Tipos;
        }
    }
}
