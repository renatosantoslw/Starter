using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aplicacao
{
    public class InputBoxFormaPagamento : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox txtInput;
        private Button cmdOK;
        private Button cmdCancel;
        private System.ComponentModel.Container components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        public bool confirmado;

        public InputBoxFormaPagamento()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(88, 24);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(111, 27);
            this.txtInput.TabIndex = 0;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.ForeColor = System.Drawing.Color.White;
            this.cmdOK.Location = new System.Drawing.Point(34, 192);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(91, 37);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.ForeColor = System.Drawing.Color.White;
            this.cmdCancel.Location = new System.Drawing.Point(143, 192);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(90, 37);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancelar";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "1- Débito";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(101, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "2- Crédito";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(101, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "3 - Crédiario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(101, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "4 - TiketCar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(101, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "5 - Recarga";
            // 
            // InputBoxFormaPagamento
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 20);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(286, 241);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtInput);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InputBoxFormaPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputBox";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.InputBoxFormaPagamento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void txtInput_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmdOK.PerformClick();
            else if (e.KeyCode == Keys.Escape)
                cmdCancel.PerformClick();
        }

        public bool Show(string previewInput, out string input)
        {
            this.txtInput.Text = previewInput;
            base.ShowDialog();
            input = this.txtInput.Text;
            return this.confirmado;
        }

        public bool Show(string previewInput, string aTextoTela, out string input)
        {
            this.txtInput.Text = previewInput;
            this.Text = aTextoTela;
            base.ShowDialog();
            input = this.txtInput.Text;
            return this.confirmado;
        }

        public bool Show(out string input)
        {
            this.txtInput.Text = "";
            base.ShowDialog();
            input = this.txtInput.Text;
            return this.confirmado;
        }

        public bool ShowDialog(out string input)
        {
            return this.Show(out input);
        }

        public bool Show(IWin32Window owner, out string input)
        {
            this.txtInput.Text = "";
            base.ShowDialog(owner);
            input = this.txtInput.Text;
            return this.confirmado;
        }

        public bool ShowDialog(IWin32Window owner, out string input)
        {
            return this.Show(owner, out input);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.confirmado = false;
            txtInput.Text = "";
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (this.Text == "Forma Pagamento" && txtInput.Text.Trim().Length > 2)
            {
                MessageBox.Show("A forma deve conter dois digitos. Exemplo : 01, 02!");
                txtInput.Focus();
                return;
            }
            this.confirmado = true;
            this.Close();
        }

        private void InputBoxFormaPagamento_Load(object sender, EventArgs e)
        {

        }
    }
}
