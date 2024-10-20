namespace PDV.VIEW.FRENTECAIXA.Forms.PDV
{
    partial class GPDV_CarregarVenda
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
            this.ovGRD_Comandas = new System.Windows.Forms.DataGridView();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Comandas)).BeginInit();
            this.SuspendLayout();
            // 
            // ovGRD_Comandas
            // 
            this.ovGRD_Comandas.AllowUserToAddRows = false;
            this.ovGRD_Comandas.AllowUserToDeleteRows = false;
            this.ovGRD_Comandas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovGRD_Comandas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ovGRD_Comandas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ovGRD_Comandas.BackgroundColor = System.Drawing.Color.White;
            this.ovGRD_Comandas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ovGRD_Comandas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_Comandas.DefaultCellStyle = dataGridViewCellStyle1;
            this.ovGRD_Comandas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ovGRD_Comandas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ovGRD_Comandas.Location = new System.Drawing.Point(6, 5);
            this.ovGRD_Comandas.MultiSelect = false;
            this.ovGRD_Comandas.Name = "ovGRD_Comandas";
            this.ovGRD_Comandas.ReadOnly = true;
            this.ovGRD_Comandas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ovGRD_Comandas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ovGRD_Comandas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ovGRD_Comandas.ShowCellErrors = false;
            this.ovGRD_Comandas.ShowEditingIcon = false;
            this.ovGRD_Comandas.ShowRowErrors = false;
            this.ovGRD_Comandas.Size = new System.Drawing.Size(982, 534);
            this.ovGRD_Comandas.TabIndex = 25;
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Location = new System.Drawing.Point(827, 553);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(150, 35);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton1.TabIndex = 26;
            this.metroButton1.TabStop = false;
            this.metroButton1.Text = "[F10] - CARREGAR";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton2.Location = new System.Drawing.Point(671, 553);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(150, 35);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton2.TabIndex = 27;
            this.metroButton2.TabStop = false;
            this.metroButton2.Text = "[ESC] - CANCELAR";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton3.Location = new System.Drawing.Point(515, 553);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(150, 35);
            this.metroButton3.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton3.TabIndex = 28;
            this.metroButton3.TabStop = false;
            this.metroButton3.Text = "IMPORTAR PEDIDO APP";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // GPDV_CarregarVenda
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.ovGRD_Comandas);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GPDV_CarregarVenda";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Carregar Pré-Venda";
            this.Load += new System.EventHandler(this.GPDV_CarregarVenda_Load);
            this.Shown += new System.EventHandler(this.GPDV_CarregarVenda_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Comandas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ovGRD_Comandas;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;
    }
}