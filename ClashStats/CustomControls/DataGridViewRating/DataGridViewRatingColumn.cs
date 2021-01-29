using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashStats.CustomControls.DataGridViewRating
{
    public class DataGridViewRatingColumn : DataGridViewImageColumn
    {
        public DataGridViewRatingColumn()
        {
            this.CellTemplate = new DataGridViewRatingCell();
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ValueType = typeof(int);
        }
    }
}
