using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Configuracoes
{
    public partial class FCONFIG_WebServicesNFCE : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "WEB-SERVICES NFE/NFC-E";
        private List<UnidadeFederativa> Estados = FuncoesUF.GetUnidadeFederativaPorCodigoPais(Contexto.CODIGO_BRASIL);
        public FCONFIG_WebServicesNFCE()
        {
            InitializeComponent();

            CarregarConfiguracoes();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void CarregarConfiguracoes()
        {
            Configuracao conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_AMBIENTE_PRODUCAO);
            if (conf != null)
            {
                if ("1".Equals(Encoding.UTF8.GetString(conf.Valor)))
                    ovRB_Producao.Checked = true;
                else
                    ovRB_Homolocagao.Checked = true;
            }

            conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_RECEPCAOEVENTOCCECANCELAMENTO);
            if (conf != null)
            {
                switch (Encoding.UTF8.GetString(conf.Valor))
                {
                    case "1.0": ovRB_RecepcaoEventoCceCancelamento1.Checked = true; break;
                    case "2.0": ovRB_RecepcaoEventoCceCancelamento2.Checked = true; break;
                    case "3.1": ovRB_RecepcaoEventoCceCancelamento3_1.Checked = true; break;
                    case "4.00": ovRB_RecepcaoEventoCceCancelamento4_0.Checked = true; break;
                }
            }

            conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_RECEPCAOEVENTOEPEC);
            if (conf != null)
            {
                switch (Encoding.UTF8.GetString(conf.Valor))
                {
                    case "1.0": ovRB_RecepcaoEventoEpec1.Checked = true; break;
                    case "2.0": ovRB_RecepcaoEventoEpec2.Checked = true; break;
                    case "3.1": ovRB_RecepcaoEventoEpec3_1.Checked = true; break;
                    case "4.00": ovRB_RecepcaoEventoEpec4_0.Checked = true; break;
                }
            }

            conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_RECEPCAOEVENTOMANIFESTACAODESTINATARIO);
            if (conf != null)
            {
                switch (Encoding.UTF8.GetString(conf.Valor))
                {
                    case "1.0": ovRB_RecepcaoEventoManifestacaoDestinatario1.Checked = true; break;
                    case "2.0": ovRB_RecepcaoEventoManifestacaoDestinatario2.Checked = true; break;
                    case "3.1": ovRB_RecepcaoEventoManifestacaoDestinatario3_1.Checked = true; break;
                    case "4.00": ovRB_RecepcaoEventoManifestacaoDestinatario4_0.Checked = true; break;
                }
            }

            conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFERECEPCAO);
            if (conf != null)
            {
                switch (Encoding.UTF8.GetString(conf.Valor))
                {
                    case "1.0": ovRB_NfeRecepcao1.Checked = true; break;
                    case "2.0": ovRB_NfeRecepcao2.Checked = true; break;
                    case "3.1": ovRB_NfeRecepcao3_1.Checked = true; break;
                    case "4.00": ovRB_NfeRecepcao4_0.Checked = true; break;
                }
            }

            conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFERETRECEPCAO);
            if (conf != null)
            {
                switch (Encoding.UTF8.GetString(conf.Valor))
                {
                    case "1.0": ovRB_NfeRetRecepcao1.Checked = true; break;
                    case "2.0": ovRB_NfeRetRecepcao2.Checked = true; break;
                    case "3.1": ovRB_NfeRetRecepcao3_1.Checked = true; break;
                    case "4.00": ovRB_NfeRetRecepcao4_0.Checked = true; break;
                }
            }

            conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFEINUTILIZACAO);
            if (conf != null)
            {
                switch (Encoding.UTF8.GetString(conf.Valor))
                {
                    case "1.0": ovRB_NfeInutilizacao1.Checked = true; break;
                    case "2.0": ovRB_NfeInutilizacao2.Checked = true; break;
                    case "3.1": ovRB_NfeInutilizacao3_1.Checked = true; break;
                    case "4.00": ovRB_NfeInutilizacao4_0.Checked = true; break;
                }
            }

            conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFECONSULTAPROTOCOLO);
            if (conf != null)
            {
                switch (Encoding.UTF8.GetString(conf.Valor))
                {
                    case "1.0": ovRB_NfeConsultaProtocolo1.Checked = true; break;
                    case "2.0": ovRB_NfeConsultaProtocolo2.Checked = true; break;
                    case "3.1": ovRB_NfeConsultaProtocolo3_1.Checked = true; break;
                    case "4.00": ovRB_NfeConsultaProtocolo4_0.Checked = true; break;
                }
            }

            conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFESTATUSSERVICO);
            if (conf != null)
            {
                switch (Encoding.UTF8.GetString(conf.Valor))
                {
                    case "1.0": ovRB_NfeStatusServico1.Checked = true; break;
                    case "2.0": ovRB_NfeStatusServico2.Checked = true; break;
                    case "3.1": ovRB_NfeStatusServico3_1.Checked = true; break;
                    case "4.00": ovRB_NfeStatusServico4_0.Checked = true; break;
                }
            }

            conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFECONSULTACADASTRO);
            if (conf != null)
            {
                switch (Encoding.UTF8.GetString(conf.Valor))
                {
                    case "1.0": ovRB_NfeConsultaCadastro1.Checked = true; break;
                    case "2.0": ovRB_NfeConsultaCadastro2.Checked = true; break;
                    case "3.1": ovRB_NfeConsultaCadastro3_1.Checked = true; break;
                    case "4.00": ovRB_NfeConsultaCadastro4_0.Checked = true; break;
                }
            }

            conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFEAUTORIZACAO);
            if (conf != null)
            {
                switch (Encoding.UTF8.GetString(conf.Valor))
                {
                    case "1.0": ovRB_NFeAutorizacao1.Checked = true; break;
                    case "2.0": ovRB_NFeAutorizacao2.Checked = true; break;
                    case "3.1": ovRB_NFeAutorizacao3_1.Checked = true; break;
                    case "4.00": ovRB_NFeAutorizacao4_0.Checked = true; break;
                }
            }

            conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFERETAUTORIZACAO);
            if (conf != null)
            {
                switch (Encoding.UTF8.GetString(conf.Valor))
                {
                    case "1.0": ovRB_NFeRetAutorizacao1.Checked = true; break;
                    case "2.0": ovRB_NFeRetAutorizacao2.Checked = true; break;
                    case "3.1": ovRB_NFeRetAutorizacao3_1.Checked = true; break;
                    case "4.00": ovRB_NFeRetAutorizacao4_0.Checked = true; break;
                }
            }

            conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFEDISTRIBUICAODFE);
            if (conf != null)
            {
                switch (Encoding.UTF8.GetString(conf.Valor))
                {
                    case "1.0": ovRB_NFeDistribuicaoDFe1.Checked = true; break;
                    case "2.0": ovRB_NFeDistribuicaoDFe2.Checked = true; break;
                    case "3.1": ovRB_NFeDistribuicaoDFe3_1.Checked = true; break;
                    case "4.00": ovRB_NFeDistribuicaoDFe4_0.Checked = true; break;
                }
            }

            conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFECONSULTADEST);
            if (conf != null)
            {
                switch (Encoding.UTF8.GetString(conf.Valor))
                {
                    case "1.0": ovRB_NfeConsultaDest1.Checked = true; break;
                    case "2.0": ovRB_NfeConsultaDest2.Checked = true; break;
                    case "3.1": ovRB_NfeConsultaDest3_1.Checked = true; break;
                    case "4.00": ovRB_NfeConsultaDest4_0.Checked = true; break;
                }
            }

            conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFEDOWNLOADNF);
            if (conf != null)
            {
                switch (Encoding.UTF8.GetString(conf.Valor))
                {
                    case "1.0": ovRB_NfeDownloadNF1.Checked = true; break;
                    case "2.0": ovRB_NfeDownloadNF2.Checked = true; break;
                    case "3.1": ovRB_NfeDownloadNF3_1.Checked = true; break;
                    case "4.00": ovRB_NfeDownloadNF4_0.Checked = true; break;
                }
            }

            conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_ADMCSCNFCE);
            if (conf != null)
            {
                switch (Encoding.UTF8.GetString(conf.Valor))
                {
                    case "1.0": ovRB_admCscNFCe1.Checked = true; break;
                    case "2.0": ovRB_admCscNFCe2.Checked = true; break;
                    case "3.1": ovRB_admCscNFCe3_1.Checked = true; break;
                    case "4.00": ovRB_admCscNFCe4_0.Checked = true; break;
                }
            }

            /* Protocolos de Segurança */
            conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_PROTOCOLO_SEGURANCA_TIMEOUT);
            if (conf != null && !string.IsNullOrEmpty(Encoding.UTF8.GetString(conf.Valor)))
                ovTXT_TimeOut.Text = Encoding.UTF8.GetString(conf.Valor);

            conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_NFCE_PROTOCOLO_SEGURANCA_TLSOUSSL3);
            if (conf != null)
            {
                switch (Encoding.UTF8.GetString(conf.Valor))
                {
                    case "0":
                        ovRB_SSL3.Checked = true;
                        break;
                    case "1":
                        ovRB_TLS.Checked = true;
                        break;
                    case "2":
                        ovRB_TLS1_2.Checked = true;
                        break;

                }
            }

            conf = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.METODO_SINCRONO);
            if (conf != null)
            {
                switch (Encoding.UTF8.GetString(conf.Valor))
                {
                    case "0":
                        ovRB_Assincrono.Checked = true;
                        break;
                    case "1":
                        ovRB_Sincrono.Checked = true;
                        break;

                }
            }
        }

        private void ovBTN_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ovBTN_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                /* Salvar as configurações aqui. */

                if (!ovRB_SSL3.Checked && !ovRB_TLS.Checked && !ovRB_TLS1_2.Checked)
                    throw new Exception("Selecione o Protocolo de Segurança.");

                if (string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(ovTXT_TimeOut.Text)))
                    throw new Exception("TimeOut é Inválido. Verifique e tente novamente.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_AMBIENTE_PRODUCAO, Encoding.Default.GetBytes(ovRB_Producao.Checked ? "1" : "2")))
                    throw new Exception("Não foi possível salvar o Ambiente de Produção");

                string Value = string.Empty;
                if (ovRB_RecepcaoEventoCceCancelamento1.Checked) Value = "1.0";
                else if (ovRB_RecepcaoEventoCceCancelamento2.Checked) Value = "2.0";
                else if (ovRB_RecepcaoEventoCceCancelamento3_1.Checked) Value = "3.1";
                else if (ovRB_RecepcaoEventoCceCancelamento4_0.Checked) Value = "4.00";

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_RECEPCAOEVENTOCCECANCELAMENTO, Encoding.Default.GetBytes(Value)))
                    throw new Exception("Não foi possível salvar a Versão do Ambiente de Destino.");


                Value = string.Empty;
                if (ovRB_RecepcaoEventoEpec1.Checked) Value = "1.0";
                else if (ovRB_RecepcaoEventoEpec2.Checked) Value = "2.0";
                else if (ovRB_RecepcaoEventoEpec3_1.Checked) Value = "3.1";
                else if (ovRB_RecepcaoEventoEpec4_0.Checked) Value = "4.00";

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_RECEPCAOEVENTOEPEC, Encoding.Default.GetBytes(Value)))
                    throw new Exception("Não foi possível salvar a Versão do Ambiente de Destino.");


                Value = string.Empty;
                if (ovRB_RecepcaoEventoManifestacaoDestinatario1.Checked) Value = "1.0";
                else if (ovRB_RecepcaoEventoManifestacaoDestinatario2.Checked) Value = "2.0";
                else if (ovRB_RecepcaoEventoManifestacaoDestinatario3_1.Checked) Value = "3.1";
                else if (ovRB_RecepcaoEventoManifestacaoDestinatario4_0.Checked) Value = "4.00";

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_RECEPCAOEVENTOMANIFESTACAODESTINATARIO, Encoding.Default.GetBytes(Value)))
                    throw new Exception("Não foi possível salvar a Versão do Ambiente de Destino.");

                Value = string.Empty;
                if (ovRB_NfeRecepcao1.Checked) Value = "1.0";
                else if (ovRB_NfeRecepcao2.Checked) Value = "2.0";
                else if (ovRB_NfeRecepcao3_1.Checked) Value = "3.1";
                else if (ovRB_NfeRecepcao4_0.Checked) Value = "4.00";

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFERECEPCAO, Encoding.Default.GetBytes(Value)))
                    throw new Exception("Não foi possível salvar a Versão do Ambiente de Destino.");

                Value = string.Empty;
                if (ovRB_NfeRetRecepcao1.Checked) Value = "1.0";
                else if (ovRB_NfeRetRecepcao2.Checked) Value = "2.0";
                else if (ovRB_NfeRetRecepcao3_1.Checked) Value = "3.1";
                else if (ovRB_NfeRetRecepcao4_0.Checked) Value = "4.00";

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFERETRECEPCAO, Encoding.Default.GetBytes(Value)))
                    throw new Exception("Não foi possível salvar a Versão do Ambiente de Destino.");

                Value = string.Empty;
                if (ovRB_NfeInutilizacao1.Checked) Value = "1.0";
                else if (ovRB_NfeInutilizacao2.Checked) Value = "2.0";
                else if (ovRB_NfeInutilizacao3_1.Checked) Value = "3.1";
                else if (ovRB_NfeInutilizacao4_0.Checked) Value = "4.00";

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFEINUTILIZACAO, Encoding.Default.GetBytes(Value)))
                    throw new Exception("Não foi possível salvar a Versão do Ambiente de Destino.");

                Value = string.Empty;
                if (ovRB_NfeConsultaProtocolo1.Checked) Value = "1.0";
                else if (ovRB_NfeConsultaProtocolo2.Checked) Value = "2.0";
                else if (ovRB_NfeConsultaProtocolo3_1.Checked) Value = "3.1";
                else if (ovRB_NfeConsultaProtocolo4_0.Checked) Value = "4.00";

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFECONSULTAPROTOCOLO, Encoding.Default.GetBytes(Value)))
                    throw new Exception("Não foi possível salvar a Versão do Ambiente de Destino.");

                Value = string.Empty;
                if (ovRB_NfeStatusServico1.Checked) Value = "1.0";
                else if (ovRB_NfeStatusServico2.Checked) Value = "2.0";
                else if (ovRB_NfeStatusServico3_1.Checked) Value = "3.1";
                else if (ovRB_NfeStatusServico4_0.Checked) Value = "4.00";

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFESTATUSSERVICO, Encoding.Default.GetBytes(Value)))
                    throw new Exception("Não foi possível salvar a Versão do Ambiente de Destino.");

                Value = string.Empty;
                if (ovRB_NfeConsultaCadastro1.Checked) Value = "1.0";
                else if (ovRB_NfeConsultaCadastro2.Checked) Value = "2.0";
                else if (ovRB_NfeConsultaCadastro3_1.Checked) Value = "3.1";
                else if (ovRB_NfeConsultaCadastro4_0.Checked) Value = "4.00";

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFECONSULTACADASTRO, Encoding.Default.GetBytes(Value)))
                    throw new Exception("Não foi possível salvar a Versão do Ambiente de Destino.");

                Value = string.Empty;
                if (ovRB_NFeAutorizacao1.Checked) Value = "1.0";
                else if (ovRB_NFeAutorizacao2.Checked) Value = "2.0";
                else if (ovRB_NFeAutorizacao3_1.Checked) Value = "3.1";
                else if (ovRB_NFeAutorizacao4_0.Checked) Value = "4.00";

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFEAUTORIZACAO, Encoding.Default.GetBytes(Value)))
                    throw new Exception("Não foi possível salvar a Versão do Ambiente de Destino.");

                Value = string.Empty;
                if (ovRB_NFeRetAutorizacao1.Checked) Value = "1.0";
                else if (ovRB_NFeRetAutorizacao2.Checked) Value = "2.0";
                else if (ovRB_NFeRetAutorizacao3_1.Checked) Value = "3.1";
                else if (ovRB_NFeRetAutorizacao4_0.Checked) Value = "4.00";

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFERETAUTORIZACAO, Encoding.Default.GetBytes(Value)))
                    throw new Exception("Não foi possível salvar a Versão do Ambiente de Destino.");

                Value = string.Empty;
                if (ovRB_NFeDistribuicaoDFe1.Checked) Value = "1.0";
                else if (ovRB_NFeDistribuicaoDFe2.Checked) Value = "2.0";
                else if (ovRB_NFeDistribuicaoDFe3_1.Checked) Value = "3.1";
                else if (ovRB_NFeDistribuicaoDFe4_0.Checked) Value = "4.00";

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFEDISTRIBUICAODFE, Encoding.Default.GetBytes(Value)))
                    throw new Exception("Não foi possível salvar a Versão do Ambiente de Destino.");

                Value = string.Empty;
                if (ovRB_NfeConsultaDest1.Checked) Value = "1.0";
                else if (ovRB_NfeConsultaDest2.Checked) Value = "2.0";
                else if (ovRB_NfeConsultaDest3_1.Checked) Value = "3.1";
                else if (ovRB_NfeConsultaDest4_0.Checked) Value = "4.00";

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFECONSULTADEST, Encoding.Default.GetBytes(Value)))
                    throw new Exception("Não foi possível salvar a Versão do Ambiente de Destino.");

                Value = string.Empty;
                if (ovRB_NfeDownloadNF1.Checked) Value = "1.0";
                else if (ovRB_NfeDownloadNF2.Checked) Value = "2.0";
                else if (ovRB_NfeDownloadNF3_1.Checked) Value = "3.1";
                else if (ovRB_NfeDownloadNF4_0.Checked) Value = "4.00";

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_NFEDOWNLOADNF, Encoding.Default.GetBytes(Value)))
                    throw new Exception("Não foi possível salvar a Versão do Ambiente de Destino.");

                Value = string.Empty;
                if (ovRB_admCscNFCe1.Checked) Value = "1.0";
                else if (ovRB_admCscNFCe2.Checked) Value = "2.0";
                else if (ovRB_admCscNFCe3_1.Checked) Value = "3.1";
                else if (ovRB_admCscNFCe4_0.Checked) Value = "4.00";

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_WEBSERVICE_ADMCSCNFCE, Encoding.Default.GetBytes(Value)))
                    throw new Exception("Não foi possível salvar a Versão do Ambiente de Destino.");

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_PROTOCOLO_SEGURANCA_TIMEOUT, Encoding.Default.GetBytes(ovTXT_TimeOut.Text)))
                    throw new Exception("Não é possível salvar o Protocolo de Segurança.");

                //if (ovRB_SSL3.Checked)
                // if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_PROTOCOLO_SEGURANCA_TLSOUSSL3, Encoding.Default.GetBytes(ovRB_SSL3.Checked ? "0" : "1")))
                //    throw new Exception("Não é possível salvar o Protocolo de Segurança.");


                if (ovRB_SSL3.Checked)
                    if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_PROTOCOLO_SEGURANCA_TLSOUSSL3, Encoding.Default.GetBytes("0")))
                        throw new Exception("Não é possível salvar o Protocolo de Segurança.");
                if (ovRB_TLS.Checked)
                    if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_PROTOCOLO_SEGURANCA_TLSOUSSL3, Encoding.Default.GetBytes("1")))
                        throw new Exception("Não é possível salvar o Protocolo de Segurança.");
                if (ovRB_TLS1_2.Checked)
                    if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_NFCE_PROTOCOLO_SEGURANCA_TLSOUSSL3, Encoding.Default.GetBytes("2")))
                        throw new Exception("Não é possível salvar o Protocolo de Segurança.");
                if (ovRB_Assincrono.Checked)
                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.METODO_SINCRONO, Encoding.Default.GetBytes("0")))
                    throw new Exception("Não é possível salvar o Método de Envio Assincrono.");
                if (ovRB_Sincrono.Checked)
                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.METODO_SINCRONO, Encoding.Default.GetBytes("1")))
                    throw new Exception("Não é possível salvar o Método de Envio Sincrono.");


                PDVControlador.Commit();
                MessageBox.Show(this, "Configurações salvas com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}