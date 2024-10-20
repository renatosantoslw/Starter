using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.Parametros
{
    public partial class FCA_MotivoCancelamento : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE MOTIVO DE CANCELAMENTO";
        private MotivoCancelamento Motivo = null;
        public FCA_MotivoCancelamento(MotivoCancelamento _Motivo)
        {
            InitializeComponent();
            Motivo = _Motivo;
            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Descricao.Text = Motivo.Nome;
            if (Motivo.Tipo == 0)
                ovCKB_Compra.Checked = true;
            else
                ovCKB_Venda.Checked = true;
        }


        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_Descricao.Text))
                    throw new Exception("Informe o Nome.");

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesMotivoCancelamento.Existe(Motivo.IDMotivoCancelamento))
                {
                    Op = TipoOperacao.INSERT;
                    Motivo.IDMotivoCancelamento = Sequence.GetNextID("MOTIVOCANCELAMENTO", "IDMOTIVOCANCELAMENTO");
                }

                Motivo.Nome = ovTXT_Descricao.Text;
                Motivo.Tipo = ovCKB_Compra.Checked ? 0 : 1;

                if (!FuncoesMotivoCancelamento.Salvar(Motivo, Op))
                    throw new Exception("Não foi possível salvar o Motivo de Cancelamento.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Motivo salvo com sucesso.", NOME_TELA);
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA);
                PDVControlador.Rollback();
            }
        }

        private void FCA_MotivoCancelamento_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
