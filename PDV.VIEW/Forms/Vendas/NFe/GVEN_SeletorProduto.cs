using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Vendas.NFe
{
    public partial class GVEN_SeletorProduto : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "Pesquisa de Produtos";
        public DataRow drProduto = null;
        private bool _ValidarIntegracaoFiscalNFe;
        private int linhaSelecionada;

        public GVEN_SeletorProduto(bool ValidarIntegracaoFiscalNFe)
        {
            InitializeComponent();
            _ValidarIntegracaoFiscalNFe = ValidarIntegracaoFiscalNFe;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            AdicionarItem();
        }

        private void AtualizaProdutos(string Descricao)
        {
            gridControl1.DataSource = FuncoesProduto.GetProdutosPorDescricao(Descricao, _ValidarIntegracaoFiscalNFe, false);
            AjustaHeaderTextGrid();
            gridView1.BestFitColumns();
        }

        private void AjustaHeaderTextGrid()
        {

            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                switch (gridView1.Columns[i].AbsoluteIndex)
                {
                    case 2:
                        gridView1.Columns[i].Caption = "CÓDIGO DE BARRAS";
                        break;
                    case 3:
                        gridView1.Columns[i].Caption = "NOME";
                        break;
                    case 4:
                        gridView1.Columns[i].Caption = "MARCA";
                        break;
                    case 7:
                        gridView1.Columns[i].Caption = "PREÇO";
                        gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gridView1.Columns[i].DisplayFormat.FormatString = "c2";
                        break;
                    default:
                        gridView1.Columns[i].Visible = false;
                        break;
                }

            }
        }

        private void GVEN_SeletorProduto_Load(object sender, System.EventArgs e)
        {
            AtualizaProdutos(string.Empty);
        }

        private void AdicionarItem()
        {
            try
            {
                if (linhaSelecionada < 0)
                {
                    MessageBox.Show(this, "Selecione um Item.", NOME_TELA);
                    return;
                }

                drProduto = gridView1.GetDataRow(linhaSelecionada >= 0 ? linhaSelecionada:0);
                if (drProduto == null)
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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            AdicionarItem();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            linhaSelecionada = gridView1.FocusedRowHandle;
        }
    }
}
