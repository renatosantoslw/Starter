using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using System;
using System.Drawing;
using System.Windows.Forms;
using PDV.VIEW.Forms.Util;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;

namespace PDV.VIEW.Forms.Configuracoes
{
    public partial class FCONFIG_ConsultarTabelaIBPT : DevExpress.XtraEditors.XtraForm
    {
        public FCONFIG_ConsultarTabelaIBPT()
        {
            InitializeComponent();
            gridControl1.DataSource = FuncoesNcm.GetTributosIBPT();
            FormatarGrid();
        }

        private void FormatarGrid()
        {

            Grids.FormatColumnType(ref gridView1, new List<string>() 
            { 
                "idncm",
                "idunidadefederativa",
                "ex",
                "tipo",
                "chave",
                "versao",
                "fonte"
            }, GridFormats.VisibleFalse);

           

            Grids.FormatGrid(ref gridView1);
           
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "descricao")
                e.Column.Width = 200;
            else
                e.Column.Width = 40;
        }
    }
}
