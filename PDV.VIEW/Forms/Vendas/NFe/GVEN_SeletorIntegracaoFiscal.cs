using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Vendas.NFe
{
    public partial class GVEN_SeletorIntegracaoFiscal : DevExpress.XtraEditors.XtraForm
    {
        private DataTable Integracoes = null;
        public DataRow drIntegracao = null;
        private decimal IDCFOP = -1;
        private string NOME_TELA = "PESQUISA DE INTEGRAÇÃO FISCAL POR CFOP";

        public GVEN_SeletorIntegracaoFiscal(decimal _IDCFOP)
        {
            InitializeComponent();
            IDCFOP = _IDCFOP;

        }

        private void GVEN_SeletorIntegracaoFiscal_Load(object sender, EventArgs e)
        {
            Integracoes = FuncoesIntegracaoFiscal.GetInteracoesPorCFOP(IDCFOP);
            ovGRD_IntegracaoFiscal.DataSource = Integracoes;
            AjustaHeader();
        }

        private void AjustaHeader()
        {
            ovGRD_IntegracaoFiscal.RowHeadersVisible = false;
            int WidthGrid = ovGRD_IntegracaoFiscal.Width;

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font("Open Sans", 9, FontStyle.Regular);
            style.Alignment = DataGridViewContentAlignment.TopLeft;
            style.WrapMode = DataGridViewTriState.True;

            foreach (DataGridViewColumn column in ovGRD_IntegracaoFiscal.Columns)
            {
                switch (column.Name)
                {
                    case "codigo":
                        column.DisplayIndex = 1;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.15);
                        column.Width = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "CFOP";
                        break;
                    case "sequencia":
                        column.DisplayIndex = 2;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.15);
                        column.Width = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "SEQUÊNCIA";
                        break;
                    case "descricao":
                        column.DisplayIndex = 3;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.70);
                        column.Width = Convert.ToInt32(WidthGrid * 0.70);
                        column.HeaderText = "DESCRIÇÃO DA INTEGRAÇÃO FISCAL";
                        break;
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (ovGRD_IntegracaoFiscal.CurrentRow == null)
                {
                    MessageBox.Show(this, "Selecione um Item.", NOME_TELA);
                    return;
                }

                drIntegracao = (ovGRD_IntegracaoFiscal.CurrentRow.DataBoundItem as DataRowView).Row;
                if (drIntegracao == null)
                {
                    MessageBox.Show(this, "Selecione um Item.", NOME_TELA);
                    return;
                }
                Close();
            }
            catch
            {
                MessageBox.Show(this, "Não foi possível selecionar o Item.", NOME_TELA);
            }
        }

        private void ovGRD_IntegracaoFiscal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ovGRD_IntegracaoFiscal.CurrentRow == null)
                {
                    MessageBox.Show(this, "Selecione um Item.", NOME_TELA);
                    return;
                }

                drIntegracao = (ovGRD_IntegracaoFiscal.CurrentRow.DataBoundItem as DataRowView).Row;
                if (drIntegracao == null)
                {
                    MessageBox.Show(this, "Selecione um Item.", NOME_TELA);
                    return;
                }
                Close();
            }
            catch
            {
                MessageBox.Show(this, "Não foi possível selecionar o Item.", NOME_TELA);
            }
        }

    }
}
