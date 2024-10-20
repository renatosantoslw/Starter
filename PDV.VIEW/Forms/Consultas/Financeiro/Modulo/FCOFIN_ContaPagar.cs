using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using FontAwesome.Sharp;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Estoque.PedidoDeCompra;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro.Financeiro.Modulo;
using PDV.VIEW.Forms.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas.Financeiro.Modulo
{
    public partial class FCOFIN_ContaPagar : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE CONTAS A PAGAR";
        private DataTable table = null;
        private List<decimal> IdsSelecionados
        {
            get
            {
                var ids = new List<decimal>();
                foreach (var linha in gridView1.GetSelectedRows())
                {
                    var id = Grids.GetValorDec(gridView1, "IDCONTAPAGAR", linha);
                    ids.Add(id);
                }

                return ids;

            }
        }
        public FCOFIN_ContaPagar()
        {
            InitializeComponent();
            dateEdit1.DateTime = DateTime.Today;
            dateEdit2.DateTime = dateEdit1.DateTime.AddDays(1);

                                 
            //icones

            Bitmap bitmapNovo = IconChar.PlusSquare.ToBitmap(Color.DarkGreen, 20);
            Bitmap bitmapEditar = IconChar.PenSquare.ToBitmap(Color.DarkOrange, 20);
            Bitmap bitmapDuplicar = IconChar.Clone.ToBitmap(Color.SteelBlue, 20);
            Bitmap bitmapBaixar = IconChar.HandHoldingUsd.ToBitmap(Color.SteelBlue, 25);
            Bitmap bitmapImprimir = IconChar.Print.ToBitmap(Color.SteelBlue, 20);
            Bitmap bitmapRemover = IconChar.MinusSquare.ToBitmap(Color.Firebrick, 20);
            
            Bitmap bitmapAtualizar = IconChar.SyncAlt.ToBitmap(Color.SteelBlue, 30);
            Bitmap bitmapBuscarProdutoNuvem = IconChar.CloudDownloadAlt.ToBitmap(Color.SteelBlue, 24);

            metroButton5.ImageOptions.Image = bitmapNovo;
            editarContasAPagarmetroButton.ImageOptions.Image = bitmapEditar;
            simpleButtonDuplicar.ImageOptions.Image = bitmapDuplicar;
            baixarMetroButton.ImageOptions.Image = bitmapBaixar;
            imprimriMetroButton.ImageOptions.Image = bitmapImprimir;
            metroButton3.ImageOptions.Image = bitmapRemover;//remover

            atualizarMetroButton.ImageOptions.Image = bitmapAtualizar;

            
        }


        private void FIN_ContaReceber_Load(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void Atualizar()
        {
            table = FuncoesContaPagar.GetContas(dateEdit1.DateTime.Date, dateEdit2.DateTime.Date.AddDays(1));
            gridControl1.DataSource = table;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;            
            AjustaTextGrid();
            gridView1.BestFitColumns();
        }
       
        private void AjustaTextGrid()
        {
            gridView1.Columns[2].Visible = false;
            gridView1.Columns[0].Caption = "ID";
            gridView1.Columns[1].Caption = "ID COMPRA";
            gridView1.Columns[3].Caption = "FORNECEDOR";
            gridView1.Columns[4].Caption = "PARCELA";
            gridView1.Columns[5].Caption = "EMISSÃO";
            gridView1.Columns[6].Caption = "VENCIMENTO";
            gridView1.Columns[7].Caption = "FORMA DE PAGAMENTO";
            gridView1.Columns[8].Caption = "ORIGEM";
            gridView1.Columns[9].Caption = "VALOR TOTAL";
            gridView1.Columns[9].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[9].DisplayFormat.FormatString = "n2";
            gridView1.Columns[10].Caption = "SITUAÇÃO";
            gridView1.Columns[11].Visible = false;

            gridView1.Columns[9].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;

            gridView1.Columns[9].SummaryItem.DisplayFormat = "Total R$ : {0:n2}";
            gridView1.Columns[0].SummaryItem.DisplayFormat = "Registros : {0}";

        }


        private void metroButton5_Click(object sender, EventArgs e)
        {
            new FCAFIN_ContaPagarEdicao(new ContaPagar()).ShowDialog(this);
            Atualizar();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                new FCAFIN_ContaPagarEdicao(FuncoesContaPagar.GetContaPagar(IdsSelecionados[0])).ShowDialog(this);                
                Atualizar();              
            }
            catch (Exception)
            {
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            var msg = "Deseja remover?";
            if (Confirm(msg) == DialogResult.Yes)
            {
                foreach (var id in IdsSelecionados)
                {
                    try
                    {
                        PDVControlador.BeginTransaction();
                        
                        var conta = FuncoesContaPagar.GetContaPagar(id);
                        if (conta.IDPedidoCompra != null || conta.Situacao != StatusConta.Aberto)
                        {
                            PDVControlador.Commit();
                            continue;
                        }                           

                        if (!FuncoesContaPagar.Remover(id))
                            throw new Exception($"Não foi possível remover o Lançamento {id}.");
                        

                        PDVControlador.Commit();
                    }
                    catch (Exception Ex)
                    {
                        Alert(Ex.Message);
                        PDVControlador.Rollback();
                    }
                }
                Atualizar();
            }
        }

        private void gridControl1_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                var contaPagar = FuncoesContaPagar.GetContaPagar(Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCONTAPAGAR").ToString()));


                FCAFIN_ContaPagarEdicao Form = new FCAFIN_ContaPagarEdicao(contaPagar);
                
                Form.ShowDialog(this);
                Atualizar();

            }
            catch (Exception)
            {


            }
            
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
        }

        private void baixarMetroButton_Click(object sender, EventArgs e)
        {
            if(IdsSelecionados.Count == 1)
            {
                var form = new FCAFIN_ContaPagarEdicao(FuncoesContaPagar.GetContaPagar(IdsSelecionados[0]));
                form.NovaBaixa();
                if (form.botaoSalvarBaixa)
                    form.SalvarTudo();
            }
            else
            {
                var msg = "Confirmar a baixa das contas selecionadas?";
                if (Confirm(msg) == DialogResult.Yes)
                    Baixar();
            }           
            Atualizar();
        }

        private void Baixar()
        {
            try
            {
                PDVControlador.BeginTransaction();

                foreach(var id in IdsSelecionados)
                {
                    var conta = FuncoesContaPagar.GetContaPagar(id);

                    if (conta.Situacao == StatusConta.Baixado && conta.Situacao == StatusConta.Cancelado)                    
                        continue;

                    var baixa = new BaixaPagamento()
                    {
                        IDContaPagar = conta.IDContaPagar,
                        IDBaixaPagamento = DAO.DB.Utils.Sequence.GetNextID("BAIXAPAGAMENTO", "IDBAIXAPAGAMENTO"),
                        IDFormaDePagamento = conta.IDFormaDePagamento,
                        IDContaBancaria = Convert.ToDecimal(conta.IDContaBancaria),
                        IDHistoricoFinanceiro = conta.IDHistoricoFinanceiro,
                        Valor = conta.Saldo,
                        Baixa = DateTime.Now
                    };
                    if (!FuncoesBaixaPagamento.Salvar(baixa, TipoOperacao.INSERT))
                        throw new Exception($"Não foi possível baixar a conta na baixa {id}");

                    if (conta.IDContaBancaria == null)
                        conta.IDContaBancaria = conta.IDContaBancaria;
                    conta.Situacao = StatusConta.Baixado;
                    conta.Saldo = 0;
                    if (!FuncoesContaPagar.Salvar(conta, TipoOperacao.UPDATE))
                        throw new Exception($"Não foi possível salvar a conta {conta.IDContaPagar}");
                }    
                PDVControlador.Commit();
            }
            catch (Exception ex)
            {
                PDVControlador.Rollback();
                Alert(ex.Message);
            }
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {

            GridView currentView = sender as GridView;
            if (e.Column.FieldName == "situacao" )
            {
                string valor;
                try
                {
                    var cellValue = gridView1.GetRowCellValue(e.RowHandle, "situacao");
                    if (cellValue != null)
                        valor = cellValue.ToString();
                    else throw new Exception();
                }
                catch (Exception)
                {
                    valor = "";
                }
                switch (valor)
                {
                    case "BAIXADO":
                        e.Appearance.ForeColor = System.Drawing.Color.Green;
                        break;
                    case "CANCELADO":
                        e.Appearance.ForeColor = System.Drawing.Color.Red;
                        break;
                    case "ABERTO":
                        e.Appearance.ForeColor = System.Drawing.Color.Blue;
                        break;
                    case "PARCIAL":
                        e.Appearance.ForeColor = System.Drawing.Color.Yellow;
                        e.Appearance.BackColor = e.Appearance.BackColor2 = System.Drawing.Color.Gray;
                        break;
                }
            }
            
        }

        private void simpleButtonDuplicar_Click(object sender, EventArgs e)
        {
            var msg = "Deseja duplicar?";
            if(Confirm(msg) == DialogResult.Yes)
            foreach (var id in IdsSelecionados)
                DuplicarConta(id);
            Atualizar();
        }

        private DialogResult Confirm(string msg)
        {
            return MessageBox.Show(msg, NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void DuplicarConta(decimal id)
        {
            try
            {
                PDVControlador.BeginTransaction();

                var conta = FuncoesContaPagar.GetContaPagar(id);
                conta.IDContaPagar = DAO.DB.Utils.Sequence.GetNextID("CONTAPAGAR", "IDCONTAPAGAR");
                conta.Situacao = 1;
                conta.Emissao = conta.Vencimento = conta.Fluxo = DateTime.Now;
                conta.Ord = "";
                conta.Parcela = 1;
                conta.Saldo = conta.ValorTotal;
                conta.IDPedidoCompra = null;

                if (!FuncoesContaPagar.Salvar(conta, DAO.Enum.TipoOperacao.INSERT))
                    throw new Exception($"Não foi possível duplicar a conta {id}");

                PDVControlador.Commit();
            }
            catch (Exception ex)
            {
                PDVControlador.Rollback();
                Alert(ex.Message);
            }
        }

        private void Alert(string message)
        {
            MessageBox.Show(message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void gridView1_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            GridImprimir.FormatarImpressão(ref e);            
        }
        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (dateEdit1.DateTime > dateEdit2.DateTime)
                dateEdit2.DateTime = dateEdit1.DateTime.AddDays(1);
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (dateEdit1.DateTime > dateEdit2.DateTime)
            {
                dateEdit1.DateTime = dateEdit2.DateTime;
                dateEdit2.DateTime = dateEdit1.DateTime.AddDays(1);
            }
        }
    }   
}
