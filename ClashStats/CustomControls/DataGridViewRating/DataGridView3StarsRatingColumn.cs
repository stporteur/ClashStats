using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashStats.CustomControls.DataGridViewRating
{
    public class DataGridView3StarsRatingColumn : DataGridViewImageColumn
    {
        public DataGridView3StarsRatingColumn()
        {
            this.CellTemplate = new DataGridView3StarsRatingCell();
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ValueType = typeof(int);
        }
    }
}
