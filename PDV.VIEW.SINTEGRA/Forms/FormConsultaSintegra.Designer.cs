namespace PDV.VIEW.SINTEGRA.Forms
{
    partial class FormConsultaSintegra
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.maskedTxtCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ttbLetras = new System.Windows.Forms.TextBox();
            this.lblCaptcha = new System.Windows.Forms.Label();
            this.picLetras = new System.Windows.Forms.PictureBox();
            this.gbDadosConsulta = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSecundarias = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDataSituacaoEspecial = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSituacaoEspecial = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMotivoSituacaoCadastral = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDataSituacaoCadastral = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSituacaoCadastral = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBoxEnteFederativo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxNaturezaJuridica = new System.Windows.Forms.TextBox();
            this.lblBairro = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.lblNomeFantasia = new System.Windows.Forms.Label();
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.lblUF = new System.Windows.Forms.Label();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.lblCidade = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCnae = new System.Windows.Forms.TextBox();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.lblCep = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.TextBox();
            this.lblRazao = new System.Windows.Forms.Label();
            this.txtRazao = new System.Windows.Forms.TextBox();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLetras)).BeginInit();
            this.gbDadosConsulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAtualizar);
            this.groupBox1.Controls.Add(this.maskedTxtCNPJ);
            this.groupBox1.Controls.Add(this.btnEnviar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ttbLetras);
            this.groupBox1.Controls.Add(this.lblCaptcha);
            this.groupBox1.Controls.Add(this.picLetras);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 202);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.Location = new System.Drawing.Point(122, 134);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(119, 25);
            this.btnAtualizar.TabIndex = 4;
            this.btnAtualizar.Text = "Atualizar Captcha";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.button2_Click);
            // 
            // maskedTxtCNPJ
            // 
            this.maskedTxtCNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTxtCNPJ.Location = new System.Drawing.Point(11, 36);
            this.maskedTxtCNPJ.Mask = "00,000,000/0000-00";
            this.maskedTxtCNPJ.Name = "maskedTxtCNPJ";
            this.maskedTxtCNPJ.Size = new System.Drawing.Size(230, 29);
            this.maskedTxtCNPJ.TabIndex = 1;
            this.maskedTxtCNPJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(149, 164);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(92, 29);
            this.btnEnviar.TabIndex = 3;
            this.btnEnviar.Text = "Consultar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Informe o CNPJ:";
            // 
            // ttbLetras
            // 
            this.ttbLetras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ttbLetras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ttbLetras.Location = new System.Drawing.Point(11, 164);
            this.ttbLetras.MaxLength = 10;
            this.ttbLetras.Name = "ttbLetras";
            this.ttbLetras.Size = new System.Drawing.Size(132, 26);
            this.ttbLetras.TabIndex = 2;
            this.ttbLetras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ttbLetras.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ttbLetras_KeyDown);
            // 
            // lblCaptcha
            // 
            this.lblCaptcha.AutoSize = true;
            this.lblCaptcha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptcha.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCaptcha.Location = new System.Drawing.Point(8, 146);
            this.lblCaptcha.Name = "lblCaptcha";
            this.lblCaptcha.Size = new System.Drawing.Size(58, 13);
            this.lblCaptcha.TabIndex = 2;
            this.lblCaptcha.Text = "Captcha:";
            // 
            // picLetras
            // 
            this.picLetras.Location = new System.Drawing.Point(11, 75);
            this.picLetras.Name = "picLetras";
            this.picLetras.Size = new System.Drawing.Size(230, 53);
            this.picLetras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLetras.TabIndex = 3;
            this.picLetras.TabStop = false;
            // 
            // gbDadosConsulta
            // 
            this.gbDadosConsulta.Controls.Add(this.label15);
            this.gbDadosConsulta.Controls.Add(this.label14);
            this.gbDadosConsulta.Controls.Add(this.txtSecundarias);
            this.gbDadosConsulta.Controls.Add(this.label11);
            this.gbDadosConsulta.Controls.Add(this.txtDataSituacaoEspecial);
            this.gbDadosConsulta.Controls.Add(this.label12);
            this.gbDadosConsulta.Controls.Add(this.txtSituacaoEspecial);
            this.gbDadosConsulta.Controls.Add(this.label13);
            this.gbDadosConsulta.Controls.Add(this.txtMotivoSituacaoCadastral);
            this.gbDadosConsulta.Controls.Add(this.label9);
            this.gbDadosConsulta.Controls.Add(this.txtDataSituacaoCadastral);
            this.gbDadosConsulta.Controls.Add(this.label10);
            this.gbDadosConsulta.Controls.Add(this.txtSituacaoCadastral);
            this.gbDadosConsulta.Controls.Add(this.label8);
            this.gbDadosConsulta.Controls.Add(this.txtBoxEnteFederativo);
            this.gbDadosConsulta.Controls.Add(this.label6);
            this.gbDadosConsulta.Controls.Add(this.txtTelefone);
            this.gbDadosConsulta.Controls.Add(this.label7);
            this.gbDadosConsulta.Controls.Add(this.txtEmail);
            this.gbDadosConsulta.Controls.Add(this.label4);
            this.gbDadosConsulta.Controls.Add(this.txtComplemento);
            this.gbDadosConsulta.Controls.Add(this.label3);
            this.gbDadosConsulta.Controls.Add(this.txtBoxNaturezaJuridica);
            this.gbDadosConsulta.Controls.Add(this.lblBairro);
            this.gbDadosConsulta.Controls.Add(this.txtBairro);
            this.gbDadosConsulta.Controls.Add(this.lblNomeFantasia);
            this.gbDadosConsulta.Controls.Add(this.txtFantasia);
            this.gbDadosConsulta.Controls.Add(this.lblUF);
            this.gbDadosConsulta.Controls.Add(this.txtUF);
            this.gbDadosConsulta.Controls.Add(this.lblCidade);
            this.gbDadosConsulta.Controls.Add(this.txtCidade);
            this.gbDadosConsulta.Controls.Add(this.label5);
            this.gbDadosConsulta.Controls.Add(this.txtCnae);
            this.gbDadosConsulta.Controls.Add(this.lblEndereco);
            this.gbDadosConsulta.Controls.Add(this.txtEndereco);
            this.gbDadosConsulta.Controls.Add(this.lblCep);
            this.gbDadosConsulta.Controls.Add(this.txtCep);
            this.gbDadosConsulta.Controls.Add(this.lblRazao);
            this.gbDadosConsulta.Controls.Add(this.txtRazao);
            this.gbDadosConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDadosConsulta.Location = new System.Drawing.Point(289, 12);
            this.gbDadosConsulta.Name = "gbDadosConsulta";
            this.gbDadosConsulta.Size = new System.Drawing.Size(477, 544);
            this.gbDadosConsulta.TabIndex = 11;
            this.gbDadosConsulta.TabStop = false;
            this.gbDadosConsulta.Text = "Dados da Empresa:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(12, 278);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 13);
            this.label15.TabIndex = 40;
            this.label15.Text = "CEP:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(12, 149);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(283, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "Código e Descrição da Atividade Econômica Secundárias:";
            // 
            // txtSecundarias
            // 
            this.txtSecundarias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecundarias.Location = new System.Drawing.Point(12, 167);
            this.txtSecundarias.Name = "txtSecundarias";
            this.txtSecundarias.Size = new System.Drawing.Size(453, 20);
            this.txtSecundarias.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(292, 492);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "Data da Situação Especial:";
            // 
            // txtDataSituacaoEspecial
            // 
            this.txtDataSituacaoEspecial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataSituacaoEspecial.Location = new System.Drawing.Point(295, 510);
            this.txtDataSituacaoEspecial.Name = "txtDataSituacaoEspecial";
            this.txtDataSituacaoEspecial.Size = new System.Drawing.Size(169, 20);
            this.txtDataSituacaoEspecial.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(9, 492);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Situação Especial:";
            // 
            // txtSituacaoEspecial
            // 
            this.txtSituacaoEspecial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSituacaoEspecial.Location = new System.Drawing.Point(12, 510);
            this.txtSituacaoEspecial.Name = "txtSituacaoEspecial";
            this.txtSituacaoEspecial.Size = new System.Drawing.Size(277, 20);
            this.txtSituacaoEspecial.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(9, 449);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(149, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Motivo de Situação Cadastral:";
            // 
            // txtMotivoSituacaoCadastral
            // 
            this.txtMotivoSituacaoCadastral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivoSituacaoCadastral.Location = new System.Drawing.Point(12, 467);
            this.txtMotivoSituacaoCadastral.Name = "txtMotivoSituacaoCadastral";
            this.txtMotivoSituacaoCadastral.Size = new System.Drawing.Size(453, 20);
            this.txtMotivoSituacaoCadastral.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(294, 406);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Data da Situação Cadastral:";
            // 
            // txtDataSituacaoCadastral
            // 
            this.txtDataSituacaoCadastral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataSituacaoCadastral.Location = new System.Drawing.Point(295, 424);
            this.txtDataSituacaoCadastral.Name = "txtDataSituacaoCadastral";
            this.txtDataSituacaoCadastral.Size = new System.Drawing.Size(169, 20);
            this.txtDataSituacaoCadastral.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(9, 406);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Situação Cadastral:";
            // 
            // txtSituacaoCadastral
            // 
            this.txtSituacaoCadastral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSituacaoCadastral.Location = new System.Drawing.Point(12, 424);
            this.txtSituacaoCadastral.Name = "txtSituacaoCadastral";
            this.txtSituacaoCadastral.Size = new System.Drawing.Size(277, 20);
            this.txtSituacaoCadastral.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(11, 363);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Ente Federativo Responsável (EFR):";
            // 
            // txtBoxEnteFederativo
            // 
            this.txtBoxEnteFederativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxEnteFederativo.Location = new System.Drawing.Point(12, 381);
            this.txtBoxEnteFederativo.Name = "txtBoxEnteFederativo";
            this.txtBoxEnteFederativo.Size = new System.Drawing.Size(453, 20);
            this.txtBoxEnteFederativo.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(292, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Telefone:";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefone.Location = new System.Drawing.Point(295, 338);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(169, 20);
            this.txtTelefone.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(9, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Endereço Eletrônico:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(12, 338);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(277, 20);
            this.txtEmail.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(292, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Complemento:";
            // 
            // txtComplemento
            // 
            this.txtComplemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComplemento.Location = new System.Drawing.Point(295, 253);
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(169, 20);
            this.txtComplemento.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(12, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Código e Descrição da Natureza Juídica:";
            // 
            // txtBoxNaturezaJuridica
            // 
            this.txtBoxNaturezaJuridica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxNaturezaJuridica.Location = new System.Drawing.Point(12, 210);
            this.txtBoxNaturezaJuridica.Name = "txtBoxNaturezaJuridica";
            this.txtBoxNaturezaJuridica.Size = new System.Drawing.Size(453, 20);
            this.txtBoxNaturezaJuridica.TabIndex = 9;
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBairro.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblBairro.Location = new System.Drawing.Point(108, 278);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(74, 13);
            this.lblBairro.TabIndex = 15;
            this.lblBairro.Text = "Bairro/Distrito:";
            // 
            // txtBairro
            // 
            this.txtBairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBairro.Location = new System.Drawing.Point(111, 296);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(140, 20);
            this.txtBairro.TabIndex = 13;
            // 
            // lblNomeFantasia
            // 
            this.lblNomeFantasia.AutoSize = true;
            this.lblNomeFantasia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeFantasia.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNomeFantasia.Location = new System.Drawing.Point(12, 63);
            this.lblNomeFantasia.Name = "lblNomeFantasia";
            this.lblNomeFantasia.Size = new System.Drawing.Size(81, 13);
            this.lblNomeFantasia.TabIndex = 13;
            this.lblNomeFantasia.Text = "Nome Fantasia:";
            // 
            // txtFantasia
            // 
            this.txtFantasia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFantasia.Location = new System.Drawing.Point(12, 81);
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.Size = new System.Drawing.Size(453, 20);
            this.txtFantasia.TabIndex = 6;
            // 
            // lblUF
            // 
            this.lblUF.AutoSize = true;
            this.lblUF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUF.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblUF.Location = new System.Drawing.Point(421, 278);
            this.lblUF.Name = "lblUF";
            this.lblUF.Size = new System.Drawing.Size(24, 13);
            this.lblUF.TabIndex = 11;
            this.lblUF.Text = "UF:";
            // 
            // txtUF
            // 
            this.txtUF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUF.Location = new System.Drawing.Point(424, 296);
            this.txtUF.Name = "txtUF";
            this.txtUF.Size = new System.Drawing.Size(39, 20);
            this.txtUF.TabIndex = 15;
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCidade.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCidade.Location = new System.Drawing.Point(254, 278);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(57, 13);
            this.lblCidade.TabIndex = 9;
            this.lblCidade.Text = "Município:";
            // 
            // txtCidade
            // 
            this.txtCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCidade.Location = new System.Drawing.Point(257, 296);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(162, 20);
            this.txtCidade.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(12, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(264, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Código e Descrição da Atividade Econômica Principal:";
            // 
            // txtCnae
            // 
            this.txtCnae.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCnae.Location = new System.Drawing.Point(12, 124);
            this.txtCnae.Name = "txtCnae";
            this.txtCnae.Size = new System.Drawing.Size(453, 20);
            this.txtCnae.TabIndex = 7;
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndereco.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblEndereco.Location = new System.Drawing.Point(12, 235);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(64, 13);
            this.lblEndereco.TabIndex = 5;
            this.lblEndereco.Text = "Logradouro:";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndereco.Location = new System.Drawing.Point(12, 253);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(277, 20);
            this.txtEndereco.TabIndex = 10;
            // 
            // lblCep
            // 
            this.lblCep.AutoSize = true;
            this.lblCep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCep.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCep.Location = new System.Drawing.Point(12, 257);
            this.lblCep.Name = "lblCep";
            this.lblCep.Size = new System.Drawing.Size(31, 13);
            this.lblCep.TabIndex = 3;
            this.lblCep.Text = "CEP:";
            // 
            // txtCep
            // 
            this.txtCep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCep.Location = new System.Drawing.Point(12, 296);
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(93, 20);
            this.txtCep.TabIndex = 12;
            // 
            // lblRazao
            // 
            this.lblRazao.AutoSize = true;
            this.lblRazao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazao.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRazao.Location = new System.Drawing.Point(12, 20);
            this.lblRazao.Name = "lblRazao";
            this.lblRazao.Size = new System.Drawing.Size(73, 13);
            this.lblRazao.TabIndex = 1;
            this.lblRazao.Text = "Razão Social:";
            // 
            // txtRazao
            // 
            this.txtRazao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazao.Location = new System.Drawing.Point(12, 38);
            this.txtRazao.Name = "txtRazao";
            this.txtRazao.Size = new System.Drawing.Size(453, 20);
            this.txtRazao.TabIndex = 5;
            // 
            // metroButton5
            // 
            this.metroButton5.Location = new System.Drawing.Point(602, 562);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(150, 35);
            this.metroButton5.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton5.TabIndex = 23;
            this.metroButton5.TabStop = false;
            this.metroButton5.Text = "CANCELAR";
            this.metroButton5.UseSelectable = true;
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // FormConsultaSintegra
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 610);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbDadosConsulta);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConsultaSintegra";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CONSULTA CNPJ RFB";
            this.Load += new System.EventHandler(this.FormConsultaSintegra_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLetras)).EndInit();
            this.gbDadosConsulta.ResumeLayout(false);
            this.gbDadosConsulta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.MaskedTextBox maskedTxtCNPJ;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ttbLetras;
        private System.Windows.Forms.Label lblCaptcha;
        private System.Windows.Forms.PictureBox picLetras;
        private System.Windows.Forms.GroupBox gbDadosConsulta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSecundarias;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDataSituacaoEspecial;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSituacaoEspecial;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMotivoSituacaoCadastral;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDataSituacaoCadastral;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSituacaoCadastral;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBoxEnteFederativo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxNaturezaJuridica;
        private System.Windows.Forms.Label lblBairro;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label lblNomeFantasia;
        private System.Windows.Forms.TextBox txtFantasia;
        private System.Windows.Forms.Label lblUF;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCnae;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label lblCep;
        private System.Windows.Forms.TextBox txtCep;
        private System.Windows.Forms.Label lblRazao;
        private System.Windows.Forms.TextBox txtRazao;
        private MetroFramework.Controls.MetroButton metroButton5;
        private System.Windows.Forms.Label label15;
    }
}