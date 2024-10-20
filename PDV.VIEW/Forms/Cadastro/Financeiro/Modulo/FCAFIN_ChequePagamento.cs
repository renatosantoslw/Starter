using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.Financeiro;
using PDV.UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.Financeiro.Modulo
{
    public partial class FCAFIN_ChequePagamento : DevExpress.XtraEditors.XtraForm
    {
        public ChequeContaPagar ChequePagamento = null;
        public bool Salvou = false;
        private List<Talonario> Talonarios = null;
        public FCAFIN_ChequePagamento(ChequeContaPagar _ChequePagamento, decimal IDContaBancaria)
        {
            InitializeComponent();
            ChequePagamento = _ChequePagamento;

            Talonarios = FuncoesTalonario.GetTalonarios(IDContaBancaria);
            ovCMB_Talonario.DataSource = Talonarios;
            ovCMB_Talonario.DisplayMember = "descricao";
            ovCMB_Talonario.ValueMember = "idtalonario";

            ovTXT_Valor.AplicaAlteracoes();
            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Numero.Text = ChequePagamento.Numero.ToString();
            ovTXT_Valor.Value = ChequePagamento.Valor;
            ovCKB_Cruzado.Checked = ChequePagamento.Cruzado == 1;

            ovCMB_Talonario.SelectedItem = null;
            if (ChequePagamento.IDTalonario.HasValue)
                ovCMB_Talonario.SelectedItem = Talonarios.Where(o => o.IDTalonario == ChequePagamento.IDTalonario).FirstOrDefault();

            ovTXT_Emissao.Value = ChequePagamento.Emissao;
            ovTXT_Vencimento.Value = ChequePagamento.Vencimento;

            ovTXT_Compensado.Checked = ChequePagamento.Compensado == 1;
            if (ChequePagamento.DataCompensacao.HasValue)
                ovTXT_Compensado.Value = ChequePagamento.DataCompensacao.Value;

            ovTXT_Devolvido.Checked = ChequePagamento.Devolvido == 1;
            if (ChequePagamento.DataDevolucao.HasValue)
                ovTXT_Devolvido.Value = ChequePagamento.DataDevolucao.Value;
            
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Salvou = false;
            Close();
        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(ovTXT_Numero.Text))
                throw new Exception("Informe o Número.");

            if (ovTXT_Valor.Value == 0)
                throw new Exception("O Valor deve ser maior que zero.");

            return true;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validar())
                    return;

                ChequePagamento.Numero = Convert.ToDecimal(ZeusUtil.SomenteNumeros(ovTXT_Numero.Text));
                ChequePagamento.Valor = ovTXT_Valor.Value;
                ChequePagamento.Cruzado = ovCKB_Cruzado.Checked ? 1 : 0;

                ChequePagamento.Emissao = ovTXT_Emissao.Value;
                ChequePagamento.Vencimento = ovTXT_Vencimento.Value;

                ChequePagamento.Compensado = ovTXT_Compensado.Checked ? 1 : 0;
                ChequePagamento.DataCompensacao = null;
                if (ChequePagamento.Compensado == 1)
                    ChequePagamento.DataCompensacao = ovTXT_Compensado.Value;

                ChequePagamento.IDTalonario = null;
                if (ovCMB_Talonario.SelectedItem != null)
                    ChequePagamento.IDTalonario = (ovCMB_Talonario.SelectedItem as Talonario).IDTalonario;

                ChequePagamento.Devolvido = ovTXT_Devolvido.Checked ? 1 : 0;
                ChequePagamento.DataDevolucao = null;
                if (ChequePagamento.Devolvido == 1)
                    ChequePagamento.DataDevolucao = ovTXT_Devolvido.Value;                

                Salvou = true;
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "CHEQUE PAGAMENTO");
            }
        }

        private void FCAFIN_ChequePagamento_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
