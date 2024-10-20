using DFe.Classes.Flags;
using DFe.Utils;
using NFe.Classes.Informacoes.Emitente;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using NFe.Danfe.Base;
using NFe.Danfe.Base.NFCe;
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

namespace PDV.CONTROLLER.NFCE.Configuracao
{
    public class ConfiguracaoNfce
    {
        public ConfiguracaoServico CfgServico { get; set; }
        public emit Emitente { get; set; }
        public ConfiguracaoCsc ConfiguracaoCsc { get; set; }

        public ConfiguracaoDanfeNfce ConfiguracaoDanfeNfce { get; set; }

        public ConfiguracaoNfce(string DiretorioSchemas)
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
            CfgServico.tpAmb = "1".Equals(Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_AMBIENTE_PRODUCAO).Valor))
                ? TipoAmbiente.Producao
                : TipoAmbiente.Homologacao;

            CfgServico.cUF = (DFe.Classes.Entidades.Estado)Enum.Parse(typeof(DFe.Classes.Entidades.Estado), FuncoesUF.GetUnidadeFederativa(FuncoesEndereco.GetEndereco(FuncoesEmitente.GetEmitente().IDEndereco).IDUnidadeFederativa.Value).Sigla);

            string TimeOut = Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_PROTOCOLO_SEGURANCA_TIMEOUT).Valor);
            CfgServico.TimeOut = string.IsNullOrEmpty(TimeOut) ? 3000 : Convert.ToInt32(TimeOut);

            CfgServico.ProtocoloDeSeguranca = SecurityProtocolType.Tls12;//Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_PROTOCOLO_SEGURANCA_TLSOUSSL3).Valor));


            ServicePointManager.Expect100Continue = true;

            int EmitenteUF = int.Parse(FuncoesMunicipio.ConverterUF(un.Sigla).ToString());

            Emitente = new emit
            {
                CNPJ = em.CNPJ,
                IE = em.InscricaoEstadual.ToString(),
                xFant = em.NomeFantasia,
                xNome = em.RazaoSocial,
                CRT = (CRT)Enum.Parse(typeof(CRT), em.CRT.ToString()),
                enderEmit = new enderEmit()
                {
                    CEP = end.Cep,
                    cMun = (long)Convert.ToDecimal(mun.CodigoIBGE),
                    cPais = Convert.ToInt32(pais.Codigo),
                    fone = (long)Convert.ToDecimal(end.Telefone),
                    nro = end.Numero.ToString(),
                    UF =  (DFe.Classes.Entidades.Estado)Enum.Parse(typeof(DFe.Classes.Entidades.Estado), int.Parse(FuncoesMunicipio.ConverterUF(un.Sigla).ToString()).ToString()),
                    xBairro = end.Bairro,
                    xCpl = end.Complemento,
                    xLgr = end.Logradouro,
                    xMun = mun.Descricao,
                    xPais = pais.Descricao
                }
            };

            // Verificar.
            if (em.CNAE.HasValue)
                Emitente.CNAE = em.CNAE.ToString();

            if (!string.IsNullOrEmpty(em.InscricaoMunicipal))
                Emitente.IM = em.InscricaoMunicipal;
            if(em.CSC != null)
            ConfiguracaoCsc = new ConfiguracaoCsc(em.IDCSC.ToString(), em.CSC);

            /* ConfiguracaoDanfe */
            DAO.Entidades.Configuracao ConfigEmissaoNormal = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_EMISSAONORMAL);
            DAO.Entidades.Configuracao ConfigEmissaoContingencia = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_IMPRESSAOCONTINGENCIA);
            DAO.Entidades.Configuracao ConfigImprimirDescontoItem = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_IMPRIMIRDESCONTOITEM);
            DAO.Entidades.Configuracao ConfigEmissaoMargemEsquerda = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_MARGEMIMPRESSAOESQUERDA);
            DAO.Entidades.Configuracao ConfigEmissaoMargemDireita = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_MARGEMIMPRESSAODIREITA);
            DAO.Entidades.Configuracao ConfigModoImpressao = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_MODODEIMPRESSAO);

            ConfiguracaoDanfeNfce = new ConfiguracaoDanfeNfce((NfceDetalheVendaNormal)Enum.Parse(typeof(NfceDetalheVendaNormal), Encoding.UTF8.GetString(ConfigEmissaoNormal.Valor)),
                                                                                  (NfceDetalheVendaContigencia)Enum.Parse(typeof(NfceDetalheVendaContigencia), Encoding.UTF8.GetString(ConfigEmissaoContingencia.Valor)),
                                                                                  em.Logomarca,
                                                                                  "1".Equals(Encoding.UTF8.GetString(ConfigImprimirDescontoItem.Valor)),
                                                                                  float.Parse(Encoding.UTF8.GetString(ConfigEmissaoMargemEsquerda.Valor)),
                                                                                  float.Parse(Encoding.UTF8.GetString(ConfigEmissaoMargemDireita.Valor)),
                                                                                  "1".Equals(Encoding.UTF8.GetString(ConfigModoImpressao.Valor)) ? NfceModoImpressao.UnicaPagina : NfceModoImpressao.MultiplasPaginas);
            //QRCODE LATERAL
            ConfiguracaoDanfeNfce.NfceLayoutQrCode = NfceLayoutQrCode.Lateral;
        }

        private ConfiguracaoServico CopiarPropriedades()
        {
            ConfiguracaoServico cfg = ConfiguracaoServico.Instancia;

            Emitente _emitente = FuncoesEmitente.GetEmitente();
           

            cfg.ModeloDocumento = ModeloDocumento.NFCe;

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
            cfg.VersaoLayout = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFEAUTORIZACAO));
            cfg.VersaoRecepcaoEventoCceCancelamento = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_RECEPCAOEVENTOCCECANCELAMENTO));
            cfg.VersaoRecepcaoEventoEpec = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_RECEPCAOEVENTOEPEC));
            cfg.VersaoRecepcaoEventoManifestacaoDestinatario = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_RECEPCAOEVENTOMANIFESTACAODESTINATARIO));
            cfg.VersaoNfeRecepcao = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFERECEPCAO));
            cfg.VersaoNfeRetRecepcao = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFERETRECEPCAO));
            cfg.VersaoNfeInutilizacao =  ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFEINUTILIZACAO));
            cfg.VersaoNfeConsultaProtocolo = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFECONSULTAPROTOCOLO));
            cfg.VersaoNfeStatusServico = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFESTATUSSERVICO));
            cfg.VersaoNfeConsultaCadastro = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFECONSULTACADASTRO));
            cfg.VersaoNFeAutorizacao = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFEAUTORIZACAO));
            cfg.VersaoNFeRetAutorizacao =  ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFERETAUTORIZACAO));
            cfg.VersaoNFeDistribuicaoDFe = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFEDISTRIBUICAODFE));
            cfg.VersaoNfeConsultaDest = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFECONSULTADEST));
            cfg.VersaoNfeDownloadNF = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFEDOWNLOADNF));
            cfg.VersaoNfceAministracaoCSC = ControllerFiscalUtil.GetTipoServicoPorConfiguracao(FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_ADMCSCNFCE));
            return cfg;
        }
    }
}
