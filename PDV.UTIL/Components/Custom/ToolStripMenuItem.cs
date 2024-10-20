using System;
using System.Windows.Forms;

namespace PDV.UTIL.Components.Custom
{
    public class ToolStripMenuItem : System.Windows.Forms.ToolStripMenuItem
    {
        public decimal IDItemMenu { get; set; }

        public ToolStripMenuItem() { }

        public static explicit operator ToolStripMenuItem(Control v)
        {
            return (ToolStripMenuItem)v;
        }
    }
}
