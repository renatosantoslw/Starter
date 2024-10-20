using DevExpress.Utils.Drawing.Helpers;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.API.Native;
using FastReport.Wizards;
using ModelAndroidApp.Controler;
using ModelAndroidApp.ModelAndroid;
using NFe.Classes.Informacoes.Detalhe.DeclaracaoImportacao;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLER.FuncoesFaturamento;
using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Estoque.Movimento;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Enum;
using PDV.REPORTS.Reports.DAV;
using PDV.REPORTS.Reports.Modelo_1;
using PDV.REPORTS.Reports.Modelo_2;
using PDV.REPORTS.Reports.Modelo_3;
using PDV.REPORTS.Reports.Modelo2;
using PDV.REPORTS.Reports.PedidoVendaTermica;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Relatorios;
using PDV.VIEW.Forms.Util;
using PDV.VIEW.Integração_Migrados;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using Cliente = PDV.DAO.Entidades.Cliente;
using Sequence = PDV.DAO.DB.Utils.Sequence;
using FontAwesome.Sharp;
using System.Drawing;

namespace PDV.VIEW.Forms.Gerenciamento.DAV
{
    public partial class PedidoDeVenda : XtraForm
    {
        public decimal VendaID { get; set; }

        public string Status { get; set; }

        public ContaReceber Conta;

        private List<decimal> IdsSelecionados
        {
            get
            {
                var ids = new List<decimal>();
                foreach (var linha in gridView1.GetSelectedRows())
                {
                    var id = Grids.GetValorDec(gridView1, "IDVENDA", linha);
                    ids.Add(id);
                }

                return ids;
            }
        }

        public Dictionary<string, Func<decimal, XtraReport>> modelos = new Dictionary<string, Func<decimal, XtraReport>>
        {
            {"0", new Func<decimal, XtraReport>(i => new Modelo1(i)) },
            {"1", new Func<decimal, XtraReport>(i => new Modelo1DuasVias(i)) },
            {"2", new Func<decimal, XtraReport>(i => new Modelo2(i)) },
            {"3", new Func<decimal, XtraReport>(i => new Modelo2DuasVias(i)) },
            {"4", new Func<decimal, XtraReport>(i => new Modelo3(i)) },
            {"5", new Func<decimal, XtraReport>(i => new Modelo3Unidade(i)) }
        };

        public PedidoDeVenda()
        {
            InitializeComponent();
            Conta = new ContaReceber();
            dateEdit1.DateTime = DateTime.Today;
            dateEdit2.DateTime = dateEdit1.DateTime.AddDays(1);
            Atualizar();
            iniciarMenuStrip();
            metroTabControl2.SelectedIndex = 0;
            CarregarPermissoes();




            Bitmap bitmapNovo = IconChar.PlusSquare.ToBitmap(Color.DarkGreen, 24);
            Bitmap bitmapDuplicar = IconChar.Clone.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapEditar = IconChar.PenSquare.ToBitmap(Color.DarkOrange, 24);
            Bitmap bitmapRemover = IconChar.MinusSquare.ToBitmap(Color.Firebrick, 24);
            Bitmap bitmapAtualizar = IconChar.SyncAlt.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapFaturar = IconChar.CheckSquare.ToBitmap(Color.DarkGreen, 24);
            Bitmap bitmapDesfazer = IconChar.Undo.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapCancelar = IconChar.Times.ToBitmap(Color.Firebrick, 24);
            Bitmap bitmapImprimir = IconChar.Print.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapVisualizar = IconChar.Eye.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapBaixarPedidos = IconChar.CloudDownloadAlt.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapPedidoApp = IconChar.MobileAlt.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapEmail = IconChar.PaperPlane.ToBitmap(Color.SteelBlue, 24);



            novoMetroButton.ImageOptions.Image = bitmapNovo;
            simpleButtonDuplicar.ImageOptions.Image = bitmapDuplicar;
            editarMetroButton.ImageOptions.Image = bitmapEditar;
            metroButtonRemover.ImageOptions.Image = bitmapRemover;//remover
            atualizarMetroButton.ImageOptions.Image = bitmapAtualizar;
            buttonFaturar.ImageOptions.Image = bitmapFaturar;
            buttonDesfazer.ImageOptions.Image = bitmapDesfazer;
            buttonCancelar.ImageOptions.Image = bitmapCancelar;
            simpleButton7.ImageOptions.Image = bitmapImprimir;
            simpleButton4.ImageOptions.Image = bitmapVisualizar;
            imprimriMetroButton.ImageOptions.Image = bitmapImprimir;
            simpleButton3.ImageOptions.Image = bitmapImprimir;
            metroButtonBaixarPedido.ImageOptions.Image = bitmapBaixarPedidos;
            simpleButton2.ImageOptions.Image = bitmapPedidoApp;
            enviarEmailSimpleButton.ImageOptions.Image = bitmapEmail;



        }

        private void CarregarPermissoes()
        {
            buttonFaturar.Enabled = Contexto.ITENSMENU.Where(i => i.IDItemMenu == 130).Count() == 1;
            buttonCancelar.Enabled = Contexto.ITENSMENU.Where(i => i.IDItemMenu == 131).Count() == 1;
            buttonDesfazer.Enabled = Contexto.ITENSMENU.Where(i => i.IDItemMenu == 132).Count() == 1;
        }

