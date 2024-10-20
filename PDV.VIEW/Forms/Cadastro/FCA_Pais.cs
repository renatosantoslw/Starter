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
    public partial class FCA_Pais : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE PAIS";
        private Pais _Pais = null;
        public FCA_Pais(Pais _P)
        {
            InitializeComponent();
            _Pais = _P;
            PreencherTela();
        }

        private void PreencherTela() {
            ovTXT_Codigo.Text = _Pais.Codigo;
            ovTXT_Descricao.Text = _Pais.Descricao;
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
                    throw new Exception("Informe O Código.");

                if (string.IsNullOrEmpty(ovTXT_Descricao.Text.Trim()))
                    throw new Exception("Informe a Descrição.");

                _Pais.Codigo = ovTXT_Codigo.Text;
                _Pais.Descricao = ovTXT_Descricao.Text;

                DAO.Enum.TipoOperacao Op = DAO.Enum.TipoOperacao.UPDATE;
                if (!FuncoesPais.Existe(_Pais.IDPais))
                {
                    _Pais.IDPais = Sequence.GetNextID("PAIS", "IDPAIS");
                    Op = DAO.Enum.TipoOperacao.INSERT;
                }

                if (!FuncoesPais.Salvar(_Pais, Op))
                    throw new Exception("Não foi possível salvar o Pais.");

                PDVControlador.Commit();
               MessageBox.Show(this, "Pais salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
               MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_Pais_KeyDown(object sender, KeyEventArgs e)
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
