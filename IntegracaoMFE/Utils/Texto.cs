using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace IntegracaoMFE.Utils
{
    public static class Texto
    {
        public static string SomenteNumeros(string toNormalize)
        {
            List<char> numbers = new List<char>("0123456789");
            StringBuilder toReturn = new StringBuilder(toNormalize.Length);
            CharEnumerator enumerator = toNormalize.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (numbers.Contains(enumerator.Current))
                    toReturn.Append(enumerator.Current);
            }

            return toReturn.ToString();
        }

        /// <summary>
        /// Metodo para tirar os Acentos da string
        /// </summary>
        /// <param name="campo">Campo a ser retirado informações</param>
        /// <returns>String sem Acentos</returns>
        public static string RetiraAcentos(string strcomAcentos)
        {
            string strsemAcentos = strcomAcentos;
            strsemAcentos = Regex.Replace(strsemAcentos, "[áàâãäªå]", "a");
            strsemAcentos = Regex.Replace(strsemAcentos, "[ÁÀÂÃÄÅ]", "A");
            strsemAcentos = Regex.Replace(strsemAcentos, "[éèêë]", "e");
            strsemAcentos = Regex.Replace(strsemAcentos, "[ÉÈÊË]", "E");
            strsemAcentos = Regex.Replace(strsemAcentos, "[íìîï]", "i");
            strsemAcentos = Regex.Replace(strsemAcentos, "[ÍÌÎÏ]", "I");
            strsemAcentos = Regex.Replace(strsemAcentos, "[óòôõöº°]", "o");
            strsemAcentos = Regex.Replace(strsemAcentos, "[ÓÒÔÕÖ]", "O");
            strsemAcentos = Regex.Replace(strsemAcentos, "[úùûü]", "u");
            strsemAcentos = Regex.Replace(strsemAcentos, "[ÚÙÛÜ]", "U");
            strsemAcentos = Regex.Replace(strsemAcentos, "[ç]", "c");
            strsemAcentos = Regex.Replace(strsemAcentos, "[Ç]", "C");
            strsemAcentos = Regex.Replace(strsemAcentos, "[ñÑ]", "n");
            strsemAcentos = Regex.Replace(strsemAcentos, "[ýÿ]", "y");
            strsemAcentos = Regex.Replace(strsemAcentos, "[šŠ]", "s");
            strsemAcentos = Regex.Replace(strsemAcentos, "[@¡?æœƒ¿þµ'!†•¦‣#¶$‡¸%¨&*()+=Þ`´‘’‚„{}^∧∨~Ð><ð⊥™‹®©₡₢›¥₠«»²¹|′³″∫↵∈∉∏∪¬⊇⊆⊃⊂∃∀∅∩√Ø∠ø⊗·ℑ⊕∇ℜℵ∂∑∴≅·∝∗⋅≡±“÷∞≥×”£‰¢≤¬¯¤§…⁺ⁿ₊₋⁻\"]", "");
            return RemoverCaracteresNaoPrintaveis(strsemAcentos);
        }

        public static string RemoverCaracteresNaoPrintaveis(string inString)
        {
            if (inString == null) return null;

            StringBuilder newString = new StringBuilder();
            char ch;

            for (int i = 0; i < inString.Length; i++)
            {

                ch = inString[i];
                if (Char.GetUnicodeCategory(ch) == System.Globalization.UnicodeCategory.Control)
                    continue;
                else
                    newString.Append(ch);
            }
            return newString.ToString();
        }
    }
}
