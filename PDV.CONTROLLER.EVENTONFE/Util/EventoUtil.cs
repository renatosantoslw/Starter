using System.Text;

namespace PDV.CONTROLLER.EVENTONFE.Util
{
    public class EventoUtil
    {
        public static string RemoverAcentos(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
            else
            {
                byte[] bytes = Encoding.GetEncoding("iso-8859-8").GetBytes(input);
                return Encoding.UTF8.GetString(bytes);
            }
        }
    }
}
