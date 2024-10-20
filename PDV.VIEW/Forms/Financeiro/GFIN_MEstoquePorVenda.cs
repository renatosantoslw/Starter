using PDV.CONTROLER.Funcoes;
using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using DevExpress.XtraPrinting;
using PDV.VIEW.Forms.Util;
using PDV.DAO.GridViewModels;
using System.Collections.Generic;
using PDV.DAO.QueryModels;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class GFIN_MEstoquePorVenda : DevExpress.XtraEditors.XtraForm
    {
        public List<MovimentoDeEstoquePorVendaGridViewModel> MovimentoEstoquePorVenda { get; set; }
        public GFIN_MEstoquePorVenda()
        {
            InitializeComponent();
            PreencherDatas();
            Pesquisar();
            FormatarGrid();
        }

        private void FormatarGrid()
        {
            Grids.FormatGrid(ref gridView1, "ID DA VENDA");
            Grids.FormatColumnType(ref gridView1, "quantidade", GridFormats.Sum);
        }

        private void PreencherDatas()
        {
            dataDe.DateTime = DateTime.Today;
            dataAte.DateTime = dataDe.DateTime.AddDays(1);
        }

        private void FCA_Transportadora_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }       
      
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void gridView1_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.Landscape = true;
            pb.PageSettings.LeftMargin = pb.PageSettings.TopMargin = pb.PageSettings.BottomMargin = pb.PageSettings.RightMargin = 5;
        }
        private void Pesquisar()
        {
            try
            {
                var pesquisa = new MovimentoDeEstoquePorVendaQueryModel
                {
                    DataDe = dataDe.DateTime.Date,
                    DataAte = dataAte.DateTime.Date,
                    Pesquisa = textBoxPesquisaProduto.Text
                };
                MovimentoEstoquePorVenda = FuncoesItemVenda.GetMovimentoPorVenda(pesquisa);
                gridControl1.DataSource = MovimentoEstoquePorVenda;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Movimento Estoque", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (dataDe.DateTime > dataAte.DateTime)
                dataAte.DateTime = dataDe.DateTime.AddDays(1);
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (dataDe.DateTime > dataAte.DateTime)
            {
                dataDe.DateTime = dataAte.DateTime;
                dataAte.DateTime = dataDe.DateTime.AddDays(1);
            }
        }

        private void simpleButtonPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }
    }
}