using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.UTIL.FORMS.Forms;
using PDV.VIEW;
using PDV.VIEW.App_Context;
using PDV.VIEW.FRENTECAIXA.Forms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace One.Loja.PDV_Manager
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
           ArredondaCantosdoForm();

            var bitmapSair = IconChar.DoorOpen.ToBitmap(Color.SteelBlue, 30);
            var bitmapConfigurar = IconChar.Cogs.ToBitmap(Color.SteelBlue, 30);
            var bitmapLiberacao = IconChar.Lock.ToBitmap(Color.SteelBlue, 30);
            var bitmapPdv = IconChar.CashRegister.ToBitmap(Color.SteelBlue, 90);
            var bitmapRetaguarda = IconChar.ChalkboardTeacher.ToBitmap(Color.SteelBlue, 90);

            btnSairFooter.ImageOptions.Image = bitmapSair;
            btnConfig.ImageOptions.Image = bitmapConfigurar;
            btnLiberacao.ImageOptions.Image = bitmapLiberacao;
            lblMac.TileImage = bitmapPdv;
            metroTile2.TileImage = bitmapRetaguarda;



        }
      

        public void AtualizarParametrosFIxos()
        {
        }

        private void frmEVOONE_Load(object sender, EventArgs e)
        {
            ArredondaCantosdoForm();


            if (ConexaoInternet.ExisteConexao())
            {
                ststausInternetLabel.Text = "ON LINE";
                ststausInternetLabel.BackColor = Color.Green;
                ststausInternetLabel.ForeColor = Color.White;
            }
            else
            {
                ststausInternetLabel.Text = "OFF LINE";
                ststausInternetLabel.BackColor = Color.Red;
                ststausInternetLabel.ForeColor = Color.White;
            }

            string macAddr =
                                (
                                    from nic in NetworkInterface.GetAllNetworkInterfaces()
                                    where nic.OperationalStatus == OperationalStatus.Up
                                    select nic.GetPhysicalAddress().ToString()
                                ).FirstOrDefault();
            //SplashScreenManager.ShowForm(typeof(slapshOnePDV));
            label1.Text = macAddr.ToString();
        }

        
        private void metroTile2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                Contexto.SetConfiguracaoPrimaria();
                Contexto.VERSAO = new Version(System.Diagnostics.FileVersionInfo.GetVersionInfo(Path.GetFullPath(".") + "/Due ERP.exe").ProductVersion);
                PDV.UTIL.FORMS.Forms.Login Log = new PDV.UTIL.FORMS.Forms.Login(Contexto.VERSAO.ToString(), "DUE ERP");
          
                
                Log.ovTXT_Login.Select();
                Log.ovTXT_Versao.Text = "Versão: " + Contexto.VERSAO;

                Configuracao config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_LOGIN_USUARIO_LEMBRAR);
                if (config != null)
                    Log.ovTXT_Login.Text = Encoding.UTF8.GetString(config.Valor);
                System.Windows.Forms.Cursor.Current = Cursors.Default;

