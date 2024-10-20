using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.Financeiro;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.Financeiro.Modulo
{
    public partial class FCAFIN_TransferenciaBancaria : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE TRANSFERÊNCIA BANCÁRIA";
        private List<ContaBancaria> ContasOrigem = null;
        private List<ContaBancaria> ContasDestino = null;
        private List<Natureza> NaturezasOrigem = null;
        private List<Natureza> NaturezasDestino = null;

        public FCAFIN_TransferenciaBancaria()
        {
            InitializeComponent();
            ContasOrigem = FuncoesContaBancaria.GetContasBancarias();
            ovCMB_ContaOrigem.DataSource = ContasOrigem;
            ovCMB_ContaOrigem.DisplayMember = "nome";
            ovCMB_ContaOrigem.ValueMember = "idcontabancaria";
            ovCMB_ContaOrigem.SelectedItem = null;

            ContasDestino = FuncoesContaBancaria.GetContasBancarias();
            ovCMB_ContaDestino.DataSource = ContasDestino;
            ovCMB_ContaDestino.DisplayMember = "nome";
            ovCMB_ContaDestino.ValueMember = "idcontabancaria";
            ovCMB_ContaDestino.SelectedItem = null;

            NaturezasOrigem = FuncoesNatureza.GetNaturezasPorTipo(1);
            ovCMB_NaturezaOrigem.DataSource = NaturezasOrigem;
            ovCMB_NaturezaOrigem.DisplayMember = "descricao";
            ovCMB_NaturezaOrigem.ValueMember = "idnatureza";
            ovCMB_NaturezaOrigem.SelectedItem = null;

            NaturezasDestino = FuncoesNatureza.GetNaturezasPorTipo(0);
            ovCMB_NaturezaDestino.DataSource = NaturezasDestino;
            ovCMB_NaturezaDestino.DisplayMember = "descricao";
            ovCMB_NaturezaDestino.ValueMember = "idnatureza";
            ovCMB_NaturezaDestino.SelectedItem = null;

            ovTXT_Valor.AplicaAlteracoes();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();
                Validar();

                decimal? IDNaturezaOrigem = null;
                if (ovCMB_NaturezaOrigem.SelectedItem != null)
                    IDNaturezaOrigem = (ovCMB_NaturezaOrigem.SelectedItem as Natureza).IDNatureza;

                decimal? IDNaturezaDestino = null;
                if (ovCMB_NaturezaDestino.SelectedItem != null)
                    IDNaturezaDestino = (ovCMB_NaturezaDestino.SelectedItem as Natureza).IDNatureza;

                if (!FuncoesMovimentoBancario.Salvar(new MovimentoBancario()
                {
                    IDMovimentoBancario = Sequence.GetNextID("MOVIMENTOBANCARIO", "IDMOVIMENTOBANCARIO"),
                    IDContaBancaria = (ovCMB_ContaOrigem.SelectedItem as ContaBancaria).IDContaBancaria,
                    IDNatureza = IDNaturezaOrigem,
                    Historico = ovTXT_Historico.Text,
                    Conciliacao = null,
                    Sequencia = 1,
                    DataMovimento = ovTXT_Movimento.Value,
                    Documento = ovTXT_Documento.Text,
                    Tipo = 0,
                    Valor = ovTXT_Valor.Value,
                }, DAO.Enum.TipoOperacao.INSERT))
                    throw new Exception("Não foi possível salvar a Transferência Bancária.");

                if (!FuncoesMovimentoBancario.Salvar(new MovimentoBancario()
                {
                    IDMovimentoBancario = Sequence.GetNextID("MOVIMENTOBANCARIO", "IDMOVIMENTOBANCARIO"),
                    IDContaBancaria = (ovCMB_ContaDestino.SelectedItem as ContaBancaria).IDContaBancaria,
                    IDNatureza = IDNaturezaDestino,
                    Historico = ovTXT_Historico.Text,
                    Conciliacao = null,
                    Sequencia = 1,
                    DataMovimento = ovTXT_Movimento.Value,
                    Documento = ovTXT_Documento.Text,
                    Tipo = 1,
                    Valor = ovTXT_Valor.Value
                }, DAO.Enum.TipoOperacao.INSERT))
                    throw new Exception("Não foi possível salvar a Transferência Bancária.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Transferência salva com sucesso.", NOME_TELA);
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
            if (ovCMB_ContaOrigem.SelectedItem == null)
                throw new Exception("Selecione a Conta de Origem.");

            if (ovCMB_ContaDestino.SelectedItem == null)
                throw new Exception("Selecione a Conta de Destino.");
        }

        private void FCAFIN_TransferenciaBancaria_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
