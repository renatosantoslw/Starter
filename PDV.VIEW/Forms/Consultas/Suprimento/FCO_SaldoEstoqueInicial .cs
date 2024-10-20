using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas.Suprimento
{
    public partial class FCO_SaldoEstoqueInicial : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA SALDOS INICIAIS DE ESTOQUE";
        public FCO_SaldoEstoqueInicial()
        {
            InitializeComponent();
        }

        private void AtualizaSaldoEstoqueInicial(string Codigo, string Descricao)
        {
            //gridControl1.DataSource = FuncoesNcm.GetNcms(Codigo, Descricao);
            //gridView1.OptionsBehavior.Editable = false;
            //gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            //gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            //gridView1.BestFitColumns();
            //AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            //gridView1.Columns[0].Visible = false;
            //gridView1.Columns[1].Caption = "CÓDIGO";
            //gridView1.Columns[2].Caption = "DESCRIÇÃO";
        }


       

        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {
            //FCA_Ncm t = new FCA_Ncm(new DAO.Entidades.Ncm());
            //t.ShowDialog(this);
            //AtualizaSaldoEstoqueInicial("","");
        }

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        {
            //decimal IDNcm = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "idncm").ToString());
            //FCA_Ncm t = new FCA_Ncm(FuncoesNcm.GetNCM(IDNcm));
            //t.ShowDialog(this);
            //AtualizaSaldoEstoqueInicial("", "");
            //editarEstoquemetroButton.Enabled = false;
        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show(this, "Deseja remover o NCM selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{
            //    decimal IDNcm = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "idncm").ToString());
            //    try
            //    {
            //        if (!FuncoesNcm.Remover(IDNcm))
            //            throw new Exception("Não foi possível remover o NCM.");
            //    }
            //    catch (Exception Ex)
            //    {
            //        MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    AtualizaSaldoEstoqueInicial("", "");
            //}
        }

        private void FCO_SaldoEstoqueInicial_Load(object sender, EventArgs e)
        {
            //AtualizaSaldoEstoqueInicial("", "");
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            //decimal IDNcm = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "idncm").ToString());
            //FCA_Ncm t = new FCA_Ncm(FuncoesNcm.GetNCM(IDNcm));
            //t.ShowDialog(this);
            //AtualizaSaldoEstoqueInicial("", "");
            //editarEstoquemetroButton.Enabled = false;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            //editarEstoquemetroButton.Enabled = true;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            //AtualizaSaldoEstoqueInicial("","");
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            //gridView1.ShowPrintPreview();
        }
    }
}
