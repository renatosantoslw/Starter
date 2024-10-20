using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.Financeiro.Modulo
{
    public partial class FCAFIN_Debito : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE DÉBITO";

        private List<ContaBancaria> Contas = null;
        private List<Natureza> Naturezas = null;
        public FCAFIN_Debito()
        {
            InitializeComponent();

            ovTXT_Valor.AplicaAlteracoes();

            Contas = FuncoesContaBancaria.GetContasBancarias();
            ovCMB_ContaBancaria.DataSource = Contas;
            ovCMB_ContaBancaria.DisplayMember = "nome";
            ovCMB_ContaBancaria.ValueMember = "idcontabancaria";
            ovCMB_ContaBancaria.SelectedItem = null;

            Naturezas = FuncoesNatureza.GetNaturezasPorTipo(1);
            ovCMB_Natureza.DataSource = Naturezas;
            ovCMB_Natureza.DisplayMember = "descricao";
            ovCMB_Natureza.ValueMember = "idnatureza";
            ovCMB_Natureza.SelectedItem = null;
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

                if (!FuncoesMovimentoBancario.Salvar(new MovimentoBancario
                {
                    IDMovimentoBancario = Sequence.GetNextID("MOVIMENTOBANCARIO", "IDMOVIMENTOBANCARIO"),
                    IDContaBancaria = (ovCMB_ContaBancaria.SelectedItem as ContaBancaria).IDContaBancaria,
                    IDNatureza = IDNatureza,
                    Documento = ovTXT_Documento.Text,
                    Historico = ovTXT_Historico.Text,
                    Sequencia = 1,
                    Valor = ovTXT_Valor.Value,
                    DataMovimento = DateTime.Now,
                    Tipo = 0
                }, TipoOperacao.INSERT))
                    throw new Exception("Não foi possível salvar o Crédito.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Crédito salvo com sucesso.", NOME_TELA);
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

        private void FCAFIN_Debito_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
