namespace PDV.VIEW.Forms.Cadastro
{
    partial class FCA_PerfilAcesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_PerfilAcesso));
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_Descricao = new System.Windows.Forms.TextBox();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.ovCKB_Admin = new System.Windows.Forms.CheckBox();
            this.ovCKB_Ativo = new System.Windows.Forms.CheckBox();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.ovTV_Itens = new System.Windows.Forms.TreeView();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(21, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "* Descrição:";
            // 
            // ovTXT_Descricao
            // 
            this.ovTXT_Descricao.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Descricao.Location = new System.Drawing.Point(24, 41);
            this.ovTXT_Descricao.Name = "ovTXT_Descricao";
            this.ovTXT_Descricao.Size = new System.Drawing.Size(506, 21);
            this.ovTXT_Descricao.TabIndex = 1;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Location = new System.Drawing.Point(24, 7);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(754, 542);
            this.metroTabControl1.TabIndex = 9;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.ovCKB_Admin);
            this.metroTabPage1.Controls.Add(this.ovCKB_Ativo);
            this.metroTabPage1.Controls.Add(this.label3);
            this.metroTabPage1.Controls.Add(this.ovTXT_Descricao);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(746, 500);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Identificação";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // ovCKB_Admin
            // 
            this.ovCKB_Admin.AutoSize = true;
            this.ovCKB_Admin.BackColor = System.Drawing.Color.White;
            this.ovCKB_Admin.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovCKB_Admin.Location = new System.Drawing.Point(553, 43);
            this.ovCKB_Admin.Name = "ovCKB_Admin";
            this.ovCKB_Admin.Size = new System.Drawing.Size(90, 17);
            this.ovCKB_Admin.TabIndex = 5;
            this.ovCKB_Admin.Text = "Admnistrador";
            this.ovCKB_Admin.UseVisualStyleBackColor = false;
            // 
            // ovCKB_Ativo
            // 
            this.ovCKB_Ativo.AutoSize = true;
            this.ovCKB_Ativo.BackColor = System.Drawing.Color.White;
            this.ovCKB_Ativo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovCKB_Ativo.Location = new System.Drawing.Point(663, 43);
            this.ovCKB_Ativo.Name = "ovCKB_Ativo";
            this.ovCKB_Ativo.Size = new System.Drawing.Size(51, 17);
            this.ovCKB_Ativo.TabIndex = 2;
            this.ovCKB_Ativo.Text = "Ativo";
            this.ovCKB_Ativo.UseVisualStyleBackColor = false;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.simpleButton1);
            this.metroTabPage2.Controls.Add(this.ovTV_Itens);
            this.metroTabPage2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTabPage2.HorizontalScrollbarBarColor = false;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 0;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(746, 500);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Itens de Menu";
            this.metroTabPage2.VerticalScrollbarBarColor = false;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 0;
            // 
            // ovTV_Itens
            // 
            this.ovTV_Itens.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ovTV_Itens.CheckBoxes = true;
            this.ovTV_Itens.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ovTV_Itens.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTV_Itens.ItemHeight = 20;
            this.ovTV_Itens.Location = new System.Drawing.Point(0, 40);
            this.ovTV_Itens.Name = "ovTV_Itens";
            this.ovTV_Itens.Size = new System.Drawing.Size(746, 460);
            this.ovTV_Itens.TabIndex = 31;
            this.ovTV_Itens.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.ovTV_Itens_AfterCheck);
            this.ovTV_Itens.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ovTV_Itens_NodeMouseClick);
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
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton5.ImageOptions.Image")));
            this.metroButton5.Location = new System.Drawing.Point(606, 555);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(88, 33);
            this.metroButton5.TabIndex = 112;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.ovBTN_Cancelar_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(620, 13);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton1.Size = new System.Drawing.Size(123, 21);
            this.simpleButton1.TabIndex = 114;
            this.simpleButton1.Text = "Selecionar tudo";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FCA_PerfilAcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.metroTabControl1);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(800, 600);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 648);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(802, 632);
            this.Name = "FCA_PerfilAcesso";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Perfil de Acesso";
            this.Load += new System.EventHandler(this.FCA_PerfilAcesso_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_PerfilAcesso_KeyDown);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ovTXT_Descricao;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private System.Windows.Forms.CheckBox ovCKB_Ativo;
        private System.Windows.Forms.TreeView ovTV_Itens;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private System.Windows.Forms.CheckBox ovCKB_Admin;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}