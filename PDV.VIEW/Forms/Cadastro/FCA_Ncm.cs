using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_Ncm : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE NCM";
        private Ncm NCM = null;

        public FCA_Ncm(Ncm _NCM)
        {
            InitializeComponent();
            NCM = _NCM;
            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Codigo.Text = NCM.Codigo.ToString();
            ovTXT_Descricao.Text = NCM.Descricao;
        }

        private void ovBTN_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ovBTN_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_Codigo.Text.Trim()))
                    throw new Exception("Informe o Código.");

                if (string.IsNullOrEmpty(ovTXT_Descricao.Text.Trim()))
                    throw new Exception("Informe a Descrição.");

                NCM.Codigo = Convert.ToDecimal(ZeusUtil.SomenteNumeros(ovTXT_Codigo.Text));
                NCM.Descricao = ovTXT_Descricao.Text;

                DAO.Enum.TipoOperacao Op = DAO.Enum.TipoOperacao.UPDATE;
                if (!FuncoesNcm.Existe(NCM.IDNCM))
                {
                    NCM.IDNCM = Sequence.GetNextID("NCM", "IDNCM");
                    Op = DAO.Enum.TipoOperacao.INSERT;
                }

                if (!FuncoesNcm.Salvar(NCM, Op))
                    throw new Exception("Não foi possível salvar o NCM.");

                PDVControlador.Commit();
               MessageBox.Show(this, "NCM salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
               MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_Ncm_KeyDown(object sender, KeyEventArgs e)
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
