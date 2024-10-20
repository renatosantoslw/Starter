using MetroFramework.Forms;
using System.IO;
using System.Windows.Forms;

namespace PDV.NFCE.MOTORCONTINGENCIA
{
    public partial class Sobre : MetroForm
    {
        public Sobre()
        {
            InitializeComponent();
            ovTXT_Versao.Text = "Versão: v" + System.Diagnostics.FileVersionInfo.GetVersionInfo(Path.GetFullPath(".") + "/PDV.NFCE.MOTORCONTINGENCIA.exe").ProductVersion;
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
