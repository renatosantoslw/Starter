using DevExpress.XtraPrinting;
using MetroFramework;
using MetroFramework.Forms;
using PDV.DAO.Enum;
using PDV.REPORTS.Reports.ImpressaoComandas;
using PDV.VIEW.App_Context;
using System;
using System.IO;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Relatorios
{
    public partial class FREL_ImpressaoComandas : DevExpress.XtraEditors.XtraForm
    {
        public FREL_ImpressaoComandas()
        {
            InitializeComponent();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GerarRelatorio()
        {
            if (string.IsNullOrEmpty(ovTXT_CodigoInicial.Text.Trim()))
            {
                MessageBox.Show(this, "Preencha o Código Inicial.", "IMPRESSÃO DE COMANDAS");
                return;
            }

            if (string.IsNullOrEmpty(ovTXT_CodigoFinal.Text.Trim()))
            {
                MessageBox.Show(this, "Preencha o Código Final.", "IMPRESSÃO DE COMANDAS");
                return;
            }

            ImpressaoComanda RelatorioComandas = new ImpressaoComanda(Convert.ToDecimal(ovTXT_CodigoInicial.Text),
                                                                      Convert.ToDecimal(ovTXT_CodigoFinal.Text),
                                                                      string.Format("{0} - ({1})", Contexto.USUARIOLOGADO.Nome, Contexto.USUARIOLOGADO.Login));

            Stream STRel = new MemoryStream();
            RelatorioComandas.ExportToPdf(STRel);
            new FREL_Preview(STRel).ShowDialog(this);

            //SaveFileDialog SaveFile = new SaveFileDialog();
            //SaveFile.Filter = "RTF|*.rtf|PDF|*.pdf|XLS|*.xls|XLSX|*.xlsx";
            //SaveFile.Title = "Salvar Relatório de Impressão de Comandas";
            //SaveFile.ShowDialog(this);
            //SaveFile.ShowHelp = false;
            //if (string.IsNullOrEmpty(SaveFile.FileName))
            //    return;

            //switch (SaveFile.FilterIndex)
            //{
            //    case 1:
            //        RelatorioComandas.ExportToRtf(SaveFile.FileName);
            //        break;
            //    case 2:
            //        RelatorioComandas.ExportToPdf(SaveFile.FileName);
            //        break;
            //    case 3:
            //        RelatorioComandas.ExportToXls(SaveFile.FileName);
            //        break;
            //    case 4:
            //        RelatorioComandas.ExportToXlsx(SaveFile.FileName);
            //        break;
            //}
        }
        
        private void metroButton1_Click(object sender, EventArgs e)
        {
            GerarRelatorio();
        }

    }
}
