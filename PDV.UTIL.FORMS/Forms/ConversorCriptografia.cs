using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.API.Native;
using MetroFramework;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.CriptografiaMD5;
using PDV.DAO.DB.Utils;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PDV.UTIL.FORMS.Forms
{
    public partial class ConversorCriptografia : Form
    {
        public ConversorCriptografia()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textoEncriptografadoText.Text = Criptografia.CodificaSenha(textoDescriptografadoText.Text);
        }

        private void textEncriptografadoText_TextChanged(object sender, EventArgs e)
        {
            textoDescriptografadoText.Text = Criptografia.DecodificaSenha(textoEncriptografadoText.Text);
        }

        private void copiarTextoDescriptografadoBtn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textoDescriptografadoText.Text);
        }

        private void copiarTextoEncriptografadoBtn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textoEncriptografadoText.Text);
        }

        private void verTextoDescriptografadoBtn_Click(object sender, EventArgs e)
        {
            textoDescriptografadoText.UseSystemPasswordChar = !textoDescriptografadoText.UseSystemPasswordChar;
        }

        private void verTextoEncriptografadoBtn_Click(object sender, EventArgs e)
        {
            textoEncriptografadoText.UseSystemPasswordChar = !textoEncriptografadoText.UseSystemPasswordChar;
        }
    }
}
