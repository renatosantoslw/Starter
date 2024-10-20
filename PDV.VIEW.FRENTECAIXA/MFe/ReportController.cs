using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace CFeImpressao
{
    public class ReportController
    {
        private List<ReportDataSource> DataSources = null;
        private List<KeyValuePair<string, object>> Parameters = null;
        public ReportController()
        {
            DataSources = new List<ReportDataSource>();
            Parameters = new List<KeyValuePair<string, object>>();
        }

        public void BindParameter(string parameterName, object value)
        {
            this.Parameters.Add(new KeyValuePair<string, object>(parameterName, value));
        }

        public void AddDataSource(string name, DataTable datatable)
        {
            DataSources.Add(new ReportDataSource()
            {
                Source_Type = ReportDataSource.SOURCE_TYPE.DataTable,
                Name = name,
                DataTable = datatable
            });
        }

        public void AddDataSource(string name, IEnumerable enumerable)
        {
            DataSources.Add(new ReportDataSource()
            {
                Source_Type = ReportDataSource.SOURCE_TYPE.IEnumerable,
                Name = name,
                IEnumerable = enumerable
            });
        }

        private string GetPathToPdfFromBrowser()
        {
            System.Windows.Forms.FolderBrowserDialog browse = new System.Windows.Forms.FolderBrowserDialog();
            browse.Description = "Selecione uma pasta no computador ou no servidor para salvar o documento em formato PDF";
            browse.ShowDialog();

            return browse.SelectedPath;
        }

        public void ExportToPDF(string fileName, ReportDocument rpt)
        {
            fileName = fileName.Replace("/", "-");
            string path = string.Empty;
            while (string.IsNullOrEmpty(path))
            {
                path = GetPathToPdfFromBrowser();
                if (string.IsNullOrEmpty(path))
                    MessageBox.Show("Informe um local válido para salvar o documento.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, $@"{path}\{fileName}");
        }

        public ReportDocument GetReportDocument(string reportFileName)
        {
            if (!reportFileName.EndsWith(".rpt"))
                reportFileName += ".rpt";

            Cache<ReportDocument> cached = CacheRepository<ReportDocument>.Get($"{reportFileName}");

            ReportDocument rd = (cached == null
                ? new ReportDocument()
                : cached.Value);

            if (cached == null)
            {
                rd.Load(Directory.GetCurrentDirectory() + $@"\MFe\{reportFileName}");
                CacheRepository<ReportDocument>.Set($"{reportFileName}", rd, 3, true);
            }

            foreach (Table table in rd.Database.Tables)
            {
                ReportDataSource rds = DataSources.First(e => e.Name.Equals(table.Name));
                switch (rds.Source_Type)
                {
                    case ReportDataSource.SOURCE_TYPE.IEnumerable:
                        table.SetDataSource(rds.IEnumerable);
                        break;

                    case ReportDataSource.SOURCE_TYPE.DataTable:
                        table.SetDataSource(rds.DataTable);
                        break;
                }
            }

            if (this.Parameters.Count > 0)
                this.Parameters.ForEach(param =>
                {
                    try
                    {
                        rd.SetParameterValue(param.Key, param.Value);
                    }
                    catch { }
                });

            return rd;
        }

        private bool spoolerReiniciado = false;
        public void PrintToMiniPrinter(ReportDocument rpt,
            string messageOnFail, string fileNameOnFail,
            string nomeImpressora, bool tryRemotePrinter = false)
        {
            PrinterSettings ps = null;
            PageSettings page = new PageSettings();
            try
            {
                if (string.IsNullOrEmpty(nomeImpressora))
                    throw new Exception("Não é possível realizar a impressão do documento. Falta do parâmetro 'NF_IMPPADRAO.'");

                ps = new PrinterSettings();
                ps.PrinterName = nomeImpressora;
                rpt.PrintToPrinter(ps, page, false);
            }
            catch (Exception ex)
            {
                if (tryRemotePrinter)
                    TryPrintToRemoteMiniPrinter(rpt, nomeImpressora);
                else
                    throw new Exception($"Ocorreu um problema ao enviar o documento para a impressora destino: " + ex.Message);
            }
        }

        private void TryPrintToRemoteMiniPrinter(ReportDocument rpt,
            string nomeImpressora)
        {
            try
            {
                PrinterSettings ps = GetFromLocalFile(nomeImpressora);
                if (ps == null)
                {
                    PrintDialog pd = new PrintDialog();
                    pd.ShowDialog();
                    ps = pd.PrinterSettings;

                    if (ps == null)
                        throw new Exception();

                    SavePrinterSettings(ps, nomeImpressora);
                }

                rpt.PrintToPrinter(ps, new PageSettings(), false);
            }
            catch (Exception ex)
            {
                throw new Exception("A impressão na impressora remota falhou: " + ex.Message);
            }
        }

        private void SavePrinterSettings(PrinterSettings ps, string nomeParametroImpressora)
        {
            FileStream fs = null;
            try
            {
                if (!Directory.Exists(@"C:\Temp\One_Desenv\"))
                    Directory.CreateDirectory(@"C:\Temp\One_Desenv\");

                fs = new FileStream($@"C:\Temp\One_Desenv\{nomeParametroImpressora}.printer", FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, ps);
                fs.Close();
            }
            catch (Exception ex)
            {
                if (fs != null)
                    fs.Close();
            }
        }

        private PrinterSettings GetFromLocalFile(string nomeParametro)
        {
            PrinterSettings result = null;
            FileStream fs = null;
            try
            {
                fs = new FileStream($@"C:\Temp\One_Desenv\{nomeParametro}.printer", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                result = (PrinterSettings)formatter.Deserialize(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                if (fs != null)
                    fs.Close();
            }

            return result;
        }
    }
}
