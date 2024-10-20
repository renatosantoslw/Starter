using MetroFramework;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.PDV;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms.PDV.DAV
{
    public partial class MainDAV : DevExpress.XtraEditors.XtraForm
    {
        public decimal VENDAID { get; set; }
        public MainDAV()
        {
            InitializeComponent();
            carregarDAV();

        }
        public void AjustarColumas()
        {
            //Ajustar Nome
            gridView1.Columns[0].Caption = "NÚM. DAV";
            gridView1.Columns[1].Caption = "DATA EMISSÃO";
            gridView1.Columns[2].Caption = "HORA";

            gridView1.Columns[2].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns[2].DisplayFormat.FormatString = "HH:mm";
            gridView1.Columns[3].Caption = "VENDEDOR";
            gridView1.Columns[4].Caption = "DOCUMENTO";
            gridView1.Columns[5].Caption = "CLIENTE";
            gridView1.Columns[6].Caption = "COMANDA";
            gridView1.Columns[7].Caption = "ITENS";
            gridView1.Columns[8].Caption = "TOTAL";
            gridView1.Columns[9].Caption = "IDCOMANDA";
            gridView1.Columns[10].Caption = "IDCLIENTE";
            gridView1.Columns[11].Caption = "IDUSUARIO";
            gridView1.Columns[12].Caption = "STATUS";
            //Esconder Dados
            gridView1.Columns[6].Visible = false;
            gridView1.Columns[7].Visible = false;
            gridView1.Columns[9].Visible = false;
            gridView1.Columns[10].Visible = false;
            gridView1.Columns[11].Visible = false;

        }
        private void carregarDAV()
        {
            DataTable table = FuncoesVenda.GetVendasDAV();
            gridControl1.DataSource = table;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            AjustarColumas();
            gridView1.BestFitColumns();
        }

        private void MainDAV_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.KeyCode:

                    break;

            }
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            //GER_NotasFiscaisConsumidor dados = new GER_NotasFiscaisConsumidor();
            //if(VENDAID!= null)
            //dados.EmitirCupomGerencial(VENDAID);
        }

        private void novoMetroButton_Click(object sender, EventArgs e)
        {
            DAVPedido pedido = new DAVPedido(0);
            pedido.ShowDialog();
            carregarDAV();
        }

        private void editarMetroButton_Click(object sender, EventArgs e)
        {
            int IDVenda = int.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "idvenda").ToString()));
            VENDAID = IDVenda;
            DAVPedido pedido = new DAVPedido(IDVenda);
            pedido.ShowDialog();
            editarMetroButton.Enabled = false;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            editarMetroButton.Enabled = true;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            int IDVenda = int.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "idvenda").ToString()));
            VENDAID = IDVenda;
            DAVPedido pedido = new DAVPedido(IDVenda);
            pedido.ShowDialog();
            editarMetroButton.Enabled = false;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            carregarDAV();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            int IDVenda = int.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "idvenda").ToString()));
            VENDAID = IDVenda;
        }

        private void gerarFaturamentoMetroButton_Click(object sender, EventArgs e)
        {
            try
            {
                PDV.DAO.Entidades.Financeiro.ContaReceber Conta = new PDV.DAO.Entidades.Financeiro.ContaReceber();
                Venda venda = new Venda();
                FormaDePagamento formaDePagamento = new FormaDePagamento();
                //Verificar se existe faturamento para essa venda 
                var ContaReceber = FuncoesContaReceber.GetContaReceberPorVenda(VENDAID);
                if (ContaReceber != null)
                {
                    MetroMessageBox.Show(this, "Já existe faturamento para essa venda de codigo " + " :" + ContaReceber.IDContaReceber.ToString(), "DAV - Documento Auxiliar de Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                venda = FuncoesVenda.GetVenda(decimal.Parse(VENDAID.ToString()));
                formaDePagamento = FuncoesFormaDePagamento.GetFormaDePagamento(decimal.Parse(venda.IDFormaPagamento.ToString()));

                int FatorPeriodicidade = 0;

                if (formaDePagamento.Periodicidade == "Diário")
                {
                    FatorPeriodicidade = 1;
                }
                else if (formaDePagamento.Periodicidade == "Semanal")
                {
                    FatorPeriodicidade = 7;
                }
                else if (formaDePagamento.Periodicidade == "Quinzenal")
                {
                    FatorPeriodicidade = 15;
                }
                else if (formaDePagamento.Periodicidade == "Mensal")
                {
                    FatorPeriodicidade = 30;
                }
                else if (formaDePagamento.Periodicidade == "Trimestral")
                {
                    FatorPeriodicidade = 90;
                }
                else if (formaDePagamento.Periodicidade == "Semestral")
                {
                    FatorPeriodicidade = 180;
                }
                else if (formaDePagamento.Periodicidade == "Anual")
                {
                    FatorPeriodicidade = 365;
                }

                DateTime ultimoVencimento = DateTime.Now;
                for (int i = 0; i < formaDePagamento.Qtd_Parcelas; i++)
                {

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
