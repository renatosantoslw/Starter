using DFe.Classes.Flags;
using DFe.Utils;
using Ionic.Zip;
using MetroFramework;
using MetroFramework.Forms;
using NFe.Classes;
using NFe.Classes.Servicos.Recepcao;
using NFe.Utils.NFe;
using PDV.CONTROLER.Funcoes;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Gerenciamento
{
    public partial class GER_ExportarNFCe : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "Exportar NFC-e/NF-e";
        public GER_ExportarNFCe()
        {
            InitializeComponent();
            //        LocalDate inicio = null, fim = null;
            //        inicio = LocalDate.now().withMonth(LocalDate.now().getMonthValue()).minusMonths(1).with(TemporalAdjusters.firstDayOfMonth());
            //          fim = LocalDate.now().withMonth(LocalDate.now().getMonthValue()).minusMonths(1).with(TemporalAdjusters.lastDayOfMonth());

            int month = DateTime.Now.Month;

            if (month == 1)
            {
                ovTXT_InicioVigencia.Value = new DateTime(DateTime.Now.AddYears(-1).Year, DateTime.Now.AddMonths(-1).Month, 1);
            }
            else
            {
                ovTXT_InicioVigencia.Value = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, 1);
            }


            ovTXT_DataFim.Value = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month));
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void metroButton5_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Filter = "ZIP|*.zip";
            SaveFile.Title = "Exportação de NFC-E";
            SaveFile.ShowDialog(this);
            SaveFile.ShowHelp = false;
            if (string.IsNullOrEmpty(SaveFile.FileName))
                return;
            ModeloDocumento Modelo = ModeloDocumento.NFCe;
            if (ovCKB_NFe.Checked)
                Modelo = ModeloDocumento.NFe;
            switch (SaveFile.FilterIndex)
            {
                case 1:
                    try
                    {
                        DataTable NFCes = FuncoesMovimentoFiscal.GetNFCEsExportar(ovTXT_InicioVigencia.Value, ovTXT_DataFim.Value, ovCKB_Transmitida.Checked, ovCKB_Cancelada.Checked, ovCKB_Rejeitada.Checked, ovCKB_Contingencia.Checked, ovCKB_Producao.Checked ? Convert.ToDecimal(TipoAmbiente.Producao) : Convert.ToDecimal(TipoAmbiente.Homologacao), Convert.ToInt32(Modelo));
                        if (NFCes.Rows.Count == 0)
                        {
                            MessageBox.Show(this, "Nenhuma " + Modelo.ToString() + " encontrada para exportar.", NOME_TELA);
                            return;
                        }
                        string NomeDiretorio = string.Format(Modelo.ToString() + "Exportadas/{0}", DateTime.Now.ToString("dd-mm-yyyy_HH-mm-ss"));
                        Directory.CreateDirectory(NomeDiretorio);

                        foreach (DataRow dr in NFCes.Rows)
                        {
                            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
                            //var nfe = new NFe.Classes.NFe().CarregarDeXmlString(iso.GetString(dr["XMLENVIO"] as byte[]));

                            var idmovimentofiscal = int.Parse(dr["IDMOVIMENTOFISCAL"].ToString());

                            PDV.DAO.Entidades.MovimentoFiscal movimentoFiscal = FuncoesMovimentoFiscal.GetMovimento(idmovimentofiscal);

                            var xml = FuncoesMovimentoFiscal.GetXMLRetorno(int.Parse(dr["IDMOVIMENTOFISCAL"].ToString()));
                            var xmla = FuncoesMovimentoFiscal.GetXMLEnvio(int.Parse(dr["IDMOVIMENTOFISCAL"].ToString()));
                            //if (movimentoFiscal.cStat == 100)
                            //{
                            var proc = new NFe.Classes.nfeProc();

                            var nfce = proc.CarregarDeXmlString(FuncoesMovimentoFiscal.GetXMLRetorno(int.Parse(dr["IDMOVIMENTOFISCAL"].ToString())));
                            
                            var nfeProc = new nfeProc()
                            {
                                NFe = nfce.NFe,
                                protNFe = nfce.protNFe,
                                versao = nfce.versao
                                
                            };

                            nfeProc.SalvarArquivoXml(string.Format("{0}/{1}.xml", NomeDiretorio, dr["CHAVE"].ToString()));
                            // }


                        }
                        ZipFile Zip = new ZipFile(SaveFile.FileName);
                        Zip.AddDirectory(NomeDiretorio, NomeDiretorio);
                        Zip.Save(SaveFile.FileName);
                        Zip.Dispose();
                        if (Directory.Exists(NomeDiretorio))
                            Directory.Delete(NomeDiretorio, true);

                        MessageBox.Show(this, "Notas exportadas com sucesso.", NOME_TELA);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(this, "Não foi possível exportar as " + Modelo.ToString() + ", Motivo: " + Ex.Message, NOME_TELA);
                    }
                    break;
            }
        }

        private void ovCKB_NFCe_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ovCKB_Cancelada_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