        public void iniciarMenuStrip()
        {
            //Iniciando o contexto menu strip 
            ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
            //Criando o ToolStripMenu
            ToolStripMenuItem atualizarToolStripMenuItem1 = new ToolStripMenuItem();
            ToolStripMenuItem novoStripMenuItem1 = new ToolStripMenuItem();
            ToolStripMenuItem editarStripMenuItem1 = new ToolStripMenuItem();
            ToolStripMenuItem enviarEmailStripMenuItem1 = new ToolStripMenuItem();
            ToolStripMenuItem CancelarFaturamentoToolStripMenuItem1 = new ToolStripMenuItem();
            ToolStripMenuItem RemoverToolStripMenuItem1 = new ToolStripMenuItem();
            ToolStripMenuItem FaturarToolStripMenuItem1 = new ToolStripMenuItem();
            ToolStripMenuItem ImprimirStripMenuItem1 = new ToolStripMenuItem();

            //Personalizando e nomeando a configuração do menu
            atualizarToolStripMenuItem1.Name = "atualizarToolStripMenuItem1";
            atualizarToolStripMenuItem1.Size = new System.Drawing.Size(175, 24);
            atualizarToolStripMenuItem1.Text = "Atualizar";

            novoStripMenuItem1.Name = "novoStripMenuItem1";
            novoStripMenuItem1.Size = new System.Drawing.Size(175, 24);
            novoStripMenuItem1.Text = "Novo";

            editarStripMenuItem1.Name = "editarStripMenuItem1";
            editarStripMenuItem1.Size = new System.Drawing.Size(175, 24);
            editarStripMenuItem1.Text = "Editar";

            enviarEmailStripMenuItem1.Name = "enviarEmailStripMenuItem1";
            enviarEmailStripMenuItem1.Size = new System.Drawing.Size(175, 24);
            enviarEmailStripMenuItem1.Text = "Enviar Email";

            CancelarFaturamentoToolStripMenuItem1.Name = "CancelarFaturamentoToolStripMenuItem1";
            CancelarFaturamentoToolStripMenuItem1.Size = new System.Drawing.Size(175, 24);
            CancelarFaturamentoToolStripMenuItem1.Text = "Cancelar";

            RemoverToolStripMenuItem1.Name = "RemoverToolStripMenuItem1";
            RemoverToolStripMenuItem1.Size = new System.Drawing.Size(175, 24);
            RemoverToolStripMenuItem1.Text = "Excluir";

            FaturarToolStripMenuItem1.Name = "FaturarToolStripMenuItem1";
            FaturarToolStripMenuItem1.Size = new System.Drawing.Size(175, 24);
            FaturarToolStripMenuItem1.Text = "Faturar";

            ImprimirStripMenuItem1.Name = "ImprimirStripMenuItem1";
            ImprimirStripMenuItem1.Size = new System.Drawing.Size(175, 24);
            ImprimirStripMenuItem1.Text = "Imprimir";

            //Adicionando os itens no MenuStrip
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                atualizarToolStripMenuItem1,
                novoStripMenuItem1,
                editarStripMenuItem1,
                enviarEmailStripMenuItem1,
                CancelarFaturamentoToolStripMenuItem1,
                RemoverToolStripMenuItem1,
                FaturarToolStripMenuItem1,
                ImprimirStripMenuItem1
            });
            //Associar o contexto Menu Strip na GridView
            gridControl1.ContextMenuStrip = contextMenuStrip1;

