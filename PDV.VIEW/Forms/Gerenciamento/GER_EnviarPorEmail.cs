using MetroFramework;
using MetroFramework.Forms;
using NFe.Danfe.Fast.NFCe;
using NFe.Danfe.Fast.NFe;
using NFe.Servicos;
using NFe.Utils.NFe;
using PDV.CONTROLLER.NFCE.Configuracao;
using PDV.CONTROLLER.NFCE.Impressao;
using PDV.CONTROLLER.NFE.Configuracao;
using PDV.CONTROLLER.NFE.Impressao;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Gerenciamento
{
    public partial class GER_EnviarPorEmail : DevExpress.XtraEditors.XtraForm
    {
        private Dictionary<string, string> TAGS
        {
            get
            {
                Dictionary<string, string> Tags = new Dictionary<string, string>();
                Tags.Add("[nomeEmit]", Emitente.NomeFantasia);
                Tags.Add("[nomeDest]", Nfe.infNFe.dest != null ? Nfe.infNFe.dest.xNome : string.Empty);
                Tags.Add("[cnpjEmit]", Emitente.CNPJ);
                Tags.Add("[nNFe]", Nfe.infNFe.ide.nNF.ToString());
                Tags.Add("[serieNFe]", Nfe.infNFe.ide.serie.ToString());
                Tags.Add("[chNFe]", Nfe.infNFe.ide.cNF);
                Tags.Add("[Link]", Nfe.infNFe.Id);
                return Tags;
            }
        }

        private string Xml = null;
        private EmailEmitente Email = null;
        private NFe.Classes.NFe Nfe;
        private DanfeFrNfce danfe = null;
        private DanfeFrNfe danfe_nfe = null;
        private Emitente Emitente = null;
        private bool Cancelada = false;
        private string NOME_TELA = "ENVIAR NFC-E/NFE POR E-MAIL";

        public GER_EnviarPorEmail(string XmlEnvio, bool _Cancelada, Emitente _Emitente, EmailEmitente _Email)
        {
            InitializeComponent();
            Xml = XmlEnvio;

            Emitente = _Emitente;
            Email = _Email;

            Nfe = new NFe.Classes.NFe().CarregarDeXmlString(Xml);


            if (Nfe.infNFe.ide.mod == DFe.Classes.Flags.ModeloDocumento.NFCe)
            {
                ImpressaoNFCe Imp = new ImpressaoNFCe() { CaminhoSolution = Contexto.CaminhoSolution, };
                ConfiguracaoNfce configuracaoNfce = Imp.RetornaConfiguracaoNFce();
                danfe = new DanfeFrNfce(Nfe, configuracaoNfce.ConfiguracaoDanfeNfce, configuracaoNfce.ConfiguracaoCsc.CIdToken, configuracaoNfce.ConfiguracaoCsc.Csc);
            }
            else if (Nfe.infNFe.ide.mod == DFe.Classes.Flags.ModeloDocumento.NFe)
            {
                ImpressaoNFe Imp = new ImpressaoNFe() { CaminhoSolution = Contexto.CaminhoSolution, };
                ConfiguracaoNFe configuracaoNfe = Imp.RetornaConfiguracaoNFe();
                danfe_nfe = new DanfeFrNfe(Nfe, configuracaoNfe.ConfiguracaoDanfeNFe, "Sistema Comercial - Software");
            }
            ovTXT_Email.Text = Nfe.infNFe.dest != null ? Nfe.infNFe.dest.email : string.Empty;
            Cancelada = _Cancelada;
        }

        private void EnviarEmail()
        {
            if (string.IsNullOrEmpty(ovTXT_Email.Text.Trim()))
            {
                MessageBox.Show(this, "Preencha o Campo E-mail.", NOME_TELA);
                return;
            }

            List<string> Destinatarios = new List<string>();
            Destinatarios.Add(ovTXT_Email.Text);

            List<byte[]> Anexos = new List<byte[]>();
            Anexos.Add(Encoding.Default.GetBytes(Xml));

            if (danfe != null)
            {
                danfe.ExportarPdf("danfe.pdf");
                Anexos.Add(File.ReadAllBytes("danfe.pdf"));
                File.Delete("danfe.pdf");
            }
            if (danfe_nfe != null)
            {
                danfe_nfe.ExportarPdf("danfe.pdf");
                Anexos.Add(File.ReadAllBytes("danfe.pdf"));
                File.Delete("danfe.pdf");
            }

            string RetornoEnvio = ZeusUtil.EnviarEmail(new Email()
            {
                Assunto = ReplaceAssuntoEmail(),
                Mensagem = ReplaceMensagemEmail(),
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

        private string ReplaceAssuntoEmail()
        {
            string Assunto = Cancelada ? Email.CancelarAssunto : Email.AutorizarAssunto;

            foreach (var Tag in TAGS)
                Assunto = Assunto.Replace(Tag.Key, Tag.Value);

            return Assunto;
        }

        private string ReplaceMensagemEmail()
        {
            string Mensagem = Cancelada ? Email.CancelarMensagem : Email.AutorizarMensagem;
            foreach (var Tag in TAGS)
                Mensagem = Mensagem.Replace(Tag.Key, Tag.Value);

            return Mensagem;
        }

        private void ovBTN_Cancelar_Click(object sender, System.EventArgs e)
        {
            EnviarEmail();
        }
    }
}
