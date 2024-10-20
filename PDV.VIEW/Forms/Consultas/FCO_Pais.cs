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
    public partial class FCO_Pais : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE PAIS";

        public FCO_Pais()
        {
            InitializeComponent();            
        }

        private void AtualizaPaises(string Descricao)
        {
            ovGRD_Paises.DataSource = FuncoesPais.GetPaises(Descricao);
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Paises.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Paises.Width;
            foreach (DataGridViewColumn column in ovGRD_Paises.Columns)
            {
                switch (column.Name)
                {
                    case "idpais":
                        column.Visible = false;
                        break;
                    case "descricao":
                        column.MinimumWidth = Convert.ToInt32(WidthGrid);
                        column.Width = Convert.ToInt32(WidthGrid);
                        column.HeaderText = "DESCRIÇÃO";
                        break;
                }
            }
        }

        private void ovBTN_Novo_Click(object sender, System.EventArgs e)
        {
            FCA_Pais t = new FCA_Pais(new Pais());
            t.ShowDialog(this);
            AtualizaPaises(ovTXT_Descricao.Text);
        }

        private void ovBTN_Editar_Click(object sender, System.EventArgs e)
        {
            decimal IDPais = Convert.ToDecimal(ZeusUtil.GetValueFieldDataRowView((ovGRD_Paises.CurrentRow.DataBoundItem as DataRowView), "IDPAIS"));
            FCA_Pais t = new FCA_Pais(FuncoesPais.GetPais(IDPais));
            t.ShowDialog(this);
            AtualizaPaises(ovTXT_Descricao.Text);
            editarPaismetroButton.Enabled = false;
        }

        private void ovBTN_Excluir_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o Pais selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                decimal IDPais = Convert.ToDecimal(ZeusUtil.GetValueFieldDataRowView((ovGRD_Paises.CurrentRow.DataBoundItem as DataRowView), "IDPAIS"));
                try
                {
                    if (!FuncoesPais.Remover(IDPais))
                        throw new Exception("Não foi possível remover o Pais.");
                }
                catch (Exception Ex)
                {
                   MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizaPaises(ovTXT_Descricao.Text);
            }
        }

        private void ovBTN_LimparFiltros_Click(object sender, System.EventArgs e)
        {
            ovTXT_Descricao.Text = string.Empty;
        }

        private void ovBTN_Pesquisar_Click(object sender, System.EventArgs e)
        {
            AtualizaPaises(ovTXT_Descricao.Text);
        }

        private void FCO_Pais_Load(object sender, EventArgs e)
        {
            AtualizaPaises(ovTXT_Descricao.Text);
        }

        private void ovGRD_Paises_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal IDPais = Convert.ToDecimal(ZeusUtil.GetValueFieldDataRowView((ovGRD_Paises.CurrentRow.DataBoundItem as DataRowView), "IDPAIS"));
            FCA_Pais t = new FCA_Pais(FuncoesPais.GetPais(IDPais));
            t.ShowDialog(this);
            AtualizaPaises(ovTXT_Descricao.Text);
            editarPaismetroButton.Enabled = false;
        }

        private void ovGRD_Paises_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            editarPaismetroButton.Enabled = true;
        }
    }
}
