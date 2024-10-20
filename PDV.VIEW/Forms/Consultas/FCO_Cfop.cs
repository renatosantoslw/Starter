using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
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
    public partial class FCO_Cfop : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE CFOP";

        public FCO_Cfop()
        {
            InitializeComponent();
            AtualizaCFOPS("", "");
        }

        private void AtualizaCFOPS(string Codigo, string Descricao)
        {
            gridControl1.DataSource = FuncoesCFOP.GetCFOPS(Codigo, Descricao);
            AjustaHeaderTextGrid();

        }

        private void AjustaHeaderTextGrid()
        {
            Grids.FormatGrid(ref gridView1);
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizaCFOPS("", "");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FCA_Cfop t = new FCA_Cfop(new DAO.Entidades.Cfop());
            t.ShowDialog(this);
            AtualizaCFOPS("","");
        }

        private void editarCategoriaMetroButton4_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o CFOP selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                var id = Grids.GetValorDec(gridView1, "IDCFOP");
                try
                {
                    if (!FuncoesCFOP.Remover(id))
                        throw new Exception("Não foi possível remover o CFOP.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizaCFOPS("", "");
            }
            DesabilitarBotoes();      
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
            DesabilitarBotoes();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            btoEditar.Enabled = true;
            btnRemover.Enabled = true;
        }

        private void Editar()
        {
            try
            {
                var id = Grids.GetValorDec(gridView1, "IDCFOP");
                FCA_Cfop t = new FCA_Cfop(FuncoesCFOP.GetCFOP(id));
                t.ShowDialog(this);
                AtualizaCFOPS("", "");
            }
            catch (NullReferenceException)
            {
            }
            finally
            {
                DesabilitarBotoes();
            }
        }

        private void DesabilitarBotoes()
        {
            btoEditar.Enabled = btnRemover.Enabled = true;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Editar();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "idcfop")
                e.Column.Width = 100;
        }
    }
}
