using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_Comanda : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE COMANDA";
        private Comanda COMANDA = null;

        public FCA_Comanda(Comanda _Comanda)
        {
            InitializeComponent();
            COMANDA = _Comanda;
            PreencherTela();
        }
        private void PreencherTela()
        {
            ovTXT_Codigo.Text = COMANDA.Codigo;
            ovTXT_Descricao.Text = COMANDA.Descricao;
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

                if (string.IsNullOrEmpty(ovTXT_Codigo.Text.Trim()))
                    throw new Exception("Informe o Código.");

                if (string.IsNullOrEmpty(ovTXT_Descricao.Text.Trim()))
                    throw new Exception("Informe a Descrição.");

                COMANDA.Codigo = ovTXT_Codigo.Text;
                COMANDA.Descricao = ovTXT_Descricao.Text;

                if (FuncoesComanda.ExistePorCodigo(ovTXT_Codigo.Text, COMANDA.IDComanda))
                    throw new Exception("O Código da comanda já está sendo usado.");

                DAO.Enum.TipoOperacao Op = DAO.Enum.TipoOperacao.UPDATE;
                if (!FuncoesComanda.Existe(COMANDA.IDComanda))
                {
                    COMANDA.IDComanda = Sequence.GetNextID("COMANDA", "IDCOMANDA");
                    Op = DAO.Enum.TipoOperacao.INSERT;
                }

                if (!FuncoesComanda.Salvar(COMANDA, Op))
                    throw new Exception("Não foi possível salvar a Comanda.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Comanda salva com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_Comanda_KeyDown(object sender, KeyEventArgs e)
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
