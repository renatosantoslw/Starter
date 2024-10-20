using PDV.UTIL.Components;
using System;
using System.Windows.Forms;

namespace Aplicacao
{
    public class InputBox : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox txtInput;
        private Button cmdOK;
        private Button cmdCancel;
        private System.ComponentModel.Container components = null;
        public bool confirmado;
        public String  ValorUsuario { get; set; }
        public InputBox(string Valor)
        {
            InitializeComponent();
            ValorUsuario = Valor;
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
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(16, 16);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(256, 27);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.ForeColor = System.Drawing.Color.White;
            this.cmdOK.Location = new System.Drawing.Point(124, 51);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(71, 26);
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
            this.cmdCancel.Location = new System.Drawing.Point(201, 51);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(71, 26);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancelar";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // InputBox
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 20);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(286, 89);
            this.ControlBox = false;
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtInput);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputBox";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.InputBox_Shown);
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
            if (this.Text == "Motivo Cancelamento" && txtInput.Text.Trim().Length < 15)
            {
                MessageBox.Show("Motivo de Cancelamento deve ter no mínimo 15 caracteres");
                txtInput.Focus();
                return;
            }
            this.confirmado = true;
            this.Close();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            if (this.Text.Contains("Infome o valor recebido"))
                DecimalMoeda.Moeda(ref txtInput);
        }

        private void InputBox_Shown(object sender, EventArgs e)
        {
            if (this.Text.Contains("Infome o valor recebido"))
                txtInput.Text = ValorUsuario;
        }
    }
}
