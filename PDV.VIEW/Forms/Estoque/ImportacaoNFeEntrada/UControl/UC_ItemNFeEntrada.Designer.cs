//namespace PDV.VIEW.Forms.Estoque.ImportacaoNFeEntrada.UControl
//{
//    partial class UC_ItemNFeEntrada
//    {
//        /// <summary> 
//        /// Variável de designer necessária.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary> 
//        /// Limpar os recursos que estão sendo usados.
//        /// </summary>
//        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Código gerado pelo Designer de Componentes

//        /// <summary> 
//        /// Método necessário para suporte ao Designer - não modifique 
//        /// o conteúdo deste método com o editor de código.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.label1 = new System.Windows.Forms.Label();
//            this.ovTXT_Produto = new System.Windows.Forms.Label();
//            this.label11 = new System.Windows.Forms.Label();
//            this.metroTabControl2 = new MetroFramework.Controls.MetroTabControl();
//            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
//            this.groupBox1 = new System.Windows.Forms.GroupBox();
//            this.ovTXT_PercentualGanho = new PDV.UTIL.Components.Custom.EditDecimal();
//            this.label13 = new System.Windows.Forms.Label();
//            this.label9 = new System.Windows.Forms.Label();
//            this.ovCMB_AlmoxarifadoEntrada = new MetroFramework.Controls.MetroComboBox();
//            this.label5 = new System.Windows.Forms.Label();
//            this.ovTXT_Status = new System.Windows.Forms.Label();
//            this.ovTXT_Ean = new System.Windows.Forms.Label();
//            this.editDecimalValorVenda = new PDV.UTIL.Components.Custom.EditDecimal();
//            this.button1 = new DevExpress.XtraEditors.SimpleButton();
//            this.ovCKB_IncluirItem = new System.Windows.Forms.CheckBox();
//            this.ovBTN_Localizar = new DevExpress.XtraEditors.SimpleButton();
//            this.ovTXT_ValorTotal = new System.Windows.Forms.Label();
//            this.ovTXT_QtdeSaida = new System.Windows.Forms.Label();
//            this.label12 = new System.Windows.Forms.Label();
//            this.label10 = new System.Windows.Forms.Label();
//            this.ovTXT_ValorCusto = new System.Windows.Forms.Label();
//            this.ovTXT_QtdeEntrada = new System.Windows.Forms.Label();
//            this.label2 = new System.Windows.Forms.Label();
//            this.label8 = new System.Windows.Forms.Label();
//            this.label3 = new System.Windows.Forms.Label();
//            this.label7 = new System.Windows.Forms.Label();
//            this.ovTXT_UNSaida = new System.Windows.Forms.Label();
//            this.label4 = new System.Windows.Forms.Label();
//            this.label6 = new System.Windows.Forms.Label();
//            this.ovCMB_FatorConversao = new MetroFramework.Controls.MetroComboBox();
//            this.ovTXT_UNEntrada = new System.Windows.Forms.Label();
//            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
//            this.ovCMB_Tributos_Origem = new MetroFramework.Controls.MetroComboBox();
//            this.lblInfCEST = new System.Windows.Forms.Label();
//            this.label15 = new System.Windows.Forms.Label();
//            this.ovCMB_IntegracaoNFCe = new MetroFramework.Controls.MetroComboBox();
//            this.label22 = new System.Windows.Forms.Label();
//            this.ovCMB_IntegracaoNFe = new MetroFramework.Controls.MetroComboBox();
//            this.label14 = new System.Windows.Forms.Label();
//            this.txtDescricaoProduto = new System.Windows.Forms.TextBox();
//            this.label16 = new System.Windows.Forms.Label();
//            this.metroTabControl2.SuspendLayout();
//            this.metroTabPage1.SuspendLayout();
//            this.groupBox1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_PercentualGanho)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.editDecimalValorVenda)).BeginInit();
//            this.metroTabPage3.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.BackColor = System.Drawing.Color.Transparent;
//            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
//            this.label1.Location = new System.Drawing.Point(9, 3);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(167, 13);
//            this.label1.TabIndex = 26;
//            this.label1.Text = "Descrição do Produto Fornecedor";
//            // 
//            // ovTXT_Produto
//            // 
//            this.ovTXT_Produto.BackColor = System.Drawing.Color.Transparent;
//            this.ovTXT_Produto.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.ovTXT_Produto.ForeColor = System.Drawing.Color.SteelBlue;
//            this.ovTXT_Produto.Location = new System.Drawing.Point(10, 19);
//            this.ovTXT_Produto.Name = "ovTXT_Produto";
//            this.ovTXT_Produto.Size = new System.Drawing.Size(443, 18);
//            this.ovTXT_Produto.TabIndex = 25;
//            this.ovTXT_Produto.Text = "ovTXT_Produto";
//            // 
//            // label11
//            // 
//            this.label11.BackColor = System.Drawing.Color.Silver;
//            this.label11.Location = new System.Drawing.Point(6, 174);
//            this.label11.Name = "label11";
//            this.label11.Size = new System.Drawing.Size(992, 3);
//            this.label11.TabIndex = 39;
//            // 
//            // metroTabControl2
//            // 
//            this.metroTabControl2.Controls.Add(this.metroTabPage1);
//            this.metroTabControl2.Controls.Add(this.metroTabPage3);
//            this.metroTabControl2.ItemSize = new System.Drawing.Size(60, 19);
//            this.metroTabControl2.Location = new System.Drawing.Point(3, 46);
//            this.metroTabControl2.Name = "metroTabControl2";
//            this.metroTabControl2.SelectedIndex = 0;
//            this.metroTabControl2.Size = new System.Drawing.Size(997, 128);
//            this.metroTabControl2.TabIndex = 133;
//            this.metroTabControl2.UseSelectable = true;
//            // 
//            // metroTabPage1
//            // 
//            this.metroTabPage1.Controls.Add(this.groupBox1);
//            this.metroTabPage1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
//            this.metroTabPage1.HorizontalScrollbarBarColor = true;
//            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
//            this.metroTabPage1.HorizontalScrollbarSize = 4;
//            this.metroTabPage1.Location = new System.Drawing.Point(4, 23);
//            this.metroTabPage1.Name = "metroTabPage1";
//            this.metroTabPage1.Size = new System.Drawing.Size(989, 101);
//            this.metroTabPage1.TabIndex = 2;
//            this.metroTabPage1.Text = "Produto";
//            this.metroTabPage1.VerticalScrollbarBarColor = true;
//            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
//            this.metroTabPage1.VerticalScrollbarSize = 7;
//            // 
//            // groupBox1
//            // 
//            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.groupBox1.Controls.Add(this.ovTXT_PercentualGanho);
//            this.groupBox1.Controls.Add(this.label13);
//            this.groupBox1.Controls.Add(this.label9);
//            this.groupBox1.Controls.Add(this.ovCMB_AlmoxarifadoEntrada);
//            this.groupBox1.Controls.Add(this.label5);
//            this.groupBox1.Controls.Add(this.ovTXT_Status);
//            this.groupBox1.Controls.Add(this.ovTXT_Ean);
//            this.groupBox1.Controls.Add(this.editDecimalValorVenda);
//            this.groupBox1.Controls.Add(this.button1);
//            this.groupBox1.Controls.Add(this.ovCKB_IncluirItem);
//            this.groupBox1.Controls.Add(this.ovBTN_Localizar);
//            this.groupBox1.Controls.Add(this.ovTXT_ValorTotal);
//            this.groupBox1.Controls.Add(this.ovTXT_QtdeSaida);
//            this.groupBox1.Controls.Add(this.label12);
//            this.groupBox1.Controls.Add(this.label10);
//            this.groupBox1.Controls.Add(this.ovTXT_ValorCusto);
//            this.groupBox1.Controls.Add(this.ovTXT_QtdeEntrada);
//            this.groupBox1.Controls.Add(this.label2);
//            this.groupBox1.Controls.Add(this.label8);
//            this.groupBox1.Controls.Add(this.label3);
//            this.groupBox1.Controls.Add(this.label7);
//            this.groupBox1.Controls.Add(this.ovTXT_UNSaida);
//            this.groupBox1.Controls.Add(this.label4);
//            this.groupBox1.Controls.Add(this.label6);
//            this.groupBox1.Controls.Add(this.ovCMB_FatorConversao);
//            this.groupBox1.Controls.Add(this.ovTXT_UNEntrada);
//            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.groupBox1.Location = new System.Drawing.Point(-2, 6);
//            this.groupBox1.Name = "groupBox1";
//            this.groupBox1.Size = new System.Drawing.Size(1000, 96);
//            this.groupBox1.TabIndex = 39;
//            this.groupBox1.TabStop = false;
//            this.groupBox1.Text = "Conversões de Unidade de Medida";
//            // 
//            // ovTXT_PercentualGanho
//            // 
//            this.ovTXT_PercentualGanho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            this.ovTXT_PercentualGanho.DecimalPlaces = 2;
//            this.ovTXT_PercentualGanho.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.ovTXT_PercentualGanho.Location = new System.Drawing.Point(476, 45);
//            this.ovTXT_PercentualGanho.Maximum = new decimal(new int[] {
//            -1530494977,
//            232830,
//            0,
//            131072});
//            this.ovTXT_PercentualGanho.Name = "ovTXT_PercentualGanho";
//            this.ovTXT_PercentualGanho.Sigla = "%";
//            this.ovTXT_PercentualGanho.Size = new System.Drawing.Size(98, 21);
//            this.ovTXT_PercentualGanho.TabIndex = 83;
//            this.ovTXT_PercentualGanho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
//            this.ovTXT_PercentualGanho.ThousandsSeparator = true;
//            this.ovTXT_PercentualGanho.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
//            this.ovTXT_PercentualGanho.vdValorDecimal = new decimal(new int[] {
//            0,
//            0,
//            0,
//            0});
//            this.ovTXT_PercentualGanho.viPrecisao = new decimal(new int[] {
//            2,
//            0,
//            0,
//            0});
//            this.ovTXT_PercentualGanho.viTamanho = new decimal(new int[] {
//            15,
//            0,
//            0,
//            0});
//            this.ovTXT_PercentualGanho.ValueChanged += new System.EventHandler(this.ovTXT_PercentualGanho_ValueChanged_1);
//            // 
//            // label13
//            // 
//            this.label13.AutoSize = true;
//            this.label13.BackColor = System.Drawing.Color.Transparent;
//            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.label13.Location = new System.Drawing.Point(433, 75);
//            this.label13.Name = "label13";
//            this.label13.Size = new System.Drawing.Size(41, 13);
//            this.label13.TabIndex = 84;
//            this.label13.Text = "Venda:";
//            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            // 
//            // label9
//            // 
//            this.label9.AutoSize = true;
//            this.label9.BackColor = System.Drawing.Color.Transparent;
//            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.label9.Location = new System.Drawing.Point(425, 49);
//            this.label9.Name = "label9";
//            this.label9.Size = new System.Drawing.Size(49, 13);
//            this.label9.TabIndex = 84;
//            this.label9.Text = "Margem:";
//            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            // 
//            // ovCMB_AlmoxarifadoEntrada
//            // 
//            this.ovCMB_AlmoxarifadoEntrada.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.ovCMB_AlmoxarifadoEntrada.FontSize = MetroFramework.MetroComboBoxSize.Small;
//            this.ovCMB_AlmoxarifadoEntrada.FormattingEnabled = true;
//            this.ovCMB_AlmoxarifadoEntrada.ItemHeight = 19;
//            this.ovCMB_AlmoxarifadoEntrada.Location = new System.Drawing.Point(592, 67);
//            this.ovCMB_AlmoxarifadoEntrada.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
//            this.ovCMB_AlmoxarifadoEntrada.Name = "ovCMB_AlmoxarifadoEntrada";
//            this.ovCMB_AlmoxarifadoEntrada.Size = new System.Drawing.Size(336, 25);
//            this.ovCMB_AlmoxarifadoEntrada.TabIndex = 42;
//            this.ovCMB_AlmoxarifadoEntrada.UseSelectable = true;
//            this.ovCMB_AlmoxarifadoEntrada.SelectedIndexChanged += new System.EventHandler(this.ovCMB_AlmoxarifadoEntrada_SelectedIndexChanged);
//            // 
//            // label5
//            // 
//            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.label5.AutoSize = true;
//            this.label5.BackColor = System.Drawing.Color.Transparent;
//            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
//            this.label5.Location = new System.Drawing.Point(589, 47);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(53, 13);
//            this.label5.TabIndex = 41;
//            this.label5.Text = "Depósito:";
//            // 
//            // ovTXT_Status
//            // 
//            this.ovTXT_Status.Anchor = System.Windows.Forms.AnchorStyles.Right;
//            this.ovTXT_Status.BackColor = System.Drawing.Color.Transparent;
//            this.ovTXT_Status.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.ovTXT_Status.ForeColor = System.Drawing.Color.Green;
//            this.ovTXT_Status.Location = new System.Drawing.Point(753, 16);
//            this.ovTXT_Status.Name = "ovTXT_Status";
//            this.ovTXT_Status.Size = new System.Drawing.Size(202, 28);
//            this.ovTXT_Status.TabIndex = 40;
//            this.ovTXT_Status.Text = "Item Localizado";
//            this.ovTXT_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            // 
//            // ovTXT_Ean
//            // 
//            this.ovTXT_Ean.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.ovTXT_Ean.AutoSize = true;
//            this.ovTXT_Ean.BackColor = System.Drawing.Color.Transparent;
//            this.ovTXT_Ean.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.ovTXT_Ean.Location = new System.Drawing.Point(643, 24);
//            this.ovTXT_Ean.Name = "ovTXT_Ean";
//            this.ovTXT_Ean.Size = new System.Drawing.Size(61, 13);
//            this.ovTXT_Ean.TabIndex = 30;
//            this.ovTXT_Ean.Text = "ovTXT_Ean";
//            // 
//            // editDecimalValorVenda
//            // 
//            this.editDecimalValorVenda.BackColor = System.Drawing.Color.LightGreen;
//            this.editDecimalValorVenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            this.editDecimalValorVenda.DecimalPlaces = 2;
//            this.editDecimalValorVenda.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.editDecimalValorVenda.Location = new System.Drawing.Point(476, 71);
//            this.editDecimalValorVenda.Maximum = new decimal(new int[] {
//            -1530494977,
//            232830,
//            0,
//            131072});
//            this.editDecimalValorVenda.Name = "editDecimalValorVenda";
//            this.editDecimalValorVenda.Sigla = "R$";
//            this.editDecimalValorVenda.Size = new System.Drawing.Size(98, 21);
//            this.editDecimalValorVenda.TabIndex = 44;
//            this.editDecimalValorVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
//            this.editDecimalValorVenda.ThousandsSeparator = true;
//            this.editDecimalValorVenda.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
//            this.editDecimalValorVenda.vdValorDecimal = new decimal(new int[] {
//            0,
//            0,
//            0,
//            0});
//            this.editDecimalValorVenda.viPrecisao = new decimal(new int[] {
//            2,
//            0,
//            0,
//            0});
//            this.editDecimalValorVenda.viTamanho = new decimal(new int[] {
//            15,
//            0,
//            0,
//            0});
//            this.editDecimalValorVenda.ValueChanged += new System.EventHandler(this.editDecimalValorVenda_ValueChanged_1);
//            // 
//            // button1
//            // 
//            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.button1.Location = new System.Drawing.Point(397, 19);
//            this.button1.Name = "button1";
//            this.button1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
//            this.button1.Size = new System.Drawing.Size(24, 23);
//            this.button1.TabIndex = 44;
//            this.button1.Click += new System.EventHandler(this.button1_Click_1);
//            // 
//            // ovCKB_IncluirItem
//            // 
//            this.ovCKB_IncluirItem.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.ovCKB_IncluirItem.AutoSize = true;
//            this.ovCKB_IncluirItem.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.ovCKB_IncluirItem.Location = new System.Drawing.Point(507, 24);
//            this.ovCKB_IncluirItem.Name = "ovCKB_IncluirItem";
//            this.ovCKB_IncluirItem.Size = new System.Drawing.Size(80, 17);
//            this.ovCKB_IncluirItem.TabIndex = 45;
//            this.ovCKB_IncluirItem.Text = "Incluir Item";
//            this.ovCKB_IncluirItem.UseVisualStyleBackColor = true;
//            this.ovCKB_IncluirItem.CheckedChanged += new System.EventHandler(this.ovCKB_IncluirItem_CheckedChanged_1);
//            // 
//            // ovBTN_Localizar
//            // 
//            this.ovBTN_Localizar.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.ovBTN_Localizar.Location = new System.Drawing.Point(425, 19);
//            this.ovBTN_Localizar.Name = "ovBTN_Localizar";
//            this.ovBTN_Localizar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
//            this.ovBTN_Localizar.Size = new System.Drawing.Size(77, 23);
//            this.ovBTN_Localizar.TabIndex = 43;
//            this.ovBTN_Localizar.Text = "Localizar";
//            this.ovBTN_Localizar.Click += new System.EventHandler(this.ovBTN_Localizar_Click_1);
//            // 
//            // ovTXT_ValorTotal
//            // 
//            this.ovTXT_ValorTotal.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.ovTXT_ValorTotal.BackColor = System.Drawing.Color.Transparent;
//            this.ovTXT_ValorTotal.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.ovTXT_ValorTotal.Location = new System.Drawing.Point(316, 77);
//            this.ovTXT_ValorTotal.Name = "ovTXT_ValorTotal";
//            this.ovTXT_ValorTotal.Size = new System.Drawing.Size(87, 15);
//            this.ovTXT_ValorTotal.TabIndex = 43;
//            this.ovTXT_ValorTotal.Text = "ovTXT_ValorTotal";
//            this.ovTXT_ValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            // 
//            // ovTXT_QtdeSaida
//            // 
//            this.ovTXT_QtdeSaida.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.ovTXT_QtdeSaida.BackColor = System.Drawing.Color.Transparent;
//            this.ovTXT_QtdeSaida.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.ovTXT_QtdeSaida.Location = new System.Drawing.Point(192, 77);
//            this.ovTXT_QtdeSaida.Name = "ovTXT_QtdeSaida";
//            this.ovTXT_QtdeSaida.Size = new System.Drawing.Size(63, 15);
//            this.ovTXT_QtdeSaida.TabIndex = 42;
//            this.ovTXT_QtdeSaida.Text = "ovTXT_QtdeSaida";
//            this.ovTXT_QtdeSaida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            // 
//            // label12
//            // 
//            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.label12.AutoSize = true;
//            this.label12.BackColor = System.Drawing.Color.Transparent;
//            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
//            this.label12.Location = new System.Drawing.Point(129, 77);
//            this.label12.Name = "label12";
//            this.label12.Size = new System.Drawing.Size(65, 13);
//            this.label12.TabIndex = 41;
//            this.label12.Text = "Qtd.  Saída:";
//            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            // 
//            // label10
//            // 
//            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.label10.AutoSize = true;
//            this.label10.BackColor = System.Drawing.Color.Transparent;
//            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
//            this.label10.Location = new System.Drawing.Point(589, 24);
//            this.label10.Name = "label10";
//            this.label10.Size = new System.Drawing.Size(31, 13);
//            this.label10.TabIndex = 29;
//            this.label10.Text = "EAN:";
//            // 
//            // ovTXT_ValorCusto
//            // 
//            this.ovTXT_ValorCusto.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.ovTXT_ValorCusto.BackColor = System.Drawing.Color.Transparent;
//            this.ovTXT_ValorCusto.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.ovTXT_ValorCusto.Location = new System.Drawing.Point(318, 49);
//            this.ovTXT_ValorCusto.Name = "ovTXT_ValorCusto";
//            this.ovTXT_ValorCusto.Size = new System.Drawing.Size(88, 15);
//            this.ovTXT_ValorCusto.TabIndex = 40;
//            this.ovTXT_ValorCusto.Text = "ovTXT_ValorCusto";
//            this.ovTXT_ValorCusto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            // 
//            // ovTXT_QtdeEntrada
//            // 
//            this.ovTXT_QtdeEntrada.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.ovTXT_QtdeEntrada.BackColor = System.Drawing.Color.Transparent;
//            this.ovTXT_QtdeEntrada.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.ovTXT_QtdeEntrada.Location = new System.Drawing.Point(192, 48);
//            this.ovTXT_QtdeEntrada.Name = "ovTXT_QtdeEntrada";
//            this.ovTXT_QtdeEntrada.Size = new System.Drawing.Size(76, 15);
//            this.ovTXT_QtdeEntrada.TabIndex = 39;
//            this.ovTXT_QtdeEntrada.Text = "ovTXT_QtdeEntrada";
//            this.ovTXT_QtdeEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            // 
//            // label2
//            // 
//            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.label2.AutoSize = true;
//            this.label2.BackColor = System.Drawing.Color.Transparent;
//            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
//            this.label2.Location = new System.Drawing.Point(3, 24);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(107, 13);
//            this.label2.TabIndex = 31;
//            this.label2.Text = "Fator de Conversão:";
//            // 
//            // label8
//            // 
//            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.label8.AutoSize = true;
//            this.label8.BackColor = System.Drawing.Color.Transparent;
//            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
//            this.label8.Location = new System.Drawing.Point(287, 77);
//            this.label8.Name = "label8";
//            this.label8.Size = new System.Drawing.Size(35, 13);
//            this.label8.TabIndex = 37;
//            this.label8.Text = "Total:";
//            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            // 
//            // label3
//            // 
//            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.label3.AutoSize = true;
//            this.label3.BackColor = System.Drawing.Color.Transparent;
//            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
//            this.label3.Location = new System.Drawing.Point(15, 77);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(57, 13);
//            this.label3.TabIndex = 33;
//            this.label3.Text = "Un. Saída:";
//            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            // 
//            // label7
//            // 
//            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.label7.AutoSize = true;
//            this.label7.BackColor = System.Drawing.Color.Transparent;
//            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
//            this.label7.Location = new System.Drawing.Point(274, 48);
//            this.label7.Name = "label7";
//            this.label7.Size = new System.Drawing.Size(48, 13);
//            this.label7.TabIndex = 36;
//            this.label7.Text = "Unitário:";
//            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            // 
//            // ovTXT_UNSaida
//            // 
//            this.ovTXT_UNSaida.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.ovTXT_UNSaida.BackColor = System.Drawing.Color.Transparent;
//            this.ovTXT_UNSaida.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.ovTXT_UNSaida.Location = new System.Drawing.Point(70, 76);
//            this.ovTXT_UNSaida.Name = "ovTXT_UNSaida";
//            this.ovTXT_UNSaida.Size = new System.Drawing.Size(43, 15);
//            this.ovTXT_UNSaida.TabIndex = 34;
//            this.ovTXT_UNSaida.Text = "ovTXT_UNSaida";
//            this.ovTXT_UNSaida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            // 
//            // label4
//            // 
//            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.label4.AutoSize = true;
//            this.label4.BackColor = System.Drawing.Color.Transparent;
//            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
//            this.label4.Location = new System.Drawing.Point(3, 48);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(69, 13);
//            this.label4.TabIndex = 27;
//            this.label4.Text = "Un. Entrada:";
//            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            // 
//            // label6
//            // 
//            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.label6.AutoSize = true;
//            this.label6.BackColor = System.Drawing.Color.Transparent;
//            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
//            this.label6.Location = new System.Drawing.Point(120, 48);
//            this.label6.Name = "label6";
//            this.label6.Size = new System.Drawing.Size(74, 13);
//            this.label6.TabIndex = 35;
//            this.label6.Text = "Qtd. Entrada:";
//            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            // 
//            // ovCMB_FatorConversao
//            // 
//            this.ovCMB_FatorConversao.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.ovCMB_FatorConversao.FontSize = MetroFramework.MetroComboBoxSize.Small;
//            this.ovCMB_FatorConversao.FormattingEnabled = true;
//            this.ovCMB_FatorConversao.ItemHeight = 19;
//            this.ovCMB_FatorConversao.Location = new System.Drawing.Point(111, 18);
//            this.ovCMB_FatorConversao.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
//            this.ovCMB_FatorConversao.Name = "ovCMB_FatorConversao";
//            this.ovCMB_FatorConversao.Size = new System.Drawing.Size(281, 25);
//            this.ovCMB_FatorConversao.TabIndex = 32;
//            this.ovCMB_FatorConversao.UseSelectable = true;
//            this.ovCMB_FatorConversao.SelectedIndexChanged += new System.EventHandler(this.ovCMB_FatorConversao_SelectedIndexChanged);
//            this.ovCMB_FatorConversao.SelectedValueChanged += new System.EventHandler(this.ovCMB_FatorConversao_SelectedValueChanged_1);
//            // 
//            // ovTXT_UNEntrada
//            // 
//            this.ovTXT_UNEntrada.Anchor = System.Windows.Forms.AnchorStyles.Left;
//            this.ovTXT_UNEntrada.BackColor = System.Drawing.Color.Transparent;
//            this.ovTXT_UNEntrada.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.ovTXT_UNEntrada.Location = new System.Drawing.Point(70, 48);
//            this.ovTXT_UNEntrada.Name = "ovTXT_UNEntrada";
//            this.ovTXT_UNEntrada.Size = new System.Drawing.Size(43, 15);
//            this.ovTXT_UNEntrada.TabIndex = 28;
//            this.ovTXT_UNEntrada.Text = "ovTXT_UMCompra";
//            this.ovTXT_UNEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            // 
//            // metroTabPage3
//            // 
//            this.metroTabPage3.Controls.Add(this.ovCMB_Tributos_Origem);
//            this.metroTabPage3.Controls.Add(this.lblInfCEST);
//            this.metroTabPage3.Controls.Add(this.label15);
//            this.metroTabPage3.Controls.Add(this.ovCMB_IntegracaoNFCe);
//            this.metroTabPage3.Controls.Add(this.label22);
//            this.metroTabPage3.Controls.Add(this.ovCMB_IntegracaoNFe);
//            this.metroTabPage3.Controls.Add(this.label14);
//            this.metroTabPage3.HorizontalScrollbarBarColor = true;
//            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
//            this.metroTabPage3.HorizontalScrollbarSize = 10;
//            this.metroTabPage3.Location = new System.Drawing.Point(4, 23);
//            this.metroTabPage3.Name = "metroTabPage3";
//            this.metroTabPage3.Size = new System.Drawing.Size(989, 101);
//            this.metroTabPage3.TabIndex = 4;
//            this.metroTabPage3.Text = "Regra Imposto";
//            this.metroTabPage3.VerticalScrollbarBarColor = true;
//            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
//            this.metroTabPage3.VerticalScrollbarSize = 10;
//            // 
//            // ovCMB_Tributos_Origem
//            // 
//            this.ovCMB_Tributos_Origem.DropDownWidth = 790;
//            this.ovCMB_Tributos_Origem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.ovCMB_Tributos_Origem.FontSize = MetroFramework.MetroComboBoxSize.Small;
//            this.ovCMB_Tributos_Origem.FormattingEnabled = true;
//            this.ovCMB_Tributos_Origem.ItemHeight = 19;
//            this.ovCMB_Tributos_Origem.Location = new System.Drawing.Point(329, 67);
//            this.ovCMB_Tributos_Origem.Name = "ovCMB_Tributos_Origem";
//            this.ovCMB_Tributos_Origem.Size = new System.Drawing.Size(51, 25);
//            this.ovCMB_Tributos_Origem.TabIndex = 74;
//            this.ovCMB_Tributos_Origem.UseSelectable = true;
//            this.ovCMB_Tributos_Origem.Visible = false;
//            // 
//            // lblInfCEST
//            // 
//            this.lblInfCEST.AutoSize = true;
//            this.lblInfCEST.BackColor = System.Drawing.Color.White;
//            this.lblInfCEST.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.lblInfCEST.Location = new System.Drawing.Point(326, 29);
//            this.lblInfCEST.Name = "lblInfCEST";
//            this.lblInfCEST.Size = new System.Drawing.Size(39, 13);
//            this.lblInfCEST.TabIndex = 75;
//            this.lblInfCEST.Text = "CEST: ";
//            // 
//            // label15
//            // 
//            this.label15.AutoSize = true;
//            this.label15.BackColor = System.Drawing.Color.White;
//            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.label15.Location = new System.Drawing.Point(326, 51);
//            this.label15.Name = "label15";
//            this.label15.Size = new System.Drawing.Size(54, 13);
//            this.label15.TabIndex = 75;
//            this.label15.Text = "* Origem:";
//            this.label15.Visible = false;
//            // 
//            // ovCMB_IntegracaoNFCe
//            // 
//            this.ovCMB_IntegracaoNFCe.DropDownWidth = 500;
//            this.ovCMB_IntegracaoNFCe.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.ovCMB_IntegracaoNFCe.FontSize = MetroFramework.MetroComboBoxSize.Small;
//            this.ovCMB_IntegracaoNFCe.FormattingEnabled = true;
//            this.ovCMB_IntegracaoNFCe.ItemHeight = 19;
//            this.ovCMB_IntegracaoNFCe.Location = new System.Drawing.Point(14, 70);
//            this.ovCMB_IntegracaoNFCe.Name = "ovCMB_IntegracaoNFCe";
//            this.ovCMB_IntegracaoNFCe.Size = new System.Drawing.Size(294, 25);
//            this.ovCMB_IntegracaoNFCe.TabIndex = 71;
//            this.ovCMB_IntegracaoNFCe.UseSelectable = true;
//            // 
//            // label22
//            // 
//            this.label22.AutoSize = true;
//            this.label22.BackColor = System.Drawing.Color.White;
//            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.label22.Location = new System.Drawing.Point(11, 51);
//            this.label22.Name = "label22";
//            this.label22.Size = new System.Drawing.Size(74, 13);
//            this.label22.TabIndex = 73;
//            this.label22.Text = "Integ. NFC-e:";
//            // 
//            // ovCMB_IntegracaoNFe
//            // 
//            this.ovCMB_IntegracaoNFe.DropDownWidth = 500;
//            this.ovCMB_IntegracaoNFe.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.ovCMB_IntegracaoNFe.FontSize = MetroFramework.MetroComboBoxSize.Small;
//            this.ovCMB_IntegracaoNFe.FormattingEnabled = true;
//            this.ovCMB_IntegracaoNFe.ItemHeight = 19;
//            this.ovCMB_IntegracaoNFe.Location = new System.Drawing.Point(14, 24);
//            this.ovCMB_IntegracaoNFe.Name = "ovCMB_IntegracaoNFe";
//            this.ovCMB_IntegracaoNFe.Size = new System.Drawing.Size(294, 25);
//            this.ovCMB_IntegracaoNFe.TabIndex = 70;
//            this.ovCMB_IntegracaoNFe.UseSelectable = true;
//            // 
//            // label14
//            // 
//            this.label14.AutoSize = true;
//            this.label14.BackColor = System.Drawing.Color.White;
//            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.label14.Location = new System.Drawing.Point(11, 5);
//            this.label14.Name = "label14";
//            this.label14.Size = new System.Drawing.Size(67, 13);
//            this.label14.TabIndex = 72;
//            this.label14.Text = "Integ. NF-e:";
//            // 
//            // txtDescricaoProduto
//            // 
//            this.txtDescricaoProduto.Location = new System.Drawing.Point(562, 19);
//            this.txtDescricaoProduto.Name = "txtDescricaoProduto";
//            this.txtDescricaoProduto.Size = new System.Drawing.Size(376, 20);
//            this.txtDescricaoProduto.TabIndex = 134;
//            // 
//            // label16
//            // 
//            this.label16.AutoSize = true;
//            this.label16.BackColor = System.Drawing.Color.Transparent;
//            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F);
//            this.label16.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
//            this.label16.Location = new System.Drawing.Point(559, 3);
//            this.label16.Name = "label16";
//            this.label16.Size = new System.Drawing.Size(149, 13);
//            this.label16.TabIndex = 26;
//            this.label16.Text = "Descrição do Produto Sistema";
//            this.label16.Click += new System.EventHandler(this.label16_Click);
//            // 
//            // UC_ItemNFeEntrada
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
//            this.BackColor = System.Drawing.Color.White;
//            this.Controls.Add(this.txtDescricaoProduto);
//            this.Controls.Add(this.metroTabControl2);
//            this.Controls.Add(this.label11);
//            this.Controls.Add(this.label16);
//            this.Controls.Add(this.label1);
//            this.Controls.Add(this.ovTXT_Produto);
//            this.Name = "UC_ItemNFeEntrada";
//            this.Size = new System.Drawing.Size(1023, 180);
//            this.Load += new System.EventHandler(this.UC_ItemNFeEntrada_Load);
//            this.metroTabControl2.ResumeLayout(false);
//            this.metroTabPage1.ResumeLayout(false);
//            this.groupBox1.ResumeLayout(false);
//            this.groupBox1.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_PercentualGanho)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.editDecimalValorVenda)).EndInit();
//            this.metroTabPage3.ResumeLayout(false);
//            this.metroTabPage3.PerformLayout();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Label ovTXT_Produto;
//        private System.Windows.Forms.Label label11;
//        private MetroFramework.Controls.MetroTabControl metroTabControl2;
//        private MetroFramework.Controls.MetroTabPage metroTabPage1;
//        private System.Windows.Forms.GroupBox groupBox1;
//        private UTIL.Components.Custom.EditDecimal ovTXT_PercentualGanho;
//        private System.Windows.Forms.Label label13;
//        private System.Windows.Forms.Label label9;
//        public MetroFramework.Controls.MetroComboBox ovCMB_AlmoxarifadoEntrada;
//        private System.Windows.Forms.Label label5;
//        private System.Windows.Forms.Label ovTXT_Status;
//        private System.Windows.Forms.Label ovTXT_Ean;
//        public UTIL.Components.Custom.EditDecimal editDecimalValorVenda;
//        private DevExpress.XtraEditors.SimpleButton button1;
//        public System.Windows.Forms.CheckBox ovCKB_IncluirItem;
//        private DevExpress.XtraEditors.SimpleButton ovBTN_Localizar;
//        private System.Windows.Forms.Label ovTXT_ValorTotal;
//        private System.Windows.Forms.Label ovTXT_QtdeSaida;
//        private System.Windows.Forms.Label label12;
//        private System.Windows.Forms.Label label10;
//        private System.Windows.Forms.Label ovTXT_ValorCusto;
//        private System.Windows.Forms.Label ovTXT_QtdeEntrada;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.Label label8;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.Label label7;
//        private System.Windows.Forms.Label ovTXT_UNSaida;
//        private System.Windows.Forms.Label label4;
//        private System.Windows.Forms.Label label6;
//        public MetroFramework.Controls.MetroComboBox ovCMB_FatorConversao;
//        private System.Windows.Forms.Label ovTXT_UNEntrada;
//        private MetroFramework.Controls.MetroTabPage metroTabPage3;
//        private System.Windows.Forms.Label label22;
//        private System.Windows.Forms.Label label14;
//        private System.Windows.Forms.Label label15;
//        public MetroFramework.Controls.MetroComboBox ovCMB_IntegracaoNFCe;
//        public MetroFramework.Controls.MetroComboBox ovCMB_IntegracaoNFe;
//        public MetroFramework.Controls.MetroComboBox ovCMB_Tributos_Origem;
//        private System.Windows.Forms.Label label16;
//        public System.Windows.Forms.TextBox txtDescricaoProduto;
//        private System.Windows.Forms.Label lblInfCEST;
//    }
//}
