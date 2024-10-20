using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.Financeiro;
using PDV.UTIL.Components.Custom;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro.Financeiro.Modulo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Financeiro
{
    public partial class GFIN_RenegociacaoTitulo : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "RENEGOCIAÇÃO DE CONTAS A RECEBER";
        private DataTable LANCAMENTOS = null;
        private DataGridViewCheckBoxColumnHeaderCell CheckAllColumn;

        public GFIN_RenegociacaoTitulo()
        {
            InitializeComponent();
            Carregar();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            LimparTela();
        }

        private void LimparTela()
        {
            ovTXT_Cliente.Text = string.Empty;
            ovTXT_VencimentoInicio.Value = DateTime.Now;
            ovTXT_Origem.Text = string.Empty;
            ovTXT_FormaPagamento.Text = string.Empty;
            ovTXT_VencimentoInicio.Value = DateTime.Now.AddMonths(-1);
            ovTXT_VencimentoFim.Value = DateTime.Now;
            ovTXT_EmissaoInicio.Value = DateTime.Now.AddMonths(-1);
            ovTXT_EmissaoFim.Value = DateTime.Now;
        }

        private void AjustaHeaderTextGrid()
        {
            //switch (column.Name)
            //{
            //    case "selecionado":
            //        column.DisplayIndex = 1;
            //        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.05);
            //        column.Width = Convert.ToInt32(WidthGrid * 0.05);
            //        column.HeaderText = string.Empty;
            //        CheckAllColumn = new DataGridViewCheckBoxColumnHeaderCell();
            //        column.HeaderCell = CheckAllColumn;
            //        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //        column.HeaderText = string.Empty;
            //        break;
            //    case "cliente":
            //        column.DisplayIndex = 2;
            //        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.17);
            //        column.Width = Convert.ToInt32(WidthGrid * 0.17);
            //        column.HeaderText = "CLIENTE";
            //        break;
            //    case "parcela":
            //        column.DisplayIndex = 3;
            //        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.08);
            //        column.Width = Convert.ToInt32(WidthGrid * 0.08);
            //        column.HeaderText = "PARCELA";
            //        break;
            //    case "emissao":
            //        column.DisplayIndex = 4;
            //        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
            //        column.Width = Convert.ToInt32(WidthGrid * 0.10);
            //        column.HeaderText = "EMISSÃO";
            //        break;
            //    case "vencimento":
            //        column.DisplayIndex = 5;
            //        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
            //        column.Width = Convert.ToInt32(WidthGrid * 0.10);
            //        column.HeaderText = "VENCIMENTO";
            //        break;
            //    case "formapagamento":
            //        column.DisplayIndex = 6;
            //        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.18);
            //        column.Width = Convert.ToInt32(WidthGrid * 0.18);
            //        column.HeaderText = "FORMA DE PAGAMENTO";
            //        break;
            //    case "origem":
            //        column.DisplayIndex = 7;
            //        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.12);
            //        column.Width = Convert.ToInt32(WidthGrid * 0.12);
            //        column.HeaderText = "ORIGEM";
            //        break;
            //    case "saldo":
            //        column.DisplayIndex = 8;
            //        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
            //        column.Width = Convert.ToInt32(WidthGrid * 0.10);
            //        column.HeaderText = "SALDO";
            //        break;
            //    case "situacao":
            //        column.DisplayIndex = 9;
            //        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
            //        column.Width = Convert.ToInt32(WidthGrid * 0.10);
            //        column.HeaderText = "SITUAÇÃO";
            //        break;
            //    default:
            //        column.DisplayIndex = 0;
            //        column.Visible = false;
            //        break;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = "CLIENTE";
            gridView1.Columns[2].Caption = "PARCELA";
            gridView1.Columns[3].Caption = "EMISSÃO";
            gridView1.Columns[4].Caption = "VENCIMENTO";
            gridView1.Columns[5].Caption = "FORMA DE PAGAMENTO";
            gridView1.Columns[6].Caption = "ORIGEM";
            gridView1.Columns[7].Caption = "SALDO";
            gridView1.Columns[8].Caption = "SITUAÇÃO";
            gridView1.Columns[9].Visible = false;
            gridView1.Columns[10].Visible = false;

        }

        private void Carregar()
        {
            LANCAMENTOS = FuncoesContaReceber.GetContasComSaldoEmAberto("","","");
           
            gridControl1.DataSource = LANCAMENTOS;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaHeaderTextGrid();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Carregar();
        }

        private void GFIN_RenegociacaoTitulo_Load(object sender, EventArgs e)
        {
            LimparTela();
            Carregar();
        }

        private void ovGRD_Contas_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            switch (gridView1.Columns[e.ColumnIndex].Name)
            {
                case "saldo":
                    e.Value = Convert.ToDecimal(e.Value).ToString("c2");
                    break;
            }
        }

        private void ovGRD_Contas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
                for (int i = 0; i < gridView1.RowCount; i++)
                    ((DataGridViewCheckBoxCell)(sender as DataGridView).Rows[i].Cells["SELECIONADO"]).Value = CheckAllColumn.CheckAll;
        }

        private void ovGRD_Contas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var x = (DataGridViewCheckBoxCell)(sender as DataGridView).Rows[e.RowIndex].Cells["SELECIONADO"];
                x.Value = !Convert.ToBoolean(x.Value);
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            // Renegociar
            try
            {
                PDVControlador.BeginTransaction();

                var lQuerySelecionados = LANCAMENTOS.AsEnumerable().Where(o => Convert.ToBoolean(o["SELECIONADO"]));
                if (lQuerySelecionados != null && lQuerySelecionados.Count() > 0)
                {
                    var lQueryMaisDeUmClienteSelecionado = LANCAMENTOS.AsEnumerable().Where(o => Convert.ToBoolean(o["SELECIONADO"])).Select(o => Convert.ToDecimal(o["IDCLIENTE"])).Distinct();
                    if (lQueryMaisDeUmClienteSelecionado != null && lQueryMaisDeUmClienteSelecionado.Count() > 1)
                        throw new Exception("Não é possível selecionar mais de um Cliente para renegociar.");

                    List<ContaReceber> ContasReceber = new List<ContaReceber>();
                    foreach (DataRow dr in lQuerySelecionados.CopyToDataTable().Rows)
                    {
                        if (dr["IDCONTARECEBER"] == DBNull.Value)
                            continue;

                        ContasReceber.Add(FuncoesContaReceber.GetContaReceber(Convert.ToDecimal(dr["IDCONTARECEBER"])));
                    }

                    ContaReceber ContaNova = new ContaReceber()
                    {
                        IDContaReceber = Sequence.GetNextID("CONTARECEBER", "IDCONTARECEBER"),
                        IDCliente = ContasReceber.FirstOrDefault().IDCliente,
                        ComplmHisFin = string.Empty,
                        Desconto = 0,
                        Juros = 0,
                        Multa = 0,
                        Emissao = DateTime.Now,
                        Fluxo = DateTime.Now,
                        IDContaBancaria = ContasReceber.FirstOrDefault() == null ? null : ContasReceber.FirstOrDefault().IDContaBancaria,
                        IDFormaDePagamento = ContasReceber.FirstOrDefault().IDFormaDePagamento,
                        IDHistoricoFinanceiro = ContasReceber.FirstOrDefault().IDHistoricoFinanceiro,
                        IDCentroCusto = ContasReceber.FirstOrDefault().IDCentroCusto,
                        Origem = "RENEG",
                        Parcela = 1,
                        Saldo = ContasReceber.Sum(o => o.Saldo),
                        Situacao = 1,
                        Titulo = null,
                        Valor = ContasReceber.Sum(o => o.Saldo),
                        ValorTotal = ContasReceber.Sum(o => o.Saldo),
                        Vencimento = DateTime.Now,
                        IDUsuario = Contexto.USUARIOLOGADO.IDUsuario
                    };

                    if (!FuncoesContaReceber.Salvar(ContaNova, DAO.Enum.TipoOperacao.INSERT))
                        throw new Exception("Não foi possível renegociar a Conta a Receber.");

                    foreach (ContaReceber Conta in ContasReceber)
                        if (!FuncoesContaReceber.UpdateRenegociacao(Conta.IDContaReceber, ContaNova.IDContaReceber))
                            throw new Exception("Não foi possível renegociar a Conta a Receber.");

                    FCAFIN_ContaReceber FormContaReceber = new FCAFIN_ContaReceber(ContaNova, false);
                    FormContaReceber.ShowDialog(this);
                    if (!FormContaReceber.Salvou)
                    {
                        PDVControlador.Rollback();
                        return;
                    }
                }
                else
                    throw new Exception("Selecione ao menos uma Conta para renegociar.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Conta renegociada com sucesso.", NOME_TELA);
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
