namespace PDV.VIEW.Forms.BI
{
    partial class BIVendedoresEClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BIVendedoresEClientes));
            this.vendasGeralPorVendedorChartControl = new DevExpress.XtraCharts.ChartControl();
            this.top10ClientesChartControl = new DevExpress.XtraCharts.ChartControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.dateDe = new DevExpress.XtraEditors.DateEdit();
            this.dateAte = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboOperacao = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vendasGeralPorVendedorChartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.top10ClientesChartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDe.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAte.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAte.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // vendasGeralPorVendedorChartControl
            // 
            this.vendasGeralPorVendedorChartControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vendasGeralPorVendedorChartControl.BorderOptions.Color = System.Drawing.Color.Gray;
            this.vendasGeralPorVendedorChartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.vendasGeralPorVendedorChartControl.Legend.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.vendasGeralPorVendedorChartControl.Legend.Name = "Default Legend";
            this.vendasGeralPorVendedorChartControl.Legend.Title.Text = "Produtos mais vendido";
            this.vendasGeralPorVendedorChartControl.Location = new System.Drawing.Point(7, 87);
            this.vendasGeralPorVendedorChartControl.Name = "vendasGeralPorVendedorChartControl";
            this.vendasGeralPorVendedorChartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.vendasGeralPorVendedorChartControl.Size = new System.Drawing.Size(1003, 233);
            this.vendasGeralPorVendedorChartControl.TabIndex = 0;
            // 
            // top10ClientesChartControl
            // 
            this.top10ClientesChartControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.top10ClientesChartControl.BorderOptions.Color = System.Drawing.Color.Gray;
            this.top10ClientesChartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.top10ClientesChartControl.Legend.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.top10ClientesChartControl.Legend.Name = "Default Legend";
            this.top10ClientesChartControl.Legend.Title.Text = "Produtos mais vendido";
            this.top10ClientesChartControl.Location = new System.Drawing.Point(6, 331);
            this.top10ClientesChartControl.Name = "top10ClientesChartControl";
            this.top10ClientesChartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.top10ClientesChartControl.Size = new System.Drawing.Size(1004, 251);
            this.top10ClientesChartControl.TabIndex = 2;
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
            this.simpleButton2.Location = new System.Drawing.Point(606, 9);
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
            this.dateDe.Location = new System.Drawing.Point(361, 18);
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
            this.dateAte.Location = new System.Drawing.Point(500, 18);
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
            this.label2.Location = new System.Drawing.Point(472, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 121;
            this.label2.Text = "até";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 119;
            this.label1.Text = "De";
            // 
            // comboOperacao
            // 
            this.comboOperacao.FormattingEnabled = true;
            this.comboOperacao.Location = new System.Drawing.Point(70, 17);
            this.comboOperacao.Name = "comboOperacao";
            this.comboOperacao.Size = new System.Drawing.Size(233, 21);
            this.comboOperacao.TabIndex = 122;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 123;
            this.label3.Text = "Operação";
            // 
            // BIVendedoresEClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 582);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboOperacao);
            this.Controls.Add(this.dateDe);
            this.Controls.Add(this.dateAte);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.top10ClientesChartControl);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.vendasGeralPorVendedorChartControl);
            this.MaximizeBox = false;
            this.Name = "BIVendedoresEClientes";
            this.ShowIcon = false;
            this.Text = "Painel BI - Vendedores e Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.vendasGeralPorVendedorChartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.top10ClientesChartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDe.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAte.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAte.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl vendasGeralPorVendedorChartControl;
        private DevExpress.XtraCharts.ChartControl top10ClientesChartControl;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.DateEdit dateDe;
        private DevExpress.XtraEditors.DateEdit dateAte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboOperacao;
        private System.Windows.Forms.Label label3;
    }
}