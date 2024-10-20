using MetroFramework.Forms;
using PDV.UTIL.Components.UControl;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Estoque.PedidoDeCompra
{
    public partial class FCA_ItemPedidoCompra : DevExpress.XtraEditors.XtraForm
    {
        public DataTable DADOS = null;
        public bool Salvou = false;

        public FCA_ItemPedidoCompra(DataTable _DADOS)
        {
            InitializeComponent();
            DADOS = _DADOS;
            PreencherTela();
            
            ovTableLayoutItens.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
        }

        private void PreencherTela()
        {
            foreach (DataRow dr in DADOS.Rows)
                ovTableLayoutItens.Controls.Add(new UC_ProdutoPedidoCompra(dr));
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Salvou = false;
            Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            foreach (UC_ProdutoPedidoCompra Control in ovTableLayoutItens.Controls)
            {
                var lQuery = Control.CurrentRow.Table.AsEnumerable().Where(o => Convert.ToDecimal(o["IDPRODUTO"]) == Convert.ToDecimal(Control.CurrentRow["IDPRODUTO"]) &&
                                                                                o["PRODUTO"].ToString().ToUpper().Contains(ovTXT_Descricao.Text.ToUpper()) &&
                                                                               (o["CODIGO"].ToString().ToUpper().Contains(ovTXT_Codigo.Text.ToUpper()) ||
                                                                                o["EAN"].ToString().ToUpper().Contains(ovTXT_Codigo.Text.ToUpper())));
                Control.Visible = lQuery != null && lQuery.Count() > 0;
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Salvou = true;
            Close();
        }
    }
}
