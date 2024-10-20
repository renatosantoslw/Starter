namespace PDV.VIEW.Forms.Consultas
{
    partial class FCO_UnidadeFederativa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCO_UnidadeFederativa));
            this.ovGRD_Unidades = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.ovTXT_Descricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_Sigla = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.metroButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.editarufmetroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Unidades)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.ovGRD_Unidades.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ovGRD_Unidades.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ovGRD_Unidades.Location = new System.Drawing.Point(23, 116);
            this.ovGRD_Unidades.MultiSelect = false;
            this.ovGRD_Unidades.Name = "ovGRD_Unidades";
            this.ovGRD_Unidades.ReadOnly = true;
            this.ovGRD_Unidades.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ovGRD_Unidades.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ovGRD_Unidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ovGRD_Unidades.ShowCellErrors = false;
            this.ovGRD_Unidades.ShowEditingIcon = false;
            this.ovGRD_Unidades.ShowRowErrors = false;
            this.ovGRD_Unidades.Size = new System.Drawing.Size(754, 369);
            this.ovGRD_Unidades.TabIndex = 15;
            this.ovGRD_Unidades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ovGRD_Unidades_CellClick);
            this.ovGRD_Unidades.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ovGRD_Unidades_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.simpleButton1);
            this.groupBox1.Controls.Add(this.simpleButton2);
            this.groupBox1.Controls.Add(this.ovTXT_Descricao);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ovTXT_Sigla);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 98);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Pesquisa";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Enabled = false;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(651, 56);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton1.Size = new System.Drawing.Size(88, 33);
            this.simpleButton1.TabIndex = 121;
            this.simpleButton1.Text = "Pesquisar";
            this.simpleButton1.Click += new System.EventHandler(this.ovBTN_Pesquisar_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(651, 17);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton2.Size = new System.Drawing.Size(88, 33);
            this.simpleButton2.TabIndex = 120;
            this.simpleButton2.Text = "Limpar";
            this.simpleButton2.Click += new System.EventHandler(this.ovBTN_LimparFiltros_Click);
            // 
            // ovTXT_Descricao
            // 
            this.ovTXT_Descricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_Descricao.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ovTXT_Descricao.Location = new System.Drawing.Point(80, 56);
            this.ovTXT_Descricao.Name = "ovTXT_Descricao";
            this.ovTXT_Descricao.Size = new System.Drawing.Size(512, 24);
            this.ovTXT_Descricao.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descrição:";
            // 
            // ovTXT_Sigla
            // 
            this.ovTXT_Sigla.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ovTXT_Sigla.Location = new System.Drawing.Point(80, 24);
            this.ovTXT_Sigla.Name = "ovTXT_Sigla";
            this.ovTXT_Sigla.Size = new System.Drawing.Size(123, 24);
            this.ovTXT_Sigla.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sigla:";
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton3.Appearance.Options.UseForeColor = true;
            this.metroButton3.Enabled = false;
            this.metroButton3.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Deletar;
            this.metroButton3.Location = new System.Drawing.Point(698, 555);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton3.Size = new System.Drawing.Size(88, 33);
            this.metroButton3.TabIndex = 119;
            this.metroButton3.Text = "Remover";
            this.metroButton3.Click += new System.EventHandler(this.ovBTN_Excluir_Click);
            // 
            // editarufmetroButton4
            // 
            this.editarufmetroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editarufmetroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editarufmetroButton4.Appearance.Options.UseForeColor = true;
            this.editarufmetroButton4.Enabled = false;
            this.editarufmetroButton4.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Editar;
            this.editarufmetroButton4.Location = new System.Drawing.Point(619, 555);
            this.editarufmetroButton4.Name = "editarufmetroButton4";
            this.editarufmetroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.editarufmetroButton4.Size = new System.Drawing.Size(73, 33);
            this.editarufmetroButton4.TabIndex = 118;
            this.editarufmetroButton4.Text = "Editar";
            this.editarufmetroButton4.Click += new System.EventHandler(this.ovBTN_Editar_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Adicionar;
            this.metroButton5.Location = new System.Drawing.Point(545, 555);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(68, 33);
            this.metroButton5.TabIndex = 117;
            this.metroButton5.Text = "Novo";
            this.metroButton5.Click += new System.EventHandler(this.ovBTN_Novo_Click);
            // 
            // FCO_UnidadeFederativa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.editarufmetroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ovGRD_Unidades);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FCO_UnidadeFederativa";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Unidade Federativa";
            this.Load += new System.EventHandler(this.FCO_UnidadeFederativa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Unidades)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView ovGRD_Unidades;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ovTXT_Descricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ovTXT_Sigla;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton metroButton3;
        private DevExpress.XtraEditors.SimpleButton editarufmetroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}