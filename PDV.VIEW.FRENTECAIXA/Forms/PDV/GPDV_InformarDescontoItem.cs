using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.Entidades;
using System;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms
{
    public partial class GPDV_InformarDescontoItem : Form
    {
        private GPDV_DescontoItem FormDesconto = null;
        private GPDV_FinalizarVenda FormFinalizar = null;
        private Configuracao CONFIG_DESCONTO = null;

        public GPDV_InformarDescontoItem(decimal ValorDesconto, GPDV_DescontoItem _FormDesconto, GPDV_FinalizarVenda _FormFinalizar)
        {
            InitializeComponent();
            FormDesconto = _FormDesconto;
            FormFinalizar = _FormFinalizar;

            CONFIG_DESCONTO = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOPEDIDOVENDA_DESCONTO_POR);
            if (CONFIG_DESCONTO != null)
            {
                if (Encoding.UTF8.GetString(CONFIG_DESCONTO.Valor).Equals("0"))
                    ovTXT_LabelInf.Text = "(%) Desconto";
                else
                    ovTXT_LabelInf.Text = "(R$) Desconto";
            }
            ovTXT_ValorDesconto.Text = ValorDesconto.ToString("n2");
        }

        private void DescontoPercentual()
        {
            if (FormDesconto != null)
            {
                try
                {
                    FormDesconto.Desconto = new GPDV_DescontoItem.DescontoItemPor()
                    {
                        Desconto = Convert.ToDecimal(ovTXT_ValorDesconto.Text),
                        TipoDesconto = 0
                    };
                }
                catch
                {
                    FormDesconto.Desconto = new GPDV_DescontoItem.DescontoItemPor()
                    {
                        Desconto = 0,
                        TipoDesconto = 0
                    };
                }
            }
            else if (FormFinalizar != null)
            {
                try { FormFinalizar.LancarDesconto(Convert.ToDecimal(ovTXT_ValorDesconto.Text), "P"); }
                catch { FormFinalizar.LancarDesconto(0, "P"); }
            }
        }

        private void DescontoValor()
        {
            if (FormDesconto != null)
            {
                try
                {
                    FormDesconto.Desconto = new GPDV_DescontoItem.DescontoItemPor()
                    {
                        Desconto = Convert.ToDecimal(ovTXT_ValorDesconto.Text),
                        TipoDesconto = 1
                    };
                }
                catch
                {
                    FormDesconto.Desconto = new GPDV_DescontoItem.DescontoItemPor()
                    {
                        Desconto = 0,
                        TipoDesconto = 1
                    };
                }
            }
            else if (FormFinalizar != null)
            {
                try { FormFinalizar.LancarDesconto(Convert.ToDecimal(ovTXT_ValorDesconto.Text), "V"); }
                catch (Exception) { FormFinalizar.LancarDesconto(0, "V"); }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Alt | Keys.F4):
                case Keys.Escape:
                    Close();
                    break;
                case Keys.Enter:
                    if (CONFIG_DESCONTO == null)
                        DescontoPercentual();
                    else
                    {
                        if (Encoding.UTF8.GetString(CONFIG_DESCONTO.Valor).Equals("0"))
                            DescontoPercentual();
                        else
                            DescontoValor();
                    }
                    Close();
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
