using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms.Seletores
{
    public partial class SEL_Comanda : DevExpress.XtraEditors.XtraForm
    {
        public DataRow LinhaSelecionada = null;
        public SEL_Comanda()
        {
            InitializeComponent();
        }

        private void AtualizarComandas()
        {
            ovGRD_Comandas.DataSource = FuncoesComanda.GetComandasAberta(ovTXT_Nome.Text);
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Comandas.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Comandas.Width;
            foreach (DataGridViewColumn column in ovGRD_Comandas.Columns)
            {
                switch (column.Name)
                {
                    case "codigo":
                        column.DisplayIndex = 1;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.30);
                        column.Width = Convert.ToInt32(WidthGrid * 0.30);
                        column.HeaderText = "CÓDIGO";
                        break;
                    case "descricao":
                        column.DisplayIndex = 2;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.70);
                        column.Width = Convert.ToInt32(WidthGrid * 0.70);
                        column.HeaderText = "DESCRIÇÃO";
                        break;
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }
        }

        private void ovTXT_Nome_KeyUp(object sender, KeyEventArgs e)
        {
            AtualizarComandas();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            LinhaSelecionada = null;
            Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.F10:
                    SelecionarComanda();
                    break;


            }
            return base.ProcessDialogKey(keyData);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            SelecionarComanda();
        }

        private void SelecionarComanda()
        {
            LinhaSelecionada = (ovGRD_Comandas.CurrentRow.DataBoundItem as DataRowView).Row;
            Close();
        }

        private void SEL_Comanda_Load(object sender, EventArgs e)
        {
            AtualizarComandas();
            ovTXT_Nome.Select();
        }
    }
}
