using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Enum;
using PDV.REPORTS.Reports.FechamentoCaixaDiarioTermica;
using PDV.REPORTS.Reports.FluxoCaixaDiario;
using PDV.VIEW.App_Context;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Relatorios
{
    public partial class FREL_FluxoDeCaixaDiarioPorUsuario : DevExpress.XtraEditors.XtraForm
    {

        private string NOME_TELA = "RELATÓRIO DE FLUXO DE CAIXA DIÁRIO";

        public FREL_FluxoDeCaixaDiarioPorUsuario()
        {
            InitializeComponent();

            ovCMB_Usuario.DataSource = FuncoesUsuario.GetUsuarios(string.Empty, string.Empty);
            ovCMB_Usuario.DisplayMember = "NOME";
            ovCMB_Usuario.ValueMember = "IDUSUARIO";
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (ovCMB_Usuario.SelectedItem == null)
            {
                MessageBox.Show(this, "Selecione o Usuário.", NOME_TELA);
                return;
            }
            var idUsuario = Convert.ToDecimal((ovCMB_Usuario.SelectedItem as DataRowView)["IDUSUARIO"]);
            var Fluxo = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuario(idUsuario);
            var usuario = FuncoesUsuario.GetUsuario(idUsuario);

            var RelatorioFluxoCaixa = new FechamentoCaixaDiarioTermica(usuario, Fluxo == null ? -1 : Fluxo.IDFluxoCaixa,
                Contexto.CONFIGURACAO_SERIE.SerieNFCe.ToString(), Contexto.CONFIGURACAO_SERIE.NomeSequenceNFCe.ToString(), false);
            
            Stream STRel = new MemoryStream();
            RelatorioFluxoCaixa.ExportToPdf(STRel);
            new FREL_Preview(STRel).ShowDialog(this);

            //SaveFileDialog SaveFile = new SaveFileDialog();
            //SaveFile.Filter = "RTF|*.rtf|PDF|*.pdf|XLS|*.xls|XLSX|*.xlsx";
            //SaveFile.Title = "Salvar Relatório de Impressão de Comandas";
            //SaveFile.ShowDialog(this);
            //SaveFile.ShowHelp = false;
            //if (string.IsNullOrEmpty(SaveFile.FileName))
            //    return;
            //
            //switch (SaveFile.FilterIndex)
            //{
            //    case 1:
            //        RelatorioFluxoCaixa.ExportToRtf(SaveFile.FileName);
            //        break;
            //    case 2:
            //        RelatorioFluxoCaixa.ExportToPdf(SaveFile.FileName);
            //        break;
            //    case 3:
            //        RelatorioFluxoCaixa.ExportToXls(SaveFile.FileName);
            //        break;
            //    case 4:
            //        RelatorioFluxoCaixa.ExportToXlsx(SaveFile.FileName);
            //        break;
            //}
        }
    }
}
