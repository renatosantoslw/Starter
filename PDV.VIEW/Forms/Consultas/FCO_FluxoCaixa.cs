using DevExpress.Office.Utils;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_FluxoCaixa : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE FLUXO DE CAIXA";

        public FCO_FluxoCaixa()
        {
            InitializeComponent();

            dateEdit1.DateTime = dateEdit2.DateTime = DateTime.Today;
            
            Atualizar();

            
        }            

        private void Atualizar()
        {
            gridControl1.DataSource = FuncoesFluxoCaixa.GetFluxosCaixa(dateEdit1.DateTime, dateEdit2.DateTime.AddDays(1));
            Grids.FormatGrid(ref gridView1);
            Grids.FormatColumnType(ref gridView1, new List<string> 
            { 
               "VALORFECHAMENTOCAIXA",
               "VALORCAIXA"
            }, GridFormats.Finance);
        }     

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }
        
        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (dateEdit1.DateTime > dateEdit2.DateTime)
                dateEdit2.DateTime = dateEdit1.DateTime;
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (dateEdit1.DateTime > dateEdit2.DateTime)
                dateEdit1.DateTime = dateEdit2.DateTime;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Editar();
        }

        private void Editar()
        {
            try
            {
                new FCA_FluxoCaixa(Grids.GetValorDec(gridView1, "IDFLUXOCAIXA")).ShowDialog();
                Atualizar();
            }
            catch (Exception exception)
            {
                Alert(exception.Message);
            }          
            
        }

        private void Alert(string message)
        {
            MessageBox.Show(message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
