namespace PDV.VIEW.FRENTECAIXA.Forms.Seletores
{
    partial class SEL_Comanda
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
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.ovGRD_Comandas = new System.Windows.Forms.DataGridView();
            this.ovTXT_Nome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Comandas)).BeginInit();
            this.SuspendLayout();
            // 
            // metroButton5
            // 
            this.metroButton5.Location = new System.Drawing.Point(471, 542);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(150, 35);
            this.metroButton5.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton5.TabIndex = 29;
            this.metroButton5.TabStop = false;
            this.metroButton5.Text = "[ESC] - CANCELAR";
            this.metroButton5.UseSelectable = true;
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.Location = new System.Drawing.Point(627, 542);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(150, 35);
            this.metroButton4.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton4.TabIndex = 28;
            this.metroButton4.TabStop = false;
            this.metroButton4.Text = "[F10] - SELECIONAR";
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // ovGRD_Comandas
            // 
            this.ovGRD_Comandas.AllowUserToAddRows = false;
            this.ovGRD_Comandas.AllowUserToDeleteRows = false;
            this.ovGRD_Comandas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovGRD_Comandas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ovGRD_Comandas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ovGRD_Comandas.BackgroundColor = System.Drawing.Color.White;
            this.ovGRD_Comandas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ovGRD_Comandas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ovGRD_Comandas.DefaultCellStyle = dataGridViewCellStyle1;
            this.ovGRD_Comandas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ovGRD_Comandas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ovGRD_Comandas.Location = new System.Drawing.Point(12, 30);
            this.ovGRD_Comandas.MultiSelect = false;
            this.ovGRD_Comandas.Name = "ovGRD_Comandas";
            this.ovGRD_Comandas.ReadOnly = true;
            this.ovGRD_Comandas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ovGRD_Comandas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ovGRD_Comandas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ovGRD_Comandas.ShowCellErrors = false;
            this.ovGRD_Comandas.ShowEditingIcon = false;
            this.ovGRD_Comandas.ShowRowErrors = false;
            this.ovGRD_Comandas.Size = new System.Drawing.Size(776, 506);
            this.ovGRD_Comandas.TabIndex = 2;
            // 
            // ovTXT_Nome
            // 
            this.ovTXT_Nome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_Nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ovTXT_Nome.Location = new System.Drawing.Point(167, 1);
            this.ovTXT_Nome.Name = "ovTXT_Nome";
            this.ovTXT_Nome.Size = new System.Drawing.Size(621, 23);
            this.ovTXT_Nome.TabIndex = 1;
            this.ovTXT_Nome.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ovTXT_Nome_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Código/Descrição:";
            // 
            // SEL_Comanda
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.ovTXT_Nome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.ovGRD_Comandas);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(802, 632);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(802, 632);
            this.Name = "SEL_Comanda";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PESQUISA DE  COMANDA";
            this.Load += new System.EventHandler(this.SEL_Comanda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ovGRD_Comandas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroButton metroButton4;
        private System.Windows.Forms.DataGridView ovGRD_Comandas;
        private System.Windows.Forms.TextBox ovTXT_Nome;
        private System.Windows.Forms.Label label3;
    }
}