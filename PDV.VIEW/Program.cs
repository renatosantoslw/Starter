using Newtonsoft.Json;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Tarefas_do_Sistema;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            try
            {                

                Cursor.Current = Cursors.WaitCursor;
                Contexto.SetConfiguracaoPrimaria();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Contexto.VERSAO = new Version(System.Diagnostics.FileVersionInfo.GetVersionInfo(Path.GetFullPath(".") + "/Due ERP.exe").ProductVersion);

                UTIL.FORMS.Forms.Login Log = new UTIL.FORMS.Forms.Login(Contexto.VERSAO.ToString(), "DUE ERP");

                Log.ovTXT_Login.Select();

                Log.ovTXT_Versao.Text = "Versão: " + Contexto.VERSAO;

                Application.Run(Log);                

                if (Log.Logado != null)
                {
                    if (Log.Logado.Root == 1)
                    {
                        Cursor.Current = Cursors.Default;
                        Contexto.USUARIOLOGADO = Log.Logado;
                        Contexto.ITENSMENU = null;
                        Contexto.TELA_LOGIN = Log;
                        Contexto.TELA_LOGIN.Visible = false;
                        Application.Run(new Principal());
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        FuncoesMaquina.Salvar(new Maquina(Log.ovCKB_Lembrar.Checked ? Log.Logado.Login : ""));

                        Contexto.USUARIOLOGADO = Log.Logado;
                        Contexto.ITENSMENU = FuncoesPerfilAcesso.GetItensMenuPorPerfilAcesso(Log.Logado.IDPerfilAcesso);
                        Contexto.TELA_LOGIN = Log;
                        Contexto.TELA_LOGIN.Visible = false;
                        Application.Run(new Principal());
                       
                    }
                }
                else
                    Application.Exit();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Erro ao inicializar o sistema!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}
