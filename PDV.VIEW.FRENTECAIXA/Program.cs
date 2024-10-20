using One.Loja.PDV_Manager;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.Forms.Gerenciamento.DAV;
using PDV.VIEW.FRENTECAIXA.App_Context;
using PDV.VIEW.FRENTECAIXA.Forms;
using PDV.VIEW.FRENTECAIXA.Forms.PDV.DAV;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application..
        /// </summary>
        [STAThread]
        static void Main()
       {
            try
            {
                Contexto.SetConfiguracaoPrimaria();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
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
