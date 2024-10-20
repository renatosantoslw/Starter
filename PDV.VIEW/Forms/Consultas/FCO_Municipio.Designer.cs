namespace PDV.VIEW.Forms.Consultas
{
    partial class FCO_Municipio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCO_Municipio));
            this.ovGRD_Municipios = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.ovTXT_Descricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.metroButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.editarmunicipiometroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Municipios)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ovGRD_Municipios
            // 
            this.ovGRD_Municipios.AllowUserToAddRows = false;
            this.ovGRD_Municipios.AllowUserToDeleteRows = false;
            this.ovGRD_Municipios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovGRD_Municipios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ovGRD_Municipios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ovGRD_Municipios.BackgroundColor = System.Drawing.Color.White;
            this.ovGRD_Municipios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ovGRD_Municipios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_Municipios.DefaultCellStyle = dataGridViewCellStyle1;
            this.ovGRD_Municipios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ovGRD_Municipios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ovGRD_Municipios.Location = new System.Drawing.Point(23, 116);
            this.ovGRD_Municipios.MultiSelect = false;
            this.ovGRD_Municipios.Name = "ovGRD_Municipios";
            this.ovGRD_Municipios.ReadOnly = true;
            this.ovGRD_Municipios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ovGRD_Municipios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ovGRD_Municipios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ovGRD_Municipios.ShowCellErrors = false;
            this.ovGRD_Municipios.ShowEditingIcon = false;
            this.ovGRD_Municipios.ShowRowErrors = false;
            this.ovGRD_Municipios.Size = new System.Drawing.Size(754, 369);
            this.ovGRD_Municipios.TabIndex = 18;
            this.ovGRD_Municipios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ovGRD_Municipios_CellClick);
            this.ovGRD_Municipios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ovGRD_Municipios_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.metroButton2);
            this.groupBox1.Controls.Add(this.metroButton1);
            this.groupBox1.Controls.Add(this.ovTXT_Descricao);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 98);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Pesquisa";
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton2.Appearance.Options.UseForeColor = true;
            this.metroButton2.Enabled = false;
            this.metroButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("metroButton2.ImageOptions.SvgImage")));
            this.metroButton2.Location = new System.Drawing.Point(649, 59);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton2.Size = new System.Drawing.Size(88, 33);
            this.metroButton2.TabIndex = 130;
            this.metroButton2.Text = "Pesquisa";
            this.metroButton2.Click += new System.EventHandler(this.ovBTN_Pesquisar_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Appearance.Options.UseForeColor = true;
            this.metroButton1.Enabled = false;
            this.metroButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton1.ImageOptions.Image")));
            this.metroButton1.Location = new System.Drawing.Point(649, 15);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton1.Size = new System.Drawing.Size(88, 38);
            this.metroButton1.TabIndex = 129;
            this.metroButton1.Text = "Limpar";
            this.metroButton1.Click += new System.EventHandler(this.ovBTN_LimparFiltros_Click);
            // 
            // ovTXT_Descricao
            // 
            this.ovTXT_Descricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_Descricao.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ovTXT_Descricao.Location = new System.Drawing.Point(80, 24);
            this.ovTXT_Descricao.Name = "ovTXT_Descricao";
            this.ovTXT_Descricao.Size = new System.Drawing.Size(512, 24);
            this.ovTXT_Descricao.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descrição:";
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton3.Appearance.Options.UseForeColor = true;
            this.metroButton3.Enabled = false;
            this.metroButton3.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Deletar;
            this.metroButton3.Location = new System.Drawing.Point(700, 555);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton3.Size = new System.Drawing.Size(88, 33);
            this.metroButton3.TabIndex = 128;
            this.metroButton3.Text = "Remover";
            this.metroButton3.Click += new System.EventHandler(this.ovBTN_Excluir_Click);
            // 
            // editarmunicipiometroButton4
            // 
            this.editarmunicipiometroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editarmunicipiometroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editarmunicipiometroButton4.Appearance.Options.UseForeColor = true;
            this.editarmunicipiometroButton4.Enabled = false;
            this.editarmunicipiometroButton4.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Editar;
            this.editarmunicipiometroButton4.Location = new System.Drawing.Point(606, 555);
            this.editarmunicipiometroButton4.Name = "editarmunicipiometroButton4";
            this.editarmunicipiometroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.editarmunicipiometroButton4.Size = new System.Drawing.Size(88, 33);
            this.editarmunicipiometroButton4.TabIndex = 127;
            this.editarmunicipiometroButton4.Text = "Editar";
            this.editarmunicipiometroButton4.Click += new System.EventHandler(this.ovBTN_Editar_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Adicionar;
            this.metroButton5.Location = new System.Drawing.Point(512, 555);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(88, 33);
            this.metroButton5.TabIndex = 126;
            this.metroButton5.Text = "Novo";
            this.metroButton5.Click += new System.EventHandler(this.ovBTN_Novo_Click);
            // 
            // FCO_Municipio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.editarmunicipiometroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ovGRD_Municipios);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FCO_Municipio";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Consulta de Município";
            this.Load += new System.EventHandler(this.FCO_Municipio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Municipios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView ovGRD_Municipios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ovTXT_Descricao;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton metroButton3;
        private DevExpress.XtraEditors.SimpleButton editarmunicipiometroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private DevExpress.XtraEditors.SimpleButton metroButton2;
        private DevExpress.XtraEditors.SimpleButton metroButton1;
    }
}