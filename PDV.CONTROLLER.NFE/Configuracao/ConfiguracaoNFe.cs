using DFe.Classes.Flags;
using DFe.Utils;
using NFe.Classes.Informacoes.Emitente;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using NFe.Danfe.Base.NFe;
using NFe.Utils;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.FISCAL.Util;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PDV.CONTROLLER.NFE.Configuracao
{
    public class ConfiguracaoNFe
    {
        public ConfiguracaoServico CfgServico { get; set; }
        public emit Emitente { get; set; }
        public ConfiguracaoDanfeNfe ConfiguracaoDanfeNFe { get; set; }

        public ConfiguracaoNFe(string DiretorioSchemas)
        {
            CfgServico = CopiarPropriedades();
            Emitente em = FuncoesEmitente.GetEmitente();
            if (em == null)
                throw new Exception("Emitente não cadastrado. Verifique!");

            Endereco end = FuncoesEndereco.GetEndereco(em.IDEndereco);
            Pais pais = FuncoesPais.GetPais(end.IDPais.Value);
            UnidadeFederativa un = FuncoesUF.GetUnidadeFederativa(end.IDUnidadeFederativa.Value);
            Municipio mun = FuncoesMunicipio.GetMunicipio(end.IDMunicipio.Value);

            CfgServico.DiretorioSchemas = DiretorioSchemas;
            CfgServico.tpEmis = TipoEmissao.teNormal;
            CfgServico.tpAmb = "1".Equals(Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_AMBIENTE_PRODUCAO).Valor)) ? TipoAmbiente.Producao : TipoAmbiente.Homologacao;
            CfgServico.cUF = (DFe.Classes.Entidades.Estado)Enum.Parse(typeof(DFe.Classes.Entidades.Estado), FuncoesUF.GetUnidadeFederativa(FuncoesEndereco.GetEndereco(FuncoesEmitente.GetEmitente().IDEndereco).IDUnidadeFederativa.Value).Sigla);

            string TimeOut = Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_PROTOCOLO_SEGURANCA_TIMEOUT).Valor);
            CfgServico.TimeOut = string.IsNullOrEmpty(TimeOut) ? 3000 : Convert.ToInt32(TimeOut);
            CfgServico.ProtocoloDeSeguranca = SecurityProtocolType.Tls12; //  "0".Equals(Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_PROTOCOLO_SEGURANCA_TLSOUSSL3).Valor)) ? SecurityProtocolType.Ssl3 : SecurityProtocolType.Tls;

            ServicePointManager.Expect100Continue = true;

            Emitente = new emit
            {
                CNPJ = em.CNPJ,
                IE = em.InscricaoEstadual.ToString(),
                xFant = em.NomeFantasia,
                xNome = em.RazaoSocial,
                CRT = (CRT)em.CRT,
                
                enderEmit = new enderEmit()
                {
                    CEP = end.Cep,
                    cMun = (long)Convert.ToDecimal(mun.CodigoIBGE),
                    cPais = Convert.ToInt32(pais.Codigo),
                    fone = (long)Convert.ToDecimal(end.Telefone),
                    nro = end.Numero.ToString(),
                    UF = (DFe.Classes.Entidades.Estado)Enum.Parse(typeof(DFe.Classes.Entidades.Estado), int.Parse(FuncoesMunicipio.ConverterUF(un.Sigla).ToString()).ToString()),
                    xBairro = end.Bairro,
                    xCpl = end.Complemento,
                    xLgr = end.Logradouro,
                    xMun = mun.Descricao,
                    xPais = pais.Descricao
                }
            };

            if (em.CNAE.HasValue)
                Emitente.CNAE = em.CNAE.ToString();

            if (!string.IsNullOrEmpty(em.InscricaoMunicipal))
                Emitente.IM = em.InscricaoMunicipal;
        }

        private ConfiguracaoServico CopiarPropriedades()
        {
            ConfiguracaoServico cfg = ConfiguracaoServico.Instancia;

            Emitente _emitente = FuncoesEmitente.GetEmitente();
            cfg.ModeloDocumento = DFe.Classes.Flags.ModeloDocumento.NFe;

            cfg.Certificado = new ConfiguracaoCertificado()
            {
                Serial = new X509Certificate2(_emitente.Certificado, Criptografia.DecodificaSenha(_emitente.SenhaCertificado)).GetSerialNumberString()
            };

            cfg.cUF = (DFe.Classes.Entidades.Estado)Enum.Parse(typeof(DFe.Classes.Entidades.Estado), FuncoesEmitente.GetUnidadeFederativaPorEmitente().Sigla);
            cfg.tpEmis = TipoEmissao.teNormal;
            cfg.tpAmb = "1".Equals(Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_AMBIENTE_PRODUCAO).Valor)) ? TipoAmbiente.Producao : TipoAmbiente.Homologacao;

            string TimeOut = Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_PROTOCOLO_SEGURANCA_TIMEOUT).Valor);
            cfg.TimeOut = string.IsNullOrEmpty(TimeOut) ? 3000 : Convert.ToInt32(TimeOut);
            cfg.ProtocoloDeSeguranca = "0".Equals(Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_PROTOCOLO_SEGURANCA_TLSOUSSL3).Valor)) ? SecurityProtocolType.Ssl3 : SecurityProtocolType.Tls;

            cfg.VersaoRecepcaoEventoCceCancelamento = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_RECEPCAOEVENTOCCECANCELAMENTO));
            cfg.VersaoRecepcaoEventoEpec = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_RECEPCAOEVENTOEPEC));
            cfg.VersaoRecepcaoEventoManifestacaoDestinatario = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_RECEPCAOEVENTOMANIFESTACAODESTINATARIO));
            cfg.VersaoNfeRecepcao = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFERECEPCAO));
            cfg.VersaoNfeRetRecepcao = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFERETRECEPCAO));
            cfg.VersaoNfeInutilizacao = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFEINUTILIZACAO));
            cfg.VersaoNfeConsultaProtocolo = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFECONSULTAPROTOCOLO));
            cfg.VersaoNfeStatusServico = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFESTATUSSERVICO));
            cfg.VersaoNfeConsultaCadastro = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFECONSULTACADASTRO));
            cfg.VersaoNFeAutorizacao = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFEAUTORIZACAO));
            cfg.VersaoNFeRetAutorizacao = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFERETAUTORIZACAO));
            cfg.VersaoNFeDistribuicaoDFe = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFEDISTRIBUICAODFE));
            cfg.VersaoNfeConsultaDest = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFECONSULTADEST));
            cfg.VersaoNfeDownloadNF = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFEDOWNLOADNF));
            cfg.VersaoNfceAministracaoCSC = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_ADMCSCNFCE));

            DAO.Entidades.Configuracao ConfigEmissaoNormal = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_EMISSAONORMAL_NFE);
            ConfiguracaoDanfeNFe = new ConfiguracaoDanfeNfe
            {
                Logomarca = _emitente.Logomarca,
                DuasLinhas = ConfigEmissaoNormal != null && Encoding.UTF8.GetString(ConfigEmissaoNormal.Valor).Equals("2"),
                DocumentoCancelado = false,
                ChaveContingencia = string.Empty,
                ExibeCampoFatura = true,
                ExibirResumoCanhoto = false,
                ResumoCanhoto = "",
                ImprimirDescPorc = true,
                ImprimirISSQN = false,
                ImprimirTotalLiquido = false,
                ImprimirUnidQtdeValor = ImprimirUnidQtdeValor.Comercial,
                QuebrarLinhasObservacao = true
            };
            return cfg;
        }
    }
}
