using DevExpress.XtraBars.Alerter;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.UTIL.FORMS.Forms
{
    public partial class SenhaMestraForm : DevExpress.XtraEditors.XtraForm
    {
        public bool SenhaCorreta { get; private set; } = false;
        public SenhaMestraForm()
        {
            InitializeComponent();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (senha.Text == "&123")
            {
                SenhaCorreta = true;
                Close();
            }
            else
            {
                Alert("Senha incorreta!");
            }
        }

        private void Alert(string msg)
        {
            MessageBox.Show(msg, "Senha mestra", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
