using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.EVENTONFE.Classes;
using PDV.CONTROLLER.EVENTONFE.Impressao;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Gerenciamento
{
    public partial class GER_EventosRegistrados : DevExpress.XtraEditors.XtraForm
    {
        private DataTable EVENTOS = null;
        public GER_EventosRegistrados()
        {
            InitializeComponent();

           
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GER_EventosRegistrados_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            EVENTOS = FuncoesMovimentoFiscal.GetEventosNFe(ovTXT_InicioVigencia.Value, ovTXT_DataFim.Value, (int)Contexto.CONFIG_NFe.CfgServico.tpAmb);
            gridControl2.DataSource = EVENTOS;
            gridView2.OptionsBehavior.Editable = false;
            gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView2.BestFitColumns();
            AjustaHeader();
        }

        private void AjustaHeader()
        {
            
            gridView2.Columns[0].Caption = "NÚMERO";
            gridView2.Columns[1].Caption = "SÉRIE";
            gridView2.Columns[2].Caption = "MODELO";
            gridView2.Columns[3].Caption = "EMISSÃO";
            gridView2.Columns[4].Caption = "SEQ. EVENTO";
            gridView2.Columns[5].Caption = "EVENTO";
            gridView2.Columns[6].Caption = "VENDEDOR";
            gridView2.Columns[7].Caption = "CLIENTE";
            gridView2.Columns[8].Caption = "TOTAL NF-E";
            gridView2.Columns[9].Visible = false;
            gridView2.Columns[10].Visible = false;
        }


        private void metroButton8_Click(object sender, EventArgs e)
        {
            ImpressaoEvento impressaoEvento = new ImpressaoEvento();
            decimal IDMovimentoFiscal = decimal.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "idmovimentofiscal").ToString());
            decimal IDEventoNFe = decimal.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ideventonfe").ToString());
            RetornoEventoImpressao Retorno = impressaoEvento.ImprimirEvento(Contexto.CONFIG_NFe.ConfiguracaoDanfeNFe.Logomarca, IDMovimentoFiscal, IDEventoNFe);
            
            if(Retorno.isVisualizar)
                Retorno.Danfe.Visualizar();
            else
                Retorno.Danfe.Imprimir(Retorno.isCaixaDialogo, Retorno.NomeImpressora);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }
    }
}
