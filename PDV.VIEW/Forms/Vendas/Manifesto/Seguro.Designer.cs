namespace PDV.VIEW.Forms.Vendas.Manifesto
{
    partial class Seguro
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Seguro));
            this.metroTabControl2 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage5 = new MetroFramework.Controls.MetroTabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ovCMB_Seguradora = new MetroFramework.Controls.MetroComboBox();
            this.ovTXT_NumeroApolice = new System.Windows.Forms.MaskedTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.ovCKB_ContratanteJuridica = new System.Windows.Forms.RadioButton();
            this.ovCKB_ContratanteFisica = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.ovTXT_CNPJCPFResponsavel = new System.Windows.Forms.MaskedTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.ovCMB_Responsavel = new MetroFramework.Controls.MetroComboBox();
            this.metroTabPage6 = new MetroFramework.Controls.MetroTabPage();
            this.ovGRD_Averbacoes = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.metroButton11 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton12 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ovTXT_Averbacao = new System.Windows.Forms.MaskedTextBox();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.metroTabControl2.SuspendLayout();
            this.metroTabPage5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.metroTabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Averbacoes)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl2
            // 
            this.metroTabControl2.Controls.Add(this.metroTabPage5);
            this.metroTabControl2.Controls.Add(this.metroTabPage6);
            this.metroTabControl2.Location = new System.Drawing.Point(23, 7);
            this.metroTabControl2.Name = "metroTabControl2";
            this.metroTabControl2.SelectedIndex = 1;
            this.metroTabControl2.Size = new System.Drawing.Size(754, 473);
            this.metroTabControl2.TabIndex = 100;
            this.metroTabControl2.UseSelectable = true;
            // 
            // metroTabPage5
            // 
            this.metroTabPage5.Controls.Add(this.groupBox1);
            this.metroTabPage5.Controls.Add(this.groupBox16);
            this.metroTabPage5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTabPage5.HorizontalScrollbarBarColor = true;
            this.metroTabPage5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage5.HorizontalScrollbarSize = 10;
            this.metroTabPage5.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage5.Name = "metroTabPage5";
            this.metroTabPage5.Size = new System.Drawing.Size(746, 431);
            this.metroTabPage5.TabIndex = 0;
            this.metroTabPage5.Text = "SEGURO DA CARGA";
            this.metroTabPage5.VerticalScrollbarBarColor = true;
            this.metroTabPage5.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage5.VerticalScrollbarSize = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ovCMB_Seguradora);
            this.groupBox1.Controls.Add(this.ovTXT_NumeroApolice);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Location = new System.Drawing.Point(3, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(740, 93);
            this.groupBox1.TabIndex = 114;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações da Seguradora";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 106;
            this.label3.Text = "* Seguradora:";
            // 
            // ovCMB_Seguradora
            // 
            this.ovCMB_Seguradora.DropDownWidth = 133;
            this.ovCMB_Seguradora.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_Seguradora.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_Seguradora.FormattingEnabled = true;
            this.ovCMB_Seguradora.ItemHeight = 19;
            this.ovCMB_Seguradora.Location = new System.Drawing.Point(115, 24);
            this.ovCMB_Seguradora.Name = "ovCMB_Seguradora";
            this.ovCMB_Seguradora.Size = new System.Drawing.Size(619, 25);
            this.ovCMB_Seguradora.TabIndex = 107;
            this.ovCMB_Seguradora.UseSelectable = true;
            // 
            // ovTXT_NumeroApolice
            // 
            this.ovTXT_NumeroApolice.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_NumeroApolice.Location = new System.Drawing.Point(115, 56);
            this.ovTXT_NumeroApolice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_NumeroApolice.Name = "ovTXT_NumeroApolice";
            this.ovTXT_NumeroApolice.Size = new System.Drawing.Size(445, 23);
            this.ovTXT_NumeroApolice.TabIndex = 111;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.White;
            this.label29.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label29.Location = new System.Drawing.Point(9, 59);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(76, 16);
            this.label29.TabIndex = 110;
            this.label29.Text = "Nº. Apolice:";
            // 
            // groupBox16
            // 
            this.groupBox16.BackColor = System.Drawing.Color.White;
            this.groupBox16.Controls.Add(this.ovCKB_ContratanteJuridica);
            this.groupBox16.Controls.Add(this.ovCKB_ContratanteFisica);
            this.groupBox16.Controls.Add(this.label4);
            this.groupBox16.Controls.Add(this.ovTXT_CNPJCPFResponsavel);
            this.groupBox16.Controls.Add(this.label19);
            this.groupBox16.Controls.Add(this.label18);
            this.groupBox16.Controls.Add(this.ovCMB_Responsavel);
            this.groupBox16.Location = new System.Drawing.Point(3, 3);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(740, 93);
            this.groupBox16.TabIndex = 3;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Responsável pelo Seguro da Carga";
            // 
            // ovCKB_ContratanteJuridica
            // 
            this.ovCKB_ContratanteJuridica.AutoSize = true;
            this.ovCKB_ContratanteJuridica.Location = new System.Drawing.Point(179, 55);
            this.ovCKB_ContratanteJuridica.Name = "ovCKB_ContratanteJuridica";
            this.ovCKB_ContratanteJuridica.Size = new System.Drawing.Size(69, 20);
            this.ovCKB_ContratanteJuridica.TabIndex = 112;
            this.ovCKB_ContratanteJuridica.Text = "Juridica";
            this.ovCKB_ContratanteJuridica.UseVisualStyleBackColor = true;
            this.ovCKB_ContratanteJuridica.CheckedChanged += new System.EventHandler(this.ovCKB_ContratanteJuridica_CheckedChanged);
            // 
            // ovCKB_ContratanteFisica
            // 
            this.ovCKB_ContratanteFisica.AutoSize = true;
            this.ovCKB_ContratanteFisica.Checked = true;
            this.ovCKB_ContratanteFisica.Location = new System.Drawing.Point(115, 55);
            this.ovCKB_ContratanteFisica.Name = "ovCKB_ContratanteFisica";
            this.ovCKB_ContratanteFisica.Size = new System.Drawing.Size(58, 20);
            this.ovCKB_ContratanteFisica.TabIndex = 111;
            this.ovCKB_ContratanteFisica.TabStop = true;
            this.ovCKB_ContratanteFisica.Text = "Fisica";
            this.ovCKB_ContratanteFisica.UseVisualStyleBackColor = true;
            this.ovCKB_ContratanteFisica.CheckedChanged += new System.EventHandler(this.ovCKB_ContratanteFisica_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 110;
            this.label4.Text = "* Tipo Pessoa:";
            // 
            // ovTXT_CNPJCPFResponsavel
            // 
            this.ovTXT_CNPJCPFResponsavel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_CNPJCPFResponsavel.Location = new System.Drawing.Point(341, 54);
            this.ovTXT_CNPJCPFResponsavel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_CNPJCPFResponsavel.Name = "ovTXT_CNPJCPFResponsavel";
            this.ovTXT_CNPJCPFResponsavel.Size = new System.Drawing.Size(229, 23);
            this.ovTXT_CNPJCPFResponsavel.TabIndex = 109;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.White;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(254, 57);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(85, 16);
            this.label19.TabIndex = 108;
            this.label19.Text = "* CPF/CNPJ:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(107, 16);
            this.label18.TabIndex = 106;
            this.label18.Text = "* Responsável:";
            // 
            // ovCMB_Responsavel
            // 
            this.ovCMB_Responsavel.DropDownWidth = 133;
            this.ovCMB_Responsavel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_Responsavel.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_Responsavel.FormattingEnabled = true;
            this.ovCMB_Responsavel.ItemHeight = 19;
            this.ovCMB_Responsavel.Location = new System.Drawing.Point(115, 24);
            this.ovCMB_Responsavel.Name = "ovCMB_Responsavel";
            this.ovCMB_Responsavel.Size = new System.Drawing.Size(619, 25);
            this.ovCMB_Responsavel.TabIndex = 107;
            this.ovCMB_Responsavel.UseSelectable = true;
            this.ovCMB_Responsavel.SelectedIndexChanged += new System.EventHandler(this.ovCMB_Responsavel_SelectedIndexChanged);
            // 
            // metroTabPage6
            // 
            this.metroTabPage6.Controls.Add(this.ovGRD_Averbacoes);
            this.metroTabPage6.Controls.Add(this.groupBox4);
            this.metroTabPage6.Controls.Add(this.groupBox7);
            this.metroTabPage6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTabPage6.HorizontalScrollbarBarColor = true;
            this.metroTabPage6.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage6.HorizontalScrollbarSize = 10;
            this.metroTabPage6.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage6.Name = "metroTabPage6";
            this.metroTabPage6.Size = new System.Drawing.Size(746, 431);
            this.metroTabPage6.TabIndex = 1;
            this.metroTabPage6.Text = "AVERBAÇÕES";
            this.metroTabPage6.VerticalScrollbarBarColor = true;
            this.metroTabPage6.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage6.VerticalScrollbarSize = 10;
            // 
            // ovGRD_Averbacoes
            // 
            this.ovGRD_Averbacoes.AllowUserToAddRows = false;
            this.ovGRD_Averbacoes.AllowUserToDeleteRows = false;
            this.ovGRD_Averbacoes.AllowUserToResizeColumns = false;
            this.ovGRD_Averbacoes.AllowUserToResizeRows = false;
            this.ovGRD_Averbacoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovGRD_Averbacoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ovGRD_Averbacoes.BackgroundColor = System.Drawing.Color.White;
            this.ovGRD_Averbacoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_Averbacoes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ovGRD_Averbacoes.ColumnHeadersHeight = 25;
            this.ovGRD_Averbacoes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ovGRD_Averbacoes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ovGRD_Averbacoes.Location = new System.Drawing.Point(2, 65);
            this.ovGRD_Averbacoes.Margin = new System.Windows.Forms.Padding(2);
            this.ovGRD_Averbacoes.MultiSelect = false;
            this.ovGRD_Averbacoes.Name = "ovGRD_Averbacoes";
            this.ovGRD_Averbacoes.ReadOnly = true;
            this.ovGRD_Averbacoes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.ovGRD_Averbacoes.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.ovGRD_Averbacoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ovGRD_Averbacoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ovGRD_Averbacoes.ShowCellErrors = false;
            this.ovGRD_Averbacoes.ShowEditingIcon = false;
            this.ovGRD_Averbacoes.ShowRowErrors = false;
            this.ovGRD_Averbacoes.Size = new System.Drawing.Size(742, 364);
            this.ovGRD_Averbacoes.TabIndex = 122;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.metroButton11);
            this.groupBox4.Controls.Add(this.metroButton12);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(523, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(220, 57);
            this.groupBox4.TabIndex = 121;
            this.groupBox4.TabStop = false;
            // 
            // metroButton11
            // 
            this.metroButton11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton11.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton11.Appearance.Options.UseForeColor = true;
            this.metroButton11.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton11.ImageOptions.Image")));
            this.metroButton11.Location = new System.Drawing.Point(116, 16);
            this.metroButton11.Name = "metroButton11";
            this.metroButton11.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton11.Size = new System.Drawing.Size(90, 28);
            this.metroButton11.TabIndex = 137;
            this.metroButton11.Text = "Remover";
            this.metroButton11.Click += new System.EventHandler(this.metroButton11_Click);
            // 
            // metroButton12
            // 
            this.metroButton12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton12.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton12.Appearance.Options.UseForeColor = true;
            this.metroButton12.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton12.ImageOptions.Image")));
            this.metroButton12.Location = new System.Drawing.Point(20, 16);
            this.metroButton12.Name = "metroButton12";
            this.metroButton12.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton12.Size = new System.Drawing.Size(90, 28);
            this.metroButton12.TabIndex = 136;
            this.metroButton12.Text = "Adicionar";
            this.metroButton12.Click += new System.EventHandler(this.metroButton12_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.White;
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.ovTXT_Averbacao);
            this.groupBox7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(3, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(514, 57);
            this.groupBox7.TabIndex = 120;
            this.groupBox7.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 112;
            this.label1.Text = "Nº. Averbação:";
            // 
            // ovTXT_Averbacao
            // 
            this.ovTXT_Averbacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Averbacao.Location = new System.Drawing.Point(107, 18);
            this.ovTXT_Averbacao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_Averbacao.Name = "ovTXT_Averbacao";
            this.ovTXT_Averbacao.Size = new System.Drawing.Size(401, 23);
            this.ovTXT_Averbacao.TabIndex = 113;
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(691, 555);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(97, 33);
            this.metroButton4.TabIndex = 135;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Appearance.Options.UseForeColor = true;
            this.metroButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton1.ImageOptions.Image")));
            this.metroButton1.Location = new System.Drawing.Point(588, 555);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton1.Size = new System.Drawing.Size(97, 33);
            this.metroButton1.TabIndex = 134;
            this.metroButton1.Text = "Cancelar";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // Seguro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroTabControl2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 639);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 639);
            this.Name = "Seguro";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seguro MDF-e";
            this.Load += new System.EventHandler(this.Seguro_Load);
            this.metroTabControl2.ResumeLayout(false);
            this.metroTabPage5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.metroTabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Averbacoes)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTabControl metroTabControl2;
        private MetroFramework.Controls.MetroTabPage metroTabPage5;
        private MetroFramework.Controls.MetroTabPage metroTabPage6;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.MaskedTextBox ovTXT_NumeroApolice;
        private System.Windows.Forms.Label label29;
        private MetroFramework.Controls.MetroComboBox ovCMB_Responsavel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RadioButton ovCKB_ContratanteJuridica;
        private System.Windows.Forms.RadioButton ovCKB_ContratanteFisica;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox ovTXT_CNPJCPFResponsavel;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroComboBox ovCMB_Seguradora;
        private System.Windows.Forms.MaskedTextBox ovTXT_Averbacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView ovGRD_Averbacoes;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton11;
        private DevExpress.XtraEditors.SimpleButton metroButton12;
        private DevExpress.XtraEditors.SimpleButton metroButton1;
    }
}