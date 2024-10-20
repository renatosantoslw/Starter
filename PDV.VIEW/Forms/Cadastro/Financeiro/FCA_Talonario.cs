using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.Financeiro
{
    public partial class FCA_Talonario : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE TALONÁRIO";
        private Talonario TALONARIO = null;
        private List<ContaBancaria> Contas = null;

        public FCA_Talonario(Talonario _TALONARIO)
        {
            InitializeComponent();
            TALONARIO = _TALONARIO;

            Contas = FuncoesContaBancaria.GetContasBancarias();
            ovCMB_Conta.DataSource = Contas;
            ovCMB_Conta.DisplayMember = "nome";
            ovCMB_Conta.ValueMember = "idcontabancaria";

            PreencherTela();

            ovTXT_Inicio.AplicaAlteracoes();
            ovTXT_Fim.AplicaAlteracoes();
        }

        private void PreencherTela()
        {
            ovCMB_Conta.SelectedItem = Contas.AsEnumerable().Where(o => o.IDContaBancaria == TALONARIO.IDContaBancaria).FirstOrDefault();
            ovCKB_Ativo.Checked = TALONARIO.Ativo == 1;
            ovTXT_Numero.Text = TALONARIO.Numero;
            ovTXT_Emissao.Value = TALONARIO.Emissao;
            ovTXT_Inicio.Value = TALONARIO.Inicio;
            ovTXT_Fim.Value = TALONARIO.Fim;
            if (TALONARIO.Obs != null)
                ovTXT_Observacao.Text = Encoding.UTF8.GetString(TALONARIO.Obs);
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

                if (ovCMB_Conta.SelectedItem == null)
                    throw new Exception("Selecione a Conta.");

                if (string.IsNullOrEmpty(ovTXT_Numero.Text))
                    throw new Exception("Informe o Número");

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesTalonario.Existe(TALONARIO.IDTalonario))
                {
                    Op = TipoOperacao.INSERT;
                    TALONARIO.IDTalonario = Sequence.GetNextID("TALONARIO", "IDTALONARIO");
                }

                TALONARIO.IDContaBancaria = (ovCMB_Conta.SelectedItem as ContaBancaria).IDContaBancaria;
                TALONARIO.Ativo = ovCKB_Ativo.Checked ? 1 : 0;
                TALONARIO.Numero = ovTXT_Numero.Text;
                TALONARIO.Emissao = ovTXT_Emissao.Value;
                TALONARIO.Inicio = ovTXT_Inicio.Value;
                TALONARIO.Fim = ovTXT_Fim.Value;
                TALONARIO.Obs = Encoding.Default.GetBytes(ovTXT_Observacao.Text);

                if (!FuncoesTalonario.Salvar(TALONARIO, Op))
                    throw new Exception("Não foi possível salvar o Talonário.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Talonário salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_Talonario_KeyDown(object sender, KeyEventArgs e)
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
