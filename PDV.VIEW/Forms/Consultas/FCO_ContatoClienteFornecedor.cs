using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_ContatoClienteFornecedor : MetroForm
    {
        private string NOME_TELA = "CONSULTA CONTATOS DE ";
        public FCO_ContatoClienteFornecedor()
        {
            InitializeComponent();
        }

        private void AtualizaContatos(string Codigo, string Descricao)
        {
            //ovGRD_MOTIVOS.DataSource = FuncoesNcm.GetNcms(Codigo, Descricao);
            //AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            //ovGRD_MOTIVOS.RowHeadersVisible = false;
            //int WidthGrid = ovGRD_MOTIVOS.Width;
            //foreach (DataGridViewColumn column in ovGRD_MOTIVOS.Columns)
            //{
            //    switch (column.Name)
            //    {
            //        case "codigo":
            //            column.DisplayIndex = 1;
            //            column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.30);
            //            column.Width = Convert.ToInt32(WidthGrid * 0.30);
            //            column.HeaderText = "CÓDIGO";
            //            break;
            //        case "descricao":
            //            column.DisplayIndex = 2;
            //            column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.70);
            //            column.Width = Convert.ToInt32(WidthGrid * 0.70);
            //            column.HeaderText = "DESCRIÇÃO";
            //            break;
            //        default:
            //            column.DisplayIndex = 0;
            //            column.Visible = false;
            //            break;
            //    }
            //}
        }


        private void ovBTN_LimparFiltros_Click(object sender, EventArgs e)
        {
            ovTXT_Codigo.Text = string.Empty;
            ovTXT_Descricao.Text = string.Empty;
        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            //AtualizaNCMS(ovTXT_Codigo.Text, ovTXT_Descricao.Text);
        }

        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {
            //FCA_Ncm t = new FCA_Ncm(new DAO.Entidades.Ncm());
            //t.ShowDialog(this);
            //AtualizaNCMS(ovTXT_Codigo.Text, ovTXT_Descricao.Text);
        }

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        {
            //decimal IDNcm = Convert.ToDecimal(ZeusUtil.GetValueFieldDataRowView((ovGRD_MOTIVOS.CurrentRow.DataBoundItem as DataRowView), "IDNCM"));
            //FCA_Ncm t = new FCA_Ncm(FuncoesNcm.GetNCM(IDNcm));
            //t.ShowDialog(this);
            //AtualizaNCMS(ovTXT_Codigo.Text, ovTXT_Descricao.Text);
        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            //if (MetroMessageBox.Show(this, "Deseja remover o NCM selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{
            //    decimal IDNcm = Convert.ToDecimal(ZeusUtil.GetValueFieldDataRowView((ovGRD_MOTIVOS.CurrentRow.DataBoundItem as DataRowView), "IDNCM"));
            //    try
            //    {
            //        if (!FuncoesNcm.Remover(IDNcm))
            //            throw new Exception("Não foi possível remover o NCM.");
            //    }
            //    catch (Exception Ex)
            //    {
            //       MetroMessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    AtualizaNCMS(ovTXT_Codigo.Text, ovTXT_Descricao.Text);
            //}
        }

        private void FCO_ContatoClienteFornecedor_Load(object sender, EventArgs e)
        {
            //AtualizaNCMS(ovTXT_Codigo.Text, ovTXT_Descricao.Text);
        }
    }
}
