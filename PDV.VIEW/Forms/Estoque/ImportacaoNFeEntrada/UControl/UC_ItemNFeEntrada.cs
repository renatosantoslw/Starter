//using System.Windows.Forms;
//using PDV.DAO.Entidades.Estoque.NFeImportacao;
//using PDV.DAO.Entidades.Estoque.Suprimentos;
//using System.Collections.Generic;
//using PDV.CONTROLER.Funcoes;
//using System.Drawing;
//using System;
//using System.Linq;
//using PDV.DAO.Entidades;
//using FontAwesome.Sharp;
//using DevExpress.Office.Utils;

//namespace PDV.VIEW.Forms.Estoque.ImportacaoNFeEntrada.UControl
//{
//    public partial class UC_ItemNFeEntrada : UserControl
//    {
//        public ItemNFeEntrada _ItemNFeEntrada = null;
       
//        public List<ItemNFeEntrada> _Itens = null;


//        public Produto _Produto = null;


//        public ConversaoUnidadeDeMedida _Conversao = null;
//        public List<ConversaoUnidadeDeMedida> Conversoes = null;
//        public List<Almoxarifado> Almoxarifados = null;
//        public  decimal itemValorVenda;

//        private List<IntegracaoFiscal> IntegNFe = FuncoesIntegracaoFiscal.GetIntegracoes();
//        private List<IntegracaoFiscal> IntegNFCe = FuncoesIntegracaoFiscal.GetIntegracoes();
//        private List<OrigemProduto> Origem = FuncoesOrigemProduto.GetOrigensProduto();

//        public UC_ItemNFeEntrada(ItemNFeEntrada ItemNFeEntrada, decimal _itemValorVenda)
//        {
//            InitializeComponent();
//            _ItemNFeEntrada = ItemNFeEntrada;

//            Almoxarifados = FuncoesAlmoxarifado.GetAlmoxarifados();
//            ovCMB_AlmoxarifadoEntrada.DataSource = Almoxarifados;
//            ovCMB_AlmoxarifadoEntrada.DisplayMember = "DESCRICAOAPRESENTACAO";
//            ovCMB_AlmoxarifadoEntrada.ValueMember = "IDALMOXARIFADO";
//            ovCMB_AlmoxarifadoEntrada.SelectedItem = null;


//            itemValorVenda = _itemValorVenda;

//            CarregaConversoes();
//            PreencherTela();


            
//        }



//        public UC_ItemNFeEntrada(ItemNFeEntrada ItemNFeEntrada, Produto _produto)
//        {
//            InitializeComponent();
//            _ItemNFeEntrada = ItemNFeEntrada;

//            Almoxarifados = FuncoesAlmoxarifado.GetAlmoxarifados();
//            ovCMB_AlmoxarifadoEntrada.DataSource = Almoxarifados;
//            ovCMB_AlmoxarifadoEntrada.DisplayMember = "DESCRICAOAPRESENTACAO";
//            ovCMB_AlmoxarifadoEntrada.ValueMember = "IDALMOXARIFADO";
//            ovCMB_AlmoxarifadoEntrada.SelectedItem = null;


//            _Produto = _produto;


//            CarregaConversoes();
//            PreencherTela();

//            //icones
//            Bitmap bitmapLimpar = IconChar.TrashAlt.ToBitmap(Color.DarkRed, 24);
//            Bitmap bitmapPesquisar = IconChar.Search.ToBitmap(Color.SteelBlue, 24);

//            button1.ImageOptions.Image = bitmapLimpar;
//            ovBTN_Localizar.ImageOptions.Image = bitmapPesquisar;
//        }


//        public UC_ItemNFeEntrada(List<ItemNFeEntrada> Itens)
//        {

//           // _Itens = Itens;
         
//            _ItemNFeEntrada = Itens[0];

            

//            InitializeComponent();
//            //_ItemNFeEntrada = ItemNFeEntrada;

//            Almoxarifados = FuncoesAlmoxarifado.GetAlmoxarifados();
//            ovCMB_AlmoxarifadoEntrada.DataSource = Almoxarifados;
//            ovCMB_AlmoxarifadoEntrada.DisplayMember = "DESCRICAOAPRESENTACAO";
//            ovCMB_AlmoxarifadoEntrada.ValueMember = "IDALMOXARIFADO";
//            ovCMB_AlmoxarifadoEntrada.SelectedItem = null;


//            //itemValorVenda = _itemValorVenda;

//            CarregaConversoes();
//            PreencherTela();



//        }



//        private void PreencherTela()
//        {
//           if (_ItemNFeEntrada == null)
//               return;
            
//            ovTXT_Ean.Text = string.IsNullOrEmpty(_ItemNFeEntrada.CEAN) ? "<Não Informado>" : _ItemNFeEntrada.CEAN.ToString();
//            ovTXT_Produto.Text = _ItemNFeEntrada.DescricaoProduto;

