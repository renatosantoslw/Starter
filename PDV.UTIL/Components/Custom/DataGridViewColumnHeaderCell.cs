using System.Drawing;
using System.Windows.Forms;

namespace PDV.UTIL.Components.Custom
{
    public class DataGridViewCheckBoxColumnHeaderCell : DataGridViewColumnHeaderCell
    {
        private Rectangle CheckBoxRegion;
        private bool checkAll = false;

        protected override void Paint(Graphics graphics,
            Rectangle clipBounds,
            Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates dataGridViewElementState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            graphics.FillRectangle(new SolidBrush(Color.Transparent), cellBounds);
            CheckBoxRegion = new Rectangle((cellBounds.Width / 2) - 5, cellBounds.Location.Y + 2, 14, cellBounds.Size.Height);

            if (checkAll)
                ControlPaint.DrawCheckBox(graphics, CheckBoxRegion, ButtonState.Checked);
            else
                ControlPaint.DrawCheckBox(graphics, CheckBoxRegion, ButtonState.Normal);

            //Rectangle normalRegion = new Rectangle(cellBounds.Location.X + 1 + 25, cellBounds.Location.Y, cellBounds.Size.Width - 26, cellBounds.Size.Height);
            //graphics.DrawString(value.ToString(), cellStyle.Font, new SolidBrush(cellStyle.ForeColor), normalRegion);
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Rectangle rec = new Rectangle(new Point(0, 0), CheckBoxRegion.Size);
            checkAll = !checkAll;

            if (rec.Contains(e.Location))
                DataGridView.Invalidate();
            base.OnMouseClick(e);
        }

        public bool CheckAll
        {
            get { return checkAll; }
            set { checkAll = value; }
        }
    }
}