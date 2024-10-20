using FontAwesome.Sharp;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.UTIL;
using PDV.VIEW.Forms.Cadastro.Suprimentos;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas.Suprimento
{
    public partial class FCO_Almoxarifado : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA ALMOXARIFADO";
        private DataTable ALMOXARIFADOS = null;
        public FCO_Almoxarifado()
        {
            InitializeComponent();
            AtualizaAlmoxarifados();




            //icones
            Bitmap bitmapNovo = IconChar.PlusSquare.ToBitmap(Color.DarkGreen, 20);
            Bitmap bitmapEditar = IconChar.Edit.ToBitmap(Color.DarkOrange, 20);
            Bitmap bitmapRemover = IconChar.MinusSquare.ToBitmap(Color.DarkRed, 20);
            Bitmap bitmapAtualizar = IconChar.Sync.ToBitmap(Color.SteelBlue, 20);
            Bitmap bitmapImprimir = IconChar.Print.ToBitmap(Color.SteelBlue, 20);

            metroButton5.ImageOptions.Image = bitmapNovo;
            editarmetroButton4.ImageOptions.Image = bitmapEditar;
            metroButton3.ImageOptions.Image = bitmapRemover;
            atualizarMetroButton.ImageOptions.Image = bitmapAtualizar;
            imprimriMetroButton.ImageOptions.Image = bitmapImprimir;
        }

        private void AtualizaAlmoxarifados()
        {
            gridControl1.DataSource = FuncoesAlmoxarifado.GetAlmoxarifados(null);
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
          
            gridView1.Columns[0].Caption = "DESCRIÇÃO";
            gridView1.Columns[1].Visible = false;
            gridView1.Columns[2].Visible = false;
            gridView1.Columns[3].Caption = "TIPO";
        }


        private void ovBTN_LimparFiltros_Click(object sender, EventArgs e)
        {
           
        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            AtualizaAlmoxarifados();
        }

        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {
            FCA_Almoxarifado t = new FCA_Almoxarifado(new Almoxarifado());
            t.ShowDialog(this);
            AtualizaAlmoxarifados();
            metroButton3.Enabled = false;
            editarmetroButton4.Enabled = false;
        }

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        { 
            try
            {
                FCA_Almoxarifado t = new FCA_Almoxarifado(FuncoesAlmoxarifado.GetAlmoxarifado(Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDALMOXARIFADO").ToString())));
                t.ShowDialog(this);
                AtualizaAlmoxarifados();

            }
            catch (Exception)
            {


            }
            finally
            {
                metroButton3.Enabled = false;
                editarmetroButton4.Enabled = false;

            }
        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o Almoxarifado selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    if (!FuncoesAlmoxarifado.Remover(Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDALMOXARIFADO").ToString())))
                        throw new Exception("Não foi possível remover o Almoxarifado.");
                }
                catch (Exception Ex)
                {
                   MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizaAlmoxarifados();
            }
            metroButton3.Enabled = false;
            editarmetroButton4.Enabled = false;
        }

        private void FCO_Almoxarifados_Load(object sender, EventArgs e)
        {
            AtualizaAlmoxarifados();
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
            metroButton3.Enabled = false;
            editarmetroButton4.Enabled = false;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            metroButton3.Enabled = true;
            editarmetroButton4.Enabled = true;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                FCA_Almoxarifado t = new FCA_Almoxarifado(FuncoesAlmoxarifado.GetAlmoxarifado(Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDALMOXARIFADO").ToString())));
                t.ShowDialog(this);
                AtualizaAlmoxarifados();
                metroButton3.Enabled = false;
                editarmetroButton4.Enabled = false;
            }
            catch (Exception)
            {

                
            }


        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizaAlmoxarifados();
            metroButton3.Enabled = false;
            editarmetroButton4.Enabled = false;
        }
    }

        
    

}
