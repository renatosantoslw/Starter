using DueLicence;
using MetroFramework;
using Newtonsoft.Json;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.VIEW.Tarefas_do_Sistema;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Criptografia = PDV.DAO.DB.Utils.Criptografia;
using FontAwesome.Sharp;

namespace PDV.UTIL.FORMS.Forms
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        private IniFile iniFile = null;
        public Usuario Logado = null;

        public Login(string Versao, string Modulo)
        {
            
            InitializeComponent();

            this.pictureBox2.Location = new System.Drawing.Point(555, 206);
            this.pictureBox3.Location = new System.Drawing.Point(555, 273);
            this.pictureBox2.Size = new System.Drawing.Size(29, 23);
            this.pictureBox3.Size = new System.Drawing.Size(29, 23);

            this.pictureBox1DuePDV.Location = new System.Drawing.Point(12, 62);
            this.pictureBox1DuePDV.Name = "pictureBox1DuePDV";
            this.pictureBox1DuePDV.Size = new System.Drawing.Size(327, 272);
            this.pictureBox1DuePDV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        
            this.pictureBox1DueERP.Location = new System.Drawing.Point(12, 62);
            this.pictureBox1DueERP.Name = "pictureBox1DueERP";
            this.pictureBox1DueERP.Size = new System.Drawing.Size(327, 272);
            this.pictureBox1DueERP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;


            var bitmapSair = IconChar.DoorOpen.ToBitmap(Color.SteelBlue, 30);
            var bitmapConfigurar = IconChar.Cogs.ToBitmap(Color.SteelBlue, 30);
            var bitmapLiberacao = IconChar.Lock.ToBitmap(Color.SteelBlue, 30);
            var bitmapLogin = IconChar.UserAlt.ToBitmap(Color.SteelBlue, 25);
            var bitmapSenha = IconChar.Lock.ToBitmap(Color.SteelBlue, 25);

            btnSairFooter.ImageOptions.Image = bitmapSair;
            btnConfig.ImageOptions.Image = bitmapConfigurar;
            simpleButton2.ImageOptions.Image = bitmapLiberacao;

            pictureBox2.Image = bitmapLogin;
            pictureBox3.Image = bitmapSenha;





            iniFile = new IniFile(ContextoUtil.CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW\\App_Data\\Start.ini" : "\\App_Data\\Start.ini"));
            ovTXT_Login.Select();
            ovTXT_Versao.Text = "Versão: " + Versao;
            if (Modulo.Contains("DUE ERP"))
            {
                pictureBox1DueERP.Visible = true;
                pictureBox1DuePDV.Visible = false;
            }
            else
            {
                pictureBox1DueERP.Visible = false;
                pictureBox1DuePDV.Visible = true;
            }
            CarregarConfiguracoesLembrar();
            ArredondaCantosdoForm();
        }
        
        public void FazerBakupAoLogarEConfigurarAPP()
        {
            try
            {
                string servidor = iniFile.GetValue("Conexao_PDV", "servidor");
                string porta = iniFile.GetValue("Conexao_PDV", "porta");
                string banco = iniFile.GetValue("Conexao_PDV", "banco");
                string usuario = iniFile.GetValue("Conexao_PDV", "usuario");
                string senha = Criptografia.DecodificaSenha(iniFile.GetValue("Conexao_PDV", "senha"));
                string caminhoorigem = iniFile.GetValue("Conexao_PDV", "caminhoorigempostgreeSql");
                string caminhodesetino = iniFile.GetValue("Conexao_PDV", "caminhodestinobackup");
                if (servidor.Contains("localhost"))
                FuncaoBackup.PostgreSqlDump(caminhoorigem, caminhodesetino + "Backup" + banco, servidor, porta, banco, usuario, senha);
               
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                try
                {
                    connectionStringsSection.ConnectionStrings["ModelAppForcaVendas"].ConnectionString = iniFile.GetValue("Conexao_PDV", "stringconexaoforcavendas");
                    connectionStringsSection.ConnectionStrings["ModelAppEstoque"].ConnectionString = iniFile.GetValue("Conexao_PDV", "stringconexaoappestoque");
                    connectionStringsSection.ConnectionStrings["ContextoBaseProdutos"].ConnectionString = iniFile.GetValue("Conexao_PDV", "stringconexaobaseprodutos");
                    //connectionStringsSection.ConnectionStrings["ContextMataFome"].ConnectionString = iniFile.GetValue("Conexao_PDV", "stringconexaomatafomedelivery");

                }
                catch (Exception)
                {

                   
                }
                
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao fazer o backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            btnSair.Region = new Region(PastaGrafica);
            btnLogar.Region = new Region(PastaGrafica);

            //ovTXT_Login.Region = new Region(PastaGrafica);
            //ovTXT_Senha.Region = new Region(PastaGrafica);
        }

        private void CarregarConfiguracoesLembrar()
        {
            var maquina = FuncoesMaquina.GetMaquina(Dns.GetHostName());
            if (maquina != null)
                ovTXT_Login.Text = maquina.UltimoLogin;
        }

        private void ovBTN_Entrar_Click(object sender, EventArgs e)
        {
            Logar();
        }

        private void LembrarSenha(string Usuario, string Senha)
        {
            try
            {
                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_LOGIN_USUARIO_LEMBRAR, Encoding.Default.GetBytes(Usuario)))
                {
                    throw new Exception("Não foi possível salvar a configuração de lembrar Login/Senha.");
                }

                if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_LOGIN_SENHA_LEMBRAR, Encoding.Default.GetBytes(Senha)))
                {
                    throw new Exception("Não foi possível salvar a configuração de lembrar Login/Senha.");
                }
            }
            catch (Exception Ex)
            {
                ovTXT_StatusLogin.Text = Ex.Message;
            }
        }

        private void ovTXT_Senha_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Logar();
            }
        }

        public void Alert(string texto)
        {
            MessageBox.Show(texto, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public async void Logar()
        {
            try
            {
                var login = ovTXT_Login.Text.Trim();
                var senha = ovTXT_Senha.Text.Trim();


                if (string.IsNullOrEmpty(login))
                {
                    ovTXT_StatusLogin.Text = "Informe o Login.";
                    ovTXT_Login.Select();
                    Alert("Informe o Login.");
                    return;
                }

                if (string.IsNullOrEmpty(ovTXT_Senha.Text.Trim()))
                {
                    ovTXT_StatusLogin.Text = "Informe a Senha.";
                    ovTXT_Senha.Select();
                    Alert("Informe a Senha.");
                    return;
                }

                ovTXT_StatusLogin.Text = "";
                FazerBakupAoLogarEConfigurarAPP();
                Logado = FuncoesUsuario.GetUsuarioRoot(login, Criptografia.CodificaSenha(senha));
                if (Logado != null)
                {
                    Close();
                }
                else
                {
                    Logado = FuncoesUsuario.GetUsuarioPorLoginESenha(login, Criptografia.CodificaSenha(senha));
                   
                    /*
                    if (await ControllerLicense.VerificarBloqueiLicença() == false)
                    {                      
                        Hide();
                        frmBloqueio frmBloqueio = new frmBloqueio();
                        frmBloqueio.ShowDialog();
                    }
                    */
                    if (Logado == null)
                    {
                        ovTXT_StatusLogin.Text = "Email ou Senha Incorreto.";
                        Alert("Email ou Senha Incorreto.");
                        ovTXT_Senha.Text = String.Empty;
                        Logado = null;
                        return;
                    }
                    else
                    {
                     
                        FazerBakupAoLogarEConfigurarAPP();
                        string motor = iniFile.GetValue("Conexao_PDV", "motorAPP");
                        
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {

                ovTXT_StatusLogin.Text = ex.Message;
                Alert(ex.Message);
                Logado = null;
                this.Hide();
                frmBloqueio frmBloqueio = new frmBloqueio();
                frmBloqueio.ShowDialog();
                return;

            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            //VerificarBloqueiLicença();
            ArredondaCantosdoForm();


            //if (System.Diagnostics.Debugger.IsAttached)
            //{
            //    Logar();
            //}

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            
            Logar();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmBloqueio frmBloqueio = new frmBloqueio();
            frmBloqueio.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AlterarSenha alterarSenha = new AlterarSenha(ovTXT_Login.Text);
            alterarSenha.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblShortDate.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }

       

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            System.Diagnostics.Process.Start(path + "\\Atualizador\\Atualizador WEB.exe");

        }

        private void ovTXT_Login_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Shown(object sender, EventArgs e)
        {
            ArredondaCantosdoForm();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            ConfiguracaoSistema configuracaoSistema = new ConfiguracaoSistema();
            configuracaoSistema.ShowDialog();
        }

        private void btnSairFooter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}