using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.PDV;
using PDV.REPORTS.Reports.ComandasEmAberto;
using PDV.VIEW.App_Context;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Relatorios
{
    public partial class FREL_ComandasEmAberto : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "COMANDAS EM ABERTO POR USUÁRIO";
        public FREL_ComandasEmAberto()
        {
            InitializeComponent();

            ovCMB_Usuario.DataSource = FuncoesUsuario.GetUsuarios(string.Empty, string.Empty);
            ovCMB_Usuario.DisplayMember = "NOME";
            ovCMB_Usuario.ValueMember = "IDUSUARIO";
        }

        private void metroButton5_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, System.EventArgs e)
        {
            if (ovCMB_Usuario.SelectedItem == null)
            {
                MessageBox.Show(this, "Selecione o Usuário.", NOME_TELA);
                return;
            }

            FluxoCaixa Fluxo = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuario(Convert.ToDecimal((ovCMB_Usuario.SelectedItem as DataRowView)["IDUSUARIO"]));
            ComandasEmAbertoUsuario _ComandasEmAbertoUsuario = new ComandasEmAbertoUsuario(Convert.ToDecimal((ovCMB_Usuario.SelectedItem as DataRowView)["IDUSUARIO"]),
                                                       Fluxo == null ? -1 : Fluxo.IDFluxoCaixa,
                                                       (ovCMB_Usuario.SelectedItem as DataRowView)["NOME"].ToString(),
                                                       string.Format("{0} - ({1})", Contexto.USUARIOLOGADO.Nome, Contexto.USUARIOLOGADO.Login));

            Stream STRel = new MemoryStream();
            _ComandasEmAbertoUsuario.ExportToPdf(STRel);
            new FREL_Preview(STRel).ShowDialog(this);

            /*SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Filter = "RTF|*.rtf|PDF|*.pdf|XLS|*.xls|XLSX|*.xlsx";
            SaveFile.Title = "Salvar Relatório de Impressão de Comandas";
            SaveFile.ShowDialog(this);
            SaveFile.ShowHelp = false;
            if (string.IsNullOrEmpty(SaveFile.FileName))
                return;

            switch (SaveFile.FilterIndex)
            {
                case 1:
                    _ComandasEmAbertoUsuario.ExportToRtf(SaveFile.FileName);
                    break;
                case 2:
                    _ComandasEmAbertoUsuario.ExportToPdf(SaveFile.FileName);
                    break;
                case 3:
                    _ComandasEmAbertoUsuario.ExportToXls(SaveFile.FileName);
                    break;
                case 4:
                    _ComandasEmAbertoUsuario.ExportToXlsx(SaveFile.FileName);
                    break;
            }*/
        }
    }
}
