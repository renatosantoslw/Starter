using System;
using System.IO;
using System.Text;

namespace IntegracaoMFE.Utils
{
    public static class Arquivos
    {
        public static void GravarArquivo(string path, string conteudoArquivo, string nomeArquivo)
        {
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                StreamWriter sw = new StreamWriter(path + "\\" + nomeArquivo, false, Encoding.UTF8);
                sw.Write(conteudoArquivo);
                sw.Close();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
