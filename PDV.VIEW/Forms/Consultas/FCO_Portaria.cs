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
    public partial class FCO_Portaria : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE PORTARIAS";

        public FCO_Portaria()
        {
            InitializeComponent();
            AtualizaPortarias("");
        }

        private void AtualizaPortarias(string Descricao)
        {
          
            gridControl1.DataSource = FuncoesPortaria.GetPortarias(Descricao);
            FormatarGrid();
        }

        private void FormatarGrid()
        {
            Grids.FormatGrid(ref gridView1);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            FCA_Portaria t = new FCA_Portaria(new DAO.Entidades.Portaria());
            t.ShowDialog(this);
            AtualizaPortarias("");
            DesabilitarBotoes();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover a Portaria selecionada?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                var id = Grids.GetValorDec(gridView1, "idportaria");
                try
                {
                    if (!FuncoesPortaria.Remover(id))
                        throw new Exception("Não foi possível remover a Portaria.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizaPortarias("");
            }
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizaPortarias("");
            DesabilitarBotoes();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnRemover.Enabled = true; 
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

            Editar();
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
            DesabilitarBotoes();
        }

        private void Editar()
        {
            try
            {
                var id = Grids.GetValorDec(gridView1, "idportaria");
                FCA_Portaria t = new FCA_Portaria(FuncoesPortaria.GetPortaria(id));
                t.ShowDialog(this);
                
                DesabilitarBotoes();
            }
            catch (NullReferenceException)
            {
            }
            finally 
            {
                AtualizaPortarias("");
            }
        }

        private void DesabilitarBotoes()
        {
            btnEditar.Enabled =  btnRemover.Enabled = false;
        }
    }
}
