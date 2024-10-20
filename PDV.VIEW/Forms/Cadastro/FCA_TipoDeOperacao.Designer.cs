namespace PDV.VIEW.Forms.Vendas.NFe
{
    partial class FCA_TipoDeOperacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_TipoDeOperacao));
            this.ovLBL_Nome = new System.Windows.Forms.Label();
            this.ovTXT_Nome = new System.Windows.Forms.TextBox();
            this.ovLBL_Codigo = new System.Windows.Forms.Label();
            this.comboBoxOperacaoFiscal = new MetroFramework.Controls.MetroComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxFinalidade = new MetroFramework.Controls.MetroComboBox();
            this.ovLBL_Finalidade = new System.Windows.Forms.Label();
            this.comboBoxTipoAtendimento = new MetroFramework.Controls.MetroComboBox();
            this.ovLBL_TipoAtendimento = new System.Windows.Forms.Label();
            this.ovTXT_Codigo = new System.Windows.Forms.MaskedTextBox();
            this.ovLBL_ModeloDocumento = new System.Windows.Forms.Label();
            this.ovTXT_ModeloDocumento = new System.Windows.Forms.TextBox();
            this.ovLBL_Serie = new System.Windows.Forms.Label();
            this.ovTXT_Serie = new System.Windows.Forms.TextBox();
            this.checkBoxControlarEstoque = new System.Windows.Forms.CheckBox();
            this.checkBoxLimiteCredito = new System.Windows.Forms.CheckBox();
            this.checkBoxEstoqueNegativo = new System.Windows.Forms.CheckBox();
            this.ovTXT_InformacoesComplementares = new System.Windows.Forms.TextBox();
            this.ovLBL_InfomacoesComplementares = new System.Windows.Forms.Label();
            this.groupBoxFrete = new System.Windows.Forms.GroupBox();
            this.ovLBL_SemFrete = new System.Windows.Forms.RadioButton();
            this.ovLBL_FreteTerceiros = new System.Windows.Forms.RadioButton();
            this.ovLBL_FreteDestinatario = new System.Windows.Forms.RadioButton();
            this.ovLBL_FreteEmitente = new System.Windows.Forms.RadioButton();
            this.checkBoxGerarFinanceiro = new System.Windows.Forms.CheckBox();
            this.comboBoxTransportadora = new MetroFramework.Controls.MetroComboBox();
            this.labelTrasnportadora = new System.Windows.Forms.Label();
            this.metroButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.checkNaoInformaTransp = new System.Windows.Forms.CheckBox();
            this.comboBoxCentroCusto = new MetroFramework.Controls.MetroComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxHistoricoFinanceiro = new MetroFramework.Controls.MetroComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxContaBancaria = new MetroFramework.Controls.MetroComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioSaida = new System.Windows.Forms.RadioButton();
            this.radioEntrada = new System.Windows.Forms.RadioButton();
            this.buttonAdicionarTransportadora = new DevExpress.XtraEditors.SimpleButton();
            this.buttonAdicionarHistoricoFinanceiro = new DevExpress.XtraEditors.SimpleButton();
            this.buttonAdicionarCentroCusto = new DevExpress.XtraEditors.SimpleButton();
            this.buttonAdicionarContaBancaria = new DevExpress.XtraEditors.SimpleButton();
            this.buttonAdicionarCFOP = new DevExpress.XtraEditors.SimpleButton();
            this.groupBoxFrete.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ovLBL_Nome
            // 
            this.ovLBL_Nome.AutoSize = true;
            this.ovLBL_Nome.BackColor = System.Drawing.Color.White;
            this.ovLBL_Nome.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovLBL_Nome.Location = new System.Drawing.Point(112, 39);
            this.ovLBL_Nome.Name = "ovLBL_Nome";
            this.ovLBL_Nome.Size = new System.Drawing.Size(47, 13);
            this.ovLBL_Nome.TabIndex = 102;
            this.ovLBL_Nome.Text = "* Nome:";
            // 
            // ovTXT_Nome
            // 
            this.ovTXT_Nome.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Nome.Location = new System.Drawing.Point(165, 36);
            this.ovTXT_Nome.Name = "ovTXT_Nome";
            this.ovTXT_Nome.Size = new System.Drawing.Size(614, 21);
            this.ovTXT_Nome.TabIndex = 1;
            // 
            // ovLBL_Codigo
            // 
            this.ovLBL_Codigo.AutoSize = true;
            this.ovLBL_Codigo.BackColor = System.Drawing.Color.White;
            this.ovLBL_Codigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovLBL_Codigo.Location = new System.Drawing.Point(106, 12);
            this.ovLBL_Codigo.Name = "ovLBL_Codigo";
            this.ovLBL_Codigo.Size = new System.Drawing.Size(53, 13);
            this.ovLBL_Codigo.TabIndex = 101;
            this.ovLBL_Codigo.Text = "* Código:";
            // 
            // comboBoxOperacaoFiscal
            // 
            this.comboBoxOperacaoFiscal.DropDownWidth = 73;
            this.comboBoxOperacaoFiscal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxOperacaoFiscal.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.comboBoxOperacaoFiscal.FormattingEnabled = true;
            this.comboBoxOperacaoFiscal.ItemHeight = 19;
            this.comboBoxOperacaoFiscal.Location = new System.Drawing.Point(165, 63);
            this.comboBoxOperacaoFiscal.Name = "comboBoxOperacaoFiscal";
            this.comboBoxOperacaoFiscal.Size = new System.Drawing.Size(613, 25);
            this.comboBoxOperacaoFiscal.TabIndex = 4;
            this.comboBoxOperacaoFiscal.UseSelectable = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label14.Location = new System.Drawing.Point(63, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 13);
            this.label14.TabIndex = 108;
            this.label14.Text = "* Operação Fiscal:";
            // 
            // comboBoxFinalidade
            // 
            this.comboBoxFinalidade.DropDownWidth = 73;
            this.comboBoxFinalidade.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFinalidade.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.comboBoxFinalidade.FormattingEnabled = true;
            this.comboBoxFinalidade.ItemHeight = 19;
            this.comboBoxFinalidade.Location = new System.Drawing.Point(165, 247);
            this.comboBoxFinalidade.Name = "comboBoxFinalidade";
            this.comboBoxFinalidade.Size = new System.Drawing.Size(614, 25);
            this.comboBoxFinalidade.TabIndex = 6;
            this.comboBoxFinalidade.UseSelectable = true;
            // 
            // ovLBL_Finalidade
            // 
            this.ovLBL_Finalidade.AutoSize = true;
            this.ovLBL_Finalidade.BackColor = System.Drawing.Color.White;
            this.ovLBL_Finalidade.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovLBL_Finalidade.Location = new System.Drawing.Point(91, 252);
            this.ovLBL_Finalidade.Name = "ovLBL_Finalidade";
            this.ovLBL_Finalidade.Size = new System.Drawing.Size(68, 13);
            this.ovLBL_Finalidade.TabIndex = 110;
            this.ovLBL_Finalidade.Text = "* Finalidade:";
            // 
            // comboBoxTipoAtendimento
            // 
            this.comboBoxTipoAtendimento.DropDownWidth = 73;
            this.comboBoxTipoAtendimento.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipoAtendimento.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.comboBoxTipoAtendimento.FormattingEnabled = true;
            this.comboBoxTipoAtendimento.ItemHeight = 19;
            this.comboBoxTipoAtendimento.Location = new System.Drawing.Point(166, 216);
            this.comboBoxTipoAtendimento.Name = "comboBoxTipoAtendimento";
            this.comboBoxTipoAtendimento.Size = new System.Drawing.Size(613, 25);
            this.comboBoxTipoAtendimento.TabIndex = 7;
            this.comboBoxTipoAtendimento.UseSelectable = true;
            // 
            // ovLBL_TipoAtendimento
            // 
            this.ovLBL_TipoAtendimento.AutoSize = true;
            this.ovLBL_TipoAtendimento.BackColor = System.Drawing.Color.White;
            this.ovLBL_TipoAtendimento.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovLBL_TipoAtendimento.Location = new System.Drawing.Point(40, 221);
            this.ovLBL_TipoAtendimento.Name = "ovLBL_TipoAtendimento";
            this.ovLBL_TipoAtendimento.Size = new System.Drawing.Size(119, 13);
            this.ovLBL_TipoAtendimento.TabIndex = 112;
            this.ovLBL_TipoAtendimento.Text = "* Tipo de Atendimento:";
            // 
            // ovTXT_Codigo
            // 
            this.ovTXT_Codigo.Enabled = false;
            this.ovTXT_Codigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Codigo.Location = new System.Drawing.Point(165, 9);
            this.ovTXT_Codigo.Name = "ovTXT_Codigo";
            this.ovTXT_Codigo.ReadOnly = true;
            this.ovTXT_Codigo.Size = new System.Drawing.Size(614, 21);
            this.ovTXT_Codigo.TabIndex = 0;
            // 
            // ovLBL_ModeloDocumento
            // 
            this.ovLBL_ModeloDocumento.AutoSize = true;
            this.ovLBL_ModeloDocumento.BackColor = System.Drawing.Color.White;
            this.ovLBL_ModeloDocumento.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovLBL_ModeloDocumento.Location = new System.Drawing.Point(43, 308);
            this.ovLBL_ModeloDocumento.Name = "ovLBL_ModeloDocumento";
            this.ovLBL_ModeloDocumento.Size = new System.Drawing.Size(116, 13);
            this.ovLBL_ModeloDocumento.TabIndex = 117;
            this.ovLBL_ModeloDocumento.Text = "* Mod. de Documento:";
            // 
            // ovTXT_ModeloDocumento
            // 
            this.ovTXT_ModeloDocumento.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_ModeloDocumento.Location = new System.Drawing.Point(166, 305);
            this.ovTXT_ModeloDocumento.Name = "ovTXT_ModeloDocumento";
            this.ovTXT_ModeloDocumento.Size = new System.Drawing.Size(613, 21);
            this.ovTXT_ModeloDocumento.TabIndex = 2;
            // 
            // ovLBL_Serie
            // 
            this.ovLBL_Serie.AutoSize = true;
            this.ovLBL_Serie.BackColor = System.Drawing.Color.White;
            this.ovLBL_Serie.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovLBL_Serie.Location = new System.Drawing.Point(114, 335);
            this.ovLBL_Serie.Name = "ovLBL_Serie";
            this.ovLBL_Serie.Size = new System.Drawing.Size(44, 13);
            this.ovLBL_Serie.TabIndex = 119;
            this.ovLBL_Serie.Text = "* Série:";
            // 
            // ovTXT_Serie
            // 
            this.ovTXT_Serie.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Serie.Location = new System.Drawing.Point(166, 332);
            this.ovTXT_Serie.Name = "ovTXT_Serie";
            this.ovTXT_Serie.Size = new System.Drawing.Size(612, 21);
            this.ovTXT_Serie.TabIndex = 3;
            // 
            // checkBoxControlarEstoque
            // 
            this.checkBoxControlarEstoque.AutoSize = true;
            this.checkBoxControlarEstoque.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBoxControlarEstoque.Location = new System.Drawing.Point(326, 396);
            this.checkBoxControlarEstoque.Name = "checkBoxControlarEstoque";
            this.checkBoxControlarEstoque.Size = new System.Drawing.Size(113, 17);
            this.checkBoxControlarEstoque.TabIndex = 10;
            this.checkBoxControlarEstoque.Text = "Controlar Estoque";
            this.checkBoxControlarEstoque.UseVisualStyleBackColor = true;
            // 
            // checkBoxLimiteCredito
            // 
            this.checkBoxLimiteCredito.AutoSize = true;
            this.checkBoxLimiteCredito.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBoxLimiteCredito.Location = new System.Drawing.Point(29, 396);
            this.checkBoxLimiteCredito.Name = "checkBoxLimiteCredito";
            this.checkBoxLimiteCredito.Size = new System.Drawing.Size(135, 17);
            this.checkBoxLimiteCredito.TabIndex = 12;
            this.checkBoxLimiteCredito.Text = "Exige Limite de Crédito";
            this.checkBoxLimiteCredito.UseVisualStyleBackColor = true;
            // 
            // checkBoxEstoqueNegativo
            // 
            this.checkBoxEstoqueNegativo.AutoSize = true;
            this.checkBoxEstoqueNegativo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBoxEstoqueNegativo.Location = new System.Drawing.Point(170, 396);
            this.checkBoxEstoqueNegativo.Name = "checkBoxEstoqueNegativo";
            this.checkBoxEstoqueNegativo.Size = new System.Drawing.Size(150, 17);
            this.checkBoxEstoqueNegativo.TabIndex = 13;
            this.checkBoxEstoqueNegativo.Text = "Permite Estoque Negativo";
            this.checkBoxEstoqueNegativo.UseVisualStyleBackColor = true;
            // 
            // ovTXT_InformacoesComplementares
            // 
            this.ovTXT_InformacoesComplementares.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_InformacoesComplementares.Location = new System.Drawing.Point(165, 278);
            this.ovTXT_InformacoesComplementares.Name = "ovTXT_InformacoesComplementares";
            this.ovTXT_InformacoesComplementares.Size = new System.Drawing.Size(614, 21);
            this.ovTXT_InformacoesComplementares.TabIndex = 9;
            // 
            // ovLBL_InfomacoesComplementares
            // 
            this.ovLBL_InfomacoesComplementares.AutoSize = true;
            this.ovLBL_InfomacoesComplementares.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ovLBL_InfomacoesComplementares.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovLBL_InfomacoesComplementares.Location = new System.Drawing.Point(16, 278);
            this.ovLBL_InfomacoesComplementares.Name = "ovLBL_InfomacoesComplementares";
            this.ovLBL_InfomacoesComplementares.Size = new System.Drawing.Size(143, 13);
            this.ovLBL_InfomacoesComplementares.TabIndex = 124;
            this.ovLBL_InfomacoesComplementares.Text = "Informações Complementar:";
            // 
            // groupBoxFrete
            // 
            this.groupBoxFrete.Controls.Add(this.ovLBL_SemFrete);
            this.groupBoxFrete.Controls.Add(this.ovLBL_FreteTerceiros);
            this.groupBoxFrete.Controls.Add(this.ovLBL_FreteDestinatario);
            this.groupBoxFrete.Controls.Add(this.ovLBL_FreteEmitente);
            this.groupBoxFrete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFrete.Location = new System.Drawing.Point(29, 432);
            this.groupBoxFrete.Name = "groupBoxFrete";
            this.groupBoxFrete.Size = new System.Drawing.Size(245, 70);
            this.groupBoxFrete.TabIndex = 125;
            this.groupBoxFrete.TabStop = false;
            this.groupBoxFrete.Text = "Frete Por Conta";
            // 
            // ovLBL_SemFrete
            // 
            this.ovLBL_SemFrete.AutoSize = true;
            this.ovLBL_SemFrete.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovLBL_SemFrete.Location = new System.Drawing.Point(132, 42);
            this.ovLBL_SemFrete.Name = "ovLBL_SemFrete";
            this.ovLBL_SemFrete.Size = new System.Drawing.Size(90, 17);
            this.ovLBL_SemFrete.TabIndex = 14;
            this.ovLBL_SemFrete.TabStop = true;
            this.ovLBL_SemFrete.Text = "9 - Sem Frete";
            this.ovLBL_SemFrete.UseVisualStyleBackColor = true;
            // 
            // ovLBL_FreteTerceiros
            // 
            this.ovLBL_FreteTerceiros.AutoSize = true;
            this.ovLBL_FreteTerceiros.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovLBL_FreteTerceiros.Location = new System.Drawing.Point(15, 42);
            this.ovLBL_FreteTerceiros.Name = "ovLBL_FreteTerceiros";
            this.ovLBL_FreteTerceiros.Size = new System.Drawing.Size(85, 17);
            this.ovLBL_FreteTerceiros.TabIndex = 13;
            this.ovLBL_FreteTerceiros.TabStop = true;
            this.ovLBL_FreteTerceiros.Text = "2 - Terceiros";
            this.ovLBL_FreteTerceiros.UseVisualStyleBackColor = true;
            // 
            // ovLBL_FreteDestinatario
            // 
            this.ovLBL_FreteDestinatario.AutoSize = true;
            this.ovLBL_FreteDestinatario.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovLBL_FreteDestinatario.Location = new System.Drawing.Point(132, 18);
            this.ovLBL_FreteDestinatario.Name = "ovLBL_FreteDestinatario";
            this.ovLBL_FreteDestinatario.Size = new System.Drawing.Size(99, 17);
            this.ovLBL_FreteDestinatario.TabIndex = 12;
            this.ovLBL_FreteDestinatario.TabStop = true;
            this.ovLBL_FreteDestinatario.Text = "1 - Destinatário";
            this.ovLBL_FreteDestinatario.UseVisualStyleBackColor = true;
            // 
            // ovLBL_FreteEmitente
            // 
            this.ovLBL_FreteEmitente.AutoSize = true;
            this.ovLBL_FreteEmitente.Checked = true;
            this.ovLBL_FreteEmitente.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovLBL_FreteEmitente.Location = new System.Drawing.Point(15, 18);
            this.ovLBL_FreteEmitente.Name = "ovLBL_FreteEmitente";
            this.ovLBL_FreteEmitente.Size = new System.Drawing.Size(83, 17);
            this.ovLBL_FreteEmitente.TabIndex = 11;
            this.ovLBL_FreteEmitente.TabStop = true;
            this.ovLBL_FreteEmitente.Text = "0 - Emitente";
            this.ovLBL_FreteEmitente.UseVisualStyleBackColor = true;
            // 
            // checkBoxGerarFinanceiro
            // 
            this.checkBoxGerarFinanceiro.AutoSize = true;
            this.checkBoxGerarFinanceiro.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBoxGerarFinanceiro.Location = new System.Drawing.Point(445, 396);
            this.checkBoxGerarFinanceiro.Name = "checkBoxGerarFinanceiro";
            this.checkBoxGerarFinanceiro.Size = new System.Drawing.Size(105, 17);
            this.checkBoxGerarFinanceiro.TabIndex = 11;
            this.checkBoxGerarFinanceiro.Text = "Gerar Financeiro";
            this.checkBoxGerarFinanceiro.UseVisualStyleBackColor = true;
            // 
            // comboBoxTransportadora
            // 
            this.comboBoxTransportadora.DropDownWidth = 73;
            this.comboBoxTransportadora.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTransportadora.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.comboBoxTransportadora.FormattingEnabled = true;
            this.comboBoxTransportadora.ItemHeight = 19;
            this.comboBoxTransportadora.Location = new System.Drawing.Point(165, 94);
            this.comboBoxTransportadora.Name = "comboBoxTransportadora";
            this.comboBoxTransportadora.Size = new System.Drawing.Size(613, 25);
            this.comboBoxTransportadora.TabIndex = 8;
            this.comboBoxTransportadora.UseSelectable = true;
            this.comboBoxTransportadora.SelectedIndexChanged += new System.EventHandler(this.comboBoxTransportadora_SelectedIndexChanged);
            // 
            // labelTrasnportadora
            // 
            this.labelTrasnportadora.AutoSize = true;
            this.labelTrasnportadora.BackColor = System.Drawing.Color.White;
            this.labelTrasnportadora.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelTrasnportadora.Location = new System.Drawing.Point(73, 96);
            this.labelTrasnportadora.Name = "labelTrasnportadora";
            this.labelTrasnportadora.Size = new System.Drawing.Size(86, 13);
            this.labelTrasnportadora.TabIndex = 128;
            this.labelTrasnportadora.Text = "Transportadora:";
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Appearance.Options.UseForeColor = true;
            this.metroButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton1.ImageOptions.Image")));
            this.metroButton1.Location = new System.Drawing.Point(669, 553);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton1.Size = new System.Drawing.Size(88, 33);
            this.metroButton1.TabIndex = 129;
            this.metroButton1.Text = "Cancelar";
            this.metroButton1.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(763, 553);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(77, 33);
            this.metroButton4.TabIndex = 141;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.ovBTN_Salvar_Click);
            // 
            // checkNaoInformaTransp
            // 
            this.checkNaoInformaTransp.AutoSize = true;
            this.checkNaoInformaTransp.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkNaoInformaTransp.Location = new System.Drawing.Point(556, 396);
            this.checkNaoInformaTransp.Name = "checkNaoInformaTransp";
            this.checkNaoInformaTransp.Size = new System.Drawing.Size(162, 17);
            this.checkNaoInformaTransp.TabIndex = 142;
            this.checkNaoInformaTransp.Text = "Não informa Transportadora";
            this.checkNaoInformaTransp.UseVisualStyleBackColor = true;
            this.checkNaoInformaTransp.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBoxCentroCusto
            // 
            this.comboBoxCentroCusto.DropDownWidth = 73;
            this.comboBoxCentroCusto.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCentroCusto.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.comboBoxCentroCusto.FormattingEnabled = true;
            this.comboBoxCentroCusto.ItemHeight = 19;
            this.comboBoxCentroCusto.Location = new System.Drawing.Point(165, 125);
            this.comboBoxCentroCusto.Name = "comboBoxCentroCusto";
            this.comboBoxCentroCusto.Size = new System.Drawing.Size(613, 25);
            this.comboBoxCentroCusto.TabIndex = 143;
            this.comboBoxCentroCusto.UseSelectable = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(60, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 144;
            this.label2.Text = "* Centro de Custo:";
            // 
            // comboBoxHistoricoFinanceiro
            // 
            this.comboBoxHistoricoFinanceiro.DropDownWidth = 73;
            this.comboBoxHistoricoFinanceiro.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxHistoricoFinanceiro.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.comboBoxHistoricoFinanceiro.FormattingEnabled = true;
            this.comboBoxHistoricoFinanceiro.ItemHeight = 19;
            this.comboBoxHistoricoFinanceiro.Location = new System.Drawing.Point(165, 156);
            this.comboBoxHistoricoFinanceiro.Name = "comboBoxHistoricoFinanceiro";
            this.comboBoxHistoricoFinanceiro.Size = new System.Drawing.Size(613, 25);
            this.comboBoxHistoricoFinanceiro.TabIndex = 147;
            this.comboBoxHistoricoFinanceiro.UseSelectable = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(46, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 148;
            this.label3.Text = "* Histórico Financeiro:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(66, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 150;
            this.label4.Text = "* Conta Bancária:";
            // 
            // comboBoxContaBancaria
            // 
            this.comboBoxContaBancaria.DropDownWidth = 73;
            this.comboBoxContaBancaria.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxContaBancaria.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.comboBoxContaBancaria.FormattingEnabled = true;
            this.comboBoxContaBancaria.ItemHeight = 19;
            this.comboBoxContaBancaria.Location = new System.Drawing.Point(165, 185);
            this.comboBoxContaBancaria.Name = "comboBoxContaBancaria";
            this.comboBoxContaBancaria.Size = new System.Drawing.Size(613, 25);
            this.comboBoxContaBancaria.TabIndex = 149;
            this.comboBoxContaBancaria.UseSelectable = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioSaida);
            this.groupBox1.Controls.Add(this.radioEntrada);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(280, 432);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 70);
            this.groupBox1.TabIndex = 126;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Movimento";
            // 
            // radioSaida
            // 
            this.radioSaida.AutoSize = true;
            this.radioSaida.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radioSaida.Location = new System.Drawing.Point(15, 42);
            this.radioSaida.Name = "radioSaida";
            this.radioSaida.Size = new System.Drawing.Size(51, 17);
            this.radioSaida.TabIndex = 13;
            this.radioSaida.TabStop = true;
            this.radioSaida.Text = "Saida";
            this.radioSaida.UseVisualStyleBackColor = true;
            // 
            // radioEntrada
            // 
            this.radioEntrada.AutoSize = true;
            this.radioEntrada.Checked = true;
            this.radioEntrada.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radioEntrada.Location = new System.Drawing.Point(15, 18);
            this.radioEntrada.Name = "radioEntrada";
            this.radioEntrada.Size = new System.Drawing.Size(63, 17);
            this.radioEntrada.TabIndex = 11;
            this.radioEntrada.TabStop = true;
            this.radioEntrada.Text = "Entrada";
            this.radioEntrada.UseVisualStyleBackColor = true;
            this.radioEntrada.CheckedChanged += new System.EventHandler(this.radioEntrada_CheckedChanged);
            // 
            // buttonAdicionarTransportadora
            // 
            this.buttonAdicionarTransportadora.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdicionarTransportadora.ImageOptions.Image")));
            this.buttonAdicionarTransportadora.Location = new System.Drawing.Point(784, 96);
            this.buttonAdicionarTransportadora.Name = "buttonAdicionarTransportadora";
            this.buttonAdicionarTransportadora.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.buttonAdicionarTransportadora.Size = new System.Drawing.Size(21, 23);
            this.buttonAdicionarTransportadora.TabIndex = 153;
            this.buttonAdicionarTransportadora.Click += new System.EventHandler(this.btnAddTransportadora_Click);
            // 
            // buttonAdicionarHistoricoFinanceiro
            // 
            this.buttonAdicionarHistoricoFinanceiro.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdicionarHistoricoFinanceiro.ImageOptions.Image")));
            this.buttonAdicionarHistoricoFinanceiro.Location = new System.Drawing.Point(784, 156);
            this.buttonAdicionarHistoricoFinanceiro.Name = "buttonAdicionarHistoricoFinanceiro";
            this.buttonAdicionarHistoricoFinanceiro.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.buttonAdicionarHistoricoFinanceiro.Size = new System.Drawing.Size(21, 23);
            this.buttonAdicionarHistoricoFinanceiro.TabIndex = 154;
            this.buttonAdicionarHistoricoFinanceiro.Click += new System.EventHandler(this.btnAddHistorico_Click);
            // 
            // buttonAdicionarCentroCusto
            // 
            this.buttonAdicionarCentroCusto.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdicionarCentroCusto.ImageOptions.Image")));
            this.buttonAdicionarCentroCusto.Location = new System.Drawing.Point(784, 125);
            this.buttonAdicionarCentroCusto.Name = "buttonAdicionarCentroCusto";
            this.buttonAdicionarCentroCusto.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.buttonAdicionarCentroCusto.Size = new System.Drawing.Size(21, 23);
            this.buttonAdicionarCentroCusto.TabIndex = 155;
            this.buttonAdicionarCentroCusto.Click += new System.EventHandler(this.btnAddTipoTitulo_Click);
            // 
            // buttonAdicionarContaBancaria
            // 
            this.buttonAdicionarContaBancaria.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdicionarContaBancaria.ImageOptions.Image")));
            this.buttonAdicionarContaBancaria.Location = new System.Drawing.Point(784, 185);
            this.buttonAdicionarContaBancaria.Name = "buttonAdicionarContaBancaria";
            this.buttonAdicionarContaBancaria.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.buttonAdicionarContaBancaria.Size = new System.Drawing.Size(21, 23);
            this.buttonAdicionarContaBancaria.TabIndex = 156;
            this.buttonAdicionarContaBancaria.Click += new System.EventHandler(this.btnAddContaBancaria_Click);
            // 
            // buttonAdicionarCFOP
            // 
            this.buttonAdicionarCFOP.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdicionarCFOP.ImageOptions.Image")));
            this.buttonAdicionarCFOP.Location = new System.Drawing.Point(784, 63);
            this.buttonAdicionarCFOP.Name = "buttonAdicionarCFOP";
            this.buttonAdicionarCFOP.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.buttonAdicionarCFOP.Size = new System.Drawing.Size(21, 23);
            this.buttonAdicionarCFOP.TabIndex = 158;
            this.buttonAdicionarCFOP.Click += new System.EventHandler(this.btnOperaçãoFiscal_Click);
            // 
            // FCA_TipoDeOperacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 598);
            this.Controls.Add(this.buttonAdicionarCFOP);
            this.Controls.Add(this.buttonAdicionarContaBancaria);
            this.Controls.Add(this.buttonAdicionarCentroCusto);
            this.Controls.Add(this.buttonAdicionarHistoricoFinanceiro);
            this.Controls.Add(this.buttonAdicionarTransportadora);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxContaBancaria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxCentroCusto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkNaoInformaTransp);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.labelTrasnportadora);
            this.Controls.Add(this.checkBoxGerarFinanceiro);
            this.Controls.Add(this.groupBoxFrete);
            this.Controls.Add(this.ovLBL_InfomacoesComplementares);
            this.Controls.Add(this.ovTXT_InformacoesComplementares);
            this.Controls.Add(this.checkBoxEstoqueNegativo);
            this.Controls.Add(this.checkBoxLimiteCredito);
            this.Controls.Add(this.checkBoxControlarEstoque);
            this.Controls.Add(this.ovLBL_Serie);
            this.Controls.Add(this.ovTXT_Serie);
            this.Controls.Add(this.ovLBL_ModeloDocumento);
            this.Controls.Add(this.ovTXT_ModeloDocumento);
            this.Controls.Add(this.comboBoxTipoAtendimento);
            this.Controls.Add(this.ovLBL_TipoAtendimento);
            this.Controls.Add(this.comboBoxFinalidade);
            this.Controls.Add(this.ovLBL_Finalidade);
            this.Controls.Add(this.comboBoxOperacaoFiscal);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.ovTXT_Codigo);
            this.Controls.Add(this.ovLBL_Nome);
            this.Controls.Add(this.ovTXT_Nome);
            this.Controls.Add(this.ovLBL_Codigo);
            this.Controls.Add(this.comboBoxHistoricoFinanceiro);
            this.Controls.Add(this.comboBoxTransportadora);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCA_TipoDeOperacao";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Tipo de Operação";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_TipoDeOperacao_KeyDown);
            this.groupBoxFrete.ResumeLayout(false);
            this.groupBoxFrete.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ovLBL_Nome;
        private System.Windows.Forms.TextBox ovTXT_Nome;
        private System.Windows.Forms.Label ovLBL_Codigo;
        private MetroFramework.Controls.MetroComboBox comboBoxOperacaoFiscal;
        private System.Windows.Forms.Label label14;
        private MetroFramework.Controls.MetroComboBox comboBoxFinalidade;
        private System.Windows.Forms.Label ovLBL_Finalidade;
        private MetroFramework.Controls.MetroComboBox comboBoxTipoAtendimento;
        private System.Windows.Forms.Label ovLBL_TipoAtendimento;
        private System.Windows.Forms.MaskedTextBox ovTXT_Codigo;
        private System.Windows.Forms.Label ovLBL_ModeloDocumento;
        private System.Windows.Forms.TextBox ovTXT_ModeloDocumento;
        private System.Windows.Forms.Label ovLBL_Serie;
        private System.Windows.Forms.TextBox ovTXT_Serie;
        private System.Windows.Forms.CheckBox checkBoxControlarEstoque;
        private System.Windows.Forms.CheckBox checkBoxLimiteCredito;
        private System.Windows.Forms.CheckBox checkBoxEstoqueNegativo;
        private System.Windows.Forms.TextBox ovTXT_InformacoesComplementares;
        private System.Windows.Forms.Label ovLBL_InfomacoesComplementares;
        private System.Windows.Forms.GroupBox groupBoxFrete;
        private System.Windows.Forms.RadioButton ovLBL_SemFrete;
        private System.Windows.Forms.RadioButton ovLBL_FreteTerceiros;
        private System.Windows.Forms.RadioButton ovLBL_FreteDestinatario;
        private System.Windows.Forms.RadioButton ovLBL_FreteEmitente;
        private System.Windows.Forms.CheckBox checkBoxGerarFinanceiro;
        private MetroFramework.Controls.MetroComboBox comboBoxTransportadora;
        private System.Windows.Forms.Label labelTrasnportadora;
        private DevExpress.XtraEditors.SimpleButton metroButton1;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private System.Windows.Forms.CheckBox checkNaoInformaTransp;
        private MetroFramework.Controls.MetroComboBox comboBoxCentroCusto;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroComboBox comboBoxHistoricoFinanceiro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroComboBox comboBoxContaBancaria;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioSaida;
        private System.Windows.Forms.RadioButton radioEntrada;
        private DevExpress.XtraEditors.SimpleButton buttonAdicionarTransportadora;
        private DevExpress.XtraEditors.SimpleButton buttonAdicionarHistoricoFinanceiro;
        private DevExpress.XtraEditors.SimpleButton buttonAdicionarCentroCusto;
        private DevExpress.XtraEditors.SimpleButton buttonAdicionarContaBancaria;
        private DevExpress.XtraEditors.SimpleButton buttonAdicionarCFOP;
    }
}