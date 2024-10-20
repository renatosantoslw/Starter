using Ionic.Zip;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace PDV.UTIL
{
    public partial class ZeusUtil
    {
        /* Verificar Atualizações */
        public static VersaoModulo VerificarVersaoDisponivel(Modulo _Modulo, Version _VersaoAtual)        
        {
            FtpWebRequest ftpWebRequest = GetFTPWebRequestAtualizacoes(_Modulo, null);
            Version _VersaoDisponivel = GetVersaoDisponivel(ftpWebRequest);
            return new VersaoModulo()
            {
                VersaoAtual = _VersaoAtual,
                VersaoDisponivel = _VersaoDisponivel
            };
        }

        private static FtpWebRequest GetFTPWebRequestAtualizacoes(Modulo _Modulo, string Arquivo)
        {
            string Endereco = null;
            string Usuario = null;
            string Senha = null;
            string Pasta = null;

            Configuracao config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOATUALIZADOR_ENDERECO);
            if (config != null)
                Endereco = Encoding.UTF8.GetString(config.Valor);

            config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOATUALIZADOR_USUARIO);
            if (config != null)
                Usuario = Encoding.UTF8.GetString(config.Valor);

            config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOATUALIZADOR_SENHA);
            if (config != null)
                Senha = Criptografia.DecodificaSenha(Encoding.UTF8.GetString(config.Valor));

            config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOATUALIZADOR_PASTA);
            if (config != null)
                Pasta = Encoding.UTF8.GetString(config.Valor);

            String URLI = $"{Endereco}/{Pasta}/{_Modulo.ToString().ToLower()}{(string.IsNullOrEmpty(Arquivo) ? string.Empty : "/" + Arquivo)}";
            FtpWebRequest fwrr = (FtpWebRequest)FtpWebRequest.Create(new Uri(URLI));

            fwrr.Timeout = 1000000000;
            fwrr.Credentials = new NetworkCredential(Usuario, Senha);
            return fwrr;
        }

        private static Version GetVersaoDisponivel(FtpWebRequest fwrr)
        {
            try
            {
                fwrr.Method = WebRequestMethods.Ftp.ListDirectory;
                StreamReader srr = new StreamReader(fwrr.GetResponse().GetResponseStream());
                string str = srr.ReadLine();
                List<Version> strList = new List<Version>();
                while (str != null)
                {
                    string sAux = SomenteNumeros(str); //1.23.56.1487
                    sAux = sAux.Insert(1, ".").Insert(4, ".").Insert(7, ".");
                    Version vs = new Version(sAux);
                    strList.Add(vs);
                  //  strList.Add(SomenteNumeros(str).Equals(string.Empty) ? new Version() : new Version(str.Replace(".zip", string.Empty)));
                    str = srr.ReadLine();
                }

                if (strList.LastOrDefault() == null)
                    return null;

                return strList.OrderByDescending(o => o).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool GetDownloadFile(Modulo _Modulo, Version VersaoDisponivel)
        {
            try
            {
                FtpWebRequest request = GetFTPWebRequestAtualizacoes(_Modulo, VersaoDisponivel.ToString() + ".zip");
                request.UseBinary = true;
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                FileStream writer = new FileStream($"{_Modulo.ToString().ToLower()}_{VersaoDisponivel.ToString()}.zip", FileMode.Create);

                long length = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[2048];

                readCount = responseStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    writer.Write(buffer, 0, readCount);
                    readCount = responseStream.Read(buffer, 0, bufferSize);
                }

                responseStream.Close();
                response.Close();
                writer.Close();

                return true;
            }
            catch
            {
                throw;
            }
        }

        public static bool DescompactaVersao(Modulo _Modulo, Version VersaoDisponivel)
        {
            try
            {
                string URLDiretorio = $"Atualizacoes/{_Modulo.ToString().ToLower()}/{VersaoDisponivel.ToString()}";
                ZipFile zip = ZipFile.Read($"{_Modulo.ToString().ToLower()}_{VersaoDisponivel.ToString()}.zip");
                Directory.CreateDirectory(URLDiretorio);
                zip.ExtractAll(URLDiretorio, ExtractExistingFileAction.OverwriteSilently);
                zip.Dispose();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public static void AtualizaBancoVersao(Modulo _Modulo, Version VersaoDisponivel)
        {
            FileInfo ArquivoSQL = new FileInfo($"{Path.GetFullPath(".")}\\Atualizacoes\\{_Modulo.ToString().ToLower()}\\{VersaoDisponivel.ToString()}\\SQL.SQL");
            string ConteudoArquivoSQL = GetConteudoArquivoSQL(ArquivoSQL);

            if (!string.IsNullOrEmpty(ConteudoArquivoSQL.Trim()))
            {
                string[] Instrucoes = ConteudoArquivoSQL.Trim().Split(';');
                foreach (string SQL in Instrucoes)
                {
                    if (string.IsNullOrEmpty(SQL))
                        continue;

                    FuncoesAtualizador.ExecutaNonQuery(SQL.Trim());
                }
            }
        }

        public static string GetNomeInstaladorVersion(Modulo _Modulo)
        {
            switch (_Modulo)
            {
                case Modulo.CONTINGENCIA_NFCE:
                    return "PDV.NFCE.MOTORCONTINGENCIA.SETUP.msi";
                case Modulo.ERP:
                    return "PDV.VIEW.SETUP.msi";
                case Modulo.PDV:
                    return "PDV.VIEW.FRENTECAIXA.SETUP.msi";
                default:
                    return null;
            }
        }

        private static string GetConteudoArquivoSQL(FileInfo ArquivoSQL)
        {

            if (ArquivoSQL.Exists)
            {
                try
                {
                    using (StreamReader st = ArquivoSQL.OpenText())
                        return st.ReadToEnd();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                return string.Empty;
        }
    }
}
