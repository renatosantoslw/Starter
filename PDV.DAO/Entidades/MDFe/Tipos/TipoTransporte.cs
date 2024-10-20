using System.Collections.Generic;

namespace PDV.DAO.Entidades.MDFe.Tipos
{
    public class TipoTransporte
    {
        public decimal IDTipoTransporte { get; set; }
        public string Descricao { get; set; }

        public TipoTransporte() { }

        public List<TipoTransporte> GetTipos()
        {
            List<TipoTransporte> Tipos = new List<TipoTransporte>();
            Tipos.Add(new TipoTransporte { IDTipoTransporte = 1, Descricao = "Rodoviário Tração" });
            Tipos.Add(new TipoTransporte { IDTipoTransporte = 2, Descricao = "Rodoviário Reboque" });
            Tipos.Add(new TipoTransporte { IDTipoTransporte = 3, Descricao = "Navio" });
            Tipos.Add(new TipoTransporte { IDTipoTransporte = 4, Descricao = "Balsa" });
            Tipos.Add(new TipoTransporte { IDTipoTransporte = 5, Descricao = "Áeronave" });
            Tipos.Add(new TipoTransporte { IDTipoTransporte = 6, Descricao = "Vagão" });
            Tipos.Add(new TipoTransporte { IDTipoTransporte = 7, Descricao = "Outros" });
            return Tipos;
        }

    }
}
