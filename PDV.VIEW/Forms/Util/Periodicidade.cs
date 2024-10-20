using FastReport.Data;
using System.Collections.Generic;
using System.Linq;

namespace PDV.VIEW.Forms.Util
{
    public class Periodicidade
    {
        public static int Fator(string periodicidade)
        {
            var dicionario = new Dictionary<string, int>()
            {
                { "Diário", 1 },
                { "Semanal", 7 },
                { "Quinzenal", 15 },
                { "Mensal", 30 },
                { "Bismestral", 61 },
                { "35 Dias", 35 },
                { "45 Dias", 45 },
                { "Trimestral", 90 },
                { "Semestral", 180 },
                { "Anual", 365 },
                { "Bienal", 730 }
            };
            
            return dicionario.Where(d => d.Key == periodicidade).Select(p => p.Value).Single();
        }
    }
}