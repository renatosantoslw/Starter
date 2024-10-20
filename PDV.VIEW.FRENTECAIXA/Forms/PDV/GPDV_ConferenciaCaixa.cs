using ACBr.Net.Core.Extensions;
using DevExpress.CodeParser;
using DevExpress.RichEdit.Export;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Import.Doc;
using MetroFramework;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.NFe;
using PDV.DAO.Entidades.PDV;
using PDV.UTIL.Calculos;
using PDV.UTIL.Components;
using PDV.UTIL.FORMS.Forms.Caixa;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms.PDV
{
    public partial class GPDV_ConferenciaCaixa : XtraForm
    {

        private FluxoCaixa FluxoAberto = null;
        public decimal User { get; set; }

        public FluxoCaixaPDVCalculos FluxoCalculos { get; set; }

        public Dictionary<string, decimal> DuplicatasAgrupadas { get; set; }

        public BindingList<ConferenciaCaixaGridViewModel> ListaConferenciaCaixa { get; set; }

        public Caixa MostrarRelatorio = null;

        public class ConferenciaCaixaGridViewModel
        {
            public decimal ID { get; set; }
            public string Nome { get; set; }
            public decimal Valor { get; set; }
            public decimal Calculado { get; set; }
            public decimal Diferenca { get; set; }
        }

        public GPDV_ConferenciaCaixa(decimal UsuarioLogado)
        {
            InitializeComponent();
            FluxoAberto = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuario(UsuarioLogado);
            MostrarRelatorio = (FuncoesCaixa.GetCaixa(FluxoAberto.CaixaID));
            InicializarVariaveis(UsuarioLogado);

            txtValor.GotFocus += foco;

            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            gridControl1.DataSource = ListaConferenciaCaixa;

            ListaConferenciaCaixa.ListChanged += (s, e) =>
                totalTextEdit.EditValue = ListaConferenciaCaixa
                    .Sum(c => c.Valor)
                    .ToString("c2");

            var colunas = new List<string> { "Valor", "Calculado", "Diferenca" };

            Grids.FormatColumnType(ref gridView1, colunas, GridFormats.Finance);
            Grids.FormatColumnType(ref gridView1, colunas, GridFormats.SumFinance);

            if (!MostrarRelatorio.Mostrar_Relatorio_Caixa) gridView1.Columns["Diferenca"].Visible = false;
            if (!MostrarRelatorio.Mostrar_Relatorio_Caixa) gridView1.Columns["Calculado"].Visible = false;


        }

        private void InicializarVariaveis(decimal UsuarioLogado)
        {
            User = UsuarioLogado;
            FluxoCalculos = new FluxoCaixaPDVCalculos(FluxoAberto);
            DuplicatasAgrupadas = FluxoCalculos.GetDuplicatasAgrupadas();
            ListaConferenciaCaixa = new BindingList<ConferenciaCaixaGridViewModel>();

        }

        public void CarregarCombo()
        {
            try
            {
                var dt = FuncoesDuplicataNFe.GetDuplicatasConferencia(FluxoAberto.IDFluxoCaixa);
                dt.Columns[0].Caption = "CÓDIGO";
                dt.Columns[1].Caption = "DESCRIÇÃO";
                cboFormaPagamento.Properties.DataSource = dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void frmConferenciaCaixa_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarCombo();
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
        }

        private void cboFormaPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValor.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();

                decimal totalCalculado = CalcularTotalDuplicatas();
                var valorDigitado = decimal.Parse(txtValor.Text);
                var diferenca = valorDigitado - totalCalculado;

                //txtTotal.Text = txtValor.Text;
                //txtTotal.Text = SomarLinhas(dgConferencia, 2).ToString();

                ListaConferenciaCaixa.Add(new ConferenciaCaixaGridViewModel()
                {
                    ID = Convert.ToDecimal(cboFormaPagamento.EditValue),
                    Nome = cboFormaPagamento.Text,
                    Valor = valorDigitado,
                    Calculado = totalCalculado,
                    Diferenca = valorDigitado - totalCalculado
                });
                txtValor.Text = String.Empty;
                cboFormaPagamento.EditValue = "";
                cboFormaPagamento.Focus();
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
        }

        private decimal CalcularTotalDuplicatas()
        {
            var descricaoFormaPagamento = cboFormaPagamento.Text;

            var totalCalculado = 0M;
            if (descricaoFormaPagamento == "DINHEIRO")
                totalCalculado = FluxoCalculos.GetDinheiroCaixa();
            else
                totalCalculado = DuplicatasAgrupadas
                .Where(d => d.Key == descricaoFormaPagamento)
                .Select(d => d.Value)
                .Single();

            return totalCalculado;
        }

        private void Validar()
        {
            if (cboFormaPagamento.EditValue == null)
            {
                cboFormaPagamento.Focus();
                throw new Exception("Informe a forma de pagamento!");
            }

            if (txtValor.Text == String.Empty)
            {
                cboFormaPagamento.Focus();
                throw new Exception("Informe o valor!");
            }

            if (ListaConferenciaCaixa.Where(c => c.Nome == cboFormaPagamento.Text).Count() > 0)
            {
                cboFormaPagamento.EditValue = null;
                cboFormaPagamento.Focus();
                throw new Exception("Esta forma de pagamento já foi conferida.");
            }
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            //DecimalMoeda.Moeda(ref txtValor);
        }

        public bool Fechou = false;
        public decimal ValorTotal = 0;

        private void FecharCaixa(decimal valortotal, string Observação)
        {
            try
            {
                var usuario = FuncoesUsuario.GetUsuario(User);
                if (!FuncoesFluxoCaixa.FecharCaixa(Convert.ToDecimal(valortotal), DateTime.Now, User, Observação, FluxoAberto.IDFluxoCaixa))
                    throw new Exception("Não foi possível Fechar o Caixa.");
                Close();
            }
            catch
            {
                Alert("Não foi possível Fechar o Caixa.");
            }
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {

                var formasPagamento = cboFormaPagamento.Properties.DataSource as DataTable;

                if (formasPagamento.Rows.Count > ListaConferenciaCaixa.Count())
                {
                    Alert("Ainda existe formas de pagamento a serem conferidas!");
                    return;
                }

                if (Confirm("Tem certeza que deseja efetuar a conferência do caixa?") == DialogResult.Yes)
                {
                    PDVControlador.BeginTransaction();
                    foreach (var conferencia in ListaConferenciaCaixa)
                    {
                        FuncoesConferenciaCaixaPDV.SalvarConferencia(new ConferenciaCaixaPDV()
                        {
                            IdFormaPagamento = conferencia.ID,
                            NomeFormaPagamento = conferencia.Nome,
                            valordigitado = conferencia.Valor,
                            valorcalculado = conferencia.Calculado,
                            diferenca = conferencia.Diferenca,
                            IdFluxoCaixa = FluxoAberto.IDFluxoCaixa,
                            Data = DateTime.Now
                        });
                    }
                    
                    ValorTotal = FluxoCalculos.GetValorFechamento();
                    FecharCaixa(ValorTotal, ocorrenciaDoDiaTextBox.Text);
                    Fechou = true;
                    PDVControlador.Commit();
                }
            }
            catch (Exception ex)
            {
                PDVControlador.Rollback();
                Fechou = false;
                Alert(ex.Message);
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            Fechou = false;
            Close();
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var rowHandles = gridView1.GetSelectedRows();
                if (rowHandles.Length > 0)
                    if (Confirm("Tem certeza que deseja excluir os itens selecionados?") == DialogResult.Yes)
                    {
                        var ids = new List<int>();
                        rowHandles.ForEach(r => ids.Add(Grids.GetValorInt(gridView1, "ID", r)));
                        foreach (var id in ids)
                        {
                            var conferencia = ListaConferenciaCaixa.Where(c => c.ID == id).SingleOrDefault();
                            if (conferencia.ID > 0)
                                ListaConferenciaCaixa.Remove(conferencia);
                        }
                    }
                    else
                        Alert("Selecione no mínimo uma linha para excluir");
            }
            catch (Exception exception)
            {
                Alert(exception.Message);
            }

        }

        private void cboFormaPagamento_EditValueChanged(object sender, EventArgs e)
        {
            txtValor.Focus();
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                simpleButton1_Click(sender, e);
        }

        private DialogResult Confirm(string msg)
        {
            return MessageBox.Show(msg, "Conferência de Caixa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void Alert(string msg)
        {
            MessageBox.Show(msg, "Conferência de Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cboFormaPagamento_TextChanged(object sender, EventArgs e)
        {
         
        }


        private void foco(object sender, EventArgs e)
        {

            if (cboFormaPagamento.Text == string.Empty) return;

           

            if (!MostrarRelatorio.Mostrar_Relatorio_Caixa) return;


            txtValor.Text = CalcularTotalDuplicatas().ToString("#,##0.00");

        }

    }
}
