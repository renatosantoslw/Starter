using DevExpress.XtraGrid.Views.Grid;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.PDV;
using PDV.VIEW.Forms.Util;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms
{
    public partial class GPDV_DescontoItem : DevExpress.XtraEditors.XtraForm
    {
        public class DescontoItemPor
        {
            public decimal Desconto { get; set; }
            public decimal TipoDesconto { get; set; }

            public static readonly int Porcentagem = 0;
            public static readonly int Valor = 1;
        }

        private GPDV_FinalizarVenda FinalizarVenda = null;
        public DescontoItemPor Desconto = null;
        Configuracao CONFIG_DESCONTO = null;

        public GPDV_DescontoItem(GPDV_FinalizarVenda TelaFinalizar)
        {
            InitializeComponent();
            FinalizarVenda = TelaFinalizar;
            CONFIG_DESCONTO = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOPEDIDOVENDA_DESCONTO_POR);
            gridControl1.DataSource = FinalizarVenda.TelaInicial.ITENS_VENDA;
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            InformarDesconto();
        }

        private void InformarDesconto()
        {
            var idItemVenda = Grids.GetValorDec(gridView1, "IDItemVenda");

            var itemVenda = FinalizarVenda.TelaInicial.ITENS_VENDA
                .Where(i => i.IDItemVenda == idItemVenda)
                .FirstOrDefault();

            if (itemVenda == null)
                return;

            var desc = itemVenda.DescontoPorcentagem;
            if (CONFIG_DESCONTO != null && Encoding.UTF8.GetString(CONFIG_DESCONTO.Valor).Equals("1"))
                desc = itemVenda.DescontoValor;

            new GPDV_InformarDescontoItem(desc, this, null).ShowDialog(this);
            ProcessarDesconto(itemVenda);
            gridView1.Focus();
        }

        private void ProcessarDesconto(ItemVenda itemVenda)
        {
            if (Desconto != null)
            {
                if (Desconto.TipoDesconto == DescontoItemPor.Porcentagem)
                {
                    itemVenda.DescontoPorcentagem = Desconto.Desconto;
                    itemVenda.DescontoValor = Desconto.Desconto == 0 ? 0 : itemVenda.ValorUnitarioItem * Desconto.Desconto / 100;
                }
                else
                {
                    itemVenda.DescontoPorcentagem = Desconto.Desconto * 100 / itemVenda.ValorUnitarioItem;
                    itemVenda.DescontoValor = Desconto.Desconto;
                }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            KeysEvents(keyData);
            return base.ProcessDialogKey(keyData);
        }

        private void KeysEvents(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.F4:
                case Keys.Escape:
                    Close();
                    break;
                case Keys.F8:
                    InformarDesconto();
                    break;
                case Keys.F10:
                    FinalizarDescontos();
                    break;
            }
        }

        private void FinalizarDescontos()
        {
            Close();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            FinalizarDescontos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            InformarDesconto();
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            KeysEvents(e.KeyData);
        }
    }
}