            //Criando os Eventos click
            atualizarToolStripMenuItem1.Click += new System.EventHandler(this.atualizarToolStripMenuItem1_Clieck);
            novoStripMenuItem1.Click += new System.EventHandler(this.novoStripMenuItem1Click_Clieck);
            editarStripMenuItem1.Click += new System.EventHandler(this.editarStripMenuItem1_Clieck);
            enviarEmailStripMenuItem1.Click += new System.EventHandler(enviarEmailStripMenuItem1_Clieck);
            CancelarFaturamentoToolStripMenuItem1.Click += new System.EventHandler(this.CancelarFaturamentoToolStripMenuItem1_Clieck);
            RemoverToolStripMenuItem1.Click += new System.EventHandler(this.RemoverToolStripMenuItem1_Clieck);
            FaturarToolStripMenuItem1.Click += new System.EventHandler(this.FaturarToolStripMenuItem1_Clieck);
            ImprimirStripMenuItem1.Click += new System.EventHandler(this.ImprimirStripMenuItem1_Clieck);
        }

        private void editarStripMenuItem1_Clieck(object sender, EventArgs e)
        {
            editarMetroButton_Click(sender, e);
        }

        private void novoStripMenuItem1Click_Clieck(object sender, EventArgs e)
        {
            novoMetroButton_Click(sender, e);
        }

        private void ImprimirStripMenuItem1_Clieck(object sender, EventArgs e)
        {
            imprimriMetroButton_Click(sender, e);
        }

        private void FaturarToolStripMenuItem1_Clieck(object sender, EventArgs e)
        {
            gerarFaturamentoMetroButton_Click(sender, e);
        }

        private void RemoverToolStripMenuItem1_Clieck(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void CancelarFaturamentoToolStripMenuItem1_Clieck(object sender, EventArgs e)
        {
            excluirMetroButton_Click(sender, e);

        }

        private void enviarEmailStripMenuItem1_Clieck(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void atualizarToolStripMenuItem1_Clieck(object sender, EventArgs e)
        {
            atualizarMetroButton_Click(sender, e);
        }

        public void FormatarGrid()
        {

            Grids.FormatColumnType(ref gridView1, new List<string>()
            {
                "comanda",
                "quantidadeitens",
                "idcomanda",
                "idcliente",
                "idusuario"
            }, GridFormats.VisibleFalse);

            Grids.FormatColumnType(ref gridView1, "valortotal", GridFormats.Finance);
            Grids.FormatColumnType(ref gridView1, "valortotal", GridFormats.SumFinance);


            Grids.FormatGrid(ref gridView1);
        }
        private void Atualizar()
        {
            gridControl1.DataSource = FuncoesVenda.GetVendas(dateEdit1.DateTime.Date, dateEdit2.DateTime.Date.AddDays(1), null);
            FormatarGrid();
           
        }
        private void MainDAV_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.KeyCode:
                    break;
            }
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            ImprimirGrid();
        }

        private void ImprimirGrid()
        {
            gridControl1.ShowPrintPreview();
        }

        private void novoMetroButton_Click(object sender, EventArgs e)
        {
            PedidoVendaItem pedido = new PedidoVendaItem(0);
            pedido.ShowDialog();
            Atualizar();
        }

        private void editarMetroButton_Click(object sender, EventArgs e)
        {
            try
            {
                Status = Grids.GetValorStr(gridView1, "STATUS");
                VendaID = IdsSelecionados[0];
                PedidoVendaItem pedido = new PedidoVendaItem((int)VendaID);
                pedido.ShowDialog();
                Atualizar();
            }
            catch (NullReferenceException ex)
            {

            }
        }


        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int IDVenda = int.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDVENDA").ToString()));
                VendaID = IDVenda;
                PedidoVendaItem pedido = new PedidoVendaItem(IDVenda);
                pedido.ShowDialog();
                Atualizar();
            }
            catch (NullReferenceException)
            {

            }
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void gerarFaturamentoMetroButton_Click(object sender, EventArgs e)
        {
            CursorMouse(Cursors.WaitCursor);
            var ids = IdsSelecionados;
            if (Confirm("Deseja efetuar o faturamento?") == DialogResult.Yes)
            {
                try
                {
                    PDVControlador.BeginTransaction();                    

                    foreach (var id in ids)
                    {
                        var vendaFaturamento = new VendaFaturamento(id, Contexto.USUARIOLOGADO);
                        vendaFaturamento.FaturarVenda();
                    }

                    PDVControlador.Commit();
                }
                catch (Exception exception)
                {
                    PDVControlador.Rollback();
                    Alert(exception.Message);
                }
            }
            Atualizar();
            CursorMouse(Cursors.Default);
        }

        private int FatorPeriodicidade(string periodicidade)
        {
            //Diário
            //Semanal
            //Quinzenal
            //Mensal
            //Bimestral
            //35 Dias
            //45 Dias
            //Trimestral
            //Semestral
            //Anual
            //Bienal
            int fator = 0;

            switch (periodicidade)
            {
                case "Diário":
                    fator = 1;
                    break;
                case "Semanal":
                    fator = 7;
                    break;
                case "Quinzenal":
                    fator = 15;
                    break;
                case "Mensal":
                    fator = 30;
                    break;
                case "Trimestral":
                    fator = 90;
                    break;
                case "Semestral":
                    fator = 180;
                    break;
                case "Anual":
                    fator = 365;
                    break;

                case "45 Dias":
                    fator = 45;
                    break;

                case "Bienal":
                    fator = 180;
                    break;

            }
            return fator;
        }

        private void excluirMetroButton_Click(object sender, EventArgs e)
        {
            
            CursorMouse(Cursors.WaitCursor);
            string msg = "Confirmar o cancelamento?";

            if (Confirm(msg) == DialogResult.Yes)
            {

                try
                {
                    PDVControlador.BeginTransaction();
                    foreach (decimal id in IdsSelecionados)
                    {
                        var motivo = XtraInputBox.Show($"Informe o motivo de cancelamento para a venda {id}", "Cancelar Venda", "");
                        var vendaFaturamento = new VendaFaturamento(id, Contexto.USUARIOLOGADO);
                        vendaFaturamento.CancelarVenda(motivo);
                    }
                    PDVControlador.Commit();
                    Atualizar();
                    MensagemSucesso("Cancelamento realizado com sucesso");

                }
                catch (Exception ex)
                {
                    PDVControlador.Rollback();
                    Alert("Erro ao cancelar pedido : " + ex.Message);
                }

            }
            CursorMouse(Cursors.Default);       
            
        }

        private DialogResult Confirm(string msg)
        {
            return MessageBox.Show(this, msg, "DAV", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void Alert(string msg)
        {
            MessageBox.Show(this, msg, "Pedido de Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MensagemSucesso(string msg)
        {
            MessageBox.Show(this, msg, "Pedido de Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MudarDataDeFaturamento(decimal id, DateTime? data)
        {
            Venda venda = FuncoesVenda.GetVenda(id);
            venda.DataFaturamento = data;
            if (!FuncoesVenda.SalvarVenda(venda))
                throw new Exception($"Não foi possível salvar a data de faturamento da venda {id}");
        }

        #region Dados do Pedido APP
        public DAO.Entidades.PDV.Venda Venda = null;
        public List<ItemVenda> lstItemDeVenda = null;
        public List<DuplicataNFCe> lstPagamentos = null;
        public CONTROLER.Funcoes.FuncoesComanda Comanda = null;
        public Cliente Cliente = null;
        public bool Alteracao = false;
        public decimal IDItemVenda { get; set; }
        public void IniciarVenda()
        {
            lstItemDeVenda = new List<ItemVenda>();

            Configuracao config2 = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.TIPO_OPERACAO_PADRAO_APP);
            if (config2 == null)
            {
                MessageBox.Show(@"Tipo de operação padrão não foi definido para essa operação. 
                                Vá em Configurações Vendas e geral e depois defina um tipo de operação padrão para venda no aplicativo."
                                , "Atenção",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Venda = new DAO.Entidades.PDV.Venda()
            {
                IDVenda = Sequence.GetNextID("VENDA", "IDVENDA"),
                IDUsuario = Contexto.USUARIOLOGADO.IDUsuario,
                DataCadastro = DateTime.Now,
                Status = 0,
                TipoDeVenda = 2,
                IDFluxoCaixa = 0,//!string.IsNullOrEmpty(FLUXO.IDFluxoCaixa) ? FLUXO.IDFluxoCaixa : 0,
                IDTipoDeOperacao = decimal.Parse(Encoding.UTF8.GetString(config2.Valor))
            };

        }
        #endregion

        private void AtualizarProgressBar()
        {
            progressBarControl1.PerformStep();
            progressBarControl1.Update();
        }
        private void AtualizarProgressBar(int pos)
        {
            progressBarControl1.Position = pos;

        }
        private void IniciarProgressBar(int Value)
        {
            progressBarControl1.Properties.Step = 1;
            progressBarControl1.Properties.PercentView = true;
            progressBarControl1.Properties.Maximum = Value;
            progressBarControl1.Properties.Minimum = 0;
            progressBarControl1.Properties.PercentView = true;
            progressBarControl1.Properties.TextOrientation = DevExpress.Utils.Drawing.TextOrientation.Horizontal;
            progressBarControl1.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            progressBarControl1.Properties.EndColor = System.Drawing.Color.SteelBlue;
            progressBarControl1.Properties.StartColor = System.Drawing.Color.PowderBlue;
            progressBarControl1.Properties.ShowTitle = true;
        }


        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                CursorMouse(Cursors.WaitCursor);
                pictureBox1.Visible = true;
                #region Do lado da API
                List<Nota> lstNota = new List<Nota>();
                List<NotaItem> lstNotaItem = new List<NotaItem>();
                List<Parcela> lstParcelas = new List<Parcela>();
                List<ModelAndroidApp.ModelAndroid.Cliente> lstClientes = new List<ModelAndroidApp.ModelAndroid.Cliente>();
                lstNota = NotaControllerAPP.BuscarNota(false).ToList();
                lstNotaItem = NotaControllerAPP.BuscarNotaItem(false);
                //lstParcelas = NotaControllerAPP.BuscarParcela(false);
                lstClientes = ClienteControllerAPP.ObterClientes();
                #endregion

                if (Confirm($"Existe {lstNota.Count} para ser baixados , confirma a baixa agora?") == DialogResult.Yes)
                {
                    if (lstNota != null)
                    {
                        IniciarProgressBar(lstNota.Count);
                        if (lstNota.Count > 0)
                        {
                            for (int i = 0; i < lstNota.Count; i++)
                            {
                                IniciarVenda();
                                AtualizarProgressBar();
                                Cliente = FuncoesCliente.GetCliente(lstNota[i].IDCliente);
                                PDVControlador.BeginTransaction();
                                Venda.ValorTotal = decimal.Parse(lstNota[i].TotalPedido.ToString());
                                Venda.IDCliente = null;
                                Venda.IDVendedor = decimal.Parse(lstNota[i].IDVendedor.Value.ToString());
                                try
                                {
                                    Venda.IDFormaPagamento = int.Parse(lstNota[i].IDCondicao.ToString());
                                }
                                catch (Exception)
                                {

                                }
                                if (Cliente != null)
                                {
                                    Venda.IDCliente = Cliente.IDCliente;
                                }

                                //Objter fluxo de caixa PDV
                                decimal IDFluxo = FuncoesVenda.GetFluxoCaixa();
                                if (IDFluxo != null)
                                {
                                    Venda.IDFluxoCaixa = IDFluxo;
                                }
                                FormaDePagamento Formapagamento = FuncoesFormaDePagamento.GetFormaDePagamento(decimal.Parse(lstNota[i].IDCondicao.Value.ToString()));
                                if (string.IsNullOrEmpty(lstNota[i].Observacao))
                                {
                                    Venda.Observacao = $"PAGAMENTO : {Formapagamento.IdentificacaoDescricao}";
                                }
                                else
                                {
                                    Venda.Observacao = $"PAGAMENTO : {Formapagamento.IdentificacaoDescricao}  | OBSERVAÇÕES : {lstNota[i].Observacao}";
                                }

                                if (!FuncoesVenda.SalvarVenda(Venda))
                                {
                                    throw new Exception("Não foi possível salvar a Venda.");
                                }

                                if (!FuncoesItemVenda.RemoverItensDaVenda(lstItemDeVenda, Venda.IDVenda))
                                {
                                    throw new Exception("Não foi possível salvar a Venda.");
                                }

                                #region Item

                                var NotaItemAPP = lstNotaItem.Where(x => x.IDNota == lstNota[i].IDPedido && x.IDVendedor == lstNota[i].IDVendedor).ToList();

                                //if(NotaItemAPP[0].ID == 302)
                                //{m

                                //}

                                //for (int j = 0; j < NotaItemAPP.Count; j++)
                                //{

                                foreach (var item in NotaItemAPP)
                                {
                                    decimal itemx = 1;
                                    ItemVenda itemVenda = new ItemVenda()
                                    {
                                        Item = itemx++,
                                        CodigoItem = item.IDProduto.ToString(),
                                        DescricaoItem = item.ProdutoNome,
                                        ValorUnitarioItem = item.Valor,
                                        Subtotal = item.Valor * item.Quantidade,
                                        IDProduto = Convert.ToDecimal(item.IDProduto.ToString()),
                                        IDItemVenda = Sequence.GetNextID("ITEMVENDA", "IDITEMVENDA"),
                                        IDVenda = Venda.IDVenda,
                                        Quantidade = Convert.ToDecimal(item.Quantidade),
                                        DescontoValor = item.ValorDesconto,
                                        IDUsuario = decimal.Parse(item.IDVendedor.ToString())
                                    };
                                    lstItemDeVenda.Add(itemVenda);
                                    NotaControllerAPP.AtualizarStatusNotaItemImportado(item.ID.ToString());
                                }
                                #endregion
                                foreach (ItemVenda Item in lstItemDeVenda)
                                {
                                    if (!FuncoesItemVenda.SalvarItemVenda(Item))
                                    {
                                        throw new Exception("Não foi possível salvar os Itens da Venda.");
                                    }
                                }
                                   
                              //  }
                                NotaControllerAPP.AtualizarStatusNotaImportado(lstNota[i].ID.ToString());
                                
                               

                                int dias = FatorPeriodicidade(Formapagamento.Periodicidade.ToString());

                                DuplicataNFCe duplicataNFCe = new DuplicataNFCe()
                                {
                                    IDDuplicataNFCe = Sequence.GetNextID("DUPLICATANFCE", "IDDUPLICATANFCE"),
                                    IDVenda = Venda.IDVenda,
                                    Valor = Convert.ToDecimal(Venda.ValorTotal),
                                    DataVencimento = DateTime.Now.AddDays(dias),
                                    IDFormaDePagamento = Venda.IDFormaPagamento,
                                    Pagamento = 0
                                };
                                if (!FuncoesItemDuplicataNFCe.SalvarDuplicataNFCe(duplicataNFCe))
                                        throw new Exception("Não foi possível salvar as Duplicatas NFCE.");

                                   
                               
                                PDVControlador.Commit();
                            }
                        }
                    }

                    //Atualizar Clientes
                    if (lstClientes.Count > 0)
                    {
                        Cliente _Cliente = new Cliente();
                        Contato _Contato = new Contato();
                        Endereco _Endereco = new Endereco();
                        Municipio _Municipio = new Municipio();
                        SalvarClienteAPP(lstClientes, _Cliente, _Contato, _Endereco, _Municipio);
                    }
                    progressBarControl1.EditValue = 0;
                    CursorMouse(Cursors.Default);
                    atualizarMetroButton_Click(sender, e);
                    pictureBox1.Visible = false;
                }
                else
                {
                    progressBarControl1.EditValue = 0;
                    CursorMouse(Cursors.Default);
                    atualizarMetroButton_Click(sender, e);
                    pictureBox1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                
                              
                PDVControlador.Rollback();
                pictureBox1.Visible = false;
                MessageBox.Show(this, "Erro ao baixar pedido : " + ex.Message, "Pedido de Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CursorMouse(Cursors.Default);
                Atualizar();
                progressBarControl1.EditValue = 0;
            }

        }

        private void CursorMouse(Cursor cursor)
        {
            Cursor.Current = cursor;
        }

        private static bool SalvarClienteAPP(List<ModelAndroidApp.ModelAndroid.Cliente> lstClientes, Cliente _Cliente, Contato _Contato, Endereco _Endereco, Municipio _Municipio)
        {
            try
            {
                PDVControlador.BeginTransaction();
                foreach (var item in lstClientes)
                {
                    _Cliente.IDCliente = PDV.DAO.DB.Utils.Sequence.GetNextID("CLIENTE", "IDCLIENTE");
                    if (item.CPFCNPJ.Length > 14)
                    {
                        _Cliente.TipoDocumento = 0;
                        _Cliente.CNPJ = ZeusUtil.SomenteNumeros(item.CPFCNPJ);
                        _Cliente.RazaoSocial = item.Nome;
                        _Cliente.CPF = string.Empty;
                        _Cliente.Nome = string.Empty;
                    }
                    else
                    {
                        _Cliente.TipoDocumento = 1;
                        _Cliente.CNPJ = string.Empty;
                        _Cliente.RazaoSocial = string.Empty;
                        _Cliente.Nome = item.Nome;
                        _Cliente.CPF = ZeusUtil.SomenteNumeros(item.CPFCNPJ);
                    }
                    _Cliente.InscricaoEstadual = null;
                    _Cliente.InscricaoMunicipal = null;
                    _Cliente.InscricaoMunicipal = null;
                    _Cliente.NomeFantasia = item.Nome;
                    _Cliente.Ativo = 1;//ovCMB_Ativo.Checked ? 1 : 0;
                    int ConsumidorFinal = 1;
                    decimal Contribuinte = 0;
                    Contribuinte = 0;
                    ConsumidorFinal = 1;
                    string email = "";
                    string NumeroCasa = "";
                    string Complemento = "";
                    email = item.Email;
                    NumeroCasa = "";
                    Complemento = "";
                    _Cliente.ConsumidorFinal = ConsumidorFinal;
                    _Cliente.Estrangeiro = 0;
                    _Cliente.DocEstrangeiro = null;
                    _Cliente.TipoContribuinte = Contribuinte;
                    _Cliente.IDVendedor = 1;
                    /* AbaContato */
                    _Contato.IDContato = PDV.DAO.DB.Utils.Sequence.GetNextID("CONTATO", "IDCONTATO");
                    _Contato.Email = email;
                    _Contato.EmailAlternativo = null;
                    _Contato.Telefone = item.Telefone;
                    _Contato.Celular = null;
                    _Cliente.IDContato = _Contato.IDContato;
                    /* Aba Endereço */
                    _Endereco.IDEndereco = PDV.DAO.DB.Utils.Sequence.GetNextID("ENDERECO", "IDENDERECO");
                    _Cliente.IDEndereco = _Endereco.IDEndereco;
                    _Endereco.Logradouro = item.Endereco;
                    if (NumeroCasa != null)
                    {
                        try
                        {
                            _Endereco.Numero = NumeroCasa;
                        }
                        catch (Exception)
                        {
                        }
                    }
                    _Endereco.Complemento = Complemento;
                    _Endereco.Bairro = item.Bairro;
                    _Endereco.Cep = null;
                    if (!string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(item.Cep)))
                        _Endereco.Cep = ZeusUtil.SomenteNumeros(item.Cep.Substring(1, 8));
                    _Endereco.IDPais = 1058;
                    _Endereco.IDUnidadeFederativa = null;
                    _Endereco.IDUnidadeFederativa = 23;
                    _Endereco.IDMunicipio = null;
                    _Municipio = FuncoesMunicipio.GetMunicipioDescricao(item.Cidade);
                    if (_Municipio != null)
                        _Endereco.IDMunicipio = _Municipio.IDMunicipio;

                    if (_Contato.IDContato != 0)
                    {
                        if (!FuncoesContato.Salvar(_Contato, DAO.Enum.TipoOperacao.INSERT))
                            throw new Exception("Não foi possível salvar o Contato.");
                    }
                    if (!FuncoesEndereco.Salvar(_Endereco, DAO.Enum.TipoOperacao.INSERT))
                        throw new Exception("Não foi possível salvar o Endereço.");

                    if (!FuncoesCliente.Salvar(_Cliente, DAO.Enum.TipoOperacao.INSERT))
                        throw new Exception("Não foi possível salvar o Cliente.");

                    ClienteControllerAPP.ExcluirClientePorID(item.ID);

                }
                PDVControlador.Commit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ao importar clientes clique OK para continuar. Detalhes :" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PDVControlador.Rollback();
                return false;
            }

        }

        private void metroButtonGerarNfe_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();
                decimal IDVenda = IdsSelecionados[0];
                if (!FuncoesNFe.GetNFeFoiGerada(IDVenda))
                {
                    DAO.Entidades.PDV.Venda venda = FuncoesVenda.GetVenda(IDVenda);
                    if (venda.Status != 1)
                        throw new Exception("Para gerar a NF-e a venda deve estar faturada.");


                    Vendas.NFe.GVEN_NFe nFeForm = new Vendas.NFe.GVEN_NFe(new DAO.Entidades.NFe.NFe());
                    nFeForm.CarregarPedido(venda);
                    nFeForm.ShowDialog();
                }
                else
                {
                    throw new Exception("A NFe desta venda já foi gerada");
                }
                PDVControlador.Commit();
            }
            catch (NullReferenceException)
            {
                PDVControlador.Rollback();
            }
            catch (Exception ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, ex.Message, "Pedido de Venda", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void metroButtonRemover_Click(object sender, EventArgs e)
        {

            if (Confirm("Confirmar ação de remover") == DialogResult.Yes)
            {
                try
                {
                    foreach (var id in IdsSelecionados)
                    {
                        var venda = FuncoesVenda.GetVenda(id);

                        if (venda.Status != StatusPedido.Aberto)
                            continue;

                        FuncoesItemDuplicataNFCe.ExcluirPorVenda(id);
                        FuncoesVenda.RemoverItemVendaPorVenda(id);
                        FuncoesVenda.Remover(id);
                    }

                    Atualizar();
                }
                catch (Exception exception)
                {
                    Alert(exception.Message);
                }                
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView currentView = sender as GridView;
            if (e.Column.FieldName == "STATUS")
            {
                string valor;
                try
                {
                    var cellValue = gridView1.GetRowCellValue(e.RowHandle, "STATUS");
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
                    case "FATURADO":
                        e.Appearance.ForeColor = System.Drawing.Color.Green;
                        break;
                    case "CANCELADO":
                        e.Appearance.ForeColor = System.Drawing.Color.Red;
                        break;
                    case "ABERTO":
                        e.Appearance.ForeColor = System.Drawing.Color.Blue;
                        break;
                    case "DESFEITO":
                        e.Appearance.ForeColor = System.Drawing.Color.Purple;
                        break;
                    case "APP":
                        e.Appearance.ForeColor = System.Drawing.Color.Blue;
                        e.Appearance.BackColor = System.Drawing.Color.Yellow;
                        break;
                }
            }
        }

        private void imprimirDAVSimpleButton_Click(object sender, EventArgs e)
        {
            ImprimirDavModelo1();
        }

        private void ImprimirDavModelo1()
        {

            try
            {
                if (Confirm("Confirmar impressão?") == DialogResult.Yes)
                {
                    foreach (decimal id in IdsSelecionados)
                    {
                        var rel = new Modelo1(id);
                        using (ReportPrintTool printTool = new ReportPrintTool(rel))
                        {
                            rel.PrintingSystem.ShowMarginsWarning = false;
                            printTool.Print();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Alert("Desculpe, não foi possível excutar a impressão: " + ex.Message);
            }
            
        }

        private void enviarEmailSimpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                IdsSelecionados.ForEach(i => EnviarRelatorioParaEmail(i));
            }
            catch (Exception ex)
            {
                CursorMouse(Cursors.Default);
                MessageBox.Show(this, ex.Message.ToString(), "DAV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnviarRelatorioParaEmail(decimal idVenda)
        {
            CursorMouse(Cursors.WaitCursor);

            Venda venda = FuncoesVenda.GetVenda(idVenda);
            Contato contato;
            if (venda.IDCliente != null)
            {
                Cliente cliente = FuncoesCliente.GetCliente(venda.IDCliente);
                if (cliente.IDContato != null)
                {
                    contato = FuncoesContato.GetContato((decimal)cliente.IDContato);
                }
                else
                {
                    throw new Exception("Cliente não possui email cadastrado");
                }

                Emitente emitente = FuncoesEmitente.GetEmitente();

                var report = GetModeloImpressao(idVenda);
                using (SmtpClient client = new SmtpClient())
                {
                    client.Host = Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(Email.EMAIL_SMTP).Valor);
                    client.Port = int.Parse(Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(Email.EMAIL_SMTP_PORT).Valor));
                    client.EnableSsl = Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(Email.EMAIL_SSL).Valor) == "1" ? true : false;
                    client.UseDefaultCredentials = false;// smtpSection.Network.DefaultCredentials;

                    string usuario = Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(Email.EMAIL_USUARIO).Valor);
                    string senha = Criptografia.DecodificaSenha(Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(Email.EMAIL_SENHA).Valor));
                    client.Credentials = new NetworkCredential(usuario, senha);

                    using (MailMessage message = report.ExportToMail(usuario, contato.Email, $"Pedido de Venda - Nº {venda.IDVenda}  - { emitente.NomeFantasia} "))
                    {
                        message.Body = $"Segue em anexo o DAV- DOCUMENTO AUXILIAR DE VENDA de número {idVenda}.";
                        client.Send(message);
                    }
                }
                MessageBox.Show(this, $"Email da venda {idVenda} enviado com sucesso!", "DAV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CursorMouse(Cursors.Default);
            }
            else
            {
                throw new Exception("Cliente não possui email cadastrado");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ImprimirDavModelo1DuasVias();
        }

        private void ImprimirDavModelo1DuasVias()
        {
            try
            {
                if (Confirm("Confirmar impressão?") == DialogResult.Yes)
                {
                    foreach (var id in IdsSelecionados)
                    {
                        var rel = new Modelo1DuasVias(id);
                        using (ReportPrintTool printTool = new ReportPrintTool(rel))
                        {
                            rel.ShowPrintMarginsWarning = false;
                            rel.PrintingSystem.ShowMarginsWarning = false;
                            printTool.Print();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Alert("Desculpe, não foi possível imprimir: " + ex.Message);
            }
        }

        private void simpleButtonDuplicar_Click(object sender, EventArgs e)
        {
            if (Confirm("Deseja duplicar o(s) item(s) selecionado(s)?") == DialogResult.Yes)
            {
                CursorMouse(Cursors.WaitCursor);
                foreach (var id in IdsSelecionados)
                    DuplicarVenda(id);

                CursorMouse(Cursors.Default);
            }           
        }

        private void DuplicarVenda(decimal id)
        {
            try
            {
                PDVControlador.BeginTransaction();
                Venda pedido = FuncoesVenda.GetVenda(id);
                pedido.DataCadastro = DateTime.Now;

                var itemVenda = FuncoesItemVenda.GetItensVenda(pedido.IDVenda);
                var duplicataNFCes = FuncoesItemDuplicataNFCe.GetPagamentosPorVenda(pedido.IDVenda);

                pedido.IDVenda = Sequence.GetNextID("VENDA", "IDVENDA");
                pedido.Status = 0;
                pedido.IDFluxoCaixa = -1;


                if (!FuncoesVenda.SalvarVenda(pedido))
                    throw new Exception($"Não foi possível duplicar a Venda {id}.");

                foreach (ItemVenda item in itemVenda)
                {
                    item.IDVenda = pedido.IDVenda;
                    item.IDItemVenda = Sequence.GetNextID("ITEMVENDA", "IDITEMVENDA");
                    if (!FuncoesItemVenda.SalvarItemVenda(item))
                        throw new Exception($"Não foi possível duplicar os Itens de Venda da Venda{id}.");
                }


                foreach (var item in duplicataNFCes)
                {
                    var duplicata = new DuplicataNFCe()
                    {
                        IDDuplicataNFCe = Sequence.GetNextID("DUPLICATANFCE", "IDDUPLICATANFCE"),
                        IDVenda = pedido.IDVenda,
                        IDFormaDePagamento = item.IDFormaDePagamento,
                        FormaDePagamento = item.FormaDePagamento,
                        Valor = item.Valor,
                        DataVencimento = item.DataVencimento
                    };
                    FuncoesItemDuplicataNFCe.SalvarDuplicataNFCe(duplicata);
                }

               
                PDVControlador.Commit();
                Atualizar();

            }
            catch (Exception exception)
            {
                PDVControlador.Rollback();
                Alert(exception.Message);
            }

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
        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            PedidoAPP pedidoAPP = new PedidoAPP();
            pedidoAPP.ShowDialog();
        }

        private void simpleButtonDesfazer_Click(object sender, EventArgs e)
        {
            DesfazerFaturamento();
        }

        private void DesfazerFaturamento()
        {
            CursorMouse(Cursors.WaitCursor);
            if (Confirm("Confirmar ação de desfazer?") == DialogResult.Yes)
            {               
                foreach (var id in IdsSelecionados)
                {
                    try
                    {
                        PDVControlador.BeginTransaction();
                        var vendaFaturamento = new VendaFaturamento(id, Contexto.USUARIOLOGADO);
                        vendaFaturamento.DesfazerVenda();
                        PDVControlador.Commit();
                    }
                    catch (Exception exception)
                    {
                        PDVControlador.Rollback();
                        Alert(exception.Message);
                    }
                }
               Atualizar();
            }
            CursorMouse(Cursors.Default);
        }
        private void EmitirCupomGerencial(decimal idVenda)
        {
            try
            {
                Configuracao Config_NomeImpressora = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOPEDIDOVENDA_NOMEIMPRESSORA);
                Configuracao Config_ExibirCaixaDialogo = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOPEDIDOVENDA_EXIBIRCAIXADIALOGO);

                ReciboPedidoVenda _ReciboPedidoVenda = new ReciboPedidoVenda(idVenda);


                if (Config_ExibirCaixaDialogo != null && "1".Equals(Encoding.UTF8.GetString(Config_ExibirCaixaDialogo.Valor)))
                {
                    using (ReportPrintTool printTool = new ReportPrintTool(_ReciboPedidoVenda))
                    {
                        _ReciboPedidoVenda.PrintingSystem.ShowMarginsWarning = false;
                        printTool.Print();
                    }
                }
                else
                {
                    Stream STRel = new MemoryStream();
                    _ReciboPedidoVenda.ExportToPdf(STRel);
                    new FREL_Preview(STRel).ShowDialog(this);

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, "Não foi possivel imprimir o cupom Detalhes:" + Ex.Message, "Pedido de Venda");
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            EmitirCupomGerencial(Grids.GetValorDec(gridView1, "IDVENDA"));
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var idVenda = IdsSelecionados.FirstOrDefault();
            Imprimir(idVenda, true);
        }

        private void gridView1_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            GridImprimir.FormatarImpressão(ref e);
        }

        private void Imprimir(decimal idVenda, bool visualizar = false)
        {
            var report = GetModeloImpressao(idVenda);


            using (var printTool = new ReportPrintTool(report))
            {
                report.ShowPrintMarginsWarning = report.PrintingSystem.ShowMarginsWarning = false;
                if (visualizar)
                {
                    printTool.ShowPreviewDialog();
                    return;
                }

                if (Confirm("Confirmar impressão?") == DialogResult.Yes)
                    printTool.Print();               
                    
            }
        }

        private XtraReport GetModeloImpressao(decimal idVenda)
        {
            var modeloIndex = FuncoesEmitente.GetEmitente().ModeloImpressaoDAV.ToString();
            var modelo = modelos.Where(m => m.Key == modeloIndex).FirstOrDefault();
            return modelo.Value.Invoke(idVenda);
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {           
            try
            {
                IdsSelecionados.ForEach(i => Imprimir(i));
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
        }
    }
}




