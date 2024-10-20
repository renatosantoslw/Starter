namespace PDV.VIEW.Forms.Configuracoes
{
    partial class FCONFIG_Vendas_Geral
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ovRB_Valor = new System.Windows.Forms.RadioButton();
            this.ovRB_Percentual = new System.Windows.Forms.RadioButton();
            this.label29 = new System.Windows.Forms.Label();
            this.ovTXT_CHAVE_ATENTICACAO = new System.Windows.Forms.TextBox();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.gridLookUpEditTipoDeOperacao = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tipoOperacaoPadraoPDVGridLookUpEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.metroTabControl2 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.txtDigitoVerificador = new DevExpress.XtraEditors.TextEdit();
            this.cbeQtdDigitosBal = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbPesoCodigo = new System.Windows.Forms.RadioButton();
            this.rbPrecoCodigo = new System.Windows.Forms.RadioButton();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.metroTabPage6 = new MetroFramework.Controls.MetroTabPage();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditTipoDeOperacao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoOperacaoPadraoPDVGridLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.metroTabControl2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDigitoVerificador.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeQtdDigitosBal.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.metroTabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.ovRB_Valor);
            this.groupBox2.Controls.Add(this.ovRB_Percentual);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(469, 37);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Desconto";
            // 
            // ovRB_Valor
            // 
            this.ovRB_Valor.AutoSize = true;
            this.ovRB_Valor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovRB_Valor.Location = new System.Drawing.Point(145, 13);
            this.ovRB_Valor.Name = "ovRB_Valor";
            this.ovRB_Valor.Size = new System.Drawing.Size(73, 17);
            this.ovRB_Valor.TabIndex = 4;
            this.ovRB_Valor.Text = "(R$) Valor";
            this.ovRB_Valor.UseVisualStyleBackColor = true;
            // 
            // ovRB_Percentual
            // 
            this.ovRB_Percentual.AutoSize = true;
            this.ovRB_Percentual.Checked = true;
            this.ovRB_Percentual.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovRB_Percentual.Location = new System.Drawing.Point(29, 13);
            this.ovRB_Percentual.Name = "ovRB_Percentual";
            this.ovRB_Percentual.Size = new System.Drawing.Size(110, 17);
            this.ovRB_Percentual.TabIndex = 3;
            this.ovRB_Percentual.TabStop = true;
            this.ovRB_Percentual.Text = "(%) Porcentagem";
            this.ovRB_Percentual.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(3, 69);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(89, 13);
            this.label29.TabIndex = 40;
            this.label29.Text = "Tef Autenticação";
            // 
            // ovTXT_CHAVE_ATENTICACAO
            // 
            this.ovTXT_CHAVE_ATENTICACAO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_CHAVE_ATENTICACAO.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_CHAVE_ATENTICACAO.Location = new System.Drawing.Point(3, 85);
            this.ovTXT_CHAVE_ATENTICACAO.Name = "ovTXT_CHAVE_ATENTICACAO";
            this.ovTXT_CHAVE_ATENTICACAO.Size = new System.Drawing.Size(469, 21);
            this.ovTXT_CHAVE_ATENTICACAO.TabIndex = 41;
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.Location = new System.Drawing.Point(331, 280);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(85, 30);
            this.metroButton4.TabIndex = 119;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.Location = new System.Drawing.Point(429, 280);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(85, 30);
            this.metroButton5.TabIndex = 118;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // gridLookUpEditTipoDeOperacao
            // 
            this.gridLookUpEditTipoDeOperacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLookUpEditTipoDeOperacao.EditValue = "";
            this.gridLookUpEditTipoDeOperacao.Location = new System.Drawing.Point(3, 136);
            this.gridLookUpEditTipoDeOperacao.Name = "gridLookUpEditTipoDeOperacao";
            this.gridLookUpEditTipoDeOperacao.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridLookUpEditTipoDeOperacao.Properties.Appearance.Options.UseFont = true;
            this.gridLookUpEditTipoDeOperacao.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEditTipoDeOperacao.Properties.DisplayMember = "Nome";
            this.gridLookUpEditTipoDeOperacao.Properties.PopupView = this.gridView3;
            this.gridLookUpEditTipoDeOperacao.Properties.ValueMember = "Cod";
            this.gridLookUpEditTipoDeOperacao.Size = new System.Drawing.Size(469, 20);
            this.gridLookUpEditTipoDeOperacao.TabIndex = 120;
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 121;
            this.label1.Text = "Tipo de Operação Padrão do APP";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 13);
            this.label2.TabIndex = 123;
            this.label2.Text = "Tipo de Operação Padrão do PDV";
            // 
            // tipoOperacaoPadraoPDVGridLookUpEdit
            // 
            this.tipoOperacaoPadraoPDVGridLookUpEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tipoOperacaoPadraoPDVGridLookUpEdit.EditValue = "";
            this.tipoOperacaoPadraoPDVGridLookUpEdit.Location = new System.Drawing.Point(3, 189);
            this.tipoOperacaoPadraoPDVGridLookUpEdit.Name = "tipoOperacaoPadraoPDVGridLookUpEdit";
            this.tipoOperacaoPadraoPDVGridLookUpEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoOperacaoPadraoPDVGridLookUpEdit.Properties.Appearance.Options.UseFont = true;
            this.tipoOperacaoPadraoPDVGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tipoOperacaoPadraoPDVGridLookUpEdit.Properties.DisplayMember = "Nome";
            this.tipoOperacaoPadraoPDVGridLookUpEdit.Properties.PopupView = this.gridView1;
            this.tipoOperacaoPadraoPDVGridLookUpEdit.Properties.ValueMember = "Cod";
            this.tipoOperacaoPadraoPDVGridLookUpEdit.Size = new System.Drawing.Size(469, 20);
            this.tipoOperacaoPadraoPDVGridLookUpEdit.TabIndex = 122;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // metroTabControl2
            // 
            this.metroTabControl2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroTabControl2.Controls.Add(this.metroTabPage3);
            this.metroTabControl2.Controls.Add(this.metroTabPage6);
            this.metroTabControl2.Location = new System.Drawing.Point(7, 0);
            this.metroTabControl2.Name = "metroTabControl2";
            this.metroTabControl2.SelectedIndex = 1;
            this.metroTabControl2.Size = new System.Drawing.Size(511, 274);
            this.metroTabControl2.TabIndex = 134;
            this.metroTabControl2.UseSelectable = true;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.txtDigitoVerificador);
            this.metroTabPage3.Controls.Add(this.cbeQtdDigitosBal);
            this.metroTabPage3.Controls.Add(this.groupBox1);
            this.metroTabPage3.Controls.Add(this.labelControl19);
            this.metroTabPage3.Controls.Add(this.labelControl18);
            this.metroTabPage3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 4;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(499, 232);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Balança Retaguarda";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 7;
            // 
            // txtDigitoVerificador
            // 
            this.txtDigitoVerificador.Location = new System.Drawing.Point(4, 40);
            this.txtDigitoVerificador.Name = "txtDigitoVerificador";
            this.txtDigitoVerificador.Size = new System.Drawing.Size(100, 20);
            this.txtDigitoVerificador.TabIndex = 50;
            // 
            // cbeQtdDigitosBal
            // 
            this.cbeQtdDigitosBal.Location = new System.Drawing.Point(166, 40);
            this.cbeQtdDigitosBal.Name = "cbeQtdDigitosBal";
            this.cbeQtdDigitosBal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeQtdDigitosBal.Properties.Items.AddRange(new object[] {
            "4",
            "5",
            "6"});
            this.cbeQtdDigitosBal.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbeQtdDigitosBal.Size = new System.Drawing.Size(100, 20);
            this.cbeQtdDigitosBal.TabIndex = 49;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rbPesoCodigo);
            this.groupBox1.Controls.Add(this.rbPrecoCodigo);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(5, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 43);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Impressão";
            // 
            // rbPesoCodigo
            // 
            this.rbPesoCodigo.AutoSize = true;
            this.rbPesoCodigo.Location = new System.Drawing.Point(137, 18);
            this.rbPesoCodigo.Name = "rbPesoCodigo";
            this.rbPesoCodigo.Size = new System.Drawing.Size(110, 18);
            this.rbPesoCodigo.TabIndex = 0;
            this.rbPesoCodigo.TabStop = true;
            this.rbPesoCodigo.Text = "Peso no Código";
            this.rbPesoCodigo.UseVisualStyleBackColor = true;
            // 
            // rbPrecoCodigo
            // 
            this.rbPrecoCodigo.AutoSize = true;
            this.rbPrecoCodigo.Location = new System.Drawing.Point(9, 18);
            this.rbPrecoCodigo.Name = "rbPrecoCodigo";
            this.rbPrecoCodigo.Size = new System.Drawing.Size(115, 18);
            this.rbPrecoCodigo.TabIndex = 0;
            this.rbPrecoCodigo.TabStop = true;
            this.rbPrecoCodigo.Text = "Preço no Código";
            this.rbPrecoCodigo.UseVisualStyleBackColor = true;
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl19.Appearance.Options.UseFont = true;
            this.labelControl19.Location = new System.Drawing.Point(166, 17);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(79, 13);
            this.labelControl19.TabIndex = 45;
            this.labelControl19.Text = "Qtd de Dígitos";
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl18.Appearance.Options.UseFont = true;
            this.labelControl18.Location = new System.Drawing.Point(3, 17);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(97, 13);
            this.labelControl18.TabIndex = 46;
            this.labelControl18.Text = "Dígito Verificador";
            // 
            // metroTabPage6
            // 
            this.metroTabPage6.Controls.Add(this.label2);
            this.metroTabPage6.Controls.Add(this.tipoOperacaoPadraoPDVGridLookUpEdit);
            this.metroTabPage6.Controls.Add(this.groupBox2);
            this.metroTabPage6.Controls.Add(this.label1);
            this.metroTabPage6.Controls.Add(this.ovTXT_CHAVE_ATENTICACAO);
            this.metroTabPage6.Controls.Add(this.gridLookUpEditTipoDeOperacao);
            this.metroTabPage6.Controls.Add(this.label29);
            this.metroTabPage6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTabPage6.HorizontalScrollbarBarColor = true;
            this.metroTabPage6.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage6.HorizontalScrollbarSize = 10;
            this.metroTabPage6.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage6.Name = "metroTabPage6";
            this.metroTabPage6.Size = new System.Drawing.Size(503, 232);
            this.metroTabPage6.TabIndex = 1;
            this.metroTabPage6.Text = "Desconto";
            this.metroTabPage6.VerticalScrollbarBarColor = true;
            this.metroTabPage6.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage6.VerticalScrollbarSize = 10;
            // 
            // FCONFIG_Vendas_Geral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 312);
            this.Controls.Add(this.metroTabControl2);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCONFIG_Vendas_Geral";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Geral";
            this.Load += new System.EventHandler(this.FCONFIG_Vendas_Geral_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditTipoDeOperacao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoOperacaoPadraoPDVGridLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.metroTabControl2.ResumeLayout(false);
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDigitoVerificador.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeQtdDigitosBal.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.metroTabPage6.ResumeLayout(false);
            this.metroTabPage6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton ovRB_Valor;
        private System.Windows.Forms.RadioButton ovRB_Percentual;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox ovTXT_CHAVE_ATENTICACAO;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEditTipoDeOperacao;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.GridLookUpEdit tipoOperacaoPadraoPDVGridLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private MetroFramework.Controls.MetroTabControl metroTabControl2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroTabPage metroTabPage6;
        private DevExpress.XtraEditors.TextEdit txtDigitoVerificador;
        private DevExpress.XtraEditors.ComboBoxEdit cbeQtdDigitosBal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPesoCodigo;
        private System.Windows.Forms.RadioButton rbPrecoCodigo;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl18;
    }
}