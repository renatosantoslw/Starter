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
    public partial class FCO_Fornecedor : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "Consulta de Fornecedor";
        public FCO_Fornecedor()
        {
            InitializeComponent();
        }



        private void metroButton5_Click(object sender, System.EventArgs e)
        {
            FCA_Fornecedor t = new FCA_Fornecedor(new DAO.Entidades.Fornecedor());
            t.ShowDialog(this);
            AtualizarFornecedor("", "");
        }

        private void metroButton4_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                decimal IDFornecedor = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDFORNECEDOR").ToString());
                FCA_Fornecedor t = new FCA_Fornecedor(FuncoesFornecedor.GetFornecedor(IDFornecedor));
                t.ShowDialog(this);
                AtualizarFornecedor("", "");
                
            }
            catch (Exception)
            {

            }
            finally
            {
                editarforncedormetroButton.Enabled = false;
                metroButton3.Enabled = false;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Deseja remover o fornecedor selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    decimal IDTransportadora = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDFORNECEDOR").ToString());
                    if (!FuncoesFornecedor.Remover(IDTransportadora))
                    {
                        MessageBox.Show(this, "Não foi possível remover o Transportadora.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    AtualizarFornecedor("", "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            editarforncedormetroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void AtualizarFornecedor(string RazaoSocial, string CNPJ)
        {
            gridControl1.DataSource = FuncoesFornecedor.GetFornecedores(RazaoSocial, CNPJ);
            FormatarGrid();
        }

        private void FormatarGrid()
        {
            Grids.FormatGrid(ref gridView1);
        }

        private void FCO_Fornecedor_Load(object sender, EventArgs e)
        {
            AtualizarFornecedor("", "");
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            editarforncedormetroButton.Enabled = true;
            metroButton3.Enabled = true;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizarFornecedor("", "");
            editarforncedormetroButton.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                decimal IDFornecedor = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDFORNECEDOR").ToString()));
                FCA_Fornecedor t = new FCA_Fornecedor(FuncoesFornecedor.GetFornecedor(IDFornecedor));
                t.ShowDialog(this);
                AtualizarFornecedor("", "");
                editarforncedormetroButton.Enabled = false;
                metroButton3.Enabled = false;
            }
            catch (Exception)
            {

            }
        }
    }
}
