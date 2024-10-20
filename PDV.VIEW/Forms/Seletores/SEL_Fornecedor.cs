using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDV.CONTROLER.Funcoes;
using System;
using System.Data;
using PDV.VIEW.Forms.Util;

namespace PDV.VIEW.Forms.Seletores
{
    public partial class SEL_Fornecedor : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "Pesquisa de Fornecedor";
        public DataRow drFornecedor = null;
        private int linhaSelecionada;

        public SEL_Fornecedor()
        {
            InitializeComponent();
        }


        private void AtualizarFornecedor(string RazaoSocial, string CNPJ)
        {
            gridControl1.DataSource = FuncoesFornecedor.GetFornecedores(RazaoSocial, CNPJ);
            FormatarGrid();
        }

        private void FormatarGrid()
        {
            Grids.FormatGrid(ref gridView1);
        }

        private void AdicionarItem()
        {
            try
            {
                if (linhaSelecionada < 0)
                {
                    MessageBox.Show(this, "Selecione um Item.", NOME_TELA);
                    return;
                }

                drFornecedor = gridView1.GetDataRow(linhaSelecionada >= 0 ? linhaSelecionada : 0);
                if (drFornecedor == null)
                {
                    MessageBox.Show(this, "Selecione um Item.", NOME_TELA);
                    return;
                }
                Close();
            }
            catch
            {
                MessageBox.Show(this, "Não foi possível selecionar o Item.", NOME_TELA);
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            AdicionarItem();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            AdicionarItem();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            linhaSelecionada = gridView1.FocusedRowHandle;
        }

        private void SEL_Fornecedor_Load(object sender, EventArgs e)
        {
            AtualizarFornecedor("","");
        }
    }
}