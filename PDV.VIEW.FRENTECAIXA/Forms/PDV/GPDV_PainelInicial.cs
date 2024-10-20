using ACBr.Net.Core.Extensions;
using DevExpress.DataProcessing;
using PDV.CONTROLER.Funcoes;
using PDV.DAO;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.PDV;
using PDV.UTIL;
using PDV.UTIL.FORMS;
using PDV.UTIL.FORMS.Forms.Caixa;
using PDV.VIEW.Forms.Consultas;
using PDV.VIEW.Forms.Consultas.Financeiro.Modulo;
using PDV.VIEW.Forms.Gerenciamento;
using PDV.VIEW.FRENTECAIXA.App_Context;
using PDV.VIEW.FRENTECAIXA.Forms.MataFome;
using PDV.VIEW.FRENTECAIXA.Forms.PDV;
using PDV.VIEW.FRENTECAIXA.Forms.PDV.Menu;
using PDV.VIEW.FRENTECAIXA.Forms.Seletores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Ports;
using System.Text;
using DevExpress.Utils.Extensions;
//Rodrigo
//Renato
//Leandro
namespace PDV.VIEW.FRENTECAIXA.Forms {
    public partial class GPDV_PainelInicial : Form 
    {
        public Caixa Caixa;
        private bool AlterouPreco = false;
        private string NOME_TELA = "Informação do RootSys";
        private int WidthGrid = 0;
        public int TipoVenda = 0;
        public int TipoFiscal = 0;
        public string EANEmpresa = "";
        /* Variáveis da Venda. */
        private FluxoCaixa FLUXO = null;
        public DAO.Entidades.PDV.Venda VENDA = null;
        public BindingList<ItemVenda> ITENS_VENDA { get; set; }
        public List<DuplicataNFCe> PAGAMENTOS = null;
        public Comanda Comanda = null;
        List<Produto> lstProduto = new List<Produto>();
        List<Categoria> lstCategoria = new List<Categoria>();
        List<Comanda> lstComanda = new List<Comanda>();

