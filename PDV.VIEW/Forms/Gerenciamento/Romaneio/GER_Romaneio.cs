using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Estoque.Movimento;
using PDV.DAO.Entidades.MDFe;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Enum;
using PDV.REPORTS.Reports.Romaneio;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Cadastro.MDFe;
using PDV.VIEW.Forms.Relatorios;
using PDV.VIEW.Forms.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Gerenciamento.Romaneio
{
    public partial class GER_Romaneio : DevExpress.XtraEditors.XtraForm
    {
        Emitente emitente;
        Venda venda;
        Cliente cliente;
        public GER_Romaneio()
        {
            InitializeComponent();
            CarregarCombo();
            emitente = FuncoesEmitente.GetEmitente();
            AtualizarDados();
            CarregarPermissoes();
        }

        private void CarregarPermissoes()
        {
            PermissoesUtil.VerificarPermissaoParaTela(FCA_Transportadora.idsMenuItem, ref buttonAdicionarTransportadora);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_Veiculo.idsMenuItem, ref buttonAdicionarVeiculo);
            PermissoesUtil.VerificarPermissaoParaTela(FCA_Condutor.idsMenuItem, ref buttonAdicionarMotorista);
        }

        public void CarregarCombo()
        {
            try
            {
                //Transportadora
                var Transportadora = FuncoesTransportadora.GetTransportadoras().Select(s => new { Cod = s.IDTransportadora, Nome = s.Nome }).OrderBy(x => x.Cod).ToList();
                transportadoraGridLookUpEdit.Properties.DataSource = Transportadora;
                //Veiculo
                var Veiculo = FuncoesVeiculoMDFe.GetVeiculos().Select(s => new { Cod = s.IDVeiculo, Nome = s.Placa }).OrderBy(x => x.Cod).ToList();
                veiculoGridLookUpEdit.Properties.DataSource = Veiculo;
                //Motorista 
                var Motrosita = FuncoesCondutor.GetCondutoresAtivos().Select(s => new { Cod = s.IDCondutor, Nome = s.Nome }).OrderBy(x => x.Cod).ToList();
                motoristaGridLookUpEdit.Properties.DataSource = Motrosita;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar Romaneio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public List<decimal> idSelecionados;
        private void metroButtonBaixarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (transportadoraGridLookUpEdit.EditValue == "" || motoristaGridLookUpEdit.EditValue == "" || veiculoGridLookUpEdit.EditValue == "")
                {
                    throw new Exception("Informe Transportadora, veiculo e motorista.");
                }

                PDV.DAO.Entidades.Romaneio romaneio = new DAO.Entidades.Romaneio();
                ListaPedidoFaturadoParaCarregamento listaPedidoFaturadoParaCarregamento = new ListaPedidoFaturadoParaCarregamento();
                listaPedidoFaturadoParaCarregamento.ShowDialog();
                idSelecionados = listaPedidoFaturadoParaCarregamento.idSelecionados;
                if (idSelecionados != null)
                {
                    if (idSelecionados.Count > 0)
                    {
                        GerarRomaneio();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro ao salvar Romaneio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        public void AtualizarDados()
        {
            gridControlRomaneio.DataSource = null;
            gridControlRomaneioVendas.DataSource = null;
            DataTable tab = FuncoesRomaneio.GetRomaneios();
            gridControlRomaneio.DataSource = tab;
            gridView1.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            gridView1.OptionsBehavior.Editable = false;
            gridControlRomaneio.ForceInitialize();
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.ShowFooter = true;
            gridView1.BestFitColumns();
            FormatarTabelaRomaneio();
            romaneioItensVendagridControl.DataSource = null;
        }

        private void FormatarTabelaRomaneio()
        {

            Grids.FormatGrid(ref gridViewRomaneio);
            Grids.FormatColumnType(ref gridViewRomaneio, "valortotal", GridFormats.Finance);
        }
        private void FormatarTabelaRomaneioVenda()
        {
            try
            {
                Grids.FormatGrid(ref gridViewRomaneioVendas);
                Grids.FormatColumnType(ref gridViewRomaneioVendas, "valortotal", GridFormats.Finance);
            }
            catch (Exception)
            {
            }

        }

        private void gerarRomaneioButton_Click(object sender, EventArgs e)
        {
            GerarRomaneio();

        }

        private void GerarRomaneio()
        {
            try
            {
                if (transportadoraGridLookUpEdit.EditValue == "" || motoristaGridLookUpEdit.EditValue == "" || veiculoGridLookUpEdit.EditValue == "")
                {
                    throw new Exception("Informe Transportadora, veiculo e motorista.");
                }
                if (MessageBox.Show(this, $"Confirma a geração do romaneio para os {idSelecionados.Count} pedidos selecionados?", "Romaneio", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    PDVControlador.BeginTransaction();
                    if (idSelecionados.Count > 0)
                    {
                        PDV.DAO.Entidades.Romaneio romaneio = new DAO.Entidades.Romaneio();
                        romaneio.IDRomaneio = PDV.DAO.DB.Utils.Sequence.GetNextID("ROMANEIO", "IDROMANEIO");
                        romaneio.Empresa = emitente.NomeFantasia;
                        romaneio.Status = "0";
                        romaneio.DataInclusao = DateTime.Now;
                        romaneio.TransportadoraID = int.Parse(transportadoraGridLookUpEdit.EditValue.ToString());
                        romaneio.TransportadoraNome = transportadoraGridLookUpEdit.Text;
                        romaneio.VeiculoID = int.Parse(veiculoGridLookUpEdit.EditValue.ToString());
                        romaneio.VeiculoDescricao = veiculoGridLookUpEdit.Text;
                        romaneio.MotoristaNome = motoristaGridLookUpEdit.Text;
                        romaneio.MotoristaID = int.Parse(motoristaGridLookUpEdit.EditValue.ToString());
                        romaneio.Observacao = "";
                        romaneio.IDUsuario = 0;
                        decimal totalvenda = 0;
                        int quantidadeItensVenda = 0;
                        foreach (var item in idSelecionados)
                        {
                            venda = FuncoesVenda.GetVenda(item);
                            cliente = FuncoesCliente.GetCliente(venda.IDCliente);
                            var Itens = FuncoesItemVenda.GetItensVenda(venda.IDVenda);
                            quantidadeItensVenda += Itens.Count;
                            RomaneioVenda romaneioVenda = new RomaneioVenda();
                            romaneioVenda.IDRomaneioVenda = PDV.DAO.DB.Utils.Sequence.GetNextID("ROMANEIOVENDA", "IDROMANEIOVENDA");
                            romaneioVenda.DataFaturamento = venda.DataFaturamento;
                            romaneioVenda.IDRomaneio = romaneio.IDRomaneio;
                            romaneioVenda.IDVenda = venda.IDVenda;
                            romaneioVenda.Cliente = cliente.NomeFantasia ?? cliente.Nome;
                            romaneioVenda.ValorTotal = venda.ValorTotal;
                            romaneioVenda.TotalItens = quantidadeItensVenda;
                            romaneioVenda.Observacao = venda.Observacao;
                            romaneioVenda.Status = 0;
                            totalvenda += venda.ValorTotal;
                            FuncoesRomaneio.SalvarRomaneioItens(romaneioVenda);
                            FuncoesVenda.AtualizarRomaneio(venda.IDVenda, romaneio.IDRomaneio);
                        }
                        romaneio.TotalItens = quantidadeItensVenda;
                        romaneio.ValorTotal = totalvenda;
                        FuncoesRomaneio.SalvarRomaneio(romaneio);
                        PDVControlador.Commit();
                        transportadoraGridLookUpEdit.EditValue = null;
                        motoristaGridLookUpEdit.EditValue = null;
                        veiculoGridLookUpEdit.EditValue = null;
                        AtualizarDados();
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        PDVControlador.Rollback();
                        Cursor.Current = Cursors.Default;
                        throw new Exception("Clique em localizar para escolher os pedidos que vão ser inseridos no romaneio.");
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                PDVControlador.Rollback();
                MessageBox.Show(ex.Message, "Erro ao salvar Romaneio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public decimal idRomaneio { get; set; }

        private void gridViewRomaneio_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            tabControl1.SelectedIndex = 0;
            decimal id = Convert.ToInt16(gridViewRomaneio.GetRowCellValue(gridViewRomaneio.FocusedRowHandle, gridViewRomaneio.Columns[0].FieldName));
            idRomaneio = id;
            AtualizarRomaneioVenda(id);
            //0-Aberto 1-Fechado 2-Cancelado 3 Entregue
            string status = "";
            try
            {
                status = gridViewRomaneio.GetRowCellValue(gridViewRomaneio.FocusedRowHandle, "status").ToString();
            }
            catch (Exception)
            {

            }

            if (status == "CANCELADO")
            {
                imprimirSimpleButton.Enabled = false;
                cancelarSimpleButton.Enabled = false;
                entregueSimpleButton.Enabled = false;
                exclirSimpleButton.Enabled = false;

            }
            else if (status == "ABERTO")
            {
                imprimirSimpleButton.Enabled = true;
                cancelarSimpleButton.Enabled = false;
                entregueSimpleButton.Enabled = true;
                exclirSimpleButton.Enabled = true;

            }
            else if (status == "ENTREGUE")
            {
                exclirSimpleButton.Enabled = false;
                imprimirSimpleButton.Enabled = true;
                cancelarSimpleButton.Enabled = true;
                entregueSimpleButton.Enabled = false;
            }

            Cursor.Current = Cursors.Default;
        }

        private void AtualizarRomaneioVenda(decimal id)
        {
            gridControlRomaneioVendas.DataSource = FuncoesRomaneio.GetRomaneiosVendas(id);
            gridViewRomaneioVendas.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            gridViewRomaneioVendas.OptionsBehavior.Editable = false;
            gridControlRomaneioVendas.ForceInitialize();
            gridViewRomaneioVendas.OptionsView.ColumnAutoWidth = false;
            gridViewRomaneioVendas.OptionsView.ShowAutoFilterRow = true;
            gridViewRomaneioVendas.OptionsView.ShowFooter = true;
            gridViewRomaneioVendas.BestFitColumns();
            FormatarTabelaRomaneioVenda();
        }

        private void RomaneioVendaGridView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                tabControl1.SelectedIndex = 1;
                var id = Grids.GetValorInt(gridViewRomaneioVendas, "idvenda");
                var itemVenda = FuncoesItemVenda.GetItensVenda(id);
                romaneioItensVendagridControl.DataSource = itemVenda;
                romaneioItemVendagridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;
                romaneioItemVendagridView.OptionsBehavior.Editable = false;
                romaneioItensVendagridControl.ForceInitialize();
                romaneioItemVendagridView.OptionsView.ColumnAutoWidth = false;
                romaneioItemVendagridView.OptionsView.ShowAutoFilterRow = true;
                romaneioItemVendagridView.OptionsView.ShowFooter = true;
                romaneioItemVendagridView.BestFitColumns();

                Grids.FormatGrid(ref romaneioItemVendagridView);
                Grids.FormatColumnType(ref romaneioItemVendagridView, new List<string>()
                {
                    "valortotalitem", "valorunitarioitem", "descontovalor"
                }, GridFormats.Finance);


                Cursor.Current = Cursors.Default;
            }
            catch (ArgumentOutOfRangeException)
            {

               
            }
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            AtualizarDados();
            Cursor.Current = Cursors.Default;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (idRomaneio > 0)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    ImpressaoRomaneio Rep = new ImpressaoRomaneio(idRomaneio);
                    Stream STRel = new MemoryStream();
                    Rep.ExportToPdf(STRel);
                    new FREL_Preview(STRel).ShowDialog(this);
                    imprimirSimpleButton.Enabled = false;
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(this, ex.Message.ToString(), "DAV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                imprimirSimpleButton.Enabled = false;
            }
        }

        private void cancelarSimpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, $"Confirma o cancelmamento ?", "Romaneio", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    FuncoesRomaneio.RomaneioStatus(idRomaneio, 2);
                    cancelarSimpleButton.Enabled = false;
                    AtualizarDados();
                    Cursor.Current = Cursors.Default;
                }

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(this, ex.Message.ToString(), "DAV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void entregueSimpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, $"Confirma a entrega ?", "Romaneio", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    FuncoesRomaneio.RomaneioStatus(idRomaneio, 3);
                    entregueSimpleButton.Enabled = false;
                    AtualizarDados();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "DAV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void exclirSimpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, $"Confirma a exclusão ?", "Romaneio", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    FuncoesRomaneio.Excluir(idRomaneio);
                    exclirSimpleButton.Enabled = false;
                    AtualizarDados();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "DAV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gridViewRomaneio_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView currentView = sender as GridView;
            if (e.Column.FieldName == "status")
            {
                string valor;
                try
                {
                    var cellValue = gridView1.GetRowCellValue(e.RowHandle, "status");
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
                    case "ENTREGUE":
                        e.Appearance.ForeColor = Color.Green;
                        break;
                    case "CANCELADO":
                        e.Appearance.ForeColor = Color.Red;
                        break;
                    case "ABERTO":
                        e.Appearance.ForeColor = Color.Blue;
                        break;

                    case "APP":
                        e.Appearance.ForeColor = Color.Blue;
                        e.Appearance.BackColor = Color.Yellow;
                        break;
                }
            }
        }

        private void buttonAdicionarTransportadora_Click(object sender, EventArgs e)
        {
            new FCA_Transportadora(new Transportadora()).ShowDialog();
            CarregarCombo();
        }

        private void gridViewRomaneioVendas_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView currentView = sender as GridView;
            if (e.Column.FieldName == "status")
            {
                string valor;
                try
                {
                    var cellValue = gridView1.GetRowCellValue(e.RowHandle, "status");
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
                    case "ENTREGUE":
                        e.Appearance.ForeColor = Color.Green;
                        break;
                    case "CANCELADO":
                        e.Appearance.ForeColor = Color.Red;
                        break;
                    case "ABERTO":
                        e.Appearance.ForeColor = Color.Blue;
                        break;

                    case "APP":
                        e.Appearance.ForeColor = Color.Blue;
                        e.Appearance.BackColor = Color.Yellow;
                        break;
                }

            }
        }

        private void cancelarRomaneioVendaSimpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Confirmar o cancelamento das vendas selecionadas? da venda selecionada?", "Romaneio", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string motivo = XtraInputBox.Show("Informe o motivo do cancelamento", "Cancelar Venda", "");
                    ArrayList rows = new ArrayList();
                    Int32[] selectedRowHandles = gridViewRomaneioVendas.GetSelectedRows();
                    for (int i = 0; i < selectedRowHandles.Length; i++)
                    {
                        int selectedRowHandle = selectedRowHandles[i];
                        if (selectedRowHandle >= 0)
                            rows.Add(gridViewRomaneioVendas.GetDataRow(selectedRowHandle));

                        DataRow row = rows[i] as DataRow;
                        var ID = row[0].ToString();
                        var IDRomaneio = row[2].ToString();
                        var IDVenda = row[3].ToString();

                        if (ID != null)
                        {
                            PDVControlador.BeginTransaction();
                            FuncoesRomaneio.AtualizarStatusRomaneioVenda(decimal.Parse(ID.ToString()), 2);

                            Venda Venda = FuncoesVenda.GetVenda(decimal.Parse(IDVenda.ToString()));
                            TipoDeOperacao tipoDeOperacao = FuncoesTipoDeOperacao.GetTipoDeOperacao(Venda.IDTipoDeOperacao);

                            AtualizarRomaneioVenda(decimal.Parse(IDRomaneio.ToString()));

                            if (!FuncoesVenda.MudarStatus(Venda.IDVenda, StatusPedido.Cancelado, motivo))
                                throw new Exception($"Cancelar a Venda {Venda.IDVenda}.");


                            if (!FuncoesContaReceber.CancelarContaReceberDocumento(Venda.IDVenda, Contexto.USUARIOLOGADO))
                                throw new Exception($"Não foi possível salvar as contas a receber da Venda {Venda.IDVenda}.");

                            var itemVenda = FuncoesItemVenda.GetItensVenda(Venda.IDVenda);

                            foreach (ItemVenda Item in itemVenda)
                            {
                                if (!FuncoesItemVenda.SalvarItemVenda(Item))
                                {
                                    throw new Exception($"Não foi possível salvar os Itens de Venda da Venda {Venda.IDVenda}.");
                                }
                                if (tipoDeOperacao.ControlarEstoque)
                                {
                                    // [Processar Movimento de Estoque]
                                    if (!FuncoesMovimentoEstoque.Salvar(new MovimentoEstoque
                                    {
                                        IDMovimentoEstoque = PDV.DAO.DB.Utils.Sequence.GetNextID("MOVIMENTOESTOQUE", "IDMOVIMENTOESTOQUE"),
                                        DataMovimento = DateTime.Now,
                                        IDAlmoxarifado = FuncoesProduto.GetProduto(Item.IDProduto).IDAlmoxarifadoEntrada,
                                        IDItemVenda = Item.IDItemVenda,
                                        IDProduto = Item.IDProduto,
                                        Quantidade = Item.Quantidade,
                                        Tipo = 0,
                                        Descricao = "Cancelamento de Venda",
                                        IDItemInventario = null,
                                        IDItemNFeEntrada = null,
                                        IDItemTransferenciaEstoque = null,
                                        IDProdutoNFe = null
                                    }))
                                    {
                                        throw new Exception($"Não foi possível salvar o Movimento de Estoque da Venda {Venda.IDVenda}.");
                                    }
                                }
                            }
                        }

                        PDVControlador.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "DAV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PDVControlador.Rollback();
            }
        }

        private void entregarRomaneioVendaSimpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList rows = new ArrayList();
                Int32[] selectedRowHandles = gridViewRomaneioVendas.GetSelectedRows();
                for (int i = 0; i < selectedRowHandles.Length; i++)
                {
                    int selectedRowHandle = selectedRowHandles[i];
                    if (selectedRowHandle >= 0)
                        rows.Add(gridViewRomaneioVendas.GetDataRow(selectedRowHandle));

                    DataRow row = rows[i] as DataRow;
                    var ID = row[0].ToString();
                    var IDRomaneio = row[2].ToString();

                    if (ID != null)
                    {
                        FuncoesRomaneio.AtualizarStatusRomaneioVenda(decimal.Parse(ID.ToString()), 1);
                        AtualizarRomaneioVenda(decimal.Parse(IDRomaneio.ToString()));
                        cancelarRomaneioVendaSimpleButton.Enabled = false;
                        entregarRomaneioVendaSimpleButton.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "DAV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridViewRomaneioVendas_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            tabControl1.SelectedIndex = 0;

            decimal id = -1;

            try
            {
                id = Convert.ToInt16(gridViewRomaneioVendas.GetRowCellValue(gridViewRomaneioVendas.FocusedRowHandle, gridViewRomaneioVendas.Columns[0].FieldName));
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            idRomaneio = id;
            
            //0-Aberto 1-Fechado 2-Cancelado 3 Entregue
            string status = "";
            try
            {
                status = gridViewRomaneioVendas.GetRowCellValue(gridViewRomaneioVendas.FocusedRowHandle, "status").ToString();
            }
            catch (Exception)
            {

            }

            if (status == "CANCELADO")
            {
                cancelarRomaneioVendaSimpleButton.Enabled = false;
                entregarRomaneioVendaSimpleButton.Enabled = false;

            }
            else if (status == "ABERTO")
            {
                cancelarRomaneioVendaSimpleButton.Enabled = true;
                entregarRomaneioVendaSimpleButton.Enabled = true;

            }
            else if (status == "ENTREGUE")
            {
                cancelarRomaneioVendaSimpleButton.Enabled = true;
                entregarRomaneioVendaSimpleButton.Enabled = false;
            }

            Cursor.Current = Cursors.Default;
        }

        private void buttonAdicionarVeiculo_Click(object sender, EventArgs e)
        {
            new FCA_Veiculo(new Veiculo()).ShowDialog();
            CarregarCombo();
        }

        private void buttonAdicionarMotorista_Click(object sender, EventArgs e)
        {
            new FCA_Condutor(new Condutor()).ShowDialog();
            CarregarCombo();
        }
    }
}