//            //ovTXT_Produto.Text = Convert.ToString(_Itens[0].DescricaoProduto);

          
//           txtDescricaoProduto.Text = _ItemNFeEntrada.DescricaoProduto;

//            lblInfCEST.Text = "CEST: " + _ItemNFeEntrada.CEST;
//            if (string.IsNullOrEmpty(_ItemNFeEntrada.CEST))
//                lblInfCEST.Visible = false;

            

//            ovTXT_UNEntrada.Text = _ItemNFeEntrada.UNEntrada;
//            ovTXT_UNSaida.Text = _ItemNFeEntrada.UNSaida;
//            ovTXT_QtdeEntrada.Text = _ItemNFeEntrada.QuantidadeEntrada.ToString("n4");
//            ovTXT_QtdeSaida.Text = _ItemNFeEntrada.QuantidadeSaida.ToString("n4");
//            ovTXT_ValorCusto.Text = _ItemNFeEntrada.Valor.ToString("c2");
//            ovTXT_ValorTotal.Text = (_ItemNFeEntrada.Valor * _ItemNFeEntrada.QuantidadeEntrada).ToString("c2");


//            ovCMB_IntegracaoNFe.DataSource = IntegNFe;
//            ovCMB_IntegracaoNFe.DisplayMember = "descricao";
//            ovCMB_IntegracaoNFe.ValueMember = "idintegracaofiscal";
//            ovCMB_IntegracaoNFe.SelectedItem = null;

//            ovCMB_IntegracaoNFCe.DataSource = IntegNFCe;
//            ovCMB_IntegracaoNFCe.DisplayMember = "descricao";
//            ovCMB_IntegracaoNFCe.ValueMember = "idintegracaofiscal";
//            ovCMB_IntegracaoNFCe.SelectedItem = null;

//            ovCMB_Tributos_Origem.DataSource = Origem;
//            ovCMB_Tributos_Origem.DisplayMember = "descricao";
//            ovCMB_Tributos_Origem.ValueMember = "codigo";
//            ovCMB_Tributos_Origem.SelectedItem = null;


//            // editDecimalValorVenda.Value = itemValorVenda;

//            if (_Produto != null)
//            {

//                editDecimalValorVenda.Value = _Produto.ValorVenda;
//                ovCMB_IntegracaoNFe.SelectedItem = IntegNFe.Where(o => o.IDIntegracaoFiscal == (_Produto.IDIntegracaoFiscalNFe ?? -1)).FirstOrDefault();
//                ovCMB_IntegracaoNFCe.SelectedItem = IntegNFCe.Where(o => o.IDIntegracaoFiscal == (_Produto.IDIntegracaoFiscalNFCe ?? -1)).FirstOrDefault();
//               // ovCMB_Tributos_Origem.SelectedItem = Origem.Where(o => o.IDOrigemProduto == _Produto.IDOrigemProduto).FirstOrDefault();

//            }






//            if (_ItemNFeEntrada.IDProduto != -1)
//                ovCMB_AlmoxarifadoEntrada.SelectedItem = Almoxarifados.Where(o => o.IDAlmoxarifado == FuncoesProduto.GetProduto(_ItemNFeEntrada.IDProduto).IDAlmoxarifadoEntrada).FirstOrDefault();




//            AtualizaLocalizacao();
//        }

//        private void ovCKB_IncluirItem_CheckedChanged(object sender, System.EventArgs e)
//        {

//        }

//        private void ovBTN_Localizar_Click(object sender, System.EventArgs e)
//        {

//        }

//        private void AtualizaLocalizacao()
//        {
//            if (_ItemNFeEntrada.IDProduto == -1)
//            {
//                ovTXT_Status.Text = "<Item Não Localizado>";
//                ovTXT_Status.ForeColor = Color.DarkRed;
//                ovTXT_Produto.ForeColor = Color.DarkRed;
//            }
//            else
//            {
//                ovTXT_Status.Text = "<Item Localizado>";
//                ovTXT_Status.ForeColor = Color.DarkGreen;
//                ovBTN_Localizar.Enabled = false;
//                ovCKB_IncluirItem.Enabled = false;
//                ovTXT_Produto.ForeColor = Color.DarkGreen;
//            }
//        }

//        private void CarregaConversoes()
//        {

//            // Conversoes = FuncoesConversaoUnidadeMedida.GetConversoesPorProduto(_ItemNFeEntrada.IDProduto);
//            Conversoes = FuncoesConversaoUnidadeMedida.GetConversoesPorProdutoTodos();


//            ovCMB_FatorConversao.DataSource = Conversoes;
//            ovCMB_FatorConversao.SelectedItem = 1;
//            ovCMB_FatorConversao.DisplayMember = "DESCRICAO";
//            ovCMB_FatorConversao.ValueMember = "IDCONVERSAOUNIDADEDEMEDIDA";


