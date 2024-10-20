using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.UTIL;
using PDV.VIEW.Forms.Cadastro.MDFe;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas.MDFe
{
    public partial class FCO_Proprietario : DevExpress.XtraEditors.XtraForm
    {
        public string NOME_TELA = "CONSULTA DE PROPRIETÁRIO";
        public FCO_Proprietario()
        {
            InitializeComponent();
            Carregar();
        }

        private void AjustaHeaderTextGrid()
        {
            gridView1.Columns[3].Caption = "CPF/CNPJ";
            gridView1.Columns[4].Caption = "NOME";
            for (int i = 0; i < 10; i++)
            {
                if (i != 4 && i != 3)
                {
                    gridView1.Columns[i].Visible = false;
                }
            }
        }


        private void FCO_Proprietario_Load(object sender, EventArgs e)
        {
            Carregar();
        }

        private void Carregar()
        {
            gridControl1.DataSource = FuncoesProprietario.GetProprietarios("", "");
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaHeaderTextGrid();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            FCA_Proprietario t = new FCA_Proprietario(new DAO.Entidades.MDFe.ProprietarioVeiculoMDFe());
            t.ShowDialog(this);
            Carregar();
            editarproprietariometroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            
           
            try
            {
                FCA_Proprietario t = new FCA_Proprietario(FuncoesProprietario.GetProprietario(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDPROPRIETARIOVEICULOMDFE").ToString())));
                t.ShowDialog(this);
                Carregar();
            }
            catch (Exception)
            {
            }
            finally
            {
                editarproprietariometroButton.Enabled = false;
                metroButton3.Enabled = false;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o Proprietário selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    if (!FuncoesProprietario.Remover(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDPROPRIETARIOVEICULOMDFE").ToString())))
                        throw new Exception("Não foi possível remover o Proprietário.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Carregar();
               
            }
            editarproprietariometroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            editarproprietariometroButton.Enabled = true;
            metroButton3.Enabled = true;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            
            try
            {
                FCA_Proprietario t = new FCA_Proprietario(FuncoesProprietario.GetProprietario(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDPROPRIETARIOVEICULOMDFE").ToString())));
                t.ShowDialog(this);
                Carregar();
                editarproprietariometroButton.Enabled = false;
                metroButton3.Enabled = false;
            }
            catch (Exception)
            {

            }
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            Carregar();
            editarproprietariometroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
            editarproprietariometroButton.Enabled = false;
            metroButton3.Enabled = false;
        }
    }
}
