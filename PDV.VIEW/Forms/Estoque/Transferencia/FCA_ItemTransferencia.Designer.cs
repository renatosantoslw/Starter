namespace PDV.VIEW.Forms.Estoque.Transferencia
{
    partial class FCA_ItemTransferencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_ItemTransferencia));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ovCMB_AlmoxEntrada = new MetroFramework.Controls.MetroComboBox();
            this.ovCMB_AlmoxSaida = new MetroFramework.Controls.MetroComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ovGRD_Itens = new PDV.UTIL.Components.Custom.GridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Itens)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(374, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 102;
            this.label1.Text = "* Destino:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 103;
            this.label2.Text = "* Origem:";
            // 
            // ovCMB_AlmoxEntrada
            // 
            this.ovCMB_AlmoxEntrada.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_AlmoxEntrada.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_AlmoxEntrada.FormattingEnabled = true;
            this.ovCMB_AlmoxEntrada.ItemHeight = 19;
            this.ovCMB_AlmoxEntrada.Items.AddRange(new object[] {
            "CNPJ",
            "CPF"});
            this.ovCMB_AlmoxEntrada.Location = new System.Drawing.Point(82, 24);
            this.ovCMB_AlmoxEntrada.Name = "ovCMB_AlmoxEntrada";
            this.ovCMB_AlmoxEntrada.Size = new System.Drawing.Size(286, 25);
            this.ovCMB_AlmoxEntrada.TabIndex = 100;
            this.ovCMB_AlmoxEntrada.UseSelectable = true;
            this.ovCMB_AlmoxEntrada.SelectedIndexChanged += new System.EventHandler(this.ovCMB_AlmoxEntrada_SelectedIndexChanged);
            // 
            // ovCMB_AlmoxSaida
            // 
            this.ovCMB_AlmoxSaida.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_AlmoxSaida.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_AlmoxSaida.FormattingEnabled = true;
            this.ovCMB_AlmoxSaida.ItemHeight = 19;
            this.ovCMB_AlmoxSaida.Items.AddRange(new object[] {
            "CNPJ",
            "CPF"});
            this.ovCMB_AlmoxSaida.Location = new System.Drawing.Point(453, 24);
            this.ovCMB_AlmoxSaida.Name = "ovCMB_AlmoxSaida";
            this.ovCMB_AlmoxSaida.Size = new System.Drawing.Size(295, 25);
            this.ovCMB_AlmoxSaida.TabIndex = 104;
            this.ovCMB_AlmoxSaida.UseSelectable = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ovGRD_Itens);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(26, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(751, 505);
            this.groupBox1.TabIndex = 106;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Itens do Almoxadifado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(6, 482);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(544, 14);
            this.label3.TabIndex = 106;
            this.label3.Text = "* A EDIÇÃO é feita sobre a coluna [QUANTIDADE]. Caso o valor seja ZERO, não será " +
    "considerado.";
            // 
            // ovGRD_Itens
            // 
            this.ovGRD_Itens.AllowUserToAddRows = false;
            this.ovGRD_Itens.AllowUserToDeleteRows = false;
            this.ovGRD_Itens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovGRD_Itens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ovGRD_Itens.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ovGRD_Itens.BackgroundColor = System.Drawing.Color.White;
            this.ovGRD_Itens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ovGRD_Itens.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(136)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(136)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(136)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_Itens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ovGRD_Itens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_Itens.DefaultCellStyle = dataGridViewCellStyle2;
            this.ovGRD_Itens.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.ovGRD_Itens.EnableHeadersVisualStyles = false;
            this.ovGRD_Itens.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.ovGRD_Itens.Location = new System.Drawing.Point(6, 24);
            this.ovGRD_Itens.MultiSelect = false;
            this.ovGRD_Itens.Name = "ovGRD_Itens";
            this.ovGRD_Itens.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ovGRD_Itens.RowHeadersVisible = false;
            this.ovGRD_Itens.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ovGRD_Itens.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ovGRD_Itens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ovGRD_Itens.ShowCellErrors = false;
            this.ovGRD_Itens.ShowEditingIcon = false;
            this.ovGRD_Itens.ShowRowErrors = false;
            this.ovGRD_Itens.Size = new System.Drawing.Size(739, 453);
            this.ovGRD_Itens.TabIndex = 105;
            this.ovGRD_Itens.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ovGRD_Itens_CellFormatting);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ovCMB_AlmoxEntrada);
            this.groupBox2.Controls.Add(this.ovCMB_AlmoxSaida);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(23, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(754, 62);
            this.groupBox2.TabIndex = 107;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Almoxarifados";
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(700, 655);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(88, 33);
            this.metroButton4.TabIndex = 117;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton5.ImageOptions.Image")));
            this.metroButton5.Location = new System.Drawing.Point(606, 655);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(88, 33);
            this.metroButton5.TabIndex = 116;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // FCA_ItemTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCA_ItemTransferencia";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item da Transferência";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Itens)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroComboBox ovCMB_AlmoxEntrada;
        private MetroFramework.Controls.MetroComboBox ovCMB_AlmoxSaida;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private UTIL.Components.Custom.GridView ovGRD_Itens;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
    }
}