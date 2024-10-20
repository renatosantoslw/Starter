using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraPrinting;
using System;

namespace PDV.VIEW.Forms.Util
{
    public class GridImprimir
    {
        public static void FormatarImpressão(ref PrintInitializeEventArgs e)
        {
            var pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.Landscape = true;
            pb.PageSettings.LeftMargin =
            pb.PageSettings.RightMargin =
            pb.PageSettings.TopMargin =
            pb.PageSettings.BottomMargin = 5;
        }
    }
}