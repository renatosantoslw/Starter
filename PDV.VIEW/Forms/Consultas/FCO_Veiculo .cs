using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.MDFe;
using PDV.UTIL;
using PDV.VIEW.Forms.Cadastro.MDFe;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_Veiculo : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE VEICULO DE TRANSPORTE";

        public FCO_Veiculo()
        {
            InitializeComponent();
            AtualizarVeiculos("","");
        }

        private void AtualizarVeiculos(string Placa, string Descricao)
        {
            gridControl1.DataSource = FuncoesVeiculoMDFe.GetVeiculos(Placa, Descricao);
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = "PLACA";
            gridView1.Columns[2].Caption = "MODELO";
            gridView1.Columns[3].Visible = false;
        }

        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {
            FCA_Veiculo t = new FCA_Veiculo(new Veiculo());
            t.ShowDialog(this);
            AtualizarVeiculos("","");
            editarveiculometroButton4.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal IDVeiculo = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDVEICULO").ToString());
                FCA_Veiculo t = new FCA_Veiculo(FuncoesVeiculoMDFe.GetVeiculo(IDVeiculo));
                t.ShowDialog(this);
                AtualizarVeiculos("", "");
                editarveiculometroButton4.Enabled = false;
                metroButton3.Enabled = false;
            }
            catch (Exception)
            {
            }
            
        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o Veículo selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                decimal IDVeiculo = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDVEICULO").ToString());
                try
                {
                    if (!FuncoesVeiculoMDFe.Remover(IDVeiculo))
                        throw new Exception("Não foi possível remover o Veículo.");
                }
                catch (Exception Ex)
                {
                   MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizarVeiculos("", "");
                
            }
            editarveiculometroButton4.Enabled = false;
            metroButton3.Enabled = false;
        }
        
        private void FCO_Veiculo_Load_1(object sender, EventArgs e)
        {
            AtualizarVeiculos("", "");
        }


        private void gridControl1_Click(object sender, EventArgs e)
        {
            editarveiculometroButton4.Enabled = true;
            metroButton3.Enabled = true;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizarVeiculos("", "");
            editarveiculometroButton4.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
            editarveiculometroButton4.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            decimal IDVeiculo = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDVEICULO").ToString());
            FCA_Veiculo t = new FCA_Veiculo(FuncoesVeiculoMDFe.GetVeiculo(IDVeiculo));
            t.ShowDialog(this);

            AtualizarVeiculos("", "");
            editarveiculometroButton4.Enabled = false;
        }
    }
}
