using MetroFramework;
using MetroFramework.Forms;
using PDV.DAO.DB.Utils;
using PDV.VIEW.FRENTECAIXA.App_Context;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms
{
    public partial class GPDV_TipoVenda : DevExpress.XtraEditors.XtraForm
    {
        public GPDV_PainelInicial TelaInicial = null;

        private string NOME_TELA = "TIPO VENDA";
        public GPDV_TipoVenda()
        {
            InitializeComponent();
        }

        public void TipoVenda(GPDV_PainelInicial _TelaInicial)
        {
            TelaInicial = _TelaInicial;
            
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                case (Keys.Alt | Keys.F4):
                    if (MessageBox.Show(this, "Deseja Sair?", NOME_TELA, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        Close();
                    break;
                case Keys.NumPad1: // SELECIONA VENDA A VISTA
                    TelaInicial.TipoVenda = 1;
                    Close();
                    break;
                case Keys.NumPad3: // SELECIONA VENDA A PRAZO
                    TelaInicial.TipoVenda = 3;
                    Close();
                    break;
                case Keys.D1: // SELECIONA VENDA A VISTA
                    TelaInicial.TipoVenda = 1;
                    Close();
                    break;
                case Keys.D3: // SELECIONA VENDA A PRAZO
                    TelaInicial.TipoVenda = 3;
                    Close();
                    break;

            }
            return base.ProcessDialogKey(keyData);
        }

    }
}
