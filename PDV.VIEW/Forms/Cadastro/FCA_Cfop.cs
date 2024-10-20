using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_Cfop : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE CFOP";
        public static readonly decimal[] idsMenuItem = { 125 };

        public Cfop Cfop { get; set; }

        public FCA_Cfop(Cfop cfop)
        {
            InitializeComponent();
            Cfop = cfop;

            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Codigo.Text = Cfop.Codigo;
            ovTXT_Descricao.Text = Cfop.Descricao;
            ovCKB_Ativo.Checked = Cfop.Ativo == 1;
        }

        private void ovBTN_Cancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void ovBTN_Salvar_Click(object sender, System.EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_Codigo.Text.Trim()))
                    throw new Exception("Informe o Código.");

                if (string.IsNullOrEmpty(ovTXT_Descricao.Text.Trim()))
                    throw new Exception("Informe a Descrição.");

                Cfop.Codigo = ovTXT_Codigo.Text;
                Cfop.Descricao = ovTXT_Descricao.Text;
                Cfop.Ativo = ovCKB_Ativo.Checked ? 1 : 0;

                DAO.Enum.TipoOperacao Op = DAO.Enum.TipoOperacao.UPDATE;
                if (!FuncoesCFOP.Existe(Cfop.IDCfop))
                {
                    Cfop.IDCfop = Sequence.GetNextID("CFOP", "IDCFOP");
                    Op = DAO.Enum.TipoOperacao.INSERT;
                }

                if (!FuncoesCFOP.Salvar(Cfop, Op))
                    throw new Exception("Não foi possível salvar o CFOP.");

                PDVControlador.Commit();
               MessageBox.Show(this, "CFOP salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
               MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_Cfop_KeyDown(object sender, KeyEventArgs e)
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