//        }

//        private void ovCMB_FatorConversao_SelectedValueChanged(object sender, EventArgs e)
//        {
 
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
          
//        }

//        private void UC_ItemNFeEntrada_Load(object sender, EventArgs e)
//        {

//        }

//        private void ovTXT_PercentualGanho_ValueChanged(object sender, EventArgs e)
//        {

           

           
      
//        }



//        private void AtualizaPercentual()
//        {
//            decimal Diferenca = editDecimalValorVenda.Value == 0 || Convert.ToDecimal(ovTXT_ValorCusto.Text.Replace("R$ ", "")) == 0 ? 0 : editDecimalValorVenda.Value - Convert.ToDecimal(ovTXT_ValorCusto.Text.Replace("R$ ", ""));
//            if (Diferenca <= 0)
//            {
//                ovTXT_PercentualGanho.Value = 0;
//                return;
//            }

//            ovTXT_PercentualGanho.Value = (Diferenca / Convert.ToDecimal(ovTXT_ValorCusto.Text.Replace("R$ ", ""))) * 100;


//        }

//        private void editDecimalValorVenda_ValueChanged(object sender, EventArgs e)
//        {
//            AtualizaPercentual();
//        }

//        private void ovBTN_Localizar_Click_1(object sender, EventArgs e)
//        {
//            FEST_SeletorProduto Seletor = new FEST_SeletorProduto(Convert.ToDecimal(_ItemNFeEntrada.NCM));
//            Seletor.ShowDialog(this);

//            if (Seletor.drProduto != null)
//            {
//                _ItemNFeEntrada.IDProduto = Convert.ToInt32(Seletor.drProduto["IDPRODUTO"]);
//                ovCMB_AlmoxarifadoEntrada.SelectedItem = Almoxarifados.Where(o => o.IDAlmoxarifado == FuncoesProduto.GetProduto(_ItemNFeEntrada.IDProduto).IDAlmoxarifadoEntrada).FirstOrDefault();

//                editDecimalValorVenda.Value = FuncoesProduto.GetProduto(_ItemNFeEntrada.IDProduto).ValorVenda;


//                ovCMB_IntegracaoNFe.SelectedItem = IntegNFe.Where(o => o.IDIntegracaoFiscal == (FuncoesProduto.GetProduto(_ItemNFeEntrada.IDProduto).IDIntegracaoFiscalNFe ?? -1)).FirstOrDefault();
//                ovCMB_IntegracaoNFCe.SelectedItem = IntegNFCe.Where(o => o.IDIntegracaoFiscal == (FuncoesProduto.GetProduto(_ItemNFeEntrada.IDProduto).IDIntegracaoFiscalNFCe ?? -1)).FirstOrDefault();





//                AtualizaLocalizacao();
//                CarregaConversoes();
//            }
//        }





//        private void ovTXT_PercentualGanho_ValueChanged_1(object sender, EventArgs e)
//        {

//            //editDecimalValorVenda.Value = _ItemNFeEntrada.Valor + _ItemNFeEntrada.Valor * (ovTXT_PercentualGanho.Value / 100);
//            editDecimalValorVenda.Value =Convert.ToDecimal(ovTXT_ValorCusto.Text.Replace("R$ ","")) + Convert.ToDecimal(ovTXT_ValorCusto.Text.Replace("R$ ", "")) * (ovTXT_PercentualGanho.Value / 100);


//        }

//        private void editDecimalValorVenda_ValueChanged_1(object sender, EventArgs e)
//        {
//            AtualizaPercentual();
//        }

//        private void button1_Click_1(object sender, EventArgs e)
//        {
//            ovCMB_FatorConversao.SelectedItem = null;
//        }

//        private void ovCMB_FatorConversao_SelectedValueChanged_1(object sender, EventArgs e)
//        {
//            var FatorConversao = (ovCMB_FatorConversao.SelectedItem as ConversaoUnidadeDeMedida);
//            if (FatorConversao != null)
//            {
//                ovTXT_UNEntrada.Text = FatorConversao.UNENTRADA;
//                ovTXT_UNSaida.Text = FatorConversao.UNSAIDA;

//                decimal QuantidadeSaida = _ItemNFeEntrada.QuantidadeEntrada * FatorConversao.Fator;
//                decimal ValorCusto = _ItemNFeEntrada.Valor / QuantidadeSaida;

//                ovTXT_QtdeSaida.Text = QuantidadeSaida.ToString("n4");
//                ovTXT_ValorCusto.Text = ValorCusto.ToString("c2");
//                ovTXT_ValorTotal.Text = (ValorCusto * QuantidadeSaida).ToString("c2");
//            }
//            else
//                PreencherTela();
//        }

