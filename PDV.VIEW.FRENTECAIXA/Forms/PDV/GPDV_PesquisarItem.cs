using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using System;
using System.Drawing;
using System.Windows.Forms;
using PDV.VIEW.Forms.Util;
using System.Collections.Generic;
using DevExpress.Office.Utils;
using DevExpress.XtraEditors;
using System.Reflection;
using DevExpress.XtraGrid.Controls;
using DevExpress.XtraGrid.Views.Grid;

namespace PDV.VIEW.FRENTECAIXA.Forms
{
    public partial class GPDV_PesquisarItem : Form
    {
        private GPDV_PainelInicial TELAINICIAL = null;
        private string NOME_TELA = "PESQUISAR ITEM";
        public string CBarras { get; set; }
        public string CBarrasPesquisa { get; set; }

        public GPDV_PesquisarItem(GPDV_PainelInicial _TELAINICIAL)
        {
            InitializeComponent();
            TELAINICIAL = _TELAINICIAL;
        }

        private void AtualizaProdutos(string Descricao)
        {
            gridControl1.DataSource = FuncoesProduto.GetProdutosPorDescricao(Descricao, false, true);
            AjustaHeaderTextGrid();

            PropertyInfo property = typeof(GridView).GetProperty("FindPanel", BindingFlags.Instance | BindingFlags.NonPublic);
            FindControl findPanel = property.GetValue(gridView1) as FindControl;
            findPanel.FindEdit.Text = CBarrasPesquisa;
            findPanel.Focus();

        }

        private void AjustaHeaderTextGrid()
        {
            Grids.FormatColumnType(ref gridView1, new List<string>() 
            { 
               "unidadedemedida", "unidadedemedidasigla", "ncm", "extipi" 
            }, GridFormats.VisibleFalse);//grid bem formatada


            Grids.FormatColumnType(ref gridView1, "precovenda", GridFormats.Finance);

            Grids.FormatGrid(ref gridView1);
        }

        private void AdicionarItem()
        {
            try
            {
                CBarras = Grids.GetValorStr(gridView1, "CODIGO");
                Close();
            }
            catch
            {
                MessageBox.Show(this, "Não foi possível selecionar o Item.", NOME_TELA);
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {

            switch (keyData)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.F2:
                    AdicionarItem();
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }


        private void GPDV_PesquisarItem_Load_1(object sender, EventArgs e)
        {
            AtualizaProdutos(string.Empty);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            AdicionarItem();
        }

        private void gridControl1_EditorKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AdicionarItem();
            if (e.KeyCode == Keys.F8)
                PesquisarPorDescricao();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            PesquisarPorDescricao();
        }

        private void PesquisarPorDescricao()
        {
            AtualizaProdutos(XtraInputBox.Show("Pesquise produtos por nome: ", "Pesquisar produto", ""));
        }
    }
}
