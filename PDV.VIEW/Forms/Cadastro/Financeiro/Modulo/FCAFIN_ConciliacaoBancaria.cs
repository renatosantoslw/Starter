using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.Financeiro.Modulo
{
    public partial class FCAFIN_ConciliacaoBancaria : DevExpress.XtraEditors.XtraForm
    {
        private DataTable DADOS = null;
        private string NOME_TELA = "CONCILIAÇÃO BANCÁRIA";
        public FCAFIN_ConciliacaoBancaria()
        {
            InitializeComponent();
            LimparTela();
            Size = new Size(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.85), Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.85));
            Carregar();
        }

        private void LimparTela()
        {
            ovTXT_Cliente.Text = string.Empty;
            ovTXT_VencimentoInicio.Value = DateTime.Now;
            ovTXT_Origem.Text = string.Empty;
            ovTXT_FormaPagamento.Text = string.Empty;
            ovTXT_VencimentoInicio.Value = DateTime.Now.AddMonths(-1);
            ovTXT_VencimentoFim.Value = DateTime.Now;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FCAFIN_ConciliacaoBancaria_Load(object sender, EventArgs e)
        {
            Carregar();
        }

        private void Carregar()
        {
            DADOS = FuncoesConciliacaoBancaria.GetBaixasParaConciliar(ovTXT_Cliente.Text, ovTXT_VencimentoInicio.Value, ovTXT_VencimentoFim.Value, ovTXT_FormaPagamento.Text, ovTXT_Origem.Text);
            gridControl1.DataSource = DADOS;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {

            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = "CLIENTE/FORNECEDOR";
            gridView1.Columns[2].Caption = "C. BANCÁRIA";
            gridView1.Columns[3].Caption = "F. PAGAMENTO";
            gridView1.Columns[4].Caption = "ORIGEM";
            gridView1.Columns[5].Caption = "MOVIMENTO";
            gridView1.Columns[6].Caption = "VENCIMENTO ";
            gridView1.Columns[7].Caption = "PARCELA";
            gridView1.Columns[8].Caption = "VALOR";
            gridView1.Columns[9].Caption = "VALOR TOTAL";
            gridView1.Columns[10].Caption = "CONCILIAÇÃO";
            gridView1.Columns[11].Visible = false;
            gridView1.Columns[12].Visible = false;
            gridView1.Columns[13].Visible = false;
            gridView1.Columns[14].Caption = "TITULO";
            
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Carregar();
        }
        

        private void ovGRD_Lancamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var x = (DataGridViewCheckBoxCell)(sender as DataGridView).Rows[e.RowIndex].Cells["SELECIONADO"];
            x.Value = !Convert.ToBoolean(x.Value);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            LimparTela();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var lQueryLancamentos = DADOS.AsEnumerable().Where(o => Convert.ToBoolean(o["SELECIONADO"]));
                if (lQueryLancamentos == null)
                    throw new Exception("Não foi possível Conciliar as Baixa(s).");

                if (lQueryLancamentos.Count() == 0)
                    throw new Exception("Selecione ao menos uma Baixa para Conciliar.");

                if (MessageBox.Show(this, "Deseja Conciliar as Baixas Selecionadas?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    PDVControlador.BeginTransaction();

                    foreach (DataRow dr in lQueryLancamentos.CopyToDataTable().Rows)
                        if (Convert.ToDecimal(dr["TITULO"]) == 0)
                        {
                            if (!FuncoesConciliacaoBancaria.ConciliarBaixa(Convert.ToDecimal(dr["IDBAIXA"]), DateTime.Now, (TipoBaixa)Enum.Parse(typeof(TipoBaixa), dr["TIPOBAIXA"].ToString())))
                                throw new Exception("Não foi possível Conciliar as Baixa(s).");
                        }
                        else if (Convert.ToDecimal(dr["TITULO"]) == 1)
                        {
                            // MovimentacaoBancaria
                            if (!FuncoesMovimentoBancario.Conciliar(Convert.ToDecimal(dr["IDBAIXA"]), DateTime.Now))
                                throw new Exception("Não foi possível Conciliar o Movimento Bancário.");
                        }

                    PDVControlador.Commit();
                    Carregar();
                    MessageBox.Show(this, "Baixas Conciliada(s) com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                if (PDVControlador.CONTROLADOR.InTransaction(Contexto.IDCONEXAO_PRIMARIA))
                    PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                var lQueryLancamentos = DADOS.AsEnumerable().Where(o => Convert.ToBoolean(o["SELECIONADO"]));
                if (lQueryLancamentos == null)
                    throw new Exception("Não foi possível Desconciliar as Baixa(s).");

                if (lQueryLancamentos.Count() == 0)
                    throw new Exception("Selecione ao menos uma Baixa para Desconciliar.");

                if (MessageBox.Show(this, "Deseja Desconciliar as Baixas Selecionadas?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    PDVControlador.BeginTransaction();

                    foreach (DataRow dr in lQueryLancamentos.CopyToDataTable().Rows)
                    {
                        if (Convert.ToDecimal(dr["TITULO"]) == 0)
                        {
                            if (!FuncoesConciliacaoBancaria.ConciliarBaixa(Convert.ToDecimal(dr["IDBAIXA"]), null, (TipoBaixa)Enum.Parse(typeof(TipoBaixa), dr["TIPOBAIXA"].ToString())))
                                throw new Exception("Não foi possível Desconciliar as Baixa(s).");
                        }
                        else if (Convert.ToDecimal(dr["TITULO"]) == 1)
                        {
                            // MovimentacaoBancaria
                            if (!FuncoesMovimentoBancario.Conciliar(Convert.ToDecimal(dr["IDBAIXA"]), null))
                                throw new Exception("Não foi possível Conciliar o Movimento Bancário.");
                        }
                    }

                    PDVControlador.Commit();
                    Carregar();
                    MessageBox.Show(this, "Baixas Desonciliada(s) com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                if (PDVControlador.CONTROLADOR.InTransaction(Contexto.IDCONEXAO_PRIMARIA))
                    PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            Carregar();
        }

        private void FCAFIN_ConciliacaoBancaria_KeyDown(object sender, KeyEventArgs e)
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