        Configuracao digitoVerificadorBalanca = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CONFIGURACAO_BALANCA_RETAGUARDA_DIGITO_VERIFICADOR);
        Configuracao qtdeDigitosBalanca = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CONFIGURACAO_BALANCA_RETAGUARDA_QTD_DIGITOS);
        Configuracao infEtiquetaBalanca = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CONFIGURACAO_BALANCA_RETAGUARDA_INFORMACAO_ETIQUETA);


    public Cliente Cliente = null;
        private static bool PortaAberta = false;
        private bool pesoRecebido = false;
        private string RxString = string.Empty;
        private bool pesoestavel = false;
        private decimal decRxString = 0m;

        private decimal IdCategoria { get; set; }

        public ProdutoPDV ProdutoPDV { get; set; }

        //public string CodigoDeBarras {
        //    get => ovTXTCodigoProduto.Text.Trim();
        //    set => ovTXTCodigoProduto.Text = value ?? string.Empty;
        //}

        public decimal Quantidade {
            set => ovTXT_Quantidade.Text = value.ToString();
            get {
                try {
                    if (string.IsNullOrEmpty(ovTXT_Quantidade.Text.Trim()))
                        return Quantidade = 0;

                    return Convert.ToDecimal(ovTXT_Quantidade.Text);
                } catch (FormatException) {
                    try {
                        char[] carateresValidos = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                        ovTXT_Quantidade.Text = RemoverCaracteresInvalidos(ovTXT_Quantidade.Text, carateresValidos);
                        return Convert.ToDecimal(ovTXT_Quantidade.Text);
                    } catch (FormatException) {
                        return 0;
                    }
                }
            }
        }

        public decimal ValorUnitario {
            set => ovTXT_ValorUnitario.Text = Math.Round(value, 2).ToString("n2");
            get {
                try {
                    if (string.IsNullOrEmpty(ovTXT_ValorUnitario.Text.Trim()))
                        return ValorUnitario = 0;
                    return Convert.ToDecimal(ovTXT_ValorUnitario.Text);
                } catch (FormatException) {
                    try {
                        char[] carateresValidos = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',' };
                        ovTXT_ValorUnitario.Text = RemoverCaracteresInvalidos(ovTXT_ValorUnitario.Text, carateresValidos);
                        return Convert.ToDecimal(ovTXT_ValorUnitario.Text);
                    } catch (FormatException) {
                        return 0;
                    }
                }
            }
        }

        public decimal SubTotal {
            set => ovTXT_SubTotal.Text = Math.Round(value, 2).ToString("n2");
            get {
                try {
                    return Convert.ToDecimal(ovTXT_SubTotal.Text);
                } catch (FormatException) {
                    return 0;
                }
            }
        }

        public decimal QuantidadeItens {
            set => ovTXT_QuantidadeItens.Text = value.ToString("n3");
            get {
                try {
                    return Convert.ToInt32(ovTXT_QuantidadeItens.Text);
                } catch (FormatException) {
                    return 0;
                }
            }
        }

        public decimal TotalVenda {
            set => ovTXT_TotalVenda.Text = Math.Round(value, 2).ToString("n2");
            get {
                try {
                    return Convert.ToDecimal(ovTXT_TotalVenda.Text);
                } catch (FormatException) {
                    return 0;
                }
            }
        }

        private class ValoresPortaBalanca {
            public string Porta { get; private set; } //COM2
            public string BaudRate { get; private set; } //9600
            public int DataBits { get; private set; } //8 Bits
            public int Paridade { get; private set; } //Nenhum
            public string ArquivoSinalizacao { get; private set; }
            public IniFile iniFile = null;

            public ValoresPortaBalanca() {
                const string conexaoPDV = "Conexao_PDV";
                iniFile = new IniFile(ContextoUtil.CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW\\App_Data\\Start.ini" : "\\App_Data\\Start.ini"));
                Porta = iniFile.GetValue(conexaoPDV, "portaimpressora");
                BaudRate = iniFile.GetValue(conexaoPDV, "baudrate");
                DataBits = Convert.ToInt32(iniFile.GetValue(conexaoPDV, "databits"));
                Paridade = Convert.ToInt32(iniFile.GetValue(conexaoPDV, "paridade"));
                ArquivoSinalizacao = iniFile.GetValue(conexaoPDV, "arquivosinalizacao");
            }
        }





        public GPDV_PainelInicial() {
            InitializeComponent(); ;
        }

        public void ObterPesoToledo() {
            try {
                AbrirPortaSerial();
                if (serialPort1.IsOpen) {
                    SolicitarPesoDaBalanca();
                    if (ReceberDadosBalanca()) {
                        pesoRecebido = true;
                    }
                }
                fecharaporta();
            } catch (Exception) {
                throw;// new Exception("ObterPesoToledo()");
            }
        }

        private void AbrirPortaSerial() {
            var valoresBalanca = new ValoresPortaBalanca();
            try {
                serialPort1.PortName = valoresBalanca.Porta;
                serialPort1.BaudRate = Convert.ToInt32(valoresBalanca.BaudRate);
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
                serialPort1.DtrEnable = true;
                serialPort1.StopBits = StopBits.One;
                serialPort1.NewLine = "vbCr";
                serialPort1.ReadTimeout = 500;
                serialPort1.WriteTimeout = 500;
                serialPort1.DtrEnable = true;
                serialPort1.RtsEnable = true;
                serialPort1.Encoding = System.Text.Encoding.ASCII;
                serialPort1.Handshake = System.IO.Ports.Handshake.None;
                serialPort1.Open();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message,
                     Application.CompanyName,
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Warning);
            }
        }
        private void fecharaporta() {
            try {
                if (serialPort1.IsOpen) {
                    serialPort1.Close();
                }
            } catch (Exception) {

                throw new Exception("fecharaporta()");
            }
        }

        private void SolicitarPesoDaBalanca() {
            try {
                if (!serialPort1.IsOpen) return;
                char[] buff = new char[1];
                buff[0] = (char)5;
                serialPort1.Write(buff, 0, 1);
                System.Threading.Thread.Sleep(1000);
            } catch (Exception) {
                throw new Exception("SolicitarPesoDaBalanca()");
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) {

        }

        private bool ReceberDadosBalanca() {
            try {
                RxString = serialPort1.ReadExisting();
                RxString = RxString.Replace("\x02", "");
                RxString = RxString.Replace("\x03", "");
                RxString = RxString.Replace("00.", "0.");
                RxString = RxString.Replace(".", ",");
                bool result;
                result = Char.IsLetter(RxString, 0);
                if (!result) {
                    decRxString = Convert.ToDecimal(RxString) / 1000;
                    RxString = string.Empty;
                    return true;
                }
                return false;
            } catch (Exception) {
                return false;
                throw new Exception("ReceberDadosBalanca()");
            }
        }

        public void TextBox(string value) {
            if (InvokeRequired) {
                this.Invoke(new Action<string>(TextBox), new object[] { value });
                return;
            }
            ovTXT_Quantidade.Text = value;
        }

        public static string ListaBytesParaString(byte[] lista) {
            char[] retornoChar = new char[lista.Length];
            for (int i = 0; i < lista.Length; i++)
                retornoChar[i] = (char)lista[i];
            string retorno = new string(retornoChar);
            return retorno;
        }

        private void InserirFooter() {
            string IPMaquina = "127.0.0.1";
            IPAddress[] ip = Dns.GetHostAddresses(Dns.GetHostName());
            if (ip != null) {
                IPAddress Ip = ip.Where(o => o.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault();
                if (Ip != null) {
                    IPMaquina = Ip.ToString();
                }
            }
            //ovTXT_FooterIP.Text = string.Format("[IP]: {0}", IPMaquina);
        }

        private void InserirCabecalhoNota() {
            Emitente _Emitente = FuncoesEmitente.GetEmitente();
            ovTXT_CNPJEmitente.Text = Convert.ToUInt64(_Emitente.CNPJ).ToString(@"00\.000\.000\/0000\-00");
            //  ovTXT_NomeFantasia.Text = _Emitente.NomeFantasia;
            ovTXT_Titulo.Text = _Emitente.NomeFantasia;
            if (_Emitente.Logomarca != null) {
                using (var ms = new MemoryStream(_Emitente.Logomarca))
                    logoEmpresaPictureBox.Image = Image.FromStream(ms);
            }
            if (_Emitente.logopropraganda != null) {
                using (var ms = new MemoryStream(_Emitente.logopropraganda))
                    pictureBoxPropraganda.Image = Image.FromStream(ms);
            }
        }

        public void CarregarVendaComanda(decimal IDVenda, decimal? IDComanda, decimal? IDCliente) {
            VENDA = FuncoesVenda.GetVenda(IDVenda);
            VENDA.IDFluxoCaixa = FLUXO.IDFluxoCaixa; //teste fluxo caixa para atualizar o fluxo de caixa para o atual quando carregar
            ITENS_VENDA = FuncoesItemVenda.GetItensVenda(IDVenda).ToBindingList();
            InitBindings();
            AtualizarQuantidadeItensESubTotalVenda();
            if (IDComanda != null) {
                Comanda = FuncoesComanda.GetComanda(IDComanda);
                //ovTXT_Comanda.Text = Comanda.Descricao;
            }

            if (IDCliente != null) {
                Cliente = FuncoesCliente.GetCliente(IDCliente);
                ovTXT_Cliente.Text = Cliente._CPF_CNPJ;
            }

            /*   if (MessageBox.Show(this, "Deseja encerrar a conta ?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                   ChamarFinalizarVenda();
               } else {
                   SalvarPreVenda();
               }*/



            DialogResult result = MessageBox.Show("Deseja encerrar a conta ?", NOME_TELA,
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes) {
                ChamarFinalizarVenda();
            } else if (result == DialogResult.No) {
                SalvarPreVenda();
            } else if (result == DialogResult.Cancel) {
                //code for Cancel
            }
        }

        public void carregarPanelComanda() {
            try {
                lstComanda = FuncoesComanda.GetComandaLista();
                painelFlutuanteMain.AutoScroll = true;
                painelFlutuanteMain.Controls.Clear();
                ovTXT_CodigoBarrasProduto.Select();
                ovTXT_CodigoBarrasProduto.SelectAll();

                foreach (var item in lstComanda) {
                    var imagem = new PictureBox();
                    var btnComanda = new Button();
                    var flwPanelItems = new FlowLayoutPanel();
                    flwPanelItems.Size = new System.Drawing.Size(110, 105);
                    flwPanelItems.BackColor = Color.White;
                    // flwPanelItems.BorderStyle = BorderStyle.Fixed3D;
                    flwPanelItems.FlowDirection = FlowDirection.TopDown;

                    if (item.Descricao.ToString().Length >= 30) {
                        btnComanda.Text = item.Descricao.ToString().Substring(0, 30);
                    } else {
                        btnComanda.Text = item.Descricao.ToString();
                    }
                    btnComanda.Name = item.Codigo.ToString();
                    if (item.Status)
                        imagem.Image = global::PDV.VIEW.FRENTECAIXA.Properties.Resources.mesa_ocupdaNew2;
                    else
                        imagem.Image = global::PDV.VIEW.FRENTECAIXA.Properties.Resources.mesa_livreNew2;

                    imagem.SizeMode = PictureBoxSizeMode.Zoom;
                    //}
                    //Texto
                    btnComanda.Font = new Font("Arial", 7, FontStyle.Bold);
                    btnComanda.BackColor = Color.White;
                    btnComanda.ForeColor = Color.Black;
                    btnComanda.TextAlign = ContentAlignment.TopCenter;
                    btnComanda.Text.ToUpper();

                    //Enventos 
                    btnComanda.Click += btnComanda_Click;
                    btnComanda.Width = 98;
                    btnComanda.Height = 35;
                    imagem.BackColor = Color.Transparent;
                    imagem.ForeColor = Color.Black;
                    //Enventos 
                    imagem.Width = 98;
                    imagem.Height = 50;
                    //Adicionando ao controle flowPanels Unitários
                    flwPanelItems.Controls.Add(imagem);
                    flwPanelItems.Controls.Add(btnComanda);
                    painelFlutuanteMain.Controls.Add(flwPanelItems);
                }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "RootSys ERP", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        //public void carregarPanelCoupomVenda(List<ItemVenda> ListaItemVenda, string Unidade)
        //{
        //    try
        //    {
        //        cupomVendaFlowLayoutPanel.AutoScroll = true;

        //        cupomVendaFlowLayoutPanel.Controls.Clear();
        //        cupomVendaFlowLayoutPanel.Update();

        //        foreach (var item in ListaItemVenda)
        //        {
        //            var DescricaoItemLabel = new Label();
        //            var flwPanelItems = new FlowLayoutPanel();
        //            flwPanelItems.Size = new System.Drawing.Size(555, 50);
        //            flwPanelItems.BackColor = Color.White;
        //            flwPanelItems.FlowDirection = FlowDirection.TopDown;
        //            flwPanelItems.BorderStyle = BorderStyle.FixedSingle;

        //            String Item = $"{item.DescricaoItem.ToUpper()} {Environment.NewLine}" +
        //                          $"  {item.Quantidade} {Unidade.ToUpper()}   X    {item.ValorUnitarioItem.ToString("C")}  =   {item.ValorTotalItem.ToString("C")}";

        //            //Descrição
        //            DescricaoItemLabel.Text = Item;
        //            DescricaoItemLabel.Size = new System.Drawing.Size(550, 49);
        //            DescricaoItemLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left)));
        //            DescricaoItemLabel.Font = new System.Drawing.Font("Tahoma", 12, System.Drawing.FontStyle.Regular);
        //            DescricaoItemLabel.TextAlign = ContentAlignment.TopCenter;
        //            DescricaoItemLabel.ForeColor = Color.MidnightBlue;
        //            //Adicionando ao controle flowPanels Unitários
        //            flwPanelItems.Controls.Add(DescricaoItemLabel);
        //            cupomVendaFlowLayoutPanel.Controls.Add(flwPanelItems);
        //            ovTXT_Quantidade.Text = "1";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "One PDV EVO", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        //    }
        //}

        private void btnComanda_Click(object sender, EventArgs e) {
            Button btnComanda = sender as Button;
            Comanda = FuncoesComanda.GetComanda(decimal.Parse(btnComanda.Name));
            if (Comanda != null) {
                labelComanda.Visible = true;
                labelComanda.Text = "COMANDA " + Comanda.Descricao + " SELECIONADA!";
                VENDA.IDComanda = Comanda.IDComanda;
                DAO.Entidades.PDV.Venda venda = FuncoesVenda.GetVendaComandaAberta(decimal.Parse(btnComanda.Name));
                if (venda != null) {
                    CarregarVendaComanda(venda.IDVenda, venda.IDComanda, venda.IDCliente);
                    CarregarPainelCategorias();
                }
                CarregarPainelCategorias();
            }
        }

        public void CarregarPainelProdutos(string pesquisa = "", bool mudarEventHandler = true) {

            try {
                if (Caixa.TipoPDV == Caixa.Mercado)
                    return;

                if (mudarEventHandler) {
                    tbxPesquisar.KeyUp -= new KeyEventHandler(tbxPesquisarCategoria_KeyUp);
                    tbxPesquisar.KeyUp += new KeyEventHandler(tbxPesquisarProduto_KeyUp);
                }

                lstProduto = FuncoesProduto.GetProdutoLista()
                    .Where(p => p.ParaVender)
                    .Where(x => x.IDCategoria == IdCategoria)
                    .ToList();

                if (pesquisa != "")
                    lstProduto = lstProduto
                        .Where(p => p.Descricao.ToLower().Contains(pesquisa.ToLower()))
                        .ToList();

                painelFlutuanteMain.AutoScroll = true;
                painelFlutuanteMain.Controls.Clear();

                foreach (var item in lstProduto) {
                    var imagem = new PictureBox();
                    var btnProdutos = new Button();
                    var flwPanelItems = new FlowLayoutPanel();
                    flwPanelItems.Size = new System.Drawing.Size(110, 105);
                    flwPanelItems.BackColor = Color.White;
                    // flwPanelItems.BorderStyle = BorderStyle.Fixed3D;
                    flwPanelItems.FlowDirection = FlowDirection.TopDown;

                    if (item.Descricao.ToString().Length >= 30) {
                        btnProdutos.Text = item.Descricao.ToString().Substring(0, 30);
                    } else {
                        btnProdutos.Text = item.Descricao.ToString();
                    }
                    btnProdutos.Name = item.Codigo.ToString();

                    if (item.ImagemProduto != null) {
                        byte[] data0 = (byte[])item.ImagemProduto;
                        MemoryStream ms0 = new MemoryStream(data0);
                        System.Drawing.Image bitMap = System.Drawing.Image.FromStream(ms0);
                        imagem.SizeMode = PictureBoxSizeMode.StretchImage;
                        imagem.Image = Image.FromStream(ms0);
                        imagem.BorderStyle = BorderStyle.None;
                    } else {
                        // imagem.BackgroundImage = global::One.Loja.Properties.Resources.semfoto;
                        imagem.BackgroundImageLayout = ImageLayout.Center;
                    }
                    //Texto
                    btnProdutos.Font = new Font("Arial", 7, FontStyle.Bold);
                    btnProdutos.BackColor = Color.White;
                    btnProdutos.ForeColor = Color.Black;
                    btnProdutos.TextAlign = ContentAlignment.TopCenter;
                    btnProdutos.Text.ToUpper();

                    //Enventos 
                    btnProdutos.Click += btnProdutos_Click;
                    btnProdutos.MouseHover += new System.EventHandler(this.btnProdutosVer_MouseHover);
                    btnProdutos.Width = 98;
                    btnProdutos.Height = 35;
                    imagem.BackColor = Color.Transparent;
                    imagem.ForeColor = Color.Black;
                    //Enventos 
                    imagem.Width = 98;
                    imagem.Height = 50;
                    //Adicionando ao controle flowPanels Unitários
                    flwPanelItems.Controls.Add(imagem);
                    flwPanelItems.Controls.Add(btnProdutos);
                    painelFlutuanteMain.Controls.Add(flwPanelItems);
                }

            } catch (Exception ex) {
                Alert(ex.Message);
            }
        }

        public void CarregarPainelCategorias(string pesquisaCategoria = "", bool mudarEventHandler = true) {

            try {
                if (Caixa.TipoPDV == Caixa.Mercado)
                    return;

                if (mudarEventHandler) {
                    tbxPesquisar.KeyUp -= new KeyEventHandler(tbxPesquisarProduto_KeyUp);
                    tbxPesquisar.KeyUp += new KeyEventHandler(tbxPesquisarCategoria_KeyUp);
                }

                lstCategoria = FuncoesCategoria.GetCategoriasParaVender();

                if (pesquisaCategoria != "")
                    lstCategoria = lstCategoria
                        .Where(c => c.Descricao.ToLower().Contains(pesquisaCategoria.ToLower())).ToList();

                painelFlutuanteMain.AutoScroll = true;
                painelFlutuanteMain.Controls.Clear();

                foreach (var item in lstCategoria) {
                    var imagem = new PictureBox();
                    var btnCategoria = new Button();
                    var flwPanelItems = new FlowLayoutPanel();
                    flwPanelItems.Size = new System.Drawing.Size(110, 105);
                    flwPanelItems.BackColor = Color.White;
                    // flwPanelItems.BorderStyle = BorderStyle.Fixed3D;
                    flwPanelItems.FlowDirection = FlowDirection.TopDown;

                    if (item.Descricao.ToString().Length >= 30) {
                        btnCategoria.Text = item.Descricao.ToString().Substring(0, 30);
                    } else {
                        btnCategoria.Text = item.Descricao.ToString();
                    }
                    btnCategoria.Name = item.IDCategoria.ToString();

                    if (item.Imagem != null) {
                        byte[] data0 = (byte[])item.Imagem;
                        MemoryStream ms0 = new MemoryStream(data0);
                        System.Drawing.Image bitMap = System.Drawing.Image.FromStream(ms0);
                        imagem.SizeMode = PictureBoxSizeMode.StretchImage;
                        imagem.Image = Image.FromStream(ms0);
                        imagem.BorderStyle = BorderStyle.None;
                    } else {
                        // imagem.BackgroundImage = global::One.Loja.Properties.Resources.semfoto;
                        imagem.BackgroundImageLayout = ImageLayout.Center;
                    }
                    //Texto
                    btnCategoria.Font = new Font("Arial", 7, FontStyle.Bold);
                    btnCategoria.BackColor = Color.White;
                    btnCategoria.ForeColor = Color.Black;
                    btnCategoria.TextAlign = ContentAlignment.TopCenter;
                    btnCategoria.Text.ToUpper();

                    //Enventos 
                    btnCategoria.Click += btnCategorias_Click;
                    btnCategoria.Width = 98;
                    btnCategoria.Height = 35;
                    imagem.BackColor = Color.Transparent;
                    imagem.ForeColor = Color.Black;
                    //Enventos 
                    imagem.Width = 98;
                    imagem.Height = 50;
                    //Adicionando ao controle flowPanels Unitários
                    flwPanelItems.Controls.Add(imagem);
                    flwPanelItems.Controls.Add(btnCategoria);
                    painelFlutuanteMain.Controls.Add(flwPanelItems);
                }
            } catch (Exception ex) {
                Alert(ex.Message);
            }
        }

        private void btnProdutosVer_MouseHover(object sender, EventArgs e) {

        }

        private void btnProdutos_Click(object sender, EventArgs e) {
            Button btnProd = sender as Button;
            ovTXT_CodigoBarrasProduto.Text = btnProd.Name;
            InserirProdutoPeloCodigo();

        }
        private void btnCategorias_Click(object sender, EventArgs e) {
            Button btnCategoria = sender as Button;
            IdCategoria = decimal.Parse(btnCategoria.Name);
            CarregarPainelProdutos();

        }

        private void GPDV_PainelInicial_Load(object sender, EventArgs e) {
            string NomeMaquina = Dns.GetHostName();
            IPAddress[] IpMaquina = Dns.GetHostAddresses(NomeMaquina);
            VerificaAberturaCaixa();
            Location = new Point(0, 0);
            //WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Maximized;
            lblOperador.Text = ("OPERADOR(a): " + Contexto.USUARIOLOGADO.Nome + " - ESTAÇÃO: " + NomeMaquina);//OperadorCaixa ip nome pc
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Bounds = Screen.PrimaryScreen.Bounds;
            FormBorderStyle = FormBorderStyle.None;
            ControlBox = false;
            //Movable = false;
            //Resizable = false;
            CarregarPainelCategorias();
            Text = string.Format("RootSys  {0} - Suporte {1}", Contexto.VERSAO, "www.rootsys.com.br");

            Quantidade = 1;

            try {
                InserirCabecalhoNota();
                ovTXT_DescricaoProduto.Text = "CAIXA LIVRE";
            } catch (Exception ex) {
                MessageBox.Show(this, "Não foi possível iniciar o PONTO DE VENDA. Verifique as Configurações. Detalhes : " + ex.Message, NOME_TELA);
                Close();
            }

            AjustarPesquisaDeCategoria();
            InitBindings();
        }

        private void InitBindings() {
            gridControl1.DataSource = ITENS_VENDA;
        }

        private void AjustarPesquisaDeCategoria() {
            if (Caixa != null)
                lblPesquisar.Visible = tbxPesquisar.Visible = btnVoltarCategoria.Visible = painelBotoesComanda.Visible = Caixa.TipoPDV == Caixa.Restaurante;
        }

        private void VerificaAberturaCaixa() {
            FLUXO = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuario(Contexto.USUARIOLOGADO.IDUsuario);
            if (FLUXO == null) {
                if (MessageBox.Show(this, "Deseja abrir um novo caixa?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    AberturaCaixa Abertura = new AberturaCaixa(Contexto.USUARIOLOGADO);
                    Abertura.ShowDialog();
                    FLUXO = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuario(Contexto.USUARIOLOGADO.IDUsuario);
                    Caixa = Abertura.Caixa;

                    if (FLUXO == null) {
                        Application.Exit();
                        return;
                    }
                    AjustarPesquisaDeCategoria();
                } else {
                    Application.Exit();
                    return;
                }
            } else {
                Caixa = FuncoesCaixa.GetCaixa(FLUXO.CaixaID);
                if (Caixa.TipoPDV == Caixa.Mercado) {
                    painelFlutuanteMain.Anchor = AnchorStyles.None;
                    pictureBoxPropraganda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                    //Logomarca Cliente Modo Mercado

                    tbxPesquisar.Visible = lblPesquisar.Visible = false;
                }
            }

            Emitente _Emitente = FuncoesEmitente.GetEmitente();
            using (var ms = new MemoryStream(_Emitente.logopropraganda))
                pictureBoxLogoMercado.Image = Image.FromStream(ms);

            pictureBoxPropraganda.Visible = Caixa.TipoPDV == Caixa.Mercado;

            pictureBoxPropraganda.Visible = Caixa.TipoPDV == Caixa.Restaurante;
            painelFlutuanteMain.Visible = Caixa.TipoPDV == Caixa.Restaurante;
            pictureBoxLogoMercado.Visible = Caixa.TipoPDV == Caixa.Mercado;

            IniciaNovaVenda();
            InserirFooter();
            ovTXT_CodigoBarrasProduto.Select();

            switch (Caixa.TipoDeVenda) {
                case "Normal":
                    TipoFiscal = 1;
                    lblInfo2.Text = $"CAIXA ONLINE (NORMAL)";
                    break;
                case "NFCe":
                    TipoFiscal = 2;
                    lblInfo2.Text = $"CAIXA ONLINE (NFCe)";
                    break;
                case "MFe":
                    TipoFiscal = 3;
                    lblInfo2.Text = $"CAIXA ONLINE (MFe)";
                    break;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData) {
            switch (keyData) {

                case (Keys.Alt | Keys.F1):
                    Form form = null;

                    if (TipoFiscal == 3)
                        form = new GPDV_CarregarVendaMFe();
                    else if (TipoFiscal == 2)
                        form = new GER_NotasFiscaisConsumidor();
                    else
                        form = new FormVendas(FLUXO.IDFluxoCaixa);

                    form.ShowDialog();

                    break;

                case (Keys.Escape):
                    if (MessageBox.Show(this, "Deseja Sair?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        Dispose();
                    }

                    break;
                case Keys.F1:
                    abrirAjudar();
                    break;
                case Keys.F5:
                    if (VENDA.IDComanda != null)
                        SalvarPreVenda();
                    else
                        ChamarFinalizarVenda();
                    break;
                case Keys.Multiply:
                    ovTXT_Quantidade.ReadOnly = false;
                    ovTXT_Quantidade.TabStop = true;
                    ovTXT_Quantidade.Select();
                    ovTXT_Quantidade.SelectAll();
                    break;
                case Keys.F9:
                    //AlterarPrecoItem();
                    carregarPanelComanda();
                    break;
                case Keys.F11:
                    if (MessageBox.Show(this, "Deseja Cancelar a Venda?", NOME_TELA, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                        IniciaNovaVenda();
                        CarregarPainelCategorias();
                    }

                    break;

                //case Keys.Escape:
                //    CarregarPainelCategorias();
                //    break;

                case Keys.F8:
                    CancelarItemVenda();
                    break;
                case Keys.F4:
                    ConsultarPrecoItem();
                    break;
                case Keys.F6:
                    AbreMenuConfiguracoes();
                    break;
                //case Keys.F9:
                //    //IdentificarComanda();
                //    break;
                case Keys.F10:
                    PesquisarItem();
                    break;
                //case Keys.F11:

                //    break;
                case Keys.F12:
                    IdentificarCliente();
                    break;
                case Keys.Insert:
                    //ChamarFinalizarVendaNaoFiscal();
                    break;
                case (Keys.Control | Keys.F12):
                    SalvarPreVenda();
                    break;
                case (Keys.Control | Keys.Insert):
                    AjustarEstoque();
                    break;

                case (Keys.Control | Keys.M):
                    MataFomeConnect mataFomeConnect = new MataFomeConnect();
                    mataFomeConnect.ShowDialog();
                    break;


                case (Keys.Control | Keys.E):
                    GPDV_SuprimentoCaixa suprimentoCaixa = new GPDV_SuprimentoCaixa();
                    suprimentoCaixa.ShowDialog();
                    break;

                case (Keys.Control | Keys.S):
                    GPDV_SangriaCaixa sangriaCaixa = new GPDV_SangriaCaixa();
                    sangriaCaixa.ShowDialog();
                    break;

                case (Keys.Alt | Keys.P):
                    FCO_ProdutoPDV fCO_Produto = new FCO_ProdutoPDV(Contexto.USUARIOLOGADO.IDPerfilAcesso);
                    fCO_Produto.ShowDialog();
                    CarregarPainelCategorias();
                    break;

                case (Keys.Alt | Keys.Delete):
                    CarregarPainelCategorias();
                    break;

            }
            return base.ProcessDialogKey(keyData);
        }

        private void abrirAjudar() {
            GPDV_Comandos comando = new GPDV_Comandos(this);
            comando.ShowDialog();
            //nao intendi...
            /*
            {               
                case ("F5"):
                    if (VENDA.IDComanda != null)
                        SalvarPreVenda();
                    else
                        ChamarFinalizarVenda();
                    break;                    
            }*/
        }

        public void AtualizaQtde(string qtde, string ean) {
            if (qtde == "Sem Leitura") {
                qtde = "1";
            } else {
                ovTXT_Quantidade.Text = qtde;
                //ovTXTCodigoProduto.Text = ean;
                ovTXT_CodigoBarrasProduto.Text = ean;
                InserirProdutoPeloCodigo();
            }
        }
        private void ovTXT_CodigoProduto_KeyUp(object sender, KeyEventArgs e) {

            if (e.KeyCode == Keys.Multiply) {
                ovTXT_CodigoBarrasProduto.Text = string.Empty;
                // sembalanca = true;
            }

            if (e.KeyCode == Keys.Enter) {

                if (ovTXT_CodigoBarrasProduto.Text != string.Empty) {
                    if (contemLetras(ovTXT_CodigoBarrasProduto.Text)) {
                        PesquisarItem();
                    } else {
                        if (contemNumeros(ovTXT_CodigoBarrasProduto.Text)) {
                            InserirProdutoPeloCodigo();
                        }
                    }
                }
            }
        }

        public bool contemLetras(string texto) {
            if (texto.Where(c => char.IsLetter(c)).Count() > 0) {
                return true;
            } else {
                return false;
            }
        }

        public bool contemNumeros(string texto) {
            if (texto.Where(c => char.IsNumber(c)).Count() > 0) {
                return true;
            } else {
                return false;
            }
        }

        private void InserirProdutoPeloCodigo() {
            string sAux;
            try {
                sAux = ConfigurationManager.AppSettings["PedeTipoVenda"];
            } catch {
                Alert("Parametro Pede Tipo Venda não configurado!");
                return;
            }
            if (sAux == "S" && ovTXT_CodigoBarrasProduto.Text.Substring(0, 1) != "*") {
                if (TipoVenda == 0) {
                    GPDV_TipoVenda tipovenda = new GPDV_TipoVenda();
                    tipovenda.TipoVenda(this);
                    tipovenda.ShowDialog();
                }
            }
            if (sAux == "N" && ovTXT_CodigoBarrasProduto.Text.Substring(0, 1) != "*") {
                TipoVenda = 1;

            }
            if (ovTXT_CodigoBarrasProduto.Text.Length > 0) {
                if (EANEmpresa != "") {
                    if (ovTXT_CodigoBarrasProduto.Text.Substring(0, 1) == "0") {
                        string ssAux = ovTXT_CodigoBarrasProduto.Text.PadLeft(7, '0');
                        ovTXT_CodigoBarrasProduto.Text = EANEmpresa + ssAux; //"7898610001967"
                    }
                }
                if (ovTXT_CodigoBarrasProduto.Text.Substring(0, 1) == "*") {
                    FCOFIN_ContaReceber receber = new FCOFIN_ContaReceber();
                    receber.MudaParaReceber();
                    receber.IDFLUXOCAIXA = FLUXO.IDFluxoCaixa;
                    receber.ShowDialog(this);
                    ovTXT_CodigoBarrasProduto.Text = "";
                    return;
                }
                if (string.IsNullOrEmpty(ovTXT_CodigoBarrasProduto.Text)) {
                    return;
                }

                GetProduto();

                if (ProdutoPDV != null) {
                    if (TipoFiscal != 1) {
                        if (ProdutoPDV.IDIntegracaoFiscalNFCe == 0) {
                            Alert(string.Format("O produto \"{0}\" não possui Integração Fiscal de NFC-e. Verifique o cadastro e tente novamente.", ProdutoPDV.Produto));
                            return;
                        }

                        if (!FuncoesProduto.ExisteTributoVigenteProduto(ProdutoPDV.IDProduto)) {
                            Alert(string.Format("O produto \"{0}\" não possui Tributação Vigênte. Verifique o cadastro do IBPT e tente novamente.", ProdutoPDV.Produto));
                            return;
                        }
                    }

                    if (ProdutoPDV.Balanca && ovTXT_CodigoBarrasProduto.Text.Length == 13)
                        CalculosProdutoBalancaRetaguarda();
                    else
                        CalculosProdutoBalancaCaixa();

                    if (!VerificaEstoque(ProdutoPDV.IDProduto))
                        return;

                    if (!ValidarValorUnitario())
                        return;

                    CalcularSubTotal();

                    InserirItem();

                    AtualizarQuantidadeItensESubTotalVenda();

                    ovTXT_DescricaoProduto.Text = ProdutoPDV.Produto;
                    AlterouPreco = false;
                    pesoRecebido = false;
                    ValorUnitario = 0;
                    
                } else {
                    ovTXT_DescricaoProduto.Text = "Produto não Cadastrado.";
                    ovTXT_CodigoBarrasProduto.SelectionStart = 0;
                    ovTXT_CodigoBarrasProduto.SelectionLength = ovTXT_CodigoBarrasProduto.Text.Length;
                    return;
                }
            }
        }

        private bool ValidarValorUnitario() {
            if (ValorUnitario == 0) {
                if (TipoVenda == 1)
                    ValorUnitario = ProdutoPDV.PrecoVenda;
                else if (TipoVenda == 3)
                    ValorUnitario = ProdutoPDV.PrecoVendaPrazo;

                if (ValorUnitario == 0) {
                    ovTXT_ValorUnitario.ReadOnly = false;
                    ovTXT_ValorUnitario.Focus();
                    return false;
                }
            }
            return true;
        }

        private void InserirItem() {
            decimal item = 0;
            ITENS_VENDA.Add(new ItemVenda() {
                Item = item++,
                CodigoItem = ProdutoPDV.Codigo,
                DescricaoItem = ProdutoPDV.Produto.TrimEnd(),
                ValorUnitarioItem = ValorUnitario,
                Subtotal = Convert.ToDecimal(ovTXT_SubTotal.Text),
                IDProduto = ProdutoPDV.IDProduto,
                IDItemVenda = Sequence.GetNextID("ITEMVENDA", "IDITEMVENDA"),
                IDVenda = VENDA.IDVenda,
                Quantidade = Quantidade,
                IDUsuario = Contexto.USUARIOLOGADO.IDUsuario
            });
            ovTXT_Quantidade.Text = "1";
        }

        private void CalcularSubTotal() {
            SubTotal = ValorUnitario * Quantidade;
        }

        private void CalculosProdutoBalancaCaixa()
        {
            //VERIFICA E CALCULA O SUBTOTAL DE PRODUTO PESADO NA BALANÇA DO CAIXA
            var sigla = ProdutoPDV.UnidadeDeMedidaSigla;
            string[] unidadesDePeso = { "kg", "Kilo", "Kilograma" };
            var IsPeso = unidadesDePeso.Where(u => u.ToLower() == sigla.ToLower()).Count() > 0;
            if (IsPeso)
            {
                try
                {
                    ObterPesoToledo();
                    System.Threading.Thread.Sleep(1000);
                    if (!pesoRecebido)
                    {
                        return;
                    }
                    ovTXT_Quantidade.Text = decRxString.ToString("#,###0.000");
                    //SubTotal = (ValorUnitario * Quantidade);
                }
                catch (Exception)
                {
                    throw; //new Exception("Calcular SubTotal");
                }
            }
        }

        private void CalculosProdutoBalancaRetaguarda()
        {
            string infEtiqueta = System.Text.Encoding.UTF8.GetString(infEtiquetaBalanca.Valor);

            if (infEtiqueta == "PRECO")
            {
                //string preco = codigoBarraBalanca.Substring(7, 5);
                //preco.Insert(Convert.ToInt32(preco.Substring(preco.Length, -2)), ".");
                int a = 1;
                decimal precoEtiqueta = Convert.ToDecimal(ovTXT_CodigoBarrasProduto.Text.Substring(7, 5).Insert(3, ","));
                decimal qtdeEtiqueta = Convert.ToDecimal(precoEtiqueta) / ProdutoPDV.PrecoVenda;

                Quantidade = Math.Round(qtdeEtiqueta, 3);
            }
            else
            {
                decimal qtdeEtiqueta = Convert.ToDecimal(ovTXT_CodigoBarrasProduto.Text.Substring(7, 5).Insert(2, ","));
                decimal subTotalEtiqueta = Convert.ToDecimal(qtdeEtiqueta) * ProdutoPDV.PrecoVenda;

                Quantidade = qtdeEtiqueta;
                SubTotal = Math.Round(subTotalEtiqueta, 3);
            }
        }

        private void GetProduto() {
            var codigo = ovTXT_CodigoBarrasProduto.Text.Trim();

            if (codigo.Substring(0, 1) == "0")
                codigo = codigo.Substring(1, codigo.Length - 1);

            if (codigo.Substring(0,1) == "2" && codigo.Length == 13)
                codigo = codigo.Substring(0, 7);
            
            ProdutoPDV = FuncoesProduto.GetProdutoPDVPorCodigo(codigo);
        }

        private void Alert(string msg) {
            MessageBox.Show(msg, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool VerificaEstoque(decimal IDProduto) {
            if (!FuncoesPerfilAcesso.ISEstoqueLiberado()) {
                return true;
            }

            Produto Prod = FuncoesProduto.GetProduto(IDProduto);
            DataRow DrSaldoAlmoxarifado = FuncoesItemTransferenciaEstoque.GetProdutosComSaldoEmAlmoxarifado(Prod.IDAlmoxarifadoSaida.Value, Prod.IDProduto);

            if (Prod.VenderSemSaldo == 0) {
                if (DrSaldoAlmoxarifado == null) {
                    MessageBox.Show(this, "Produto sem Saldo em Estoque. Verifique!", NOME_TELA);

                    return false;
                }        

                if (Quantidade > Convert.ToDecimal(DrSaldoAlmoxarifado["SALDO"])) {
                    MessageBox.Show(this, "Saldo do Produto em Estoque é menor que a Quantidade solicitada.", NOME_TELA);
                    return false;
                }                
            }
            return true;
        }

        private void AtualizarQuantidadeItensESubTotalVenda() {
            QuantidadeItens = ITENS_VENDA.Sum(i => i.Quantidade);
            TotalVenda = ITENS_VENDA.Sum(i => i.Subtotal);
            ovTXT_QuantidadeProdutos.Text = ITENS_VENDA.Count.ToString("n0");

            VENDA.ValorTotal = TotalVenda;
            VENDA.QuantidadeItens = QuantidadeItens;

            ovTXT_CodigoBarrasProduto.Text = string.Empty;

            Quantidade = 1;
            SubTotal = 0;

            if (gridView1.RowCount > 0) {
                gridView1.ClearSelection();
                gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                gridView1.SelectRow(gridView1.RowCount - 1);

            }
        }

        public void IniciaNovaVenda() {
            VENDA = new DAO.Entidades.PDV.Venda() {
                IDVenda = Sequence.GetNextID("VENDA", "IDVENDA"),
                IDUsuario = Contexto.USUARIOLOGADO.IDUsuario,
                DataCadastro = DateTime.Now,
                IDFluxoCaixa = FLUXO.IDFluxoCaixa,

            };
            TipoVenda = 0;
            //  gbInfo.Text = "Informações Gerais da Venda";
            Comanda = null;
            Cliente = null;
            ITENS_VENDA = new BindingList<ItemVenda>();
            InitBindings();
            PAGAMENTOS = new List<DuplicataNFCe>();
            AtualizarQuantidadeItensESubTotalVenda();
            LimparCamposVenda();

            ovTXT_CodigoBarrasProduto.Select();
            ovTXT_CodigoBarrasProduto.SelectAll();

            ovTXT_Cliente.Text = "<CPF/CNPJ Não Informado>";
            labelComanda.Visible = false;
            ///cupomVendaFlowLayoutPanel.Controls.Clear();
            ///


        }

        private void LimparCamposVenda() {
            ovTXT_DescricaoProduto.Text = string.Empty;

            ovTXT_ValorUnitario.Text = 0.ToString("n2");
            //ovTXTCodigoProduto.Text = string.Empty;

            SubTotal = 0;
            ovTXT_CodigoBarrasProduto.Text = string.Empty;
            ovTXT_Quantidade.Text = 1.ToString();
        }

        private void f4ALTERARQUANTIDADEToolStripMenuItem_Click(object sender, EventArgs e) {
            ovTXT_Quantidade.ReadOnly = false;
            ovTXT_Quantidade.TabStop = true;
            ovTXT_Quantidade.Select();
            ovTXT_Quantidade.SelectAll();
        }


        private void f7CANCELARVENDAToolStripMenuItem_Click(object sender, EventArgs e) {
            if (MessageBox.Show(this, "Deseja Cancelar a Venda?", NOME_TELA, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                IniciaNovaVenda();
            }
        }

        private void f6CANCELARITEMToolStripMenuItem_Click(object sender, EventArgs e) {
            CancelarItemVenda();
        }

        private void CancelarItemVenda() {
            if (ITENS_VENDA.Count == 0) {
                ovTXT_CodigoBarrasProduto.Select();
                ovTXT_CodigoBarrasProduto.SelectAll();
                return;
            }

            new GPDV_CancelarItem(ITENS_VENDA).ShowDialog(this);
            ovTXT_CodigoBarrasProduto.Select();
            ovTXT_CodigoBarrasProduto.SelectAll();


            FuncoesItemVenda.RemoverItensDaVenda(ITENS_VENDA.ToList(), VENDA.IDVenda);

            if (ITENS_VENDA.Count == 0) {
                FuncoesVenda.Remover(VENDA.IDVenda);
                FuncoesComanda.AtualizaStatusComanda(Comanda.IDComanda, "Null");
                IniciaNovaVenda();
                CarregarPainelCategorias();
                return;
            }

            AtualizarQuantidadeItensESubTotalVenda();
            //carregarPanelCoupomVenda(ITENS_VENDA,"");
        }
        private void AlterarQuantidadeItem() {
            try { ovTXT_Quantidade.Text = Convert.ToDecimal(ovTXT_Quantidade.Text).ToString(); } catch { ovTXT_Quantidade.Text = "1"; }
        }

        private void ovTXT_Quantidade_KeyUp(object sender, KeyEventArgs e) {

            if (e.KeyCode == Keys.Enter) {
                AlterarQuantidadeItem();

                ovTXT_CodigoBarrasProduto.Select();
                ovTXT_CodigoBarrasProduto.SelectAll();

                ovTXT_Quantidade.ReadOnly = true;
                ovTXT_Quantidade.TabStop = false;
            }
        }

        private void CONSULTARITEMToolStripMenuItem_Click(object sender, EventArgs e) {
            ConsultarPrecoItem();
        }

        private void ConsultarPrecoItem() {
            new GPDV_ConsultarPreco().ShowDialog(this);
            ovTXT_CodigoBarrasProduto.Select();
            ovTXT_CodigoBarrasProduto.SelectAll();
        }

        private void AjustarEstoque() {
            if (Contexto.USUARIOLOGADO.Root == 1) {
                new tbQtde().ShowDialog(this);
            }
        }

        private void f12FINALIZARVENDAToolStripMenuItem_Click(object sender, EventArgs e) {
            ChamarFinalizarVenda();
        }

        public void ChamarFinalizarVenda() {
            try {
                if (ITENS_VENDA.Count == 0) {
                    ovTXT_CodigoBarrasProduto.Select();
                    ovTXT_CodigoBarrasProduto.SelectAll();
                    return;
                }

                GPDV_FinalizarVenda gPDV_FinalizarVenda = new GPDV_FinalizarVenda(this, TipoFiscal);
                gPDV_FinalizarVenda.ShowDialog();
                ovTXT_CodigoBarrasProduto.Select();
                ovTXT_CodigoBarrasProduto.SelectAll();
                ovTXT_DescricaoProduto.Text = "CAIXA LIVRE PRÓXIMO CLIENTE";
            } catch (Exception ex) {
                MessageBox.Show(this, ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AtivarFinalizaçãoVisual(bool ativar) {
            if (ativar) {
                ovTXT_DescricaoProduto.Text = "Finalizando";
                //totalPanel.ForeColor = Color.Gray;
                //Total2panel.ForeColor = Color.Gray;
                //caixaPanel.ForeColor = Color.Gray;
                //ovTXT_SubTotalVenda.ForeColor = Color.Gray;
                //ovTXT_QuantidadeItens.ForeColor = Color.Gray;
                //ovTXT_QuantidadeProdutos.ForeColor = Color.Gray;
            } else {
                ovTXT_DescricaoProduto.Text = "CAIXA LIVRE";
                labelComanda.Visible = false;
                labelComanda.Text = "COMANDA " + Comanda.Descricao + "SELECIONADA!";
                carregarPanelComanda();
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            int Hora = DateTime.Now.Hour;
            string Saudacao = string.Empty;
            if (Hora >= 0 && Hora <= 6) {
                Saudacao = "Boa noite, ";
            }

            if (Hora >= 6 && Hora < 13) {
                Saudacao = "Bom dia, ";
            }

            if (Hora >= 13 && Hora <= 18) {
                Saudacao = "Boa tarde, ";
            }

            if (Hora > 18 && Hora <= 23) {
                Saudacao = "Boa noite, ";
            }
            try {
                String TextoInfo =
                string.Format("{0} {1}", Saudacao, DateTime.Now.ToLongDateString()) +
                                         string.Format("[Operador]: {0}", Contexto.USUARIOLOGADO.Nome.ToUpper()) +
                                          string.Format("[POS]: {0}", (Caixa != null ? Caixa.NomePOS.ToUpper() : "") + "-" + (Caixa != null ? Caixa.SerialPOS.ToUpper() : ""));
                this.Text = string.Format("[PDV ONLINE]: {0}", "(" + (Caixa != null ? Caixa.TipoDeVenda.ToUpper() : "") + ")");
                this.Text = TextoInfo;
            } catch (Exception) {


            }


        }

        private void metroButton1_Click(object sender, EventArgs e) {
            PesquisarItem();
        }

        private void PesquisarItem() {
            var form = new GPDV_PesquisarItem(this);
            form.CBarrasPesquisa = ovTXT_CodigoBarrasProduto.Text;
            form.ShowDialog(this);
            var cBarras = form.CBarras;
            if (cBarras != null) {
                ovTXT_CodigoBarrasProduto.Text = form.CBarras;
                InserirProdutoPeloCodigo();
            }

            ovTXT_CodigoBarrasProduto.Select();
        }

        private void metroButton7_Click(object sender, EventArgs e) {
            AlterarPrecoItem();
        }

        private void AlterarPrecoItem() {
            ovTXT_ValorUnitario.ReadOnly = false;
            ovTXT_ValorUnitario.TabStop = true;
            ovTXT_ValorUnitario.Select();
            ovTXT_ValorUnitario.SelectAll();

        }
        private void ovTXT_ValorUnitario_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                ovTXT_CodigoBarrasProduto.Select();
                ovTXT_CodigoBarrasProduto.SelectAll();

                ovTXT_ValorUnitario.ReadOnly = true;
                ovTXT_ValorUnitario.TabStop = false;
                AlterouPreco = true;
            }
        }

        private void ovGRD_Itens_Paint(object sender, PaintEventArgs e) {
            //DataGridView dgv = (DataGridView)sender;
            //e.Graphics.DrawImage(Properties.Resources.Zeus_Plano_de_Fundo, new Rectangle(0, dgv.Height - 105, dgv.Width, 105));
        }

        private void AbreMenuConfiguracoes() {
            new GPDV_MenuConfiguracoes(this).ShowDialog(this);
            FLUXO = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuario(Contexto.USUARIOLOGADO.IDUsuario);
            VerificaAberturaCaixa();
        }

        private void metroButton8_Click(object sender, EventArgs e) {
            CarregarVenda();
        }

        private void CarregarVenda() {
            GPDV_CarregarVenda FormCarregarVenda = new GPDV_CarregarVenda();
            FormCarregarVenda.ShowDialog(this);

            if (FormCarregarVenda.LinhaSelecionada != null) {
                VENDA = FuncoesVenda.GetVenda(Convert.ToDecimal(FormCarregarVenda.LinhaSelecionada["IDVENDA"]));
                VENDA.IDFluxoCaixa = FLUXO.IDFluxoCaixa; //teste fluxo caixa para atualizar o fluxo de caixa para o atual quando carregar
                ITENS_VENDA = FuncoesItemVenda.GetItensVenda(Convert.ToDecimal(FormCarregarVenda.LinhaSelecionada["IDVENDA"])).ToBindingList();
                InitBindings();
                AtualizarQuantidadeItensESubTotalVenda();

                if (FormCarregarVenda.LinhaSelecionada["IDCOMANDA"] != DBNull.Value) {
                    Comanda = FuncoesComanda.GetComanda(Convert.ToDecimal(FormCarregarVenda.LinhaSelecionada["IDCOMANDA"]));
                    // ovTXT_Comanda.Text = Comanda.Descricao;
                }

                if (FormCarregarVenda.LinhaSelecionada["IDCLIENTE"] != DBNull.Value) {
                    Cliente = FuncoesCliente.GetCliente(Convert.ToDecimal(FormCarregarVenda.LinhaSelecionada["IDCLIENTE"]));
                    ovTXT_Cliente.Text = Cliente._CPF_CNPJ;
                }
            }
        }

        private void linkLabel1_Click(object sender, EventArgs e) {
            IdentificarComanda();
        }

        private void IdentificarComanda() {
            SEL_Comanda SeletorComanda = new SEL_Comanda();
            SeletorComanda.ShowDialog(this);

            if (SeletorComanda.LinhaSelecionada != null) {
                Comanda = EntityUtil<Comanda>.ParseDataRow(SeletorComanda.LinhaSelecionada);

            } else {
                Comanda = null;

            }
        }

        private void IdentificarCliente() {
            GPDV_IdentificarCliente Identificar = new GPDV_IdentificarCliente(this);
            Identificar.ShowDialog(this);
            if (Identificar.Identificar) {
                if (Identificar.DRCliente != null) {
                    Cliente = FuncoesCliente.GetCliente(Convert.ToDecimal(Identificar.DRCliente["IDCLIENTE"]));
                } else {
                    Cliente = new Cliente {
                        TipoDocumento = Convert.ToDecimal(Identificar.ovTXT_TipoPessoa.Text),
                        Nome = Identificar.ovTXT_NomeCliente.Text,
                        CPF = Convert.ToDecimal(Identificar.ovTXT_TipoPessoa.Text) == 1 ? ZeusUtil.SomenteNumeros(Identificar.ovTXT_CPFCNPJ.Text) : null,
                        CNPJ = Convert.ToDecimal(Identificar.ovTXT_TipoPessoa.Text) == 0 ? ZeusUtil.SomenteNumeros(Identificar.ovTXT_CPFCNPJ.Text) : null,
                        Email = Identificar.ovTXT_EmailCliente.Text
                    };
                }

                ovTXT_Cliente.Text = "CPF/CNPJ: " + Cliente._CPF_CNPJ;
            } else {
                Cliente = null;
                ovTXT_Cliente.Text = "<CPF/CNPJ Não Informado>";
            }
        }

        private void linkLabel2_Click(object sender, EventArgs e) {
            IdentificarCliente();
        }

        private void linkLabel3_Click(object sender, EventArgs e) {
            SalvarPreVenda();
        }

        private void SalvarPreVenda() {
            try {
                PDVControlador.BeginTransaction();

                VENDA.IDCliente = null;
                if (Cliente != null) {
                    VENDA.IDCliente = Cliente.IDCliente;
                    if (!FuncoesCliente.SalvarAtualizarClienteNFCe(Cliente.Nome, Cliente.IDCliente, Cliente.Email, Cliente._CPF_CNPJ, Cliente.TipoDocumento))
                        throw new Exception("Não foi possível salvar o Cliente.");
                }

                VENDA.IDComanda = null;

                if (Comanda != null)
                    VENDA.IDComanda = Comanda.IDComanda;

                if (!FuncoesVenda.SalvarVenda(VENDA))
                    throw new Exception("Não foi possível salvar a Venda.");

                if (!FuncoesItemVenda.RemoverItensDaVenda(ITENS_VENDA.ToList(), VENDA.IDVenda))
                    throw new Exception("Não foi possível salvar a Venda.");

                foreach (ItemVenda Item in ITENS_VENDA)
                    if (!FuncoesItemVenda.SalvarItemVenda(Item))
                        throw new Exception("Não foi possível salvar os Itens da Venda.");

                if (Comanda != null)
                    FuncoesComanda.AtualizaStatusComanda(Comanda.IDComanda, "1");

                if (ITENS_VENDA.Count == 0) {
                    FuncoesComanda.AtualizaStatusComanda(Comanda.IDComanda, "Null");
                }

                PDVControlador.Commit();
                IniciaNovaVenda();
                CarregarPainelCategorias();
                ovTXT_CodigoBarrasProduto.Select();
                ovTXT_CodigoBarrasProduto.SelectAll();
                ovTXT_DescricaoProduto.Text = "CAIXA LIVRE";
            } catch (Exception ex) {
                PDVControlador.Rollback();
                MessageBox.Show(this, ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void metroButton9_Click(object sender, EventArgs e) {
            abrirAjudar();
        }

        private void ovTXT_CodigoBarrasProduto_KeyPress(object sender, KeyPressEventArgs e) {
            //if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            //{
            //    e.Handled = true;
            //}
        }

        private void label8_Click(object sender, EventArgs e) {
            carregarPanelComanda();
        }

        private void label6_Click(object sender, EventArgs e) {
            CarregarPainelCategorias();
        }

        private void label7_Click(object sender, EventArgs e) {
            SalvarPreVenda();
        }

        private void button1_Click(object sender, EventArgs e) {
            GPDV_CarregarVendaMFe gPDV_CarregarVendaMFe = new GPDV_CarregarVendaMFe();
            gPDV_CarregarVendaMFe.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e) {
            GPDV_CarregarVendaMFe gPDV_CarregarVendaMFe = new GPDV_CarregarVendaMFe();
            gPDV_CarregarVendaMFe.ShowDialog();
        }

        private void labelComanda_Click(object sender, EventArgs e) {

        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e) {
            if (e.Column.FieldName.ToLower() == "descricaoitem") {
                e.Column.Width = 200;
            }
        }

        private void tbxPesquisarCategoria_KeyUp(object sender, KeyEventArgs e) {
            CarregarPainelCategorias(tbxPesquisar.Text, false);
        }
        private void tbxPesquisarProduto_KeyUp(object sender, KeyEventArgs e) {
            CarregarPainelProdutos(tbxPesquisar.Text, false);
        }

        private void button1_Click_1(object sender, EventArgs e) {
            //GPDV_ConsultarProduto consulta = new GPDV_ConsultarProduto();
            //new GPDV_ConsultarProduto().ShowDialog(this);
            //consulta.ConsultaProduto(ovTXT_CodigoBarrasProduto.Text, this);
            ////consulta.ovTXT_CodigoBarrasProduto.Text = ovTXT_CodigoBarrasProduto.Text;
            ////consulta.ovTXT_CodigoBarrasProduto.Select();
            //ovTXT_CodigoBarrasProduto.SelectAll();
            //consulta.ShowDialog();


        }

        private void button1_Click_2(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            /*  if (balancaLigada)
               {
                   balancaLigada = false;
                   button2.Text = "BALANCA DESLIGADA";
               }
               else
               {
                   balancaLigada = true;
                   button2.Text = "BALANCA LIGADA";
               }
               */
            //ObterPesoToledo();
        }

        private void ovTXT_ValorUnitario_TextChanged(object sender, EventArgs e) {
            // CalcularSubTotal();
        }

        private string RemoverCaracteresInvalidos(string valor, char[] caracteresValidos) {
            valor
                .Where(c => !caracteresValidos.Contains(c))
                .ForEach(c => valor = valor.Replace(c.ToString(), ""));
            return valor;
        }

        private void button3_Click(object sender, EventArgs e) {
            CarregarVenda();
        }

        private void ovTXT_Quantidade_KeyDown(object sender, KeyEventArgs e) {
            return;
        }

        private void ovTXT_CodigoBarrasProduto_TextChanged(object sender, EventArgs e) {

        }

        private void ovTXT_CodigoBarrasProduto_KeyDown(object sender, KeyEventArgs e) {

            switch (e.KeyData) {
                case Keys.Multiply:

                    var valorQtd = ovTXT_CodigoBarrasProduto.Text;
                    ovTXT_Quantidade.Text = valorQtd;
                    ovTXT_CodigoBarrasProduto.Text = "";
                    ovTXT_CodigoBarrasProduto.Focus();

                    break;
                default:
                    break;
            }
        }

        private void painelFlutuanteMain_Paint(object sender, PaintEventArgs e) {

        }


        private void label5_Click(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void btnCancelarVenda_Click(object sender, EventArgs e) {

        }

        private void btnCancelarItem_Click(object sender, EventArgs e) {
            CancelarItemVenda();
        }

        private void btnAjuda_Click(object sender, EventArgs e) {
            abrirAjudar();
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e) {
            if (VENDA.IDComanda != null)
                SalvarPreVenda();

            else
                ChamarFinalizarVenda();
        }

        private void serialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e) {
            MessageBox.Show("err");
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            IdentificarCliente();
        }

        private void btnCaixa_Click(object sender, EventArgs e) {
            AbreMenuConfiguracoes();
        }

        private void btnVoltarCategoria_Click(object sender, EventArgs e) {
            CarregarPainelCategorias();//tbxPesquisar.Text, false
        }

        private void ovTXT_Usuario_Click(object sender, EventArgs e) {

        }

        private void label5_Click_1(object sender, EventArgs e) {

        }

        private void ovTXT_CodigoBarrasProduto_KeyPress_1(object sender, KeyPressEventArgs e) {
            /*   if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
               {
                   e.Handled = true;
               }*/  //comentamos para poder digitar letras e virgula 
             
        }

        private void btnSair_Click(object sender, EventArgs e) {

        }

        private void panel5_Paint(object sender, PaintEventArgs e) {

        }

        private void btnSair_Click_1(object sender, EventArgs e) {
            if (MessageBox.Show(this, "Deseja Sair?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Dispose();
            }
        }

        private void tbxPesquisar_TextChanged(object sender, EventArgs e) {

        }

        private void label5_Click_2(object sender, EventArgs e) {

        }

        private void lblPesquisar_Click(object sender, EventArgs e) {

        }

        private void ovTXT_CodigoBarrasProduto_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Multiply)
            {
                ovTXT_CodigoBarrasProduto.Text = string.Empty;
                // sembalanca = true;
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (ovTXT_CodigoBarrasProduto.Text != string.Empty)
                {
                    if (contemLetras(ovTXT_CodigoBarrasProduto.Text))
                    {
                        PesquisarItem();
                    }
                    else
                    {
                        if (contemNumeros(ovTXT_CodigoBarrasProduto.Text))
                        {
                            InserirProdutoPeloCodigo();
                        }
                    }
                }
            }
        }


       public bool EmitirContingenciaNFCE = false;

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if(simpleButton3.Text == "Normal")
            {
                simpleButton3.Text = "Contingência";
                EmitirContingenciaNFCE = true;
                simpleButton3.Appearance.BackColor = Color.DarkRed;
            }
            else
            {
                simpleButton3.Text = "Normal";
                EmitirContingenciaNFCE = false;
                simpleButton3.Appearance.BackColor = Color.SteelBlue;

            }

        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            if (VENDA.IDComanda != null)
                SalvarPreVenda();

            else
                ChamarFinalizarVenda();
        }

        private void linkFinalizarVenda_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (VENDA.IDComanda != null)
                SalvarPreVenda();

            else
                ChamarFinalizarVenda();
        }

        private void linkCancelarItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CancelarItemVenda();
        }

        private void linkCancelarVenda_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show(this, "Deseja Cancelar a Venda?", NOME_TELA, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                IniciaNovaVenda();

                CarregarPainelCategorias();

            }
        }
    }
}
