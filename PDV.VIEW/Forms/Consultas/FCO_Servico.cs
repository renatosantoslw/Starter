using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Util;
using System;
using System.Security;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_Servico : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE SERVICOS";

        public decimal IdSelecionado { get => Grids.GetValorDec(gridView1, "IDServico"); }
        public FCO_Servico()
        {
            InitializeComponent();
            Atualizar();
            FormatarGrid();
        }

        private void Atualizar()
        {
            try
            {
                gridControl1.DataSource = FuncoesServico.GetServicosGridView();
            }
            catch (Exception exception)
            {
                Alert(exception.Message);
            }
                    
        }

        private void FormatarGrid()
        {
            try
            {
                Grids.FormatGrid(ref gridView1);

            }
            catch (Exception exception)
            { 
               Alert(exception.Message);
            }
        }

        private void Imprimir()
        {
            gridControl1.ShowPrintPreview();
            Atualizar();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            Remover();
        }

        private void Remover()
        {
            if (Confirm("Deseja mesmo remover o serviço?") == DialogResult.Yes)
            {
                try
                {
                    PDVControlador.BeginTransaction();
                    if (!FuncoesServico.Remover(IdSelecionado))
                        throw new Exception("Não foi possível remover o serviço");
                    PDVControlador.Commit();                        

                }
                catch (Exception exception)
                {
                    PDVControlador.Rollback();
                    Alert(exception.Message);
                }
            }
            Atualizar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {            
            Editar();
        }

        private void Editar()
        {
            try
            {
                new FCA_Servico(IdSelecionado).ShowDialog();
            }
            catch (Exception exception)
            {
                Alert(exception.Message);
            }
            Atualizar();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void Novo()
        {
            try
            {
                new FCA_Servico(new Servico()).ShowDialog();
            }
            catch (Exception exception)
            {
                Alert(exception.Message);
            }
            Atualizar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void Alert(string msg)
        {
            MessageBox.Show(msg, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private DialogResult Confirm(string msg)
        {
            return MessageBox.Show(msg, NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Editar();
        }

        private void FCO_Servico_Load(object sender, EventArgs e)
        {

        }
    }
}
