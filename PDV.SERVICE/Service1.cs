using PDV.SERVICE.App_Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace PDV.SERVICE
{
    public partial class Service1 : ServiceBase
    {
        
        private TaskInfo taskEnviarEmail;
        private TaskInfo taskRecalcularHandling;
        private TaskInfo taskBackupLocal;
        private TaskInfo taskEnviarXMLDUE;
        private TaskInfo taskBaixarDados;
        private TaskInfo taskEnviarDados;
        private log4net.ILog logger;
        string ftpServerIP = "ftp.DUE.com.br";
        string ftpUserID = "vanderlei";
        string ftpPassword = "padrao@123";
        string remoteDirectory = "";
        string localDestnDir = "\\atualizacao";
        public Service1()
        {
            InitializeComponent();
        }

        public void IniciaServico()
        {
            log4net.Config.XmlConfigurator.Configure();
            logger = log4net.LogManager.GetLogger("LogInFile");
            logger.Info("Inicio Serviço");

            int tempoBackupLocal = 10; //int.Parse(ConfigurationManager.AppSettings["tempoEnviarEmail"].ToString());
            if (tempoBackupLocal > 0)
            {
                this.taskBackupLocal = new TaskInfo("BackupLocal", 0);
                this.taskBackupLocal.Handle = ThreadPool.RegisterWaitForSingleObject(
                    this.taskBackupLocal.TaskEvent,
                    new WaitOrTimerCallback(WaitProcBackupLocal),
                    this.taskBackupLocal,
                    tempoBackupLocal * 1000,
                    //paramNfe.QtdSegEnvioLote * 1000,
                    false
                );
            }
        }

        private void WaitProcBackupLocal(object state, bool timedOut)
        {
            string idThread = Thread.CurrentThread.GetHashCode().ToString();
            TaskInfo task = (TaskInfo)state;

            // verifica se a thread foi sinalizada para a execução
            if (timedOut)
            {
                // verifica qual é a task a ser executada
                if (!task.IsExecuting)
                {
                    try
                    {
                        logger.Info("Realizar Backup de Dados local");
                        // executa as regras de negocio
                        task.LastExecution = DateTime.Now;
                        task.IsExecuting = true;
                        task.IdCliente = 0;


                    }
                    catch (Exception ex)
                    {

                        logger.Error("Erro ao salvar arquivo backup local: " + ex.InnerException);
                    }
                    finally
                    {
                        task.IsExecuting = false;
                    }
                }
            }
        }

        private void WaitRecalcularHandling(object state, bool timedOut)
        {
            string idThread = Thread.CurrentThread.GetHashCode().ToString();
            TaskInfo task = (TaskInfo)state;

            // verifica se a thread foi sinalizada para a execução
            if (timedOut)
            {
                // verifica qual é a task a ser executada
                if (!task.IsExecuting)
                {
                    try
                    {
                        task.IsExecuting = true;
                        logger.Info("Enviar os Emails Pendentes");
                        // executa as regras de negocio
                        task.LastExecution = DateTime.Now;

                        task.IdCliente = 0;

                        //MovimentacaoContainerBusiness business = new MovimentacaoContainerBusiness();
                        //business.GetHandlingAdicional();


                    }
                    catch (Exception ex)
                    {

                        logger.Error("Erro ao executar :" + ex.Message);
                    }
                    finally
                    {
                        task.IsExecuting = false;
                    }
                }
            }
        }

        protected override void OnStart(string[] args)
        {
            logger.Info("Inicio Serviço");
        }

        protected override void OnStop()
        {
        }
  
        protected void Backup()
        {
            try
            {
                const string quote = "\"";
                string Arquivo = @"G:\banco\DUE_Backup_26042018_0900.backup";
                string Banco = "DUE_PDV_PIEREZAN_LOJA";
                //ProcessStartInfo inf = new ProcessStartInfo(Contexto.CaminhoSolution + "pg_dump.exe", " --host localhost --port 5432 --username postgres --format custom --blobs --verbose --file " + " \"" + Arquivo + " \"" + " \"" + Banco + " \""); //," --host localhost --port 5432 --username postgres --format custom --blobs --verbose --file " + "\"" + Arquivo + "\"" + " \"" + Banco + "\r\n\r\n");
                ProcessStartInfo inf = new ProcessStartInfo(Contexto.CaminhoSolution + "pg_dump.exe");
                string arguments = string.Format("\"{0}\" \"{1}\"", Arquivo, Banco);
                string Argumentos = " --host localhost --port 5432 --username postgres --format custom --blobs --verbose --file " + arguments;
                inf.Arguments = Argumentos;
                Process proc = new Process();
                inf.CreateNoWindow = true;
                inf.UseShellExecute = false;
                proc.StartInfo = inf;

                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                logger.Error("Falha no Backup: " + ex.Message);
            }
            finally
            {
                logger.Info("Backup Realizado com Sucesso");
            }

        }
        protected string[] GetFileList()
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            WebResponse response = null;
            StreamReader reader = null;


            try
            {
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + remoteDirectory));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                reqFTP.Proxy = null;
                reqFTP.KeepAlive = false;
                reqFTP.UsePassive = false;
                response = reqFTP.GetResponse();
                reader = new StreamReader(response.GetResponseStream());

                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                return result.ToString().Split('\n');
            }
            catch
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                downloadFiles = null;
                return downloadFiles;
            }
        }

        private void ProcurarAtualização()
        {
            string[] files = GetFileList();
            foreach (string file in files)
            {
                if (file.Length >= 5)
                {
                    string uri = "ftp://" + ftpServerIP + "/" + remoteDirectory + "/" + file;
                    Uri serverUri = new Uri(uri);

                    CheckFile(file);
                }
            }
        }

        private void CheckFile(string file)
        {
            string dFile = file;
            string fYear = "2018";
            string localDirectory = "";

            string[] splitDownloadFile = Regex.Split(dFile, " ");
            string fSize = splitDownloadFile[13];
            string fMonth = splitDownloadFile[14];
            string fDate = splitDownloadFile[15];
            string fTime = splitDownloadFile[16];
            string fName = splitDownloadFile[17];


            string dateModified = fDate + "/" + fMonth + "/" + fYear;

            DateTime lastModifiedDF = Convert.ToDateTime(dateModified);

            string[] filePaths = Directory.GetFiles(localDirectory);

            // if there is a file in filePaths that is the same as on the server compare them and then download if file on server is newer
            foreach (string ff in filePaths)
            {

                string[] splitFile = Regex.Split(ff, @"\\");

                string fileName = splitFile[2];
                FileInfo fouFile = new FileInfo(ff);
                DateTime lastChangedFF = fouFile.LastAccessTime;
                if (lastModifiedDF > lastChangedFF) Download(fileName);
            }
        }

        private void Download(string file)
        {
            try
            {
                string uri = "ftp://" + ftpServerIP + "/" + remoteDirectory + "/" + file;
                Uri serverUri = new Uri(uri);
                if (serverUri.Scheme != Uri.UriSchemeFtp)
                {
                    return;
                }
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + remoteDirectory + "/" + file));
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Proxy = null;
                reqFTP.UsePassive = false;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream responseStream = response.GetResponseStream();
                FileStream writeStream = new FileStream(localDestnDir + "\\" + file, FileMode.Create);                
                int Length = 2048;
                Byte[] buffer = new Byte[Length];
                int bytesRead = responseStream.Read(buffer, 0, Length);
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = responseStream.Read(buffer, 0, Length);
                }
                writeStream.Close();
                response.Close();
            }
            catch (WebException wEx)
            {
                logger.Info("Erro Download: " + wEx.Message);
            }
            catch (Exception ex)
            {
                logger.Info("Erro Download: " + ex.Message);
            }
        }


    }
}
