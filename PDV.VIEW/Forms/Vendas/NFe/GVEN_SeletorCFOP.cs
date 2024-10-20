using DevExpress.Office.Utils;
using PDV.CONTROLER.Funcoes;
using PDV.VIEW.Forms.Util;
using System;
using System.Collections.Generic;

namespace PDV.VIEW.Forms.Vendas.NFe
{
    public partial class GVEN_SeletorCFOP : DevExpress.XtraEditors.XtraForm
    {

        public decimal IdCFOP { get; private set; } = -1;
         
        public GVEN_SeletorCFOP()
        {
            InitializeComponent();
            PreencherGrid();
        }

        private void PreencherGrid()
        {
            gridControl1.DataSource = FuncoesCFOP.GetCFOPSAtivos();
            FormatarCabecalhos();
        }

        private void FormatarCabecalhos()
        {
            Grids.FormatGrid(ref gridView1);

            Grids.FormatColumnType(ref gridView1, new List<string> 
            {
                "ativo",
                "tipo",
                "codigodescricao",
                "idcfop"
            }, GridFormats.VisibleFalse);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            SelecionarCFOP();
        }

        private void SelecionarCFOP()
        {
            IdCFOP = Grids.GetValorDec(gridView1, "IDCfop");
            Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            SelecionarCFOP();
        }
    }
}
