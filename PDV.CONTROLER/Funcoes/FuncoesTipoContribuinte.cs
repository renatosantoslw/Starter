using PDV.DAO.Entidades;
using System.Collections.Generic;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesTipoContribuinte
    {
        public static List<TipoContribuinte> GetTiposContribuinte()
        {
            List<TipoContribuinte> Tipos = new List<TipoContribuinte>();
            Tipos.Add(new TipoContribuinte() { Codigo = 1, Descricao = "Contribuinte ICMS" });
            Tipos.Add(new TipoContribuinte() { Codigo = 2, Descricao = "Isento" });
            Tipos.Add(new TipoContribuinte() { Codigo = 9, Descricao = "Não Contribuinte"});
            return Tipos;
        }
    }
}
