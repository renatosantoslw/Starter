namespace PDV.VIEW.Forms.Vendas.NFe
{
    partial class GVEN_SeletorClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GVEN_SeletorClientes));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ovTXT_RazaoSocial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ovGRD_Clientes = new System.Windows.Forms.DataGridView();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ovTXT_RazaoSocial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 62);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Pesquisa";
            // 
            // ovTXT_RazaoSocial
            // 
            this.ovTXT_RazaoSocial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_RazaoSocial.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_RazaoSocial.Location = new System.Drawing.Point(122, 24);
            this.ovTXT_RazaoSocial.Name = "ovTXT_RazaoSocial";
            this.ovTXT_RazaoSocial.Size = new System.Drawing.Size(626, 23);
            this.ovTXT_RazaoSocial.TabIndex = 1;
            this.ovTXT_RazaoSocial.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ovTXT_RazaoSocial_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome/Fantasia:";
            // 
            // ovGRD_Clientes
            // 
            this.ovGRD_Clientes.AllowUserToAddRows = false;
            this.ovGRD_Clientes.AllowUserToDeleteRows = false;
            this.ovGRD_Clientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovGRD_Clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ovGRD_Clientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ovGRD_Clientes.BackgroundColor = System.Drawing.Color.White;
            this.ovGRD_Clientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ovGRD_Clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_Clientes.DefaultCellStyle = dataGridViewCellStyle1;
            this.ovGRD_Clientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ovGRD_Clientes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ovGRD_Clientes.Location = new System.Drawing.Point(23, 67);
            this.ovGRD_Clientes.MultiSelect = false;
            this.ovGRD_Clientes.Name = "ovGRD_Clientes";
            this.ovGRD_Clientes.ReadOnly = true;
            this.ovGRD_Clientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ovGRD_Clientes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ovGRD_Clientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ovGRD_Clientes.ShowCellErrors = false;
            this.ovGRD_Clientes.ShowEditingIcon = false;
            this.ovGRD_Clientes.ShowRowErrors = false;
            this.ovGRD_Clientes.Size = new System.Drawing.Size(754, 405);
            this.ovGRD_Clientes.TabIndex = 15;
            this.ovGRD_Clientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ovGRD_Clientes_CellDoubleClick);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton5.ImageOptions.Image")));
            this.metroButton5.Location = new System.Drawing.Point(588, 555);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(97, 33);
            this.metroButton5.TabIndex = 121;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("metroButton4.ImageOptions.SvgImage")));
            this.metroButton4.Location = new System.Drawing.Point(691, 555);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(97, 33);
            this.metroButton4.TabIndex = 120;
            this.metroButton4.Text = "Selecionar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // GVEN_SeletorClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.ovGRD_Clientes);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 639);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 639);
            this.Name = "GVEN_SeletorClientes";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa de Clientes";
            this.Load += new System.EventHandler(this.GVEN_SeletorClientes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Clientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ovTXT_RazaoSocial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView ovGRD_Clientes;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
    }
}