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
    public partial class GVEN_SeletorClientes : DevExpress.XtraEditors.XtraForm
    {
        public DataRow DRCliente = null;
        private DataTable CLIENTES = null;

        public GVEN_SeletorClientes()
        {
            InitializeComponent();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GVEN_SeletorClientes_Load(object sender, EventArgs e)
        {
            AjustaTextHeader();
            AtualizaClientes(ovTXT_RazaoSocial.Text);
        }

        private void AtualizaClientes(string Nome_RazaoSocial)
        {
            CLIENTES = FuncoesCliente.GetClientesNFe(Nome_RazaoSocial);
            ovGRD_Clientes.DataSource = CLIENTES;
            AjustaTextHeader();
        }

        private void AjustaTextHeader()
        {
            ovGRD_Clientes.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Clientes.Width;
            foreach (DataGridViewColumn column in ovGRD_Clientes.Columns)
            {
                switch (column.Name)
                {
                    case "nome":
                        column.HeaderText = "NOME/FANTASIA";
                        column.DisplayIndex = 2;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.75);
                        column.Width = Convert.ToInt32(WidthGrid * 0.75);
                        break;
                    case "documento":
                        column.HeaderText = "DOCUMENTO";
                        column.DisplayIndex = 4;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.25);
                        column.Width = Convert.ToInt32(WidthGrid * 0.25);
                        break;
                    default:
                        column.Visible = false;
                        break;
                }
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                decimal IDCliente = Convert.ToDecimal(ZeusUtil.GetValueFieldDataRowView((ovGRD_Clientes.CurrentRow.DataBoundItem as DataRowView), "IDCLIENTE"));
                DRCliente = CLIENTES.AsEnumerable().Where(o => Convert.ToDecimal(o["IDCLIENTE"]) == IDCliente).FirstOrDefault();
                Close();
            }
            catch
            {
                MessageBox.Show(this, "Selecione um Cliente.", "PESQUISA DE CLIENTES");
            }
        }

        private void ovTXT_RazaoSocial_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AtualizaClientes(ovTXT_RazaoSocial.Text);
        }

        private void ovGRD_Clientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal IDCliente = Convert.ToDecimal(ZeusUtil.GetValueFieldDataRowView((ovGRD_Clientes.CurrentRow.DataBoundItem as DataRowView), "IDCLIENTE"));
                DRCliente = CLIENTES.AsEnumerable().Where(o => Convert.ToDecimal(o["IDCLIENTE"]) == IDCliente).FirstOrDefault();
                Close();
            }
            catch
            {
                MessageBox.Show(this, "Selecione um Cliente.", "PESQUISA DE CLIENTES");
            }
        }
    }
}
