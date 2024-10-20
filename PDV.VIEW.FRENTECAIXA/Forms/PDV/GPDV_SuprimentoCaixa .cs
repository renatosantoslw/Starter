using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Enum;
using PDV.VIEW.FRENTECAIXA.App_Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms
{
    public partial class GPDV_SuprimentoCaixa : DevExpress.XtraEditors.XtraForm
    {
        private DateTime DataSuprimento { get; set; }

        private FluxoCaixa Fluxo { get; set; } = null;

        private DataTable Suprimentos { get; set; } = null;
            
        private List<Venda> Vendas { get; set; } = null;

        private DataTable Sangrias { get; set; } = null;

        private const string NomeTela = "SUPRIMENTO CAIXA";

        public GPDV_SuprimentoCaixa()
        {
            InitializeComponent();

            ovTXT_ValorSuprimento.AplicaAlteracoes();

            GetFluxo();
            GetVendas();
            GetSangrias();
            GetSuprimentos();
            PrencherTbxSaldoAtual();

            
            DataSuprimento = DateTime.Now;
            ovTXT_DataHora.Text = DataSuprimento.ToString();
            ovTXT_Usuario.Text = string.Format("{0} ({1})", Contexto.USUARIOLOGADO.Nome, Contexto.USUARIOLOGADO.Login);

            ovTXT_ValorSuprimento.GotFocus += OvTXT_ValorSangria_GotFocus;

            CalcularValorAposSuprimento();
        }

        private void PrencherTbxSaldoAtual()
        {
            if (Fluxo != null)
            {
                decimal saldo = 0;

                saldo += Fluxo.ValorCaixa;
                saldo += Vendas.AsEnumerable().Sum(v => v.Dinheiro - v.Troco);
                saldo += Suprimentos.AsEnumerable().Sum(v => Convert.ToDecimal(v["valor"]));
                saldo -= Sangrias.AsEnumerable().Sum(v => Convert.ToDecimal(v["valor"]));

                ovTXT_SaldoAtual.Text = saldo.ToString();
            }
        }

        private void GetSuprimentos()
        {
            if (Fluxo != null)
                Suprimentos = FuncoesSuprimentoCaixa.GetSuprimentoPorFluxoDeCaixa(Fluxo.IDFluxoCaixa);
        }

        private void GetSangrias()
        {
            if(Fluxo != null)
                Sangrias = FuncoesSangriaCaixa.GetSangriasPorFluxoDeCaixa(Fluxo.IDFluxoCaixa);
        }

        private void GetVendas()
        {
            if (Fluxo != null)
                Vendas = FuncoesVenda
                    .GetVendasPDV(Fluxo.IDFluxoCaixa)
                    .Where(v => v.Status != StatusPedido.Cancelado)
                    .ToList();

        }

        private void GetFluxo()
        {
            Fluxo = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuario(Contexto.USUARIOLOGADO.IDUsuario);
        }

        private void OvTXT_ValorSangria_ValueChanged(object sender, EventArgs e)
        {
            CalcularValorAposSuprimento();
        }

        private void CalcularValorAposSuprimento()
        {
            var saldoAtual = Convert.ToDecimal(ovTXT_SaldoAtual.Text);
            var suprimento = ovTXT_ValorSuprimento.Value;
            ovTXT_AposSuprimento.Text = (saldoAtual + suprimento).ToString();
        }

        private void OvTXT_ValorSangria_GotFocus(object sender, EventArgs e)
        {
            ovTXT_ValorSuprimento.Select(0, ovTXT_ValorSuprimento.Text.Length);
        }


        private void metroButton4_Click(object sender, EventArgs e)
        {
            Efetuar();
        }

        private void Efetuar()
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (ovTXT_ValorSuprimento.Value == 0)
                    throw new Exception("O valor deve ser maior que zero.");

                if (!FuncoesSuprimentoCaixa.Salvar(new DAO.Entidades.SuprimentoCaixa()
                {
                    IDFluxoCaixa = Fluxo.IDFluxoCaixa,
                    DataSuprimentocaixa = DataSuprimento,
                    IDSuprimentocaixa = Sequence.GetNextID("SUPRIMENTOCAIXA", "IDSUPRIMENTOCAIXA"),
                    IDUsuario = Contexto.USUARIOLOGADO.IDUsuario,
                    IDUsuarioCadastro = Contexto.USUARIOLOGADO.IDUsuario,
                    Observacao = ovTXT_Observacao.Text,
                    Valor = ovTXT_ValorSuprimento.Value
                }))
                    throw new Exception("Não foi possível Efetuar o suprimento.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Suprimento efetivado com sucesso.", NomeTela, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NomeTela, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Efetuar();
            
        }
    }
}
