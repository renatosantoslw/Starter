using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_UnidadeFederativa : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE UNIDADE FEDERATIVA";

        public FCO_UnidadeFederativa()
        {
            InitializeComponent();            
        }

        private void AtualizaUnidades(string Codigo, string Descricao)
        {
            ovGRD_Unidades.DataSource = FuncoesUF.GetUnidadesFederativa(Codigo, Descricao);
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Unidades.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Unidades.Width;
            foreach (DataGridViewColumn column in ovGRD_Unidades.Columns)
            {
                switch (column.Name)
                {
                    case "unidadefederativa":
                        column.DisplayIndex = 1;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.55);
                        column.Width = Convert.ToInt32(WidthGrid * 0.55);
                        column.HeaderText = "DESCRIÇÃO";
                        break;
                    case "sigla":
                        column.DisplayIndex = 2;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.15);
                        column.Width = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "SIGLA";
                        break;
                    case "pais":
                        column.DisplayIndex = 3;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.30);
                        column.Width = Convert.ToInt32(WidthGrid * 0.30);
                        column.HeaderText = "PAIS";
                        break;
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }
        }

        private void ovBTN_LimparFiltros_Click(object sender, System.EventArgs e)
        {
            ovTXT_Sigla.Text = string.Empty;
            ovTXT_Descricao.Text = string.Empty;
        }

        private void ovBTN_Pesquisar_Click(object sender, System.EventArgs e)
        {
            AtualizaUnidades(ovTXT_Sigla.Text, ovTXT_Descricao.Text);
        }

        private void ovBTN_Novo_Click(object sender, System.EventArgs e)
        {
            FCA_UnidadeFederativa t = new FCA_UnidadeFederativa(new UnidadeFederativa());
            t.ShowDialog(this);
            AtualizaUnidades(ovTXT_Sigla.Text, ovTXT_Descricao.Text);
        }

        private void ovBTN_Editar_Click(object sender, System.EventArgs e)
        {
            decimal IDUF = Convert.ToDecimal(ZeusUtil.GetValueFieldDataRowView((ovGRD_Unidades.CurrentRow.DataBoundItem as DataRowView), "IDUNIDADEFEDERATIVA"));
            FCA_UnidadeFederativa t = new FCA_UnidadeFederativa(FuncoesUF.GetUnidadeFederativa(IDUF));
            t.ShowDialog(this);
            AtualizaUnidades(ovTXT_Sigla.Text, ovTXT_Descricao.Text);
            editarufmetroButton4.Enabled = false;
        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover a Unidade Federativa selecionada?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                decimal IDUF = Convert.ToDecimal(ZeusUtil.GetValueFieldDataRowView((ovGRD_Unidades.CurrentRow.DataBoundItem as DataRowView), "IDUNIDADEFEDERATIVA"));
                try
                {
                    if (!FuncoesUF.Remover(IDUF))
                        throw new Exception("Não foi possível remover a Unidade Federativa.");
                }
                catch (Exception Ex)
                {
                   MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizaUnidades(ovTXT_Sigla.Text, ovTXT_Descricao.Text);
            }
        }

        private void FCO_UnidadeFederativa_Load(object sender, EventArgs e)
        {
            AtualizaUnidades(ovTXT_Sigla.Text, ovTXT_Descricao.Text);
        }

        private void ovGRD_Unidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal IDUF = Convert.ToDecimal(ZeusUtil.GetValueFieldDataRowView((ovGRD_Unidades.CurrentRow.DataBoundItem as DataRowView), "IDUNIDADEFEDERATIVA"));
            FCA_UnidadeFederativa t = new FCA_UnidadeFederativa(FuncoesUF.GetUnidadeFederativa(IDUF));
            t.ShowDialog(this);
            AtualizaUnidades(ovTXT_Sigla.Text, ovTXT_Descricao.Text);
            editarufmetroButton4.Enabled = false;
        }

        private void ovGRD_Unidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            editarufmetroButton4.Enabled = true;
        }
    }
}
