namespace PDV.VIEW.Forms.Cadastro
{
    partial class FCA_Composicao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_Composicao));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalvar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.spinQuantidade = new DevExpress.XtraEditors.SpinEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMateriaPrima = new MetroFramework.Controls.MetroComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.spinQuantidade.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 142;
            this.label1.Text = "Matéria Prima";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnSalvar.Appearance.Options.UseForeColor = true;
            this.btnSalvar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.ImageOptions.Image")));
            this.btnSalvar.Location = new System.Drawing.Point(398, 123);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSalvar.Size = new System.Drawing.Size(88, 33);
            this.btnSalvar.TabIndex = 144;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Appearance.Options.UseForeColor = true;
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(304, 123);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnCancelar.Size = new System.Drawing.Size(88, 33);
            this.btnCancelar.TabIndex = 143;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // spinQuantidade
            // 
            this.spinQuantidade.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinQuantidade.Location = new System.Drawing.Point(25, 82);
            this.spinQuantidade.Name = "spinQuantidade";
            this.spinQuantidade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinQuantidade.Size = new System.Drawing.Size(100, 20);
            this.spinQuantidade.TabIndex = 145;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 146;
            this.label2.Text = "Quantidade";
            // 
            // cmbMateriaPrima
            // 
            this.cmbMateriaPrima.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbMateriaPrima.FormattingEnabled = true;
            this.cmbMateriaPrima.ItemHeight = 19;
            this.cmbMateriaPrima.Location = new System.Drawing.Point(25, 28);
            this.cmbMateriaPrima.Name = "cmbMateriaPrima";
            this.cmbMateriaPrima.Size = new System.Drawing.Size(355, 25);
            this.cmbMateriaPrima.TabIndex = 147;
            this.cmbMateriaPrima.UseSelectable = true;
            // 
            // FCA_Composicao
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 168);
            this.Controls.Add(this.cmbMateriaPrima);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.spinQuantidade);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "FCA_Composicao";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Composição";
            ((System.ComponentModel.ISupportInitialize)(this.spinQuantidade.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnSalvar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SpinEdit spinQuantidade;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroComboBox cmbMateriaPrima;
    }
}