using MetroFramework.Forms;
using System.IO;

namespace PDV.VIEW.FRENTECAIXA.Forms.PDV.Menu
{
    public partial class FREL_Preview : DevExpress.XtraEditors.XtraForm
    {
        private Stream StreamRel = null;

        public FREL_Preview(Stream St)
        {
            InitializeComponent();
            StreamRel = St;
            pdfViewer1.LoadDocument(StreamRel);
        }

        private void pdfViewer1_PopupMenuShowing(object sender, DevExpress.XtraPdfViewer.PdfPopupMenuShowingEventArgs e)
        {
            e.ItemLinks.Clear();
        }
    }
}
