using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClashStats.CustomControls.DataGridViewDateTimePicker
{
    public class DataGridViewDateTimePickerColumn : DataGridViewTextBoxColumn
    {
        private bool _initialized;
        private DateTimePicker _dateTimePickerControl { get; set; }
        protected override void OnDataGridViewChanged()
        {
            base.OnDataGridViewChanged();

            if (!_initialized)
            {
                DataGridView.CellClick += DataGridView_CellClick;
                _initialized = true;
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Index)
            {
                // initialize DateTimePicker
                _dateTimePickerControl = new DateTimePicker();
                _dateTimePickerControl.Format = DateTimePickerFormat.Short;
                _dateTimePickerControl.Visible = true;

                var dateTimeToSet = DateTime.Today;
                if (DataGridView.CurrentCell.Value.ToString() != new DateTime().ToString())
                {
                    dateTimeToSet = (DateTime)DataGridView.CurrentCell.Value;
                }
                _dateTimePickerControl.Value = dateTimeToSet;

                // set size and location
                var rect = DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                _dateTimePickerControl.Size = new Size(rect.Width, rect.Height);
                _dateTimePickerControl.Location = new Point(rect.X, rect.Y);

                // attach events
                _dateTimePickerControl.CloseUp += new EventHandler(dtp_CloseUp);
                _dateTimePickerControl.TextChanged += new EventHandler(dtp_OnTextChange);

                DataGridView.Controls.Add(_dateTimePickerControl);
            }
        }

        private void dtp_OnTextChange(object sender, EventArgs e)
        {
            DataGridView.CurrentCell.Value = _dateTimePickerControl.Value;
        }

        void dtp_CloseUp(object sender, EventArgs e)
        {
            _dateTimePickerControl.Visible = false;
        }
    }
}