namespace PDV.UTIL.FORMS.Forms.Caixa
{
    partial class frmContadorMoedas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContadorMoedas));
            this.dgDados = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTotal = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgDados
            // 
            this.dgDados.AllowUserToAddRows = false;
            this.dgDados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dgDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDados.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgDados.EnableHeadersVisualStyles = false;
            this.dgDados.GridColor = System.Drawing.Color.White;
            this.dgDados.Location = new System.Drawing.Point(2, 1);
            this.dgDados.Name = "dgDados";
            this.dgDados.RowHeadersVisible = false;
            this.dgDados.Size = new System.Drawing.Size(384, 469);
            this.dgDados.TabIndex = 369;
            this.dgDados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDados_CellContentClick);
            this.dgDados.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDados_CellEndEdit);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtTotal);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(392, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 100);
            this.groupBox3.TabIndex = 379;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TOTAL";
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtTotal.Location = new System.Drawing.Point(15, 19);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(242, 16);
            this.txtTotal.TabIndex = 370;
            this.txtTotal.Text = ".Digite o valor na coluna Quantidade";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button3.Location = new System.Drawing.Point(480, 437);
            this.button3.Margin = new System.Windows.Forms.Padding(1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(186, 33);
            this.button3.TabIndex = 380;
            this.button3.TabStop = false;
            this.button3.Text = "DEL - Zerar Contador";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Moeda / Cédula";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Quant";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Valor";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // frmContadorMoedas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(676, 471);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgDados);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmContadorMoedas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contador de Moedas";
            this.Load += new System.EventHandler(this.frmContadorMoedas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDados;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label txtTotal;
        public System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}