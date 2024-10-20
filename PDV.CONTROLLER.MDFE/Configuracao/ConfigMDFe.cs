using DFe.Classes.Flags;
using DFe.Utils;
using MDFe.Utils.Configuracoes;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PDV.CONTROLLER.MDFE.Configuracao
{
    public class ConfigMDFe
    {
        public static void PreencheConfiguracao(string CaminhoSchemas)
        {
            Emitente _emitente = FuncoesEmitente.GetEmitente();
            var configuracaoCertificado = new ConfiguracaoCertificado() { Serial = new X509Certificate2(_emitente.Certificado, Criptografia.DecodificaSenha(_emitente.SenhaCertificado)).GetSerialNumberString() };

            MDFeConfiguracao.ConfiguracaoCertificado = configuracaoCertificado;
            MDFeConfiguracao.CaminhoSchemas = CaminhoSchemas;
            MDFeConfiguracao.IsSalvarXml = false;
            MDFeConfiguracao.VersaoWebService.VersaoLayout = MDFe.Utils.Flags.VersaoServico.Versao300;
            MDFeConfiguracao.VersaoWebService.TipoAmbiente = "1".Equals(Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_AMBIENTE_PRODUCAO).Valor)) ? TipoAmbiente.Producao : TipoAmbiente.Homologacao;
            MDFeConfiguracao.VersaoWebService.UfEmitente = (DFe.Classes.Entidades.Estado)Enum.Parse(typeof(DFe.Classes.Entidades.Estado), FuncoesEmitente.GetUnidadeFederativaPorEmitente().Sigla);
            string TimeOut = Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_PROTOCOLO_SEGURANCA_TIMEOUT).Valor);
            MDFeConfiguracao.VersaoWebService.TimeOut = string.IsNullOrEmpty(TimeOut) ? 3000 : Convert.ToInt32(TimeOut);
        }

        public static bool IsExibirCaixaDialogo()
        {
            DAO.Entidades.Configuracao config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_EXIBIRCAIXADIALOGO_MDFE);
            if (config == null)
                return true;
            return "1".Equals(Encoding.UTF8.GetString(config.Valor));
        }

        public static string GetNomeImpressora()
        {
            DAO.Entidades.Configuracao config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_NOMEIMPRESSORA_MDFE);
            if (config == null)
                return null;
            return Encoding.UTF8.GetString(config.Valor);
        }
    }
}