//        private void ovCKB_IncluirItem_CheckedChanged_1(object sender, EventArgs e)
//        {
//            ovBTN_Localizar.Enabled = !ovCKB_IncluirItem.Checked;

//            if (!ovCKB_IncluirItem.Checked)
//            {
//                ovTXT_Status.Text = "<Item Não Localizado>";
//                ovTXT_Status.ForeColor = Color.DarkRed;
//                ovTXT_Produto.ForeColor = Color.DarkRed;
//            }
//            else
//            {
//                ovTXT_Status.Text = "<Item Será Inserido>";
//                ovTXT_Status.ForeColor = Color.DarkGreen;
//                ovBTN_Localizar.Enabled = false;
//                ovTXT_Produto.ForeColor = Color.DarkGreen;
//            }
//        }

//        private void label16_Click(object sender, EventArgs e)
//        {

//        }

//        private void ovCMB_FatorConversao_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            var FatorConversao = (ovCMB_FatorConversao.SelectedItem as ConversaoUnidadeDeMedida);
          
//            if (FatorConversao != null)
//            {
//                ovTXT_UNEntrada.Text = FatorConversao.UNENTRADA;
//                ovTXT_UNSaida.Text = FatorConversao.UNSAIDA;

//                decimal QuantidadeSaida;
//                decimal ValorCusto;



//                switch (FatorConversao.CALCULO)
//                {
//                    case "Multiplicar":
//                         QuantidadeSaida = _ItemNFeEntrada.QuantidadeEntrada * FatorConversao.Fator;
//                         ValorCusto = _ItemNFeEntrada.Valor / QuantidadeSaida;
//                        ovTXT_QtdeSaida.Text = QuantidadeSaida.ToString("n4");
//                        ovTXT_ValorCusto.Text = ValorCusto.ToString("c2");
//                        ovTXT_ValorTotal.Text = (ValorCusto * QuantidadeSaida).ToString("c2");
//                        break;
//                    case "Dividir":
//                         QuantidadeSaida = _ItemNFeEntrada.QuantidadeEntrada / FatorConversao.Fator;
//                        ValorCusto = _ItemNFeEntrada.Valor / QuantidadeSaida;

//                        ovTXT_QtdeSaida.Text = QuantidadeSaida.ToString("n4");
//                        ovTXT_ValorCusto.Text = ValorCusto.ToString("c2");
//                        ovTXT_ValorTotal.Text = (ValorCusto * QuantidadeSaida).ToString("c2");

//                        break;
//                }




//              // decimal QuantidadeSaida = _ItemNFeEntrada.QuantidadeEntrada * FatorConversao.Fator;
                
                                         
//             //   decimal ValorCusto = _ItemNFeEntrada.Valor / QuantidadeSaida;

//            }
//            else
//                PreencherTela();
//        }


//        public void ConversaoFator()
//        {
//            var FatorConversao = (ovCMB_FatorConversao.SelectedItem as ConversaoUnidadeDeMedida);

//            if (FatorConversao != null)
//            {
//                ovTXT_UNEntrada.Text = FatorConversao.UNENTRADA;
//                ovTXT_UNSaida.Text = FatorConversao.UNSAIDA;

//                decimal QuantidadeSaida;
//                decimal ValorCusto;



//                switch (FatorConversao.CALCULO)
//                {
//                    case "Multiplicar":
//                        QuantidadeSaida = _ItemNFeEntrada.QuantidadeEntrada * FatorConversao.Fator;
//                        ValorCusto = _ItemNFeEntrada.Valor / QuantidadeSaida;
//                        ovTXT_QtdeSaida.Text = QuantidadeSaida.ToString("n4");
//                        ovTXT_ValorCusto.Text = ValorCusto.ToString("c2");
//                        ovTXT_ValorTotal.Text = (ValorCusto * QuantidadeSaida).ToString("c2");
//                        break;
//                    case "Dividir":
//                        QuantidadeSaida = _ItemNFeEntrada.QuantidadeEntrada / FatorConversao.Fator;
//                        ValorCusto = _ItemNFeEntrada.Valor / QuantidadeSaida;

//                        ovTXT_QtdeSaida.Text = QuantidadeSaida.ToString("n4");
//                        ovTXT_ValorCusto.Text = ValorCusto.ToString("c2");
//                        ovTXT_ValorTotal.Text = (ValorCusto * QuantidadeSaida).ToString("c2");

//                        break;
//                }




//                // decimal QuantidadeSaida = _ItemNFeEntrada.QuantidadeEntrada * FatorConversao.Fator;


//                //   decimal ValorCusto = _ItemNFeEntrada.Valor / QuantidadeSaida;

//            }
//            else
//                PreencherTela();
//        }

//        private void ovCMB_AlmoxarifadoEntrada_SelectedIndexChanged(object sender, EventArgs e)
//        {

//        }
//    }
//}