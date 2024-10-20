using DevExpress.Utils.Extensions;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.VIEW.Forms.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Seletores
{
    public partial class SEL_Ncm : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "PESQUISA DE NCM";
        private DataTable NCMS = null;
        public DataRow NCMSelecionado = null;
        public SEL_Ncm()
        {
            InitializeComponent();
        }

        private void SEL_Ncm_Load(object sender, EventArgs e)
        {
            Carregar();

        }

        private void Carregar()
        {
            NCMS = FuncoesNcm.GetNcms("");
            gridControl1.DataSource = NCMS;
            AjustaHeader();
        }

        private void AjustaHeader()
        {
            Grids.FormatColumnType(ref gridView1, new List<string>() { "idncm", "codigodescricao"}, GridFormats.VisibleFalse);
            Grids.FormatGrid(ref gridView1);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Seleciona();
        }

        private void Seleciona()
        {
            try
            {

                NCMSelecionado = gridView1.GetDataRow(gridView1.FocusedRowHandle);

                if (NCMSelecionado == null)
                {
                    MessageBox.Show(this, "Selecione um Ncm.", NOME_TELA);
                    return;
                }

                Close();
            }
            catch
            {
                MessageBox.Show(this, "Não foi possível selecionar o Ncm.", NOME_TELA);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "codigo")
                e.Column.Width = 50;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Seleciona();
        }
    }
}
