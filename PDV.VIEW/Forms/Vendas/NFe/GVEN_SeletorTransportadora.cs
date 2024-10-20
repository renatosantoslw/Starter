using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Vendas.NFe
{
    public partial class GVEN_SeletorTransportadora : DevExpress.XtraEditors.XtraForm
    {
        public DataRow DRTransportadora = null;
        private DataTable TRANSPORTADORAS = null;

        public GVEN_SeletorTransportadora()
        {
            InitializeComponent();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                decimal IDTransportadora = Convert.ToDecimal(ZeusUtil.GetValueFieldDataRowView((ovGRD_Transportadoras.CurrentRow.DataBoundItem as DataRowView), "IDTRANSPORTADORA"));
                DRTransportadora = TRANSPORTADORAS.AsEnumerable().Where(o => Convert.ToDecimal(o["IDTRANSPORTADORA"]) == IDTransportadora).FirstOrDefault();
                Close();
            }
            catch
            {
                MessageBox.Show(this, "Selecione uma Transportadora.", "PESQUISA DE TRANSPORTADORAS");
            }
        }

        private void GVEN_SeletorTransportadora_Load(object sender, EventArgs e)
        {
            AjustaTextHeader();
            AtualizaTransportadoras(ovTXT_RazaoSocial.Text);
        }

        private void AtualizaTransportadoras(string Nome_RazaoSocial)
        {
            TRANSPORTADORAS = FuncoesTransportadora.GetTransportadoras(Nome_RazaoSocial);
            ovGRD_Transportadoras.DataSource = TRANSPORTADORAS;
            AjustaTextHeader();
        }

        private void AjustaTextHeader()
        {
            ovGRD_Transportadoras.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Transportadoras.Width;
            foreach (DataGridViewColumn column in ovGRD_Transportadoras.Columns)
            {
                switch (column.Name)
                {
                    case "nome":
                        column.HeaderText = "DESCRIÇÃO";
                        column.DisplayIndex = 1;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.75);
                        column.Width = Convert.ToInt32(WidthGrid * 0.75);
                        break;
                    case "numerodocumento":
                        column.HeaderText = "DOCUMENTO";
                        column.DisplayIndex = 2;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.25);
                        column.Width = Convert.ToInt32(WidthGrid * 0.25);
                        break;
                    default:
                        column.Visible = false;
                        break;
                }
            }
        }

        private void ovTXT_RazaoSocial_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AtualizaTransportadoras(ovTXT_RazaoSocial.Text);
        }

        private void ovGRD_Transportadoras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal IDTransportadora = Convert.ToDecimal(ZeusUtil.GetValueFieldDataRowView((ovGRD_Transportadoras.CurrentRow.DataBoundItem as DataRowView), "IDTRANSPORTADORA"));
                DRTransportadora = TRANSPORTADORAS.AsEnumerable().Where(o => Convert.ToDecimal(o["IDTRANSPORTADORA"]) == IDTransportadora).FirstOrDefault();
                Close();
            }
            catch
            {
                MessageBox.Show(this, "Selecione uma Transportadora.", "PESQUISA DE TRANSPORTADORAS");
            }
        }

    }
}
