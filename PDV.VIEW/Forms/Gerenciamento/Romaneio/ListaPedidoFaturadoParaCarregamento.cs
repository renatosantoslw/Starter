using DevExpress.XtraGrid.Views.Grid;
using PDV.CONTROLER.Funcoes;
using PDV.VIEW.Forms.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Gerenciamento.Romaneio
{
    public partial class ListaPedidoFaturadoParaCarregamento : DevExpress.XtraEditors.XtraForm
    {
        private DataTable table;
        private string status;
        private int indexColunaSelecionado = -1;
        public List<decimal> idSelecionados;
        public ListaPedidoFaturadoParaCarregamento()
        {
            InitializeComponent();
            PreencherTabela();
        }
        private void PreencherTabela()
        {
            table = FuncoesVenda.GetVendasNãoCarredasNoRomaneio();
            gridControl1.DataSource = table;
            FormatarTabela();
        }
        private void FormatarTabela()
        {   Grids.FormatGrid(ref gridView1, "NÚM. DAV");
            Grids.FormatColumnType(ref gridView1, "valortotal", GridFormats.Finance);

        }

        private List<decimal> GetIDSelecionados()
        {
            List<decimal> ids = new List<decimal>();
            int[] linhas = gridView1.GetSelectedRows();

            for (int i = 0; i < linhas.Length; i++)
                ids.Add(Convert.ToDecimal(gridView1.GetRowCellValue(linhas[i], gridView1.Columns[0].FieldName)));

            return ids;
        }
        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            PreencherTabela();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            idSelecionados = GetIDSelecionados();
            Close();
        }

    }
}
