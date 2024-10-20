using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_Emitente : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE EMITENTE";
        public FCO_Emitente()
        {
            InitializeComponent();
        }

        private void AtualizaEmitente(string Nome_RazaoSocial, string CPF_CNPJ, string InscricaoEstadual)
        {
            try
            {
                gridControl1.DataSource = FuncoesEmitente.GetEmitentePesquisa(Nome_RazaoSocial, CPF_CNPJ, InscricaoEstadual);
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                gridView1.BestFitColumns();
                AjustaHeaderTextGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void AjustaHeaderTextGrid()
        {
           

            gridView1.Columns[0].Caption = "IDEMITENTE";
            gridView1.Columns[1].Caption = "DESCRICAO";
            gridView1.Columns[2].Caption = "NUMERODOCUMENTO";
            gridView1.Columns[3].Caption = "INSCRICAOESTADUAL";
            gridView1.Columns[4].Caption = "TIPO";
            gridView1.Columns[5].Caption = "ATIVO";
        }

        private void ovBTN_Novo_Click(object sender, System.EventArgs e)
        {
            FCA_Emitente t = new FCA_Emitente(new DAO.Entidades.Emitente());
            t.ShowDialog(this);
            AtualizaEmitente(ovTXT_RazaoSocial.Text, ovTXT_CPFCNPJ.Text, ovTXT_InscricaoEstadual.Text);

        }

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        {
            decimal IDEmitente = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDEmitente").ToString()));
            FCA_Emitente t = new FCA_Emitente(FuncoesEmitente.GetEmitentePorID(IDEmitente));
            t.ShowDialog(this);
            AtualizaEmitente(ovTXT_RazaoSocial.Text, ovTXT_CPFCNPJ.Text, ovTXT_InscricaoEstadual.Text);
            editarMetroButton.Enabled = false;
        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o cliente selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    decimal IDCliente = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCLIENTE").ToString()));

                    if (!FuncoesCliente.Remover(IDCliente))
                    {
                        MessageBox.Show(this, "Não foi possível remover o cliente.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    AtualizaEmitente(ovTXT_RazaoSocial.Text, ovTXT_CPFCNPJ.Text, ovTXT_InscricaoEstadual.Text);
                    editarMetroButton.Enabled = false;
                }
                catch (Exception EX)
                {
                    MessageBox.Show(this, EX.Message, NOME_TELA);
                }

            }
        }

        private void ovBTN_LimparFiltros_Click(object sender, EventArgs e)
        {
            ovTXT_CPFCNPJ.Text = string.Empty;
            ovTXT_InscricaoEstadual.Text = string.Empty;
            ovTXT_RazaoSocial.Text = string.Empty;
        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            AtualizaEmitente(ovTXT_RazaoSocial.Text, ZeusUtil.SomenteNumeros(ovTXT_CPFCNPJ.Text), ovTXT_InscricaoEstadual.Text);
        }

        private void FCO_Cliente_Load(object sender, EventArgs e)
        {
            AtualizaEmitente(ovTXT_RazaoSocial.Text, ovTXT_CPFCNPJ.Text, ovTXT_InscricaoEstadual.Text);
        }

        private void ovGRD_Clientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal IDCliente = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCLIENTE").ToString()));
            FCA_Cliente t = new FCA_Cliente(FuncoesCliente.GetCliente(IDCliente));
            t.ShowDialog(this);
            AtualizaEmitente(ovTXT_RazaoSocial.Text, ovTXT_CPFCNPJ.Text, ovTXT_InscricaoEstadual.Text);
            editarMetroButton.Enabled = false;
        }

        private void ovGRD_Clientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            editarMetroButton.Enabled = true;
        }
    }
}
