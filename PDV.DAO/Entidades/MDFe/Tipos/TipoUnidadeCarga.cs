using System.Collections.Generic;

namespace PDV.DAO.Entidades.MDFe.Tipos
{
    public class TipoUnidadeCarga
    {
        public decimal IDTipoUnidadeCarga { get; set; }
        public string Descricao { get; set; }

        public TipoUnidadeCarga() { }

        public List<TipoUnidadeCarga> GetTipos()
        {
            List<TipoUnidadeCarga> Tipos = new List<TipoUnidadeCarga>();
            Tipos.Add(new TipoUnidadeCarga { IDTipoUnidadeCarga = 1, Descricao = "Container" });
            Tipos.Add(new TipoUnidadeCarga { IDTipoUnidadeCarga = 2, Descricao = "ULD" });
            Tipos.Add(new TipoUnidadeCarga { IDTipoUnidadeCarga = 3, Descricao = "Pallet" });
            Tipos.Add(new TipoUnidadeCarga { IDTipoUnidadeCarga = 4, Descricao = "Outros" });
            return Tipos;
        }
    }
}
