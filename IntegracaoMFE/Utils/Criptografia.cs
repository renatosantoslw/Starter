using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoMFE.Utils
{
    public static class Criptografia
    {
        public static string MD5(string conteudo)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(conteudo));
            return BitConverter.ToString(bytes).Replace("-", "");
        }
    }
}
