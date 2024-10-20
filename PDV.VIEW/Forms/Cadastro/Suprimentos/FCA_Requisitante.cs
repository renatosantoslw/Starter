using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.Suprimentos
{
    public partial class FCA_Requisitante : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE REQUISITANTE";
        private Requisitante Requisitante = null;
        private List<CentroCusto> Centros = null;

        public FCA_Requisitante(Requisitante Req)
        {
            InitializeComponent();
            Requisitante = Req;

            //Centros = FuncoesCentroCusto.GetCentrosCusto();
            //ovCMB_CentroCusto.DataSource = Centros;
            //ovCMB_CentroCusto.DisplayMember = "descricao";
            //ovCMB_CentroCusto.ValueMember = "idcentrocusto";

            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Nome.Text = Requisitante.Nome;
            //ovCMB_CentroCusto.SelectedItem = Centros.Where(o => o.IDCentroCusto == Requisitante.IDCentroCusto).FirstOrDefault();
        }

        private void metroButton4_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void metroButton3_Click(object sender, System.EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_Nome.Text))
                    throw new Exception("Informe o Nome.");

                if (ovCMB_CentroCusto.SelectedItem == null)
                    throw new Exception("Selecione o Centro de Custo.");

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesRequisitante.Existe(Requisitante.IDRequisitante))
                {
                    Requisitante.IDRequisitante = Sequence.GetNextID("REQUISITANTE", "IDREQUISITANTE");
                    Op = TipoOperacao.INSERT;
                }

                Requisitante.Nome = ovTXT_Nome.Text;
                //Requisitante.IDCentroCusto = (ovCMB_CentroCusto.SelectedItem as CentroCusto).IDCentroCusto;

                if (!FuncoesRequisitante.Salvar(Requisitante, Op))
                    throw new Exception("Não foi possível salvar o Requisitante.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Requisitante salvo com sucesso.", NOME_TELA);
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA);
                PDVControlador.Rollback();
            }
        }

        private void FCA_Requisitante_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}
