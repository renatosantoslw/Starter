using PDV.UTIL.Components;
using System;
using System.Windows.Forms;

namespace Aplicacao
{
    public class InputBoxRecarcga : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox txtInput;
        private Button cmdOK;
        private Button cmdCancel;
        private System.ComponentModel.Container components = null;
        private ComboBox ComboBoxOperadorasRecarga;
        private Label label7;
        private NumericUpDown NumericUpDownNumeroRecarga;
        private NumericUpDown NumericUpDownDDDRecarga;
        private Label label5;
        private Label label8;
        private ComboBox ComboBoxProdutosRecarga;
        private Label label6;
        private NumericUpDown NumericUpDownValorRecarga;
        private Label label4;
        public bool confirmado;
        public String  ValorUsuario { get; set; }
        public InputBoxRecarcga(string Valor)
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
            this.ComboBoxOperadorasRecarga = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.NumericUpDownNumeroRecarga = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownDDDRecarga = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ComboBoxProdutosRecarga = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NumericUpDownValorRecarga = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownNumeroRecarga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownDDDRecarga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownValorRecarga)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(16, 16);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(210, 27);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.ForeColor = System.Drawing.Color.White;
            this.cmdOK.Location = new System.Drawing.Point(55, 323);
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
            this.cmdCancel.Location = new System.Drawing.Point(132, 323);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(71, 26);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancelar";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // ComboBoxOperadorasRecarga
            // 
            this.ComboBoxOperadorasRecarga.FormattingEnabled = true;
            this.ComboBoxOperadorasRecarga.Location = new System.Drawing.Point(35, 68);
            this.ComboBoxOperadorasRecarga.Name = "ComboBoxOperadorasRecarga";
            this.ComboBoxOperadorasRecarga.Size = new System.Drawing.Size(191, 27);
            this.ComboBoxOperadorasRecarga.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 19);
            this.label7.TabIndex = 15;
            this.label7.Text = "Número";
            // 
            // NumericUpDownNumeroRecarga
            // 
            this.NumericUpDownNumeroRecarga.Location = new System.Drawing.Point(35, 174);
            this.NumericUpDownNumeroRecarga.Name = "NumericUpDownNumeroRecarga";
            this.NumericUpDownNumeroRecarga.Size = new System.Drawing.Size(191, 27);
            this.NumericUpDownNumeroRecarga.TabIndex = 16;
            // 
            // NumericUpDownDDDRecarga
            // 
            this.NumericUpDownDDDRecarga.Location = new System.Drawing.Point(35, 119);
            this.NumericUpDownDDDRecarga.Name = "NumericUpDownDDDRecarga";
            this.NumericUpDownDDDRecarga.Size = new System.Drawing.Size(191, 27);
            this.NumericUpDownDDDRecarga.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "Produto";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 19);
            this.label8.TabIndex = 17;
            this.label8.Text = "DDD";
            // 
            // ComboBoxProdutosRecarga
            // 
            this.ComboBoxProdutosRecarga.FormattingEnabled = true;
            this.ComboBoxProdutosRecarga.Location = new System.Drawing.Point(35, 226);
            this.ComboBoxProdutosRecarga.Name = "ComboBoxProdutosRecarga";
            this.ComboBoxProdutosRecarga.Size = new System.Drawing.Size(191, 27);
            this.ComboBoxProdutosRecarga.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "Valor";
            // 
            // NumericUpDownValorRecarga
            // 
            this.NumericUpDownValorRecarga.Location = new System.Drawing.Point(36, 278);
            this.NumericUpDownValorRecarga.Name = "NumericUpDownValorRecarga";
            this.NumericUpDownValorRecarga.Size = new System.Drawing.Size(190, 27);
            this.NumericUpDownValorRecarga.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "Operadora";
            // 
            // InputBoxRecarcga
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 20);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(247, 374);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ComboBoxOperadorasRecarga);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.NumericUpDownNumeroRecarga);
            this.Controls.Add(this.NumericUpDownDDDRecarga);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ComboBoxProdutosRecarga);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.NumericUpDownValorRecarga);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtInput);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InputBoxRecarcga";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputBox";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.InputBox_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownNumeroRecarga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownDDDRecarga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownValorRecarga)).EndInit();
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
