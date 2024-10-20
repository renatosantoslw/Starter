using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.UTIL.Components.Custom;
using PDV.VIEW.App_Context;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Vendas.Manifesto
{
    public partial class  SeletorNFe : DevExpress.XtraEditors.XtraForm
    {
        private DataGridViewCheckBoxColumnHeaderCell CheckAllColumn;
        private string NOME_TELA = "SELETOR DE NF-E";
        public DataTable Selecionados = null;

        public SeletorNFe()
        {
            InitializeComponent();


            ovTXT_Inicio.Value = DateTime.Now.AddDays(-30);
        }

        private void CarregarNFe()
        {
            gridControlNFe.DataSource = FuncoesMovimentoFiscal.GetNFeParaMovimentoFiscal(ovTXT_Inicio.Value, ovTXT_DataFim.Value, (int)Contexto.CONFIG_NFe.CfgServico.tpAmb);
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            //ovGRD_NFe.RowHeadersVisible = false;
            //int WidthGrid = ovGRD_NFe.Width;
            //foreach (DataGridViewColumn column in ovGRD_NFe.Columns)
            //{
            //    switch (column.Name)
            //    {
            //        case "selecionado":
            //            column.DisplayIndex = 0;
            //            column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
            //            column.Width = Convert.ToInt32(WidthGrid * 0.10);
            //            column.HeaderText = string.Empty;
            //            CheckAllColumn = new DataGridViewCheckBoxColumnHeaderCell();
            //            column.HeaderCell = CheckAllColumn;
            //            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //            column.HeaderText = string.Empty;
            //            break;
            //        case "dataemissao":
            //            column.DisplayIndex = 1;
            //            column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.15);
            //            column.Width = Convert.ToInt32(WidthGrid * 0.15);
            //            column.HeaderText = "EMISSAO";
            //            break;
            //        case "chave":
            //            column.DisplayIndex = 2;
            //            column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.30);
            //            column.Width = Convert.ToInt32(WidthGrid * 0.30);
            //            column.HeaderText = "CHAVE";
            //            break;
            //        case "cpfcnpj":
            //            column.DisplayIndex = 3;
            //            column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.20);
            //            column.Width = Convert.ToInt32(WidthGrid * 0.20);
            //            column.HeaderText = "CPF/CNPJ";
            //            break;
            //        case "nome":
            //            column.DisplayIndex = 4;
            //            column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.25);
            //            column.Width = Convert.ToInt32(WidthGrid * 0.25);
            //            column.HeaderText = "CLIENTE";
            //            break;
            //    }
            //}
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            int[] rowHandles = gridView1.GetSelectedRows();
            Selecionados  = new DataTable();
            for (int i = 0; i < rowHandles.Length; i++)
            {
                Selecionados.Rows.Add(gridView1.GetRow(rowHandles[i]));
            }
            Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            CarregarNFe();
        }

        private void SeletorNFe_Load(object sender, EventArgs e)
        {
            CarregarNFe();
        }

        private void gridControlNFe_DoubleClick(object sender, EventArgs e)
        {
            int[] rowHandles = gridView1.GetSelectedRows();
            Selecionados = new DataTable();
            for (int i = 0; i < rowHandles.Length; i++)
            {
                Selecionados.Rows.Add(gridView1.GetRow(rowHandles[i]));
            }
            Close();
        }
    }
}
