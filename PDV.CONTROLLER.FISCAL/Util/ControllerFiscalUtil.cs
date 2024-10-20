using DFe.Classes.Flags;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos;
using NFe.Classes.Servicos.Tipos;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace PDV.CONTROLLER.FISCAL.Util
{
    public class ControllerFiscalUtil
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

        public static string SomenteNumeros(string Value)
        {
            string resultString = string.Empty;
            Regex regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(Value, "");
            return resultString;
        }

        public static VersaoServico GetTipoServicoPorConfiguracao(DAO.Entidades.Configuracao config)
        {
            if (config == null)
                return VersaoServico.Versao400;

            switch (Encoding.UTF8.GetString(config.Valor))
            {
                case "1.0": return VersaoServico.Versao100;
                case "2.0": return VersaoServico.Versao200;
                case "3.1": return VersaoServico.Versao310;
                case "4.00": return VersaoServico.Versao400;
                default:
                    return VersaoServico.Versao400;
            }
        }

        public static Csticms CstICMSToZeus(int CST)
        {
            switch (CST)
            {
                case 00:
                    return Csticms.Cst00;
                case 10:
                    return Csticms.Cst10;
                case 20:
                    return Csticms.Cst20;
                case 30:
                    return Csticms.Cst30;
                case 40:
                    return Csticms.Cst40;
                case 41:
                    return Csticms.Cst41;
                case 50:
                    return Csticms.Cst50;
                case 51:
                    return Csticms.Cst51;
                case 60:
                    return Csticms.Cst60;
                case 70:
                    return Csticms.Cst70;
                case 90:
                    return Csticms.Cst90;
                default:
                    throw new Exception("CST Inválido");
            }
        }

        public static string CstICMSParaString(Csticms csticms)
        {
            switch (csticms)
            {
                case Csticms.Cst00:
                    return "00";
                case Csticms.Cst10:
                case Csticms.CstPart10:
                    return "10";
                case Csticms.Cst20:
                    return "20";
                case Csticms.Cst30:
                    return "30";
                case Csticms.Cst40:
                    return "40";
                case Csticms.Cst41:
                case Csticms.CstRep41:
                    return "41";
                case Csticms.Cst50:
                    return "50";
                case Csticms.Cst51:
                    return "51";
                case Csticms.Cst60:
                    return "60";
                case Csticms.Cst70:
                    return "70";
                case Csticms.Cst90:
                case Csticms.CstPart90:
                    return "90";
                default:
                    throw new ArgumentOutOfRangeException("csticms", csticms, null);
            }
        }
    }
}