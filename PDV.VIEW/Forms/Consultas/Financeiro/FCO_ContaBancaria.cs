using System.Collections.Generic;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.Financeiro;
using PDV.VIEW.Forms.Cadastro.Financeiro;
using PDV.VIEW.Forms.Util;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas.Financeiro
{
    public partial class FCO_ContaBancaria : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE CONTA BANCÁRIA";
        private DataTable DADOS = null;

        public FCO_ContaBancaria()
        {
            InitializeComponent();
            Atualizar();
        }


        private void FCO_ContaBancaria_Load(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void Atualizar()
        {
            DADOS = FuncoesContaBancaria.GetContasBancarias("");
            gridControl1.DataSource = DADOS;
            FormatarGrid();
        }

        private void FormatarGrid()
        {
            Grids.FormatColumnType(ref gridView1, new List<string>() 
            { 
                "caixa","idbanco"
            
            }, GridFormats.VisibleFalse);
            
            Grids.FormatGrid(ref gridView1);

        }


        private void metroButton5_Click(object sender, EventArgs e)
        {
            new FCA_ContaBancaria(new ContaBancaria()).ShowDialog(this);
            Atualizar();
            DesabilitarBotoes();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Editar();
            
        }

        private void Editar()
        {
            try
            {
                var id = Grids.GetValorDec(gridView1, "idcontabancaria");
                FCA_ContaBancaria FormContaBancaria = new FCA_ContaBancaria(FuncoesContaBancaria.GetContaBancaria(id));
                FormContaBancaria.ShowDialog(this);
                Atualizar();
            }
            catch (Exception)
            {

            }
            finally
            {
                DesabilitarBotoes();

            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover a Conta Bancária selecionada?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    if (!FuncoesContaBancaria.Remover(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCONTABANCARIA").ToString())))
                        throw new Exception("Não foi possível remover a Conta Bancária.");
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

        private void gridControl1_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnRemover.Enabled = true;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            Atualizar();
            DesabilitarBotoes();
            
        }

        private void DesabilitarBotoes()
        {
            btnEditar.Enabled = btnRemover.Enabled = false;
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
            DesabilitarBotoes();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

            Editar();
        }
    }
}
