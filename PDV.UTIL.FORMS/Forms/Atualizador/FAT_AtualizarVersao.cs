using MetroFramework;
using MetroFramework.Forms;
using PDV.DAO.Custom;
using PDV.DAO.Enum;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PDV.UTIL.FORMS.Forms.Atualizador
{
    public partial class  FAT_AtualizarVersao : DevExpress.XtraEditors.XtraForm
    {
        private Thread ThreadDownload = null;
        private VersaoModulo Versao;
        private Modulo Modulo;
        private bool EfetuoDownloadExecutou = false;
        public FAT_AtualizarVersao(Modulo _Modulo, VersaoModulo _Versao)
        {
            InitializeComponent();
            Versao = _Versao;
            Modulo = _Modulo;
        }

        private void FAT_AtualizarVersao_Load(object sender, EventArgs e)
        {
            try
            {
                ovLBL_VersaoAtual.Text = Versao.VersaoAtual.ToString();
                ovBTN_AtualizarVersao.Enabled = false;
                ovTXT_Download.Visible = false;

                ovLBL_VersaoDisponivel.Text = "Verificando Atualização...";
                VerificarAtualizacao();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, "Não foi possível verificar a atualização, Motivo: " + Ex.Message);
            }
        }

        private void VerificarAtualizacao()
        {
            Versao = ZeusUtil.VerificarVersaoDisponivel(Modulo, Versao.VersaoAtual);

            if (Versao.Disponivel)
                ovLBL_VersaoDisponivel.Text = Versao.VersaoDisponivel.ToString();
            else
                ovLBL_VersaoDisponivel.Text = "Nenhuma Versão Disponível...";

            ovPB_Carregando.Visible = false;
            ovBTN_AtualizarVersao.Enabled = Versao.Disponivel;
        }

        private void ovBTN_AtualizarVersao_Click(object sender, EventArgs e)
        {
            ovBTN_AtualizarVersao.Enabled = false;
            ovPB_Carregando.Visible = true;
            ovTXT_Download.Visible = true;
            ovTXT_Download.Text = "Efetuando Download da atualização. Aguarde...";
            try
            {
                ThreadDownload = new Thread(ThreadDownloadExecute);
                ThreadDownload.Start();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Erro");
                ovBTN_AtualizarVersao.Enabled = true;
            }
        }

        private void ThreadDownloadExecute()
        {
            string _Path = Path.GetFullPath(".");

            if (ZeusUtil.GetDownloadFile(Modulo, Versao.VersaoDisponivel))
            {
                ZeusUtil.DescompactaVersao(Modulo, Versao.VersaoDisponivel);
                ZeusUtil.AtualizaBancoVersao(Modulo, Versao.VersaoDisponivel); //Quem Chamar, é Obrigatório abrir transação.

                Process.Start($"{_Path}\\Atualizacoes\\{Modulo.ToString()}\\{Versao.VersaoDisponivel.ToString()}\\{ZeusUtil.GetNomeInstaladorVersion(Modulo)}");

                if (File.Exists($"{_Path}\\{Modulo.ToString()}_{Versao.VersaoDisponivel.ToString()}.zip"))
                    File.Delete($"{_Path}\\{Modulo.ToString()}_{Versao.VersaoDisponivel.ToString()}.zip");

                if (File.Exists($"{_Path}\\Atualizacoes\\{Modulo.ToString()}\\{Versao.VersaoDisponivel.ToString()}\\SQL.SQL"))
                    File.Delete($"{_Path}\\Atualizacoes\\{Modulo.ToString()}\\{Versao.VersaoDisponivel.ToString()}\\SQL.SQL");

                /* Deletando .DLL do FastReport */
                //if (File.Exists(Path.GetFullPath(".") + "\\FastReport.dll"))
                //    File.Delete(Path.GetFullPath(".") + "\\FastReport.dll");
                //
                //if (File.Exists(Path.GetFullPath(".") + "\\FastReport.Editor.dll"))
                //    File.Delete(Path.GetFullPath(".") + "\\FastReport.Editor.dll");
                //
                //if (File.Exists(Path.GetFullPath(".") + "\\FastReport.Bars.dll"))
                //    File.Delete(Path.GetFullPath(".") + "\\FastReport.Bars.dll");

                Thread.Sleep(1000);
                EfetuoDownloadExecutou = true;
                if (ThreadDownload.IsAlive)
                    ThreadDownload.Abort();
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Escape):
                    Close();
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void ovTimer_Tick(object sender, EventArgs e)
        {
            if (EfetuoDownloadExecutou)
            {
                if (ThreadDownload.IsAlive)
                    ThreadDownload.Abort();

                Close();

                if (Parent != null)
                    (Parent as MetroForm).Close();

                Application.ExitThread();
                Application.Exit();
            }
        }
    }
}