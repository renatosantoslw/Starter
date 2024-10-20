using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.MDFe;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.MDFe
{
    public partial class FCA_Seguradora : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE SEGURADORA";
        private Seguradora SEGURADORA = null;

        public FCA_Seguradora(Seguradora Seg)
        {
            InitializeComponent();
            SEGURADORA = Seg;
            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_CNPJ.Text = SEGURADORA.CNPJ;
            ovTXT_Descricao.Text = SEGURADORA.Descricao;
            ovCKB_Ativo.Checked = SEGURADORA.Ativo == 1;
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

                if (string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(ovTXT_CNPJ.Text)))
                    throw new Exception("Informe o CNPJ.");

                if (string.IsNullOrEmpty(ovTXT_Descricao.Text))
                    throw new Exception("Informe a Descrição.");

                SEGURADORA.CNPJ = ZeusUtil.SomenteNumeros(ovTXT_CNPJ.Text);
                SEGURADORA.Descricao = ovTXT_Descricao.Text;
                SEGURADORA.Ativo = ovCKB_Ativo.Checked ? 1 : 0;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesSeguradora.Existe(SEGURADORA.IDSeguradora))
                {
                    SEGURADORA.IDSeguradora = Sequence.GetNextID("SEGURADORA", "IDSEGURADORA");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesSeguradora.Salvar(SEGURADORA, Op))
                    throw new Exception("Não foi possível salvar a Seguradora.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Seguradora salva com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_Seguradora_KeyDown(object sender, KeyEventArgs e)
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
