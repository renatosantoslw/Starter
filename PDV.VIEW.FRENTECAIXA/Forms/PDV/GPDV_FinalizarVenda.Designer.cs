
using PDV.UTIL.Components.Custom;
namespace PDV.VIEW.FRENTECAIXA.Forms
{
    partial class GPDV_FinalizarVenda
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, null, true, true);
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ovTXT_SubTotalVenda = new System.Windows.Forms.TextBox();
            this.ovTXT_TotalPagamentosVenda = new System.Windows.Forms.TextBox();
            this.ovTXT_TotalDesconto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ovTXT_FaltaVenda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ovCMB_FormaPagamento = new System.Windows.Forms.ComboBox();
            this.ovTXT_Vencimento = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ovTXT_TrocoVenda = new System.Windows.Forms.TextBox();
            this.ovTXT_TotalVenda = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ovTXT_Cliente = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ovTXT_Comanda = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.aguardePictureBox = new System.Windows.Forms.PictureBox();
            this.lblMensgamFinalizacao = new System.Windows.Forms.Label();
            this.ovTXT_QuantidadeParcelas = new System.Windows.Forms.TextBox();
            this.ovTXT_ValorPago = new System.Windows.Forms.TextBox();
            this.finalizarButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.valorFormaPagTextBox = new System.Windows.Forms.TextBox();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.ovGRD_Pagamentos = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.codFormaPagTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.finalizadoraFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgFormaDePagamento = new System.Windows.Forms.DataGridView();
            this.pictureBoxPropraganda = new System.Windows.Forms.PictureBox();
            this.btnFinalizarVenda = new DevExpress.XtraEditors.SimpleButton();
            this.btnLimparPagto = new DevExpress.XtraEditors.SimpleButton();
            this.btnDescontoItem = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemoverCliente = new DevExpress.XtraEditors.SimpleButton();
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.btnDescontoVenda = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aguardePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Pagamentos)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFormaDePagamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPropraganda)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(629, 568);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "SUB TOTAL";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(401, 570);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Valor Recebido (F1)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ovTXT_SubTotalVenda
            // 
            this.ovTXT_SubTotalVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_SubTotalVenda.BackColor = System.Drawing.Color.White;
            this.ovTXT_SubTotalVenda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ovTXT_SubTotalVenda.Font = new System.Drawing.Font("Calibri", 25.25F, System.Drawing.FontStyle.Bold);
            this.ovTXT_SubTotalVenda.ForeColor = System.Drawing.Color.SteelBlue;
            this.ovTXT_SubTotalVenda.Location = new System.Drawing.Point(587, 596);
            this.ovTXT_SubTotalVenda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 1);
            this.ovTXT_SubTotalVenda.Name = "ovTXT_SubTotalVenda";
            this.ovTXT_SubTotalVenda.ReadOnly = true;
            this.ovTXT_SubTotalVenda.Size = new System.Drawing.Size(180, 42);
            this.ovTXT_SubTotalVenda.TabIndex = 12;
            this.ovTXT_SubTotalVenda.TabStop = false;
            this.ovTXT_SubTotalVenda.Text = "0,00";
            this.ovTXT_SubTotalVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ovTXT_TotalPagamentosVenda
            // 
            this.ovTXT_TotalPagamentosVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_TotalPagamentosVenda.BackColor = System.Drawing.Color.White;
            this.ovTXT_TotalPagamentosVenda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ovTXT_TotalPagamentosVenda.Font = new System.Drawing.Font("Calibri", 25.25F, System.Drawing.FontStyle.Bold);
            this.ovTXT_TotalPagamentosVenda.ForeColor = System.Drawing.Color.SteelBlue;
            this.ovTXT_TotalPagamentosVenda.Location = new System.Drawing.Point(385, 597);
            this.ovTXT_TotalPagamentosVenda.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.ovTXT_TotalPagamentosVenda.Name = "ovTXT_TotalPagamentosVenda";
            this.ovTXT_TotalPagamentosVenda.ReadOnly = true;
            this.ovTXT_TotalPagamentosVenda.Size = new System.Drawing.Size(180, 42);
            this.ovTXT_TotalPagamentosVenda.TabIndex = 14;
            this.ovTXT_TotalPagamentosVenda.TabStop = false;
            this.ovTXT_TotalPagamentosVenda.Text = "0,00";
            this.ovTXT_TotalPagamentosVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ovTXT_TotalDesconto
            // 
            this.ovTXT_TotalDesconto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_TotalDesconto.BackColor = System.Drawing.Color.White;
            this.ovTXT_TotalDesconto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ovTXT_TotalDesconto.Font = new System.Drawing.Font("Calibri", 25.25F, System.Drawing.FontStyle.Bold);
            this.ovTXT_TotalDesconto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ovTXT_TotalDesconto.Location = new System.Drawing.Point(770, 596);
            this.ovTXT_TotalDesconto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 1);
            this.ovTXT_TotalDesconto.Name = "ovTXT_TotalDesconto";
            this.ovTXT_TotalDesconto.ReadOnly = true;
            this.ovTXT_TotalDesconto.Size = new System.Drawing.Size(180, 42);
            this.ovTXT_TotalDesconto.TabIndex = 13;
            this.ovTXT_TotalDesconto.TabStop = false;
            this.ovTXT_TotalDesconto.Text = "0,00";
            this.ovTXT_TotalDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.SteelBlue;
            this.label8.Location = new System.Drawing.Point(805, 569);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 23);
            this.label8.TabIndex = 11;
            this.label8.Text = "DESCONTO (F8)\r\n";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ovTXT_FaltaVenda
            // 
            this.ovTXT_FaltaVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_FaltaVenda.BackColor = System.Drawing.Color.White;
            this.ovTXT_FaltaVenda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ovTXT_FaltaVenda.Font = new System.Drawing.Font("Calibri", 25.25F, System.Drawing.FontStyle.Bold);
            this.ovTXT_FaltaVenda.ForeColor = System.Drawing.Color.Red;
            this.ovTXT_FaltaVenda.Location = new System.Drawing.Point(982, 596);
            this.ovTXT_FaltaVenda.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.ovTXT_FaltaVenda.Name = "ovTXT_FaltaVenda";
            this.ovTXT_FaltaVenda.ReadOnly = true;
            this.ovTXT_FaltaVenda.Size = new System.Drawing.Size(116, 42);
            this.ovTXT_FaltaVenda.TabIndex = 15;
            this.ovTXT_FaltaVenda.TabStop = false;
            this.ovTXT_FaltaVenda.Text = "0,00";
            this.ovTXT_FaltaVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(1013, 569);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "FALTA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ovCMB_FormaPagamento
            // 
            this.ovCMB_FormaPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ovCMB_FormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ovCMB_FormaPagamento.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_FormaPagamento.FormattingEnabled = true;
            this.ovCMB_FormaPagamento.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.ovCMB_FormaPagamento.Location = new System.Drawing.Point(56, 323);
            this.ovCMB_FormaPagamento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ovCMB_FormaPagamento.Name = "ovCMB_FormaPagamento";
            this.ovCMB_FormaPagamento.Size = new System.Drawing.Size(105, 24);
            this.ovCMB_FormaPagamento.TabIndex = 1;
            this.ovCMB_FormaPagamento.Visible = false;
            this.ovCMB_FormaPagamento.SelectedIndexChanged += new System.EventHandler(this.ovCMB_FormaPagamento_SelectedIndexChanged);
            // 
            // ovTXT_Vencimento
            // 
            this.ovTXT_Vencimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ovTXT_Vencimento.CalendarFont = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ovTXT_Vencimento.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_Vencimento.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.ovTXT_Vencimento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_Vencimento.Location = new System.Drawing.Point(56, 296);
            this.ovTXT_Vencimento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ovTXT_Vencimento.Name = "ovTXT_Vencimento";
            this.ovTXT_Vencimento.Size = new System.Drawing.Size(116, 23);
            this.ovTXT_Vencimento.TabIndex = 66;
            this.ovTXT_Vencimento.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(1141, 569);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "TROCO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ovTXT_TrocoVenda
            // 
            this.ovTXT_TrocoVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_TrocoVenda.BackColor = System.Drawing.Color.White;
            this.ovTXT_TrocoVenda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ovTXT_TrocoVenda.Font = new System.Drawing.Font("Calibri", 25.25F, System.Drawing.FontStyle.Bold);
            this.ovTXT_TrocoVenda.ForeColor = System.Drawing.Color.Green;
            this.ovTXT_TrocoVenda.Location = new System.Drawing.Point(1132, 594);
            this.ovTXT_TrocoVenda.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.ovTXT_TrocoVenda.Name = "ovTXT_TrocoVenda";
            this.ovTXT_TrocoVenda.ReadOnly = true;
            this.ovTXT_TrocoVenda.Size = new System.Drawing.Size(130, 42);
            this.ovTXT_TrocoVenda.TabIndex = 17;
            this.ovTXT_TrocoVenda.TabStop = false;
            this.ovTXT_TrocoVenda.Text = "0,00";
            this.ovTXT_TrocoVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ovTXT_TotalVenda
            // 
            this.ovTXT_TotalVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_TotalVenda.BackColor = System.Drawing.Color.White;
            this.ovTXT_TotalVenda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ovTXT_TotalVenda.Font = new System.Drawing.Font("Calibri", 26F, System.Drawing.FontStyle.Bold);
            this.ovTXT_TotalVenda.ForeColor = System.Drawing.Color.SteelBlue;
            this.ovTXT_TotalVenda.Location = new System.Drawing.Point(1023, 136);
            this.ovTXT_TotalVenda.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.ovTXT_TotalVenda.Name = "ovTXT_TotalVenda";
            this.ovTXT_TotalVenda.ReadOnly = true;
            this.ovTXT_TotalVenda.Size = new System.Drawing.Size(225, 43);
            this.ovTXT_TotalVenda.TabIndex = 16;
            this.ovTXT_TotalVenda.TabStop = false;
            this.ovTXT_TotalVenda.Text = "0,00";
            this.ovTXT_TotalVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(882, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 26);
            this.label7.TabIndex = 7;
            this.label7.Text = "Total Venda :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ovTXT_Cliente
            // 
            this.ovTXT_Cliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ovTXT_Cliente.AutoSize = true;
            this.ovTXT_Cliente.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Cliente.Location = new System.Drawing.Point(92, 1314);
            this.ovTXT_Cliente.Name = "ovTXT_Cliente";
            this.ovTXT_Cliente.Size = new System.Drawing.Size(177, 18);
            this.ovTXT_Cliente.TabIndex = 1;
            this.ovTXT_Cliente.Text = "<Cliente Não Informado>";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(7, 1314);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 18);
            this.label12.TabIndex = 0;
            this.label12.Text = "CPF/CNPJ:";
            // 
            // ovTXT_Comanda
            // 
            this.ovTXT_Comanda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_Comanda.AutoSize = true;
            this.ovTXT_Comanda.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.ovTXT_Comanda.Location = new System.Drawing.Point(1013, 12);
            this.ovTXT_Comanda.Name = "ovTXT_Comanda";
            this.ovTXT_Comanda.Size = new System.Drawing.Size(169, 16);
            this.ovTXT_Comanda.TabIndex = 2;
            this.ovTXT_Comanda.Text = "<Comanda Não Informada>";
            this.ovTXT_Comanda.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.aguardePictureBox);
            this.panel1.Controls.Add(this.lblMensgamFinalizacao);
            this.panel1.Controls.Add(this.ovTXT_Comanda);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1275, 41);
            this.panel1.TabIndex = 68;
            // 
            // aguardePictureBox
            // 
            this.aguardePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aguardePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.aguardePictureBox.Image = global::PDV.VIEW.FRENTECAIXA.Properties.Resources.load_chat;
            this.aguardePictureBox.Location = new System.Drawing.Point(1186, 1);
            this.aguardePictureBox.Name = "aguardePictureBox";
            this.aguardePictureBox.Size = new System.Drawing.Size(86, 46);
            this.aguardePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.aguardePictureBox.TabIndex = 113;
            this.aguardePictureBox.TabStop = false;
            this.aguardePictureBox.Visible = false;
            // 
            // lblMensgamFinalizacao
            // 
            this.lblMensgamFinalizacao.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMensgamFinalizacao.AutoSize = true;
            this.lblMensgamFinalizacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Bold);
            this.lblMensgamFinalizacao.ForeColor = System.Drawing.Color.Transparent;
            this.lblMensgamFinalizacao.Location = new System.Drawing.Point(455, 0);
            this.lblMensgamFinalizacao.Name = "lblMensgamFinalizacao";
            this.lblMensgamFinalizacao.Size = new System.Drawing.Size(364, 40);
            this.lblMensgamFinalizacao.TabIndex = 1;
            this.lblMensgamFinalizacao.Text = "Finalizando a Venda";
            // 
            // ovTXT_QuantidadeParcelas
            // 
            this.ovTXT_QuantidadeParcelas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ovTXT_QuantidadeParcelas.Location = new System.Drawing.Point(56, 351);
            this.ovTXT_QuantidadeParcelas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ovTXT_QuantidadeParcelas.Name = "ovTXT_QuantidadeParcelas";
            this.ovTXT_QuantidadeParcelas.Size = new System.Drawing.Size(109, 23);
            this.ovTXT_QuantidadeParcelas.TabIndex = 70;
            this.ovTXT_QuantidadeParcelas.Visible = false;
            // 
            // ovTXT_ValorPago
            // 
            this.ovTXT_ValorPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ovTXT_ValorPago.Location = new System.Drawing.Point(56, 378);
            this.ovTXT_ValorPago.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ovTXT_ValorPago.Name = "ovTXT_ValorPago";
            this.ovTXT_ValorPago.Size = new System.Drawing.Size(109, 23);
            this.ovTXT_ValorPago.TabIndex = 71;
            this.ovTXT_ValorPago.Visible = false;
            this.ovTXT_ValorPago.TextChanged += new System.EventHandler(this.ovTXT_ValorPago_TextChanged);
            // 
            // finalizarButton
            // 
            this.finalizarButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.finalizarButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.finalizarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finalizarButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalizarButton.ForeColor = System.Drawing.Color.White;
            this.finalizarButton.Location = new System.Drawing.Point(752, 928);
            this.finalizarButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.finalizarButton.Name = "finalizarButton";
            this.finalizarButton.Size = new System.Drawing.Size(270, 32);
            this.finalizarButton.TabIndex = 0;
            this.finalizarButton.Text = "FINALIZAR VENDA (F10)";
            this.finalizarButton.UseVisualStyleBackColor = false;
            this.finalizarButton.Click += new System.EventHandler(this.finalizarButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackColor = System.Drawing.Color.MidnightBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(476, 928);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(270, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "CANCELAR (F3)";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackColor = System.Drawing.Color.MidnightBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(200, 928);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(270, 32);
            this.button2.TabIndex = 0;
            this.button2.Text = "VOLTAR (ESC)";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(136)))), ((int)(((byte)(241)))));
            this.panel2.Location = new System.Drawing.Point(-2, 1337);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1256, 31);
            this.panel2.TabIndex = 75;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(10, 2);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(191, 26);
            this.labelControl1.TabIndex = 78;
            this.labelControl1.Text = "Forma de Pagamento:";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(470, -1);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 26);
            this.labelControl2.TabIndex = 79;
            this.labelControl2.Text = "Valor:";
            // 
            // valorFormaPagTextBox
            // 
            this.valorFormaPagTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valorFormaPagTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.valorFormaPagTextBox.Font = new System.Drawing.Font("Calibri", 26F, System.Drawing.FontStyle.Bold);
            this.valorFormaPagTextBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.valorFormaPagTextBox.Location = new System.Drawing.Point(604, 1);
            this.valorFormaPagTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.valorFormaPagTextBox.Name = "valorFormaPagTextBox";
            this.valorFormaPagTextBox.Size = new System.Drawing.Size(225, 43);
            this.valorFormaPagTextBox.TabIndex = 2;
            this.valorFormaPagTextBox.Text = "0,00";
            this.valorFormaPagTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.valorFormaPagTextBox.TextChanged += new System.EventHandler(this.valorFormaPagTextBox_TextChanged);
            this.valorFormaPagTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.valorFormaPagTextBox_KeyDown);
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarControl1.Location = new System.Drawing.Point(22, 880);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Size = new System.Drawing.Size(1202, 43);
            this.progressBarControl1.TabIndex = 112;
            // 
            // ovGRD_Pagamentos
            // 
            this.ovGRD_Pagamentos.AllowUserToAddRows = false;
            this.ovGRD_Pagamentos.AllowUserToDeleteRows = false;
            this.ovGRD_Pagamentos.AllowUserToResizeColumns = false;
            this.ovGRD_Pagamentos.AllowUserToResizeRows = false;
            this.ovGRD_Pagamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovGRD_Pagamentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ovGRD_Pagamentos.BackgroundColor = System.Drawing.Color.White;
            this.ovGRD_Pagamentos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ovGRD_Pagamentos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_Pagamentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.ovGRD_Pagamentos.ColumnHeadersHeight = 30;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ovGRD_Pagamentos.DefaultCellStyle = dataGridViewCellStyle10;
            this.ovGRD_Pagamentos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ovGRD_Pagamentos.GridColor = System.Drawing.Color.White;
            this.ovGRD_Pagamentos.Location = new System.Drawing.Point(12, 334);
            this.ovGRD_Pagamentos.Margin = new System.Windows.Forms.Padding(2);
            this.ovGRD_Pagamentos.MultiSelect = false;
            this.ovGRD_Pagamentos.Name = "ovGRD_Pagamentos";
            this.ovGRD_Pagamentos.ReadOnly = true;
            this.ovGRD_Pagamentos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_Pagamentos.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.ovGRD_Pagamentos.RowHeadersVisible = false;
            this.ovGRD_Pagamentos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.ovGRD_Pagamentos.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.ovGRD_Pagamentos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ovGRD_Pagamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ovGRD_Pagamentos.ShowCellErrors = false;
            this.ovGRD_Pagamentos.ShowCellToolTips = false;
            this.ovGRD_Pagamentos.ShowEditingIcon = false;
            this.ovGRD_Pagamentos.ShowRowErrors = false;
            this.ovGRD_Pagamentos.Size = new System.Drawing.Size(58, 178);
            this.ovGRD_Pagamentos.TabIndex = 0;
            this.ovGRD_Pagamentos.Visible = false;
            this.ovGRD_Pagamentos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ovGRD_Pagamentos_CellFormatting);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(76, 689);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 16);
            this.label13.TabIndex = 1;
            this.label13.Text = "Código/Descrição:";
            this.label13.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.labelControl1);
            this.panel3.Controls.Add(this.codFormaPagTextBox);
            this.panel3.Controls.Add(this.labelControl2);
            this.panel3.Controls.Add(this.valorFormaPagTextBox);
            this.panel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Location = new System.Drawing.Point(418, 54);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(845, 77);
            this.panel3.TabIndex = 114;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // codFormaPagTextBox
            // 
            this.codFormaPagTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.codFormaPagTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codFormaPagTextBox.Font = new System.Drawing.Font("Tahoma", 27F, System.Drawing.FontStyle.Bold);
            this.codFormaPagTextBox.Location = new System.Drawing.Point(3, 29);
            this.codFormaPagTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.codFormaPagTextBox.Name = "codFormaPagTextBox";
            this.codFormaPagTextBox.Size = new System.Drawing.Size(170, 44);
            this.codFormaPagTextBox.TabIndex = 1;
            this.codFormaPagTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.codFormaPagTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.codFormaPagTextBox_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(416, 162);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 19);
            this.label14.TabIndex = 115;
            this.label14.Text = "Recebimentos";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // finalizadoraFlowLayoutPanel
            // 
            this.finalizadoraFlowLayoutPanel.AllowDrop = true;
            this.finalizadoraFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.finalizadoraFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.finalizadoraFlowLayoutPanel.Location = new System.Drawing.Point(418, 186);
            this.finalizadoraFlowLayoutPanel.Name = "finalizadoraFlowLayoutPanel";
            this.finalizadoraFlowLayoutPanel.Size = new System.Drawing.Size(844, 382);
            this.finalizadoraFlowLayoutPanel.TabIndex = 118;
            this.finalizadoraFlowLayoutPanel.WrapContents = false;
            this.finalizadoraFlowLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.finalizadoraFlowLayoutPanel_Paint);
            // 
            // panel4
            // 
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.dgFormaDePagamento);
            this.panel4.Location = new System.Drawing.Point(8, 54);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(405, 264);
            this.panel4.TabIndex = 120;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // dgFormaDePagamento
            // 
            this.dgFormaDePagamento.AllowUserToAddRows = false;
            this.dgFormaDePagamento.AllowUserToDeleteRows = false;
            this.dgFormaDePagamento.AllowUserToResizeColumns = false;
            this.dgFormaDePagamento.AllowUserToResizeRows = false;
            this.dgFormaDePagamento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgFormaDePagamento.BackgroundColor = System.Drawing.Color.White;
            this.dgFormaDePagamento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgFormaDePagamento.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgFormaDePagamento.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFormaDePagamento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgFormaDePagamento.ColumnHeadersHeight = 25;
            this.dgFormaDePagamento.ColumnHeadersVisible = false;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFormaDePagamento.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgFormaDePagamento.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgFormaDePagamento.GridColor = System.Drawing.Color.White;
            this.dgFormaDePagamento.Location = new System.Drawing.Point(11, 12);
            this.dgFormaDePagamento.Margin = new System.Windows.Forms.Padding(2);
            this.dgFormaDePagamento.MultiSelect = false;
            this.dgFormaDePagamento.Name = "dgFormaDePagamento";
            this.dgFormaDePagamento.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFormaDePagamento.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgFormaDePagamento.RowHeadersVisible = false;
            this.dgFormaDePagamento.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.SteelBlue;
            this.dgFormaDePagamento.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgFormaDePagamento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgFormaDePagamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFormaDePagamento.ShowCellErrors = false;
            this.dgFormaDePagamento.ShowEditingIcon = false;
            this.dgFormaDePagamento.ShowRowErrors = false;
            this.dgFormaDePagamento.Size = new System.Drawing.Size(376, 226);
            this.dgFormaDePagamento.TabIndex = 0;
            // 
            // pictureBoxPropraganda
            // 
            this.pictureBoxPropraganda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxPropraganda.Location = new System.Drawing.Point(34, 252);
            this.pictureBoxPropraganda.Name = "pictureBoxPropraganda";
            this.pictureBoxPropraganda.Size = new System.Drawing.Size(370, 314);
            this.pictureBoxPropraganda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxPropraganda.TabIndex = 119;
            this.pictureBoxPropraganda.TabStop = false;
            this.pictureBoxPropraganda.Visible = false;
            // 
            // btnFinalizarVenda
            // 
            this.btnFinalizarVenda.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.btnFinalizarVenda.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnFinalizarVenda.Appearance.Options.UseBackColor = true;
            this.btnFinalizarVenda.Appearance.Options.UseForeColor = true;
            this.btnFinalizarVenda.Location = new System.Drawing.Point(354, 675);
            this.btnFinalizarVenda.Name = "btnFinalizarVenda";
            this.btnFinalizarVenda.Size = new System.Drawing.Size(87, 42);
            this.btnFinalizarVenda.TabIndex = 121;
            this.btnFinalizarVenda.Text = "Finalizar\r\n(F5)";
            this.btnFinalizarVenda.Click += new System.EventHandler(this.btnFinalizarVenda_Click);
            // 
            // btnLimparPagto
            // 
            this.btnLimparPagto.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLimparPagto.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnLimparPagto.Appearance.Options.UseBackColor = true;
            this.btnLimparPagto.Appearance.Options.UseForeColor = true;
            this.btnLimparPagto.Location = new System.Drawing.Point(449, 675);
            this.btnLimparPagto.Name = "btnLimparPagto";
            this.btnLimparPagto.Size = new System.Drawing.Size(87, 42);
            this.btnLimparPagto.TabIndex = 121;
            this.btnLimparPagto.Text = "Limpar Pagtos\r\n(F3)";
            this.btnLimparPagto.Click += new System.EventHandler(this.btnLimparPagto_Click);
            // 
            // btnDescontoItem
            // 
            this.btnDescontoItem.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDescontoItem.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDescontoItem.Appearance.Options.UseBackColor = true;
            this.btnDescontoItem.Appearance.Options.UseForeColor = true;
            this.btnDescontoItem.Location = new System.Drawing.Point(544, 675);
            this.btnDescontoItem.Name = "btnDescontoItem";
            this.btnDescontoItem.Size = new System.Drawing.Size(87, 42);
            this.btnDescontoItem.TabIndex = 121;
            this.btnDescontoItem.Text = "Desconto Item\r\n(F9)";
            this.btnDescontoItem.Click += new System.EventHandler(this.btnDescontoItem_Click);
            // 
            // btnRemoverCliente
            // 
            this.btnRemoverCliente.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRemoverCliente.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRemoverCliente.Appearance.Options.UseBackColor = true;
            this.btnRemoverCliente.Appearance.Options.UseForeColor = true;
            this.btnRemoverCliente.Location = new System.Drawing.Point(734, 675);
            this.btnRemoverCliente.Name = "btnRemoverCliente";
            this.btnRemoverCliente.Size = new System.Drawing.Size(87, 42);
            this.btnRemoverCliente.TabIndex = 121;
            this.btnRemoverCliente.Text = "Remover Cliente\r\n(F7)";
            this.btnRemoverCliente.Click += new System.EventHandler(this.btnRemoverCliente_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.btnVoltar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Appearance.Options.UseBackColor = true;
            this.btnVoltar.Appearance.Options.UseForeColor = true;
            this.btnVoltar.Location = new System.Drawing.Point(829, 675);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(87, 42);
            this.btnVoltar.TabIndex = 121;
            this.btnVoltar.Text = "Voltar\n(Esc)";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnDescontoVenda
            // 
            this.btnDescontoVenda.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDescontoVenda.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDescontoVenda.Appearance.Options.UseBackColor = true;
            this.btnDescontoVenda.Appearance.Options.UseForeColor = true;
            this.btnDescontoVenda.Location = new System.Drawing.Point(639, 675);
            this.btnDescontoVenda.Name = "btnDescontoVenda";
            this.btnDescontoVenda.Size = new System.Drawing.Size(87, 42);
            this.btnDescontoVenda.TabIndex = 121;
            this.btnDescontoVenda.Text = "Desconto Venda\r\n(F8)";
            this.btnDescontoVenda.Click += new System.EventHandler(this.btnDescontoVenda_Click);
            // 
            // GPDV_FinalizarVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1274, 749);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnRemoverCliente);
            this.Controls.Add(this.btnDescontoVenda);
            this.Controls.Add(this.btnDescontoItem);
            this.Controls.Add(this.btnLimparPagto);
            this.Controls.Add(this.btnFinalizarVenda);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pictureBoxPropraganda);
            this.Controls.Add(this.finalizadoraFlowLayoutPanel);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.progressBarControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.finalizarButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ovTXT_TrocoVenda);
            this.Controls.Add(this.ovTXT_SubTotalVenda);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ovTXT_TotalVenda);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ovTXT_FaltaVenda);
            this.Controls.Add(this.ovTXT_TotalPagamentosVenda);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ovTXT_TotalDesconto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ovTXT_Cliente);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ovGRD_Pagamentos);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ovTXT_ValorPago);
            this.Controls.Add(this.ovTXT_QuantidadeParcelas);
            this.Controls.Add(this.ovTXT_Vencimento);
            this.Controls.Add(this.ovCMB_FormaPagamento);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GPDV_FinalizarVenda";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GPDV_FinalizarVenda_Load);
            this.Shown += new System.EventHandler(this.GPDV_FinalizarVenda_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aguardePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Pagamentos)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFormaDePagamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPropraganda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ovTXT_SubTotalVenda;
        private System.Windows.Forms.TextBox ovTXT_TotalPagamentosVenda;
        private System.Windows.Forms.TextBox ovTXT_TotalDesconto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ovTXT_FaltaVenda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ovCMB_FormaPagamento;
        private System.Windows.Forms.TextBox ovTXT_TotalVenda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ovTXT_TrocoVenda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker ovTXT_Vencimento;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label ovTXT_Cliente;
        private System.Windows.Forms.Label ovTXT_Comanda;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ovTXT_QuantidadeParcelas;
        private System.Windows.Forms.TextBox ovTXT_ValorPago;
        private System.Windows.Forms.Button finalizarButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.TextBox valorFormaPagTextBox;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        public System.Windows.Forms.Label lblMensgamFinalizacao;
        private System.Windows.Forms.DataGridView ovGRD_Pagamentos;
        private System.Windows.Forms.PictureBox aguardePictureBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgFormaDePagamento;
        private System.Windows.Forms.FlowLayoutPanel finalizadoraFlowLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBoxPropraganda;
        private System.Windows.Forms.TextBox codFormaPagTextBox;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.SimpleButton btnFinalizarVenda;
        private DevExpress.XtraEditors.SimpleButton btnLimparPagto;
        private DevExpress.XtraEditors.SimpleButton btnDescontoItem;
        private DevExpress.XtraEditors.SimpleButton btnRemoverCliente;
        private DevExpress.XtraEditors.SimpleButton btnVoltar;
        private DevExpress.XtraEditors.SimpleButton btnDescontoVenda;
    }
}