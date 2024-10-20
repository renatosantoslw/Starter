using PDV.CONTROLER.Funcoes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms.PDV.DAV
{
    public partial class DAVPesquisarClientes : DevExpress.XtraEditors.XtraForm
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public DAVPesquisarClientes()
        {
            InitializeComponent();
            gridControl1.DataSource = FuncoesCliente.GetClientes("","","");
            //Formatação
            gridView1.Columns[0].Caption = "IDCLIENTE";
            gridView1.Columns[1].Caption = "NOME";
            gridView1.Columns[2].Caption = "DOCUMENTO";
            gridView1.Columns[3].Caption = "IE";
            gridView1.Columns[4].Caption = "TIPO";
            gridView1.Columns[5].Caption = "ATIVO";
            gridView1.Columns[6].Caption = "CODVENDEDOR";
            gridView1.Columns[7].Caption = "TELEFONE";
            gridView1.Columns[8].Caption = "CELULAR";
            gridView1.Columns[9].Caption = "EMAIL";
            gridView1.Columns[10].Caption = "LOGRADOURO";
            gridView1.Columns[11].Caption = "NUMERO";
            gridView1.Columns[12].Caption = "CEP";
            gridView1.Columns[13].Caption = "BAIRRO";
            gridView1.Columns[14].Caption = "CIDADE";
            gridView1.Columns[15].Caption = "UF";
            gridView1.Columns[16].Caption = "ATIVO";
            gridView1.BestFitColumns();
            gridView1.OptionsBehavior.Editable = false;
            gridControl1.ForceInitialize();
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.ShowFooter = true;
            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[0].SummaryItem.DisplayFormat = "Registros:{0}";
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCLIENTE").ToString();
                Nome = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DESCRICAO").ToString();
            }
            catch (NullReferenceException)
            {

            }
            Close();
        }
    }
}
