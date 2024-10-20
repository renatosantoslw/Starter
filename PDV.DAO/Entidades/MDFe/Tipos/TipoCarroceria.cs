using System.Collections.Generic;

namespace PDV.DAO.Entidades.MDFe.Tipos
{
    public class TipoCarroceria
    {
        public decimal IDTipoCarroceria { get; set; }
        public string Descricao { get; set; }

        public static List<TipoCarroceria> GetTipos()
        {
            List<TipoCarroceria> Tipos = new List<TipoCarroceria>();
            Tipos.Add(new TipoCarroceria { IDTipoCarroceria = 0, Descricao = "Não Aplicavel" });
            Tipos.Add(new TipoCarroceria { IDTipoCarroceria = 1, Descricao = "Aberta" });
            Tipos.Add(new TipoCarroceria { IDTipoCarroceria = 2, Descricao = "Fechada/Bau" });
            Tipos.Add(new TipoCarroceria { IDTipoCarroceria = 3, Descricao = "Graneleira" });
            Tipos.Add(new TipoCarroceria { IDTipoCarroceria = 4, Descricao = "Porta/Container" });
            Tipos.Add(new TipoCarroceria { IDTipoCarroceria = 5, Descricao = "Sider" });
            return Tipos;
        }
    }
}
