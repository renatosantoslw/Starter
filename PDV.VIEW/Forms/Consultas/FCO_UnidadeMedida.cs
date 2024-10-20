using FontAwesome.Sharp;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Util;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_UnidadeMedida : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE UNIDADE DE MEDIDA";
        public FCO_UnidadeMedida()
        {
            InitializeComponent();
            AtualizaUnidades("", "");


            //IconesFA.Icones24 icones2 = new IconesFA.Icones24();
            //icones

            Bitmap bitmapNovo = IconChar.PlusSquare.ToBitmap(Color.DarkGreen, 24);
            Bitmap bitmapEditar = IconChar.PenSquare.ToBitmap(Color.DarkOrange, 24);
            Bitmap bitmapRemover = IconChar.MinusSquare.ToBitmap(Color.Firebrick, 24);
            Bitmap bitmapAtualizar = IconChar.SyncAlt.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapImprimir = IconChar.Print.ToBitmap(Color.SteelBlue, 24);

            metroButton5.ImageOptions.Image = bitmapNovo;
            unidademetroButton.ImageOptions.Image = bitmapEditar;
            metroButton3.ImageOptions.Image = bitmapRemover;//remover
            atualizarMetroButton.ImageOptions.Image = bitmapAtualizar;
            imprimriMetroButton.ImageOptions.Image = bitmapImprimir;
        }

        private void AtualizaUnidades(string Codigo, string Descricao)
        {
            gridControl1.DataSource = FuncoesUnidadeMedida.GetUnidadesMedida(Codigo, Descricao);
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            Grids.FormatGrid(ref gridView1);
        }


        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {
            FCA_UnidadeMedida t = new FCA_UnidadeMedida(new UnidadeMedida());
            t.ShowDialog(this);
            AtualizaUnidades("", "");
        }

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        {
            /* decimal IDUnidadeMedida = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDUNIDADEMEDIDA").ToString());
             FCA_UnidadeMedida t = new FCA_UnidadeMedida(FuncoesUnidadeMedida.GetUnidadeMedida(IDUnidadeMedida));
             t.ShowDialog(this);
             AtualizaUnidades("", "");
             unidademetroButton.Enabled = false;*/
            Editar_Unidade();
        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover a Unidade de Medida selecionada?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                decimal IDUnidadeMedida = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDUNIDADEMEDIDA").ToString());
                try
                {
                    if (!FuncoesUnidadeMedida.Remover(IDUnidadeMedida))
                        throw new Exception("Não foi possível remover a Unidade de Medida.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizaUnidades("", "");
            }
        }

        private void FCO_UnidadeMedida_Load(object sender, EventArgs e)
        {
            AtualizaUnidades("", "");
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
             /*decimal IDUnidadeMedida = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDUNIDADEDEMEDIDA").ToString());
             FCA_UnidadeMedida t = new FCA_UnidadeMedida(FuncoesUnidadeMedida.GetUnidadeMedida(IDUnidadeMedida));
             t.ShowDialog(this);
             AtualizaUnidades("", "");
             unidademetroButton.Enabled = false;*/
           Editar_Unidade();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            unidademetroButton.Enabled = true;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizaUnidades("", "");
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
        }

        private void Editar_Unidade()
        {
            try
            {
                var id = Grids.GetValorDec(gridView1, "IDUNIDADEDEMEDIDA");
                FCA_UnidadeMedida t = new FCA_UnidadeMedida(FuncoesUnidadeMedida.GetUnidadeMedida(id));
                t.ShowDialog(this);
                AtualizaUnidades("", "");
            }
            catch (NullReferenceException)
            {
            }
            finally
            {
                //DesabilitarBotoes();
            }
        }
    }
}
