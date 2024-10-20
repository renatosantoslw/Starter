using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Cadastro.Parametros;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas.Parametros
{
    public partial class FCO_MotivoCancelamento : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA MOTIVO DE CANCELAMENTO";
        public FCO_MotivoCancelamento()
        {
            InitializeComponent();
            Carregar();
        }

        private void Carregar()
        {
            gridControl1.DataSource = FuncoesMotivoCancelamento.GetMotivos("");
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = "NOME";
            gridView1.Columns[2].Caption = "ATIVO";
        }


        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            Carregar();
        }

        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {
            new FCA_MotivoCancelamento(new MotivoCancelamento()).ShowDialog(this);
            Carregar();
        }

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        {
            decimal IDMotivoCancelamento = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "idmotivocancelamento").ToString());
            new FCA_MotivoCancelamento(FuncoesMotivoCancelamento.GetMotivo(IDMotivoCancelamento)).ShowDialog(this);
            Carregar();
            editamonitormetroButton4.Enabled = false;
        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o Motivo de Cancelamento selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                
                decimal IDMotivoCancelamento = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMOTIVOCANCELAMENTO").ToString());
                try
                {
                    if (!FuncoesMotivoCancelamento.Remover(IDMotivoCancelamento))
                        throw new Exception("Não foi possível remover o Motivo de Cancelamento.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Carregar();
            }
        }

        private void FCO_Ncm_Load(object sender, EventArgs e)
        {
            Carregar();
        }


        private void gridControl1_Click(object sender, EventArgs e)
        {
            editamonitormetroButton4.Enabled = true;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            decimal IDMotivoCancelamento = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDOTIVOCANCELAMENTO").ToString());
            new FCA_MotivoCancelamento(FuncoesMotivoCancelamento.GetMotivo(IDMotivoCancelamento)).ShowDialog(this);
            Carregar();
            editamonitormetroButton4.Enabled = false;
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            Carregar();
        }
    }
}
