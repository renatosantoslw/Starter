namespace PDV.VIEW.Forms.Consultas
{
    partial class FCO_Pais
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCO_Pais));
            this.ovGRD_Paises = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.ovTXT_Descricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.metroButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.editarPaismetroButton = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Paises)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ovGRD_Paises
            // 
            this.ovGRD_Paises.AllowUserToAddRows = false;
            this.ovGRD_Paises.AllowUserToDeleteRows = false;
            this.ovGRD_Paises.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovGRD_Paises.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ovGRD_Paises.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ovGRD_Paises.BackgroundColor = System.Drawing.Color.White;
            this.ovGRD_Paises.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ovGRD_Paises.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_Paises.DefaultCellStyle = dataGridViewCellStyle1;
            this.ovGRD_Paises.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ovGRD_Paises.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ovGRD_Paises.Location = new System.Drawing.Point(23, 116);
            this.ovGRD_Paises.MultiSelect = false;
            this.ovGRD_Paises.Name = "ovGRD_Paises";
            this.ovGRD_Paises.ReadOnly = true;
            this.ovGRD_Paises.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ovGRD_Paises.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ovGRD_Paises.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ovGRD_Paises.ShowCellErrors = false;
            this.ovGRD_Paises.ShowEditingIcon = false;
            this.ovGRD_Paises.ShowRowErrors = false;
            this.ovGRD_Paises.Size = new System.Drawing.Size(754, 369);
            this.ovGRD_Paises.TabIndex = 18;
            this.ovGRD_Paises.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ovGRD_Paises_CellClick);
            this.ovGRD_Paises.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ovGRD_Paises_CellDoubleClick);
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
            this.metroButton2.Location = new System.Drawing.Point(660, 59);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton2.Size = new System.Drawing.Size(88, 33);
            this.metroButton2.TabIndex = 124;
            this.metroButton2.Text = "Pesquisar";
            this.metroButton2.Click += new System.EventHandler(this.ovBTN_Pesquisar_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Appearance.Options.UseForeColor = true;
            this.metroButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton1.ImageOptions.Image")));
            this.metroButton1.Location = new System.Drawing.Point(660, 20);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton1.Size = new System.Drawing.Size(88, 33);
            this.metroButton1.TabIndex = 123;
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
            this.metroButton3.TabIndex = 122;
            this.metroButton3.Text = "Remover";
            this.metroButton3.Click += new System.EventHandler(this.ovBTN_Excluir_Click);
            // 
            // editarPaismetroButton
            // 
            this.editarPaismetroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editarPaismetroButton.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editarPaismetroButton.Appearance.Options.UseForeColor = true;
            this.editarPaismetroButton.Enabled = false;
            this.editarPaismetroButton.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Editar;
            this.editarPaismetroButton.Location = new System.Drawing.Point(622, 555);
            this.editarPaismetroButton.Name = "editarPaismetroButton";
            this.editarPaismetroButton.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.editarPaismetroButton.Size = new System.Drawing.Size(72, 33);
            this.editarPaismetroButton.TabIndex = 121;
            this.editarPaismetroButton.Text = "Editar";
            this.editarPaismetroButton.Click += new System.EventHandler(this.ovBTN_Editar_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Adicionar;
            this.metroButton5.Location = new System.Drawing.Point(547, 555);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(68, 33);
            this.metroButton5.TabIndex = 120;
            this.metroButton5.Text = "Novo";
            this.metroButton5.Click += new System.EventHandler(this.ovBTN_Novo_Click);
            // 
            // FCO_Pais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.editarPaismetroButton);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ovGRD_Paises);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FCO_Pais";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Consulta de País";
            this.Load += new System.EventHandler(this.FCO_Pais_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Paises)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView ovGRD_Paises;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ovTXT_Descricao;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton metroButton3;
        private DevExpress.XtraEditors.SimpleButton editarPaismetroButton;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private DevExpress.XtraEditors.SimpleButton metroButton2;
        private DevExpress.XtraEditors.SimpleButton metroButton1;
    }
}