using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Util;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_Transportadora : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE TRANSPORTADORAS";
        public FCO_Transportadora()
        {
            InitializeComponent();
            AtualizarTransportadora("", "", "");
        }

        private void AtualizarTransportadora(string Nome_RazaoSocial, string CPF_CNPJ, string InscricaoEstadual)
        {
            gridControl1.DataSource = FuncoesTransportadora.GetTransportadoras(Nome_RazaoSocial, CPF_CNPJ, InscricaoEstadual);
            FormatarGrid();
        }

        private void FormatarGrid()
        {
            Grids.FormatGrid(ref gridView1);
        }

        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {
            FCA_Transportadora t = new FCA_Transportadora(new DAO.Entidades.Transportadora());
            t.ShowDialog(this);
            AtualizarTransportadora("", "", "");
            editartranspmetroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        {
            try
            {

                decimal IDTransportadora = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDTRANSPORTADORA").ToString()));
                FCA_Transportadora t = new FCA_Transportadora(FuncoesTransportadora.GetTransportadora(IDTransportadora));
                t.ShowDialog(this);
                AtualizarTransportadora("", "", "");
            }
            catch (Exception)
            {

            }
            finally
            {
                editartranspmetroButton.Enabled = false;
                metroButton3.Enabled = false;
            }

        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover a transportadora selecionada?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                decimal IDTransportadora = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDTRANSPORTADORA").ToString()));
                if (!FuncoesTransportadora.Remover(IDTransportadora))
                {
                    MessageBox.Show(this, "Não foi possível remover a transportadora.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizarTransportadora("", "", "");
            }
            editartranspmetroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void FCO_Transportadora_Load(object sender, EventArgs e)
        {
            AtualizarTransportadora("", "", "");
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
            editartranspmetroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {
            editartranspmetroButton.Enabled = true;
            metroButton3.Enabled = true;
        }

        private void gridControl1_DoubleClick_1(object sender, EventArgs e)
        {

            try
            {
                decimal IDTransportadora = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDTRANSPORTADORA").ToString()));
                FCA_Transportadora t = new FCA_Transportadora(FuncoesTransportadora.GetTransportadora(IDTransportadora));
                t.ShowDialog(this);
                AtualizarTransportadora("", "", "");
                editartranspmetroButton.Enabled = false;
                metroButton3.Enabled = false;
            }
            catch (Exception)
            {

            }
            
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizarTransportadora("", "", "");
            editartranspmetroButton.Enabled = false;
            metroButton3.Enabled = false;
        }
    }
}
