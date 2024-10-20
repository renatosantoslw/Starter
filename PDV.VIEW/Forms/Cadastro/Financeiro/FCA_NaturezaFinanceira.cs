using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.Financeiro
{
    public partial class FCA_NaturezaFinanceira : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE NATUREZA FINANCEIRA";
        private Natureza NaturezaFinanceira = null;
        private List<Natureza> Naturezas = null;
        public FCA_NaturezaFinanceira(Natureza Natureza)
        {
            InitializeComponent();
            NaturezaFinanceira = Natureza;

            Naturezas = FuncoesNatureza.GetNaturezas(Natureza.IDNatureza);
            ovCMB_NaturezaSuperior.DataSource = Naturezas;
            ovCMB_NaturezaSuperior.DisplayMember = "descricao";
            ovCMB_NaturezaSuperior.ValueMember = "idnatureza";

            ovCMB_NaturezaSuperior.SelectedItem = null;
            if (Natureza.IDNaturezaSuperior.HasValue)
                ovCMB_NaturezaSuperior.SelectedItem = Naturezas.Where(o => o.IDNatureza == Natureza.IDNaturezaSuperior.Value).FirstOrDefault();

            ovTXT_Descricao.Text = NaturezaFinanceira.Descricao;
            ovTXT_Conta.Text = NaturezaFinanceira.Conta;
            ovTXT_Aplicacao.Text = NaturezaFinanceira.Aplicacao;

            if (NaturezaFinanceira.Tipo == 0)
                ovCKB_Receita.Checked = true;
            else
                ovCKB_Despesa.Checked = true;
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

                if (string.IsNullOrEmpty(ovTXT_Descricao.Text.Trim()))
                    throw new Exception("Informe a Descrição.");

                NaturezaFinanceira.Aplicacao = ovTXT_Aplicacao.Text;
                NaturezaFinanceira.Descricao = ovTXT_Descricao.Text;
                NaturezaFinanceira.Conta = ovTXT_Conta.Text;
                NaturezaFinanceira.Tipo = ovCKB_Receita.Checked ? 0 : 1;

                NaturezaFinanceira.IDNaturezaSuperior = null;
                if (ovCMB_NaturezaSuperior.SelectedItem != null)
                    NaturezaFinanceira.IDNaturezaSuperior = (ovCMB_NaturezaSuperior.SelectedItem as Natureza).IDNatureza;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesNatureza.Existe(NaturezaFinanceira.IDNatureza))
                {
                    NaturezaFinanceira.IDNatureza = Sequence.GetNextID("NATUREZA", "IDNATUREZA");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesNatureza.Salvar(NaturezaFinanceira, Op))
                    throw new Exception("Não foi possível salvar a Natureza Financeira.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Natureza Financeira salva com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ovCMB_NaturezaSuperior.SelectedItem = null;
        }

        private void FCA_NaturezaFinanceira_KeyDown(object sender, KeyEventArgs e)
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
