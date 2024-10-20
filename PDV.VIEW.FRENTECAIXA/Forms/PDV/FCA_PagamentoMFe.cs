using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using MetroFramework.Forms;
using MetroFramework;
using PDV.DAO.Entidades.PDV;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_PagamentoMFe : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE PAGAMENTO MFe";
        public PagamentoMFe Pagamento = null;
        public bool Cancelado { get; set; }
        public FCA_PagamentoMFe(PagamentoMFe _Pagamento) 
        {
            InitializeComponent();
            Pagamento = _Pagamento;
            //metroComboBoxVenda.DataSource = FuncoesVenda.GetVendasDAV();
            //metroComboBoxVenda.DisplayMember = "idvenda";
            //metroComboBoxVenda.ValueMember = "idvenda";

            textBoxValorCartao.Text = _Pagamento.ValorCartao;
            PreencherTela();
        }

        private void PreencherTela()
        {
            
             if (Pagamento.IDPagamentoMFe == -1)
                Pagamento.IDPagamentoMFe = Sequence.GetNextID("PAGAMENTOMFE", "IDPAGAMENTOMFE");

           
            ovTXT_Adquirente.Text = "REDE";
            textBoxBandeira.Text ="VISA";
            ovTXT_NSU.Text ="";
            textEditQndParcelas.Value = 0;
            textBoxAutorizacao.Text ="";
        }

        private void ovBTN_Cancelar_Click(object sender, System.EventArgs e)
        {
            Cancelado = true;
            Close();
        }

        private void ovBTN_Salvar_Click(object sender, System.EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_Adquirente.Text.Trim()))
                    throw new Exception("Informe o Adquirente.");

                if (string.IsNullOrEmpty(textBoxAutorizacao.Text.Trim()))
                    throw new Exception("Informe a Autorização.");

                if (string.IsNullOrEmpty(ovTXT_NSU.Text.Trim()))
                    throw new Exception("Informe a NSU.");

               

                if (string.IsNullOrEmpty(textBoxValorCartao.Text.Trim()))
                    throw new Exception("Informe o Valor do Cartão.");

                if (textEditQndParcelas.Value == 0)
                    throw new Exception("Informe a Qauntidade de Parcelas.");

                if (string.IsNullOrEmpty(textBoxAutorizacao.Text.Trim()))
                    throw new Exception("Informe a Autorização.");

                Pagamento.IDPagamentoMFe = Sequence.GetNextID("pagamentomfe", "IDPagamento");
                Pagamento.DonoCartao =  "CONSUMIDOR FINAL" ;
                Pagamento.Adquirente = ovTXT_Adquirente.Text;
                Pagamento.IDVenda = Pagamento.IDVenda;
                Pagamento.Bandeira = textBoxBandeira.Text;
                Pagamento.NSU = ovTXT_NSU.Text ;
                Pagamento.BinCartao = "123456789";
                 Pagamento.UltimosQuatroDigitos = "" ;
                Pagamento.QtdParcelas = textEditQndParcelas.Value.ToString() ;
                Pagamento.ValorCartao = textBoxValorCartao.Text;
                Pagamento.Autorizacao = textBoxAutorizacao.Text  ;
                Pagamento.DataExpiracao = DateTime.Now.AddYears(3) ;
                Pagamento.IDLocal = Pagamento.IDLocal;
                Pagamento.IDPagamento = Pagamento.IDPagamento;

                if (!FuncoesPagamentoMFe.Salvar(Pagamento,TipoOperacao.INSERT))
                    throw new Exception("Não foi possível salvar o Pagamento.");
              
                PDVControlador.Commit();
                //MessageBox.Show(this, "Pagamento MFe salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cancelado = false;
                Close();
            }
            catch (Exception Ex)
            {
                Cancelado = true;
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_Usuario_KeyDown(object sender, KeyEventArgs e)
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