/*
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    Log.ovTXT_Senha.Text = "1234";
                }*/

                Log.ShowDialog();

               



                if (Log.Logado != null)
                {
                    if (Log.Logado.Root == 1)
                    {
                        Contexto.USUARIOLOGADO = Log.Logado;
                        Contexto.ITENSMENU = null;
                        Contexto.TELA_LOGIN = Log;
                        Contexto.TELA_LOGIN.Visible = false;
                        this.Hide();
                        Principal gPDV_PainelInicial = new Principal();
                        gPDV_PainelInicial.FormClosing += TelasPrincipaisFormClosing;
                        gPDV_PainelInicial.ShowDialog();
                    }
                    else
                    {
                        FuncoesMaquina.Salvar(new Maquina(Log.ovCKB_Lembrar.Checked ? Log.Logado.Login : ""));
                        ZeusUtil.LembrarSenha(Log.ovCKB_Lembrar.Checked ? Log.Logado.Login : string.Empty, Log.ovCKB_Lembrar.Checked ? Log.Logado.Senha : string.Empty);
                        Contexto.USUARIOLOGADO = Log.Logado;
                        Contexto.ITENSMENU = FuncoesPerfilAcesso.GetItensMenuPorPerfilAcesso(Log.Logado.IDPerfilAcesso);
                        Contexto.TELA_LOGIN = Log;
                        Contexto.TELA_LOGIN.Visible = false;
                        string perfil = Log.Logado.PerfilAcesso.ToString();
                        this.Hide();
                        Principal gPDV_PainelInicial = new Principal();
                        gPDV_PainelInicial.FormClosing += TelasPrincipaisFormClosing;
                        gPDV_PainelInicial.ShowDialog();
                    }
                }
               
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Cursor.Current = Cursors.Default;
                MessageBox.Show("" + ex.Message, " RootSys Software", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                Application.ExitThread();
                Application.Exit();
               
            }


        }




        private void metroTile1_Click(object sender, EventArgs e)
        {

            try
            {
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                PDV.VIEW.FRENTECAIXA.App_Context.Contexto.SetConfiguracaoPrimaria();
                PDV.VIEW.FRENTECAIXA.App_Context.Contexto.VERSAO = new Version(System.Diagnostics.FileVersionInfo.GetVersionInfo(Path.GetFullPath(".") + "/Due PDV.exe").ProductVersion);
                PDV.UTIL.FORMS.Forms.Login Log = new PDV.UTIL.FORMS.Forms.Login(PDV.VIEW.FRENTECAIXA.App_Context.Contexto.VERSAO.ToString(), "DUE PDV");
                Log.ovTXT_Login.Select();
                Log.ovTXT_Versao.Text = "Versão: " + PDV.VIEW.FRENTECAIXA.App_Context.Contexto.VERSAO;

                Configuracao config = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_LOGIN_USUARIO_LEMBRAR);
                if (config != null)
                    Log.ovTXT_Login.Text = Encoding.UTF8.GetString(config.Valor);
                System.Windows.Forms.Cursor.Current = Cursors.Default;

/*
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    Log.ovTXT_Senha.Text = "1234";
                }*/


                Log.ShowDialog();


           

                if (Log.Logado != null)
                {
                    if (Log.Logado.Root == 1)
                    {
                        PDV.VIEW.FRENTECAIXA.App_Context.Contexto.USUARIOLOGADO = Log.Logado;
                        PDV.VIEW.FRENTECAIXA.App_Context.Contexto.ITENSMENU = null;
                        PDV.VIEW.FRENTECAIXA.App_Context.Contexto.TELA_LOGIN = Log;
                        PDV.VIEW.FRENTECAIXA.App_Context.Contexto.TELA_LOGIN.Visible = false;
                        this.Hide();
                        GPDV_PainelInicial gPDV_PainelInicial = new GPDV_PainelInicial();
                        gPDV_PainelInicial.FormClosing += TelasPrincipaisFormClosing;
                        gPDV_PainelInicial.ShowDialog();
                    }
                    else
                    {
                        ZeusUtil.LembrarSenha(Log.ovCKB_Lembrar.Checked ? Log.Logado.Login : string.Empty, Log.ovCKB_Lembrar.Checked ? Log.Logado.Senha : string.Empty);
                        PDV.VIEW.FRENTECAIXA.App_Context.Contexto.USUARIOLOGADO = Log.Logado;
                        PDV.VIEW.FRENTECAIXA.App_Context.Contexto.ITENSMENU = FuncoesPerfilAcesso.GetItensMenuPorPerfilAcesso(Log.Logado.IDPerfilAcesso);
                        PDV.VIEW.FRENTECAIXA.App_Context.Contexto.TELA_LOGIN = Log;
                        PDV.VIEW.FRENTECAIXA.App_Context.Contexto.TELA_LOGIN.Visible = false;
                        string perfil = Log.Logado.PerfilAcesso.ToString();
                        this.Hide();
                        GPDV_PainelInicial gPDV_PainelInicial = new GPDV_PainelInicial();
                        gPDV_PainelInicial.FormClosing += TelasPrincipaisFormClosing;
                        gPDV_PainelInicial.ShowDialog();
                    }
                }
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Cursor.Current = Cursors.Default;
                MessageBox.Show("Erro 3314: Sem Comunicação com a licenção ou acesso de permissão!" + ex.Message, "RootSys ERP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                Application.ExitThread();
                Application.Exit();
             
            }



        }

        private void TelasPrincipaisFormClosing(object sender, FormClosingEventArgs e) => Show();

        private void button2_Click(object sender, EventArgs e)
        {
            ConfiguracaoSistema configuracaoSistema = new ConfiguracaoSistema();
            configuracaoSistema.ShowDialog();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            try
            {
               
                MessageBox.Show("Não disponivél no pacote!");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro 3314: Sem Comunicação com a licenção ou acesso de permissão!" + ex.Message, ">>>One PDV EVO<<<<<<<<<<<<", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmTermoDeAcordo frm = new frmTermoDeAcordo();
            frm.ShowDialog();
            frm = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            System.Diagnostics.Process.Start("http://onepdv.com");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=-2TV3NDWRNc&t=12s");
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://onedesenvolvimento.com");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.rootsys.com.br");
        }

        private void btnLiberacao_Click(object sender, EventArgs e)
        {
            PDV.UTIL.FORMS.frmBloqueio frmBloqueio = new PDV.UTIL.FORMS.frmBloqueio();
            frmBloqueio.ShowDialog();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            ConfiguracaoSistema configuracaoSistema = new ConfiguracaoSistema();
            configuracaoSistema.ShowDialog();
        }

        private void btnSairFooter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public void ArredondaCantosdoForm()
        {
            GraphicsPath PastaGrafica = new GraphicsPath();
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(1, 1, this.Size.Width, this.Size.Height));

            //Arredondar canto superior esquerdo        
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(1, 1, 10, 10));
            PastaGrafica.AddPie(1, 1, 20, 20, 180, 90);

            //Arredondar canto superior direito
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(this.Width - 12, 1, 12, 13));
            PastaGrafica.AddPie(this.Width - 24, 1, 24, 26, 270, 90);

            //Arredondar canto inferior esquerdo
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(1, this.Height - 10, 10, 10));
            PastaGrafica.AddPie(1, this.Height - 20, 20, 20, 90, 90);

            //Arredondar canto inferior direito
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(this.Width - 12, this.Height - 13, 13, 13));
            PastaGrafica.AddPie(this.Width - 24, this.Height - 26, 24, 26, 0, 90);

            PastaGrafica.SetMarkers();
            this.Region = new Region(PastaGrafica);


            //ovTXT_Login.Region = new Region(PastaGrafica);
            //ovTXT_Senha.Region = new Region(PastaGrafica);
        }



    }
}
