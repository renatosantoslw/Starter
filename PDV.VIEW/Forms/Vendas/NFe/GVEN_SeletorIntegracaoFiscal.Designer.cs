namespace PDV.VIEW.Forms.Vendas.NFe
{
    partial class GVEN_SeletorIntegracaoFiscal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GVEN_SeletorIntegracaoFiscal));
            this.ovGRD_IntegracaoFiscal = new System.Windows.Forms.DataGridView();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_IntegracaoFiscal)).BeginInit();
            this.SuspendLayout();
            // 
            // ovGRD_IntegracaoFiscal
            // 
            this.ovGRD_IntegracaoFiscal.AllowUserToAddRows = false;
            this.ovGRD_IntegracaoFiscal.AllowUserToDeleteRows = false;
            this.ovGRD_IntegracaoFiscal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovGRD_IntegracaoFiscal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ovGRD_IntegracaoFiscal.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ovGRD_IntegracaoFiscal.BackgroundColor = System.Drawing.Color.White;
            this.ovGRD_IntegracaoFiscal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ovGRD_IntegracaoFiscal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_IntegracaoFiscal.DefaultCellStyle = dataGridViewCellStyle1;
            this.ovGRD_IntegracaoFiscal.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ovGRD_IntegracaoFiscal.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ovGRD_IntegracaoFiscal.Location = new System.Drawing.Point(23, 12);
            this.ovGRD_IntegracaoFiscal.MultiSelect = false;
            this.ovGRD_IntegracaoFiscal.Name = "ovGRD_IntegracaoFiscal";
            this.ovGRD_IntegracaoFiscal.ReadOnly = true;
            this.ovGRD_IntegracaoFiscal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ovGRD_IntegracaoFiscal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ovGRD_IntegracaoFiscal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ovGRD_IntegracaoFiscal.ShowCellErrors = false;
            this.ovGRD_IntegracaoFiscal.ShowEditingIcon = false;
            this.ovGRD_IntegracaoFiscal.ShowRowErrors = false;
            this.ovGRD_IntegracaoFiscal.Size = new System.Drawing.Size(834, 553);
            this.ovGRD_IntegracaoFiscal.TabIndex = 26;
            this.ovGRD_IntegracaoFiscal.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ovGRD_IntegracaoFiscal_CellDoubleClick);
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("metroButton4.ImageOptions.SvgImage")));
            this.metroButton4.Location = new System.Drawing.Point(771, 635);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(97, 33);
            this.metroButton4.TabIndex = 121;
            this.metroButton4.Text = "Selecionar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // GVEN_SeletorIntegracaoFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 680);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.ovGRD_IntegracaoFiscal);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(896, 719);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(896, 719);
            this.Name = "GVEN_SeletorIntegracaoFiscal";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pesquisa de Integração Fiscal por CFOP";
            this.Load += new System.EventHandler(this.GVEN_SeletorIntegracaoFiscal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_IntegracaoFiscal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView ovGRD_IntegracaoFiscal;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
    }
}