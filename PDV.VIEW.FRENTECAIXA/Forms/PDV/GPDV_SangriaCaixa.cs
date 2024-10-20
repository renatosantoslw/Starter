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
    public partial class GPDV_SangriaCaixa : DevExpress.XtraEditors.XtraForm
    {
        private DateTime DataSangria { get; set; }

        private FluxoCaixa Fluxo { get; set; } = null;

        private DataTable Sangrias { get; set; } = null;

        private List<Venda> Vendas { get; set; } = null;

        private DataTable Suprimentos { get; set; } = null;

        private DataTable DinheiroEmCaixa { get; set; } = null;

        private const string NOME_TELA  = "SANGRIA DE CAIXA";

        public GPDV_SangriaCaixa()
        {
            InitializeComponent();

            ovTXT_ValorSangria.AplicaAlteracoes();
            
            GetFluxo();
            GetVendas();
            GetSangrias();
            GetSuprimentos();
            PrencherTbxSaldoAtual();

            DataSangria = DateTime.Now;
            ovTXT_DataHora.Text = DataSangria.ToString();
            ovTXT_Usuario.Text = string.Format("{0} ({1})", Contexto.USUARIOLOGADO.Nome, Contexto.USUARIOLOGADO.Login);

            ovTXT_ValorSangria.GotFocus += OvTXT_ValorSangria_GotFocus;
            ovTXT_ValorSangria.ValueChanged += OvTXT_ValorSangria_ValueChanged;

            CalcularValorAposSangria();
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

        private void GetFluxo()
        {
            Fluxo = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuario(Contexto.USUARIOLOGADO.IDUsuario);
        }

        private void GetSuprimentos()
        {
            if (Fluxo != null)
                Suprimentos = FuncoesSuprimentoCaixa.GetSuprimentoPorFluxoDeCaixa(Fluxo.IDFluxoCaixa);
        }

        private void GetSangrias()
        {
            if (Fluxo != null)
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

        private void OvTXT_ValorSangria_ValueChanged(object sender, EventArgs e)
        {
            CalcularValorAposSangria();
        }

        private void CalcularValorAposSangria()
        {
            var saldoAtual = Convert.ToDecimal(ovTXT_SaldoAtual.Text);
            var sangria = ovTXT_ValorSangria.Value;
            ovTXT_AposSangria.Text = (saldoAtual - sangria).ToString();
        }

        private void OvTXT_ValorSangria_GotFocus(object sender, EventArgs e)
        {
            ovTXT_ValorSangria.Select(0, ovTXT_ValorSangria.Text.Length);
        }

        private void EfetuarSangria()
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (ovTXT_ValorSangria.Value == 0)
                    throw new Exception("O valor deve ser maior que zero.");

                if (ovTXT_ValorSangria.Value > Convert.ToDecimal(ovTXT_SaldoAtual.Text))
                    throw new Exception("O valor deve ser menor que o valor do saldo atual.");

                if (!FuncoesSangriaCaixa.Salvar(new DAO.Entidades.SangriaCaixa()
                {
                    IDFluxoCaixa = Fluxo.IDFluxoCaixa,
                    DataSangria = DataSangria,
                    IDSangriaCaixa = Sequence.GetNextID("SANGRIACAIXA", "IDSANGRIACAIXA"),
                    IDUsuario = Contexto.USUARIOLOGADO.IDUsuario,
                    IDUsuarioCadastro = Contexto.USUARIOLOGADO.IDUsuario,
                    Observacao = ovTXT_Observacao.Text,
                    Valor = ovTXT_ValorSangria.Value
                }))
                    throw new Exception("Não foi possível Efetuar a sangria.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Sangria efetuada com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            EfetuarSangria();
        }
    }
}
