using System.Drawing;
using System.Windows.Forms;

namespace PDV.UTIL.Components.Custom
{
    public class GridView : DataGridView
    {
        protected DataGridViewCellStyle StyleHeaderColumn = new DataGridViewCellStyle();
        protected DataGridViewCellStyle StyleHeaderRow = new DataGridViewCellStyle();

        private void Set()
        {
            RowHeadersVisible = false;
            ShowCellErrors = false;
            ShowRowErrors = false;
            ShowEditingIcon = false;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MultiSelect = false;
            EnableHeadersVisualStyles = false;

            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ScrollBars = ScrollBars.Vertical;
            BackgroundColor = Color.White;
            BorderStyle = BorderStyle.Fixed3D;
            //ReadOnly = true;

            RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        }

        private void SetColors()
        {
            EnableHeadersVisualStyles = false;
            GridColor = ColorTranslator.FromHtml("#D3D3D3");

            
            StyleHeaderColumn.Alignment = DataGridViewContentAlignment.MiddleLeft;
            StyleHeaderColumn.BackColor = ColorTranslator.FromHtml("#778899");
            StyleHeaderColumn.Font = new Font("Open Sans", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StyleHeaderColumn.ForeColor = Color.White;
            StyleHeaderColumn.SelectionBackColor = ColorTranslator.FromHtml("#778899");
            StyleHeaderColumn.SelectionForeColor = ColorTranslator.FromHtml("#778899");
            StyleHeaderColumn.Padding = new Padding(0, 5, 0, 5);
            StyleHeaderColumn.WrapMode = DataGridViewTriState.True;
            ColumnHeadersDefaultCellStyle = StyleHeaderColumn;

            
            StyleHeaderRow.Alignment = DataGridViewContentAlignment.MiddleLeft;
            StyleHeaderRow.BackColor = SystemColors.Window;
            StyleHeaderRow.Font = new Font("Open Sans", 9.50F);
            StyleHeaderRow.ForeColor = ColorTranslator.FromHtml("#696969");
            StyleHeaderRow.SelectionBackColor = ColorTranslator.FromHtml("#EEE9E9");
            StyleHeaderRow.SelectionForeColor = ColorTranslator.FromHtml("#696969");
            StyleHeaderRow.WrapMode = DataGridViewTriState.True;
            DefaultCellStyle = StyleHeaderRow;
        }

        public GridView()
        {
            Set();
            //SetColors();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            SetColors();
        }        
    }
}
