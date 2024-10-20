using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.UTIL
{
    public static class FuncoesUteis
    {
        public static string ConverterListParaString(List<decimal> lista, string separador = " ")
        {
            var listaString = new List<string>();
            foreach (var item in lista)
            {
                listaString.Add(item.ToString());
            }

            return string.Join(separador, listaString);
        }
    }
}
