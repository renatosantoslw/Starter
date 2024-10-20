using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.Financeiro;
using PDV.VIEW.Forms.Cadastro.Financeiro;
using System;
using System.Data;
using System.Windows.Forms;
using PDV.VIEW.Forms.Util;

namespace PDV.VIEW.Forms.Consultas.Financeiro
{
    public partial class FCO_CentroCusto : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE CENTRO DE CUSTO";
        private DataTable DADOS = null;

        public FCO_CentroCusto()
        {
            InitializeComponent();
            Atualizar();
        }

    
        private void Atualizar()
        {
            DADOS = FuncoesCentroCusto.GetCentroCusto("", "");
            gridControl1.DataSource = DADOS;
            FormatarGrid();
        }

        private void FormatarGrid()
        {
            Grids.FormatColumnType(ref gridView1, "tipodemovimento", GridFormats.VisibleFalse);
            Grids.FormatGrid(ref gridView1);
        }

        private void FCO_CentroCusto_Load(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            new FCA_CentroCusto(new CentroCusto()).ShowDialog(this);
            Atualizar();      

            DesabilitarBotoes();
        }

        private void DesabilitarBotoes()
        {
            btnEditar.Enabled = btnRemover.Enabled = true;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o Centro de Custo selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    if (!FuncoesCentroCusto.Remover(Grids.GetValorDec(gridView1, "idcentrocusto")))
                        throw new Exception("Não foi possível remover o Centro de Custo.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Atualizar();
            }
            DesabilitarBotoes();

        }


        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
            DesabilitarBotoes();
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            Atualizar();
            DesabilitarBotoes();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Editar();            
        }

        private void Editar()
        {
            try
            {
                FCA_CentroCusto Form = new FCA_CentroCusto(Grids.GetValorDec(gridView1, "idcentrocusto"));
                Form.ShowDialog(this);
                Atualizar();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            DesabilitarBotoes();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = btnRemover.Enabled = true;
        }
    }
}
