using MetroFramework;
using MetroFramework.Forms;
using Microsoft.VisualBasic.Devices;
using ModelAndroidApp.Controler;
using ModelAndroidApp.ModelAndroid;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.PDV;
using PDV.VIEW.FRENTECAIXA.App_Context;
using PDV.VIEW.FRENTECAIXA.Forms.PDV.Comanda;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Cliente = PDV.DAO.Entidades.Cliente;
using Sequence = PDV.DAO.DB.Utils.Sequence;

namespace PDV.VIEW.FRENTECAIXA.Forms.PDV
{
    public partial class GPDV_CarregarVenda : DevExpress.XtraEditors.XtraForm
    {
        public string NOME_TELA = "CARREGAR VENDA";

        private DataTable DADOS = null;

        public DataRow LinhaSelecionada = null;
        
        #region Dados do Pedido APP
        public DAO.Entidades.PDV.Venda Venda = null;
        public List<ItemVenda> lstItemDeVenda = null;
        public List<DuplicataNFCe> lstPagamentos = null;
        public CONTROLER.Funcoes.FuncoesComanda Comanda = null;
        public Cliente Cliente = null;
        public bool Alteracao = false;
        public decimal IDItemVenda { get; set; }
        #endregion

        public GPDV_CarregarVenda()
        {
            InitializeComponent();
            Width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.70);
            Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.60);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            CarregarVenda();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.F10:
                    CarregarVenda();
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void CarregarVenda()
        {
            LinhaSelecionada = (ovGRD_Comandas.CurrentRow.DataBoundItem as DataRowView).Row;
            DAO.Entidades.PDV.Venda _Venda = FuncoesVenda.GetVenda(Convert.ToDecimal(LinhaSelecionada["IDVENDA"]));

            if (LinhaSelecionada["IDCOMANDA"] != DBNull.Value)
            {
                if (FuncoesItemDuplicataNFCe.ExistePagamentoNaVenda(Convert.ToDecimal(LinhaSelecionada["IDVENDA"])))
                {
                    MessageBox.Show(this, "Comanda está bloqueada.", NOME_TELA);
                    return;
                }

                //if (!AutenticarUsuarioSuperior(_Venda))
                //{
                //    LinhaSelecionada = null;
                //    return;
                //}
                else
                    Close();
            }
            else
            {
                //if (!AutenticarUsuarioSuperior(_Venda))
                //{
                //    LinhaSelecionada = null;
                //    return;
                //}
                //else
                    Close();
            }
        }

        private bool AutenticarUsuarioSuperior(DAO.Entidades.PDV.Venda _Venda)
        {
            if (FuncoesUsuario.GetUsuarioSupervisor(_Venda.IDUsuario).IDUsuario != Contexto.USUARIOLOGADO.IDUsuario)
            {
                if (!_Venda.IDComandaUtilizada.HasValue && _Venda.IDUsuario != Contexto.USUARIOLOGADO.IDUsuario)
                {
                    /* Solicita Pin do usuário superior do usuário logado. */
                    GVEN_PedidoVendaComanda_IdentificarUsuarioSuperior AutenticacaoUser = new GVEN_PedidoVendaComanda_IdentificarUsuarioSuperior();
                    AutenticacaoUser.ShowDialog(this);
                    return AutenticacaoUser.Autenticou;
                }
                else
                    return true;
            }
            else
                return true;
        }


