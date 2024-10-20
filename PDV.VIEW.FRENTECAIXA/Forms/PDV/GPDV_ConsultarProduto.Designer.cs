namespace PDV.VIEW.FRENTECAIXA.Forms.PDV
{
    partial class GPDV_ConsultarProduto
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ovTXT_DescricaoProduto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ovTXT_Marca = new System.Windows.Forms.TextBox();
            this.ovTXT_UnidadeMedida = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ovTXT_ValorUnitario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.ovTXT_CodigoBarrasProduto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ovTXT_StatusConsulta = new System.Windows.Forms.Label();
            this.ovGRD_Produtos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ovTXT_CodigoBarras = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Saida_Tela = new System.Windows.Forms.Label();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Produtos)).BeginInit();
            this.SuspendLayout();
            // 
            // ovTXT_DescricaoProduto
            // 
            this.ovTXT_DescricaoProduto.BackColor = System.Drawing.Color.White;
            this.ovTXT_DescricaoProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_DescricaoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_DescricaoProduto.ForeColor = System.Drawing.Color.Black;
            this.ovTXT_DescricaoProduto.Location = new System.Drawing.Point(206, 150);
            this.ovTXT_DescricaoProduto.Margin = new System.Windows.Forms.Padding(2);
            this.ovTXT_DescricaoProduto.Name = "ovTXT_DescricaoProduto";
            this.ovTXT_DescricaoProduto.ReadOnly = true;
            this.ovTXT_DescricaoProduto.ShortcutsEnabled = false;
            this.ovTXT_DescricaoProduto.Size = new System.Drawing.Size(522, 31);
            this.ovTXT_DescricaoProduto.TabIndex = 102;
            this.ovTXT_DescricaoProduto.TabStop = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(142, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 101;
            this.label7.Text = "Marca:";
            // 
            // ovTXT_Marca
            // 
            this.ovTXT_Marca.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_Marca.BackColor = System.Drawing.Color.White;
            this.ovTXT_Marca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_Marca.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Marca.ForeColor = System.Drawing.Color.Black;
            this.ovTXT_Marca.Location = new System.Drawing.Point(207, 190);
            this.ovTXT_Marca.Margin = new System.Windows.Forms.Padding(2);
            this.ovTXT_Marca.Name = "ovTXT_Marca";
            this.ovTXT_Marca.ReadOnly = true;
            this.ovTXT_Marca.ShortcutsEnabled = false;
            this.ovTXT_Marca.Size = new System.Drawing.Size(278, 31);
            this.ovTXT_Marca.TabIndex = 100;
            this.ovTXT_Marca.TabStop = false;
            // 
            // ovTXT_UnidadeMedida
            // 
            this.ovTXT_UnidadeMedida.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_UnidadeMedida.BackColor = System.Drawing.Color.White;
            this.ovTXT_UnidadeMedida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_UnidadeMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_UnidadeMedida.ForeColor = System.Drawing.Color.Black;
            this.ovTXT_UnidadeMedida.Location = new System.Drawing.Point(689, 190);
            this.ovTXT_UnidadeMedida.Margin = new System.Windows.Forms.Padding(2);
            this.ovTXT_UnidadeMedida.Name = "ovTXT_UnidadeMedida";
            this.ovTXT_UnidadeMedida.ReadOnly = true;
            this.ovTXT_UnidadeMedida.ShortcutsEnabled = false;
            this.ovTXT_UnidadeMedida.Size = new System.Drawing.Size(278, 31);
            this.ovTXT_UnidadeMedida.TabIndex = 97;
            this.ovTXT_UnidadeMedida.TabStop = false;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(524, 197);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(151, 20);
            this.label16.TabIndex = 96;
            this.label16.Text = "Unidade de Medida:";
            // 
            // ovTXT_ValorUnitario
            // 
            this.ovTXT_ValorUnitario.BackColor = System.Drawing.Color.White;
            this.ovTXT_ValorUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_ValorUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_ValorUnitario.ForeColor = System.Drawing.Color.Black;
            this.ovTXT_ValorUnitario.Location = new System.Drawing.Point(207, 230);
            this.ovTXT_ValorUnitario.Margin = new System.Windows.Forms.Padding(2);
            this.ovTXT_ValorUnitario.Name = "ovTXT_ValorUnitario";
            this.ovTXT_ValorUnitario.ReadOnly = true;
            this.ovTXT_ValorUnitario.ShortcutsEnabled = false;
            this.ovTXT_ValorUnitario.Size = new System.Drawing.Size(278, 35);
            this.ovTXT_ValorUnitario.TabIndex = 93;
            this.ovTXT_ValorUnitario.TabStop = false;
            this.ovTXT_ValorUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(50, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 20);
            this.label4.TabIndex = 92;
            this.label4.Text = "Valor Unitário (R$):";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.ovTXT_CodigoBarrasProduto);
            this.panel2.Location = new System.Drawing.Point(23, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(954, 99);
            this.panel2.TabIndex = 104;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(2, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(947, 18);
            this.label6.TabIndex = 83;
            this.label6.Text = "Informe o Código de Barras ou Descrição Parcial";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ovTXT_CodigoBarrasProduto
            // 
            this.ovTXT_CodigoBarrasProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_CodigoBarrasProduto.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ovTXT_CodigoBarrasProduto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ovTXT_CodigoBarrasProduto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_CodigoBarrasProduto.Location = new System.Drawing.Point(2, 32);
            this.ovTXT_CodigoBarrasProduto.Margin = new System.Windows.Forms.Padding(2);
            this.ovTXT_CodigoBarrasProduto.Name = "ovTXT_CodigoBarrasProduto";
            this.ovTXT_CodigoBarrasProduto.Size = new System.Drawing.Size(948, 34);
            this.ovTXT_CodigoBarrasProduto.TabIndex = 1;
            this.ovTXT_CodigoBarrasProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ovTXT_CodigoBarrasProduto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ovTXT_CodigoBarrasProduto_KeyUp);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(21, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(166, 20);
            this.label9.TabIndex = 103;
            this.label9.Text = "Descrição do Produto:";
            // 
            // ovTXT_StatusConsulta
            // 
            this.ovTXT_StatusConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_StatusConsulta.BackColor = System.Drawing.Color.Transparent;
            this.ovTXT_StatusConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_StatusConsulta.ForeColor = System.Drawing.Color.Red;
            this.ovTXT_StatusConsulta.Location = new System.Drawing.Point(24, 272);
            this.ovTXT_StatusConsulta.Name = "ovTXT_StatusConsulta";
            this.ovTXT_StatusConsulta.Size = new System.Drawing.Size(946, 33);
            this.ovTXT_StatusConsulta.TabIndex = 105;
            this.ovTXT_StatusConsulta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ovGRD_Produtos
            // 
            this.ovGRD_Produtos.AllowUserToAddRows = false;
            this.ovGRD_Produtos.AllowUserToDeleteRows = false;
            this.ovGRD_Produtos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovGRD_Produtos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ovGRD_Produtos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ovGRD_Produtos.BackgroundColor = System.Drawing.Color.White;
            this.ovGRD_Produtos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ovGRD_Produtos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_Produtos.DefaultCellStyle = dataGridViewCellStyle1;
            this.ovGRD_Produtos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ovGRD_Produtos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ovGRD_Produtos.Location = new System.Drawing.Point(27, 333);
            this.ovGRD_Produtos.MultiSelect = false;
            this.ovGRD_Produtos.Name = "ovGRD_Produtos";
            this.ovGRD_Produtos.ReadOnly = true;
            this.ovGRD_Produtos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ovGRD_Produtos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ovGRD_Produtos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ovGRD_Produtos.ShowCellErrors = false;
            this.ovGRD_Produtos.ShowEditingIcon = false;
            this.ovGRD_Produtos.ShowRowErrors = false;
            this.ovGRD_Produtos.Size = new System.Drawing.Size(950, 218);
            this.ovGRD_Produtos.TabIndex = 106;
            this.ovGRD_Produtos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ovGRD_Produtos_CellClick);
            this.ovGRD_Produtos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ovGRD_Produtos_CellFormatting);
            this.ovGRD_Produtos.CurrentCellChanged += new System.EventHandler(this.ovGRD_Produtos_CurrentCellChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(634, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 108;
            this.label1.Text = "Peso:";
            // 
            // ovTXT_CodigoBarras
            // 
            this.ovTXT_CodigoBarras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_CodigoBarras.BackColor = System.Drawing.Color.White;
            this.ovTXT_CodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_CodigoBarras.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_CodigoBarras.ForeColor = System.Drawing.Color.Black;
            this.ovTXT_CodigoBarras.Location = new System.Drawing.Point(782, 150);
            this.ovTXT_CodigoBarras.Margin = new System.Windows.Forms.Padding(2);
            this.ovTXT_CodigoBarras.Name = "ovTXT_CodigoBarras";
            this.ovTXT_CodigoBarras.ReadOnly = true;
            this.ovTXT_CodigoBarras.ShortcutsEnabled = false;
            this.ovTXT_CodigoBarras.Size = new System.Drawing.Size(185, 31);
            this.ovTXT_CodigoBarras.TabIndex = 110;
            this.ovTXT_CodigoBarras.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(733, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 109;
            this.label2.Text = "EAN:";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 4800;
            this.serialPort1.PortName = "COM14";
            this.serialPort1.RtsEnable = true;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // Saida_Tela
            // 
            this.Saida_Tela.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Saida_Tela.Location = new System.Drawing.Point(691, 232);
            this.Saida_Tela.Name = "Saida_Tela";
            this.Saida_Tela.Size = new System.Drawing.Size(276, 40);
            this.Saida_Tela.TabIndex = 111;
            this.Saida_Tela.Text = "Sem Leitura";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(827, 557);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(150, 35);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton1.TabIndex = 112;
            this.metroButton1.TabStop = false;
            this.metroButton1.Text = "[F10] - CONFIRMAR ITEM";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(638, 558);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 113;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GPDV_ConsultarProduto
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.Saida_Tela);
            this.Controls.Add(this.ovTXT_CodigoBarras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ovGRD_Produtos);
            this.Controls.Add(this.ovTXT_StatusConsulta);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ovTXT_DescricaoProduto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ovTXT_Marca);
            this.Controls.Add(this.ovTXT_UnidadeMedida);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ovTXT_ValorUnitario);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1002, 632);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1002, 632);
            this.Name = "GPDV_ConsultarProduto";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CONSULTAR PRODUTO";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Produtos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox ovTXT_DescricaoProduto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ovTXT_Marca;
        private System.Windows.Forms.TextBox ovTXT_UnidadeMedida;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox ovTXT_ValorUnitario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ovTXT_CodigoBarrasProduto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label ovTXT_StatusConsulta;
        private System.Windows.Forms.DataGridView ovGRD_Produtos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ovTXT_CodigoBarras;
        private System.Windows.Forms.Label label2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label Saida_Tela;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.Button button1;
    }
}