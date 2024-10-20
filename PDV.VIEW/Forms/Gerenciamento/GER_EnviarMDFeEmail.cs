using DFe.Utils;
using MDFe.Classes.Retorno;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Gerenciamento
{
    public partial class GER_EnviarMDFeEmail : DevExpress.XtraEditors.XtraForm
    {
        private string Xml = null;
        private MDFeProcMDFe MDFe;
        private string NOME_TELA = "ENVIAR MDF-E POR E-MAIL";

        public GER_EnviarMDFeEmail(string XmlEnvio)
        {
            InitializeComponent();
            Xml = XmlEnvio;
            MDFe = FuncoesXml.XmlStringParaClasse<MDFeProcMDFe>(Xml);
        }

        private void EnviarEmail()
        {
            if (string.IsNullOrEmpty(ovTXT_Email.Text.Trim()))
            {
                MessageBox.Show(this, "Preencha o Campo E-mail.", NOME_TELA);
                return;
            }

            Emitente Emitente = FuncoesEmitente.GetEmitente();

            List<string> Destinatarios = new List<string>();
            Destinatarios.Add(ovTXT_Email.Text);

            List<byte[]> Anexos = new List<byte[]>();
            Anexos.Add(Encoding.Default.GetBytes(Xml));

            string RetornoEnvio = ZeusUtil.EnviarEmail(new Email()
            {
                Assunto = $"MDF-E Emitente: [{Emitente.CNPJ} - {Emitente.NomeFantasia}] - [DUE ERP]",
                Mensagem = $@"Um Manifesto de Documento Fiscal Eletrônico foi emitida em seu nome pela empresa {Emitente.NomeFantasia}, CNPJ: {Emitente.CNPJ}.
Nº da do MDFe: {MDFe.MDFe.InfMDFe.Ide.NMDF}
Série da NF-e: {MDFe.MDFe.InfMDFe.Ide.Serie}
Chave de Acesso: {MDFe.ProtMDFe.InfProt.ChMDFe}

Em caso de dúvida entre em contato com a empresa emitente deste MDFe.",
                EmailDestinatario = Destinatarios,
                Anexos = Anexos,
            }, Contexto.USUARIOLOGADO.Nome);

            if (RetornoEnvio.Equals("OK"))
            {
                MessageBox.Show(this, "Enviado com Sucesso.", NOME_TELA);
                Close();
            }
            else
                MessageBox.Show(this, RetornoEnvio, NOME_TELA);
        }

        private void ovBTN_Cancelar_Click(object sender, EventArgs e)
        {
            EnviarEmail();
        }
    }
}
