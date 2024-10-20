using PDV.DAO.DB.Utils;
using PDV.NFCE.MOTORCONTINGENCIA.App_Context;
using PDV.UTIL.FORMS;
using PDV.VIEW.Forms.Configuracoes;
using PDV.VIEW.Tarefas_do_Sistema;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.NFCE.MOTORCONTINGENCIA
{
    
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application..
        /// </summary>.
        [STAThread]
        static void Main()
        {
            Contexto.SetConfiguracaoPrimaria();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IniFile iniFile = new IniFile(Contexto.CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW\\App_Data\\Start.ini" : "\\App_Data\\Start.ini"));
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            try
            {
                connectionStringsSection.ConnectionStrings["ModelAppForcaVendas"].ConnectionString = iniFile.GetValue("Conexao_PDV", "stringconexaoforcavendas");
                connectionStringsSection.ConnectionStrings["ModelAppEstoque"].ConnectionString = iniFile.GetValue("Conexao_PDV", "stringconexaoappestoque");
            }
            catch (Exception)
            {


            }

            //  Task.Run((Action)(Tarefas.RunMonitoramento));

            //Task.Run((Action)(PainelInicial));

            // Application.Run(new TarefasForm());
            Application.Run(new PainelInicial());
        }
    }
}
