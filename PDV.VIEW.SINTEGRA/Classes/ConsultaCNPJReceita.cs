using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;


namespace PDV.VIEW.SINTEGRA.Classes
{
    public class ConsultaCNPJReceita
    {
        private readonly CookieContainer _cookies = new CookieContainer();
        //private String urlBaseReceitaFederal = "http://www.receita.fazenda.gov.br/pessoajuridica/cnpj/cnpjreva/";
        private String urlBaseReceitaFederal = "http://servicos.receita.fazenda.gov.br/Servicos/cnpjreva/";
        private String paginaValidacao = "valida.asp";
        //private String paginaPrincipal = "cnpjreva_solicitacao2.asp";
        private String paginaPrincipal = "Cnpjreva_Solicitacao.asp";

        private String paginaCaptcha = "captcha/gerarCaptcha.asp";

        public Bitmap GetCaptcha()
        {
            String htmlResult;
            using (var wc = new CookieAwareWebClient())
            {
                wc.SetCookieContainer(_cookies);
                wc.Headers[HttpRequestHeader.UserAgent] = "Mozilla/4.0 (compatible; Synapse)";
                wc.Headers[HttpRequestHeader.KeepAlive] = "300";
                htmlResult = wc.DownloadString(urlBaseReceitaFederal + paginaPrincipal);
            }
            if (htmlResult.Length > 0)
            {
                var wc2 = new CookieAwareWebClient();
                wc2.SetCookieContainer(_cookies);
                wc2.Headers[HttpRequestHeader.UserAgent] = "Mozilla/4.0 (compatible; Synapse)";
                wc2.Headers[HttpRequestHeader.KeepAlive] = "300";
                byte[] data = wc2.DownloadData(urlBaseReceitaFederal + paginaCaptcha);
                return new Bitmap(new MemoryStream(data));
            }
            return null;
        }

        public String Consulta(string aCNPJ, string aCaptcha)
        {
            var request = (HttpWebRequest)WebRequest.Create(urlBaseReceitaFederal + paginaValidacao);
            request.ProtocolVersion = HttpVersion.Version10;
            request.CookieContainer = _cookies;
            request.Method = "POST";

            string postData = "";
            postData = postData + "origem=comprovante&";
            postData = postData + "cnpj=" + new Regex(@"[^\d]").Replace(aCNPJ, string.Empty) + "&";
            postData = postData + "txtTexto_captcha_serpro_gov_br=" + aCaptcha + "&";
            postData = postData + "submit1=Consultar&";
            postData = postData + "search_type=cnpj";

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            StreamReader stHtml = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("ISO-8859-1"));
            String retorno = stHtml.ReadToEnd();

            if (retorno.Contains("Verifique se o mesmo foi digitado corretamente"))
                throw new System.InvalidOperationException("O número do CNPJ não foi digitado corretamente");
            if (retorno.Contains("Erro na Consulta"))
                throw new System.InvalidOperationException("Os caracteres digitados não correspondem com a imagem");
            return retorno;
        }
    }
}