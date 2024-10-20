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
    public partial class FCO_Municipio : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE MUNICÍPIO";
        public FCO_Municipio()
        {
            InitializeComponent();            
        }

        private void AtualizaMunicipios(string Descricao)
        {
            ovGRD_Municipios.DataSource = FuncoesMunicipio.GetMunicipios(Descricao);
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Municipios.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Municipios.Width;
            foreach (DataGridViewColumn column in ovGRD_Municipios.Columns)
            {
                switch (column.Name)
                {
                    case "descricao":
                        column.DisplayIndex = 1;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.75);
                        column.Width = Convert.ToInt32(WidthGrid * 0.75);
                        column.HeaderText = "DESCRIÇÃO";
                        break;
                    case "unidadefederativa":
                        column.DisplayIndex = 3;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.25);
                        column.Width = Convert.ToInt32(WidthGrid * 0.25);
                        column.HeaderText = "UNIDADE FEDERATIVA";
                        break;                    
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }
        }

        private void ovBTN_LimparFiltros_Click(object sender, EventArgs e)
        {
            ovTXT_Descricao.Text = string.Empty;
        }

        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            AtualizaMunicipios(ovTXT_Descricao.Text);
        }

        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {
            FCA_Municipio t = new FCA_Municipio(new Municipio());
            t.ShowDialog(this);
            AtualizaMunicipios(ovTXT_Descricao.Text);
        }

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        {
            decimal IDMunicipio = Convert.ToDecimal(ZeusUtil.GetValueFieldDataRowView((ovGRD_Municipios.CurrentRow.DataBoundItem as DataRowView), "IDMUNICIPIO"));
            FCA_Municipio t = new FCA_Municipio(FuncoesMunicipio.GetMunicipio(IDMunicipio));
            t.ShowDialog(this);
            AtualizaMunicipios(ovTXT_Descricao.Text);
            editarmunicipiometroButton4.Enabled = false;
        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover a Unidade Federativa selecionada?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                decimal IDMunicipio = Convert.ToDecimal(ZeusUtil.GetValueFieldDataRowView((ovGRD_Municipios.CurrentRow.DataBoundItem as DataRowView), "IDMUNICIPIO"));
                try
                {
                    if (!FuncoesMunicipio.Remover(IDMunicipio))
                        throw new Exception("Não foi possível remover o Município.");
                }
                catch (Exception Ex)
                {
                   MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizaMunicipios(ovTXT_Descricao.Text);
            }
        }

        private void FCO_Municipio_Load(object sender, EventArgs e)
        {
            AtualizaMunicipios(ovTXT_Descricao.Text);
        }

        private void ovGRD_Municipios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal IDMunicipio = Convert.ToDecimal(ZeusUtil.GetValueFieldDataRowView((ovGRD_Municipios.CurrentRow.DataBoundItem as DataRowView), "IDMUNICIPIO"));
            FCA_Municipio t = new FCA_Municipio(FuncoesMunicipio.GetMunicipio(IDMunicipio));
            t.ShowDialog(this);
            AtualizaMunicipios(ovTXT_Descricao.Text);
            editarmunicipiometroButton4.Enabled = false;
        }

        private void ovGRD_Municipios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            editarmunicipiometroButton4.Enabled = true;
        }
    }
}
