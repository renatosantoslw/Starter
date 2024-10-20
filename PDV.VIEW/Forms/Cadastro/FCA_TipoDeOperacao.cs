using Boleto2Net;
using DevExpress.Accessibility;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.XtraEditors;
using DFe.Classes.Flags;
using MetroFramework;
using MetroFramework.Forms;
using NFe.Classes.Informacoes.Emitente;
using NFe.Classes.Informacoes.Pagamento;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.NFE.Transmissao;
using PDV.CONTROLLER.NFE.Util;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Entidades.NFe;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.BOLETO.Classes;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Cadastro.Financeiro;
using PDV.VIEW.Forms.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Vendas.NFe
{
    public partial class FCA_TipoDeOperacao : DevExpress.XtraEditors.XtraForm
    {

        private string NOME_TELA = "CADASTRO DE CAIXA";
        private TipoDeOperacao TipoDeOperacao { get; set; } = null;

        private Operacao operacao = Operacao.Ambas;
        public static readonly decimal[] idsMenuItem = { 103 };

        public FCA_TipoDeOperacao(TipoDeOperacao tipoDeOperacao, Operacao _operacao = Operacao.Ambas)
        {
            InitializeComponent();

            TipoDeOperacao = tipoDeOperacao;

            operacao = _operacao;

            PreencherTela();

            CarregarPermissoes();
        }

        private void CarregarPermissoes()
        {
            PermissoesUtil.VerificarPermissaoParaTela(FCA_Cfop.idsMenuItem, ref buttonAdicionarCFOP);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_Transportadora.idsMenuItem, ref buttonAdicionarTransportadora);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_CentroCusto.idsMenuItem, ref buttonAdicionarCentroCusto);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_HistoricoFinanceiro.idsMenuItem, ref buttonAdicionarHistoricoFinanceiro);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_ContaBancaria.idsMenuItem, ref buttonAdicionarContaBancaria);
        }

        public decimal GetTipoDeOperacaoID() { return TipoDeOperacao.IDTipoDeOperacao; }
        private void PreencherTela()
        {

            ovTXT_Codigo.Text = TipoDeOperacao.IDTipoDeOperacao == -1 ? 
                                ZeusUtil.GetProximoCodigo("TIPODEOPERACAO", "IDTIPODEOPERACAO").ToString() : 
                                TipoDeOperacao.IDTipoDeOperacao.ToString();


            ovTXT_Serie.Text = TipoDeOperacao.Serie.ToString();
            ovTXT_Nome.Text = TipoDeOperacao.Nome;

            PreencherTipoDeMovimento();
            PreencherFinalidade();
            PreencherTipoAtendimento();
            PreencherOperacaoFiscal();
            PreencherTransportadora();
            PreencherCentroCusto();
            PreencherHistoricoFinanceiro();
            PreencherContaBancaria();           
            

            ovTXT_ModeloDocumento.Text = TipoDeOperacao.ModeloDocumento.ToString();

            ovTXT_InformacoesComplementares.Text = TipoDeOperacao.InformacoesComplementares;
            checkBoxControlarEstoque.Checked = TipoDeOperacao.ControlarEstoque;
            checkBoxLimiteCredito.Checked = TipoDeOperacao.LimiteCredito;
            checkBoxEstoqueNegativo.Checked = TipoDeOperacao.PermiteEstoqueNegativo;
            checkBoxGerarFinanceiro.Checked = TipoDeOperacao.GerarFinanceiro;

            checkNaoInformaTransp.Checked = TipoDeOperacao.IDTransportadora < 1;


            switch (TipoDeOperacao.TipoDeFrete)
            {
                case 0:
                    ovLBL_FreteEmitente.Checked = true;
                    break;
                case 1:
                    ovLBL_FreteDestinatario.Checked = true;
                    break;
                case 2:
                    ovLBL_FreteTerceiros.Checked = true;
                    break;
                case 9:
                    ovLBL_SemFrete.Checked = true;
                    break;
            }
        }

        private void PreencherTipoDeMovimento()
        {
            bool isEntrada = TipoDeOperacao.TipoDeMovimento == TipoDeOperacao.Entrada;

            radioEntrada.Checked = isEntrada;
            radioSaida.Checked = !isEntrada;

            

            if (Operacao.DeEntrada == operacao)
                radioEntrada.Checked = true;
            else if(Operacao.DeSaida == operacao)
                radioSaida.Checked = true;

            radioEntrada.Enabled = radioSaida.Enabled = operacao == Operacao.Ambas;

        }

        private void PreencherHistoricoFinanceiro()
        {
            try
            {
                var tipoDeMovimento = radioEntrada.Checked ? CentroCusto.Entrada : CentroCusto.Saida;
                comboBoxHistoricoFinanceiro.DataSource = FuncoesHistoricoFinanceiro.GetHistoricosFinanceiros(tipoDeMovimento);
                comboBoxHistoricoFinanceiro.DisplayMember = "descricao";
                comboBoxHistoricoFinanceiro.ValueMember = "idhistoricofinanceiro";
                comboBoxHistoricoFinanceiro.SelectedValue = TipoDeOperacao.IDHistoricoFinanceiro;
            }
            catch (Exception exception)
            {
                var msg = "Desculpe! " + exception.Message;
                MessageBox.Show(msg, "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void PreencherContaBancaria()
        {
            try
            {
                comboBoxContaBancaria.DataSource = FuncoesContaBancaria.GetContasBancarias();
                comboBoxContaBancaria.DisplayMember = "nome";
                comboBoxContaBancaria.ValueMember = "idcontabancaria";
                comboBoxContaBancaria.SelectedValue = TipoDeOperacao.IDContaBancaria;
            }
            catch (Exception exception)
            {
                var msg = "Desculpe! " + exception.Message;
                MessageBox.Show(msg, "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void PreencherCentroCusto()
        {
            try
            {
                var tipoDeMovimento = radioEntrada.Checked ? CentroCusto.Entrada : CentroCusto.Saida;
                comboBoxCentroCusto.DataSource = FuncoesCentroCusto.GetCentrosCusto(tipoDeMovimento);
                comboBoxCentroCusto.DisplayMember = "descricao";
                comboBoxCentroCusto.ValueMember = "idcentrocusto";
                comboBoxCentroCusto.SelectedValue = TipoDeOperacao.IdCentroCusto;
            }
            catch (Exception exception)
            {
                var msg = "Desculpe! " + exception.Message;
                MessageBox.Show(msg, "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void PreencherTransportadora()
        {
            try
            {
                comboBoxTransportadora.DataSource = FuncoesTransportadora.GetTransportadoras();
                comboBoxTransportadora.DisplayMember = "nome";
                comboBoxTransportadora.ValueMember = "idtransportadora";
                comboBoxTransportadora.SelectedValue = TipoDeOperacao.IDTransportadora;
            }
            catch (Exception exception)
            {
                var msg = "Desculpe! " + exception.Message;
                MessageBox.Show(msg, "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void PreencherOperacaoFiscal()
        {
            try
            {
                comboBoxOperacaoFiscal.DataSource = FuncoesCFOP.GetCFOPSAtivos();
                comboBoxOperacaoFiscal.DisplayMember = "codigodescricao";
                comboBoxOperacaoFiscal.ValueMember = "idcfop";
                comboBoxOperacaoFiscal.SelectedValue = TipoDeOperacao.IDOperacaoFiscal;
            }
            catch (Exception exception)
            {
                var msg = "Desculpe! " + exception.Message;
                MessageBox.Show(msg, "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void PreencherTipoAtendimento()
        {
            try
            {
                comboBoxTipoAtendimento.DataSource = FuncoesTipoAtendimento.GetTiposAtendimento();
                comboBoxTipoAtendimento.DisplayMember = "descricao";
                comboBoxTipoAtendimento.ValueMember = "idtipoatendimento";
                comboBoxTipoAtendimento.SelectedValue = TipoDeOperacao.IDTipoAtendimento;
            }
            catch (Exception exception)
            {
                var msg = "Desculpe! " + exception.Message;
                MessageBox.Show(msg, "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void PreencherFinalidade()
        {
            try
            {
                comboBoxFinalidade.DataSource = FuncoesFinalidade.GetFinalidades();
                comboBoxFinalidade.DisplayMember = "descricao";
                comboBoxFinalidade.ValueMember = "idfinalidade";
                comboBoxFinalidade.SelectedValue = TipoDeOperacao.IDFinalidade;
            }
            catch (Exception exception)
            {
                var msg = "Desculpe! " + exception.Message;
                MessageBox.Show(msg, "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ovBTN_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_Nome.Text.Trim()))
                    throw new Exception("Informe o Nome.");

                if (string.IsNullOrEmpty(ovTXT_Serie.Text.Trim()))
                    throw new Exception("Informe a Serie.");

                if (string.IsNullOrEmpty(ovTXT_ModeloDocumento.Text.Trim()))
                    throw new Exception("Informe o Modelo de Documento.");

                if (comboBoxOperacaoFiscal.SelectedIndex == -1)
                    throw new Exception("Informe a Operação Fiscal.");

                if (comboBoxFinalidade.SelectedIndex == -1)
                    throw new Exception("Informe a Finalidade.");               

                if (comboBoxTipoAtendimento.SelectedIndex == -1)
                    throw new Exception("Informe o Tipo de Atendimento.");


                if (comboBoxCentroCusto.SelectedIndex == -1)
                    throw new Exception("Informe o Centro de Custo");

                if (comboBoxHistoricoFinanceiro.SelectedIndex == -1)
                    throw new Exception("Informe o Histórico Financeiro");

                if (comboBoxContaBancaria.SelectedIndex == -1)
                    throw new Exception("Informe a Conta Bancária");

                if (comboBoxTransportadora.SelectedIndex == -1)
                    if (checkNaoInformaTransp.Checked)
                    {
                        TipoDeOperacao.IDTransportadora = 0;
                    }
                    else
                    {
                        throw new Exception("Informe a Transportadora");
                    }
                else
                    TipoDeOperacao.IDTransportadora = (comboBoxTransportadora.SelectedItem as Transportadora).IDTransportadora;               

                
                TipoDeOperacao.Serie = Convert.ToInt32(ovTXT_Serie.Text);
                TipoDeOperacao.Nome = ovTXT_Nome.Text;
                TipoDeOperacao.ModeloDocumento = Convert.ToInt32(ovTXT_ModeloDocumento.Text);

                TipoDeOperacao.IDFinalidade = (comboBoxFinalidade.SelectedItem as Finalidade).IDFinalidade;
                TipoDeOperacao.IDTipoAtendimento = (comboBoxTipoAtendimento.SelectedItem as TipoAtendimento).IDTipoAtendimento;
                TipoDeOperacao.IDOperacaoFiscal = (comboBoxOperacaoFiscal.SelectedItem as Cfop).IDCfop;
                TipoDeOperacao.IdCentroCusto = (comboBoxCentroCusto.SelectedItem as CentroCusto).IDCentroCusto;
                TipoDeOperacao.IDHistoricoFinanceiro = (comboBoxHistoricoFinanceiro.SelectedItem as HistoricoFinanceiro).IDHistoricoFinanceiro;
                TipoDeOperacao.IDContaBancaria = (comboBoxContaBancaria.SelectedItem as DAO.Entidades.Financeiro.ContaBancaria).IDContaBancaria;
                

                TipoDeOperacao.InformacoesComplementares = ovTXT_InformacoesComplementares.Text;
                
                TipoDeOperacao.ControlarEstoque = checkBoxControlarEstoque.Checked;
                
                TipoDeOperacao.PermiteEstoqueNegativo = checkBoxEstoqueNegativo.Checked;
                TipoDeOperacao.LimiteCredito = checkBoxLimiteCredito.Checked;
                TipoDeOperacao.GerarFinanceiro = checkBoxGerarFinanceiro.Checked;

                TipoDeOperacao.TipoDeFrete = ovLBL_FreteEmitente.Checked ? 0 : TipoDeOperacao.TipoDeFrete;
                TipoDeOperacao.TipoDeFrete = ovLBL_FreteDestinatario.Checked ? 1 : TipoDeOperacao.TipoDeFrete;
                TipoDeOperacao.TipoDeFrete = ovLBL_FreteTerceiros.Checked ? 2 : TipoDeOperacao.TipoDeFrete;
                TipoDeOperacao.TipoDeFrete = ovLBL_SemFrete.Checked ? 9 : TipoDeOperacao.TipoDeFrete;

                TipoDeOperacao.TipoDeMovimento = radioEntrada.Checked ? TipoDeOperacao.Entrada : TipoDeOperacao.Saida;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesTipoDeOperacao.Existe(TipoDeOperacao.IDTipoDeOperacao))
                {
                    TipoDeOperacao.IDTipoDeOperacao = Sequence.GetNextID("TIPODEOPERACAO", "IDTIPODEOPERACAO");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesTipoDeOperacao.Salvar(TipoDeOperacao, Op))
                    throw new Exception("Não foi possível salvar o Tipo de Operacao.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Tipo de Operação salva com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void FCA_TipoDeOperacao_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void radioButtonEntrada_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkNaoInformaTransp.Checked)
            {
                comboBoxTransportadora.SelectedIndex = -1;
            }
        }

        private void comboBoxTransportadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkNaoInformaTransp.Checked = false;
        }

        private void radioEntrada_CheckedChanged(object sender, EventArgs e)
        {
            PreencherHistoricoFinanceiro();

            PreencherCentroCusto();
        }
        private void btnAddTipoTitulo_Click(object sender, EventArgs e)
        {
            var _operacao = radioEntrada.Checked ? Operacao.DeEntrada : Operacao.DeSaida;
            FCA_CentroCusto fCA_TipoTitulo = new FCA_CentroCusto(new CentroCusto(), _operacao);
            fCA_TipoTitulo.ShowDialog();           
            var idTipo = fCA_TipoTitulo.Tipo.IDCentroCusto;
            if (idTipo > 0)
            {
                TipoDeOperacao.IdCentroCusto = idTipo;
                PreencherCentroCusto();
            }
               
        }

        private void btnAddContaBancaria_Click(object sender, EventArgs e)
        {
            FCA_ContaBancaria fCA_ContaBancaria = new FCA_ContaBancaria(new DAO.Entidades.Financeiro.ContaBancaria());
            fCA_ContaBancaria.ShowDialog();

            var idConta = fCA_ContaBancaria.Conta.IDContaBancaria;

            if (idConta > 0)
            {
                TipoDeOperacao.IDContaBancaria = idConta;
                PreencherContaBancaria();
            }
                
        }

        private void btnAddHistorico_Click(object sender, EventArgs e)
        {
            var _operacao = radioEntrada.Checked ? Operacao.DeEntrada : Operacao.DeSaida;
            FCA_HistoricoFinanceiro fCA_HistoricoFinanceiro = new FCA_HistoricoFinanceiro(new HistoricoFinanceiro(), _operacao);
            fCA_HistoricoFinanceiro.ShowDialog();
            var idHistorico = fCA_HistoricoFinanceiro.Historico.IDHistoricoFinanceiro;

            if (idHistorico > 0)
            {
                TipoDeOperacao.IDHistoricoFinanceiro = idHistorico;
                PreencherHistoricoFinanceiro();
            }
        }

        private void btnAddTransportadora_Click(object sender, EventArgs e)
        {
            FCA_Transportadora fCA_Transportadora = new FCA_Transportadora(new Transportadora());
            fCA_Transportadora.ShowDialog();
            var idTransportadora = fCA_Transportadora.Transportadora.IDTransportadora;

            if (idTransportadora > 0)
            {
                TipoDeOperacao.IDTransportadora = idTransportadora;
                PreencherTransportadora();
            }
        }
        private void btnOperaçãoFiscal_Click(object sender, EventArgs e)
        {
            FCA_Cfop fCA_Cfop = new FCA_Cfop(new Cfop());
            fCA_Cfop.ShowDialog();
            var idCfop = fCA_Cfop.Cfop.IDCfop;

            if (idCfop > 0)
            {
                TipoDeOperacao.IDOperacaoFiscal = idCfop;
                PreencherOperacaoFiscal();
            }
        }

    }
    
}
