using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PDV.UTIL.Components
{
    public static class DecimalMoeda
    {
        public static void Moeda(ref TextBox txt)
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
                throw;
            }
        }

        public static void Moeda(ref TextEdit txt)
        {
            //var value = txt.Text.Replace(",", "");
            
            //if(value != "")
            //{
            //    txt.Text = (Convert.ToDecimal(value) / 100).ToString();
            //}
            //txt.SelectionStart = txt.Text.Length;
        }

    }

}