        private void GPDV_CarregarVenda_Load(object sender, EventArgs e)
        {
            Network net = new Network();
            if (net.IsAvailable)
            {
                ImportarPedidoAPP();
            }
            DADOS = FuncoesVenda.GetVendasPDV();
            ovGRD_Comandas.DataSource = DADOS;
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Comandas.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Comandas.Width;
            foreach (DataGridViewColumn column in ovGRD_Comandas.Columns)
            {
                switch (column.Name)
                {
                    case "idvenda":
                        column.DisplayIndex = 1;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
                        column.Width = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "CÓDIGO";
                        break;
                    case "datacadastro":
                        column.DisplayIndex = 2;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
                        column.Width = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "DATA VENDA";
                        break;
                    case "documento":
                        column.DisplayIndex = 3;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
                        column.Width = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "CPF/CNPJ";
                        break;
                    case "usuario":
                        column.DisplayIndex = 4;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
                        column.Width = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "USUÁRIO";
                        break;
                    case "cliente":
                        column.DisplayIndex = 5;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.20);
                        column.Width = Convert.ToInt32(WidthGrid * 0.20);
                        column.HeaderText = "CLIENTE";
                        break;
                    case "comanda":
                        column.DisplayIndex = 6;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.15);
                        column.Width = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "COMANDA";
                        break;
                    case "quantidadeitens":
                        column.DisplayIndex = 7;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
                        column.Width = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "QTD. ITENS";
                        break;
                    case "valortotal":
                        column.DisplayIndex = 8;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.15);
                        column.Width = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "VALOR TOTAL";
                        break;
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }
        }

        public void IniciarVenda()
        {
            lstItemDeVenda = new List<ItemVenda>();
            Venda = new DAO.Entidades.PDV.Venda()
            {
                IDVenda = Sequence.GetNextID("VENDA", "IDVENDA"),
                IDUsuario = 1,
                DataCadastro = DateTime.Now,
                Status = 0,
                IDFluxoCaixa = 0//!string.IsNullOrEmpty(FLUXO.IDFluxoCaixa) ? FLUXO.IDFluxoCaixa : 0,
            };

        }

        private void GPDV_CarregarVenda_Shown(object sender, EventArgs e)
        {
            //ImportarPedidoAPP();
        }

        private void ImportarPedidoAPP()
        {
            try
            {
                List<Nota> lstNota = new List<Nota>();
                List<NotaItem> lstNotaItem = new List<NotaItem>();
                List<Parcela> lstParcelas = new List<Parcela>();
                lstNota = NotaControllerAPP.BuscarNota(false);
                lstNotaItem = NotaControllerAPP.BuscarNotaItem(false);
                lstParcelas = NotaControllerAPP.BuscarParcela(false);

                if (lstNota != null)
                {
                    if (lstNota.Count > 0)
                    {
                        for (int i = 0; i < lstNota.Count; i++)
                        {
                            IniciarVenda();

                            Cliente = FuncoesCliente.GetCliente(lstNota[i].IDCliente);

                            PDVControlador.BeginTransaction();
                            Venda.ValorTotal = decimal.Parse(lstNota[i].TotalPedido.ToString());
                            Venda.IDCliente = null;
                            if (Cliente != null)
                            {
                                Venda.IDCliente = Cliente.IDCliente;
                                if (!FuncoesCliente.SalvarAtualizarClienteNFCe(Cliente.Nome, Cliente.IDCliente, Cliente.Email, Cliente._CPF_CNPJ, Cliente.TipoDocumento))
                                {
                                    throw new Exception("Não foi possível salvar o Cliente.");
                                }
                            }
                            //Objter fluxo de caixa PDV
                            decimal IDFluxo = FuncoesVenda.GetFluxoCaixa();
                            if (IDFluxo != null)
                            {
                                Venda.IDFluxoCaixa = IDFluxo;
                                Venda.IDUsuario = 2;
                                Venda.TipoDeVenda = 1;
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
                            for (int j = 0; j < lstNotaItem.Count; j++)
                            {
                                decimal item = lstItemDeVenda.Count();
                                ItemVenda itemVenda = new ItemVenda()
                                {
                                    Item = item + 1,
                                    CodigoItem = lstNotaItem[j].IDProduto.ToString(),
                                    DescricaoItem = lstNotaItem[j].ProdutoNome,
                                    ValorUnitarioItem = Convert.ToDecimal(lstNotaItem[j].Valor),
                                    Subtotal = (Convert.ToDecimal(lstNotaItem[j].Valor) - lstNotaItem[j].ValorDesconto) * lstNotaItem[j].Quantidade,
                                    IDProduto = Convert.ToDecimal(lstNotaItem[j].IDProduto.ToString()),
                                    IDItemVenda = Sequence.GetNextID("ITEMVENDA", "IDITEMVENDA"),
                                    IDVenda = Venda.IDVenda,
                                    Quantidade = lstNotaItem[j].Quantidade,
                                    DescontoValor = lstNotaItem[j].ValorDesconto,
                                    IDUsuario = decimal.Parse(lstNota[i].IDVendedor.ToString())
                                };
                                lstItemDeVenda.Add(itemVenda);
                                #endregion
                                foreach (ItemVenda Item in lstItemDeVenda)
                                {
                                    if (!FuncoesItemVenda.SalvarItemVenda(Item))
                                    {
                                        throw new Exception("Não foi possível salvar os Itens da Venda.");
                                    }
                                }
                            }

                            PDVControlador.Commit();

                            foreach (var item in lstNota)
                            {
                                NotaControllerAPP.AtualizarStatusNotaImportado(item.ID.ToString());
                            }
                            foreach (var item in lstNotaItem)
                            {
                                NotaControllerAPP.AtualizarStatusNotaItemImportado(item.ID.ToString());
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            ImportarPedidoAPP();
        }
    }
}
