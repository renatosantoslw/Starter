using DevExpress.XtraReports.UI;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.NFCE.Impressao;
using PDV.CONTROLLER.NFE.Impressao;
using PDV.DAO.Custom;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.REPORTS.Reports.CarneVendaTermica;
using PDV.UTIL;
using PDV.VIEW.Forms.Gerenciamento;
using PDV.VIEW.FRENTECAIXA.App_Context;
using System;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms.PDV
{
    public partial class GPDV_Comandos : DevExpress.XtraEditors.XtraForm
    {
        private GPDV_PainelInicial PainelInicial = null;
        public DataRow DRCliente = null;
        public bool Identificar = false;
        private bool ClienteNovo = false;
        public string IDCliente = "";

        private string _TipoCliente = "1";

        public string comandosf1 = string.Empty;

        public string comandof1 { get; internal set; }

        public GPDV_Comandos(GPDV_PainelInicial _PainelInicial)
        {
            InitializeComponent();
            PainelInicial = _PainelInicial;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Identificar = false;
                    Close();
                    break;
                case Keys.F3:
                    metroButton2_Click(metroButton2, null);
                    break;

            }
            return base.ProcessDialogKey(keyData);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Configuracao Config_NomeImpressora = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOPEDIDOVENDA_NOMEIMPRESSORA);
            Configuracao Config_ExibirCaixaDialogo = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOPEDIDOVENDA_EXIBIRCAIXADIALOGO);
            decimal ultimavenda = FuncoesVenda.GetUltimaVenda();
            CarneVenda _CarneVenda = new CarneVenda(ultimavenda);
            using (ReportPrintTool printTool = new ReportPrintTool(_CarneVenda))
            {
                if (Config_NomeImpressora != null && !string.IsNullOrEmpty(Encoding.UTF8.GetString(Config_NomeImpressora.Valor)))
                    printTool.PrinterSettings.PrinterName = Encoding.UTF8.GetString(Config_NomeImpressora.Valor);
                printTool.PrinterSettings.Copies = 1;
                printTool.Print();
            }
        }

     
        private void BackupBanco()
        {
            try
            {
                const string quote = "\"";
                string Arquivo = @"E:\db\DUE_Backup_26042018_0900.backup";
                string Banco = "MFe";
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
            finally
            {
                MessageBox.Show(this, "Backup Realizado com Sucesso", "BACKUP");
            }
        }


        private void metroButton2_Click(object sender, EventArgs e)
        {
            decimal ultimanfce = FuncoesMovimentoFiscal.GetUltimaNFCeEmitidaPorSerie(Contexto.CONFIGURACAO_SERIE.SerieNFCe, 1);
            RetornoImpressaoNFCe Retorno = new ImpressaoNFCe() { CaminhoSolution = Contexto.CaminhoSolution }.ImprimirNFCe(ultimanfce);
            if (Retorno.isVisualizar)
                Retorno.danfe.Visualizar();
            else
                Retorno.danfe.Imprimir(Retorno.isCaixaDialogo, Retorno.NomeImpressora);

        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            GER_NotasFiscaisConsumidor frm = new GER_NotasFiscaisConsumidor();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackupBanco();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            PainelInicial.ChamarFinalizarVenda();
            //comandosf1 = "F5";
            Hide();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja Cancelar a Venda?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                PainelInicial.IniciaNovaVenda();
                PainelInicial.CarregarPainelCategorias();
                Hide();
            }

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

        }
    }
}
