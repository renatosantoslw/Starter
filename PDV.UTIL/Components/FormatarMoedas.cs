using System;
using System.Windows.Forms;

namespace PDV.UTIL.Components
{

    public static class Moedas
    {
        public static void FormatarMoedas(ref TextBox txt)
        {
            string m = string.Empty;
            decimal v = 0;
            try
            {
                m = txt.Text.Replace(",", "").Replace(",", "");
                if (m.Equals(""))
                {
                    m = "";
                }
                m = m.PadLeft(3, '0');
                if (m.Length > 3 & m.Substring(0, 1) == "0")
                {
                    m = m.Substring(1, m.Length - 1);
                }
                v = Convert.ToDecimal(m) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception)
            {
            }
        }

       
    }
}
