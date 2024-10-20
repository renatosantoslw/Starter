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

namespace PDV.VIEW.Forms.Cadastro.Financeiro.Modulo
{
    public partial class FCAFIN_MovimentacaoBancaria : DevExpress.XtraEditors.XtraForm
    {
        private MovimentoBancario Movimento = null;
        private string NOME_TELA = "CADASTRO DE MOVIMENTAÇÃO BANCÁRIA";

        private List<ContaBancaria> Contas = null;
        private List<Natureza> Naturezas = null;

        public FCAFIN_MovimentacaoBancaria(MovimentoBancario _Movimento)
        {
            InitializeComponent();

            ovTXT_Sequencia.AplicaAlteracoes();
            ovTXT_Valor.AplicaAlteracoes();

            Contas = FuncoesContaBancaria.GetContasBancarias();
            ovCMB_ContaBancaria.DataSource = Contas;
            ovCMB_ContaBancaria.DisplayMember = "nome";
            ovCMB_ContaBancaria.ValueMember = "idcontabancaria";

            Naturezas = FuncoesNatureza.GetNaturezasPorTipo(1);
            ovCMB_Natureza.DataSource = Naturezas;
            ovCMB_Natureza.DisplayMember = "descricao";
            ovCMB_Natureza.ValueMember = "idnatureza";

            Movimento = _Movimento;
            PreencherTela();
        }

        private void PreencherTela()
        {
            ovCMB_ContaBancaria.SelectedItem = Contas.Where(o => o.IDContaBancaria == Movimento.IDContaBancaria).FirstOrDefault();
            ovTXT_Documento.Text = Movimento.Documento;
            ovTXT_Movimento.Value = Movimento.DataMovimento;
            ovTXT_Historico.Text = Movimento.Historico;
            ovTXT_Sequencia.Value = Movimento.Sequencia;
            ovTXT_Valor.Value = Movimento.Valor;

            if (Movimento.Tipo == 0)
                ovCKB_Debito.Checked = true;
            else if (Movimento.Tipo == 1)
                ovCKB_Credito.Checked = true;

            if (Movimento.IDMovimentoBancario != -1 && !string.IsNullOrEmpty(Movimento.Documento))
            {
                ovTXT_Documento.Enabled = false;
                ovTXT_Documento.ReadOnly = true;
            }

            ovCMB_Natureza.SelectedItem = Naturezas.Where(o => o.IDNatureza == Movimento.IDNatureza).FirstOrDefault();
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
                Validar();

                decimal? IDNatureza = null;
                if (ovCMB_Natureza.SelectedItem != null)
                    IDNatureza = (ovCMB_Natureza.SelectedItem as Natureza).IDNatureza;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (FuncoesMovimentoBancario.GetMovimento(Movimento.IDMovimentoBancario) == null)
                {
                    Op = TipoOperacao.INSERT;
                    Movimento.IDMovimentoBancario = Sequence.GetNextID("MOVIMENTOBANCARIO", "IDMOVIMENTOBANCARIO");
                }

                Movimento.IDContaBancaria = (ovCMB_ContaBancaria.SelectedItem as ContaBancaria).IDContaBancaria;
                Movimento.IDNatureza = IDNatureza;

                Movimento.Documento = ovTXT_Documento.Text;
                //Movimento.DataMovimento = ovTXT_Movimento.Value;
                Movimento.Historico = ovTXT_Historico.Text;
                Movimento.Sequencia = ovTXT_Sequencia.Value;
                Movimento.Valor = ovTXT_Valor.Value;
                Movimento.Tipo = ovCKB_Debito.Checked ? 0 : 1;

                if (!FuncoesMovimentoBancario.Salvar(Movimento, Op))
                    throw new Exception("Não foi possível salvar o Movimento Bancário.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Movimentação Bancária salva com sucesso.", NOME_TELA);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

        private void Validar()
        {
            if (ovCMB_ContaBancaria.SelectedItem == null)
                throw new Exception("Selecione o Portador.");

            if (ovTXT_Valor.Value == 0)
                throw new Exception("O Valor não pode ser igual a zero.");
        }

        private void ovCKB_Credito_CheckedChanged(object sender, EventArgs e)
        {
            Naturezas = FuncoesNatureza.GetNaturezasPorTipo(0);
            ovCMB_Natureza.DataSource = Naturezas;
            ovCMB_Natureza.DisplayMember = "descricao";
            ovCMB_Natureza.ValueMember = "idnatureza";
            ovCMB_Natureza.SelectedItem = null;
        }

        private void ovCKB_Debito_CheckedChanged(object sender, EventArgs e)
        {
            Naturezas = FuncoesNatureza.GetNaturezasPorTipo(1);
            ovCMB_Natureza.DataSource = Naturezas;
            ovCMB_Natureza.DisplayMember = "descricao";
            ovCMB_Natureza.ValueMember = "idnatureza";
            ovCMB_Natureza.SelectedItem = null;
        }

        private void FCAFIN_MovimentacaoBancaria_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
