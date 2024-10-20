namespace PDV.VIEW.Forms.Cadastro
{
    partial class FCA_AliquotaICMSPorEstado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_AliquotaICMSPorEstado));
            this.ovGRD_Unidades = new System.Windows.Forms.DataGridView();
            this.metroButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Unidades)).BeginInit();
            this.SuspendLayout();
            // 
            // ovGRD_Unidades
            // 
            this.ovGRD_Unidades.AllowUserToAddRows = false;
            this.ovGRD_Unidades.AllowUserToDeleteRows = false;
            this.ovGRD_Unidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovGRD_Unidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ovGRD_Unidades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ovGRD_Unidades.BackgroundColor = System.Drawing.Color.White;
            this.ovGRD_Unidades.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ovGRD_Unidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_Unidades.DefaultCellStyle = dataGridViewCellStyle1;
            this.ovGRD_Unidades.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ovGRD_Unidades.Location = new System.Drawing.Point(12, 12);
            this.ovGRD_Unidades.MultiSelect = false;
            this.ovGRD_Unidades.Name = "ovGRD_Unidades";
            this.ovGRD_Unidades.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ovGRD_Unidades.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ovGRD_Unidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ovGRD_Unidades.ShowCellErrors = false;
            this.ovGRD_Unidades.ShowEditingIcon = false;
            this.ovGRD_Unidades.ShowRowErrors = false;
            this.ovGRD_Unidades.Size = new System.Drawing.Size(760, 498);
            this.ovGRD_Unidades.TabIndex = 15;
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton3.Appearance.Options.UseForeColor = true;
            this.metroButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton3.ImageOptions.Image")));
            this.metroButton3.Location = new System.Drawing.Point(684, 516);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton3.Size = new System.Drawing.Size(88, 33);
            this.metroButton3.TabIndex = 113;
            this.metroButton3.Text = "Salvar";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(590, 516);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(88, 33);
            this.metroButton4.TabIndex = 112;
            this.metroButton4.Text = "Cancelar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // FCA_AliquotaICMSPorEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.ovGRD_Unidades);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCA_AliquotaICMSPorEstado";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ICMS por UF";
            this.Load += new System.EventHandler(this.FCA_AliquotaICMSPorEstado_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_AliquotaICMSPorEstado_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Unidades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ovGRD_Unidades;
        private DevExpress.XtraEditors.SimpleButton metroButton3;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
    }
}