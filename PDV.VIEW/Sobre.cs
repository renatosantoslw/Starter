using MetroFramework.Forms;
using PDV.VIEW.App_Context;
using System;
using System.Windows.Forms;

namespace PDV.VIEW
{
    public partial class Sobre : DevExpress.XtraEditors.XtraForm
    {
        public Sobre()
        {
            InitializeComponent();
            ovTXT_Versao.Text = Contexto.VERSAO.ToString();
            ovTXT_Footer.Text = string.Format("Copyright ©  {0} - Todos os Direitos Reservados\r\n Software", DateTime.Now.Year);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Escape):
                    Close();
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
