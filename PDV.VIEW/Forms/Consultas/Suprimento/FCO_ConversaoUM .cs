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
    public partial class FCO_ConversaoUM : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA CONVERSÕES DE UNIDADE DE MEDIDA";
        private DataTable CONVERSOES = null;
        public FCO_ConversaoUM()
        {
            InitializeComponent();
            AtualizaConversaoUM();

            //IconesFA.Icones24 icones2 = new IconesFA.Icones24();
            //icones

            Bitmap bitmapNovo = IconChar.PlusSquare.ToBitmap(Color.DarkGreen, 24);
            Bitmap bitmapEditar = IconChar.PenSquare.ToBitmap(Color.DarkOrange, 24);
            Bitmap bitmapRemover = IconChar.MinusSquare.ToBitmap(Color.Firebrick, 24);
            Bitmap bitmapAtualizar = IconChar.SyncAlt.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapImprimir = IconChar.Print.ToBitmap(Color.SteelBlue, 24);
                        
            novoMetroButton.ImageOptions.Image = bitmapNovo;
            editarconvundmetroButton4.ImageOptions.Image = bitmapEditar;
            removerMetroButton.ImageOptions.Image = bitmapRemover;//remover
            atualizarMetroButton.ImageOptions.Image = bitmapAtualizar;
            imprimirMetroButton.ImageOptions.Image = bitmapImprimir;
        }

        private void AtualizaConversaoUM()
        {
            CONVERSOES = FuncoesConversaoUnidadeMedida.GetConversoes();
            gridControl1.DataSource = CONVERSOES;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            //AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            gridView1.Columns[0].BestFit();

            /* gridView1.Columns[0].Caption = "PRODUTO";
             gridView1.Columns[1].Caption   = "UN. DE ENTRADA";
             gridView1.Columns[2].Caption = "UN.DE SAIDA";
             gridView1.Columns[3].Caption = "FATOR";*/ 
             
            //for para ocultar
             for (int i = 5; i < 9; i++)
             {
                 gridView1.Columns[i].Visible = false;
             }
        }
    
        private void ovGRD_Conversoes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (gridView1.Columns[e.ColumnIndex].Name)
            {
                case "fator":
                    if (e.Value != null && e.Value != DBNull.Value)
                        e.Value = Convert.ToDecimal(e.Value).ToString("n4");
                    break;
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FCA_ConversaoUM t = new FCA_ConversaoUM(FuncoesConversaoUnidadeMedida.GetConversao(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCONVERSAOUNIDADEDEMEDIDA").ToString())));
                t.ShowDialog(this);
                AtualizaConversaoUM();
                editarconvundmetroButton4.Enabled = false;
                removerMetroButton.Enabled = false;
            }
            catch (Exception)
            {

            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            editarconvundmetroButton4.Enabled = true;
            removerMetroButton.Enabled = true;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizaConversaoUM();
            editarconvundmetroButton4.Enabled = false;
            removerMetroButton.Enabled = false;
        }

        private void imprimirMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
            editarconvundmetroButton4.Enabled = false;
            removerMetroButton.Enabled = false;
        }


        private void editarconvundmetroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                FCA_ConversaoUM t = new FCA_ConversaoUM(FuncoesConversaoUnidadeMedida.GetConversao(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCONVERSAOUNIDADEDEMEDIDA").ToString())));
                t.ShowDialog(this);
                AtualizaConversaoUM();
            }
            catch (Exception)
            {

            }
            finally
            {
                editarconvundmetroButton4.Enabled = false;
                removerMetroButton.Enabled = false;

            }
        }

        private void removerMetroButton_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(this, "Deseja remover a Conversão selecionada?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    if (!FuncoesConversaoUnidadeMedida.Remover(Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCONVERSAOUNIDADEDEMEDIDA").ToString())))
                        throw new Exception("Não foi possível remover a Conversão.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizaConversaoUM();
            }
            editarconvundmetroButton4.Enabled = false;
            removerMetroButton.Enabled = false;
        }

        private void novoMetroButton_Click(object sender, EventArgs e)
        {
            FCA_ConversaoUM t = new FCA_ConversaoUM(new ConversaoUnidadeDeMedida());
            t.ShowDialog(this);
            AtualizaConversaoUM();
            editarconvundmetroButton4.Enabled = false;
            removerMetroButton.Enabled = false;
        }

        private void imprimirMetroButton_Clic(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
            editarconvundmetroButton4.Enabled = false;
            removerMetroButton.Enabled = false;
        }
    }
}
