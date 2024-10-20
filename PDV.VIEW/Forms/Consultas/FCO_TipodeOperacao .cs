using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Vendas.NFe;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using PDV.VIEW.Forms.Util;
using System.Collections.Generic;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_TipodeOperacao : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE TIPOS DE OPERACAO";

        public FCO_TipodeOperacao()
        {
            InitializeComponent();
            AtualizaTiposdeOperacao();
        }

        private void AtualizaTiposdeOperacao()
        {
            gridControl1.DataSource = FuncoesTipoDeOperacao.GetTiposDeOperacao();
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            Grids.FormatColumnType(ref gridView1, new List<string>() 
            { 
                "idtipodeoperacao1",
                "idoperacaofiscal",
                "idfinalidade",
                "idtipoatendimento",
                "modelodocumento",
                "informacoescomplementares"
            }, GridFormats.VisibleFalse);

            Grids.FormatGrid(ref gridView1);
        }


        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            AtualizaTiposdeOperacao();
        }

        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {

            FCA_TipoDeOperacao t = new FCA_TipoDeOperacao(new TipoDeOperacao());
            t.ShowDialog(this);
            AtualizaTiposdeOperacao();
            editartipodeoperacaometroButton4.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal IDTipoOperacao = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDTIPODEOPERACAO").ToString()));
                FCA_TipoDeOperacao t = new FCA_TipoDeOperacao(FuncoesTipoDeOperacao.GetTipoDeOperacao(IDTipoOperacao));
                t.ShowDialog(this);
                AtualizaTiposdeOperacao();
            }
            catch (Exception)
            {

            }

            finally
            {
                editartipodeoperacaometroButton4.Enabled = false;
                metroButton3.Enabled = false;
            }
           
            
        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o Tipo de Operação selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                decimal IDTipoOperacao = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDTIPODEOPERACAO").ToString()));
                try
                {
                    if (!FuncoesTipoDeOperacao.Remover(IDTipoOperacao))
                        throw new Exception("Não foi possível remover o Tipo de Operação.");
                }
                catch (Exception Ex)
                {
                   MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizaTiposdeOperacao();
            }
            editartipodeoperacaometroButton4.Enabled = false;
            metroButton3.Enabled = false;
        }


        private void gridControl1_Click(object sender, EventArgs e)
        {
            editartipodeoperacaometroButton4.Enabled = true;
            metroButton3.Enabled = true;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            
            try
            {
                decimal IDTipoOperacao = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDTIPODEOPERACAO").ToString());
                FCA_TipoDeOperacao t = new FCA_TipoDeOperacao(FuncoesTipoDeOperacao.GetTipoDeOperacao(IDTipoOperacao));
                t.ShowDialog(this);
                AtualizaTiposdeOperacao();
                editartipodeoperacaometroButton4.Enabled = false;
                metroButton3.Enabled = false;
            }
            catch (NullReferenceException)
            {

                
            }

        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
            editartipodeoperacaometroButton4.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizaTiposdeOperacao();
            editartipodeoperacaometroButton4.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void FCO_TipodeOperacao_Load(object sender, EventArgs e)
        {
            AtualizaTiposdeOperacao();
        }

        private void gridView1_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            GridImprimir.FormatarImpressão(ref e);
        }
    }
}
