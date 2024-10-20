using PDV.DAO.Entidades;
using System.Collections.Generic;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesRegimeTributario
    {
        public static List<RegimeTributario> GetRegimesTributario()
        {
            List<RegimeTributario> Regimes = new List<RegimeTributario>();
            Regimes.Add(new RegimeTributario(01, "1 - Simples Nacional"));
            Regimes.Add(new RegimeTributario(02, "2 - Simples Nacional com Exc. Rec. Bruta"));
            Regimes.Add(new RegimeTributario(03, "3 - Regime Normal"));
            return Regimes;
        }
    }
}
