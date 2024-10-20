namespace PDV.VIEW.Forms.BI
{
    partial class BIContasAReceber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BIContasAReceber));
            this.contasAReceberPorFormaDePagamento = new DevExpress.XtraCharts.ChartControl();
            this.contasAReceberPorSituacao = new DevExpress.XtraCharts.ChartControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.dateDe = new DevExpress.XtraEditors.DateEdit();
            this.dateAte = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboFiltrarPor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.contasAReceberPorFormaDePagamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contasAReceberPorSituacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDe.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAte.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAte.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // contasAReceberPorFormaDePagamento
            // 
            this.contasAReceberPorFormaDePagamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contasAReceberPorFormaDePagamento.BorderOptions.Color = System.Drawing.Color.Gray;
            this.contasAReceberPorFormaDePagamento.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.contasAReceberPorFormaDePagamento.Legend.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.contasAReceberPorFormaDePagamento.Legend.Name = "Default Legend";
            this.contasAReceberPorFormaDePagamento.Legend.Title.Text = "Produtos mais vendido";
            this.contasAReceberPorFormaDePagamento.Location = new System.Drawing.Point(5, 352);
            this.contasAReceberPorFormaDePagamento.Name = "contasAReceberPorFormaDePagamento";
            this.contasAReceberPorFormaDePagamento.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.contasAReceberPorFormaDePagamento.Size = new System.Drawing.Size(1014, 226);
            this.contasAReceberPorFormaDePagamento.TabIndex = 0;
            // 
            // contasAReceberPorSituacao
            // 
            this.contasAReceberPorSituacao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contasAReceberPorSituacao.BorderOptions.Color = System.Drawing.Color.Gray;
            this.contasAReceberPorSituacao.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.contasAReceberPorSituacao.Legend.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.contasAReceberPorSituacao.Legend.Name = "Default Legend";
            this.contasAReceberPorSituacao.Legend.Title.Text = "Produtos mais vendido";
            this.contasAReceberPorSituacao.Location = new System.Drawing.Point(5, 46);
            this.contasAReceberPorSituacao.Name = "contasAReceberPorSituacao";
            this.contasAReceberPorSituacao.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.contasAReceberPorSituacao.Size = new System.Drawing.Size(1014, 300);
            this.contasAReceberPorSituacao.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(547, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(126, 23);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Carregar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButton2.Location = new System.Drawing.Point(584, 3);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton2.Size = new System.Drawing.Size(37, 37);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "Atualizar Dados";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // dateDe
            // 
            this.dateDe.EditValue = null;
            this.dateDe.Location = new System.Drawing.Point(339, 12);
            this.dateDe.Name = "dateDe";
            this.dateDe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDe.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDe.Size = new System.Drawing.Size(100, 20);
            this.dateDe.TabIndex = 118;
            // 
            // dateAte
            // 
            this.dateAte.EditValue = null;
            this.dateAte.Location = new System.Drawing.Point(478, 12);
            this.dateAte.Name = "dateAte";
            this.dateAte.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateAte.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateAte.Size = new System.Drawing.Size(100, 20);
            this.dateAte.TabIndex = 120;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 121;
            this.label2.Text = "até";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 119;
            this.label1.Text = "De";
            // 
            // comboFiltrarPor
            // 
            this.comboFiltrarPor.FormattingEnabled = true;
            this.comboFiltrarPor.Location = new System.Drawing.Point(78, 12);
            this.comboFiltrarPor.Name = "comboFiltrarPor";
            this.comboFiltrarPor.Size = new System.Drawing.Size(217, 21);
            this.comboFiltrarPor.TabIndex = 122;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 123;
            this.label3.Text = "Filtrar por";
            // 
            // BIContasAReceber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 582);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboFiltrarPor);
            this.Controls.Add(this.dateDe);
            this.Controls.Add(this.dateAte);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contasAReceberPorSituacao);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.contasAReceberPorFormaDePagamento);
            this.MaximizeBox = false;
            this.Name = "BIContasAReceber";
            this.ShowIcon = false;
            this.Text = "Painel BI - Contas a Recebar";
            ((System.ComponentModel.ISupportInitialize)(this.contasAReceberPorFormaDePagamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contasAReceberPorSituacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDe.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAte.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAte.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl contasAReceberPorFormaDePagamento;
        private DevExpress.XtraCharts.ChartControl contasAReceberPorSituacao;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.DateEdit dateDe;
        private DevExpress.XtraEditors.DateEdit dateAte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboFiltrarPor;
        private System.Windows.Forms.Label label3;
    }
}