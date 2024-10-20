using DFe.Classes.Flags;
using MetroFramework.Forms;
using NFe.Classes;
using NFe.Classes.Informacoes.Transporte;
using NFe.Classes.Servicos.Autorizacao;
using NFe.Classes.Servicos.Tipos;
using NFe.Servicos;
using NFe.Servicos.Retorno;
using NFe.Utils;
using NFe.Utils.InformacoesSuplementares;
using NFe.Utils.NFe;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.Entidades;
using PDV.NFCE.MOTORCONTINGENCIA.App_Context;
using PDV.UTIL.FORMS.Forms.Atualizador;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PDV.NFCE.MOTORCONTINGENCIA
{
    public partial class PainelInicial : MetroForm
    {
        private Thread TH_CONTINGENCIA = null;
        private static decimal QtdAtutorizada = 0;
        private static decimal QtdTransmitida = 0;

        public PainelInicial()
        {
            InitializeComponent();
            ovTXT_Status.Text = "[Em Operação]";
            ovTXT_Inicio.Text = DateTime.Now.ToString();

            ovTXT_Versao.Text = "Versão: v" + System.Diagnostics.FileVersionInfo.GetVersionInfo(Path.GetFullPath(".") + "/PDV.NFCE.MOTORCONTINGENCIA.exe").ProductVersion;
            ovTXT_Rodape.Text = string.Format("Copyright ©  {0} - Todos os Direitos Reservados  RootSys ", DateTime.Now.Year);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* Minimizando aplicação na bandeja do windows */
            Visible = false;
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;

            notifyIcon.Text = "[RootSys NFCe ] - NFC-e Contingência";

            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(1500, "RootSys - Contingência", "Motor de envio de NFC-e em contingência continua ativo na bandeja.", ToolTipIcon.Info);
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            /* Exibindo novamente o programa */
            Visible = true;
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            notifyIcon.Visible = false;
        }

        private void PainelInicial_Load(object sender, EventArgs e)
        {
            notifyIcon.Visible = true;
            WindowState = FormWindowState.Normal;
            TH_CONTINGENCIA = new Thread(IniciarMotor);
            TH_CONTINGENCIA.Start();
        }

        static void IniciarMotor()
        {
            Configuracao Config_Tempo = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOCONTINGENCIA_TEMPOINTERVALO_MOTOR);
            int TempoSleepMS = Config_Tempo != null ? Convert.ToInt32(Encoding.UTF8.GetString(Config_Tempo.Valor)) : 600000;

            while (true)
            {
                DataTable DTNFCE = FuncoesMovimentoFiscal.GetNFCEContingencia_MotorEnvio(Convert.ToDecimal(Contexto.CONFIG_NFCe.CfgServico.tpAmb), Convert.ToInt32(Contexto.CONFIG_NFCe.CfgServico.ModeloDocumento));
                
                
                
                if (DTNFCE != null && DTNFCE.Rows.Count > 0)
                    foreach (DataRow drNFCe in DTNFCE.Rows)
                        Transmitir(drNFCe);

                Thread.Sleep(TempoSleepMS);
            }
        }

        static void Transmitir(DataRow drNFCe)
        {
            decimal IDMovimentoFiscal = Convert.ToDecimal(drNFCe["IDMOVIMENTOFISCAL"]);
            try
            {
                NFe.Classes.NFe _nfeContingencia = new NFe.Classes.NFe().CarregarDeXmlString(Encoding.UTF8.GetString(drNFCe["XMLENVIO"] as byte[]));

                Configuracao config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOCONTINGENCIA_JUSTIFICATIVA);
                if (config == null)
                    return;

                _nfeContingencia.infNFe.ide.xJust = config == null ? string.Empty : Encoding.UTF8.GetString(config.Valor);

                _nfeContingencia.infNFe.versao = Conversao.VersaoServicoParaString(Contexto.CONFIG_NFCe.CfgServico.VersaoNFeAutorizacao);
                //ide = GetIdentificacao(numero, modelo, versao),
                _nfeContingencia.infNFe.emit = Contexto.CONFIG_NFCe.Emitente;
                _nfeContingencia.infNFe.transp = new transp() { modFrete = ModalidadeFrete.mfSemFrete };

                //não precisa validar aqui, pois o lote será validado em ServicosNFe.NFeAutorizacao
                //A URL do QR-Code deve ser gerada em um objeto nfe já assinado, pois na URL vai o DigestValue que é gerado por ocasião da assinatura
                /*  _nfeContingencia.infNFeSupl = new infNFeSupl() 

                  { urlChave = _nfeContingencia.infNFeSupl.ObterUrlConsulta(_nfeContingencia, VersaoQrCode.QrCodeVersao2), qrCode = _nfeContingencia.infNFeSupl.ObterUrlQrCode(_nfeContingencia, Contexto.CONFIG_NFCe.ConfiguracaoDanfeNfce.VersaoQrCode, Contexto.CONFIG_NFCe.ConfiguracaoCsc.CIdToken, Contexto.CONFIG_NFCe.ConfiguracaoCsc.Csc) }; //Define a URL do QR-Code.
                  */

                _nfeContingencia.Assina();

                _nfeContingencia.Valida();

                if (_nfeContingencia.infNFe.ide.mod == ModeloDocumento.NFCe)
                {
                    infNFeSupl supl = new infNFeSupl
                    {
                        urlChave = _nfeContingencia.infNFeSupl.ObterUrlConsulta(_nfeContingencia, VersaoQrCode.QrCodeVersao2)
                    };
                    _nfeContingencia.infNFeSupl = supl;
                    _nfeContingencia.infNFeSupl.qrCode = _nfeContingencia.infNFeSupl.ObterUrlQrCode(_nfeContingencia, VersaoQrCode.QrCodeVersao2, Contexto.CONFIG_NFCe.ConfiguracaoCsc.CIdToken, Contexto.CONFIG_NFCe.ConfiguracaoCsc.Csc);
                }


       

                var servicoNFe = new ServicosNFe(Contexto.CONFIG_NFCe.CfgServico);
               
                var pedEnvio = new enviNFe4("ZeusPDVWTSoftware", 1, IndicadorSincronizacao.Sincrono, new List<NFe.Classes.NFe> { _nfeContingencia });

                RetornoNFeAutorizacao retornoEnvio = null;
                try
                { // Se chegou até aqui é por que a nota é válida..
                    retornoEnvio = servicoNFe.NFeAutorizacao(1, IndicadorSincronizacao.Sincrono, new List<NFe.Classes.NFe> { _nfeContingencia }, false /*Envia a mensagem compactada para a SEFAZ*/);
                }
                catch { return; }

                if (!FuncoesMovimentoFiscal.AtualizarMovimentoPorID(new MovimentoFiscal()
                {
                    IDMovimentoFiscal = IDMovimentoFiscal,
                    Cancelada = 0,
                    cStat = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.cStat : retornoEnvio.Retorno.protNFe.infProt.cStat,
                    DataRecebimento = retornoEnvio.Retorno.dhRecbto,
                    DataEmissao = DateTime.Now.ToLocalTime(),//Convert.ToDateTime(_nfeContingencia.infNFe.ide.dhEmi),
                    Emitida = 1,
                    xMotivo = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.xMotivo : retornoEnvio.Retorno.protNFe.infProt.xMotivo,
                    Chave = _nfeContingencia.infNFe.Id,
                    XMLEnvio = Encoding.Default.GetBytes(retornoEnvio.EnvioStr),
                    XMLRetorno = Encoding.Default.GetBytes(retornoEnvio.RetornoStr),
                    Contingencia = 1
                }))
                    throw new Exception("Não foi possível salvar a NFC-e.");

                decimal stat = retornoEnvio.Retorno.protNFe == null ? retornoEnvio.Retorno.cStat : retornoEnvio.Retorno.protNFe.infProt.cStat;
                if (stat == 100)
                    QtdAtutorizada++;

                QtdTransmitida++;
            }
            catch { }
        }

        private void PainelInicial_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TH_CONTINGENCIA != null)
                if (TH_CONTINGENCIA.IsAlive)
                    TH_CONTINGENCIA.Abort();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ovTXT_QtdTransmitida.Text = QtdTransmitida.ToString("n0");
            ovTXT_Qtd_Autorizada.Text = QtdAtutorizada.ToString("n0");
        }

        private void minimizarNaBandejaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Minimizando aplicação na bandeja do windows */
            Visible = false;
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;

            notifyIcon.Text ="RootSys - NFC-e Contingência";

            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(1500,"RootSys - Contingência", "Motor de envio de NFC-e em contingência do Zeus ERP continua ativo na bandeja.", ToolTipIcon.Info);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TH_CONTINGENCIA.IsAlive)
                TH_CONTINGENCIA.Abort();
            Application.ExitThread();
            Application.Exit();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Sobre().ShowDialog(this);
        }

        private void verificarAtualizaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAT_AtualizarVersao Form = new FAT_AtualizarVersao(DAO.Enum.Modulo.CONTINGENCIA_NFCE, new VersaoModulo()
            {
                VersaoAtual = new Version(System.Diagnostics.FileVersionInfo.GetVersionInfo(Path.GetFullPath(".") + "/PDV.NFCE.MOTORCONTINGENCIA.exe").ProductVersion),
                VersaoDisponivel = null,
            });

           // Form.ShowDialog(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}