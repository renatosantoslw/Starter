using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.VIEW.Forms.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Estoque.ImportacaoNFeEntrada
{
    public partial class FEST_SeletorProduto : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "Pesquisa de Produtos";
        public DataRow drProduto = null;
        private decimal _CodigoNCM;

        public FEST_SeletorProduto(decimal CodigoNCM)
        {
            InitializeComponent();
            _CodigoNCM = CodigoNCM;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            AdicionarItem();
        }

        private void ovTXT_Nome_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AtualizaProdutos("");
        }

        private void AtualizaProdutos(string Descricao)
        {
            gridControl1.DataSource = FuncoesProduto.GetProdutosPorNCM(Descricao, _CodigoNCM);
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            Grids.FormatGrid(ref gridView1);
            Grids.FormatColumnType(ref gridView1, new List<string> 
            { 
                "codigo",
                "extipi",
                "unidadedemedida"
            }, GridFormats.VisibleFalse);
        }

        private void GVEN_SeletorProduto_Load(object sender, System.EventArgs e)
        {
            AtualizaProdutos(string.Empty);
        }

        private void AdicionarItem()
        {
            try
            {
                int rowHandle = gridView1.FocusedRowHandle;
                drProduto = gridView1.GetDataRow(rowHandle);
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
    }
}
