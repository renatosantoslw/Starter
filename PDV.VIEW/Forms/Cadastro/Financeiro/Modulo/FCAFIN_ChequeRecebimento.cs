using MetroFramework;
using MetroFramework.Forms;
using PDV.DAO.Entidades.Financeiro;
using PDV.UTIL;
using System;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.Financeiro.Modulo
{
    public partial class FCAFIN_ChequeRecebimento : DevExpress.XtraEditors.XtraForm
    {
        public ChequeContaReceber ChequeRecebimento = null;
        public bool Salvou = false;
        public FCAFIN_ChequeRecebimento(ChequeContaReceber _ChequeRecebimento)
        {
            InitializeComponent();
            ChequeRecebimento = _ChequeRecebimento;
            ovTXT_Valor.AplicaAlteracoes();
            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Numero.Text = ChequeRecebimento.Numero.ToString();
            ovTXT_Valor.Value = ChequeRecebimento.Valor;
            ovCKB_Cruzado.Checked = ChequeRecebimento.Cruzado == 1;

            ovTXT_Emissao.Value = ChequeRecebimento.Emissao;
            ovTXT_Vencimento.Value = ChequeRecebimento.Vencimento;

            ovTXT_Compensado.Checked = ChequeRecebimento.Compensado == 1;
            if (ChequeRecebimento.DataCompensacao.HasValue)
                ovTXT_Compensado.Value = ChequeRecebimento.DataCompensacao.Value;

            ovTXT_Devolvido.Checked = ChequeRecebimento.Devolvido == 1;
            if (ChequeRecebimento.DataDevolucao.HasValue)
                ovTXT_Devolvido.Value = ChequeRecebimento.DataDevolucao.Value;

            ovTXT_Repasse.Checked = ChequeRecebimento.Repasse == 1;
            if (ChequeRecebimento.DataRepasse.HasValue)
                ovTXT_Repasse.Value = ChequeRecebimento.DataRepasse.Value;

            if (ChequeRecebimento.ObsRepasse != null)
                ovTXT_Obs.Text = Encoding.UTF8.GetString(ChequeRecebimento.ObsRepasse);
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

                ChequeRecebimento.Numero = Convert.ToDecimal(ZeusUtil.SomenteNumeros(ovTXT_Numero.Text));
                ChequeRecebimento.Valor = ovTXT_Valor.Value;
                ChequeRecebimento.Cruzado = ovCKB_Cruzado.Checked ? 1 : 0;

                ChequeRecebimento.Emissao = ovTXT_Emissao.Value;
                ChequeRecebimento.Vencimento = ovTXT_Vencimento.Value;

                ChequeRecebimento.Compensado = ovTXT_Compensado.Checked ? 1 : 0;
                ChequeRecebimento.DataCompensacao = null;
                if (ChequeRecebimento.Compensado == 1)
                    ChequeRecebimento.DataCompensacao = ovTXT_Compensado.Value;


                ChequeRecebimento.Devolvido = ovTXT_Devolvido.Checked ? 1 : 0;
                ChequeRecebimento.DataDevolucao = null;
                if (ChequeRecebimento.Devolvido == 1)
                    ChequeRecebimento.DataDevolucao = ovTXT_Devolvido.Value;

                ChequeRecebimento.Repasse = ovTXT_Repasse.Checked ? 1 : 0;
                ChequeRecebimento.DataRepasse = null;
                if (ChequeRecebimento.Repasse == 1)
                    ChequeRecebimento.DataRepasse = ovTXT_Repasse.Value;

                ChequeRecebimento.ObsRepasse = Encoding.Default.GetBytes(ovTXT_Obs.Text);

                Salvou = true;
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "CHEQUE RECEBIMENTO");
            }
        }

        private void FCAFIN_ChequeRecebimento_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
