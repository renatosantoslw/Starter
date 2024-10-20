namespace PDV.VIEW.Forms.Cadastro
{
    partial class FCA_Usuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_Usuario));
            this.ovCMB_Perfil = new MetroFramework.Controls.MetroComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ovTXT_Email = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ovTXT_ConfirmaSenha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ovTXT_Login = new System.Windows.Forms.MaskedTextBox();
            this.ovTXT_Nome = new System.Windows.Forms.MaskedTextBox();
            this.ovCKB_Ativo = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ovLBL_RazaoSocial = new System.Windows.Forms.Label();
            this.ovTXT_Senha = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ovCMB_UsuarioSupervisor = new MetroFramework.Controls.MetroComboBox();
            this.ovTXT_Pin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tipoDescontoComboBox = new MetroFramework.Controls.MetroComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.formaDescontoCombobox = new MetroFramework.Controls.MetroComboBox();
            this.labelFormaDeDesconto = new System.Windows.Forms.Label();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.ovCKB_IsVendedor = new System.Windows.Forms.CheckBox();
            this.ovCKB_IsComprador = new System.Windows.Forms.CheckBox();
            this.textEditDescontoMaximo = new DevExpress.XtraEditors.SpinEdit();
            this.labelDescontoMaximo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDescontoMaximo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ovCMB_Perfil
            // 
            this.ovCMB_Perfil.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_Perfil.FormattingEnabled = true;
            this.ovCMB_Perfil.ItemHeight = 19;
            this.ovCMB_Perfil.Location = new System.Drawing.Point(26, 186);
            this.ovCMB_Perfil.Name = "ovCMB_Perfil";
            this.ovCMB_Perfil.Size = new System.Drawing.Size(268, 25);
            this.ovCMB_Perfil.TabIndex = 7;
            this.ovCMB_Perfil.UseSelectable = true;
            this.ovCMB_Perfil.DropDown += new System.EventHandler(this.ovCMB_Perfil_DropDown);
            this.ovCMB_Perfil.SelectedIndexChanged += new System.EventHandler(this.ovCMB_Perfil_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "* Perfil:";
            // 
            // ovTXT_Email
            // 
            this.ovTXT_Email.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Email.Location = new System.Drawing.Point(439, 79);
            this.ovTXT_Email.Name = "ovTXT_Email";
            this.ovTXT_Email.Size = new System.Drawing.Size(273, 21);
            this.ovTXT_Email.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(436, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "E-mail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(430, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "* Confirmar Senha:";
            // 
            // ovTXT_ConfirmaSenha
            // 
            this.ovTXT_ConfirmaSenha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_ConfirmaSenha.Location = new System.Drawing.Point(439, 132);
            this.ovTXT_ConfirmaSenha.Name = "ovTXT_ConfirmaSenha";
            this.ovTXT_ConfirmaSenha.PasswordChar = '*';
            this.ovTXT_ConfirmaSenha.Size = new System.Drawing.Size(273, 21);
            this.ovTXT_ConfirmaSenha.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "* Senha:";
            // 
            // ovTXT_Login
            // 
            this.ovTXT_Login.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Login.Location = new System.Drawing.Point(26, 79);
            this.ovTXT_Login.Name = "ovTXT_Login";
            this.ovTXT_Login.Size = new System.Drawing.Size(268, 21);
            this.ovTXT_Login.TabIndex = 3;
            // 
            // ovTXT_Nome
            // 
            this.ovTXT_Nome.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Nome.Location = new System.Drawing.Point(26, 28);
            this.ovTXT_Nome.Name = "ovTXT_Nome";
            this.ovTXT_Nome.Size = new System.Drawing.Size(686, 21);
            this.ovTXT_Nome.TabIndex = 1;
            // 
            // ovCKB_Ativo
            // 
            this.ovCKB_Ativo.AutoSize = true;
            this.ovCKB_Ativo.Checked = true;
            this.ovCKB_Ativo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ovCKB_Ativo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCKB_Ativo.Location = new System.Drawing.Point(657, 308);
            this.ovCKB_Ativo.Name = "ovCKB_Ativo";
            this.ovCKB_Ativo.Size = new System.Drawing.Size(51, 17);
            this.ovCKB_Ativo.TabIndex = 2;
            this.ovCKB_Ativo.Text = "Ativo";
            this.ovCKB_Ativo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "* Nome:";
            // 
            // ovLBL_RazaoSocial
            // 
            this.ovLBL_RazaoSocial.AutoSize = true;
            this.ovLBL_RazaoSocial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovLBL_RazaoSocial.Location = new System.Drawing.Point(20, 60);
            this.ovLBL_RazaoSocial.Name = "ovLBL_RazaoSocial";
            this.ovLBL_RazaoSocial.Size = new System.Drawing.Size(45, 13);
            this.ovLBL_RazaoSocial.TabIndex = 3;
            this.ovLBL_RazaoSocial.Text = "* Login:";
            // 
            // ovTXT_Senha
            // 
            this.ovTXT_Senha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Senha.Location = new System.Drawing.Point(26, 132);
            this.ovTXT_Senha.Name = "ovTXT_Senha";
            this.ovTXT_Senha.PasswordChar = '*';
            this.ovTXT_Senha.Size = new System.Drawing.Size(268, 21);
            this.ovTXT_Senha.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(430, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 75;
            this.label6.Text = "* Supervisor:";
            // 
            // ovCMB_UsuarioSupervisor
            // 
            this.ovCMB_UsuarioSupervisor.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_UsuarioSupervisor.FormattingEnabled = true;
            this.ovCMB_UsuarioSupervisor.ItemHeight = 19;
            this.ovCMB_UsuarioSupervisor.Location = new System.Drawing.Point(439, 186);
            this.ovCMB_UsuarioSupervisor.Name = "ovCMB_UsuarioSupervisor";
            this.ovCMB_UsuarioSupervisor.Size = new System.Drawing.Size(273, 25);
            this.ovCMB_UsuarioSupervisor.TabIndex = 8;
            this.ovCMB_UsuarioSupervisor.UseSelectable = true;
            // 
            // ovTXT_Pin
            // 
            this.ovTXT_Pin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Pin.Location = new System.Drawing.Point(26, 246);
            this.ovTXT_Pin.Name = "ovTXT_Pin";
            this.ovTXT_Pin.PasswordChar = '*';
            this.ovTXT_Pin.Size = new System.Drawing.Size(268, 21);
            this.ovTXT_Pin.TabIndex = 76;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 77;
            this.label7.Text = "PIN:";
            // 
            // tipoDescontoComboBox
            // 
            this.tipoDescontoComboBox.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.tipoDescontoComboBox.FormattingEnabled = true;
            this.tipoDescontoComboBox.ItemHeight = 19;
            this.tipoDescontoComboBox.Items.AddRange(new object[] {
            "Venda",
            "Produto",
            "Não Concede Desconto"});
            this.tipoDescontoComboBox.Location = new System.Drawing.Point(439, 246);
            this.tipoDescontoComboBox.Name = "tipoDescontoComboBox";
            this.tipoDescontoComboBox.Size = new System.Drawing.Size(273, 25);
            this.tipoDescontoComboBox.TabIndex = 78;
            this.tipoDescontoComboBox.UseSelectable = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(436, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 79;
            this.label8.Text = "Tipo de Desconto";
            // 
            // formaDescontoCombobox
            // 
            this.formaDescontoCombobox.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.formaDescontoCombobox.FormattingEnabled = true;
            this.formaDescontoCombobox.ItemHeight = 19;
            this.formaDescontoCombobox.Items.AddRange(new object[] {
            "Valor",
            "Percentual"});
            this.formaDescontoCombobox.Location = new System.Drawing.Point(26, 308);
            this.formaDescontoCombobox.Name = "formaDescontoCombobox";
            this.formaDescontoCombobox.Size = new System.Drawing.Size(268, 25);
            this.formaDescontoCombobox.TabIndex = 80;
            this.formaDescontoCombobox.UseSelectable = true;
            this.formaDescontoCombobox.SelectedIndexChanged += new System.EventHandler(this.formaDescontoCombobox_SelectedIndexChanged);
            // 
            // labelFormaDeDesconto
            // 
            this.labelFormaDeDesconto.AutoSize = true;
            this.labelFormaDeDesconto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFormaDeDesconto.Location = new System.Drawing.Point(23, 292);
            this.labelFormaDeDesconto.Name = "labelFormaDeDesconto";
            this.labelFormaDeDesconto.Size = new System.Drawing.Size(113, 13);
            this.labelFormaDeDesconto.TabIndex = 81;
            this.labelFormaDeDesconto.Text = "* Forma de Desconto:";
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(700, 555);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(88, 33);
            this.metroButton4.TabIndex = 113;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.ovBTN_Salvar_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton3.Appearance.Options.UseForeColor = true;
            this.metroButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton3.ImageOptions.Image")));
            this.metroButton3.Location = new System.Drawing.Point(606, 555);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton3.Size = new System.Drawing.Size(88, 33);
            this.metroButton3.TabIndex = 112;
            this.metroButton3.Text = "Cancelar";
            this.metroButton3.Click += new System.EventHandler(this.ovBTN_Cancelar_Click);
            // 
            // ovCKB_IsVendedor
            // 
            this.ovCKB_IsVendedor.AutoSize = true;
            this.ovCKB_IsVendedor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCKB_IsVendedor.Location = new System.Drawing.Point(442, 308);
            this.ovCKB_IsVendedor.Name = "ovCKB_IsVendedor";
            this.ovCKB_IsVendedor.Size = new System.Drawing.Size(72, 17);
            this.ovCKB_IsVendedor.TabIndex = 114;
            this.ovCKB_IsVendedor.Text = "Vendedor";
            this.ovCKB_IsVendedor.UseVisualStyleBackColor = true;
            // 
            // ovCKB_IsComprador
            // 
            this.ovCKB_IsComprador.AutoSize = true;
            this.ovCKB_IsComprador.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCKB_IsComprador.Location = new System.Drawing.Point(541, 308);
            this.ovCKB_IsComprador.Name = "ovCKB_IsComprador";
            this.ovCKB_IsComprador.Size = new System.Drawing.Size(79, 17);
            this.ovCKB_IsComprador.TabIndex = 115;
            this.ovCKB_IsComprador.Text = "Comprador";
            this.ovCKB_IsComprador.UseVisualStyleBackColor = true;
            // 
            // textEditDescontoMaximo
            // 
            this.textEditDescontoMaximo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textEditDescontoMaximo.Location = new System.Drawing.Point(26, 369);
            this.textEditDescontoMaximo.Name = "textEditDescontoMaximo";
            this.textEditDescontoMaximo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditDescontoMaximo.Properties.Appearance.Options.UseFont = true;
            this.textEditDescontoMaximo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEditDescontoMaximo.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.textEditDescontoMaximo.Properties.Mask.EditMask = "p";
            this.textEditDescontoMaximo.Size = new System.Drawing.Size(268, 20);
            this.textEditDescontoMaximo.TabIndex = 116;
            // 
            // labelDescontoMaximo
            // 
            this.labelDescontoMaximo.AutoSize = true;
            this.labelDescontoMaximo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescontoMaximo.Location = new System.Drawing.Point(23, 353);
            this.labelDescontoMaximo.Name = "labelDescontoMaximo";
            this.labelDescontoMaximo.Size = new System.Drawing.Size(104, 13);
            this.labelDescontoMaximo.TabIndex = 117;
            this.labelDescontoMaximo.Text = "* Desconto Máximo:";
            // 
            // FCA_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.labelDescontoMaximo);
            this.Controls.Add(this.ovCKB_IsComprador);
            this.Controls.Add(this.ovCKB_IsVendedor);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.formaDescontoCombobox);
            this.Controls.Add(this.labelFormaDeDesconto);
            this.Controls.Add(this.tipoDescontoComboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ovTXT_Pin);
            this.Controls.Add(this.ovCMB_UsuarioSupervisor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ovCMB_Perfil);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ovLBL_RazaoSocial);
            this.Controls.Add(this.ovCKB_Ativo);
            this.Controls.Add(this.ovTXT_ConfirmaSenha);
            this.Controls.Add(this.ovTXT_Email);
            this.Controls.Add(this.ovTXT_Nome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ovTXT_Login);
            this.Controls.Add(this.ovTXT_Senha);
            this.Controls.Add(this.textEditDescontoMaximo);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FCA_Usuario";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Usuário/Vendedor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_Usuario_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.textEditDescontoMaximo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox ovTXT_Nome;
        private System.Windows.Forms.CheckBox ovCKB_Ativo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ovLBL_RazaoSocial;
        private System.Windows.Forms.TextBox ovTXT_Senha;
        private System.Windows.Forms.MaskedTextBox ovTXT_Login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ovTXT_ConfirmaSenha;
        private System.Windows.Forms.MaskedTextBox ovTXT_Email;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroComboBox ovCMB_Perfil;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private MetroFramework.Controls.MetroComboBox ovCMB_UsuarioSupervisor;
        private System.Windows.Forms.TextBox ovTXT_Pin;
        private System.Windows.Forms.Label label7;
        private MetroFramework.Controls.MetroComboBox tipoDescontoComboBox;
        private System.Windows.Forms.Label label8;
        private MetroFramework.Controls.MetroComboBox formaDescontoCombobox;
        private System.Windows.Forms.Label labelFormaDeDesconto;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton3;
        private System.Windows.Forms.CheckBox ovCKB_IsVendedor;
        private System.Windows.Forms.CheckBox ovCKB_IsComprador;
        private DevExpress.XtraEditors.SpinEdit textEditDescontoMaximo;
        private System.Windows.Forms.Label labelDescontoMaximo;
    }
}