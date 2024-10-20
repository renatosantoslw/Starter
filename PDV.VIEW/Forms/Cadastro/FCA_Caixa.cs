using FontAwesome.Sharp;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro {
    public partial class FCA_Caixa : DevExpress.XtraEditors.XtraForm {
        private string NOME_TELA = "CADASTRO DE CAIXA";
        private Caixa Caixa = null;

        public FCA_Caixa(Caixa _Caixa) {
            InitializeComponent();
            Caixa = _Caixa;
            PreencherTela();

            Bitmap bitmapSalvar = IconChar.Save.ToBitmap(Color.SteelBlue, 32);
            Bitmap bitmapCancelar = IconChar.WindowClose.ToBitmap(Color.Firebrick, 32);

            metroButton4.ImageOptions.Image = bitmapSalvar;
            metroButton5.ImageOptions.Image = bitmapCancelar;
        }

        private void PreencherTela() {
            ovTXT_Codigo.Text = Caixa.IDCaixa == -1 ? ZeusUtil.GetProximoCodigo("CAIXA", "IDCAIXA").ToString() : Caixa.IDCaixa.ToString();
            ovTXT_NumeroCaixa.Text = Caixa.NumeroCaixa;
            ovTXT_SerialPOS.Text = Caixa.SerialPOS;
            ovTXT_NomePOS.Text = Caixa.NomePOS;
            checkBoxAtivo.Checked = Caixa.Ativo;
            checkBoxMostrarRelatorio.Checked = Caixa.Mostrar_Relatorio_Caixa;
            tipoDeVendaComboBox.Text = Caixa.TipoDeVenda;

            if (Caixa.TipoPDV == 1) {
                checkBox1Mercado.Checked = true;
            } else {
                checkBoxRestaurante.Checked = true;
            }
        }

        private void metroButton5_Click(object sender, EventArgs e) {
            Close();
        }

        private void ovBTN_Salvar_Click(object sender, EventArgs e) {
            try {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_Codigo.Text.Trim()))
                    throw new Exception("Informe o Código.");

                if (string.IsNullOrEmpty(ovTXT_NumeroCaixa.Text.Trim()))
                    throw new Exception("Informe a Descrição.");

                if (string.IsNullOrEmpty(ovTXT_SerialPOS.Text.Trim()))
                    throw new Exception("Informe a Serial POS.");

                if (string.IsNullOrEmpty(ovTXT_NomePOS.Text.Trim()))
                    throw new Exception("Informe a Nome POS.");

                if (string.IsNullOrEmpty(tipoDeVendaComboBox.Text.Trim()))
                    throw new Exception("Informe o Tipo de Venda.");

                Caixa.NumeroCaixa = ovTXT_NumeroCaixa.Text;
                Caixa.SerialPOS = ovTXT_SerialPOS.Text;
                Caixa.NomePOS = ovTXT_NomePOS.Text;
                Caixa.Ativo = checkBoxAtivo.Checked;
                Caixa.TipoDeVenda = tipoDeVendaComboBox.Text;
                Caixa.TipoPDV = checkBox1Mercado.Checked ? 1 : 2;
                Caixa.Mostrar_Relatorio_Caixa = checkBoxMostrarRelatorio.Checked;

                TipoOperacao Op = TipoOperacao.UPDATE;

                if (!FuncoesCaixa.Existe(Caixa.IDCaixa)) {
                    Caixa.IDCaixa = Sequence.GetNextID("CAIXA", "IDCAIXA");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesCaixa.Salvar(Caixa, Op))
                    throw new Exception("Não foi possível salvar o Caixa.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Caixa salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            } catch (Exception Ex) {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void FCA_Caixa_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void checkBox1Mercado_CheckedChanged(object sender, EventArgs e) {
            if (checkBox1Mercado.Checked)
                checkBoxRestaurante.Checked = false;
        }

        private void checkBoxRestaurante_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxRestaurante.Checked)
                checkBox1Mercado.Checked = false;
        }
    }
}
